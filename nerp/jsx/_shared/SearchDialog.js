/**
*Thực hiện tạo một popup tìm kiếm
*state dataSearch: dữ liệu sẽ tìm kiếm, được set tại List: mã, tên, ghi chú ... [{title:'',id:'',type:'text'/'number',combo:'block'/'none'},...]
*callback: hàm callback để xử lý khi chọn tham số (array[{id:'',value:''}]
*title: tiêu đề của form
*defaultdata: dữ liệu đã được chọn trước đó; định dạng đúng như định dạng hàm getResult() trả về
*/
'use strict';

var SearchDialog = React.createClass({
    displayName: 'SearchDialog',

    getInitialState: function getInitialState() {
        return {
            dataSearch: [], //Dữ liệu danh sách các trường
            callbackFunction: null, //hàm xử lý khi chọn tìm kiếm
            title: 'Tìm kiếm', //Tiêu đề
            defaultdata: [] //Dữ liệu đã được khởi tạo cho đối tượng
        };
    },
    componentWillMount: function componentWillMount() {
        this.setState({ dataSearch: this.props.lst, callbackFunction: this.props.callback, title: this.props.title, defaultdata: this.props.defaultdata });
    },
    /**
    *Thiết lập lại tham số cho lần tìm kiếm tiếp theo, có thể sử dung cho nhiều chức năng
    *title: tiêu đề của form
    *lst: dữ liệu sẽ tìm kiếm, được set tại List: mã, tên, ghi chú ... [{title:'',id:'',type:'text'/'number',combo:'block'/'none'},...]
    *callback: hàm callback để xử lý khi chọn tham số (array[{id:'',value:'', type:''}]
    *defaultdata: dữ liệu đã chọn đúng định dạng của getResult
    */
    setNewFace: function setNewFace(title, lst, callback, defaultdata) {
        this.setState({ dataSearch: lst, callbackFunction: callback, title: title, defaultdata: defaultdata });
    },
    /**
    *Trả về các giá trị nhập trên form tìm kiếm này, có thể để gọi lấy lại dữ liệu sau khi đã tìm đóng form này. nếu nhiều cái cùng chia sẽ thì sẽ lưu giá trị trả về này và state của danh sách gọi. bao gồm mã của a[mã id]=obj (value,type)
      */
    getResult: function getResult() {
        var that = this;
        var ar = [];
        var datasearch = this.state.dataSearch;
        if (!!datasearch) {
            datasearch.forEach(function (item, index) {
                var v = that.refs[item.id].getValue();
                ar[item.id] = v;
            });
        }
        return ar;
    },
    /**
    *Thực hiện thao tac callback để tìm kiếm
    */
    doSearch: function doSearch() {
        var ar = this.getResult();
        var fn = this.state.callbackFunction;
        if (fn != null || fn !== 'undefined') {
            fn(ar);
        }
        this.Hide();
    },
    /**
    *Hiển thị giao diện tìm kiếm
    */
    Show: function Show() {
        $('#ModalSearch').modal('show');
    },
    /**
    *Ẩn giao diện tìm kiếm
    */
    Hide: function Hide() {
        $('#ModalSearch').modal('hide');
    },
    render: function render() {
        var that = this;
        var datasearch = this.state.dataSearch;
        var defaultdata = this.state.defaultdata;
        var listRow = [];
        if (!!datasearch) {
            datasearch.forEach(function (item, index) {
                var obj = null;
                if (defaultdata != null && defaultdata !== 'undefined') {
                    obj = defaultdata[item.id];
                }
                listRow.push(React.createElement(SearchDialogField, { title: item.title, id: item.id, type: item.type, key: index, combo: item.combo, ref: item.id, defaultvalue: obj }));
            });
        }
        return React.createElement(
            'div',
            { className: 'modal fade', id: 'ModalSearch', role: 'dialog', 'aria-labelledby': 'myModalLabel', 'aria-hidden': 'true' },
            React.createElement(
                'div',
                { className: 'modal-dialog' },
                React.createElement(
                    'div',
                    { className: 'box box-info' },
                    React.createElement(
                        'div',
                        { className: 'box-header with-border' },
                        React.createElement(
                            'button',
                            { type: 'button', className: 'close', 'data-dismiss': 'modal' },
                            React.createElement(
                                'span',
                                { 'aria-hidden': 'true' },
                                '×'
                            ),
                            React.createElement(
                                'span',
                                { className: 'sr-only' },
                                'Close'
                            )
                        ),
                        React.createElement(
                            'h4',
                            { className: 'modal-title', id: 'myModalLabel' },
                            this.state.title
                        )
                    ),
                    React.createElement(
                        'div',
                        { className: 'modal-body' },
                        React.createElement(
                            'form',
                            { className: 'form-horizontal', role: 'form' },
                            listRow
                        )
                    ),
                    React.createElement(
                        'div',
                        { className: 'box-footer modal-footer' },
                        React.createElement(
                            'button',
                            { type: 'button', className: 'btn btn-primary', onClick: this.doSearch },
                            'Tìm kiếm'
                        ),
                        React.createElement(
                            'button',
                            { type: 'button', className: 'btn btn-default', 'data-dismiss': 'modal' },
                            'Đóng'
                        )
                    )
                )
            )
        );
    }
});
var SearchDialogField = React.createClass({
    displayName: 'SearchDialogField',

    getValue: function getValue() {
        return { value: this.refs[this.props.id].value, type: this.refs['type' + this.props.id].value };
    },
    handleChange: function handleChange() {
        //Không làm gì cả
    },
    render: function render() {
        var id = 'type' + this.props.id;
        var obj = this.props.obj;
        if (obj == null || obj === 'undefined') {
            obj = { value: '', type: 'Contain' };
        }
        return React.createElement(
            'div',
            { className: 'form-group' },
            React.createElement(
                'label',
                { className: 'col-sm-2 control-label' },
                this.props.title
            ),
            React.createElement(
                'div',
                { className: 'combobox-component comboboxSearch col-sm-2' },
                React.createElement(
                    'select',
                    { id: id, style: { display: this.props.combo, padding: '6px 12px' }, ref: id, onChange: this.handleChange },
                    React.createElement(
                        'option',
                        { value: 'false' },
                        'Contain'
                    ),
                    React.createElement(
                        'option',
                        { value: 'true' },
                        'Equal'
                    )
                )
            ),
            React.createElement(
                'div',
                { className: 'col-sm-6' },
                React.createElement('input', { className: 'form-control', id: this.props.id, type: this.props.type, ref: this.props.id })
            )
        );
    }
});

