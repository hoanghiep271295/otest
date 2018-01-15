﻿var QuestionGroupFG = React.createClass({
componentDidMount:function() {
document.getElementById(this.props.id + '_questiontypeFG').innerHTML = this.props.objQuestionGroup.CONTENT;
$("#" + this.props.id + '_questiontypeFG').off();
var listStudentAnswer = this.props.listAnswerStudent;
var listQuestion = this.props.dataQuestion;
var listAnswer = this.props.dataAnswer;
listQuestion.map((rowitem) => {
if (rowitem.QUESTIONGROUPCODE === this.props.id) {
//kiểm tra xem câu hỏi này đã được trả lời hay chưa
//trả về câu trả lời của sinh viên cho câu hỏi đó
var itemChecked = this.CheckItemInArray(rowitem.CODE, listStudentAnswer);
if (!!itemChecked) {
//var answerObj = this.GetItemInArray(itemChecked.ANSWERCODE, listAnswer);
    var answerContent = itemChecked.ANSWERTEXT;// câu trả lời của sinh viên
    $(`#${this.props.id}_${rowitem.CODE}_FG`).unbind();
document.getElementById(`${this.props.id}_${rowitem.CODE}_FG`).value = answerContent;
document.getElementById(`${this.props.id}_${rowitem.CODE}_FG`).disabled = true;
var answerObj = this.GetItemInArray(rowitem.ANSWERCODE, listAnswer);
var answerText = answerObj.CONTENT;//câu trả lời đúng
if (answerText.trim() === answerContent.trim()) {
//đúng
$(`#${this.props.id}_${rowitem.CODE}_FG`).unbind();
document.getElementById(`${this.props.id}_${rowitem.CODE}_FG`).removeClass("inputFG");
document.getElementById(`${this.props.id}_${rowitem.CODE}_FG`).addClass("rightAnswer");
} else {
//sai
$(`#${this.props.id}_${rowitem.CODE}_FG`).unbind();
document.getElementById(`${this.props.id}_${rowitem.CODE}_FG`).removeClass("inputFG");
document.getElementById(`${this.props.id}_${rowitem.CODE}_FG`).addClass("wrongAnswer");
}
} else {
//không trả lời thì mặc định là sai
$(`#${this.props.id}_${rowitem.CODE}_FG`).unbind();
document.getElementById(`${this.props.id}_${rowitem.CODE}_FG`).removeClass("inputFG");
document.getElementById(`${this.props.id}_${rowitem.CODE}_FG`).addClass("wrongAnswer");
}}});},
CheckItemInArray(questioncode, arr) {
    var count = 0;
    for (var i = 0; i < arr.length; i++) {
        if (arr[i].QUESTIONCODE === questioncode) {return arr[i];}
        count++;
        if (count === arr.length) {return false;}}},
    /**
     * Lay ra doi tượng answer trong bảng answer và append ví trị mà mà sinh viên đã điền rồi
     * @param {answerCode in list StudentAnswer} item-Answercode 
     * @param {Arr<AnswerObj>} arr --list answer
     * @returns {} 
     */
    GetItemInArray(item, arr) {
        for (var i = 0; i < arr.length; i++) {
            if (arr[i].CODE === item) {
                return arr[i];
            }
        }
    },
    render: function () {
        return (
          <div>
           <div className="container questiongroup"><b>{this.props.number}.</b></div>
            <div className="fieldsetGroup">
                <span id={this.props.id +'_questiontypeFG'}> </span>
            </div>
        </div>
            );
    }

});