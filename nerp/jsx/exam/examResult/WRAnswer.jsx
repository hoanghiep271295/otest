﻿var QuestionGroupWR = React.createClass({
    componentDidMount: function () {
        document.getElementById(this.props.id + '_questiontypeWR').innerHTML =
            this.props.objQuestionGroup.CONTENT;
    },
    render: function () {
        var listAnswer = [];
        this.props.listAnswerStudent.map((rowitem,index)=> {
            if (rowitem.QUESTIONGROUPCODE === this.props.id) {
                index++;
                listAnswer.push(
                    <div key={index}>
                    <div  className="fieldsetGroup" >
                        {rowitem.ANSWERTEXT}
                    </div>
                        <div className="container questiongroup">
                         <b> Mark :</b> <input type="number"
                                             id={ this.props.id + "_WR_MARK"} 
                                            className="flex-item" />
                    </div>
                        </div>
                    );
            }
        });     
        return (
                  <div>
            <div className="container questiongroup">
            <b>{this.props.number}.</b>
            </div>
               <div>
            <div>
                <fieldset className="fieldsetGroup lineHeight">
          <div className="text-center">
             <span id={this.props.id + '_questiontypeWR' }></span>
          </div>
                {listAnswer}
                </fieldset>
            </div>
               </div>
        </div>
                  );
}
});