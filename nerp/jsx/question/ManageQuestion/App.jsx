﻿var App = React.createClass({
    getInitialState: function () {
        return {
            listGroupQuesion: null,
            listQuestion: [],
            listAnswer: [],
            objHalltudent: null,
            objExamForm: null,
            listExamDetail: [],
            listStudentAnswerFinish: [],
            listStudentAnswer: [],
            numberQuestion: 0
        }
    },
    componentWillMount: function () {
    },
    componentDidMount: function () {
        this.loadData();
        window.getAppAdmin(this);
    },
    onload: function () {
        window.setTimeout(console.log("a"), 5000);
    },
    loadData: function () {
        var defaultvalue = window.getDefaultFromServer();
        var questiongroupcode = defaultvalue.code;

        $.ajax({
            url: "/Question/GetById",
            dataType: 'json',
            data: {
                questiongroupcode: questiongroupcode
            },
            success: function (data) {
                if (data.ret >= 0) {
                    this.setState({
                        listGroupQuesion: data.liQuestiongroup,
                        listQuestion: data.li_question,
                        listAnswer: data.li_answer,
                        numberQuestion: data.numberQuestion
                    });
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }
        });
    },

    /**
     * @param {string} mach -  Questioncode
     * @param {string} mctl - sometimes here is answercode, sometimes here is answer text
     * @param {string} thetype - Type of answer : MC,PA,LA,FI,FG,RW,WR or default is none
     * @returns {} push answer into this state
     */
    onCheck(mach, mctl, thetype) {
        //    debugger
        var obj = new Object();
        obj.MaCauHoi = mach;
        obj.MaCauTL = mctl;
        obj.TYPE = thetype;
        // var ques = {MaCauHoi:mach,MaCauTL:mctl,TYPE:thetype};
        //check the existence of this obj in db
        var check = this.containsObject(obj, this.state.listStudentAnswer);
        //if update we will update
        if (check) {
            this.updateObject(obj, this.state.listStudentAnswer);
            //     this.onSubmit();
        } //add new
        else {
            this.state.listStudentAnswer.push(obj);
            //console.log(this.state.listStudentAnswer);
            //     this.onSubmit();
        }
    },
    /**
     * check extistence of an object
     * @param {object} obj
     * @param {list<>} list
     * @returns {boolean}
     */
    containsObject: function (obj, list) {
        for (var i = 0; i < list.length; i++) {
            if (list[i].MaCauHoi === obj.MaCauHoi) {
                return true;//exist
            }
        }
        return false;//none exist
    },
    /**
     * check an object in arr and update it
     * @param {Object} obj
     * @param {Arr<>} arr
     * @returns {}
     */
    updateObject: function (obj, arr) {
        for (var i in arr) {
            if (arr.hasOwnProperty(i)) {
                if (arr[i].MaCauHoi === obj.MaCauHoi) {
                    arr[i].MaCauTL = obj.MaCauTL;
                    arr[i].TYPE = obj.TYPE;
                    break; //Stop this loop, we found it!
                }
            }
        }
    },
    render: function () {
        var listQgroup = [];
        var index = 1;
        var rowitem = this.state.listGroupQuesion;
        if (!!rowitem) {
            switch (rowitem._QUESTIONTYPECODE.CODEVIEW) {
                //multichoice
                //một câu hỏi lớn và danh sách các câu hỏi nhỏ, trong các câu hỏi nhỏ thì sẽ có các câu trả lời
                case 'MC':
                    listQgroup.push(<QuestionTypeMC key={index}
                                                    number={index}
                                                    id={rowitem.CODE}
                                                    objQuestionGroup={rowitem}
                                                    dataQuestion={this.state.listQuestion}
                                                    dataAnswer={this.state.listAnswer}
                                                    type={"MC"}
                                                    listAnswer={this.state.listStudentAnswer} />);
                    index++;
                    break;
                    // Single choice
                    //dạng này không khác dạng multichoice cho lắm, chỉ hơi khác là chỉ gồm có 1 câu hỏi lớn và trong đó là các câu trả lời luôn
                    //chứ không cần phải nhập câu hỏi nữa, khi nhập liệu thì dạng này đã tự động sinh ra 1 bản ghi là 1 question rồi
                    //2
                case 'MS':
                    listQgroup.push(<QuestionTypeMS key={index}
                                                    number={index}
                                                    id={rowitem.CODE}
                                                    objQuestionGroup={rowitem}
                                                    dataQuestion={this.state.listQuestion}
                                                    dataAnswer={this.state.listAnswer}
                                                    type={"MS"}
                                                    listAnswer={this.state.listStudentAnswer} />);
                    index++;
                    break;
                    //Co; Trường hợp câu hỏi tổng hợp, thực hiện giống như câu hỏi một nhiều
                    //3
                case 'CO':
                    listQgroup.push(<QuestionTypeCO key={index}
                                                    number={index}
                                                    id={rowitem.CODE}
                                                    objQuestionGroup={rowitem}
                                                    dataQuestion={this.state.listQuestion}
                                                    dataAnswer={this.state.listAnswer}
                                                    type={"CO"}
                                                    listAnswer={this.state.listStudentAnswer} />);
                    index++;
                    break;
                    //Pa : Dạng câu hỏi kéo thả theo group
                    //4
                case 'PA':
                    listQgroup.push(<QuestionTypePA key={index}
                                                    number={index}
                                                    id={rowitem.CODE}
                                                    objQuestionGroup={rowitem}
                                                    dataQuestion={this.state.listQuestion}
                                                    dataAnswer={this.state.listAnswer}
                                                    type={"PA"}
                                                    listAnswer={this.state.listStudentAnswer} />);
                    index++;
                    break;

                    //recording
                    //5
                case 'LA':
                    listQgroup.push(<QuestionTypeLA key={index}
                                                    number={index}
                                                    id={rowitem.CODE}
                                                    objQuestionGroup={rowitem}
                                                    dataQuestion={this.state.listQuestion}
                                                    type={"LA"}
                                                    listAnswer={this.state.listStudentAnswer} />);
                    index++;
                    break;
                    //writing
                    //6
                case 'WR':
                    listQgroup.push(<QuestionTypeWR key={index}
                                                    number={index}
                                                    id={rowitem.CODE}
                                                    objQuestionGroup={rowitem}
                                                    dataQuestion={this.state.listQuestion}
                                                    type={"WR"} />);
                    index++;
                    break;
                    // FG: Câu hỏi điền vào đoạn trống tự gõ từ
                    //7
                case 'FG':
                    listQgroup.push(<QuestionTypeFG key={index}
                                                    id={rowitem.CODE}
                                                    number={index}
                                                    objQuestionGroup={rowitem}
                                                    type={"FG"} />);
                    index++;
                    break;
                    //
                    //8
                case 'FF':
                    listQgroup.push(<QuestionTypeFF key={index}
                                                    number={index}
                                                    id={rowitem.CODE}
                                                    dataAnswer={this.state.listAnswer}
                                                    objQuestionGroup={rowitem}
                                                    type={"FF"} />);
                    index++;
                    break;
                    //9
                case 'FI':
                    listQgroup.push(<QuestionTypeFI key={index}
                                                    number={index}
                                                    id={rowitem.CODE}
                                                    dataAnswer={this.state.listAnswer}
                                                    objQuestionGroup={rowitem}
                                                    type={"FI"} />);
                    index++;
                    break;
                    // RW: rewrite
                    //10
                case 'RW':
                    listQgroup.push(<QuestionTypeRW key={index}
                                                    number={index}
                                                    id={rowitem.CODE}
                                                    objQuestionGroup={rowitem}
                                                    dataQuestion={this.state.listQuestion}
                                                    dataAnswer={this.state.listAnswer}
                                                    type={"RW"} />);
                    index++;
                    break;
                    //11
                case 'RA':
                    listQgroup.push(<QuestionTypeRA key={index}
                                                    number={index}
                                                    id={rowitem.CODE}
                                                    objQuestionGroup={rowitem}
                                                    dataQuestion={this.state.listQuestion}
                                                    dataAnswer={this.state.listAnswer}
                                                    type={"RA"} />);
                    index++;
                    break;
            }
        }
        return (
        <div className="examform">
            {listQgroup}
                <div style={{margin:'10px',width:'100%', paddingLeft:'40px'}}>

                </div>
        </div>
            );
    }
});


ReactDOM.render(<App />, document.getElementById('container'));

var global = "";