'use strict';

var Test = React.createClass({
    displayName: 'Test',

    render: function render() {

        return React.createElement(
            'div',
            null,
            'hello'
        );
    }
});

ReactDOM.render(React.createElement(Test, null), document.getElementById('container'));

