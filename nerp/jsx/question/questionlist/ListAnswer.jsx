﻿/**
 * Quy tắc đặt tên
 * QUESTIONGROUP :Câu hỏi hay được hiểu hay hơn chính là đầu bài của câu hỏi
 * QUESTION : câu hỏi con trong một đề bài
 * ANSWER : Câu trả lời cho một câu hỏi con 
 * TRUEANSWER : Nếu là 0 tức là câu trả lời sai và là 1 tức là câu trả lời đúng
 * các questiontype :Các hình thức câu hỏi thi khác nhau
    1.MC: câu hỏi một nhiều - có thể là 1 câu hỏi có nhiều đáp án và chọn một đáp án đúng
    2.PA: câu hỏi dạng ghép đôi - hiển thị một danh sách các câu hỏi bên trái, danh sách các câu hỏi bên phải ghép lại thành cặp
    3.FI: Câu hỏi điền vào đoạn trống - Có một đoạn các câu hỏi và sau đó có danh sách các đáp án (có thể dư hoặc không dư) để điền vào
    4.FG: Câu hỏi điền vào đoạn trống tự gõ từ - Có một đoạn các câu hỏi và sau đó người thi phải tự điền từ thích hợp vào ô trống.
    5.CO: Dạng câu hỏi tổng kết - cho một đoạn đọc; sau đó tiến hành đưa ra một câu hỏi và có nhiều đáp án trả lời độc lập - true/false, true/false/not given
    6.RW: Viết lại câu; Một câu hỏi có thể có nhiều đáp án đúng (để cho phép so sánh chỉ cần đúng một trong các đáp án đó là tính điểm)
    7.LA: Nghe nói - lưu lại một file không có answer
    8.WR: Bài viết (tự luận)
    9.MS: câu hỏi một nhiều chỉ dành cho một câu hỏi cho một nhóm; Câu hỏi ỏ nhóm, tự động sinh ra một bản ghi câu hỏi giả để lien kết, sau đó có các đáp án. 
    10.RA: Nhóm sắp xếp lại các cụm, có 1 câu hỏi bị cắt nhỏ ra, nhiệm vụ là sắp xếp nó lại 
    11.FF: Câu hỏi điền vào đoạn trống, mỗi chỗ trống sẽ có một số đáp án và sử dụng phương án combo box để chọn vào
 */
var ListAnswer = React.createClass({
    getInitialState: function() {
        return {
            agGrid: { setRowData: null, getDataChange: null, setNextRow: null, setPrevRow: null },
            rowSelect: null,
            columnDefs: [
                { headerName: "Mã hiển thị", field: "CODEVIEW", width: 200, editable: false },
                { headerName: "Tên", field: "NAME", width: 200, editable: false },
                { headerName: "Đúng", field: "TRUEANSWER", width: 200, editable: false, type: 'checkbox' }
            ],
            tab: null,
            questiontypeAnswer: null,
            buts: [{ ref: 'cmdAdd', callback: this.onNewClick }
                 , { ref: 'cmdEdit', callback: this.onEditClick }
                 , { ref: 'cmdDelete', callback: this.onDeleteClick }
                 , { ref: 'cmdRefresh', callback: this.Refresh }
            ]
        };
    },
    componentWillMount: function() {
    },
    componentDidMount: function () {
        this.setState({ popup: this.refs[this.props.id + '_Popup'] });
    },
    initAgGrid: function(setRowData, getDataChange, setNextRow, setPrevRow) {
        var agGrid = {
            setRowData: setRowData,
            getDataChange: getDataChange,
            setNextRow: setNextRow,
            setPrevRow: setPrevRow
        };
        this.setState({ agGrid: agGrid });
    },
    refreshRowData: function () {
        this.loadData();
    },
    onRowSelect: function (itemSelect) {
            this.setState({ rowSelect: itemSelect });
    },
    onActive: function () {
        console.log('Active list answer');
        var questiongroupcode = this.props.parent.getKeyValue('questiongroupcode');
        var questioncode = this.props.parent.getKeyValue('questioncode');
        var questiontypecodeview = this.props.parent.getKeyValue('questiontypecodeview');
        var that = this;

        if (isMiss(questiongroupcode)) {
            bootbox.alert("Chưa chọn nhóm câu hỏi", function () { that.props.parent.ChooseTab('questiongroup') });
            return;
        }
        var reqirequestion = 1;
        this.props.parent.setButtonStatus('cmdAdd', true);
        this.props.parent.setButtonStatus('cmdDelete', true);
        //tại sao lại phải disable đi, vẫn nên cho xóa
        console.log(questiontypecodeview);
        switch (questiontypecodeview) {
            case "LA":
                reqirequestion = 0;
                this.props.parent.setButtonStatus('cmdAdd', false);
                this.props.parent.setButtonStatus('cmdDelete', false);
                this.props.parent.setKeyValue('questioncode', questioncode);
                break;
            case "WR":
                reqirequestion = 0;
                this.props.parent.setButtonStatus('cmdAdd', false);
                this.props.parent.setButtonStatus('cmdDelete', false);
                this.props.parent.setKeyValue('questioncode', questioncode);
                //callAjax('/question/GetQuestion', { groupcode: questiongroupcode },
                //  function (data) {
                //      questioncode = data.firstquestion.CODE;
                //      this.props.parent.setKeyValue('questioncode', questioncode);
                //  }.bind(this));
                break;
            case "MS":
                reqirequestion = 0;
                this.props.parent.setKeyValue('questioncode', questioncode);
                //callAjax('/question/GetQuestion', { groupcode: questiongroupcode }, function(data) {
                //    questioncode = data.firstquestion.CODE;
                //    this.props.parent.setKeyValue('questioncode', questioncode);
                //}.bind(this));
                break;
        }
        if (isMiss(questioncode) && reqirequestion === 1) {
            bootbox.alert("Chưa chọn câu hỏi", function ()
            { that.props.parent.ChooseTab('question') });
            return;
        }
        this.loadData();
    },
    /**
*Lấy lại toàn bộ dữ liệu 
*/
    Refresh: function () {
    },
    /**
    *Lấy lại toàn bộ dữ liệu được gọi bởi popup - với đối tượng vào để xử lý phù hợp
    */
    ReloadList: function (obj) {
        //Mặc định theo giá trị tìm kiếm hiện tại, thiết lập theo bản ghi hiện tại
        this.loadData(this.state.searchstatus, obj);
    },
    /**
    * Cập nhật lại thông tin sau khi gọi xóa dữ liệu thành công
    */
    ReloadListDelete: function () {
        //cập nhật lại danh sách
        this.loadData();//(this.state.currentcode);
    },
    //load data for list answer
    loadData: function () {
        var questioncode = this.props.parent.getKeyValue('questioncode');
        var questiongroupcode = this.props.parent.getKeyValue('questiongroupcode');
        var questiontypecodeview = this.props.parent.getKeyValue('questiontypecodeview');
        var ret = 0;
             $.ajax({
                 url: "/Question/getListAnswer",
                 data: {
                     questioncode: questioncode,
                     questiongroupcode: questiongroupcode,
                     questiontypecodeview:questiontypecodeview
                  
                 },
                 dataType: 'json',
                 success: function(data) {
                     if (data.data.length === 0) {
                         this.setState({ rowSelect: null });
                     }
                     this.state.agGrid.setRowData(data.data);
                 }.bind(this),
                 error: function(xhr, status, err) {
                     console.log(err.toString());
                 }
             });
             return ret;
    },
    onNewClick: function () {
        var questiongroupcode = this.props.parent.getKeyValue('questiongroupcode');
        var questiontypecode = this.props.parent.getKeyValue('questiontypecode');
        var questiontypecodeview = this.props.parent.getKeyValue('questiontypecodeview');
        var questioncode = this.props.parent.getKeyValue('questioncode');
        var questionname = this.props.parent.getKeyValue('questionname');
        var questioncontent = this.props.parent.getKeyValue('questioncontent');
        var questiongroupname = this.props.parent.getKeyValue('questiongroupname');
        var questiongroupcontent = this.props.parent.getKeyValue('questiongroupcontent');
        var obj = {
            QUESTIONGROUPCODE: questiongroupcode,
            QUESTIONTYPECODE: questiontypecode,
            QUESTIONTYPECODEVIEW: questiontypecodeview,
            QUESTIONCODE: questioncode,
            QUESTIONNAME: questionname,
            QUESTIONCONTENT: questioncontent,
            QUESTIONGROUPCONTENT: questiongroupcontent,
            QUESTIONGROUPNAME: questiongroupname
    };
        this.state.popup.ClearInput(obj);
        this.state.popup.Show();
   
    },
    onEditClick: function () {
        if (this.state.rowSelect.length !== 1) {
            bootbox.alert('Chưa chọn bản ghi hoặc nhiều hơn một bản ghi');
        } else {
            var questiongroupcode = this.props.parent.getKeyValue('questiongroupcode');
            var questiontypecode = this.props.parent.getKeyValue('questiontypecode');
            var questiontypecodeview = this.props.parent.getKeyValue('questiontypecodeview');
            var questioncode = this.props.parent.getKeyValue('questioncode');
            var questiongroupname = this.props.parent.getKeyValue('questiongroupname');
            var questionname = this.props.parent.getKeyValue('questionname');
            var questioncontent = this.props.parent.getKeyValue('questioncontent');
            var questiongroupcontent = this.props.parent.getKeyValue('questiongroupcontent');
            var obj = this.state.rowSelect[0];
            obj.QUESTIONGROUPCODE = questiongroupcode;
            obj.QUESTIONTYPECODE = questiontypecode;
            obj.QUESTIONTYPECODEVIEW = questiontypecodeview;
            obj.QUESTIONGROUPNAME = questiongroupname;
            obj.QUESTIONCODE = questioncode;
            obj.QUESTIONNAME = questionname;
            obj.QUESTIONCONTENT = questioncontent;
            obj.QUESTIONGROUPCONTENT = questiongroupcontent;
            this.state.popup.SetInput(obj);
            this.state.popup.Show();
        }
    },
    handDelete: function () {
        if (!!this.state.rowSelect) {
            var data = [];
            this.state.rowSelect.forEach(function (item) {
                data.push(item.CODE);
            });
            var postData = { code: data };
            $.ajax({
                url: "/Question/DeleteAnswer",
                type: "POST",
                dataType: "json",
                traditional: true,
                data: postData,
                success: function (data) {
                    if (data.ret >= 0) {
                        this.refreshRowData();
                        log.show("Đã xoá các bản ghi đã chọn?", true);
                    }
                    else {
                        log.show("Xoá không thành công!", false);
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
                    log.show("No items have been deleted !", true);
                }
            }
        });
    },
    onNextClick: function () {
        !!this.state.rowSelect && this.state.agGrid.setNextRow(this.state.rowSelect[0]);
        setTimeout(function () {
            this.setData(this.state.rowSelect[0]);
        }.bind(this), 200);
    },
    onPrevClick: function () {
        !!this.state.rowSelect && this.state.agGrid.setPrevRow(this.state.rowSelect[0]);
        setTimeout(function () {
            this.setData(this.state.rowSelect[0]);
        }.bind(this), 200);
    },
    onKeyUp: function (event) {
        var keypressed = event.keyCode || event.which;
        if (keypressed === 13) {
            this.setState({ page: 1 });
            setTimeout(function () {
                this.loadData();
            }.bind(this), 200);
        }
    },
    onReport: function () {
        console.log("onReport");
    },
    onSearch: function () {
        $('#ModalSearch').modal('show');
        console.log('Search grade');
    },
    onSearchSQL: function () {
        console.log("search SQL GRADE");
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
    render: function () {
        return (
            <div id="listAnswer" className="tab-pane fade in">
               <PopupAnswer ReloadData={this.ReloadList} ref ={this.props.id + '_Popup'} id ={this.props.id + '_Popup'} parent={this.props.parent} />
          

   

    <div id={this.props.id+'_grid'} className="ag-fresh customgrid">
    </div>

        <AgGrid container={this.props.id+'_grid'}
        initAgGrid={this.initAgGrid}
        loadData={this.loadData}
        onRowSelect={this.onRowSelect}
        columnDefs={this.state.columnDefs}
        headerCheckBox={true}> </AgGrid>

</div>
            );}
});