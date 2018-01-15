var QuestionGroupFI = React.createClass({
componentDidMount: function () {
document.getElementById(this.props.id + '_questiontypeFI').innerHTML = this.props.objQuestionGroup.CONTENT;
$("#" + this.props.id + '_questiontypeFI').off();
var listStudentAnswer = this.props.listAnswerStudent;
var listQuestion = this.props.dataQuestion;
var listAnswer = this.props.dataAnswer;
listQuestion.map((rowitem) => {
if (rowitem.QUESTIONGROUPCODE === this.props.id) {
//kiểm tra xem câu hỏi này đã được trả lời hay chưa
var itemChecked = this.CheckItemInArray(rowitem.CODE, listStudentAnswer);
if (!!itemChecked) {
var answerObj = this.GetItemInArray(itemChecked.ANSWERCODE, listAnswer);
var answerContent = answerObj.CONTENT;
document.getElementById(`${this.props.id}_${rowitem.CODE}_FI`).innerHTML = answerContent;
if (answerObj.CODE === rowitem.ANSWERCODE && answerObj.TRUEANSWER === 1){
//đúng
$(`#${this.props.id}_${rowitem.CODE}_FI`).unbind();
$(`#${this.props.id}_${rowitem.CODE}_FI`).removeClass('dropClass');
$(`#${this.props.id}_${rowitem.CODE}_FI`).addClass('rightAnswer');
} else {
//sai
$(`#${this.props.id}_${rowitem.CODE}_FI`).unbind();
$(`#${this.props.id}_${rowitem.CODE}_FI`).removeClass('dropClass');
$(`#${this.props.id}_${rowitem.CODE}_FI`).addClass('wrongAnswer');
}}}});},
/** 
* @param {string} questioncode - mã câu hỏi
* @param {array} arr - danh sách câu trả lời của sinh viên
* @returns {} - arr[i]- trả lại đối tượng trong danh sách. 
* mục đích là để lấy được answercode của vị trí được thả,
* từ đó suy ra được một số thứ như nội dung .. và append vào vị trí của chúng ta cần
*/
CheckItemInArray(questioncode, arr) {
var count = 0;
for (var i = 0; i < arr.length; i++) { if (arr[i].QUESTIONCODE === questioncode) { return arr[i]; } count++; if (count === arr.length) { return false; } }
},
/**
* Lay ra doi tượng answer trong bảng answer và append ví trị mà mà sinh viên đã điền rồi
* @param {answerCode in list StudentAnswer} item-Answercode 
* @param {Arr<AnswerObj>} arr --list answer
* @returns {} 
*/
GetItemInArray(item, arr) {
    for (var i = 0; i < arr.length; i++)
    {
        if (arr[i].CODE === item)
         { return arr[i]; }
    }
},
render: function () {
return (
<div>
<div className="container questiongroup"><b>{this.props.number}.</b></div>
<div className="fieldsetGroup">
<span id={this.props.id +'_questiontypeFI'}> </span>
</div>
</div>
    );
    }
}); 