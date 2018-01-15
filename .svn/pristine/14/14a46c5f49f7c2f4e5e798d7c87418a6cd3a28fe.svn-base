//dạng câu hỏi ghép đôi
//gồm 1 danh sách các câu trả lời nằm trên cùng cho phép kéo vào danh sách các đáp án cho các câu hỏi
//một danh sách các câu hỏi chỉ để hiển thị nằm phía bên trái
var QuestionGroupPA = React.createClass({
componentDidMount:function() {
document.getElementById(this.props.id + '_questiontypePA').innerHTML = this.props.objQuestionGroup.CONTENT;
$("#" + this.props.id + '_questiontypePA').off();
var listStudentAnswer = this.props.listAnswerStudent;
var listQuestion = this.props.dataQuestion;
var listAnswer = this.props.dataAnswer;
listQuestion.map((rowitem) => {
if (rowitem.QUESTIONGROUPCODE === this.props.id) {
//kiểm tra xem câu hỏi này đã được trả lời hay chưa
//nếu kiểm tra rồi thì lấy câu trả lời đó ra bao gồm questioncode-answercode || aswertext 
var itemChecked = this.CheckItemInArray(rowitem.CODE, listStudentAnswer);
if (!!itemChecked) {
// debugger
//lấy ra câu mã câu trả lời của sinh viên trong danh sách câu trả lời. để lấy ra các thuộc tính của câu trả lời đó
var answerObj = this.GetItemInArray(itemChecked.ANSWERCODE, listAnswer);
//lấy nội dung ra để append vào vị trí đã thi 
var answerContent = answerObj.CONTENT;
document.getElementById(`${rowitem.QUESTIONGROUPCODE}_${rowitem.CODE}_PA_CONTAINER`).innerHTML = answerContent;
if (answerObj.QUESTIONCODE === rowitem.CODE && answerObj.TRUEANSWER === 1) {
//đúng
$(`${rowitem.QUESTIONGROUPCODE}_${rowitem.CODE}_PA_CONTAINER`).unbind();
document.getElementById(`${rowitem.QUESTIONGROUPCODE}_${rowitem.CODE}_PA_CONTAINER`).style.backgroundColor = 'rgba(7, 138, 5, 0.5)';
document.getElementById(`${rowitem.QUESTIONGROUPCODE}_${rowitem.CODE}_PA_CONTAINER`).style.Color = '#161615';
document.getElementById(`${rowitem.QUESTIONGROUPCODE}_${rowitem.CODE}_PA_CONTAINER`).style.textAlign = 'center';
} else {
//sai
$(`${rowitem.QUESTIONGROUPCODE}_${rowitem.CODE}_PA_CONTAINER`).unbind();
document.getElementById(`${rowitem.QUESTIONGROUPCODE}_${rowitem.CODE}_PA_CONTAINER`).style.backgroundColor = 'rgba(181, 72, 72, 0.5)';
document.getElementById(`${rowitem.QUESTIONGROUPCODE}_${rowitem.CODE}_PA_CONTAINER`).style.Color = '#161615';
document.getElementById(`${rowitem.QUESTIONGROUPCODE}_${rowitem.CODE}_PA_CONTAINER`).style.textAlign = 'center';}}}
});

},
    /** 
 * @param {string} questioncode - mã câu hỏi
 * @param {array} arr - danh sách câu trả lời của sinh viên
 * @returns {} - arr[i]- trả lại đối tượng trong danh sách. 
 * mục đích là để lấy được answercode của vị trí được thả,
 * từ đó suy ra được một số thứ như nội dung .. và append vào vị trí của chúng ta cần
 */
CheckItemInArray(questioncode, arr) {
var count = 0;
for (var i = 0; i < arr.length; i++) {
if (arr[i].QUESTIONCODE === questioncode) {return arr[i];}count++;
if (count === arr.length) { return false;}}},
    /**
  * Lay ra doi tượng answer trong bảng answer và append ví trị mà mà sinh viên đã điền rồi
  * @param {answerCode in list StudentAnswer} item-Answercode 
  * @param {Arr<AnswerObj>} arr --list answer
  * @returns {} 
  */
GetItemInArray(item, arr) {
for (var i = 0; i < arr.length; i++) {if (arr[i].CODE === item) {return arr[i];}}},
render: function () {
var listQuestion = [];
//var listAnswer = [];
var listContainer = [];
var index = 0;
// danh sách các câu hỏi ở cột bên trái
this.props.dataQuestion.map((rowitem)=> {
if (rowitem.QUESTIONGROUPCODE === this.props.id) { index++;
var contentQuestion = $('<div/>').html(rowitem.CONTENT).text().trim();
///in ra danh sách các câu hỏi nằm ở cột bên trái
listQuestion.push(
<li key={index} className="licustom">
<b>{index}.</b>&nbsp;&nbsp;&nbsp;
<div><span className="textLeft" key={`error_${index}`} dangerouslySetInnerHTML={{ __html: contentQuestion }}></span></div></li>);
//in ra danh sách các khung chứa nằm ở bên phải
// id thì gồm có mã nhóm câu hỏi + mã câu hỏi
//cần để các area drop là các questiongroup
listContainer.push(
<li key={index} id={`${rowitem.QUESTIONGROUPCODE}_${rowitem.CODE}_PA_CONTAINER`}className="box1"onDragStart={this.dragstartHandler} onDragOver={this.dragoverHandler} onDrop={this.dropHandler}></li>
); } });
//load ra danh sach các đáp án để kéo thả
//this.props.dataAnswer.map( (rowitem)=> {
//if (rowitem.QUESTIONGROUPCODE === this.props.id) {
//index++;
//var contentAnswer = $('<div />').html(rowitem.CONTENT).text().trim();
//listAnswer.push(<DragBack key={index} index={index} id={`${rowitem.QUESTIONGROUPCODE}_${rowitem.CODE}`} content={contentAnswer} />);
//}
//});
return (
<div>
<div className="container questiongroup"><b>{this.props.number}.</b></div>
<div className="fieldsetGroup">
<div className="container questiongroup text-center"><span id={this.props.id + '_questiontypePA'}></span></div>
<div className="customcontainer">
<div className="flex list-group"><ul className="list-unstyled">{listQuestion}</ul></div>
<div className="flex list-group"><ul className="list-unstyled">{listContainer}</ul></div>
</div>
</div>
</div>
);} });