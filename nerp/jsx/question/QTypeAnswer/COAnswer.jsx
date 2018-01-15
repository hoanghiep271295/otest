  var COAnswer  = React.createClass({

      componentWillMount: function () {
//          component.add('COAnswer', this);
      },
      render: function () {       
          return (
                        <div>
                                   <div className="form-group" id="coques">
                                    <label className="col-sm-2 control-label">True/False/NotGiven </label>
                                    <div className="col-sm-10">
                                        <input style={{ 'height': '60px', 'overflowY': 'scroll', 'fontFamily': 'serif', 'fontWeight': 'bold', 'textAlign': 'center' }} className="form-control" id='CO_ANSWER' />                                                                          
                                    </div>
                                   </div>
                        </div>
                      
            );
  }
  });
