/**
* Quy tắc đặt tên
*Cung cấp ra ngoài các hàm: 
* ClearInput(obj): Xóa các text box - được gọi từ cha
* SetInput(obj): Thiết lập thông tin trên các ô text tương ứng - được gọi từ cha
* ReloadData(): callback function được gán từ cha vào để cập nhật lại thông tin của cha nếu cần thiết
*/
'use strict';

var SysmenuPopup = React.createClass({
    displayName: 'SysmenuPopup',

    componentWillMount: function componentWillMount() {
        //Load các thông tin về danh mục các thứ khác nếu cần hiết
    },
    componentDidMount: function componentDidMount() {},
    /**
    *hàm được gọi để xóa dữ liệu trên form cho phép thêm mới; được gọi bởi component có component này (list)
    */
    ClearInput: function ClearInput(obj) {
        this.refs.sysmenu_popup_parentcode.value = obj.PARENTCODE;
        this.refs.sysmenu_popup_parentextcode.value = obj.PARENTEXT;
        this.refs.sysmenu_popup_thetype.value = obj.THETYPE;
        this.ClearThing(); //clear
    },
    /**
    *thực tế xóa trên form
    */
    ClearThing: function ClearThing() {
        this.refs.sysmenu_popup_code.value = '';
        this.refs.txtName.value = '';
        this.refs.txtTheorder.value = '';
        this.refs.txtNote.value = '';
        this.refs.txtIcon.value = '';
        this.refs.txtPriority.value = '';
        this.refs.txtLink.value = '';
        this.refs.chkLock.checked = true;
        //Set status
        this.refs.sysmenu_popup_status.innerHTML = 'new';
    },
    /**
    *Hàm gán dữ liệu để sửa, được gọi bởi component cha của component này
    *para obj: thông tin về dữ liệu được thay đổi
    */
    SetInput: function SetInput(obj) {
        this.refs.sysmenu_popup_code.value = obj.CODE;
        this.refs.sysmenu_popup_parentcode.value = obj.PARENTCODE;
        this.refs.sysmenu_popup_parentextcode.value = obj.PARENTEXT;
        this.refs.sysmenu_popup_thetype.value = obj.THETYPE;
        this.refs.txtName.value = obj.NAME;
        this.refs.txtTheorder.value = obj.THEORDER;
        this.refs.txtNote.value = obj.NOTE;
        this.refs.txtIcon.value = obj.ICON;
        this.refs.txtPriority.value = obj.PRIORITY;
        this.refs.txtLink.value = obj.LINK;
        this.refs.chkLock.checked = obj.LOCK === 0;
        //Set status
        this.refs.sysmenu_popup_status.innerHTML = 'edit';
    },
    /**
    *Hiển thị, được gọi bởi component cha
    */
    Show: function Show() {
        $('#NewModalSQ').modal('show');
    },
    /**
    *Ẩn form hiện tại
    */
    Hide: function Hide() {
        $('#NewModalSQ').modal('hide');
    },
    /**
    *Kiểm tra để gọi load lại cho dữ liệu từ component cha (danh sách)
    *para obj: là mã của bản ghi mới được thao tác
    */
    ReloadData: function ReloadData(obj) {
        if (this.props.ReloadData === null || this.props.ReloadData === 'undefined') {
            return false;
        } else {
            this.props.ReloadData(obj);
            return true;
        }
    },
    /**
    *gọi khi bấm nút ghi
    */
    SaveClick: function SaveClick() {
        this.SaveData(true);
    },
    /**
    *gọi khi bấm nút ghi và tạo mới
    */
    SaveContinueClick: function SaveContinueClick() {
        this.SaveData(false);
    },
    /**
    *Thực tế ghi dữ liệu
    *para isClose xác định sau khi ghi xong sẽ đóng form, hay là tiếp tục tạo mới
    */
    SaveData: function SaveData(isClose) {
        //try to save data
        //        console.log("Ghi dữ liệu");
        var NAME = this.refs.txtName.value;
        var LINK = this.refs.txtLink.value;
        var THEORDER = this.refs.txtTheorder.value;
        var NOTE = this.refs.txtNote.value;
        var LOCK = 0;
        if (!this.refs.chkLock.checked) {
            LOCK = 1;
        }
        var ICON = this.refs.txtIcon.value;
        var PRIORITYCODE = this.refs.txtPriority.value;
        //default
        var CODE = this.refs.sysmenu_popup_code.value;
        var PARENTCODE = this.refs.sysmenu_popup_parentcode.value;
        var EXTENSIONCODE = this.refs.sysmenu_popup_parentextcode.value;
        var THETYPE = this.refs.sysmenu_popup_thetype.value;

        var data = {
            NAME: NAME,
            LINK: LINK,
            THEORDER: THEORDER,
            NOTE: NOTE,
            PARENTCODE: PARENTCODE,
            LOCK: LOCK,
            ICON: ICON,
            PRIORITYCODE: PRIORITYCODE,
            CODE: CODE,
            PARENTCODE: PARENTCODE,
            EXTENSIONCODE: EXTENSIONCODE,
            THETYPE: THETYPE
        };
        //Add or edit 1 item
        $.ajax({
            url: "/sysmenu/update",
            type: 'POST',
            data: data,
            dataType: 'json',
            success: (function (data) {
                if (data.ret >= 0) {
                    if (isClose) {
                        this.Hide();
                    } else {
                        this.ClearThing();
                        this.ReloadData(data.CODE);
                    }
                } else {
                    bootbox.alert('Lỗi ghi dữ liệu');
                }
            }).bind(this),
            error: (function (xhr, status, err) {
                console.error('unknow:url', status, err.toString());
            }).bind(this)
        });
    },
    render: function render() {
        return React.createElement(
            'div',
            { className: 'modal fade', id: 'NewModalSQ', role: 'dialog', 'aria-labelledby': 'myModalLabel', 'aria-hidden': 'true' },
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
                            { type: 'button', className: 'close ui-icon-circle-close', 'data-dismiss': 'modal' },
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
                            'h3',
                            { className: 'box-title' },
                            'Cập nhật menu  '
                        ),
                        React.createElement('input', { type: 'hidden', id: 'sysmenu_popup_code', ref: 'sysmenu_popup_code' }),
                        React.createElement('input', { type: 'hidden', id: 'sysmenu_popup_parentcode', ref: 'sysmenu_popup_parentcode' }),
                        React.createElement('input', { type: 'hidden', id: 'sysmenu_popup_parentextcode', ref: 'sysmenu_popup_parentextcode' }),
                        React.createElement('input', { type: 'hidden', id: 'sysmenu_popup_thetype', ref: 'sysmenu_popup_thetype' })
                    ),
                    React.createElement(
                        'div',
                        { className: 'modal-body' },
                        React.createElement(
                            'form',
                            { className: 'form-horizontal' },
                            React.createElement(
                                'div',
                                { className: 'box-body' },
                                React.createElement(
                                    'div',
                                    { className: 'form-group' },
                                    React.createElement(
                                        'label',
                                        { htmlFor: 'txtName', className: 'col-sm-3 control-label' },
                                        'Tên'
                                    ),
                                    React.createElement(
                                        'div',
                                        { className: 'col-sm-9' },
                                        React.createElement('input', { type: 'text', className: 'form-control', id: 'txtName', ref: 'txtName', placeholder: 'Tên menu' })
                                    )
                                ),
                                React.createElement(
                                    'div',
                                    { className: 'form-group' },
                                    React.createElement(
                                        'label',
                                        { htmlFor: 'txtLink', className: 'col-sm-3 control-label' },
                                        'Tên'
                                    ),
                                    React.createElement(
                                        'div',
                                        { className: 'col-sm-9' },
                                        React.createElement('input', { type: 'text', className: 'form-control', id: 'txtLink', ref: 'txtLink', placeholder: 'Đường dẫn' })
                                    )
                                ),
                                React.createElement(
                                    'div',
                                    { className: 'form-group' },
                                    React.createElement(
                                        'label',
                                        { htmlFor: 'txtTheorder', className: 'col-sm-3 control-label' },
                                        'Thứ tự'
                                    ),
                                    React.createElement(
                                        'div',
                                        { className: 'col-sm-9' },
                                        React.createElement('input', { type: 'number', className: 'form-control', id: 'txtTheorder', ref: 'txtTheorder', placeholder: 'Thứ tự hiển thị' })
                                    )
                                ),
                                React.createElement(
                                    'div',
                                    { className: 'form-group' },
                                    React.createElement(
                                        'label',
                                        { htmlFor: 'txtNote', className: 'col-sm-3 control-label' },
                                        'Ghi chú'
                                    ),
                                    React.createElement(
                                        'div',
                                        { className: 'col-sm-9' },
                                        React.createElement('input', { type: 'text', className: 'form-control', id: 'txtNote', ref: 'txtNote', placeholder: 'Ghi chú' })
                                    )
                                ),
                                React.createElement(
                                    'div',
                                    { className: 'form-group' },
                                    React.createElement(
                                        'label',
                                        { htmlFor: 'txtTheorder', className: 'col-sm-3 control-label' },
                                        'Hiển thị'
                                    ),
                                    React.createElement(
                                        'div',
                                        { className: 'col-sm-9' },
                                        React.createElement('input', { type: 'checkbox', id: 'chkLock', ref: 'chkLock' })
                                    )
                                ),
                                React.createElement(
                                    'div',
                                    { className: 'form-group' },
                                    React.createElement(
                                        'label',
                                        { htmlFor: 'txtIcon', className: 'col-sm-3 control-label' },
                                        'Biểu tượng'
                                    ),
                                    React.createElement(
                                        'div',
                                        { className: 'col-sm-9' },
                                        React.createElement('input', { type: 'text', className: 'form-control', id: 'txtIcon', ref: 'txtIcon', placeholder: 'Biểu tượng: fa fa-user' })
                                    )
                                ),
                                React.createElement(
                                    'div',
                                    { className: 'form-group' },
                                    React.createElement(
                                        'label',
                                        { htmlFor: 'txtPriority', className: 'col-sm-3 control-label' },
                                        'Phân quyền'
                                    ),
                                    React.createElement(
                                        'div',
                                        { className: 'col-sm-9' },
                                        React.createElement('input', { type: 'text', className: 'form-control', id: 'txtPriority', ref: 'txtPriority', placeholder: 'Phân quyền: SUPADMIN, ADMINMENU' })
                                    )
                                )
                            )
                        )
                    ),
                    React.createElement(
                        'div',
                        { className: 'box-footer modal-footer' },
                        React.createElement(
                            'span',
                            { className: 'label label-warning', style: { float: 'left' }, id: 'sysmenu_popup_status', ref: 'sysmenu_popup_status' },
                            'i'
                        ),
                        React.createElement(
                            'button',
                            { type: 'button', className: 'btn btn-primary', onClick: this.SaveClick },
                            React.createElement('i', { className: 'fa fa-floppy-o' }),
                            ' Ghi'
                        ),
                        React.createElement(
                            'button',
                            { type: 'button', className: 'btn btn-primary', onClick: this.SaveContinueClick },
                            React.createElement('i', { className: 'fa fa-plus-circle' }),
                            ' Ghi và thêm mới'
                        ),
                        React.createElement(
                            'button',
                            { type: 'button', className: 'btn btn-default ', 'data-dismiss': 'modal' },
                            React.createElement('i', { className: 'fa fa-sign-out' }),
                            'Thoát'
                        )
                    )
                )
            )
        );
    }
});
/*Tiêu đề của form*/ /*Lưu lại mã code của bản ghi hiện tại*/ /*Lưu lại mã code của cha hiện tại*/ /*Lưu lại mã extcode của cha hiện tại*/ /*Lưu lại mã kiểu menu hiện tại*/ /*Nội dung của form*/ /*Trong trường hợp nhiều trường hơn - độ cao vượt quá trang thì đặt thông số này để xác định độ cao tối đa tự động tạo thanh cuộn: style={{ height: '300px', overflow:'auto'}}*/ /*Các nút lệnh ở dưới*/

