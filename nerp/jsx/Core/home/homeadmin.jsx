﻿var HomeAdmin = React.createClass( {
    getInitialState: function() {
        return {
            title:''
        };
    },
    componentWillMount:function()
    {
        var obj = getDefaultFromServer();
        this.setState({ currentcode: obj.code });
        setTitle('sys_title', 'Xin chào: ' + obj.name);
        var path = [{ title: 'Quản trị', status: 'active', link: '' }];
        setTree('sys_path', path);

    },


    componentDidMount: function () {

    },

    render: function () {
        return(
    <div className="row">
        <div className="col-md-12">
          <div className="box box-warning">
              <div className="box-header ">
              <h3 className="box-title">Collapsable</h3>

              <div className="box-tools pull-right">
                    <span data-toggle="tooltip" title="" className="badge bg-yellow" data-original-title="3 New Messages">3</span>
                <button type="button" className="btn btn-box-tool" data-widget="collapse">
                <i className="fa fa-minus"></i>
                </button>
              </div>

              </div>

            <div className="box-body">
                <div className="box-footer no-padding">
              <ul className="nav nav-stacked">
                <li><a href="#">Projects <span className="pull-right badge bg-blue">31</span></a></li>
                <li><a href="#">Tasks <span className="pull-right badge bg-aqua">5</span></a></li>
                <li><a href="#">Completed Projects <span className="pull-right badge bg-green">12</span></a></li>
                <li><a href="#">Followers <span className="pull-right badge bg-red">842</span></a></li>
              </ul>
                </div>
            </div>
              {/*.box-body */}
          </div>
        </div>
    </div>

        );
		}

} );

//----------------
ReactDOM.render(
    <HomeAdmin />,
    document.getElementById('container')
);