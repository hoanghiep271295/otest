'use strict';

var Test3 = React.createClass({
    displayName: 'Test3',

    render: function render() {

        return React.createElement(
            'div',
            null,
            'hello3'
        );
    }
});

ReactDOM.render(React.createElement(Test3, null), document.getElementById('container'));

