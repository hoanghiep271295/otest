﻿//FI Question,first render questiongroup htmldrangerous
//render ul contain list answer
var QuestionTypeFI = React.createClass({
    componentDidMount: function () {
        document.getElementById(this.props.id + '_questiontypeFI').innerHTML =this.props.objQuestionGroup.CONTENT;
        $('#'+this.props.id + '_questiontypeFI').scrollTop(300);
    },
    render() {
        var listanswer = [];
        var value = 1;
        this.props.dataAnswer.map( (rowitem)=> {
            if (rowitem.QUESTIONGROUPCODE === this.props.id) {
                listanswer.push(
              <Drag     key={value}
                        index={value}
                        id={rowitem.QUESTIONGROUPCODE+"_"+ rowitem.CODE}
                        content={rowitem.CONTENT}
                        type={this.props.type} />
                    );
                value++;
            }
    });
return (
        <div>
        <div className="container questiongroup dragFi">
        <b>{this.props.number}.</b>
        </div>
        <div className="fieldsetGroup lineHeight">
             <ul className="portfolio-grid">
                 {listanswer}
             </ul>
                <div >
                   <span id={this.props.id + '_questiontypeFI'}></span>
                </div>
        </div>
        </div>
       );
}
});