var DepartmentList = React.createClass( {
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
                { headerName: "Thứ tự", field: "THEORDER", width: 100, align: 'center', editable: false },
                { headerName: "Không hiển thị", field: "LOCK", width: 100, editable: false, type: 'checkbox' },
            ],
            //Danh sách trên cây
            lst: [], currentcode: '',
            //Danh sách các nút lệnh thực hiện chức năng
            buts: [ 
                      { title: 'In', callback: this.onReportClick, icon: 'fa fa-line-chart', ref: 'cmdPri' }
                    , { title: 'Lọc', callback: this.searchCall, icon: 'fa fa-filter', ref: 'cmdFil' }],
            parentcode: '',
            parentname:'Đơn vị cấp trên',
            parentnamedef: 'Đơn vị cấp trên',
            parentextcode: ''
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
        setTitle('sys_title', 'Danh mục đơn vị');
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

        if((obj!=null)&&(obj!=='undefined'))//dối tượng này có các trường theo cấu hình của cây
        {
            if (obj.length > 0) {
                code = obj[0].id;
                title = obj[0].text;
                parentextcode= obj[0].idext
            }
        }
        this.setState({ parentcode: code, parentextcode: parentextcode, parentname: title });
        //set the new code
        if(currentcode!==code)
        {
            this.setState({
                currentcode: code
            });
            //Gán lại đường dẫn của trang theo đúng mã đã được chọn - đảm bảo khi copy đường dẫn này lần sau sẽ vào đúng trang với việc gắn mặc định code được lựa chọn
            var objurl = { Page: 'currentpage', Url: '/Department/index/'+code };
            history.pushState(objurl, objurl.Page, objurl.Url);

            //setTitle('sysmenu_list_title', title);
            //Lấy lại dữ liệu trên lưới
            this.loadData(code);
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
            url: "/Department/getAllSearch",
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
   
   
    onReportClick: function () {

        var currentobj = this.state.rowSelect[0];
        var CODEVIEW = currentobj.CODEVIEW;
        var typeCodeView = false;
        var NAME = currentobj.NAME;
        var typeName =  false;
        var NOTE = currentobj.NOTE
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
                <a href="#" onClick={this.TreeSelect}>Đơn vị cấp trên</a>
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
    <DepartmentList />,
    document.getElementById('container')
);