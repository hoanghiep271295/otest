/**
* Hiển thị danh sách các nút lệnh trên bảng
* list: Danh sách các nút lệnh sẽ được hiển thị - danh sách này nên được lưu vào trong state để đảm bảo không render lại khi cập nhật lại phẩn hiển thị chính
* Ví dụ: buts: [{ title: 'Thêm mới', callback: this.onNewClick, icon: ' fa fa-files-o', ref: 'cmdAdd' }, { title: 'Sửa', callback: this.onEidtClick, icon: 'fa fa-edit', ref: 'cmdEdit' }, { title: 'Xóa', callback: this.docallback, icon: 'fa fa-trash-o fa-fw', ref: 'cmdDel' }, { title: 'In', callback: this.docallback, icon: 'fa fa-line-chart', ref: 'cmdPri' }, { title: 'Lọc', callback: this.docallback, icon: 'fa fa-filter', ref: 'cmdFil' }],
*/
"use strict";

var ButtonList = React.createClass({
    displayName: "ButtonList",

    componentDidMount: function componentDidMount() {},
    shouldComponentUpdate: function shouldComponentUpdate(nextProps, nextState) {
        //console.log('Check componentUpdate', nextProps.list, this.props.list, nextProps.list !== this.props.list, nextProps.list == this.props.list);
        return nextProps.list !== this.props.list;
    },

    render: function render() {
        //console.log(this.props.list);
        var buts = [];
        var thelist = this.props.list;
        var namesList = thelist.map(function (item) {
            buts.push(React.createElement(
                "button",
                { type: "button", className: "btn btn-default", onClick: item.callback, ref: item.ref, key: item.ref },
                React.createElement(
                    "i",
                    { className: item.icon },
                    " "
                ),
                item.title
            ));
        });
        return React.createElement(
            "div",
            { className: "btn-group", style: { float: 'right' } },
            buts
        );
    }
});

