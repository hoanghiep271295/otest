﻿  var RWAnswer = React.createClass({
      componentWillMount: function () {
//          component.add('RWAnswer', this);
      },
      render: function () {       
          return (
                <div>                         
                        <div className="form-group" id="rwques">
                        <label className="col-sm-2 control-label">Câu trả lời chấp nhận được  </label>
                        <div className="col-sm-10">
                            <input style={{ 'height': '60px', 'overflowY': 'scroll', 'fontFamily': 'serif', 'fontWeight': 'bold', 'textAlign': 'center' }} className="form-control" id='RW_ANSWER' />                                                                          
                        </div>
                        </div>
                </div>                      
            );
  }
  });