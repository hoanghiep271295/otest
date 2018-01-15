﻿/**
 * Quy tắc đặt tên
 *Cung cấp ra ngoài các hàm:
 * ClearInput(obj): Xóa các text box - được gọi từ cha
 * SetInput(obj): Thiết lập thông tin trên các ô text tương ứng - được gọi từ cha
 * ReloadData(): callback function được gán từ cha vào để cập nhật lại thông tin của cha nếu cần thiết
 */
var TestStructDetailPopup = React.createClass({
    getInitialState: function () {
        return ({
            lstSubjectContent: [],
            lstQuestionType: []
        }
        );

    },
    componentWillMount: function () {
        //Load các thông tin về danh mục các thứ khác nếu cần hiết
    },
    componentDidMount: function () {
        this.loadQuestionType();
    },
    loadQuestionType: function() {
        $.ajax({
            url: '/QuestionType/GetAll',
            dataType: 'json',
            success: function (data) {
                if (data.ret >= 0) {
                    this.setState({
                        lstQuestionType: data.lst
                    });
                    if (data.lst.length > 0)
                        this.refs['QUESTIONTYPECODE'].setValueString(data.lst[0].CODE);
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.error('unknow:url', status, err.toString());
            }.bind(this)
        });
    },
    /**
    *Hiển thị, được gọi bởi component cha
    */
    Show: function () {
        $('#' + this.props.id).modal('show');
    },
    /**
    *Ẩn form hiện tại
    */
    Hide: function () {
        $('#' + this.props.id).modal('hide');
    },    /**
    *hàm được gọi để xóa dữ liệu trên form cho phép thêm mới; được gọi bởi component có component này (list)
    */
    ClearInput: function (obj) {
        this.refs.teststructdetail_popup_teststructcontentcode.value = obj.PARENTCODE;
        this.refs.teststructdetail_popup_teststructcode.value = obj.TESTSTRUCTCODE;
        //Không hiểu vì sao phải load lại cái này, 
        //Kiểm tra load lại - nếu không nên truyền nó từ danh sách sang
     //   this.loadDropDownTree();
        this.ClearThing();//clear
    },
    /**
    *thực tế xóa trên form
    */
    ClearThing: function () {
        this.refs[this.props.id + "_CODE"].value = "";
        this.refs[this.props.id + "_AMOUNT"].value = "0";
        this.refs[this.props.id + "_TOTALMARK"].value = "0";
        //Set status
        this.refs[this.props.id + "_status"].innerHTML = 'new';

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
    /**
    *Hàm gán dữ liệu để sửa, được gọi bởi component cha của component này
    *para obj: thông tin về dữ liệu được thay đổi
    */
    SetInput: function (obj) {
        this.refs.teststructdetail_popup_teststructcontentcode.value = obj.TESTSTRUCTCONTENTCODE;
        this.refs.teststructdetail_popup_teststructcode.value = obj.TESTSTRUCTCODE;
        //Sử dụng cú pháp của react để thực hiện tương tác dữ liệu
        this.refs[this.props.id + "_CODE"].value = obj.CODE;
        this.refs[this.props.id + "_AMOUNT"].value = obj.AMOUNT;
        this.refs[this.props.id + "_TOTALMARK"].value = obj.TOTALMARK;
        this.refs['QUESTIONTYPECODE'].setValueString(obj.QUESTIONTYPECODE);
        this.refs['dropSubjectContent'].setValue(obj.SUBJECTCONTENTCODE);
        //Set status
        this.refs[this.props.id + "_status"].innerHTML = 'edit';
    },

    /**
   *Kiểm tra để gọi load lại cho dữ liệu từ component cha (danh sách)
   *para obj: là mã của bản ghi mới được thao tác
   */
    ReloadData: function (parentcode, teststructcode) {
        if (isMiss(this.props.ReloadData)) {
            //console.log('Call load data');
            return false;
        }
        else {
            //console.log('Call load data!!!!!!!!!!!!!');
            this.props.ReloadData(parentcode, teststructcode);
            return true;
        }
    },
    /**
    *gọi khi bấm nút ghi
    */
    SaveClick: function () {
        this.SaveData(true);
    },
    /**
    *gọi khi bấm nút ghi và tạo mới
    */
    SaveContinueClick: function () {
        this.SaveData(false);
    },
    /**
     *Thực tế ghi dữ liệu
   *para isClose xác định sau khi ghi xong sẽ đóng form, hay là tiếp tục tạo mới
   */
    SaveData: function (isClose) {
        var teststructcontentcode = this.refs.teststructdetail_popup_teststructcontentcode.value;
        var teststructcode = this.refs.teststructdetail_popup_teststructcode.value;
        var subjectcode = this.props.parent.getKeyValue("subjectcode");
        var subjectcontentcode = this.refs['dropSubjectContent'].getValue().id;
        var questiontypecode = this.refs['QUESTIONTYPECODE'].getValueString();
        var data = {
            CODE: this.refs[this.props.id + "_CODE"].value,
            AMOUNT: this.refs[this.props.id + "_AMOUNT"].value,
            TOTALMARK: this.refs[this.props.id + "_TOTALMARK"].value,
            TESTSTRUCTCONTENTCODE: teststructcontentcode,
            TESTSTRUCTCODE: teststructcode,
            SUBJECTCODE: subjectcode,
            SUBJECTCONTENTCODE: subjectcontentcode,
            QUESTIONTYPECODE: questiontypecode
        }
        //console.log(data);
        //Add or edit 1 item
        $.ajax({
            url: "/TestStructDetail/Update",
            type: 'POST',
            data: data,
            dataType: 'json',
            success: function (data) {
                if (data.ret >= 0) {
                    if (isClose) {
                        //Ghi và kết thúc
                        this.Hide();
                    }
                    else {
                        //Ghi và tạo form mới
                        this.ClearThing();
                    }
                    //Load lại dữ liệu trên grid
                    this.ReloadData(teststructcontentcode, teststructcode); //Truyền code để chọn đúng bản ghi - xử lý trên grid
                }
                else {
                    //Sử dụng bootbox để thông báo, thay vì thông báo của hệ thống
                    bootbox.alert('Lỗi ghi dữ liệu');
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.error('unknow:url', status, err.toString());
            }.bind(this)
        });

    },
    render: function () {
        var id = this.props.id;
        //       var arr3 = this.state.lstSubjectContent;
        var arr3 = this.props.parent.getKeyValue('lstsubjectcontent');
            var mapping = { id: 'CODE', text: 'NAME', parent: 'PARENTCODE', idext:'CODE'};
        return (
                <div className="modal fade" id={id} ref={id} role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                  <div className="modal-dialog">
                    <div className="box box-info">
                      <div className="modal-header with-border">

                        <button type="button" className="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span className="sr-only">Close</span></button>
                        <h4 className="modal-title" id={id+"_form_title"} ref={id+"_form_title"}>Thêm chi tiết cấu trúc đề</h4>
                           <input type="hidden" id="teststructdetail_popup_teststructcontentcode" ref="teststructdetail_popup_teststructcontentcode" />{/*Lưu lại mã code của cha hiện tại*/}
                           <input type="hidden" id="teststructdetail_popup_teststructcode" ref="teststructdetail_popup_teststructcode" />{/*Lưu lại mã code của cha hiện tại*/}
                      </div>
                      <div className="modal-body">
                          <form className="form-horizontal" role="form">
                              <input type="text" id={id+"_CODE"} ref={id+"_CODE"} className="form-control col-md-10 hidden" />
                              <div className="form-group">
                                  <label className="col-sm-2 control-label">Nội dung bài học</label>
                                   <div className="col-sm-10">
                              <DropdownTree title='Nội dung bài học' id='dropSubjectContent' lst={arr3} onSelect={this.ComboOnSelect} onCheck={this.ComboOnCheck} onExpand={this.ComboOnExpand} check={false} selectChildren={true} mapper={mapping} ref='dropSubjectContent' />
                                   </div>
                              </div>
                              <div className="form-group">
                                  <label className="col-sm-2 control-label">Loại câu hỏi</label>
                                  <div className="col-sm-10">
                                       <Combobox lst={this.state.lstQuestionType} valuefield='CODE' textfield='{NAME}' id='QUESTIONTYPECODE' callback={''} tooltip="Click hoặc space chọn" multiple={false} ref='QUESTIONTYPECODE' />
                                  </div>
                                  </div>
                              <div className="form-group">
                                  <label className="col-sm-2 control-label">Số câu hỏi</label>
                                  <div className="col-sm-10">
                                      <input type="number" className="form-control" id={id + "_AMOUNT"} ref={id + "_AMOUNT"} />
                                  </div>
                              </div>
                              <div className="form-group">
                                  <label className="col-sm-2 control-label">Điểm</label>
                                  <div className="col-sm-10">
                                      <input type="number" className="form-control" id={id + "_TOTALMARK"} ref={id + "_TOTALMARK"} />
                                  </div>
                              </div>
</form>
                    </div>
             <div className="box-footer modal-footer">
                 {/*Phần dành để hiển thị trạng thái - không thay đổi*/}
                <span className="label label-warning" style={{float:'left'}} id={id+"_status"} ref={id+"_status"}>i</span>
                <button type="button" className="btn btn-primary" onClick={this.SaveClick}><i className="fa fa-floppy-o"></i> Ghi</button>
                <button type="button" className="btn btn-primary" onClick={this.SaveContinueClick}><i className="fa fa-plus-circle"></i> Ghi và thêm mới</button>
                <button type="button" className="btn btn-default " data-dismiss="modal"><i className="fa fa-sign-out"></i>Thoát</button>
             </div>

                    </div>
                  </div>
                </div>
            );
    }
});