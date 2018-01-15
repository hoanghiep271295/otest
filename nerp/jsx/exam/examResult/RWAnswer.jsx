var QuestionGroupRW = React.createClass({
    componentDidMount:function() {
        document.getElementById(this.props.id + '_questiongtypeRW').innerHTML =
    this.props.objQuestionGroup.CONTENT;
    },
    /**
     * kiem tra xem 1 cau hoi da duoc tra loi hay chua
     * @param {} item : cau hoi
     * @param {} arr : mang danh sach cac cau tra loi cua sinh vien
     * @returns{object}  - arr[i]- Đây chính là câu trả lời của sinh viên
     *                     -null- Câu ỏi này chưa được trả lời - render null 
     */
    CheckItemInArray: function (questioncode, arr) {

        var count = 0;
        for (var i = 0; i < arr.length; i++) {
            if (arr[i].QUESTIONCODE === questioncode) {
                return arr[i];
            }
            count++;
            if (count === arr.length) {
                return null;
            }
        }
    },
    render: function () {
        var listQuestion = [];
        var dataQuestion = this.props.dataQuestion;
        var dataStudentAnswer = this.props.listAnswerStudent;
        var questiongroupCode = this.props.id;
       var  index=1;
        dataQuestion.map((rowitem) =>
        {
            if (rowitem.QUESTIONGROUPCODE === questiongroupCode) {
                var contentQuestion = $('<div />').html(rowitem.CONTENT).text().trim();
                var questionAnswer = this.CheckItemInArray(rowitem.CODE, dataStudentAnswer);
                if (!!questionAnswer) {
                    listQuestion.push(
                        <li key={index} className="none-style">
                            <div className="flex-item"  >
                                <div className="questiongroup">
                                    <div className="col-sm-1"><b>{index}.</b>
                                    </div>
                                    <div className="col-sm-11">
                                          <span>{contentQuestion}</span>
                                    </div>
                                </div>
                                  <div>
                                    <label> <b><i className="fa fa-arrow-right" aria-hidden="true"></i></b></label>
                                    <input type="text" value={questionAnswer.ANSWERTEXT} className="inputRW" disabled />
                                  </div>
                            </div>
                        </li>);
                    index++;
                } else {
                    listQuestion.push(
                        <li key={index} className="none-style">
                            <div  className="flex-item">
                                <div className="questiongroup" >
                                    <div className="col-sm-1"><b>{index}.</b>
                                    </div>
                                    <div className="col-sm-11">
                                        <span >{contentQuestion}</span>
                                    </div>
                                </div>
                                  <div >
                                            <label> <b><i className="fa fa-arrow-right" aria-hidden="true"></i></b></label>
                                            <input type="text" value="NULL" className="inputRW" disabled/>
                                        </div>
                        </div>
                   </li>);
                    index++;
                }
                }

        });
return(
    <div>
           <div className="container questiongroup">
           <b>{this.props.number}.</b>
           </div>
        <div className="fieldsetGroup">
                 <div>
          <span id={this.props.id+'_questiongtypeRW'}> </span>
                 </div>
         <div>
              <ul className="flex-container">
             {listQuestion}
                 </ul>
            </div>
        </div>

   </div>
    );
}

});
