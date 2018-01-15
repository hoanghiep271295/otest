/**
*Thực hiện tạo một trê trên đối tượng
*@para id: id của thẻ select của đối tượng được sinh ra
*@para data: Dữ liệu hiển thị cây (Danh sách theo mô hình cha con)
*@para mapper: Ánh xạ các trường với dữ liệu trên cây (config = { id: "CODE", text: "NAME", parent: "PARENTCODE", idext: "EXTCODE" };)
*@para check: Cho phép hiển thị check box hoặc không hiển thị check {true/false}
*@para callback: Hàm callback hiển khi thực hiện chọn đối tượng trên cây
*@para height: độ cao của cây height='450px' - không có mặc định full
*/
'use strict';

var Tree = React.createClass({
    displayName: 'Tree',

    componentDidMount: function componentDidMount() {},
    shouldComponentUpdate: function shouldComponentUpdate(nextProps, nextState) {
        //console.log('Check componentUpdate', nextProps.data !== this.props.data);
        return nextProps.data !== this.props.data;
    },
    componentDidUpdate: function componentDidUpdate() {
        //        console.log('Update tree');
        //$('#' + this.props.id).empty();
        //Try to empty current tree if exist
        $('#' + this.props.id).jstree("destroy").empty();
        //console.log('Clear tree');
        var tr = $('#' + this.props.id).setTree({
            data: this.props.data,
            mapper: this.props.mapper,
            onChoose: this.props.callback,
            check: this.props.check
        });
        //console.log('Set tree ok');
    },

    render: function render() {
        var styleheight = {
            height: "100%"
        };
        if (this.props.height !== 'undefined' && this.props.height !== null) {
            styleheight = {
                height: this.props.height,
                overflow: "auto"
            };
        }
        return React.createElement('div', { id: this.props.id, style: styleheight });
    }
});

