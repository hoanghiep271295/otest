var SysmenuList = React.createClass( {
    getInitialState: function() {
        return {
            //Phục vụ cho lưới
            agGrid: { setRowData: null, getDataChange: null, setNextRow: null, setPrevRow: null },
            rowSelect: null,
            //Định nghĩa các cột trên lưới
            columnDefs: [
                { headerName: "Tên", field: "NAME", width: 450, editable: false },
                { headerName: "Không hiển thị", field: "LOCK", width: 150, editable: false, type: 'checkbox' },
                { headerName: "Thứ tự", field: "THEORDER", width: 100, align: 'center', editable: false },
                { headerName: "Biểu tượng", field: "ICON", width: 150, align: 'center', editable: false },
                { headerName: "Liên kết", field: "LINK", width: 200, align: 'center', editable: false },
                { headerName: "Phân quyền", field: "PRIORITYCODE", width: 200, align: 'center', editable: false }
            ],
//Danh sách trên cây
            lst: [], currentcode: '',
//Danh sách các nút lệnh thực hiện chức năng
            buts: [{ title: 'Thêm mới', callback: this.onNewClick, icon: ' fa fa-files-o', ref: 'cmdAdd' }, { title: 'Sửa', callback: this.onEidtClick, icon: 'fa fa-edit', ref: 'cmdEdit' }, { title: 'Xóa', callback: this.onDeleteClick, icon: 'fa fa-trash-o fa-fw', ref: 'cmdDel' }, { title: 'In', callback: this.docallback, icon: 'fa fa-line-chart', ref: 'cmdPri' }, { title: 'Lọc', callback: this.searchCall, icon: 'fa fa-filter', ref: 'cmdFil' }],
            parentcode: '',
            parentextcode:''
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
        setTitle('sys_title', 'Quản lý menu hệ thống');
            //Thiết lập đường dẫn
        var path = [{ title: 'Menus', status: 'active', link: '' }];
        setTree('sys_path', path);
//Thiết lập lựa chọn mặc định trên cây
        if(this.state.currentcode!=='')
        {
            $('#sysmenu_list_tree').jstree('select_node', this.state.currentcode);
        }
//Lấy dữ liệu trên lưới
        this.loadData();
    },
    /**
*Thực hiện lấy dữ liệu gán vào danh sách trên cây
*/
    loadTree: function () {
        //console.log('Load data for tree');hidTheType
        var thetype = this.refs.hidTheType.value;
        var postdata = { thetype: thetype };
        $.ajax({
            url: '/sysmenu/getBackend',
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
        var title = 'Hệ thống menu';

        if(obj!=null)//dối tượng này có các trường theo cấu hình của cây
        {
            if (obj.length > 0) {
                code = obj[0].id;
                title = obj[0].text;
                this.setState({ parentcode: obj[0].id, parentextcode: obj[0].idext });
            }
        }
        //set the new code
        if(currentcode!==code)
        {
            this.setState({
                currentcode: code
            });
            //Gán lại đường dẫn của trang theo đúng mã đã được chọn - đảm bảo khi copy đường dẫn này lần sau sẽ vào đúng trang với việc gắn mặc định code được lựa chọn
            var objurl = { Page: 'currentpage', Url: '/sysmenu/index/'+code };
            history.pushState(objurl, objurl.Page, objurl.Url);

            //            setTitle('sysmenu_list_title', title);
            //Lấy lại dữ liệu trên lưới
            this.loadData();
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
    loadData: function () {
        return this.loadDataSearch('', '', '', '');//default
    },
    /**
    *Thực hiện truy vấn dữ liệu
    */
    loadDataSearch:function(name, nametype, note, notetype)
    {
        var currentcode = this.state.currentcode;
        var thetype = this.refs.hidTheType.value;
        var postdata = { code: currentcode, thetype: thetype, name:name, nametype:nametype,note:note,notetype:notetype };
        var ret = 0;
        $.ajax({
            url: "/sysmenu/getBackendList",
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
//        console.log(obj);
        //cập nhật lại cây
        this.loadTree();
        //cập nhật lại danh sách
        this.loadData();
    },
    /**
    * Cập nhật lại thông tin sau khi gọi xóa dữ liệu thành công
    */
    ReloadListDelete: function () {
        //        console.log(obj);
        //cập nhật lại cây
        this.loadTree();
        //cập nhật lại danh sách
        this.loadData();
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

        var obj = { PARENTEXT: this.state.parentextcode, PARENTCODE: this.state.parentcode, THETYPE: this.refs.hidTheType.value };
        //gọi hàm từ trong đối tượng popup form để thiết lập tham số, sau đó hiển thị
        this.refs.sysmenuPopup.ClearInput(obj);
        this.refs.sysmenuPopup.Show();

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
            var obj = { NAME: currentobj.NAME, PARENTEXT: this.state.parentextcode, PARENTCODE: this.state.parentcode, CODE: currentobj.CODE, THEORDER: currentobj.THEORDER, NOTE: currentobj.NOTE, ICON: currentobj.ICON, PRIORITY: currentobj.PRIORITYCODE, THETYPE: this.refs.hidTheType.value, LINK: currentobj.LINK, LOCK:currentobj.LOCK };
            //gọi hàm từ trong đối tượng popup form để thiết lập tham số, sau đó hiển thị
            this.refs.sysmenuPopup.SetInput(obj);
            this.refs.sysmenuPopup.Show();
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
                url: "/sysmenu/delete",
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
    /**
    *Gọi hiển thị giao diện tìm kiếm
    */
    searchCall: function () {
        //can set other in this: setNewFace
        this.refs.sysmenuSearch.Show();
    },
    /**
    *Thực hiện nút lệnh tìm kiếm
    */
    searchCallback(lst)
    {
        var name = lst.searchMenu_name.value;
        var nametype = lst.searchMenu_name.type;
        var note = lst.searchMenu_note.value;
        var notetype = lst.searchMenu_note.type;
        return this.loadDataSearch(name, nametype, note, notetype);
    },
    render: function () {
        var self = this;
        var config = { id: "CODE", text: "NAME", parent: "PARENTCODE", idext: "EXTENSIONCODE" };
        var searchconfig = [{ title: 'Tên menu', id: 'searchMenu_name', type: 'text', combo: 'block' }, { title: 'Ghi chú', id: 'searchMenu_note', type: 'text', combo: 'block' }];
        return(
    <div className="box">
        <div className="row">
            <input type="hidden" value="BACKEND" ref="hidTheType" id= "hidTheType" />
            <div className="col-xs-3" style={{borderRight: '1px solid gray', minHeight:550}}>
                <a href="#" onClick={() => this.TreeSelect(null)}>Hệ thống menu</a>
                <Tree id='sysmenu_list_tree' data={this.state.lst} mapper={config} callback={this.TreeSelect} height='450px'/>
            </div>
            <div className="col-xs-9">
                <ButtonList list={this.state.buts}/>

                            <div id="listSubCon" className="tab-pane fade  in active">
                   <SysmenuPopup setData={this.setData} onPre={this.onPrevClick} onNext={this.onNextClick} ReloadData={this.ReloadList} ref="sysmenuPopup" />
                   <SearchDialog title='Tìm kiếm menu' lst={searchconfig} callback={this.searchCallback} ref='sysmenuSearch' />
               
                    <div id="myGridSQ" className="ag-fresh" style={{width: '100%', height:'400px'}}>

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
    <SysmenuList />,
    document.getElementById('container')
);