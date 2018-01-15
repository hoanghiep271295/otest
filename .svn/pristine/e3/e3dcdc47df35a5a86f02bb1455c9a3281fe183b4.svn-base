var AdmingroupPriority = React.createClass({
    getInitialState: function () {
        return {
            agGrid: { setRowData: null, getDataChange: null, setNextRow: null, setPrevRow: null, setSelect :null},
            rowSelect: null,
            columnDefs: [
                { headerName: "Mã hiển thị", field: "_PRIORITYCODE.CODE", width: 100, editable: false },
                { headerName: "Tên", field: "_PRIORITYCODE.NAME", width: 300, editable: false },
                { headerName: "Nhóm", field: "_PRIORITYCODE.GROUPCODE", width: 100, editable: false },
                { headerName: "Phân hệ", field: "SYSCOMPONENTCODE", width: 100, editable: false },
            ],
            page: 1,
            searchstatus:[],
            loaded:null,
            popup:null,
            parentinfo:null
        };
    },
    componentWillMount: function () {
      
    },
    componentDidMount: function () {
        this.setState({popup:this.refs[this.props.id+'_popup']});
//        console.log('List-componentDidMount:', new Date());
        //this.loadData();
    },
    //Thêm bắt buộc so với cái cũ - 
    /**
    *Danh sách các nút lệnh - để tương tác do cha củađối tượng này gọi (xem hàm dùng chung trong _shared/TabHeader.jsx, ButtonList.jsx )
    */
    registerButton:function(){
        var obj = Object();
        //Đầy đủ nếu nó không thuộc các nhóm mặc định: { ref: 'cmdNew', callback: this.onPrint,title:'Hello',icon:'',tooltip:'Không rõ'}

        obj=[{ref: 'cmdAdd' , callback: this.onNewClick1 }
//             , {ref: 'cmdEdit', callback: this.onEditClick}
             , { ref: 'cmdDelete', callback: this.onDeleteClick}
             , { ref: 'cmdRefresh', callback: this.Refresh}
             //, { ref: 'cmdSearch', callback: this.onSearch}
             //, { ref: 'cmdSearchSQL', callback: this.onSearch}
             //, { ref: 'cmdPrint', callback: this.onPrint}
        ];
        return obj;
    },
    /**
    * Thực thao tác khi tab này được chọn - đối tượng parent (this.props.parent) truy xuất đến đối tượng cha đã gọi đối tượng này dùng để truy xuất thông tin chung trong các hệ thống (xem hàm dùng chung trong _shared/TabHeader.jsx)
    */
    onActive: function (parent) {
        var that=this;
        //Lấy bản ghi cha đang được chọn
        var objAdmingroup = this.props.parent.getKeyValue('admingroupCode');
        //Nếu chưa chọn
        if(isMiss(objAdmingroup))
        {
            //Thông báo và chuyển về trang cha
            bootbox.alert("Chưa chọn nhóm quản trị", function(){ that.props.parent.ChooseTab('admingroup') });
            return ;
        }
        //Kiểm tra việc lấy dữ liệu và lấy lại dữ liệu; hoặc chưa load, hoặc cha đã bị thay đổi
        if(this.state.loaded===null || this.state.parentinfo!==objAdmingroup)
        {
            this.loadData();
            this.setState({loaded:true});//Có thể là giá trị khác để kiểm tra
            this.setState({parentinfo:objAdmingroup});//Trường hợp có thay đổi thì nhận lại mã mới
            //Gán lại tiêu đề lớn - cộng với tên nhóm
        }
        this.props.parent.setParentTitle(this.props.parentTitle + '(' + objAdmingroup.NAME + ')');
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
        console.log(itemSelect);
        if (!!itemSelect && itemSelect.length > 0)
            this.setState({ rowSelect: itemSelect });
    },
    /**
    *Lấy lại toàn bộ dữ liệu 
    */
    Refresh:function()
    {
        this.loadData(this.state.searchstatus, this.state.rowSelect[0]);
    },
    /**
    *Lấy lại toàn bộ dữ liệu được gọi bởi popup - với đối tượng vào để xử lý phù hợp
    */
    ReloadList:function(obj)
    {
        this.loadData(this.state.searchstatus,obj);

    }
    ,
    /**
    * Cập nhật lại thông tin sau khi gọi xóa dữ liệu thành công
    */
    ReloadListDelete: function () {
        //cập nhật lại danh sách
        this.loadData();//(this.state.currentcode);
    },
    /**
    * Lấy dữ liệu 
    */
    loadData: function (obj, selectobject) {
        var ret;
        var that = this;
//        window.NProgress.start();
        var pageSize = $('#pageSize').val();
        if (isNaN(pageSize)) {
            pageSize = 0;
        }
        let page = this.state.page;
        if (isMiss(obj)) {
            obj = this.state.searchstatus;
        }
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
            url: "/admingroup/GetPriority",
            dataType: 'json',
            data: {
                page: page
                ,pageSize: pageSize
                , code: code
                , codetype: codetype
                , name: name
                , nametype: nametype
                ,admingroupcode:this.props.parent.getKeyValue('admingroupCode').CODE
            },
            success: function (data) {
                ret = data.data;
                //console.log(data.data);
                if (!data.data) {
                    this.setState({ rowSelect : null });
                }                
                this.state.agGrid.setRowData(data.data);//JSON.parse(data.data2));
                if (!isMiss(selectobject ))
                {
                    that.state.agGrid.setSelect(selectobject);
                }
//                this.setDisplay(page, pageSize, data);
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }
        });
        //window.NProgress.done();
        return ret;
    },
    
    /**
    * Xử lý cho trường hợp chỉ thêm mới
    */
    onNewClick1: function () {
//        console.log('Call onNewClick:')
        var obj={};//nếu có một số thông tin về cha và cần truyền sẽ đưa vào đây
//        console.log('popup of admingrouppriority', this.state.popup);
//        this.state.popup.ClearInput(obj);
        this.state.popup.Show();
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
        this.state.popup.SetInput(obj);
        this.state.popup.Show();
        
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
                       
            }
        });
    },
    /**
    *Xử lý trường hợp xóa bản ghi
    */
    handDelete: function(){
        var data =[];
        var rowSelect= this.state.rowSelect;
        rowSelect.forEach(function (item, index) {
            data.push({OBJECTCODE:item.OBJECTCODE, PRIORITYCODE:item.PRIORITYCODE, SYSCOMPONENTCODE:item.SYSCOMPONENTCODE, FUNC:item.FUNC, THETYPE:item.THETYPE, THECODE:item.THECODE, TABLENAME:item.TABLENAME, FORMAN:item.FORMAN});
        });
        var lst={list: JSON.stringify( data)};
        console.log('Add post:',lst);

        //Add or edit 1 item
        $.ajax({
            url: "/Admingroup/DeletePriority",
            type: 'POST',
            data:lst,
            dataType: 'json',
            success: function (data) {
                   if (data.ret >= 0) {
                        this.loadData();
                    }
                    else
                    {
                       bootbox.alert("Xoá không thành công!");
                    }

            }.bind(this),
            error: function (xhr, status, err) {
                console.error('unknow:url', status, err.toString());
            }.bind(this)
        });
    },
    /**
    * Xử lý nút lệnh tìm kiếm
    */
    onSearch: function () {
        //$('#ModalSearchSkill').modal('show');
        //console.log('Search skill');
        var   dataSearch = [
                           { title: 'Mã', id: 'CODESEARCH', type: 'text' }
                           ,{ title: 'Tên', id: 'NAMESEARCH', type: 'text' }
 //                          ,{ title: 'Ghi chú', id: 'NOTESEARCH', type: 'text' }
        ];
        obj = this.state.searchstatus;//Dữ liệu mặc định
        this.props.parent.ShowSearch(this.props.id+'_search',dataSearch, obj, this.doSearch);
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
        //console.log("search SQL SKILL");
    },
    /**
   *Lấy lại toàn bộ dữ liệu được gọi bởi popup - với đối tượng vào để xử lý phù hợp
   */
    onPrint:function()
    {
        //bootbox.alert('In ấn ở đây');
        //this.props.parent.setButtonStatus('cmdDelete',true);
        //this.props.parent.setButtonStatus('cmdSearch', false);
    }
    ,
    render: function () {
//        console.log('Gan cha cho pop up',this.props.parent);
        return (

            <div id={this.props.id+'_list'} className="tab-pane fade in active ">
                {/*Cần phải gán ref để truy xuất đến đối tượng này*/}
               <AdmingroupPriorityAdd ref={this.props.id+'_popup'}  ReloadData={this.ReloadList} id={this.props.id+'_popup'} parent={this.props.parent}/> 
                <div id={this.props.id+'_grid'} className="ag-fresh" style={{width: '100%', height:'400px'}}>
                </div>
                        <AgGrid container={this.props.id+'_grid'}
                        initAgGrid={this.initAgGrid}
                        loadData={this.loadData}
                        onRowSelect={this.onRowSelect}
                        columnDefs={this.state.columnDefs}
                        headerCheckBox={true}
                        ref={this.props.id+'_grid'}
                        > 
                        
                        </AgGrid>
                
</div>
           
        );
}
});

