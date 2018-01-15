﻿var PopupQGROUP = React.createClass({
    getInitialState: function () {
        return {
            questiontype: []
            , questionuse: []
            ,first:true
        }
    },
    componentWillMount: function () {
        if (this.state.first) {
            //Chỉ loa dữ liệu trong lần hiển thị đầu tiên
            this.setState({ first: false });
            this.listComboQtype();
            this.listComboQuse();
        }

    },
    listComboQtype: function () {
        $.ajax({
            url: "/QuestionType/ListcomboQType",
            dataType: 'json',
            success: function (data) {
                if (data.ret >= 0) {
                    this.setState({ questiontype :data.data});
                }
                else {
                    log.show("Không lấy được môn học lên combobox", false);
                }
            }.bind(this)
        });
    },
    listComboQuse: function () {
        $.ajax({
            url: "/QuestionType/ListcomboQuse",
            dataType: 'json',
            success: function (data) {

                if (data.ret >= 0) {
                    this.setState({ questionuse:data.data});

                }
                else {
                    log.show("Không lấy được môn học lên combobox", false);
                }
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
    },
    /**
    *hàm được gọi để xóa dữ liệu trên form cho phép thêm mới; được gọi bởi component có component này (list)
    */
    ClearInput: function () {
        this.ClearThing();//clear
    },
    /**
    *thực tế xóa trên form
    */
    ClearThing: function () {
        this.refs[this.props.id + "_CODE"].value = "";
        this.refs[this.props.id + "_CODEVIEW"].value = "";
        this.refs[this.props.id + "_NAME"].value = "";
        this.refs[this.props.id + "_LOCK"].checked = true;//Mặc định là hiển thị
        this.refs[this.props.id + '_QUESTIONTYPECODE'].setValueString('');
        this.refs[this.props.id + '_QUESTIONUSECODE'].setValueString('');
        if (!!window.tinymce.get(this.props.id + '_content_mce')) {
            window.tinymce.get(this.props.id + '_content_mce').setContent("");
        }
        //Set status
        this.refs[this.props.id + "_status"].innerHTML = 'new';
    },
    /**
    *Hàm gán dữ liệu để sửa, được gọi bởi component cha của component này
    *para obj: thông tin về dữ liệu được thay đổi
    */
    SetInput: function (obj) {
        //Sử dụng cú pháp của react để thực hiện tương tác dữ liệu
        this.refs[this.props.id + "_CODE"].value = obj.CODE;
        this.refs[this.props.id + "_CODEVIEW"].value = obj.CODEVIEW;
        this.refs[this.props.id + "_NAME"].value = obj.NAME;
        this.refs[this.props.id + "_LOCK"].checked = (obj.LOCK === 0);
        this.refs[this.props.id + '_QUESTIONTYPECODE'].setValueString(obj.QUESTIONTYPECODE);
        this.refs[this.props.id + '_QUESTIONUSECODE'].setValueString(obj.QUESTIONUSECODELIST);
        $('textarea.contentQG').html(obj.CONTENT);
        window.tinymce.get(this.props.id + '_content_mce').setContent($('textarea.contentQG').val());
        //Set status
        this.refs[this.props.id + "_status"].innerHTML = 'edit';
    },

    /**
   *Kiểm tra để gọi load lại cho dữ liệu từ component cha (danh sách)
   *para obj: là mã của bản ghi mới được thao tác
   */
    ReloadData: function (obj) {
        if (isMiss(this.props.ReloadData)) {
            return false;
        }
        else {
            this.props.ReloadData(obj);
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
    SaveData: function (isClose) {
        //$('textarea.contentQG').html(tinymce.get(this.props.id + '_content_mce').getContent());
        var content =  window.tinymce.get('contentQG').getContent();
        content = content.replace(new RegExp('src="ContentQuestion', 'g'), 'src="/ContentQuestion');
        content = content.replace(new RegExp('src="../../ContentQuestion', 'g'), 'src="/ContentQuestion');
        var subjectcode = this.props.parent.getKeyValue('subjectcode');
        var subjectcontentcode = this.props.parent.getKeyValue('subjectcontentcode');
        var data = {
            NAME: this.refs[this.props.id + "_NAME"].value,
            CODEVIEW: this.refs[this.props.id + "_CODEVIEW"].value,
            LOCK: this.refs[this.props.id + "_LOCK"].checked ? 0 : 1,
            CODE: this.refs[this.props.id + "_CODE"].value,
            CONTENT: content,
            SUBJECTCODE: subjectcode,
            SUBJECTCONTENTCODE: subjectcontentcode,
            QUESTIONTYPECODE: this.refs[this.props.id + '_QUESTIONTYPECODE'].getValueString(),
            QUESTIONUSECODELIST: this.refs[this.props.id + '_QUESTIONUSECODE'].getValueString()
    }
        $.ajax({
            url: "/Question/UpdateQGROUP",
            dataType: 'json',
            data: data,
            type: "POST",
            success: function (data) {
                if (data.ret >= 0) {
                    log.show("Ghi thành công!", true);
                    if (isClose) {
                        this.Hide();
                    } else {
                        this.ClearInput({});
                    }
                    this.ReloadData();
                }
                else {
                    log.show("Ghi lỗi!", false);
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }
        });
    },
    changeType: function (obj) {
        var that = this;
        if (!isMiss(obj)) {
            callAjax('/questiontype/GetMaxCount', { code: obj.value }, function(data) {
                if (that.refs[that.props.id + '_CODEVIEW'].value === "") {
                    that.refs[that.props.id + '_CODEVIEW'].value = data.obj.CODEVIEW+ "_" + data.count;
                }
                if (that.refs[that.props.id + '_NAME'].value === "") {
                    that.refs[that.props.id + '_NAME'].value = obj.label + "_" + data.count;
                }

            }.bind(this));

        }
    },
    render: function () {
        var id = this.props.id;
        return (
                                <div className="modal fade" id={id} ref={id} role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                  <div className="modal-dialog">
                    <div className="box box-info">
                      <div className="modal-header with-border">
                        <button type="button" className="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span className="sr-only">Close</span></button>
                        <h4 className="modal-title" id="myModalLabel">Thêm bản ghi mới</h4>
                      </div>
                      <div className="modal-body">
                          <form className="form-horizontal" id='myform' role="form">
                              <input type="text" ref={id + '_CODE'} id={id + '_CODE'} className="form-control col-md-10 hidden" />
                                 <div className="form-group">
                                   <label className="col-sm-2 control-label">Loại câu hỏi</label>
                                        <div className="col-sm-10">
                                          <Combobox id={id + '_QUESTIONTYPECODE'} ref={id + '_QUESTIONTYPECODE'} lst={this.state.questiontype} valuefield='CODE' textfield='{NAME}' tooltip='Chọn loại câu hỏi' callback={this.changeType} />
                                        </div>
                                 </div>
                                 <div className="form-group">
                                   <label className="col-sm-2 control-label">Loại hình </label>
                                        <div className="col-sm-10">
                                          <Combobox  id={id + '_QUESTIONUSECODE'} ref={id + '_QUESTIONUSECODE'} lst={this.state.questionuse} valuefield='CODE' textfield='{NAME}' tooltip='Chọn loại sử dụng' multiple={true}/>
                                        </div>
                                 </div>
                              
                              <div className="form-group">
                                  <label className="col-sm-2 control-label">Mã câu hỏi trong nhóm</label>
                                  <div className="col-sm-10">
                                      <input type="text" className="form-control" ref={id + '_CODEVIEW'} id={id + '_CODEVIEW'} />
                                  </div>
                              </div>
                              
                              <div className="form-group">
                                  <label className="col-sm-2 control-label">Mô tả gợi nhớ câu hỏi</label>
                                  <div className="col-sm-10">
                                      <input type="text" className="form-control" ref={id + '_NAME'} id={id + '_NAME'}/>
                                  </div>
                              </div>
                              <div className="form-group">
                                  <div className="col-sm-offset-2 col-sm-10">
                                      <div className="checkbox">
                                          <label>
                                              <input type="checkbox" ref={id + '_LOCK'} id={id + '_LOCK'}/> Hiển thị
                                          </label>
                                      </div>
                                  </div>
                              </div>
                              {/*<div className="form-group">
                                  <label className="col-sm-2 control-label">Ghi chú</label>
                                  <div className="col-sm-10">
                                      <textarea className="form-control" rows="4" ref={id + '_NOTE'} id={id + '_NOTE'}></textarea>
                                  </div>
                              </div>*/}
                              <div className="form-group">
                                  <label className="col-sm-2 control-label">Nội dung câu hỏi</label>
                                  <div className="col-sm-10">
                                      <textarea className="tinymce form-control contentQG" ref={id + '_content_mce'} id={id + '_content_mce'}></textarea>
                                  <input name="image" type="file" id="upload_imageQG" className="hidden" width="100" height="100" />
                                  <input name="media" type="file" id="upload_mediaQG" className="hidden" width="100" height="100" />

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
    },
});