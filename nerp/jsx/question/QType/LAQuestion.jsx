﻿  var LAQuestion = React.createClass({
      componentWillMount: function () {
      },
      componentDidMount: function () {
      },
      
      render: function () {       
          return (
                        <div>
                               <input type="text" id="hidLAANSWERCODE" className="hidden" />
                                   <div className="form-group" id='laques'>
                                    <label className="col-sm-2 control-label">Các gợi ý</label>
                                    <div className="col-sm-10">
                                        <div className="form-control" style={{ height: 'fit-content', minHeight: '30px', 'overflowY': 'scroll', fontWeight: 'bold' }} id='LAANSWER'></div>
                                    </div>
                                   </div>
                        </div>
                      
            );
      }
  });