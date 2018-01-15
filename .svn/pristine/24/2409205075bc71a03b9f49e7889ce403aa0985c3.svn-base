/**
 * Quy tắc đặt tên
 * QUESTIONGROUP :Câu hỏi hay được hiểu hay hơn chính là đầu bài của câu hỏi
 * QUESTION : câu hỏi con trong một đề bài
 * ANSWER : Câu trả lời cho một câu hỏi con 
 */
var ListSubCon = React.createClass({
    getInitialState: function () {
        return {
            agGrid: { setRowData: null, getDataChange: null, setNextRow: null, setPrevRow: null },
            rowSelect: null,
            columnDefs: [
              { headerName: "Mã hiển thị", field: "CODEVIEW", width: 120, align: 'center', editable: false },
                { headerName: "Tên", field: "NAME", width: 450, editable: false },
                { headerName: "Hiển thị", field: "LOCK", width: 100, editable: false, type: 'checkbox' }
             ],
            tab: null,
            page: 1,
            subject: []          
        };
    },
    componentWillMount: function () {
        var tab = new Tab(false, 'listSubCon', 'Nội dung bài học', this.onNewClick, null, this.onDeleteClick, this.onNextClick, this.onPrevClick, null, this.onActive);
        tab.pushToList();
        this.setState({ tab: tab });
        tab.setTabActive('listSubCon');
        component.add('listSubCon', this);
        this.loadCombo();
        //parent:combobox
        var parent = component.get("PARENTCODE");
        parent.setState({
            onChange: this.loadData
        });
      

    },
    callback: function (parentcode) {
        consolelog(parentcode);
    },
    loadCombo: function () {
        var comboparent = component.get('PARENTCODE');
        $.ajax({
            url: "Subject/Listcombo",
            dataType: 'json',
            success: function (data) {
                if (data.ret >= 0) {
                    setTimeout(function () {                      
                        comboparent.updatedata(data.data);
                    }.bind(this), 200);
                   
                }
                else {
                    log.show("Không lấy được môn học lên combobox", false);
                }
            }.bind(this)
        });
    },
    initAgGrid: function (setRowData, getDataChange, setNextRow, setPrevRow) {
        var agGrid = {
            setRowData: setRowData,
            getDataChange: getDataChange,
            setNextRow: setNextRow,
            setPrevRow: setPrevRow
        };
        this.setState({ agGrid: agGrid });
    },
    /*** var count = 0;
         var handle = setInterval(function(){
          count++;
          console.log(count);
          if(count == 5){
            clearInterval(handle);
            console.log('stop');
          }
    }, 100);
     * @returns {}
     */
    loadData: function () {
        var ret;     
        var handle = setInterval(function () {
            if (!!$('#PARENTCODE').val()) {
                window.NProgress.start();
               // console.log($('#PARENTCODE').val());
                var pageSize = $('#pageSizeSQ').val();
                var combo3 = component.get('PARENTCODE2');
                if (isNaN(pageSize)) {
                    pageSize = 0;
                }
                let page = this.state.page;
                var codeview = !!$('#CODESEARCHSQ').val() ? $('#CODESEARCHSQ').val() : null;
                var typeCodeView = !!$('#typeCODESEARCHSQ').val() ? $('#typeCODESEARCHSQ').val() : false;
                var name = !!$('#NAMESEARCHSQ').val() ? $('#NAMESEARCHSQ').val() : null;
                var typeName = !!$('#typeNAMESEARCHSQ').val() ? $('#typeNAMESEARCHSQ').val() : false;
                var note = !!$('#NOTESEARCHSQ').val() ? $('#NOTESEARCHSQ').val() : null;
                var typeNote = !!$('#typeNOTESEARCHSQ').val() ? $('#typeNOTESEARCHSQ').val() : false;
                var postdata = {
                    page: page,
                    pageSize: pageSize,
                    subjectcode: $('#PARENTCODE').val(),
                    codeView: codeview,
                    typeCodeView: typeCodeView,
                    name: name,
                    typeName: typeName,
                    note: note,
                    typeNote: typeNote
                };
                $.ajax({
                    url: "/SubjectContent/getList",
                    dataType: 'json',
                    data: postdata,
                    success: function (data) {
                        ret = data.data;
                        this.setState({ rowSelect: null });
                        if (data.ret >= 0) {                            
                            $('#hidQUESTIONGROUPCODE').val(data.groupquestion);
                            $('#hidQUESTIONCODE').val(data.question);
                            setTimeout(function() {
                                    combo3.updatedata(data.totalData, 1, '(Chọn nội dung bài học)'); },100);
                        } else {
                            $('#hidQUESTIONGROUPCODE').val('');
                            $('#hidQUESTIONCODE').val('');
                        }
                        this.state.agGrid.setRowData(JSON.parse(data.data2));
                        this.setDisplay(page, pageSize, data);
                    }.bind(this),
                    error: function (xhr, status, err) {
                        console.log(err.toString());
                    }
                });

                window.NProgress.done();
                clearInterval(handle);
            }
        }.bind(this), 100);


        return ret;
    },
    // set hiển thị số bản ghi và disable nút
    setDisplay: function (page, pageSize, data) {
        // set phần hiển thị số bản ghi
        $("#startIndexSQ").text((page - 1) * pageSize + 1);
        if (page === data.totalPage) {
            $("#endIndexSQ").text(data.totalItem);
        } else
            $("#endIndexSQ").text(page * pageSize);
        $("#totalItemSQ").text(data.totalItem);
        // disable nút <, >
        if (page === 1)
            $("#prePageSQ").prop('disabled', true);
        else
            $("#prePageSQ").prop('disabled', false);
        if (page === data.totalPage)
            $("#nextPageSQ").prop('disabled', true);
        else
            $("#nextPageSQ").prop('disabled', false);
    },
    /// set data cho popup
    setData: function (data) {
        if (!!data) {
            $('#CODESQ').val(data.CODE);
            $('#CODEVIEWSQ').val(data.CODEVIEW);
            $('#NAMESQ').val(data.NAME);
            $('#LOCKSQ').prop('checked', data.LOCK);
            $('#PARENTCODE2').val(data.PARENTCODE);
            $('#THEORDERSQ').val(data.THEORDER);
            $('#cboContentType').val(data.CONTENTTYPE);
            var a = data.NOTE;
            $('textarea.NOTESQ').html(a);
            window.tinymce.get('NOTESQ').setContent($('textarea.NOTESQ').val());
            var popup = component.get('popupsubcon');
            popup.getContentType(function (contentType) {
                if (contentType === 'TH' || contentType === 'BT' || contentType === 'KT') {
                    setTimeout(function () {
                        popup.getSubjectContentTest();
                    }.bind(this), 200);
                    document.getElementById('divNote').style.display = 'none';
                    document.getElementById('divExamtime').style.display = 'block';

                } else {
                    document.getElementById('divNote').style.display = 'block';
                    document.getElementById('divExamtime').style.display = 'none';
                }
            }.bind(this));
        } else {
            this.clearData();
        }


    },
    clearData: function () {
        // $('#PARENTCODE2').val("");
        $('#CODESQ').val("");
        $('#CODEVIEWSQ').val("");
        $('#NAMESQ').val("");
        $('#LOCKSQ').prop('checked', false);
        $('#THEORDERSQ').val(0);
        $('#NOTESQ').val("");
        $('#cboContentType').val("");
        $('#cboExamtime').val("");
        window.tinymce.get('NOTESQ').setContent("");
        document.getElementById('divNote').style.display = 'block';
        document.getElementById('divExamtime').style.display = 'none';
    },
    // set data cho popup
    onNewClick: function () {
        var rowSelect = this.state.rowSelect;
        if (!!rowSelect && !!rowSelect[0]) {
            this.setData(rowSelect[0]);
        }
        $('#NewModalSQ').modal('show');        
    },
    handDelete: function () {
        if (!!this.state.rowSelect) {
            var data = [];
            this.state.rowSelect.forEach(function (item) {
                data.push(item.CODE);
            });
            var postData = { code: data };
            $.ajax({
                url: "/SubjectContent/Delete",
                type: "POST",
                dataType: "json",
                traditional: true,
                data: postData,
                success: function (data) {
                    if (data.ret >= 0) {
                        this.refreshRowData();
                        log.show("Done !", true);
                    }
                    else {
                        log.show("Can not delete !", false);
                    }
                }.bind(this),
                error: function (xhr, status, err) {
                    console.log(err.toString());
                }
            });
        }
        else {
            log.show("Không có bản ghi nào!", false);
        }
    },
    onDeleteClick: function () {
        var that = this;
        //  confirm.show(null,this.handDelete,null);
        bootbox.confirm({
            message: "Do you want to delete these items ?",
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
                if (result) {
                    that.handDelete();
                }
                else {
                    log.show("No items have been deleted", true);
                }
            }
        });

        // confirm.show(null,this.handDelete,null);
    },
    onNextClick: function () {
        !!this.state.rowSelect && this.state.agGrid.setNextRow(this.state.rowSelect[0]);
        setTimeout(function () {
            this.setData(this.state.rowSelect[0]);
        }.bind(this), 50);
    },
    onPrevClick: function () {
        !!this.state.rowSelect && this.state.agGrid.setPrevRow(this.state.rowSelect[0]);
        setTimeout(function () {
            this.setData(this.state.rowSelect[0]);
        }.bind(this), 50);
    },
    onSearch: function () {
        $('#CODESEARCHSUBCON').val($('#hidCODESEARCHSUBCON').val());
        //$('#typeCODESEARCHSUBCON').val("false");
        $('#NAMESEARCHSUBCON').val($('#hidNAMESEARCHSUBCON').val());
        //$('#typeNAMESEARCHSUBCON').val("false");
        $('#NOTESEARCHSUBCON').val($('#hidNOTESEARCHSUBCON').val());
        //$('#typeNOTESEARCHSUBCON').val("false");
        $('#YEARINSEARCHSUBCON').val($('#hidYEARINSEARCHSUBCON').val());
        $('#typeYEARINSEARCHSUBCON').val($('#hidtypeYEARINSEARCHSUBCON').val());
        $('#YEAROUTSEARCHSUBCON').val($('#hidYEAROUTSEARCHSUBCON').val());
        //$('#typeYEAROUTSEARCHSUBCON').val("false");
        $('#ModalSearch').modal('show');
    },
    handleSearch: function () {
        $('#hidCODESEARCHSUBCON').val($('#CODESEARCHSUBCON').val());
        $('#hidNAMESEARCHSUBCON').val($('#NAMESEARCHSUBCON').val());
        $('#hidNOTESEARCHSUBCON').val($('#NOTESEARCHSUBCON').val());
        $('#hidYEARINSEARCHSUBCON').val($('#YEARINSEARCHSUBCON').val());
        $('#hidtypeYEARINSEARCHSUBCON').val($('#typeYEARINSEARCHSUBCON').val());
        $('#hidYEAROUTSEARCHSUBCON').val($('#YEAROUTSEARCHSUBCON').val());
        this.loadData();
        $('#ModalSearch').modal('hide');
    },
    onSearchSQL: function () {
        console.log("search SQL SUBCON");

    },
    handleSearchSQL: function () {

    },
    prePage: function () {
        var c = this.state.page - 1;
        this.setState({ page: c });
        setTimeout(function () {
            this.loadData();
        }.bind(this), 200);
    },
    nextPage: function () {
        var c = this.state.page + 1;
        this.setState({ page: c });

        setTimeout(function () {
            this.loadData();
        }.bind(this), 200);
    },
    onActive: function () {
        setTimeout(function () {
            $("#PARENTCODE3").parent().hide();
            $("#PARENTCODE").parent().show();
            $("#PARENTCODE").prop("disabled", false);
        }, 100);
        //khi load lại tab 1  luôn luôn set lại giá trị, điều này khá khó để giải quyết khi di chuyển từ tab 1 sang tab 4
        //vì nếu muốn khi onrowselect anyrow mà cập nhật lại giá trị lại ngay thì điều này không khác gì là giết chết server 
        //có 1 cách khác nữa là đành phải put và trong hidden input subcon, time to make it :))
        $('#hidQUESTIONGROUPCODE').val('');
        $('#hidQUESTIONCODE').val('');        
       var dataSearch = [
           { title: 'Mã', id: 'CODESEARCHSUBCON', type: 'text', combo: true },
           { title: 'Tên', id: 'NAMESEARCHSUBCON', type: 'text', combo: true },
           { title: 'Ghi chú', id: 'NOTESEARCHSUBCON', type: 'text', combo: true }
       ];
        var popupsearch = component.get('popupsearch');
        popupsearch.setState({ dataSearch: dataSearch });
        setTimeout(function () {
            popupsearch.setState({ search: this.handleSearch });
        }.bind(this), 200);         
      
         this.loadData();
    },
    refreshRowData: function () {

        this.loadData();
    },
    componentDidMount: function () {
      //  this case run from and tab 1 to tab 4 
        var question = component.get('listQuestion');
        question.setState({ questionactive: -1 });
        var questiongroup = component.get('listQGROUP');   
        questiongroup.setState({ statusQGroup: -1 });
    },
    /**
     * @param {object} itemSelect
     * @returns {}
     */
    onRowSelect: function (itemSelect) {
       
        this.setState({ rowSelect: itemSelect });
        if (!!itemSelect) {
            $('#hidSUBCONCODE').val('');
            //before put any object into hidden we have to convert to string
            // otherwise it'll be Object (can't read)
            if (!!itemSelect.length) {
                console.log('ok');
            } else {
                console.log('not ok');
            }
            if (!!$('#hidQUESTIONGROUPCODE').val() && !!itemSelect.length) {

                var obj = JSON.parse($('#hidQUESTIONGROUPCODE').val());
                if (itemSelect[0].CODE !== obj.SUBJECTCONTENTCODE) {
                    $('#hidQUESTIONCODE').val('');
                    $('#hidQUESTIONGROUPCODE').val('');
                }
            }
        }
    },
    render: function () {
        return (
            <div id="listSubCon" className="tab-pane fade  in active">
                   <PopupSubCon setData={this.setData}  onPre={this.onPrevClick} onNext={this.onNextClick} />
                <div className="table-before" >
                    <div>
                        <span style={{fontWeight:'bold',fontFamily:'serif'}} className=""> DANH SÁCH CÂU HỎI THEO MÔN HỌC</span>
                    </div>
                    <div>
                        <b>
                        <div style={{ 'width': '50px' }}>
                            <span id="item-indexSQ">
                                <span id='startIndexSQ'>0</span>-
                                <span id='endIndexSQ'>20</span>
                            </span> /
                            <span id="totalItemSQ">1000</span>
                        </div>
                        </b>
                        <div style={{fontWeight:'bold',fontFamily:'serif'}} style ={{ width: 30 }}>

                     </div>
                    <span style={{fontWeight:'bold',fontFamily:'serif'}}> Kích thước trang: </span>
                    <input type="text" id="pageSizeSQ" onKeyUp={this.onKeyUp} defaultValue="20" style={{ width: 30 }}/>
                    <button className="btn btn-default btn-sm" onClick = {this.prePage} id="prePage" style={{ paddingTop: '0.5px' }}><i className="fa fa-step-backward" aria-hidden="true"></i></button>
                        &nbsp;
                    <button className="btn btn-default btn-sm" onClick={this.nextPage} id="nextPage" style={{ paddingTop: '0.5px' }}><i className="fa fa-step-forward" aria-hidden="true"></i></button>
                    </div>
                </div>
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

        );
    }
});

        var count = 0;
   