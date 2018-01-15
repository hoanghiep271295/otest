﻿
///câu hỏi dạng 1 câu hỏi lớn có nhiều câu trả lời
var QuestionTypeMS = React.createClass({
    onChangeMS: function(e) {
        var mch = e.target.name;
        var mctl = e.target.id;
        this.props.onCheck(mch, mctl,"MS");
    },
    componentDidMount: function () {
        document.getElementById(this.props.id + '_questiontypeMS').innerHTML = this.props.objQuestionGroup.CONTENT;
    },
    render: function () {
        var index = 0;
        var listanswer = [];
        this.props.dataAnswer.map( (rowitem)=>{
            if (rowitem.QUESTIONGROUPCODE === this.props.id) {
                var answer = $("<div />").html(rowitem.CONTENT).text().trim();
                listanswer.push(
                    <li key={index} className='flex-item' name={rowitem.QUESTIONCODE}>
                     <input type="radio"
                                   id={rowitem.CODE}
                                   name={rowitem.QUESTIONCODE}
                                   onClick={this.onChangeMS} />
                                  &nbsp; &nbsp;&nbsp; &nbsp;
                                 <label id={index} htmlFor={rowitem.CODE}>
                                   <span className="textLeft"
                                       key={'error_' + index}
                                      dangerouslySetInnerHTML={{__html: answer}}>
                                </span>
                        </label>
                    </li>
                );
                index++;
            }
        });
return (
    <div>
 <div className="container questiongroup">
    <b>{this.props.number}.</b>
 </div>
    <div className="fieldsetGroup lineHeight">
         <li className="none-style">
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
                </li>
                </div>
                </div>
        );
}
});