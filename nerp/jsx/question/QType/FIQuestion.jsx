  var FIQuestion = React.createClass({
      componentWillMount: function () {
      },
      componentDidMount: function () {
      },
      render: function () {       
          return (
                        <div>
                    <input type="text" id="hidFIANSWERCODE" className="hidden" />
                              <div className="form-group" id="ficontentques">
                                    <label className="col-sm-2 control-label">Câu hỏi FI số </label>
                                    <div className="col-sm-10">
                                        <input style={{ 'overflowY': 'scroll', 'fontFamily': 'serif',fontWeight:'bold',textAlign:'center',height:'30px' }} className="form-control" id='FICONTENTQUESTION' />
                                    </div>
                              </div>
                                   <div className="form-group">
                                    <label className="col-sm-2 control-label">Câu trả lời FI</label>
                                    <div className="col-sm-10">
                                        <div style={{ 'height':'60px' , 'overflowY':'scroll' , fontWeight: 'bold' , textAlign: 'center' , 'fontFamily':'serif' }} className="form-control" id='FIANSWER'>
                                            </div>
                                        </div>
                                   </div>
                        </div>
                      
            );
      }
  });
