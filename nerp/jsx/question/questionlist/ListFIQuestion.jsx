﻿  var ListFIQuestion = React.createClass({
      getInitialState: function () {
          return {
              tab: null,
              page: 1,
              listAnswer: [],
              check: -1
          };
      },
      componentWillMount: function () {
          component.add('FIQuestion', this);
      },
      loadData: function () {
          var ret;
          var parent = component.get('listQuestion');
          window.NProgress.start();
          var question;
          var questioncode = "";
          var questiongroupcode = "";

          //nếu mà rowselect  của cha mà chính thằng này
          //thì ta sẽ đẩy nó vào lấy danh sách kết quả theo rowselect của nó

          if (!!parent.state.rowSelect) {
              $('#hidQUESTIONCODE').val('');
              question = parent.state.rowSelect[0];
              questioncode = question.CODE;
              questiongroupcode = question.QUESTIONGROUPCODE;
              var income = JSON.stringify(parent.state.rowSelect[0]);
              $('#hidQUESTIONCODE').val(income);
          }
          var pageSize = $('#pageSizeAnswer').val();
          if (isNaN(pageSize)) {
              pageSize = 0;
          }
          let page = this.state.page;
          $.ajax({
              url: "/Question/getListAnswer",
              dataType: 'json',
              data: {
                  questioncode: questioncode,
                  questiongroupcode: questiongroupcode,
                  page: page,
                  pageSize: pageSize
              },
              success: function (data) {
                  console.log(this.state.check);
                  if (data.quantiti === 0) {
                      this.setState({ check: -1 });
                  }
                  console.log(this.state.check);
                  this.setState({ listAnswer: data.data });
                  setTimeout(function () {
                      this.state.listAnswer.map((value) => {
                          if (value.TRUEANSWER === 1) {
                              this.loadCheck(value.CODE);
                          }
                      });
                  }.bind(this), 100);
                  $('#hidQUANTITIES').val('');
                  $('#hidQUANTITIES').val(data.quantiti);
                  $('#hidANSWERCODE').val('');
                  $('#hidANSWERCODE').val(data.answer);
                  ret = data.data;
              }.bind(this),
              error: function (xhr, status, err) {
                  console.log(err.toString());
              }
          });
          window.NProgress.done();
          return ret;
      },
      //check the change of answer in MC question
      onCheckChange: function () {
          var that = this;
          var parent = component.get('popupanswerquestion');
          var hideanswer = $('#hidANSWERCODE').val();
          if ($('#CODEQUESTION') !== 0) {
              if (this.state.check !== hideanswer) {
                  //  confirm.show(null, this.handDelete, null);
                  $("#NewModalQuestion").modal('hide');
                  bootbox.confirm({
                      message: "Do you want to save the change ?",
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
                              that.onSave();
                          }
                          else {
                              log.show("Nothing changed !", false);
                          }
                      }
                  });
              }
              else {
                  parent.handleSubmit();
              }
          }
          else {
              parent.handleSubmit();
          }
      },
      onSave: function () {
          var node = new Object();
          node.CODE = $('#CODEQUESTION').val();
          node.CODEVIEW = $('#CODEVIEWQUESTION').val();
          node.NAME = $('#NAMEQUESTION').val();
          node.LOCK = $('#LOCKQUESTION').prop("checked") ? 1 : 0;
          node.ORD = $('#ORDQUESTION').val();
          node.MARK = $('#MARKQUESTION').val();
          node.ANSWERCODE = this.state.check;
          node.QUESTIONGROUPCODE = $('#QUESTIONGROUPCODE').val();
          node.CONTENT = $('#FICONTENTQUESTION').val();

          $.ajax({
              url: "/Question/UpdateQuestion",
              dataType: 'json',
              traditional: true,
              data: {
                  QUESTIONGROUPCODE: node.QUESTIONGROUPCODE,
                  CODE: node.CODE,
                  CODEVIEW: node.CODEVIEW,
                  NAME: node.NAME,
                  LOCK: node.LOCK,
                  ORD: node.ORD,
                  MARK: node.MARK,
                  ANSWERCODE: node.ANSWERCODE,
                  CONTENT: node.CONTENT,
                  typeQuestion: "FI"
              },
              success: function (data) {

                  if (data.ret >= 0) {
                      var list = component.get('listQuestion');
                      list.refreshRowData();
                      log.show("Ghi thành công!", true);
                      $('#ANSWERCODE').val('');
                      $('#ANSWERCODE').val(data.nameANSWER);

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

      loadCheck: function (id) {
          this.setState({ check: id });
      },

      render: function () {
          var listRow = [];
          var that = this;
          var index = 0;

          this.state.listAnswer.forEach(function (rowitem) {
              var content = $('<div />').html(rowitem.CONTENT).text();
              listRow.push(

              <tr key={index}>
                     <td style={{'textAlign':'center'}}>{index}</td>
                         <td style={{'textAlign':'center'}}>
                         <input type="checkbox" id={rowitem.CODE}
                                checked={ that.state.check === rowitem.CODE}
                                className={index}
                                onClick={that.loadCheck.bind(that, rowitem.CODE)} />
                         </td>
                            <td style={{'textAlign':'center'}}>{rowitem.NAME}</td>
                            <td style={{'textAlign':'center'}}>
                                             <span style={{ 'textAlign': 'left' }} key={'error_' + index} dangerouslySetInnerHTML={{ __html: content }}></span>
                            </td>
              </tr>);
                              index++;
                              });
          return (
                        <div>
                              <div className="form-group" id="ficontentques">
                                    <label className="col-sm-2 control-label">Câu hỏi FI số </label>
                                    <div className="col-sm-10">
                                        <input style={{ 'overflowY': 'scroll', 'fontFamily': 'serif',fontWeight:'bold',textAlign:'center',height:'30px' }} className="form-control" id='FICONTENTQUESTION' />
                                    </div>
                              </div>
                                   <div className="form-group">
                            <label className="col-sm-2 control-label">Danh sách đáp án</label>
                            <div className="col-sm-10">

                                    <table id="example2" className="table table-bordered table-hover">
                                  <thead>
                            <tr>

                            <th style={{'textAlign':'center'}}>STT</th>
                                <th>Đúng</th>
                            <th style={{'textAlign':'center'}}>Đáp án</th>
                            <th style={{'textAlign':'center'}}>Câu trả lời</th>
                            </tr>
                                  </thead>
                                          <tbody>{listRow}</tbody>
                                    </table>
                            </div>
                                   </div>
                        </div>

            );
      }
  });