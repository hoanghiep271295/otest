'use strict';

var App = React.createClass({
    displayName: 'App',

    getInitialState: function getInitialState() {
        return {
            dataSearch: [],
            tab: null
        };
    },
    componentWillMount: function componentWillMount() {
        //var tab = new Tab(false, 'app', 'App', null, null, null, null, null, null, null, null, null);
        //this.setState({ tab: tab });
        //component.add('app', this);
    },
    componentDidMount: function componentDidMount() {
        setTitle('sys_title', 'Đổi mật khẩu');
        //Thiết lập đường dẫn
        var path = [{ title: 'Đổi mật khẩu', status: 'active', link: '' }];
        setTree('sys_path', path);
    },

    render: function render() {
        return React.createElement(
            'div',
            null,
            React.createElement(
                'div',
                { className: 'tab-content' },
                React.createElement('input', { type: 'text', id: 'hidCODE', className: 'hidden' }),
                React.createElement(Changepass, null)
            )
        );
    }
});

ReactDOM.render(React.createElement(App, null), document.getElementById('container'));

