var QuestionGroupFF = React.createClass({
componentDidMount: function () {
document.getElementById(`${this.props.id}_questiontypeFF`).innerHTML = this.props.objQuestionGroup.CONTENT;
$(`#${this.props.id}_questiontypeFF`).off();
$(`#${this.props.id}_questiontypeFF`).unbind();
var listStudentAnswer = this.props.listAnswerStudent;//kết quả bài thi của sinh vi
var listQuestion = this.props.dataQuestion;
var listAnswer = this.props.dataAnswer;//danh sách câu trả lời của đề bài chứ không phải của sinh viên
listQuestion.map((rowitem) => {
if (rowitem.QUESTIONGROUPCODE === this.props.id) {
//kiểm tra xem câu hỏi này đã được trả lời hay chưa
//nếu đã trả lời trả về đối tượng, nếu chưa chả về false
var itemChecked = this.CheckItemInArray(rowitem.CODE, listStudentAnswer);
if (!!itemChecked) {
//đối tượng answer trong bảng answer 
var answerObj = this.GetItemInArray(itemChecked.ANSWERCODE, listAnswer);
$(`#${this.props.id}_${rowitem.CODE}_FF`).replaceWith(`<div id=${`${this.props.id}_${rowitem.CODE}_FF`} >${answerObj.CONTENT}</div> `);
if (answerObj.CODE === rowitem.ANSWERCODE && answerObj.TRUEANSWER===1) {
//đúng
$(`#${this.props.id}_${rowitem.CODE}_FF`).unbind();
$(`#${this.props.id}_${rowitem.CODE}_FF`).addClass("rightAnswer");
} else {
//sai
$(`#${this.props.id}_${rowitem.CODE}_FF`).unbind();
$(`#${this.props.id}_${rowitem.CODE}_FF`).addClass("wrongAnswer");
}} else {
$(`#${this.props.id}_${rowitem.CODE}_FF`).unbind();
$(`#${this.props.id}_${rowitem.CODE}_FF`).addClass("wrongAnswer");
}}});},
//kiểm tra xem câu hỏi này đã được thi hay chưa, nếu đã được thi thì trả lại cả nội dung thi của câu hỏi đó
CheckItemInArray(questioncode, arr) {
var count = 0;
for (var i = 0; i < arr.length; i++) {if (arr[i].QUESTIONCODE === questioncode) { return arr[i]; } count++;if (count === arr.length) { return false; }}},
/**
* Lay ra doi tượng answer trong bảng answer và append ví trị mà mà sinh viên đã điền rồi
* @param {answerCode in list StudentAnswer} item-Answercode 
* @param {Arr<AnswerObj>} arr --list answer
* @returns {} 
*/
GetItemInArray(item, arr) {
for (var i = 0; i < arr.length; i++) { if (arr[i].CODE === item) { return arr[i]; } } },
    render: function () {
return (
 <div><div className="container questiongroup"><b>{this.props.number}.</b></div><div className="fieldsetGroup"><span id={this.props.id +'_questiontypeFF'}> </span></div></div>
);}}); 