var PopupMark = React.createClass({

    componentWillMount: function () {
       
    },

    render: function () {
        var liExam = this.props.liExam;
        var listRowExam = []; // danh sách các đợt thi
        if (!!liExam) {
            liExam.forEach(function (item, key) {
                var amountQuestion = item.ListQuestion.length; // số câu hỏi trong 1 bài thi, mục đích là để rowSpan
                listRowExam.push(<Exam nameExam={item.Name} amountQuestion={amountQuestion} listQuestion={item.ListQuestion} key={key } />);
                });
        }
        
        return (
            <div className="modal fade" id="ModalMark" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div className="modal-dialog">
                    <div className="modal-content">
                        <div className="modal-header">
                            <button type="button" className="close" data-dismiss="modal">
                            <span aria-hidden="true">
                                &times;
                            </span><span className="sr-only">Close</span>
                            </button>
                            <h4 className="modal-title" id="myModalLabel">Danh sách điểm</h4>
                        </div>
                        <div className="modal-body">
                            <input type="text" id="MARKCODE_MARKPOPUP" className="form-control col-md-10 hidden" />
                            <input type="text" id="COURSECODE_MARKPOPUP" className="form-control col-md-10 hidden" />
                            <div id="gridMark" className="container" style={{ width: '95%' }}>
                                <table className="table table-bordered">
                                    <thead>
                                    <tr>
                                        <th>Đợt thi</th>
                                        <th>Bài</th>
                                        <th>Điểm</th>
                                    </tr>
                                    </thead>
                                    {listRowExam}
                                </table>
                            </div>
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-danger" data-dismiss="modal">Hủy</button>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
});
var Exam = React.createClass({
    render: function () {
        var amountQuestion = this.props.amountQuestion; // số câu hỏi trong 1 bài thi
        var listQuestion = this.props.listQuestion; // danh sách các câu hỏi
        var listRowQuestion = [];
        var that = this;
        listQuestion.forEach(function (item, key) {
            // nếu là câu hỏi đầu tiên thì thêm 2 prop là nameExam và amountQuestion
            // để hiển thị tên đợt thi và set rowspan
            if (key === 0) 
                listRowQuestion.push(<QuestionFirst nameExam={that.props.nameExam} amountQuestion={amountQuestion} nameQuestion={item.Name} mark={item.Mark} key={key } />);
            else
                listRowQuestion.push(<Question nameQuestion={item.Name} mark={item.Mark} key={key } />);
        });
        return (
            <tbody>
                {listRowQuestion}
            </tbody>
        );

    }
});
var QuestionFirst = React.createClass({
    render: function () {
        return (
                <tr style={{backgroundColor: 'white'}}>
                    <td rowSpan={this.props.amountQuestion}>{this.props.nameExam}</td>
                    <td>{this.props.nameQuestion}</td>
                    <td>{this.props.mark}</td>
                </tr>
        );

    }
});
var Question = React.createClass({
    render: function () {
        return (
                <tr style={{backgroundColor: 'white'}}>
                    <td>{this.props.nameQuestion}</td>
                    <td>{this.props.mark}</td>
                </tr>
        );

    }
});