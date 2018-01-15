  var RWQuestion = React.createClass({
      getInitialState: function () {
          return {
              listAnswer: []
          };
      },
      componentWillMount: function () {
      },
      componentDidMount: function () {
      },
      loadData: function () {
          var ret;
          //nếu mà rowselect  của cha mà chính thằng này
          //thì ta sẽ đẩy nó vào lấy danh sách kết quả theo rowselect của nó
          var questioncode = this.props.parent.getValue('QUESTIONCODE');
         var questiongroupcode = this.props.parent.getKeyValue('questiongroupcode');
          $.ajax({
              url: "/Question/getListAnswer",
              dataType: 'json',
              data: {
                  questioncode: questioncode,
                  questiongroupcode:questiongroupcode
              },
              success: function (data) {
                  this.setState({ listAnswer: data.data});
                  ret = data.data;
              }.bind(this),
                  error: function(xhr, status, err) {
                  console.log(err.toString());
              }
          });
          return ret;
      },   
     
      render: function () {
          var listRow = [];
          var index = 1;
          this.state.listAnswer.forEach(function (rowitem) {
              listRow.push(
              <tr key={index}>
                     <td style={{'textAlign':'center'}}>{index}</td>                                          
                     <td style={{'textAlign':'center'}}>
                        {rowitem.CONTENT}
                    </td>
                    </tr>);
            index++;
  });
  return (
         <div>
                                 
            <div className="form-group">
              <label className="col-sm-2 control-label">Các câu trả lời đúng</label>
              <div className="col-sm-10">
                      <table id="example2" className="table table-bordered table-hover">
                    <thead>
              <tr>
              <th className="text-center">STT</th>
              <th className="text-center">Câu trả lời</th>
              </tr>
                     </thead>
                            <tbody>{listRow}</tbody>
                      </table>
              </div>
            </div>       
  </div>
  ); }
  });
