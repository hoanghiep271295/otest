var App = React.createClass({
    getInitialState: function () {
        return {
            dataSearch: [],
            tab: null
        }
    },
    componentWillMount: function () {
        //var tab = new Tab(false, 'app', 'App', null, null, null, null, null, null, null, null, null);
        //this.setState({ tab: tab });
        //component.add('app', this);
    },
    componentDidMount: function(){
        setTitle('sys_title', 'Đổi mật khẩu');
        //Thiết lập đường dẫn
        var path = [{ title: 'Đổi mật khẩu', status: 'active', link: '' }];
        setTree('sys_path', path);
        this.refs.changePassForm.Show();
    },
    handleCancel:function() {
        this.refs.changePassForm.Hide();
        window.location.replace("/home/index");
    },
    handleChanged: function () {
        this.refs.changePassForm.Hide();
        window.location.replace("/home/index");
    },
    render: function () {
        var defaultValue = getDefaultFromServer();
        var thetype = defaultValue.thetype;
        var username = defaultValue.codeview;
        return(
            <div>
                <div className="tab-content">
                  <input type="text" id="hidCODE" className="hidden" />
                    <Changepass thetype={thetype} username={username} handleCancel={this.handleCancel} handleChanged={this.handleChanged} id='changePassForm' ref='changePassForm' /> 
                </div>
                
            </div>   
        );
    }
});

ReactDOM.render(<App/>, document.getElementById('container'));