﻿var TestStructDetailList = React.createClass({
    getInitialState: function () {
        return {
            //Phục vụ cho lưới
            agGrid: { setRowData: null, getDataChange: null, setNextRow: null, setPrevRow: null },
            agGridContent: { setRowData: null, getDataChange: null, setNextRow: null, setPrevRow: null },
            rowSelect: null,
            //Định nghĩa các cột trên lưới cho các câu hỏi
            columnDefsDetail: [
                { headerName: "Nội dung bài học", field: "_SUBJECTCONTENTCODE.NAME", width: 300, editable: false },
                { headerName: "Kiểu câu hỏi", field: "_QUESTIONTYPECODE.NAME", width: 150, editable: false },
                { headerName: "Số câu hỏi", field: "AMOUNT", width: 100, align: 'center', editable: false },
                { headerName: "Tổng điểm", field: "TOTALMARK", width: 100, align: 'center', editable: false }
            ],
            //Định nghĩa các cột trên lưới cho các content
            columnDefsContent: [
               { headerName: "Mã", field: "CODEVIEW", width: 150, editable: false },
               { headerName: "Tên", field: "NAME", width: 200, editable: false },
                { headerName: "Thứ tự", field: "THEORDER", width: 100, editable: false },
                { headerName: "Thời gian làm bài", field: "TOTALTIME", width: 200, editable: false},
               { headerName: "Hiển thị", field: "LOCK", width: 100, align: 'center', editable: false, type: 'invcheckbox' }
               
            ],
            //Danh sách trên cây
            lstTestStruct: [],
            currentcode: '', // code trên tree
            keyvalue: [],
            parentcode: '',
            parentname: '',
            parentnamedef: '',
            parentextcode: '',
            cbo: [],
            page: 1,
            currentteststructcode: '',
            currentnode: null, // dùng trong khi load lại trang
            ScrollTop: 0
        };
    },
    componentWillMount: function () {
    },


    componentDidMount: function () {
    },
    registerButton: function () {
        var obj = Object();
        //Đầy đủ nếu nó không thuộc các nhóm mặc định: { ref: 'cmdNew', callback: this.onPrint,title:'Hello',icon:'',tooltip:'Không rõ'}
        obj = [{ ref: 'cmdAdd', callback: this.onNewClick },
            { ref: 'cmdAdd1', callback: this.onNewClickContent, title: "Thêm nội dung" },
//             , { ref: 'cmdSearchSQL', callback: this.onSearchSQL }
             , { ref: 'cmdPrint', callback: this.onPrint }
             , { ref: 'cmdSearch', callback: this.onSearch }
             , { ref: 'cmdEdit', callback: this.onEditClick }
             , { ref: 'cmdDelete', callback: this.onDeleteClick }
             , { ref: 'cmdRefresh', callback: this.Refresh }
        ];
        return obj;
    },
    // lấy dữ liệu lên combobox
    setKeyValue: function (key, value) {
        keyvalue = this.state.keyvalue;
        keyvalue[key] = value;
        this.state.keyvalue = keyvalue;
    },
    /**
    * Lấy một giá trị theo key, nếu chưa có thì trả về null - dành cho các trường hợp cần truyền tham số từ các tab
    */
    getKeyValue: function (key) {
        keyvalue = this.state.keyvalue;
        if (!isMiss(keyvalue[key])) return keyvalue[key];
        else return null;
    },
    /**
*Thực hiện lấy dữ liệu gán vào danh sách trên cây
     * para obj: subjectcode
*/
    loadTree: function (subjectcode) {
        //console.log('Load data for tree');hidTheType
        if (!!subjectcode)
        subjectcode = this.props.parent.getKeyValue("subjectcode");
        $.ajax({
            url: '/TestStruct/GetAll',
            dataType: 'json',
            data: {
                subjectCode: subjectcode
            },
            success: function (data) {

                if (data.ret >= 0) {
                    var closed = [];
                    var jsonNodes = [];
                    // duyệt từng node, node nào đóng thì sau khi load lại cây vẫn đóng các node đó
                    if (!!$('#teststructcontent_list_tree').jstree(true)) {
                         jsonNodes = $('#teststructcontent_list_tree').jstree(true).get_json('#', { flat: true });
                    
                        jsonNodes.forEach(function (item) {
                            if (item.state.opened === false) {
                                closed.push(item);
                            }
                        });
                    }
                    this.setState({
                        lstTestStruct: data.data
                    });
                    var that = this;
                    // sau khi tree reload xong, đóng lại các node cũ mà trước khi tree reload.
                    $("#teststructcontent_list_tree")
                        .on('loaded.jstree',
                            function () {
                                closed.forEach(function (item) {
                                    $("#teststructcontent_list_tree").jstree("close_node", item.id);

                                });
                                // vị trí scroll div tree trước khi load
                                var scrollTop = that.state.ScrollTop;
                                // sau khi load xong thì đưa scroll trở lại đúng vị trí ban đầu
                                $("div#teststructcontent_list_tree").scrollTop(scrollTop);
                                // set node duoc chon tren cay
                                if (!!that.state.currentnode) {
                                    $("#teststructcontent_list_tree").jstree("open_node", that.state.currentnode[0].id);
                                    $('#teststructcontent_list_tree')
                                        .jstree(true)
                                        .select_node(that.state.currentnode[0]);
                                }
                                    
                                else {
                                    // nếu chưa từng chọn node nào. thì mặc định chọn node đầu tiên
                                    var firstnode = $('#teststructcontent_list_tree').jstree(true).get_json('#', { flat: true })[0];
                                    $('#teststructcontent_list_tree')
                                        .jstree(true)
                                        .select_node(firstnode);
                                }

                            });
                    if (data.data.length > 0) {
                        var code = data.data[0].CODE;
                        this.setState({ currentcode: code });
                    } else
                    {
                        this.state.agGridContent.setRowData([]);
                        this.state.agGrid.setRowData([]);
                    }
                }

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
        this.setState({ 'ScrollTop': $("div#teststructcontent_list_tree").scrollTop() });
        this.setState({ currentnode: obj });
        
        var currentcode = this.state.currentcode;
        var code = '';
        var title = this.state.parentnamedef;
        var parentextcode = '';
        var parentcode = '';
        var teststructcode = '';
        if ((obj != null) && (obj !== 'undefined'))//dối tượng này có các trường theo cấu hình của cây
        {
            if (obj.length > 0) {
                code = obj[0].id;
                title = obj[0].text;
                parentextcode = obj[0].idext;
                if (obj[0].parent !== "#")
                    parentcode = obj[0].parent;
                if (!!obj[0].teststructcode)
                    teststructcode = obj[0].teststructcode;
            }
        }
        this.setState({ parentcode: code, parentextcode: parentextcode, parentname: title, currentteststructcode: teststructcode });
        //set the new code
        if (currentcode !== code) {
            this.setState({
                currentcode: code
            });
            //Gán lại đường dẫn của trang theo đúng mã đã được chọn - đảm bảo khi copy đường dẫn này lần sau sẽ vào đúng trang với việc gắn mặc định code được lựa chọn
            var objurl = { Page: 'currentpage', Url: '/teststrucT/index/tesstructdetail' + code };
            history.pushState(objurl, objurl.Page, objurl.Url);

            //setTitle('sysmenu_list_title', title);
            //Lấy lại dữ liệu trên lưới
            // kiểm tra có phải lá hay không
            this.loadData(code, teststructcode);
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
    initAgGridContent: function (setRowData, getDataChange, setNextRow, setPrevRow) {
        var agGrid = {
            setRowData: setRowData,
            getDataChange: getDataChange,
            setNextRow: setNextRow,
            setPrevRow: setPrevRow
        };
        this.setState({ agGridContent: agGrid });
    },
    /**
     * Kiểm tra xem đây là hay không
     * @param {} theType 
     * @returns {} 
     */
    checkParent: function (theType) {
        $.ajax({
            url: "/TestStructContent/CheckParent",
            dataType: 'json',
            data: {
                code: this.state.currentcode
                , teststructcode: this.state.currentteststructcode
            },
            success: function (data) {
                if (data.ret >= 0) {
                    this.setState({ rowSelect: null });
                    theType(data.ret);
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }
        });
    },
    /**
    *Lấy dữ liệu cho vào lưới
     * id là mã của node chọn trên cây, chính là teststructcontent
    */
    loadData: function (id, teststructcode) {
        var ret;
        var that = this;
        var pageSize = $('#pageSize').val();
        if (isNaN(pageSize)) {
            pageSize = 0;
        }
        var page = this.state.page;
        if (isMiss(obj)) {
            obj = this.state.searchstatus;
        }
        var code = '';
        var codetype = false;
        var name = '';
        var nametype = false;
        var note = '';
        var notetype = false;
        //Truyền các tham số tìm kiếm
        if (!!obj.CODESEARCH) {
            code = obj.CODESEARCH.value;
            codetype = obj.CODESEARCH.type;
        }
        if (!!obj.NAMESEARCH) {
            name = obj.NAMESEARCH.value;
            nametype = obj.NAMESEARCH.type;
        }
        if (!!obj.NOTESEARCH) {
            note = obj.NOTESEARCH.value;
            notetype = obj.NOTESEARCH.type;
        }
        $.ajax({
            url: "/TestStructContent/CheckParent",
            dataType: 'json',
            data: {
                 code: id
                , teststructcode: teststructcode
            },
            success: function (data) {
                if (data.ret >= 0) {
                    this.setState({ rowSelect: null });
                    if (data.ret === 1) {
                        //$('#myGridTestStructContent').css('display', 'block');
                        //$('#myGridTestStruct').css('display', 'none');
                        $('#myGridTestStructContent').removeClass('hidden');
                        $('#myGridTestStructDetail').addClass('hidden');
                        this.refs.hidTheType.value = 'CONTENT';
                        this.state.agGridContent.setRowData
                            (data.liTestStructContent);
                    }                       
                    if (data.ret === 2) {
                        $('#myGridTestStructContent').addClass('hidden');
                        $('#myGridTestStructDetail').removeClass('hidden');
                        this.refs.hidTheType.value = 'DETAIL';
                        this.state.agGrid.setRowData(data.liTestStructDetail);
                    }                        
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
    *para obj: là mã của bản ghi vừa cập nhật
    */
    ReloadList: function (obj, teststructcode) {
        var subjectcode = this.props.parent.getKeyValue("subjectcode");
        this.loadTree(subjectcode);
        //cập nhật lại danh sách
        this.loadData(obj, teststructcode);
        setTimeout(function () {
            $('#teststructcontent_list_tree').jstree(true).select_node(this.state.currentnode);
        }.bind(this), 200);
       
    },
    /**
    * Cập nhật lại thông tin sau khi gọi xóa dữ liệu thành công
    */
    ReloadListDelete: function (teststructcode) {
        var subjectcode = this.props.parent.getKeyValue("subjectcode");
        this.loadTree(subjectcode);
        //cập nhật lại danh sách
        this.loadData(this.state.currentcode, teststructcode);
        setTimeout(function () {
            $('#teststructcontent_list_tree').jstree(true).select_node(this.state.currentnode);
        }.bind(this), 200);
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
      
        //Không hiểu lấy theType để làm gì
        this.checkParent(function(theType) {
            var temp = theType;
        });
        //--Call nothing
        if (this.state.lstTestStruct.length > 0) {
            var teststructcode = this.state.currentteststructcode;
            var obj = {
                PARENTEXT: this.state.parentextcode,
                PARENTCODE: this.state.currentcode,
                THETYPE: this.refs.hidTheType.value,
                PARENTNAME: this.state.parentname,
                TESTSTRUCTCODE: this.state.currentteststructcode
            };
            //gọi hàm từ trong đối tượng popup form để thiết lập tham số, sau đó hiển thị
            this.refs.TeststructdetailPopup.ClearInput(obj);
            this.refs.TeststructdetailPopup.Show();
        } else {
            bootbox.alert("Chưa có cấu trúc đề!", false);
        }


    },
    onNewClickContent: function () {
        if (this.state.lstTestStruct.length > 0){
        var teststructcode = this.state.currentteststructcode;
        var obj = { PARENTEXT: this.state.parentextcode, PARENTCODE: this.state.currentcode, THETYPE: this.refs.hidTheType.value, PARENTNAME: this.state.parentname, TESTSTRUCTCODE: this.state.currentteststructcode };
        //gọi hàm từ trong đối tượng popup form để thiết lập tham số, sau đó hiển thị
        this.refs.TeststructcontentPopup.ClearInput(obj);
        this.refs.TeststructcontentPopup.Show();
        } else
            bootbox.alert("Chưa có cấu trúc đề!", false);
    },
    /**
    *Hàm thực hiện khi sửa bản ghi
    */
    onEditClick: function () {
        var thetype = this.refs.hidTheType.value;
        if (this.state.rowSelect === null)
            bootbox.alert('Chưa chọn bản ghi hoặc nhiều hơn một bản ghi');
        else if (this.state.rowSelect.length !== 1)
            bootbox.alert('Chưa chọn bản ghi hoặc nhiều hơn một bản ghi');
        else {

            var currentobj = this.state.rowSelect[0];
            
            if (thetype === 'CONTENT') {
                var obj = {
                    NAME: currentobj.NAME
                        , PARENTCODE: this.state.currentcode
                        , CODE: currentobj.CODE
                        , THEORDER: currentobj.THEORDER
                        , NOTE: currentobj.NOTE
                        , CODEVIEW: currentobj.CODEVIEW
                        , LOCK: currentobj.LOCK
                        , TESTSTRUCTCODE: currentobj.TESTSTRUCTCODE
                        , SUBJECTCODE: currentobj.SUBJECTCODE
                        , EXTENSIONCODE: currentobj.EXTENSIONCODE
                        , TOTALTIME: currentobj.TOTALTIME
                };
                this.refs.TeststructcontentPopup.SetInput(obj);
                this.refs.TeststructcontentPopup.Show();
            }else  {
                var obj1 = {
                    TESTSTRUCTCONTENTCODE: this.state.currentcode
                       , CODE: currentobj.CODE
                       , TESTSTRUCTCODE: currentobj.TESTSTRUCTCODE
                       , QUESTIONTYPECODE: currentobj.QUESTIONTYPECODE
                       , AMOUNT: currentobj.AMOUNT
                       , TOTALMARK: currentobj.TOTALMARK
                       , SUBJECTCONTENTCODE: currentobj.SUBJECTCONTENTCODE
                };
                this.refs.TeststructdetailPopup.SetInput(obj1);
                this.refs.TeststructdetailPopup.Show();
            }
        }
        
    },
    /**
    *Thực hiện thao tác xóa
    */
    handDelete: function () {
        var thetype = this.refs.hidTheType.value;
        var url = '/TestStructContent/Delete/';
        if (thetype === 'DETAIL')
            url = '/TestStructDetail/Delete/';
        if (!!this.state.rowSelect) {
            var teststructcode = this.state.rowSelect[0].TESTSTRUCTCODE;
            var data = [];
            this.state.rowSelect.forEach(function (item) {
                data.push(item.CODE);
            });
            var postData = { code: data };
            $.ajax({
                url: url,
                type: "POST",
                dataType: "json",
                traditional: true,
                data: postData,
                success: function (data) {
                    if (data.ret >= 0) {
                        this.ReloadListDelete(teststructcode);
                    }
                    else {
                            bootbox.alert("Bản ghi có tham chiếu, cần xóa các menu con trước!", false);
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
        if (this.state.rowSelect.length === 0) {
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
        var typeName = false;
        var NOTE = currentobj.NOTE;
        var typeNote = false;

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
    onActive: function (parent) {
        var that = this;
        // lấy bản ghi cha được chọn
        var subjectcode = this.props.parent.getKeyValue('subjectcode');
        //Kiểm tra việc lấy dữ liệu và lấy lại dữ liệu; hoặc chưa load, hoặc cha đã bị thay đổi
        if (this.state.loaded === null || this.state.currentSubjectCode !== subjectcode) {

            this.loadTree(subjectcode);
            this.setState({ currentSubjectCode: subjectcode });
            this.setState({ loaded: true });//Có thể là giá trị khác để kiểm tra
        }
    },
    render: function () {

        var self = this;
        var config = { id: "CODE", text: "NAME", parent: "PARENTCODE", idext: "EXTENSIONCODE", teststructcode: "TESTSTRUCTCODE" };
        var searchconfig = [
            { title: 'Mã', id: 'searchSubjectcontent_code', type: 'text', combo: 'block' },
            { title: 'Tên bài học', id: 'searchSubjectcontent_name', type: 'text', combo: 'block' },
            { title: 'Ghi chú', id: 'searchSubjectcontent_note', type: 'text', combo: 'block' }];
        return (
    <div className="box">
        <div className="row">
            <input type="hidden" ref="hidTheType" id="hidTheType" />
            <div className="col-xs-3" style={{borderRight: '1px solid gray', minHeight:527}}>
                <Tree id='teststructcontent_list_tree' data={this.state.lstTestStruct} mapper={config} callback={this.TreeSelect} height='515px' />
            </div>
            <div className="col-xs-9">
            <div className="row">
                <div className="col-xs-12">

                <span id="sysmenu_list_title" className="subtitle" style={{float:'left'}}>{this.state.parentname}</span>
                </div>
            </div>
                            <div id="listSubCon" className="tab-pane fade  in active">
                   <TestStructDetailPopup setData={this.setData} onPre={this.onPrevClick} onNext={this.onNextClick} ReloadData={this.ReloadList} parent={this} ref={'TeststructdetailPopup'} id={'TeststructdetailPopup'} parent={this.props.parent} />
                    <TestStructContentPopup setData={this.setData} onPre={this.onPrevClick} onNext={this.onNextClick} ReloadData={this.ReloadList} parent={this} ref={'TeststructcontentPopup'} id={'TeststructcontentPopup'} parent={this.props.parent} />
                    <div id="myGridTestStructContent" className="ag-fresh hidden" style={{ width: '100%', height: '500px'}}>

                    </div>
                    <AgGrid container='myGridTestStructContent'
                            initAgGrid={this.initAgGridContent}
                            loadData={this.loadData}
                            onRowSelect={this.onRowSelect}
                            columnDefs={this.state.columnDefsContent}
                            headerCheckBox={true}>
                    </AgGrid>
                    <div id="myGridTestStructDetail" className="ag-fresh hidden" style={{ width: '100%', height: '500px'}}>

                    </div>
                    <AgGrid container='myGridTestStructDetail'
                            initAgGrid={this.initAgGrid}
                            loadData={this.loadData}
                            onRowSelect={this.onRowSelect}
                            columnDefs={this.state.columnDefsDetail}
                            headerCheckBox={true}>
                    </AgGrid>
                            </div>
            </div>
        </div>

    </div>

        );
    }

});
