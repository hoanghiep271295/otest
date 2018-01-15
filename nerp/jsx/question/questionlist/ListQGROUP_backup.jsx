﻿var ListQGROUP = React.createClass({
    getInitialState: function () {
        return {
            agGrid: { setRowData: null, getDataChange: null, setNextRow: null, setPrevRow: null },
            rowSelect: null,
            columnDefs: [
                { headerName: "Mã câu hỏi trong nhóm", field: "CODEVIEW", width: 100, editable: false }
                ,{ headerName: "Mô tả gợi nhớ câu hỏi", field: "NAME", width: 300, editable: false }
                ,{ headerName: "Hiển thị", field: "LOCK", width: 120, editable: false, type: 'invcheckbox' }
//                ,{ headerName: "Ghi chú", field: "NOTE", width: 400, editable: false }
            ],
            searchstatus: [],
            loaded: null, //Kiểm tra chỉ load dữ liệu lần đầu tiên
            popup: null,//Để lưu đối tượng popup ở đây
            tab: null,
            page : 1,
            currentcode: ''
        };
    },
    componentWillMount: function(){
        //var tab = new Tab(false, 'listQGROUP', 'Nhóm câu hỏi', this.onNewClick, null, this.onDeleteClick, this.onNextClick, this.onPrevClick, this.onReport, this.onActive, this.onSearch, this.onSearchSQL);
        //tab.pushToList();
        //this.setState({ tab: tab });
        //tab.setTabActive('listQGROUP');
        //component.add('listQGROUP', this);
    },
    componentDidMount: function () {
        this.setState({popup:this.refs[this.props.id + '_Popup']});
//        this.loadData();

    },

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
    //Thêm bắt buộc so với cái cũ - 
    /**
    *Danh sách các nút lệnh - để tương tác do cha củađối tượng này gọi (xem hàm dùng chung trong _shared/TabHeader.jsx, ButtonList.jsx )
    */
    registerButton: function () {
        var obj = Object();
        //Đầy đủ nếu nó không thuộc các nhóm mặc định: { ref: 'cmdNew', callback: this.onPrint,title:'Hello',icon:'',tooltip:'Không rõ'}
        obj = [{ ref: 'cmdAdd', callback: this.onNewClick }
//             , { ref: 'cmdSearchSQL', callback: this.onSearchSQL }
             , { ref: 'cmdPrint', callback: this.onReport }
             , { ref: 'cmdSearch', callback: this.onSearch }
             , { ref: 'cmdEdit', callback: this.onEditClick }
             , { ref: 'cmdDelete', callback: this.onDeleteClick }
             , { ref: 'cmdRefresh', callback: this.Refresh }
        ];
        return obj;
    },
    onActive: function () {
        var subjectcontentcode = this.props.parent.getKeyValue('subjectcontentcode');
        if (this.state.loaded === null || subjectcontentcode !== this.state.currentcode) {
            this.setState({ currentcode: subjectcontentcode });
            this.loadData();
            this.setState({ loaded: true });//Có thể là giá trị khác để kiểm tra
        }

    },
    refreshRowData: function () {
        this.loadData();
    },
    /**
*Lấy lại toàn bộ dữ liệu 
*/
    Refresh: function () {
        this.loadData(this.state.searchstatus, this.state.rowSelect[0]);
    },
    /**
    *Lấy lại toàn bộ dữ liệu được gọi bởi popup - với đối tượng vào để xử lý phù hợp
    */
    ReloadList: function (obj) {
        //Mặc định theo giá trị tìm kiếm hiện tại, thiết lập theo bản ghi hiện tại
        this.loadData(this.state.searchstatus, obj);

    }
    ,
    /**
    * Cập nhật lại thông tin sau khi gọi xóa dữ liệu thành công
    */
    ReloadListDelete: function () {
        //cập nhật lại danh sách
        this.loadData();//(this.state.currentcode);
    },
    loadData: function (obj, current) {
        var subjectcode = this.props.parent.getKeyValue('subjectcode');
        var subjectcontentcode = this.props.parent.getKeyValue('subjectcontentcode');
        var ret;
        //window.NProgress.start();
        //setTimeout(function () {
        //    NProgress.set(0.9);
        //    NProgress.start();
        //}, 10);
        var pageSize = 0;//$('#pageSize').val();
        //if (isNaN(pageSize)) {
        //    pageSize = 0;
        //}
        var page = this.state.page;
        $.ajax({
            url: "/Question/getListQGROUP",
            dataType: 'json',
            data: {
                page: page,
                pageSize: pageSize,
                subjectcontentcode: subjectcontentcode,
                subjectcode: subjectcode
            },
            success: function (data) {
                //ret = data.data;
                //console.log(data.data);
                if (!data.lst) {
                    this.setState({ rowSelect : null });
                }                
                this.state.agGrid.setRowData(data.lst);
                //this.setDisplay(page, pageSize, data);
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }
        });
//        window.NProgress.done();
        return ret;
    },
    // set hiển thị số bản ghi và disable nút <<, >>
    setDisplay: function (page, pageSize, data) {
        // set phần hiển thị số bản ghi
        //$("#startIndex").text((page - 1) * pageSize + 1);
        //if (page == data.totalPage) {
        //    $("#endIndex").text(data.totalItem);
        //} else
        //    $("#endIndex").text(page * pageSize);
        //$("#totalItem").text(data.totalItem);
        //// disable nút <, >
        //if (page == 1)
        //    $("#prePage").prop('disabled', true);
        //else
        //    $("#prePage").prop('disabled', false);
        //if (page == data.totalPage)
        //    $("#nextPage").prop('disabled', true);
        //else
        //    $("#nextPage").prop('disabled', false);
    },
    // set data cho popup
    setData: function (data) {
        if (!!data) {
            $('#CODE').val(data.CODE);
            $('#CODEVIEW').val(data.CODEVIEW);
            $('#NAME').val(data.NAME);
            $('#THEORDER').val(data.THEORDER);
            $('#LOCK').prop('checked', data.LOCK);
            $('#NOTE').val(data.NOTE);
            $('textarea.tinymce').html(tinymce.get('content_mce').getContent());
            var c = $('textarea.tinymce').text();
            tinymce.get('content_mce').setContent(c);
        }
        else {
            this.clearData();
        }
    },
    
    onNewClick:function() {
        this.state.popup.ClearInput({});
        this.state.popup.Show();
    },
    onEditClick: function () {
        if (this.state.rowSelect.length != 1) {
            bootbox.alert('Chưa chọn bản ghi hoặc nhiều hơn một bản ghi');
        } else {
            var obj = this.state.rowSelect[0];
            this.state.popup.SetInput(obj);
            this.state.popup.Show();
        }
    },
    handDelete: function(){
        if (!!this.state.rowSelect) {
            var data = [];
            this.state.rowSelect.forEach(function (item, index) {
                data.push(item.CODE);
            });
            var postData = { code: data };
            $.ajax({
                url: "/Question/DeleteQGROUP",
                type: "POST",
                dataType: "json",
                traditional: true,
                data: postData,
                success: function (data) {
                    if (data.ret >= 0) {
                        this.refreshRowData();
                        log.show("Đã xoá các bản ghi đã chọn?",true);
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
    onDeleteClick: function(){
        confirm.show(null,this.handDelete,null);  
    },
    //onNextClick: function(){
    //    !!this.state.rowSelect && this.state.agGrid.setNextRow(this.state.rowSelect[0]);
    //    setTimeout(function () {
    //        this.setData(this.state.rowSelect[0]);
    //    }.bind(this), 200);
    //},
    //onPrevClick: function () {
    //    !!this.state.rowSelect && this.state.agGrid.setPrevRow(this.state.rowSelect[0]);
    //    setTimeout(function () {
    //        this.setData(this.state.rowSelect[0]);
    //    }.bind(this), 200);
    //},
    //onKeyUp: function (event) {
    //    var keypressed = event.keyCode || event.which;
    //    if (keypressed == 13) {
    //        this.setState({page: 1});
    //        setTimeout(function () {
    //            this.loadData();
    //        }.bind(this), 200);
    //    }
    //},
    onReport: function () {
        console.log("onReport");
    },
    onSearch: function () {
        //$('#ModalSearchSkill').modal('show');
        //console.log('Search skill');
        var dataSearch = [
                           { title: 'Mã', id: 'CODESEARCH', type: 'text' }
                           , { title: 'Tên', id: 'NAMESEARCH', type: 'text' }
                           , { title: 'Ghi chú', id: 'NOTESEARCH', type: 'text' }
        ];
        var obj = this.state.searchstatus;//Dữ liệu mặc định
        this.props.parent.ShowSearch(this.props.id + '_search', dataSearch, obj, this.doSearch);
        //        console.log('Gọi tìm kiếm');
    },
    onSearchSQL: function () {
        console.log("search SQL GRADE");
    },

    //prePage: function(){
    //    var c = this.state.page - 1;
    //    this.setState({ page: c });

    //    setTimeout(function () {
    //        this.loadData();
    //    }.bind(this), 200);
    //},
    //nextPage: function () {
    //    var c = this.state.page + 1;
    //    this.setState({ page: c});
       
    //    setTimeout(function () {
    //        this.loadData();
    //    }.bind(this), 200);
    //},

    onRowSelect: function (itemSelect) {
   
        this.setState({ rowSelect: itemSelect });
        if (itemSelect.length > 0) {
            this.props.parent.setKeyValue('questiongroupcode', itemSelect[0].CODE);
            this.props.parent.setKeyValue('questiontypecode', itemSelect[0].QUESTIONTYPECODE);
            this.props.parent.setKeyValue('questiontypecodeview', itemSelect[0]._QUESTIONTYPECODE.CODEVIEW);
            this.props.parent.setKeyValue('questiongroupname', itemSelect[0].NAME);
            this.props.parent.setKeyValue('questiongroupcontent', itemSelect[0].CONTENT);
            if (itemSelect[0]._QUESTIONTYPECODE.CODEVIEW === "MS" || itemSelect[0]._QUESTIONTYPECODE.CODEVIEW === "WR") {
                this.props.parent.Hide('question');
            } else {
                this.props.parent.UnHide('question');
            }
        } else {
            this.props.parent.setKeyValue('questiongroupcode', '');
            this.props.parent.setKeyValue('questiontypecode', '');
            this.props.parent.setKeyValue('questiontypecodeview', '');
            this.props.parent.setKeyValue('questiontypecodeview', itemSelect[0]._QUESTIONTYPECODE.CODEVIEW);
            this.props.parent.setKeyValue('questiongroupname', '');
            this.props.parent.setKeyValue('questiongroupcontent', '');
        }
        //$('#hidQUESTIONGROUPCODE').val(rowSelect);

        },
    render: function () {
        return (
            <div id={this.props.id+'_list'} className="tab-pane fade in active">
               <PopupQGROUP ReloadData={this.ReloadList} ref ={this.props.id + '_Popup'} id ={this.props.id + '_Popup'} parent={this.props.parent}/>
{/*               <PopupSearch id='ModalSearch' onSearch={this.onSearch}/>*/}
                <div id={this.props.id+'_grid'} className="ag-fresh customgrid">
                </div>
                    <AgGrid container={this.props.id+'_grid'}
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

