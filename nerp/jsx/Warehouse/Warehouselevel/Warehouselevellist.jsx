var WarehouselevelList = React.createClass( {
    getInitialState: function() {
        return {
            //Phục vụ cho lưới
            agGrid: { setRowData: null, getDataChange: null, setNextRow: null, setPrevRow: null },
            rowSelect: null,
            //Định nghĩa các cột trên lưới
            columnDefs: [
                { headerName: "Mã", field: "CODEVIEW", width: 100, editable: false },
                { headerName: "Tên", field: "NAME", width: 350, editable: false },
                { headerName: "Ghi chú", field: "NOTE", width: 200, align: 'center', editable: false },
                { headerName: "Không hiển thị", field: "LOCK", width: 100, editable: false, type: 'checkbox' },
            ],
            //Danh sách trên cây
            lst: [], currentcode: '',
            //Danh sách các nút lệnh thực hiện chức năng
            buts: [ { title: 'Thêm mới', callback: this.onNewClick, icon: ' fa fa-files-o', ref: 'cmdAdd' }
                    , { title: 'Sửa', callback: this.onEidtClick, icon: 'fa fa-edit', ref: 'cmdEdit' }
                    , { title: 'Xóa', callback: this.onDeleteClick, icon: 'fa fa-trash-o fa-fw', ref: 'cmdDel' }
                    , { title: 'In', callback: this.onReportClick, icon: 'fa fa-line-chart', ref: 'cmdPri' }
                    , { title: 'Lọc', callback: this.searchCall, icon: 'fa fa-filter', ref: 'cmdFil' }],
            parentcode: '',
            parentname:'',
            parentnamedef: '',
            parentextcode: ''
        };
    },
    componentWillMount:function()
    {
        var obj = getDefaultFromServer();
        this.setState({ currentcode:obj.code});
    },
    componentDidMount: function () {
	    //Thiết lập tiêu đề
        setTitle('sys_title', 'Danh mục cấp kho');
        //Thiết lập đường dẫn
        var path = [{ title: 'Danh mục cấp kho', status: 'active', link: '' }];
        setTree('sys_path', path);
        //Lấy dữ liệu trên lưới
        this.loadData(this.state.currentcode);
    },
    /**
    *Hàm thiết lập cho lưới
    */
    initAgGrid: function (setRowData, getDataChange, setNextRow, setPrevRow) {
        var agGrid = {
            setRowData: setRowData,
            getDataChange: getDataChange,
            setNextRow: setNextRow,
            setPrevRow: setPrevRow
        };
        this.setState({ agGrid: agGrid });
    },
    /**
*Danh sách các nút lệnh - để tương tác do cha củađối tượng này gọi (xem hàm dùng chung trong _shared/TabHeader.jsx, ButtonList.jsx )
*/
    registerButton:function(){
        var obj = Object();
        //Đầy đủ nếu nó không thuộc các nhóm mặc định: { ref: 'cmdNew', callback: this.onPrint,title:'Hello',icon:'',tooltip:'Không rõ'}

        obj=[{ref: 'cmdAdd' , callback: this.onNewClick }
             , {ref: 'cmdEdit', callback: this.onEditClick}
             , { ref: 'cmdDelete', callback: this.onDeleteClick}
             , { ref: 'cmdRefresh', callback: this.Refresh}
             , { ref: 'cmdSearch', callback: this.onSearch}
             , { ref: 'cmdSearchSQL', callback: this.onSearch}
             , { ref: 'cmdPrint', callback: this.onPrint}
        ];
        return obj;
    },
    /**
 * Thực thao tác khi tab này được chọn - đối tượng parent (this.props.parent) truy xuất đến đối tượng cha đã gọi đối tượng này dùng để truy xuất thông tin chung trong các hệ thống (xem hàm dùng chung trong _shared/TabHeader.jsx)
 */
    onActive: function (parent) {
        if(this.state.loaded===null)
        {
            this.loadData();
            this.setState({loaded:true});//Có thể là giá trị khác để kiểm tra
        }
    },
    /**
    *Lấy dữ liệu cho vào lưới
    */
    loadData: function (code) {
        if (code === null || code === 'undefined')
        {
            code = this.state.currentcode;//load mặc định từ trong state đã được lưu trữ
        }
        return this.loadDataSearch(code,'', '', '', '');//default
    },
    /**
    *Thực hiện truy vấn dữ liệu
    */
    loadDataSearch:function(currentcode,name, nametype, note, notetype)
    {
        //var currentcode = this.state.currentcode;
        var thetype = this.refs.hidTheType.value;
        var postdata = { code: currentcode, thetype: thetype, name:name, nametype:nametype,note:note,notetype:notetype };
        var ret = 0;
        $.ajax({
            url: "/Warehouselevel/getAllSearch",
            dataType: 'json',
            data: postdata,
            success: function (data) {
                ret = data.lst;
                this.setState({ rowSelect: null });
                if (data.ret >= 0) {
                    this.state.agGrid.setRowData(data.lst);//(JSON.parse(data.data2));
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }
        });
        return ret;
    },
    /**
    *Hàm cập nhật lại thông tin trên lưới, được gọi bởi popup form khi cập nhật lại thông tin
    *para obj: là mã của đối tượng bị thay đổi hoặc thêm mới
    */
    ReloadList:function(obj)
    {
        this.loadData(this.state.currentcode);
    },
    /**
    * Cập nhật lại thông tin sau khi gọi xóa dữ liệu thành công
    */
    ReloadListDelete: function () {
        this.loadData(this.state.currentcode);
    },
    /**
    *hàm callback để thực hiện xử lý lựa chọn trên lưới
    */
    onRowSelect: function (itemSelect) {
        this.setState({ rowSelect: itemSelect });
    },
    /**
    *Hàm thực hiện khi chọn nút thêm mới (được quy định trong danh sách nút)
    */
    onNewClick: function () {

        var obj = { PARENTEXT: this.state.parentextcode, PARENTCODE: this.state.currentcode, THETYPE: this.refs.hidTheType.value, PARENTNAME: this.state.parentname };
        //gọi hàm từ trong đối tượng popup form để thiết lập tham số, sau đó hiển thị
        this.refs.WarehouselevelPopup.ClearInput(obj);
        this.refs.WarehouselevelPopup.Show();

    },
    /**
    *Hàm thực hiện khi sửa bản ghi
    */
    onEidtClick: function () {
        if (this.state.rowSelect.length != 1)
        {
            bootbox.alert('Chưa chọn bản ghi hoặc nhiều hơn một bản ghi');
        }
        else
        {
            var currentobj = this.state.rowSelect[0];
            var obj = { NAME: currentobj.NAME
                        , CODE: currentobj.CODE
                        , NOTE: currentobj.NOTE
                        , CODEVIEW: currentobj.CODEVIEW
                        , LOCK: currentobj.LOCK
            };
            //gọi hàm từ trong đối tượng popup form để thiết lập tham số, sau đó hiển thị
            this.refs.WarehouselevelPopup.SetInput(obj);
            this.refs.WarehouselevelPopup.Show();
            console.log(obj);
        }
    },
    /**
    *Thực hiện thao tác xóa
    */
    handDelete: function () {
        if (!!this.state.rowSelect) {
            var data = [];
            this.state.rowSelect.forEach(function (item) {
                data.push(item.CODE);
            });
            var postData = { code: data };
            $.ajax({
                url: "/Warehouselevel/delete",
                type: "POST",
                dataType: "json",
                traditional: true,
                data: postData,
                success: function (data) {
                    if (data.ret >= 0) {
                        this.ReloadListDelete();
                    }
                    else {
                        if (data.ret == -2) {
                            bootbox.alert("Bản ghi có tham chiếu, cần xóa các menu con trước!", false);
                        }
                        else {
                            bootbox.alert("Lỗi khi xóa dữ liệu!", false);
                        }
                    }
                }.bind(this),
                error: function (xhr, status, err) {
                    console.log(err.toString());
                }
            });
        }
        else {
            bootbox.alert("Không có bản ghi nào!", false);
        }
    },
    /**
    *gọi khi click vào nút xóa
    */
    onDeleteClick: function () {
        var that = this;
        if (!this.state.rowSelect)
        {
            bootbox.alert("Chưa chọn bản ghi");
            return false;
        }
        if (this.state.rowSelect.length==0) {
            bootbox.alert("Chưa chọn bản ghi");
            return false;
        }
        //  confirm.show(null,this.handDelete,null);
        bootbox.confirm({
            message: "Xóa các bản ghi được lựa chọn ?",
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn btn-danger'
                },
                cancel: {
                    label: 'No',
                    className: 'btn btn-default'
                }
            },
            callback: function (result) {
                if (result) {
                    that.handDelete();
                }
                else {
                    console.log("No items have been deleted", true);
                }
            }
        });
    },

    onReportClick: function () {

        var currentobj = this.state.rowSelect[0];
        var CODEVIEW = currentobj.CODEVIEW;
        var typeCodeView = false;
        var NAME = currentobj.NAME;
        var typeName =  false;
        var NOTE = currentobj.NOTE
        var typeNote =  false;
        
        var parameter="code="+this.state.currentcode+"&reporttype=WAREHOUSELEVEL";
        open("/report/reporting.aspx?"+parameter);
    },
    /**
    *Gọi hiển thị giao diện tìm kiếm
    */
    searchCall: function () {
        //can set other in this: setNewFace
        this.refs.WarehouselevelSearch.Show();
    },  
    /**
    *Thực hiện nút lệnh tìm kiếm
    */
    searchCallback(lst)
    {
        var name = lst.search_name.value;
        var nametype = lst.search_name.type;
        var note = lst.search_note.value;
        var notetype = lst.search_note.type;
        return this.loadDataSearch(this.state.currentcode,name, nametype, note, notetype);
    },
    render: function () {
        var self = this;
        var config = { id: "CODE", text: "NAME", parent: "PARENTCODE", idext: "EXTENSIONCODE" };
        var searchconfig = [{ title: 'Tên', id: 'search_name', type: 'text', combo: 'block' }, { title: 'Ghi chú', id: 'search_note', type: 'text', combo: 'block' }];
        return(
    <div className="box">
        <div className="row">
            <input type="hidden" value="BACKEND" ref="hidTheType" id= "hidTheType" />
               
            <div className="col-xs-12">
            <div className="row">
                <div className="col-xs-12">

                <span id="sysmenu_list_title" className="subtitle" style={{float:'left'}}>{this.state.parentname}</span>
                <ButtonList list={this.state.buts} />
                </div>
            </div>
                            <div id="listSubCon" className="tab-pane fade  in active">
                    <SearchDialog title='Tìm kiếm' lst={searchconfig} callback={this.searchCallback} ref='WarehouselevelSearch' />
                    <WarehouselevelPopup setData={this.setData} onPre={this.onPrevClick} onNext={this.onNextClick} ReloadData={this.ReloadList} ref="WarehouselevelPopup" />
                 
                    <div id="myGridSQ" className="ag-fresh" style={{width: '100%', height:'500px'}}>

                    </div>
                    <AgGrid container='myGridSQ'
                            initAgGrid={this.initAgGrid}
                            loadData={this.loadData}
                            onRowSelect={this.onRowSelect}
                            columnDefs={this.state.columnDefs}
                            headerCheckBox={true}>
                    </AgGrid>

                            </div>
            </div>
                            </div>

            </div>

        );
		}
    
} );

//----------------
ReactDOM.render(
    <WarehouselevelList />,
    document.getElementById('container')
);