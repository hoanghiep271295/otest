﻿  var PAQuestion = React.createClass({
      componentWillMount: function () {
      },
      componentDidMount: function () {
      },
      render: function () {
          return (
                       <div>
                          <input type="text" id="hidPAANSWERCODE" className="hidden" />
                                   <div className="form-group">
                                    <label className="col-sm-2 control-label">Nội dung câu trả lời</label>
                                    <div className="col-sm-10">
                                        <div style={{ 'height': '60px', 'overflowY': 'scroll', fontWeight: 'bold', textAlign: 'center', 'fontFamily': 'serif' }} className="form-control" id='PAANSWER'></div>             
                                   </div>
                                   </div>
                        </div>
            );
        }
  });