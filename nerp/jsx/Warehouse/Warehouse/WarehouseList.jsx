var WarehouseList = React.createClass({
    getInitialState: function () {
        return {
            agGrid: { setRowData: null, getDataChange: null, setNextRow: null, setPrevRow: null, setSelect :null},
            rowSelect: null,
            columnDefs: [
                { headerName: "Mã hiển thị", field: "CODEVIEW", width: 100, editable: false },
                { headerName: "Tên", field: "NAME", width: 300, editable: false },
                { headerName: "Ghi chú", field: "NOTE", width: 400, editable: false },
                { headerName: "Không hiển thị", field: "LOCK", width: 120, editable: false, type: 'checkbox' }
            ],
            page: 1,
            searchstatus:[]
        };
    },
    componentWillMount: function () {},
    componentDidMount: function () {},
    //Thêm bắt buộc so với cái cũ - 
    /**
    *Danh sách các nút lệnh - để tương tác do cha củađối tượng này gọi (xem hàm dùng chung trong _shared/TabHeader.jsx, ButtonList.jsx )
    */
    registerButton:function(){
        return [ { title: 'Thêm mới', callback: this.onNewClick, icon: ' fa fa-files-o', ref: 'cmdAdd' }
                    , { title: 'Sửa', callback: this.onEditClick, icon: 'fa fa-edit', ref: 'cmdEdit' }
                    , { title: 'Xóa', callback: this.onDeleteClick, icon: 'fa fa-trash', ref: 'cmdDelete' }
                    , { title: 'Lấy dữ liệu', callback: this.Refresh, icon: 'fa fa-refresh', ref: 'cmdRefresh' }
                    , { title: 'Tìm kiếm', callback: this.onSearch, icon: 'fa fa-filter', ref: 'cmdSearch' }
                    //, { title: 'Tìm kiếm SQL', callback: this.onSearch, icon: 'fa fa-database', ref: 'cmdSearchSQL' }
                    , { title: 'In ấn', callback: this.onPrint, icon: 'fa fa-print', ref: 'cmdPrint' }
                ];
    },
    /**
    * Thực thao tác khi tab này được chọn - đối tượng parent (this.props.parent) truy xuất đến đối tượng cha đã gọi đối tượng này dùng để truy xuất thông tin chung trong các hệ thống (xem hàm dùng chung trong _shared/TabHeader.jsx)
    */
    onActive: function (parent){
        this.loadData();
    },
    /**
    *Khởi tạo lưới
    */
    initAgGrid: function (setRowData, getDataChange, setNextRow, setPrevRow, setSelect) {
        var agGrid = {
            setRowData: setRowData,
            getDataChange: getDataChange,
            setNextRow: setNextRow,
            setPrevRow: setPrevRow,
            setSelect: setSelect
        };
        this.setState({ agGrid: agGrid });
    },
    /**
    *Khi chọn một bản ghi đưa vào vùng chọn hiện tại
    */
    onRowSelect: function (itemSelect) {
        //console.log(itemSelect);
        if (!!itemSelect && itemSelect.length > 0)
            this.setState({ rowSelect: itemSelect });
    },
    /**
    *Lấy lại toàn bộ dữ liệu 
    */
    Refresh:function() {
        this.loadData(this.state.searchstatus, this.state.rowSelect[0]);
    },
    /**
    *Lấy lại toàn bộ dữ liệu được gọi bởi popup - với đối tượng vào để xử lý phù hợp
    */
    ReloadList:function(obj)  {
        this.loadData(this.state.searchstatus,obj);
    }
    ,
    /**
    * Cập nhật lại thông tin sau khi gọi xóa dữ liệu thành công
    */
    ReloadListDelete: function () {
        this.loadData();//(this.state.currentcode);
    },
    /**
    * Lấy dữ liệu 
    */
    loadData: function (obj, selectobject) {
        var ret;
        var that = this;
        var pageSize = $('#pageSize').val();
        if (isNaN(pageSize)) {
            pageSize = 0;
        }
        let page = this.state.page;
       // console.log('param:', obj, obj === null, typeof obj === 'undefined');
        if (obj === null || typeof obj === 'undefined') {
            obj = this.state.searchstatus;
            //console.log('Assign to:', obj);
        }
        //console.log('Search here:', obj);
        var code = '';
        var codetype = false;
        var name = '';
        var nametype = false;
        if (!!obj.CODESEARCH)
        {
            code = obj.CODESEARCH.value;
            codetype = obj.CODESEARCH.type;
        }
        if (!!obj.NAMESEARCH) {
            name = obj.NAMESEARCH.value;
            nametype = obj.NAMESEARCH.type;
        }
       
        $.ajax({
            url: "/warehouse/getList",
            dataType: 'json',
            data: {
                page: page
                ,pageSize: pageSize
                , code: code
                , codetype: codetype
                , name: name
                , nametype: nametype
            },
            success: function (data) {
                ret = data.data;
                if (!data.data) {
                    this.setState({ rowSelect : null });
                }                
                this.state.agGrid.setRowData(data.data);//JSON.parse(data.data2));
                if (selectobject !== null && typeof selectobject !== 'undefined')
                {
                    that.state.agGrid.setSelect(selectobject);
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }
        });
        return ret;
    },
    
    /**
    * Xử lý cho trường hợp chỉ thêm mới
    */
    onNewClick: function () {
        var obj={};//nếu có một số thông tin về cha và cần truyền sẽ đưa vào đây
        this.refs.warehouse_popup.ClearInput(obj);
        this.refs.warehouse_popup.Show();
    },
    /**
    * Xử lý trường hợp sửa
    */
    onEditClick: function () {
        //Chỉ sửa cho một bản ghi
        if (this.state.rowSelect.length != 1)
        {
            bootbox.alert('Chọn nhiều hơn một bản ghi');
            return;
        }
        var obj=this.state.rowSelect[0];//Ban ghi hiện tại để sửa
        this.refs.warehouse_popup.SetInput(obj);
        this.refs.warehouse_popup.Show();
        
    },
    /**
    *Xử lý trường hợp nút lệnh gọi xóa bản ghi
    */
    onDeleteClick: function () {
        var that = this;
        bootbox.confirm({
            message: "Bạn có muốn delete bản ghi này",
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn btn-success'
                },
                cancel: {
                    label: 'No',
                    className: 'btn btn-danger'        
                }
            },
            callback: function (result) {
                if (result)
                {
                    that.handDelete();
                }
                else
                {
                    log.show("Không xóa bản ghi", true);
                }                
            }
        });
    },
    /**
    *Xử lý trường hợp xóa bản ghi
    */
    handDelete: function(){
        if (!!this.state.rowSelect) {
            var data = [];
            this.state.rowSelect.forEach(function (item, index) {
                data.push(item.CODE);
            });
            var postData = { code: data };
            $.ajax({
                url: "/warehouse/Delete",
                type: "POST",
                dataType: "json",
                traditional: true,
                data: postData,
                success: function (data) {
                    if (data.ret >= 0) {
                        this.loadData();
                        log.show("Đã xoá bản ghi!",true);
                    }
                    else
                    {
                        log.show("Xoá không thành công!",false);
                    }
                }.bind(this),
                error: function (xhr, status, err) {
                    console.log(err.toString());
                }
            });
        }
        else{
            log.show("Không có bản ghi nào!",false);
        }
    },
    /**
    * Xử lý nút lệnh tìm kiếm
    */
    onSearch: function () {
        var   dataSearch = [
                           { title: 'Mã', id: 'CODESEARCH', type: 'text' }
                           ,{ title: 'Tên', id: 'NAMESEARCH', type: 'text' }
                           ,{ title: 'Ghi chú', id: 'NOTESEARCH', type: 'text' }
        ];
        obj = this.state.searchstatus;//Dữ liệu mặc định
        this.props.parent.ShowSearch('admingroup_search',dataSearch, obj, this.doSearch);
        //console.log('Gọi tìm kiếm');
    },
    /**
    * Xử lý lời gọi search - dựa tren id đã được gửi để lấy dữ liệu về
    */
    doSearch:function(obj)
    {
        //obj dữ liệu lấy về
        //console.log('search based on:', obj.CODESEARCH, obj.NAMESEARCH, obj.NOTESEARCH);
        this.setState({ searchstatus: obj });
        this.loadData(obj);
    },
    /**
    *Xử lý tìm kiếm nâng cao
    */
    onSearchSQL: function () {
        console.log("search SQL SKILL");
    },
    /**
   *Lấy lại toàn bộ dữ liệu được gọi bởi popup - với đối tượng vào để xử lý phù hợp
   */
    onPrint:function()
    {
        //bootbox.alert('In ấn ở đây');
        //this.props.parent.setButtonStatus('cmdDelete',true);
    }
    ,
    render: function () {
        return (

            <div id="list" className="tab-pane fade in active ">
                {/*Cần phải gán ref để truy xuất đến đối tượng này*/}
               <WarehousePopup ref="warehouse_popup"  ReloadData={this.ReloadList}/> 
                <div id="myGrid" className="ag-fresh" style={{width: '100%', height:'500px'}}>
                </div>
                        <AgGrid container='myGrid'
                        initAgGrid={this.initAgGrid}
                        loadData={this.loadData}
                        onRowSelect={this.onRowSelect}
                        columnDefs={this.state.columnDefs}
                        headerCheckBox={true}
                        ref='myGrid'
                        > 
                        </AgGrid>
                
            </div>
           
        );
}
});

