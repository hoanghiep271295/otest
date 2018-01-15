﻿var ExamResult = React.createClass({
    getInitialState: function () {
        return {
            listGroupQuesion: [],// list groupcode
            listQuestion: [],/// list question
            listAnswer: [],///list answer follow question
            objHalltudent: null, ///object Hall student
            objExamForm: null, /// Objet Exam Form
            listExamDetail: [], ///list ExamFromdetail
            listAnswerStudent: [], ///list answer of student get from server
            numberQuestion: 0
        }
    },
    componentDidMount: function ()
    {
        this.loadData();
    },
    loadData: function () {
        var defaultvalue = window.getDefaultFromServer();
        var markcode = defaultvalue.markcode;
        var examtimecode = defaultvalue.examtimecode;
        $.ajax({
            url: "/ExamResult/ShowExamResult",
            dataType: 'json',
            data: {
                markcode: markcode,
                examtimecode: examtimecode
            },
            success: function (data) {
                if (data.ret >= 0) {
                    this.setState({
                        listGroupQuesion: data.liQuestiongroup,
                        listQuestion: data.li_question,
                        listAnswer: data.li_answer,
                        objHalltudent: data.ObjexamHallstudent,
                        objExamForm: data.ObjexamForm,
                        listExamDetail: data.liExamformDetail,
                        listAnswerStudent : data.li_examresult,
                        numberQuestion: data.numberQuestion
                    });
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }
        });
    },
    render: function () {
        var listQgroup = [];
        var index = 1;
        this.state.listGroupQuesion.map((rowitem) => {
            console.log("cotentType", rowitem._QUESTIONTYPECODE.CODEVIEW);
            switch (rowitem._QUESTIONTYPECODE.CODEVIEW) {
                //1
   case'CO':
                    listQgroup.push(<QuestionGroupCO
                                        key={index}
                                        number={index}
                                        id={rowitem.CODE}
                                        objQuestionGroup={rowitem}
                                        dataQuestion={this.state.listQuestion}
                                        dataAnswer={this.state.listAnswer}
                                        listAnswerStudent= {this.state.listAnswerStudent}
                                        type={"CO"} />);
                          index++;
                          break;
                        //writing
                        //2
     case 'WR':
                 listQgroup.push(<QuestionGroupWR    
                                    key={index}
                                    number={index}
                                    id={rowitem.CODE}
                                    objQuestionGroup={rowitem}
                                    dataQuestion={this.state.listQuestion}
                                    dataAnswer={this.state.listAnswer}
                                    listAnswerStudent= {this.state.listAnswerStudent}
                                    type={"WR"}  />);
                  index++;
                  break;
                  //3
                  //câu hỏi một nhiều chỉ dành cho một câu hỏi cho một nhóm;
                  //Câu hỏi ỏ nhóm, tự động sinh ra một bản ghi câu hỏi giả để lien kết, sau đó có các đáp án. 
     case 'MS':
                 listQgroup.push(<QuestionGroupMS 
                                    key={index}
                                    number={index}
                                    id={rowitem.CODE}
                                    objQuestionGroup={rowitem}
                                    dataQuestion={this.state.listQuestion}
                                    dataAnswer={this.state.listAnswer}
                                    listAnswerStudent= {this.state.listAnswerStudent}
                                    type={"MS"} />);
                    index++;
                    break;
                    //: Viết lại câu; (câu hỏi chính ở nhóm), sau đó câu hỏi chi tiết chính là các từ;
                    //Một câu hỏi có thể có nhiều đáp án đúng 
                    //(để cho phép so sánh chỉ cần đúng một trong các đáp án đó là tính điểm)
                    //4
     case 'RW':
                listQgroup.push(<QuestionGroupRW
                                    key={index}
                                    number={index}
                                    id={rowitem.CODE}
                                    objQuestionGroup={rowitem}
                                    dataQuestion={this.state.listQuestion}
                                    dataAnswer={this.state.listAnswer}
                                    listAnswerStudent= {this.state.listAnswerStudent}
                                    type={"RW"} />);
                    index++;
                    break;
                    //5
                    //dạng kéo thả vào trong đoạn văn
     case 'FI':
                    listQgroup.push(<QuestionGroupFI
                                      key={index}
                                      number={index}
                                      id={rowitem.CODE}
                                      objQuestionGroup={rowitem}
                                      dataQuestion={this.state.listQuestion}
                                      dataAnswer={this.state.listAnswer}
                                      listAnswerStudent= {this.state.listAnswerStudent}
                                      type={"FI"}  />);
                    index++;
                    break;
                    //dạng điền từ vào trong ô trống
                    //6
     case 'FG':
                listQgroup.push(<QuestionGroupFG
                                         key={index}
                                         number={index}
                                         id={rowitem.CODE}
                                         objQuestionGroup={rowitem}
                                         dataQuestion={this.state.listQuestion}
                                         dataAnswer={this.state.listAnswer}
                                         listAnswerStudent= {this.state.listAnswerStudent}
                                         type={"FG"}  />);
                    index++;
                    break;
                    //7
     case 'FF':
                listQgroup.push(<QuestionGroupFF
                                        key={index}
                                        number={index}
                                        id={rowitem.CODE}
                                        objQuestionGroup={rowitem}
                                        dataQuestion={this.state.listQuestion}
                                        dataAnswer={this.state.listAnswer}
                                        listAnswerStudent= {this.state.listAnswerStudent}
                                        type={"FF"} />);
                    index++;
                    break;
                    //8
                    // dạng kéo thả vào 
      case 'PA':
                listQgroup.push(<QuestionGroupPA
                                      key={index}
                                      number={index}
                                      id={rowitem.CODE}
                                      objQuestionGroup={rowitem}
                                      dataQuestion={this.state.listQuestion}
                                      dataAnswer={this.state.listAnswer}
                                      listAnswerStudent= {this.state.listAnswerStudent}
                                      type={"PA"}  />);
                    index++;
                    break;
                    //9
       case 'LA':
                    listQgroup.push(<QuestionGroupLA
                                       key={index}
                                       number={index}
                                       id={rowitem.CODE}
                                       objQuestionGroup={rowitem}
                                       dataQuestion={this.state.listQuestion}
                                       dataAnswer={this.state.listAnswer}
                                       listAnswerStudent= {this.state.listAnswerStudent}
                                       type={"LA"}  />);
                   index++;
                    break;
//10
       case 'MC':
                    listQgroup.push(<QuestionGroupMC 
                                        key={index}
                                        number={index}
                                        id={rowitem.CODE}
                                        objQuestionGroup={rowitem}
                                        dataQuestion={this.state.listQuestion}
                                        dataAnswer={this.state.listAnswer}
                                        listAnswerStudent= {this.state.listAnswerStudent}
                                        type={"MC"}  />);
                   index++;
                   break;
                    //11
     case 'RA':
                    listQgroup.push(<QuestionGroupRA
                                        key={index}
                                        number={index}
                                        id={rowitem.CODE}
                                        objQuestionGroup={rowitem}
                                        dataQuestion={this.state.listQuestion}
                                        dataAnswer={this.state.listAnswer}
                                        listAnswerStudent= {this.state.listAnswerStudent}
                                        type={"RA"}  />);
                         index++;
                         break;
                                                }
         });
        return (
                <div className="examform" >
                        {listQgroup}
                  </div>
            );}});
ReactDOM.render(<ExamResult />, document.getElementById('container'));