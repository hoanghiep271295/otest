var CountLevelTitleList = React.createClass( {
    getInitialState: function() {
        return {
            //Phục vụ cho lưới
            agGrid: { setRowData: null, getDataChange: null, setNextRow: null, setPrevRow: null },
            rowSelect: null,
            //Định nghĩa các cột trên lưới
            columnDefs: [
                { headerName: "Mã", field: "codeview", width: 100, editable: false },
                { headerName: "Tên", field: "name", width: 250, editable: false }
            ],
            //Danh sách trên cây
            lst: [], currentcode: '',
            //Danh sách các nút lệnh thực hiện chức năng
            buts: [ { title: 'In', callback: this.onReportClick, icon: 'fa fa-line-chart', ref: 'cmdPri' }
                    , { title: 'Lọc', callback: this.searchCall, icon: 'fa fa-filter', ref: 'cmdFil' }],
            
            parentcode: '',
            parentname:'Danh mục đơn vị',
            parentnamedef: 'Danh mục đơn vị',
            parentextcode: '',
            extensioncode: ''
        };
    },
    componentWillMount:function()
    {
        var obj = getDefaultFromServer();
        this.setState({ currentcode:obj.code});
    },


    componentDidMount: function () {
        //Lấy dữ liệu cây
	    this.loadTree();
	    //Thiết lập tiêu đề
        setTitle('sys_title', 'Quản lý Danh mục đơn vị');
            //Thiết lập đường dẫn
        var path = [{ title: 'Danh mục đơn vị', status: 'active', link: '' }];
        setTree('sys_path', path);
        //Thiết lập lựa chọn mặc định trên cây
        if(this.state.currentcode!=='')
        {
            $('#department_list_tree').jstree('select_node', this.state.currentcode);
        }
        //Lấy dữ liệu trên lưới
        this.loadData(this.state.currentcode);
    },
    /**
*Thực hiện lấy dữ liệu gán vào danh sách trên cây
*/
    loadTree: function () {
        //console.log('Load data for tree');hidTheType
        var thetype = this.refs.hidTheType.value;
        var postdata = { thetype: thetype };
        $.ajax({
            url: '/Department/getAll',
            dataType: 'json',
            data: postdata,
            success: function (data) {
                this.setState({
                    lst: data.lst
                });
            }.bind(this),
            error: function (xhr, status, err) {
                console.error('unknow:url', status, err.toString());
            }.bind(this)
        });
    },
    /**
    * Lựa chọn một nút trên cây, lựu lại thông tin lựa chọn để thực hiện bước sau
    */
    TreeSelect: function (obj) {
        var currentcode = this.state.currentcode;
        var code = '';
        var title = this.state.parentnamedef;
        var parentextcode = '';
        var extensioncode = '';
        if((obj!=null)&&(obj!=='undefined'))//dối tượng này có các trường theo cấu hình của cây
        {
            if (obj.length > 0) {
                code = obj[0].id;
                title = obj[0].text;
                parentextcode = obj[0].departmentextensioncode;
                extensioncode = obj[0].idext;
            }
        }
        this.setState({ parentcode: code, parentextcode: parentextcode, parentname: title, extensioncode: extensioncode });
        //set the new code
        if(currentcode!==code)
        {
            this.setState({
                currentcode: code
            });
            //Gán lại đường dẫn của trang theo đúng mã đã được chọn - đảm bảo khi copy đường dẫn này lần sau sẽ vào đúng trang với việc gắn mặc định code được lựa chọn
            var objurl = { Page: 'currentpage', Url: '/CountLevelTitle/index/'+code };
            history.pushState(objurl, objurl.Page, objurl.Url);

            //setTitle('sysmenu_list_title', title);
            //Lấy lại dữ liệu trên lưới
            this.loadData(code, extensioncode);
        }
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
    *Lấy dữ liệu cho vào lưới
    */
    loadData: function (code) {
        if (code === null || code === 'undefined')
        {
            code = this.state.currentcode;//load mặc định từ trong state đã được lưu trữ
        }
        return this.loadDataSearch(code, this.state.extensioncode);//default
    },
    /**
    *Thực hiện truy vấn dữ liệu
    */
    loadDataSearch:function(currentcode, extensioncode)
    {
        var postdata = { departmentcode: currentcode, departmentextensioncode: extensioncode };
        var ret = 0;
        $.ajax({
            url: "/CountLevelTitle/CountLevelTitle",
            dataType: 'json',
            data: postdata,
            success: function (data) {
                this.setState({ rowSelect: null });
                var listData = JSON.parse(data.data);
                var colName = [];
                colName = data.colName;
                var listCol = [
                {
                    headerName: "Mã",
                    field: "codeview",
                    width: 100,
                    editable: false
                },
                {
                    headerName: "Tên",
                    field: "name",
                    width: 350,
                    editable: false
                }
            ];
                for (var i = 3; i < colName.length; i++) {
                    listCol.push({
                        headerName: colName[i],
                        field: colName[i],
                        width: 150,
                        editable: false
                   });
                }
                this.setState({ columnDefs: listCol });
                var a = JSON.parse(data.data);
                this.state.agGrid.setRowData(JSON.parse(data.data));
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
        //console.log('Trytoload');
//        console.log(obj);
        //cập nhật lại cây
        this.loadTree();
        //cập nhật lại danh sách
        this.loadData(this.state.currentcode);
    },
    /**
    * Cập nhật lại thông tin sau khi gọi xóa dữ liệu thành công
    */
    ReloadListDelete: function () {
        //        console.log(obj);
        //cập nhật lại cây
        this.loadTree();
        //cập nhật lại danh sách
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
        this.refs.DepartmentPopup.ClearInput(obj);
        this.refs.DepartmentPopup.Show();

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
                        , PARENTEXT: this.state.parentextcode
                        , PARENTCODE: this.state.currentcode
                        , CODE: currentobj.CODE
                        , THEORDER: currentobj.THEORDER
                        , NOTE: currentobj.NOTE
                        , CODEVIEW: currentobj.CODEVIEW
                        , THETYPE: this.refs.hidTheType.value
                        , LOCK: currentobj.LOCK
                        , PARENTNAME: this.state.parentname
            };
            //gọi hàm từ trong đối tượng popup form để thiết lập tham số, sau đó hiển thị
            this.refs.DepartmentPopup.SetInput(obj);
            this.refs.DepartmentPopup.Show();
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
                url: "/Department/delete",
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

        //// confirm.show(null,this.handDelete,null);
    },

    onReportClick: function () {

        var currentobj = this.state.rowSelect[0];
        var CODEVIEW = currentobj.CODEVIEW;
        var typeCodeView = false;
        var NAME = currentobj.NAME;
        var typeName =  false;
        var NOTE = currentobj.NOTE;
        var typeNote =  false;
        
        var parameter="code="+this.state.currentcode+"&reporttype=DEPARTMENT";
        open("/report/reporting.aspx?"+parameter);
    },
    /**
    *Gọi hiển thị giao diện tìm kiếm
    */
    searchCall: function () {
        //can set other in this: setNewFace
        this.refs.departmentSearch.Show();
    },  
    /**
    *Thực hiện nút lệnh tìm kiếm
    */
    searchCallback(lst)
    {
        var name = lst.searchDepartment_name.value;
        var nametype = lst.searchDepartment_name.type;
        var note = lst.searchDepartment_note.value;
        var notetype = lst.searchDepartment_note.type;
        return this.loadDataSearch(this.state.currentcode,name, nametype, note, notetype);
    },
    render: function () {
        var self = this;
        var config = { id: "CODE", text: "NAME", parent: "PARENTCODE", idext: "EXTENSIONCODE" };
        var searchconfig = [{ title: 'Tên ĐV', id: 'searchDepartment_name', type: 'text', combo: 'block' }, { title: 'Ghi chú', id: 'searchDepartment_note', type: 'text', combo: 'block' }];
        return(
    <div className="box">
        <div className="row">
            <input type="hidden" value="BACKEND" ref="hidTheType" id= "hidTheType" />
            <div className="col-xs-3" style={{borderRight: '1px solid gray', minHeight:550}}>
                <a href="#" onClick={this.TreeSelect}>Danh mục đơn vị</a>
                <Tree id='department_list_tree' data={this.state.lst} mapper={config} callback={this.TreeSelect} height='515px'/>
            </div>
            <div className="col-xs-9">
            <div className="row">
                <div className="col-xs-12">

                <span id="sysmenu_list_title" className="subtitle" style={{float:'left'}}>{this.state.parentname}</span>
                <ButtonList list={this.state.buts} />
                </div>
            </div>
                            <div id="listSubCon" className="tab-pane fade  in active">
                   <CountLevelTitlePopup setData={this.setData} onPre={this.onPrevClick} onNext={this.onNextClick} ReloadData={this.ReloadList} ref="DepartmentPopup" />
                   <SearchDialog title='Tìm kiếm đơn vị' lst={searchconfig} callback={this.searchCallback} ref='departmentSearch' />

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
    <CountLevelTitleList />,
    document.getElementById('container')
);