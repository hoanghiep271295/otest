var QuestionGroupLA = React.createClass({
    componentDidMount: function () {
        document.getElementById(this.props.id + '_questiontypeLA').innerHTML =
            this.props.objQuestionGroup.CONTENT;
        $("#"+this.props.id + '_questiontypeLA').off();
    },
    getFile:function(id, lst)
    {
        if(!!lst)
        {
            return '';
        }
        var i;
        for(i=0 ; i< lst.length; i++)
        {
            if( id===lst[i].QUESTIONCODE)
            {
                return lst[i].ANSWERFILE;
            }
        }
        return '';
    },
    render: function () {
        var index = this.props.id;
        //danh sách đáp án của sinh viên
        var ans = this.props.listAnswerStudent;
        var thefile = this.getFile(index, ans);
        return (
            <div>
              <div className="container questiongroup">
            <b>{this.props.number}.</b>
            </div>
        <div className="fieldsetGroup flex-container">
                   <div className="container text-center" >
                                <span id={this.props.id + '_questiontypeLA'}></span>            
                                
                      </div>

                    <div className="flex-item flexAuto" >
                        <audio controls autoPlay>
                        <source src={thefile} type="audio/wav"/>
                            Chưa có file
                        </audio>
                    </div>
                    </div>
         </div>
            );
}
});