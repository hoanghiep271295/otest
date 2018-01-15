﻿  var COQuestion = React.createClass({
      getInitialState:function() {
          return {
              answercode: "",
              listCheck: [],
              first: true,
              thecontent: '',
              questioncode: null
          }
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
      ClearInput: function (obj) {
          this.refs[this.props.id + "_QUESTIONTYPECODEVIEW"].value = obj.QUESTIONTYPECODEVIEW;
          this.refs[this.props.id + "_QUESTIONGROUPCODE"].value = obj.QUESTIONGROUPCODE;
          this.refs[this.props.id + "_QUESTIONGROUPCONTENT"].innerHTML = obj.QUESTIONGROUPCONTENT;
          this.refs[this.props.id + "_QUESTIONTYPECODE"].value = obj.QUESTIONTYPECODE;
          this.refs[this.props.id + "_QUESTIONCODE"].value = obj.QUESTIONCODE;
          this.ClearThing();//clear
      },
      ClearThing: function () {
          this.refs[this.props.id + "_CODE"].value = "";
          this.refs[this.props.id + "_NAME"].value = "";
          this.refs[this.props.id + "_LOCK"].checked = true;
          this.refs[this.props.id + "_ORD"].value = "";
          this.refs[this.props.id + "_MARK"].value = "";
          this.setEditorContent('');
          //Set status
          this.refs[this.props.id + "_status"].innerHTML = 'new';
          this.setState({ questioncode: null });
          var questiongroupcode = this.props.parent.getKeyValue('questiongroupcode');
          this.refs[questiongroupcode + '_' + 0].checked = true;
          
      },
      /**
      *Hàm gán dữ liệu để sửa, được gọi bởi component cha của component này
      *para obj: thông tin về dữ liệu được thay đổi
      */
      SetInput: function (obj) {
          console.log('Set to obj:', obj);
          this.refs[this.props.id + "_QUESTIONTYPECODEVIEW"].value = obj.QUESTIONTYPECODEVIEW;
          this.refs[this.props.id + "_QUESTIONGROUPCODE"].value = obj.QUESTIONGROUPCODE;
          this.refs[this.props.id + "_QUESTIONTYPECODE"].value = obj.QUESTIONTYPECODE;
          this.refs[this.props.id + "_QUESTIONGROUPCONTENT"].innerHTML = obj.QUESTIONGROUPCONTENT;
          this.refs[this.props.id + "_QUESTIONCODE"].value = obj.QUESTIONCODE;
          //Sử dụng cú pháp của react để thực hiện tương tác dữ liệu
          this.refs[this.props.id + "_CODE"].value = obj.CODE;
          this.refs[this.props.id + "_NAME"].value = obj.NAME;
          this.refs[this.props.id + "_LOCK"].checked = (obj.LOCK === 0);
          this.refs[this.props.id + "_ORD"].value = obj.ORD;
          this.refs[this.props.id + "_MARK"].value = obj.MARK;
          this.setEditorContent(obj.CONTENT);
          //Set status
          this.refs[this.props.id + "_status"].innerHTML = 'edit';

          this.loadData(obj.CODE);
          this.setState({ questioncode: obj.CODE });
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
      SaveClick: function () {
          this.SaveData(true);
      },
      SaveContinueClick: function () {
          this.SaveData(false);
      },
      SaveData: function (isClose) {
          if (!!this.refs[this.props.id + "_CODE"].value) {
              var content = $('textarea.CONTENTQUESTION').html();
              content = content.replace(new RegExp('src="ContentQuestion', 'g'), 'src="/ContentQuestion');
              content = content.replace(new RegExp('src="../../ContentQuestion', 'g'), 'src="/ContentQuestion');
              var saveindex = 0;
              var questiongroupcode = this.props.parent.getKeyValue('questiongroupcode');
              for (var i = 0; i < 3; i++) {
                  if (this.refs[questiongroupcode + "_" + i].checked) {
                      saveindex = i;
                      break;
                  }
              }
              var data = {
                  CODE: this.refs[this.props.id + "_CODE"].value,
                  QUESTIONGROUPCODE: this.refs[this.props.id + "_QUESTIONGROUPCODE"].value,
                  NAME: this.refs[this.props.id + "_NAME"].value,
                  LOCK: (this.refs[this.props.id + "_LOCK"].checked ? 0 : 1),
                  ORD: this.refs[this.props.id + "_ORD"].value,
                  MARK: this.refs[this.props.id + "_MARK"].value,
                  typeQuestion: this.refs[this.props.id + "_QUESTIONTYPECODEVIEW"].value,
                  CONTENT: content,
                  ANSWERCODE: saveindex
              };
              window.tinymce.get(this.props.id + '_CONTENT').setContent("");
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
              log.show("Phải nhập mã",false);
          }
          
      },
      loadData: function (questionCode) {
          var that = this;
          //var questionCode = this.props.questioncode;
          console.log(questionCode);
          $.ajax({
              url: '/Question/GetAnswerQuestionCo',
              data: { questionCode: questionCode },
              type: 'post',
              dataType: "json",
              success: function(data) {
                  if (data.ret > 0) {
                      var questiongroupcode = that.props.parent.getKeyValue('questiongroupcode');
                      var index = 0;
                      data.listAnswerObjs.forEach(function(rowitem) {
                          if (rowitem.TRUEANSWER === 1) {
                              that.refs[questiongroupcode + '_' + index].checked = true;
                          }
                              index++;
                      });
                      log.show("OK", true);
                  } else {
                      log.show("False", false);
                  }
              }
          });
      },
      componentWillMount: function () {
      },
      componentDidMount: function () {
          var questiongroupcode = this.props.parent.getKeyValue('questiongroupcode');
          $('input[name="' + questiongroupcode + '"]').prop('checked', false);
          console.log("new");
          var id = this.props.id;
          window.initEditorByID(id + '_CONTENT', this.finishInit);
      },
      finishInit: function () {
          this.setState({ first: false });
          var id = this.props.id;
          $('#' + id + '_CONTENT').html(this.state.thecontent);
          window.tinymce.get(id + '_CONTENT').setContent($('#' + id + '_CONTENT').val());
      },
      setEditorContent: function (value) {
          var id = this.props.id;
          if (this.state.first) {
              this.setState({ thecontent: value });
          } else {
              $('#' + id + '_CONTENT').html(value);
              window.tinymce.get(id + '_CONTENT').setContent($('#' + id + '_CONTENT').val());
          }
      },
      checkChange: function (e) {
          var mctl = e.target.id;
          this.setState({ answercode: mctl });
      },
     
      render: function () {
          var questiongroupcode = this.props.parent.getKeyValue('questiongroupcode');
          var listAnswer = [];
          var index = 0;
          var answerList = ["TRUE", "FALSE", "NOT GIVEN"];
          var that = this;
          answerList.map(function(rowitem) {
              //add new question
              listAnswer.push(
                  <div className="col-sm-3 text-center" key={index}
                                   name={questiongroupcode}>
                            <input id={questiongroupcode + '_' + index} ref={questiongroupcode + '_' + index}
                          type="radio"
                          name={questiongroupcode + "CO"}
                          onClick={that.checkChange}/>
                             &nbsp;&nbsp;
                          <label htmlFor={questiongroupcode + '_' + index }>
                        {rowitem}
                        </label>
                        </div>
                        );
                          index++;
                          });
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
     <div>
                <input className="hidden" value={this.state.answercode} id={'ANSWERCODE_CO'} />
                          <div className="form-group">
                            <label className="col-sm-2 control-label">Danh sách đáp án</label>
                        <div className="row">
                            {listAnswer}
                        </div>
                          </div>
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