//dạng câu hỏi ghép đôi
//gồm 1 danh sách các câu trả lời nằm trên cùng cho phép kéo vào danh sách các đáp án cho các câu hỏi
//một danh sách các câu hỏi chỉ để hiển thị nằm phía bên trái
var QuestionTypePA = React.createClass({
    dragstartHandler: function (event) {
        // Add the target element's id to the data transfer object
        if (!!event) {
            global = event.target.id;
            event.dataTransfer.setData("text", event.target.id);
            event.dropEffect = "move";
        }
    },
    dragoverHandler: function (event) {
        if (!!event) {
            event.preventDefault();
            event.dataTransfer.dropEffect = "move";
        }
    },
    dropHandler: function (event) {
        //    debugger
        // var idDropTarget = targetdrop.split('_')[1];
        console.log(global);
        //1712240001_1712270010_number_PA
        if (!!global) {
            event.preventDefault();
            var type = global.split('_')[3];
            var answercode = global.split('_')[1];
            //lay questiongroup cua vi tri dang duoc drop
            var targetdraggroupcode = global.split('_')[0];
            //lay questiongroup cua vi tri dang duoc drag
            var targetdrop = event.currentTarget.id;
            var targetdropgroupcode = targetdrop.split('_')[0];
            //kiem tra neu hop le có nghĩa là 2 questiongroup === nhau thì chúng cùng 1 group
            //-> cho phép tranferdata
            if (targetdropgroupcode === targetdraggroupcode) {

                var el = event.currentTarget.getElementsByTagName("p");
                var data = event.dataTransfer.getData("text");
                if (el.length === 0) {
                    event.currentTarget.appendChild(document.getElementById(data));
                } else {
                    var cut = el[0].id.split('_')[1];
                    document.getElementById(el[0].id.replace("_" + cut, "")).appendChild(el[0]);
                    event.currentTarget.appendChild(document.getElementById(data));
                }
                event.preventDefault();
                //var data = event.dataTransfer.getData("text");
                //event.target.appendChild(document.getElementById(data));
                //hiện tại thì chỉ xử lý được đến thế này
                //vấn đề kĩ thuật trong khâu kéo thả cần xem xét lại
                var questioncode = targetdrop.split('_')[1];
                this.props.onCheck(questioncode, answercode, type);

            } else {
                log.show("Không thể thực hiện được thao tác này", false);
            }
        }
    },
    componentDidMount:function() {
        document.getElementById(this.props.id + '_questiontypePA').innerHTML = this.props.objQuestionGroup.CONTENT;
    },
    render: function () {
        var listQuestion = [];
        var listAnswer = [];
        var listContainer = [];
        var index = 0;
        // danh sách các câu hỏi ở cột bên trái
        this.props.dataQuestion.map((rowitem)=> {
            if (rowitem.QUESTIONGROUPCODE === this.props.id) {
                index++;
                var contentQuestion = $('<div />').html(rowitem.CONTENT).text().trim();
                ///in ra danh sách các câu hỏi nằm ở cột bên trái
                listQuestion.push(
                    <li key={index} className="licustom">
                        <b>{index}.</b>
                        &nbsp;&nbsp;&nbsp;
                        <div>
                              <span className="textLeft"
                                    key={'error_' + index}
                                    dangerouslySetInnerHTML={{ __html: contentQuestion }}>
                              </span>
                        </div>
                    </li>
                    );
                        //in ra danh sách các khung chứa nằm ở bên phải
                        // id thì gồm có mã nhóm câu hỏi + mã câu hỏi
                        //cần để các area drop là các questiongroup
                        listContainer.push(
                                <li key={index}
                                    id={rowitem.QUESTIONGROUPCODE + "_"+rowitem.CODE+"_PA_CONTAINER"}
                                    className="box1"
                                    onDragStart={this.dragstartHandler}
                                    onDragOver={this.dragoverHandler}
                                    onDrop={this.dropHandler}>
                                </li>
                    ); } });
        //load ra danh sach các đáp án để kéo thả
        this.props.dataAnswer.map( (rowitem)=> {
            if (rowitem.QUESTIONGROUPCODE === this.props.id) {
                index++;
                var contentAnswer = $('<div />').html(rowitem.CONTENT).text().trim();
                listAnswer.push(
                      <DragBack key={index}
                                index={index}
                                id={rowitem.QUESTIONGROUPCODE + "_" + rowitem.CODE}
                                content={contentAnswer}
                                type={this.props.type} />
                        );}
                        });

return (
        <div>
             <div className="container questiongroup">
               <b>{this.props.number}.</b>
                 </div>
              <div className="fieldsetGroup">
              <div className="container questiongroup text-center">
             <span id={this.props.id + '_questiontypePA'} ></span>
             </div>
            <ul className="portfolio-grid">
                {listAnswer}
            </ul>
            <div className="customcontainer">
              <div className="flex list-group">
              <ul className="list-unstyled">
                  {listQuestion}
              </ul>
              </div>
             <div className="flex list-group">
                <ul className="list-unstyled">
                    {listContainer}
                </ul>
             </div>
        </div>
             </div>
        </div>
    );} });