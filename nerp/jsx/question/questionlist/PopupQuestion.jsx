﻿/**
 * Quy tắc đặt tên
 * QUESTIONGROUP :Câu hỏi hay được hiểu hay hơn chính là đầu bài của câu hỏi
 * QUESTION : câu hỏi con trong một đề bài
 * ANSWER : Câu trả lời cho một câu hỏi con 
 */
var PopupQuestion = React.createClass({
      getInitialState: function () {
          return {
              tab: null
          };
      },
      componentWillMount: function () {
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
      initChild: function (questiongtypecodeview, questioncode, statusQuestion) {
          //debugger
          console.log('init child:', questiongtypecodeview);
          var ins = null;
          switch (questiongtypecodeview) {
              //1
              case 'MC':
                   ins = ReactDOM.render(<MCQuestion  />, document.getElementById('question_detail'));
                  break;
                  //2
              case 'PA':
                  ins = ReactDOM.render(<PAQuestion  />, document.getElementById('question_detail'));
                  break;
                  //3
              case 'FI':
                  ins = ReactDOM.render(<FIQuestion />, document.getElementById('question_detail'));
                  break;
                  //4
              case 'FG':
                  ins = ReactDOM.render(<FGQuestion />, document.getElementById('question_detail'));
                  break;
                  //5
              case 'CO':
                  console.log("CO");
                      ReactDOM.render(<COQuestion parent={this.props.parent}
                                                         questioncode={questioncode}
                                                         statusQuestion={statusQuestion} />, document.getElementById('question_detail'));
                  break;
                  //6
              case 'RW':
                  ins = ReactDOM.render(<RWQuestion />, document.getElementById('question_detail'));
                  break;
                  //7
              case 'LA':
                  ins = ReactDOM.render(<LAQuestion />, document.getElementById('question_detail'));
                  break;
                  //8
              case 'WR':
                  ins = ReactDOM.render(<WRQuestion />, document.getElementById('question_detail'));
                  break;
              case 'RA':
                  ins = ReactDOM.render(<RAQuestion />, document.getElementById('question_detail'));
                  break;
              case 'FF':
                  ins = ReactDOM.render(<FGQuestion />, document.getElementById('question_detail'));
                  break;
                  
              default:
                  break;
          }
          window.initEditor('CONTENTQUESTION');
      },
    //sử dụng trong trường hợp thêm mới nên chưa có questioncode đâu
ClearInput: function (obj) {
              var questiontypecodeview = obj.QUESTIONTYPECODEVIEW;
              this.refs[this.props.id + "_QUESTIONTYPECODEVIEW"].value = obj.QUESTIONTYPECODEVIEW;
              this.refs[this.props.id + "_QUESTIONGROUPCODE"].value = obj.QUESTIONGROUPCODE;
              this.refs[this.props.id + "_QUESTIONGROUPCONTENT"].innerHTML = obj.QUESTIONGROUPCONTENT;
              this.refs[this.props.id + "_QUESTIONTYPECODE"].value = obj.QUESTIONTYPECODE;
              this.refs[this.props.id + "_QUESTIONCODE"].value = obj.QUESTIONCODE;
              //debugger
              this.initChild(questiontypecodeview, "","new");
              this.ClearThing();//clear
          },
        /**
        *thực tế xóa trên form
        */
ClearThing: function () {
              this.refs[this.props.id + "_CODE"].value = "";
              //this.refs[this.props.id + "_CODEVIEW"].value = "";
              this.refs[this.props.id + "_NAME"].value = "";
              this.refs[this.props.id + "_LOCK"].checked = true;
              this.refs[this.props.id + "_ORD"].value = "";
              this.refs[this.props.id + "_MARK"].value = "";
              var ident = this.props.id + '_CONTENT';
              if (!!this.props.id) {
                  window.tinymce.get(ident).setContent("");
              }
              //Set status
              this.refs[this.props.id + "_status"].innerHTML = 'new';
          },
        /**
        *Hàm gán dữ liệu để sửa, được gọi bởi component cha của component này
        *para obj: thông tin về dữ liệu được thay đổi
        */
SetInput: function (obj) {
              console.log('Set to obj:', obj);
              var questiontypecodeview = obj.QUESTIONTYPECODEVIEW;
              this.refs[this.props.id + "_QUESTIONTYPECODEVIEW"].value = obj.QUESTIONTYPECODEVIEW;
              this.refs[this.props.id + "_QUESTIONGROUPCODE"].value = obj.QUESTIONGROUPCODE;
              this.refs[this.props.id + "_QUESTIONTYPECODE"].value = obj.QUESTIONTYPECODE;
              this.refs[this.props.id + "_QUESTIONGROUPCONTENT"].innerHTML = obj.QUESTIONGROUPCONTENT;
              this.refs[this.props.id + "_QUESTIONCODE"].value = obj.QUESTIONCODE;
            //  debugger
              this.initChild(questiontypecodeview, obj.CODE,"edit");

              //Sử dụng cú pháp của react để thực hiện tương tác dữ liệu
              this.refs[this.props.id + "_CODE"].value = obj.CODE;
              this.refs[this.props.id + "_NAME"].value = obj.NAME;
              this.refs[this.props.id + "_LOCK"].checked = (obj.LOCK === 0);
              this.refs[this.props.id + "_ORD"].value = obj.ORD;
              this.refs[this.props.id + "_MARK"].value = obj.MARK;
                 var ident = this.props.id + '_CONTENT';
              if (!!this.props.id) {
                  $('textarea.CONTENTQUESTION').html(obj.CONTENT);
                  window.tinymce.get(ident).setContent($('textarea.CONTENTQUESTION').val());
              }
                  //Set status
              this.refs[this.props.id + "_status"].innerHTML = 'edit';
          },
    /**
*Kiểm tra để gọi load lại cho dữ liệu từ component cha (danh sách)
*para obj: là mã của bản ghi mới được thao tác
*/
          ReloadData: function (obj) {
              if (isMiss(this.props.ReloadData)) {
                  //console.log('Call load data');
                  return false;
              }
              else {
                  //console.log('Call load data!!!!!!!!!!!!!');
                  this.props.ReloadData(obj);
                  return true;
              }
          },
          SaveClick:function() {
              this.SaveData(true);
          },
          SaveContinueClick:function() {
              this.SaveData(false);
          },
          SaveData: function (isClose) {
              if (!!this.refs[this.props.id + "_NAME"].value) {

                  var content = $('textarea.CONTENTQUESTION').html();
                  var data = {
                      CODE: this.refs[this.props.id + "_CODE"].value,
                      QUESTIONGROUPCODE: this.refs[this.props.id + "_QUESTIONGROUPCODE"].value,
                      NAME: this.refs[this.props.id + "_NAME"].value,
                      LOCK: (this.refs[this.props.id + "_LOCK"].checked ? 0 : 1),
                      ORD: this.refs[this.props.id + "_ORD"].value,
                      MARK: this.refs[this.props.id + "_MARK"].value,
                      typeQuestion: this.refs[this.props.id + "_QUESTIONTYPECODEVIEW"].value,
                      CONTENT: content
                  };
                  $.ajax({
                      url: "/Question/UpdateQuestion",
                      dataType: 'json',
                      type: 'post',
                      data: data,
                      success: function(data) {
                          if (data.ret >= 0) {
                              log.show("Ghi thành công!", true);
                              if (isClose) {
                                  this.Hide();
                              } else {
                                  this.ClearInput({});
                              }
                              this.ReloadData();
                          } else {
                              log.show("Ghi lỗi!", false);
                          }
                      }.bind(this),
                      error: function(xhr, status, err) {
                          console.log(err.toString());
                      }
                  });
              } else {
                  log.show("Failed", false);
              }
          },
          componentDidMount: function() {
          }, 
      render: function () {
          var title = '';
          var id = this.props.id;
          return (
          <div className="modal fade" id={id} ref={id} role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div className="modal-dialog">
                      <div className="modal-content">
                        <div className="modal-header">
                          <button type="button" className="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span className="sr-only">Close</span></button>
                          <h4 className="modal-title" id="myModalLabel" style={{ fontFamily: 'serif'}}>Thêm câu hỏi mới dạng {title}</h4>
                        </div>
                        <div className="modal-body">
                            <form className="form-horizontal" id='myform' role="form" style={{ fontFamily: 'serif'}}>
                                <input type="text" ref={id + '_CODE'} id={id + '_CODE'} className="form-control col-md-10 hidden" />
                                 <div className="form-group">
                                    <label className="col-sm-2 control-label">Câu hỏi</label>
                                    <div className="col-sm-10">
                                          <input type="hidden" className="form-control hidden" ref={id + '_QUESTIONGROUPCODE'} id={id + '_QUESTIONGROUPCDOE'} />
                                          <input type="hidden" className="form-control hidden" ref={id + '_QUESTIONTYPECODE' } id={id + '_QUESTIONTYPECODE' } />
                                          <input type="hidden" className="form-control hidden" ref={id + '_QUESTIONTYPECODEVIEW'} id={id + '_QUESTIONTYPECODEVIEW' } />
                                          <input type="hidden" className="form-control hidden" ref={id + '_QUESTIONCODE' } id={id + '_QUESTIONCODE' } />
                                             <div type="text" data-spy="scroll" className="form-control fitContentHeight"
                                                ref={id + '_QUESTIONGROUPCONTENT'} id={id + '_QUESTIONGROUPCONTENT'}>
                                            </div>
                                    </div>
                                   </div>
                                <hr/>
                                 <div className="form-group">
                                    <label className="col-sm-2 control-label">Mô tả gợi nhớ chi tiết </label>
                                    <div className="col-sm-10">
                                        <input type="text" className="form-control" ref={id + '_NAME'} id={id + '_NAME'} />
                                    </div>
                                </div>
                                 <div className="form-group">
                                    <label className="col-sm-2 control-label">Hiển thị</label>
                                    <div className="col-sm-10">
                                        <input type="checkbox" ref={id + '_LOCK'} id={id + '_LOCK'} />
                                    </div>
                                 </div>
                                 <div className="form-group">
                                    <label className="col-sm-2 control-label">Thứ tự hiển thị</label>
                                    <div className="col-sm-10">
                                        <input type="number" className="form-control" ref={id + '_ORD'} id={id + '_ORD'} />
                                    </div>
                                  </div>
                                 <div className="form-group">
                                    <label className="col-sm-2 control-label">Điểm</label>
                                    <div className="col-sm-10">
                                      <input type="number" className="form-control" ref={id + '_MARK'} id={id + '_MARK'}
                                             min='0.1' max='10'maxLength="2"
                                              placeholder="Only float with comma !" step="0.01" />
                                    </div>
                                   </div>                                
                                 <div className="form-group" id="contentques">
                                    <label className="col-sm-2 control-label">Nội dung chi tiết</label>
                                    <div className="col-sm-10">
                                        <textarea className="CONTENTQUESTION form-control" ref={id + '_CONTENT'} id={id + '_CONTENT'}></textarea>
                                    </div>
                                </div>
                                 <div id='question_detail'>
                                    {/**
                                      * answer
                                      */}
                                 </div>                              
                            </form>
                        </div>
             <div className="box-footer modal-footer">{/*Phần dành để hiển thị trạng thái - không thay đổi*/}
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
