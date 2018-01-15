﻿var QuestionTypeRA = React.createClass({
    componentDidMount:  function() {
        document.getElementById(this.props.id + '_questiontypeRA').innerHTML =
            this.props.objQuestionGroup.CONTENT;
    },
    render:  function() 
    {
        var listQuestion = [];
        var index = 1;
        this.props.dataQuestion.map( (rowitem)=>{
            if (rowitem.QUESTIONGROUPCODE === this.props.id) 
            {
            listQuestion.push(<QuestionRA key={index}
                              index={index}
                              id={rowitem.CODE}
                              objQuestion={rowitem}
                              onCheck={this.props.onCheck}
                              questiontype={this.props.questiontype} />);
                           index++; 
               }});
        return (
              <div>
                    <div className="container questiongroup">
                    <b>{this.props.number}.</b>
                    </div>
                       <div>
                    <div>
                        <fieldset className="fieldsetGroup lineHeight">
                     <span id={this.props.id + '_questiontypeRA'}></span>
                    <ul>
                        {listQuestion}
                    </ul>
                        </fieldset>
                    </div>
                       </div>
              </div>
            );}
    });

var QuestionRA = React.createClass({
    componentDidMount:function() {
        var that = this;
        $('#' + this.props.id + '_quesionRA').sortable({
            placeholer:'ui-state-highlight',
            axis : "x",
            opacity:'0.7',
            update: function() {
                var changedList = this.id;
                var mch = changedList.replace("_quesionRA", "");
                var order = $(this).sortable('toArray');
                var positions = order.join(';');
                var answer = "";
                order.map((item) => {
                    var html = document.getElementById(item);
                    var obj = html.innerText || html.textContent;
                    answer = answer.concat(...obj);
                });
                that.props.onCheck(mch, answer, "RA");
                console.log({
                    id: changedList,
                    positions: positions
                });
            }
        });
        $( "#sortable" ).disableSelection();
    },
  
    /**
     * reder data
     * @returns {}
     */
    render :function() {
        var   listContent = [];
        var questionContent = $("<div/>").html(this.props.objQuestion.CONTENT).text().trim();
        //console.log(questionContent);        
        var listQuest = questionContent.split("|");
        var id = this.props.id;
        listQuest.map((rowitem,index)=>
            {
                listContent.push(
                                <li  key={index}  id={id+"_"+index}className="liRA">  
                            <span className="ui-icon ui-icon-transferthick-e-w">
                                    </span>       
                                 {rowitem} 
                                </li>
            );
            
        });
        return (
             <div>
                 <li className="none-style">
                      <div className="container" >
                       <b className="col-sm-1" >
                           {this.props.index}.
                       </b>
                           <ul id={this.props.id + '_quesionRA'} className="list-inline">
                             { listContent }
                        </ul>  
                      </div>   
                </li>
           </div>
             );
}
});