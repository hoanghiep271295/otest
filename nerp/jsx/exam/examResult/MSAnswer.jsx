﻿var QuestionGroupMS = React.createClass({
    componentDidMount: function () {
        document.getElementById(this.props.id + '_questiontypeMS').innerHTML =
            this.props.objQuestionGroup.CONTENT;
    },

    //Vì các radio button được gom nhóm bằng name, mà trong đây ta quy định name = quesiontioncode
    //vậy khi 1 radio button được chọn là câu trả lời của sinh viên thì các radio button còn lại sẽ bị disable
    // Nhưng là vì có 2 trường hợp là câu chọn của sinh viên là đúng
    //câu chọn của sinh viên là sai nên cần disable trừ trường hợp đã được chọn
    //trong  1 câu hỏi không thể cùng xảy ra 2 trường hợp được check nên mặc định là disable hết
    ///check answer to show out
    //item here is answer from list answer from table answer
    //arr here is list answer of student from table examresult
    CheckItem: function (item, arr, questioncode) {
        for (var i = 0; i < arr.length; i++) {
            if (this.CheckItemInArray(questioncode, arr)) {
                //kiểm tra xem xem câu trả lời của sinh viên và câu trả lời trong danh sách câu trả lời có cùng mã câu hỏi không
                if (item.QUESTIONCODE === arr[i].QUESTIONCODE && item.QUESTIONGROUPCODE === arr[i].QUESTIONGROUPCODE) {
                    var count = 0;
                    count++;
                    ///this case: this answer is right and it's student's answer too
                    ///mark is glyphicon-ok and radio button will be checked
                    //sau khi radio button được check thì disable tất cả các radio button còn lại
                    if (item.TRUEANSWER === 1 && item.CODE === arr[i].ANSWERCODE) {
                        //nếu vào trường hợp này là câu trả lời là câu trả lời đúng thì cần disable tất cả các radio button còn lại
                        return 1;
                    }
                    ///this case this answer is right and it isn't student's answer
                    ///mark is glyphicon-ok and  radio button will not be checked
                    if (item.TRUEANSWER === 1 && item.CODE !== arr[i].ANSWERCODE) {
                        return 2;
                    }
                    ///this case : this answer is false and it's student's answer
                    ///mark is glyphicon-remove and  radio button will be checked
                    if (item.TRUEANSWER !== 1 && item.CODE === arr[i].ANSWERCODE) {
                        return 3;
                    }
                    ///this case : this case is false and it is'nt student's answer
                    ///mark is glyphicon-remove and  radio button will not be checked
                    if (item.TRUEANSWER !== 1 && item.CODE !== arr[i].ANSWERCODE) {
                        return 4;
                    }
                }
            }
                //đây là trường hợp câu hỏi không được thí sinh làm bài
            else {
                ///this case this answer is right 
                ///mark is glyphicon-ok and  radio button will not be checked
                if (item.TRUEANSWER === 1) {
                    return 2;
                }
                ///this case : this case is false and it is'nt student's answer
                ///mark is glyphicon-remove and  radio button will not be checked
                if (item.TRUEANSWER !== 1) {
                    return 4;
                }
            }

        }
    },
    //giả sử như sinh viên vẫn chưa nhập câu trả lời cho câu hỏi đó thì công việc của chúng ta là 
    // sẽ hiển thị lên câu đúng sai và không đánh dấu tích vào bất kì đâu cả, giống trường hợp 2 và 4 ở trên
    /**
     * 
     * @param {string} questioncode - mã của câu hỏi trong  danh sách câu trả lời 
     * @param {arrau} arr - mảng câu trả lời của sinh viên listStudentAnswer
     * @returns {boolean} - Kiểm tra xem câu hỏi này đã được sinh viên làm hay chưa, nếu đã làm thì sẽ có hiển thị check radio button
     */
    CheckItemInArray(questioncode, arr) {
        var count = 0;
        for (var i = 0; i < arr.length; i++) {
            if (arr[i].QUESTIONCODE === questioncode) {
                return true;
            }
            count++;
            if (count === arr.length) {
                return false;
            }
        }
    },
    render: function()
    {
        var questionGroupCode = this.props.id;
        var listanswer = [];
        var listStudentAnswer = this.props.listAnswerStudent;
        var dataAnswer = this.props.dataAnswer;
        //lọc trong danh sách đáp án
        this.props.dataQuestion.map( (rowQuestion)=> {
            if (rowQuestion.QUESTIONGROUPCODE === questionGroupCode) {
                dataAnswer.map( (rowitem,index)=> {
                    //điều kiện lọc đảm bảo mỗi câu trả lời chỉ duyệt 2 lần,1 lần là thuộc câu hỏi và lần 2 là thực hiện in ra
                    if (rowitem.QUESTIONCODE === rowQuestion.CODE) {
                        ///insert content answer from list answer of table Answer
                        var answer = $("<div />").html(rowitem.CONTENT).text().trim();
                        //check case to show
                        switch (this.CheckItem(rowitem, listStudentAnswer, rowitem.QUESTIONCODE)) {
                            case 1: ///mark is glyphicon-ok and radio button will be checked
                                listanswer.push(
                            <li key={index} className='flex-item' id={rowitem.QUESTIONCODE}>
                                        <input type="radio" id={rowitem.CODE} name={rowitem.QUESTIONCODE} disabled checked/>
                                 &nbsp; &nbsp; &nbsp;
                            <label id={index+"_MS"} htmlFor={rowitem.CODE}>
                            <span key={'error_' + index} dangerouslySetInnerHTML={{ __html: answer }}></span>
                          </label>
                            &nbsp;&nbsp;
                        <span className="glyphicon glyphicon-ok green" ></span>
                    </li>);
                            break;
                        case 2: //mark is glyphicon-ok and  radio button will not be checked
                            listanswer.push(
                            <li key={index} className='flex-item' id={rowitem.QUESTIONCODE} disabled>
                               <input type="radio" id={rowitem.CODE} name={rowitem.QUESTIONCODE}/>
                          &nbsp; &nbsp; &nbsp;
                          <label id={index+'_MS'} htmlFor={rowitem.CODE}>
                          <span key={'error_' + index} dangerouslySetInnerHTML={{ __html: answer }}></span>
                                    </label> &nbsp;&nbsp;
                                    <span className="glyphicon glyphicon-ok green" ></span>
                                </li>
                            );
                             break;
                        case 3: //mark is glyphicon-remove and  radio button will be checked
                            listanswer.push(
                            <li key={index} className='flex-item' id={rowitem.QUESTIONCODE}>
                                        <input type="radio" id={rowitem.CODE} name={rowitem.QUESTIONCODE} disabled checked/> &nbsp; &nbsp; &nbsp;
                           <label id={index + '_MS'} htmlFor={rowitem.CODE}>
                        <span key={'error_' + index} dangerouslySetInnerHTML={
                        { __html: answer }}></span>
                     </label>&nbsp;&nbsp;
                       <span className="glyphicon glyphicon-remove red" ></span>
                       </li>);
                              break;
                        case 4: //mark is glyphicon-remove and  radio button will not be checked
                            listanswer.push(
                            <li key={index} className='flex-item' id={rowitem.QUESTIONCODE}>
                            <input type="radio" id={rowitem.CODE} name={rowitem.QUESTIONCODE}
                            disabled/>
                            &nbsp; &nbsp; &nbsp;
                            <label id={index + '_MS'} htmlFor={rowitem.CODE}>
                                <span key={'error_' + index} dangerouslySetInnerHTML={{ __html: answer }}></span>
                            </label>&nbsp;&nbsp;
                            <span className="glyphicon glyphicon-remove red" ></span>       
                       </li>);
                             break;
                        }
                    }
                });
            }
        });
        return (
            <div>
                <div className="container questiongroup">
                <b>{this.props.number}.</b>
                 </div>
              <div className="fieldsetGroup">
                   <div className="container">
                        <div className="col-sm-11 text-center">
                            <span id={this.props.id + '_questiontypeMS'}></span>
                        </div>
                   </div>
                  <ul>
                    <ul className="list-unstyled flex-container marginBottom">
                        {listanswer}
                    </ul>
                 </ul>
              </div>
              </div>
    );
}
});