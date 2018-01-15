﻿var QuestionAppList = React.createClass({
    getInitialState: function () {
        return {
            //Phục vụ cho lưới
            agGrid: { setRowData: null, getDataChange: null, setNextRow: null, setPrevRow: null },
            rowSelect: null,
            //Định nghĩa các cột trên lưới
            columnDefs: [
                { headerName: "Mã", field: "CODEVIEW", width: 100, editable: false },
                { headerName: "Tên", field: "NAME", width: 300, editable: false },
                { headerName: "Thứ tự", field: "THEORDER", width: 100, align: 'center', editable: false },
                { headerName: "Không hiển thị", field: "LOCK", width: 100, editable: false, type: 'checkbox' }
            ],
            //Danh sách trên cây
            //lst: [],
            currentcode: '',
            subjectcode:'',
            keyvalue: [],
            //Danh sách các nút lệnh thực hiện chức năng
            //buts: [
            //    { title: 'Thêm mới', callback: this.onNewClick, icon: ' fa fa-files-o', ref: 'cmdAdd' },
            //    { title: 'Sửa', callback: this.onEditClick, icon: 'fa fa-edit', ref: 'cmdEdit' },
            //    { title: 'Xóa', callback: this.onDeleteClick, icon: 'fa fa-trash-o fa-fw', ref: 'cmdDel' },
            //    { title: 'In', callback: this.onReportClick, icon: 'fa fa-line-chart', ref: 'cmdPri' },
            //    { title: 'Lọc', callback: this.searchCall, icon: 'fa fa-filter', ref: 'cmdFil' }
            //],
            parentcode: '',
            parentname: '',
            parentnamedef: '',
            parentextcode: '',
            cbo: [],
            page: 1
        };
    },
    componentWillMount: function () {
        var obj = getDefaultFromServer();
        this.setState({subjectcode:obj.code, currentcode: obj.contentcode });
    },


    componentDidMount: function () {
        //Lấy danh sách các môn học
        this.loadCombobox();

        //Lấy dữ liệu cây
        this.loadTree();
        //Thiết lập tiêu đề
        setTitle('sys_title', 'Danh mục bài học');
        //Thiết lập đường dẫn
        var path = [{ title: 'Danh mục bài học', status: 'active', link: '' }];
        setTree('sys_path', path);
        //Thiết lập lựa chọn mặc định trên cây
        if (this.state.currentcode !== '') {
            $('#subjectcontent_list_tree').jstree('select_node', this.state.currentcode);
        }
        
        ////Lấy dữ liệu trên lưới
        //setTimeout(function () {
        //    var obj = { value: this.refs["SUBJECTCODE"].getValueString() };
        //    this.loadTree(obj, this.state.currentcode);
        //}.bind(this), 100);
    },
    // lấy dữ liệu lên combobox
    loadCombobox: function () {
        $.ajax({
            url: '/Subject/GetAll',
            dataType: 'json',
            success: function (data) {

                this.setState({
                    cbo: data.lst
                });
                if (!!data.lst) {

                    var defaultcbovalue = '';
                    if (data.lst.length > 0) {
                        defaultcbovalue = data.lst[0].CODE;//Mặc định là phần tử đầu tiên
                    }
                    if (checkMiss(this.state.subjectcode, '') !== '') {
                        defaultcbovalue = this.state.subjectcode;
                    }
                        
                    this.refs["SUBJECTCODE"].setValueString(defaultcbovalue);
                    var obj = { value: this.refs["SUBJECTCODE"].getValueString() };
                    this.loadTree(obj, this.state.currentcode);//Load trê theo cái mới
                    this.refs.childTab.setKeyValue('subjectcode', defaultcbovalue);//Chung cho toàn bộ hệ thống
                    this.refs.childTab.setKeyValue('subjectcontentcode', this.state.currentcode);//Chung cho toàn bộ hệ thống
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.error('unknow:url', status, err.toString());
            }.bind(this)
        });
    },
    comboboxChange:function(item) {
//        console.log('Combo:', item);
        if (!isMiss(item)) {
            this.refs.childTab.setKeyValue('subjectcode', item.value);
            this.refs.childTab.setKeyValue('subjectcontentcode', '');
            this.loadTree(item,'');
        }
    },
    /**
*Thực hiện lấy dữ liệu gán vào danh sách trên cây
     * para obj: subjectcode
*/
    loadTree: function (obj, currentcode) {
        //console.log('Load data for tree');hidTheType
        var subjectCode = '';
        if (!!obj)
            subjectCode = obj.value;
        $.ajax({
            url: '/SubjectContent/getAll',
            dataType: 'json',
            data: { subjectcode: subjectCode },
            success: function (data) {
                if (data.ret >= 0) {
                    this.setState({
                        lst: data.lst
                    });
                }
                
                this.loadData(subjectCode, currentcode);
//                this.refs.childTab.setKeyValue('subjectcode', this.refs["SUBJECTCODE"].getValueString());//Chung cho toàn bộ hệ thống
                //this.setKeyValue('comboSubject', this.refs["SUBJECTCODE"].getValueString());
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
        var subjectcode = this.refs.childTab.getKeyValue('subjectcode'); //
        var currentcode = this.state.currentcode;
        var code = '';
        var title = this.state.parentnamedef;
        var parentextcode = '';
        
        if ((obj != null) && (obj !== 'undefined'))//dối tượng này có các trường theo cấu hình của cây
        {
            if (obj.length > 0) {
                code = obj[0].id;
                title = obj[0].text;
                parentextcode = obj[0].idext;
            }
        }
        this.setState({ parentcode: code, parentextcode: parentextcode, parentname: title });
        //set the new code
      //  console.log('load for:', subjectcode, currentcode, code);
        if (currentcode !== code) {
            this.setState({
                currentcode: code
            });
            //Gán lại đường dẫn của trang theo đúng mã đã được chọn - đảm bảo khi copy đường dẫn này lần sau sẽ vào đúng trang với việc gắn mặc định code được lựa chọn
            var objurl = { Page: 'currentpage', Url: '/question/index/' + this.refs.childTab.getKeyValue('subjectcode')  +'/'+code };
            history.pushState(objurl, objurl.Page, objurl.Url);

            //setTitle('sysmenu_list_title', title);
            //Lấy lại dữ liệu trên lưới
            this.loadData(subjectcode, code);
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
    loadData: function (subjectcode, code) {
        if (isMiss(code)) {
            code = this.state.currentcode;//load mặc định từ trong state đã được lưu trữ
        }
       // console.log('Call load for:', subjectcode, code);
        return this.loadDataSearch(subjectcode, code, '', false, '', false, '', false);//default
    },
    /**
    *Thực hiện truy vấn dữ liệu
    */
    loadDataSearch: function (subjectcode, currentcode, code, codetype, name, nametype, note, notetype) {
        var pageSize = 0;
        this.refs.childTab.setKeyValue('subjectcode', subjectcode);
        this.refs.childTab.setKeyValue('subjectcontentcode', currentcode);
        this.refs.childTab.FirstTab();//load lai tab
        //var pageSize = $('#pageSize').val();
        //if (isNaN(pageSize)) {
        //    pageSize = 0;
        //}
        //var ret = 0;
        //var postdata = {
        //    subjectcode: subjectcode,
        //    subjectcontentcode: currentcode,
        //    page: this.state.page,
        //    pageSize: pageSize,
        //};
        //$.ajax({
        //    url: "/question/GetListQgroup",
        //    dataType: 'json',
        //    data: postdata,
        //    success: function (data) {
        //        ret = data.lst;
        //        this.setState({ rowSelect: null });
        //        if (data.ret >= 0) {
        //            this.refs.childTab.FirstTab();//load lai tab
        //            //this.state.agGrid.setRowData(data.lst);//(JSON.parse(data.data2));
        //        }
        //    }.bind(this),
        //    error: function (xhr, status, err) {
        //        console.log(err.toString());
        //    }
        //});
        //return ret;
    },
    /**
    *Hàm cập nhật lại thông tin trên lưới, được gọi bởi popup form khi cập nhật lại thông tin
    *para obj: là mã môn học 
    */
    ReloadList: function (subjectcode, obj) {
        //console.log('Trytoload');
        //        console.log(obj);
        //cập nhật lại cây
        var temp = { value: subjectcode };
        this.loadTree(temp, this.state.currentcode);
        //cập nhật lại danh sách
     //   this.loadData(subjectcode, this.state.currentcode);
    },
    /**
    * Cập nhật lại thông tin sau khi gọi xóa dữ liệu thành công
    */
    ReloadListDelete: function () {
        var subjectcode = this.refs["SUBJECTCODE"].getValueString();
        //cập nhật lại cây
        //  this.loadTree();
        var temp = { value: subjectcode };
        this.loadTree(temp, this.state.currentcode);
        //cập nhật lại danh sách
//this.loadData(this.state.currentcode);
    },
    // lấy nội dung bản ghi theo mã
    GetByCode: function(code) {
        var ret;
        $.ajax({
            url: "/SubjectContent/GetByCode",
            dataType: 'json',
            data: {code: code},
            success: function (data) {
                ret = data.lst;
                if (data.ret >= 0) {
                    var currentobj = data.data;
                    var obj = {
                        NAME: currentobj.NAME
                                , PARENTEXT: this.state.parentextcode
                                , PARENTCODE: this.state.currentcode
                                , CODE: currentobj.CODE
                                , THEORDER: currentobj.THEORDER
                                , NOTE: currentobj.NOTE
                                , CODEVIEW: currentobj.CODEVIEW
                                , LOCK: currentobj.LOCK
                                , PARENTNAME: this.state.parentname
                                , CONTENTTYPE: currentobj.CONTENTTYPE
                                , EXAMTIMECODE: currentobj.EXAMTIMECODE
                    };
                    //gọi hàm từ trong đối tượng popup form để thiết lập tham số, sau đó hiển thị
                    this.refs.SubjectcontentPopup.SetInput(obj);
                    this.refs.SubjectcontentPopup.Show();
                   // console.log(obj);
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }
        });
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
        this.refs.SubjectcontentPopup.ClearInput(obj);
        this.refs.SubjectcontentPopup.Show();

    },
    /**
    *Hàm thực hiện khi sửa bản ghi
    */
    onEditClick: function () {
        if (this.state.rowSelect === null)
            bootbox.alert('Chưa chọn bản ghi hoặc nhiều hơn một bản ghi');
        else if (this.state.rowSelect.length !== 1)
            bootbox.alert('Chưa chọn bản ghi hoặc nhiều hơn một bản ghi');
        else {
            var currentcode = this.state.rowSelect[0].CODE;
            this.GetByCode(currentcode);
            //var obj = {
            //    NAME: currentobj.NAME
            //            , PARENTEXT: this.state.parentextcode
            //            , PARENTCODE: this.state.currentcode
            //            , CODE: currentobj.CODE
            //            , THEORDER: currentobj.THEORDER
            //            , NOTE: currentobj.NOTE
            //            , CODEVIEW: currentobj.CODEVIEW
            //            , LOCK: currentobj.LOCK
            //            , PARENTNAME: this.state.parentname
            //            , CONTENTTYPE: currentobj.CONTENTTYPE
            //            , EXAMTIMECODE: currentobj.EXAMTIMECODE
            //};
            ////gọi hàm từ trong đối tượng popup form để thiết lập tham số, sau đó hiển thị
            //this.refs.SubjectcontentPopup.SetInput(obj);
            //this.refs.SubjectcontentPopup.Show();
            //console.log(obj);
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
                url: "/SubjectContent/delete",
                type: "POST",
                dataType: "json",
                traditional: true,
                data: postData,
                success: function (data) {
                    if (data.ret >= 0) {
                        this.ReloadListDelete();
                    }
                    else {
                        if (data.ret === -2) {
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
        if (!this.state.rowSelect) {
            bootbox.alert("Chưa chọn bản ghi");
            return false;
        }
        if (this.state.rowSelect.length == 0) {
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
            callback: function () {
                    that.handDelete();
            }
        });
    },
    onReportClick: function () {
        //var currentobj = this.state.rowSelect[0];
        //var codeview = currentobj.CODEVIEW;
        //var typeCodeView = false;
        //var name = currentobj.NAME;
        //var typeName = false;
        //var note = currentobj.NOTE;
        //var typeNote = false;

        var parameter = "code=" + this.state.currentcode + "&reporttype=SUBJECTCONTENT";
        open("/report/reporting.aspx?" + parameter);
    },
    /**
    *Gọi hiển thị giao diện tìm kiếm
    */
    searchCall: function () {
        //can set other in this: setNewFace
        this.refs.subjectcontentSearch.Show();
    },
    /**
    *Thực hiện nút lệnh tìm kiếm
    */
    searchCallback(lst) {
        var subjectcode = this.refs["SUBJECTCODE"].getValueString();
        var code = lst.searchSubjectcontent_code.value;
        var codetype = lst.searchSubjectcontent_code.type;
        var name = lst.searchSubjectcontent_name.value;
        var nametype = lst.searchSubjectcontent_name.type;
        var note = lst.searchSubjectcontent_note.value;
        var notetype = lst.searchSubjectcontent_note.type;
        return this.loadDataSearch(subjectcode, this.state.currentcode, code, codetype, name, nametype, note, notetype);
    },
    ComboOnSelect: function (element) {
        console.log('On ComboOnSelect', element);
    },
    ComboOnCheck: function (elements, status) {
        console.log("on ComboOnCheck", elements, status);
    },
    ComboOnExpand: function (element, status) {
        console.log('ComboOnExpand', element, status);
    },
    render: function () {
        var config = { id: "CODE", text: "NAME", parent: "PARENTCODE", idext: "EXTENSIONCODE" };
        return (
    <div className="box">
        <div className="row">
            <input type="hidden" value="BACKEND" ref="hidTheType" id="hidTheType" />
            <div className="col-xs-3" style={{borderRight: '1px solid gray', minHeight:550}}>
                <Combobox lst={this.state.cbo} valuefield='CODE' textfield='{NAME}' id='SUBJECTCODE' callback={this.comboboxChange} tooltip="Click hoặc space chọn" multiple={false} ref='SUBJECTCODE' />
                <Tree id='subjectcontent_list_tree' data={this.state.lst} mapper={config} callback={this.TreeSelect} height='515px' />
            </div>
            <div className="col-xs-9">
            <div className="row">
                <div className="col-xs-12">

                    <QuestionChildApp ref = 'childTab' id ='childTab'/>
                                </div>
            </div>
     
            </div>
        </div>

    </div>

        );
    }

});

//----------------
ReactDOM.render(
    <QuestionAppList />,
    document.getElementById('container')
);