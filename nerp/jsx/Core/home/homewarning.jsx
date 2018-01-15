//var Select = require(['scripts/reactselect/react-select']);
var HomeIndex = React.createClass({
    getInitialState: function() {
        return {
            title: ''
            ,cbo:[]
        };
    },
    componentWillMount:function()
    {

       

    },


    componentDidMount: function () {
//        setTitle('sys_title', 'Hệ thống hỗ trợ dạy và học tiếng Nga');
        //var path = [{ title: 'Thông báo', status: 'active', link: '' }];
        //setTree('sys_path', path);
        var obj = getDefaultFromServer();
        console.log('server object here:', obj);
        setTimeout(this.doChange, 1000);
        var counttime = 3000;
        if (checkMiss(obj.url, '') === '') {
            obj.url='/home'
        }
        this.setState({ url: obj.url });
        this.refs.warning_title.innerHTML = obj.title;
        this.refs.warning_inform.innerHTML = obj.inform;
        if (!isMiss(obj.waitingtime)) {
            counttime = parseInt(obj.waitingtime);
            if (counttime === 0) {
                counttime = 3000;
            }
        }
        //Chỉ đếm khi khác -1
        if (coutntime !== -1) {
            this.setState({ counttime: counttime });
            this.refs.warning_timmer.innerHTML = (counttime / 1000);
        }
    },
    doChange: function () {
        var remain = this.state.counttime;
        remain = remain - 1000;
        this.refs.warning_timmer.innerHTML = (remain / 1000);
        this.setState({ counttime: remain });
        if (remain <= 0) {
            this.goPage();
        } else {
            console.log('Timeout!!!!!!!!!!!!!', remain);
            setTimeout(this.doChange, 1000);
        }
    },
    goPage: function () {
        window.location.replace(checkMiss(this.state.url, '/home/'));
    },
    render: function () {
        
        return (
                        <div>
                <div className="row">
                    <div className="col-sm-6 col-sm-offset-3">

    <div className="box">
        <div className="box-header with-border">
            <span className="label label-warning pull-right" id="warning_timmer" ref='warning_timmer'>100</span>
            <h3 className="box-title" ref='warning_title' id='warning_title'>Kiểm tra đầu vào</h3>
        </div>
        <div className="box-body">
            <span ref='warning_inform' id='warning_inform'>Nội dung thông báo</span>
        </div>
        <div className="box-footer">
            <button type="button" className="btn btn-primary" onClick={this.goPage}><i className="fa fa-rocket"></i> Chuyển</button>
        </div>
    </div>

                    </div>
                </div>
            </div>
        );
		}
    
});


//----------------
ReactDOM.render(
    <HomeIndex />,
    document.getElementById('container')
);