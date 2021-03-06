﻿
var QuestionTypeRW = React.createClass({
    componentDidMount: function () {
        document.getElementById(this.props.id + '_questiontypeRW').innerHTML = this.props.objQuestionGroup.CONTENT;
    },
    /**
     * khen anything up in this input will automate update into state
     * @returns {}
     */
    inputChange: function (event) {
        var index = event.target.id;
        var answer = document.getElementById(index).value;
        if (!!answer) {
            index = index.replace("RW", "");
            var mch = index;
            this.props.onCheck(mch, answer, "RW");
        }
    },
    render: function () {
        var listQuestion = [];
        var index = 1;
        this.props.dataQuestion.map( (rowitem)=> {
            if (rowitem.QUESTIONGROUPCODE === this.props.id) {
                var contentQuestion = $("<div />").html(rowitem.CONTENT).text().trim();
                listQuestion.push(
                <div key={index}>
              <li className="none-style">
                <div className="container">
                       <b className="col-sm-1">{index}.</b>
                        <div className="col-sm-10 fitContent">
                     <span id={rowitem.CODE + '_questionMC' }>{contentQuestion}</span>
                        </div>
                </div>
                  <ul className="list-unstyled flex-container marginBottom">
                      <li>
                         <label htmlFor={rowitem.CODE + "RW"}>
                           <b><i className="fa fa-arrow-right" aria-hidden="true"></i></b>
                         </label>
                          <input id={rowitem.CODE + "RW"}
                                type="text"
                                 onBlur={this.inputChange}
                                  className="inputRW" />
                          </li>
                    </ul>
                </li>
                </div>);
                index++;
        }
          
    });
        return (
          <div>
                    <div className="container questiongroup"><b>{this.props.number}.</b></div>
                       <div>
                    <div>
                        <fieldset className="fieldsetGroup lineHeight text-center">
                     <span id={this.props.id + '_questiontypeRW'}></span>
                    <ul>{listQuestion}</ul>
                        </fieldset>
                    </div>
                       </div>
           </div>
            );
}
});
