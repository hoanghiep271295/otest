﻿/**
 * username: tên đăng nhập
 * thetype: kiểu nguwoif dùng hiện tại là giáo viên hay là sinh viên
 * handleCancel: hàm được gọi khi cancel
 * handleChanged: hàm được gọi khi đổi mật khẩu thành công
 * Show(): hiển thị
 * Hide(): Đóng
 * 
 */
var Changepass = React.createClass({
    getInitialState: function () {
        return {
           data:[]
        };
    },
    componentWillMount: function () {
        
    },
   
    componentDidMount: function () {
        this.refs.txtUsername.value = this.props.username;
        //var defaultvalue = getDefaultFromServer();
        //console.log('code:',defaultvalue.code);
        //console.log('thetype:',defaultvalue.thetype);
        //$('#txtUsername').val(defaultvalue.codeview);
    },
    /**
*Hiển thị, được gọi bởi component cha
*/
    Show: function () {
        $('#formChangePass').modal('show');
    },
    /**
    *Ẩn form hiện tại
    */
    Hide: function () {
        $('#formChangePass').modal('hide');
    },

    handleCancel:function()
    {
        if (!isMiss(this.props.handleCancel)) {
            this.props.handleCancel();
        }
//        window.location.replace("/home/index");
    },
    changePass:function() {
        var passwordOld = this.refs.txtPasswordOld.value;//$("#txtUsername").val();
        var password = this.refs.txtPassword.value;//$("#txtPassword").val();
        var passwordRe = this.refs.txtPasswordRe.value;//$("#txtPassword").val();
        var sec = this.refs.txtSectext.value;//$("#txtSectext").val();
        var username = this.refs.txtUsername.value;//$("#txtSectext").val();
        if (password !== passwordRe) {
            bootbox.alert('Hai lần nhập mật khẩu không giống nhau');
            return;
        }
        var thetype = this.props.thetype;
        $.ajax({
            url: "/admin/ChangeMyPass",
            dataType: 'json',
            data: {
                passwordOld: passwordOld,
                password: password,
                passwordRe: passwordRe,
                secText: sec,
                username: username,
                thetype: thetype
            },
            success: function (data) {
                var that = this;
                if (data.ret >= 0) {
                    bootbox.alert({
                        message: "Đổi mật khẩu thành công: ",
                        callback: function (result) {
                            if (!isMiss(that.props.handleChanged)) {
                                that.props.handleChanged();
                            }
                        }
                    });
                }
                else {
                    if (data.ret == -1) {
                        bootbox.alert("Thông tin thay đổi người dùng không chính xác");
                    }
                    else {
                        bootbox.alert("Lỗi không lấy được dữ liệu");
                    }
                }

            }.bind(this),
            error: function (xhr, status, err) {
                console.error('unknow:url', status, err.toString());
            }.bind(this)
        });
    },
   
    render: function () {
        return (
                <div className="modal fade bounceInRight" id='formChangePass' ref='formChangePass' role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                  <div className="modal-dialog" style={{ fontFamily: 'serif'}}>
                    <div className="modal-content">
                      <div className="modal-header">
                        <button type="button" className="close" data-dismiss="modal" onClick={this.handleCancel}><span aria-hidden="true">&times;</span><span className="sr-only">Close</span></button>
                        <h4 className="modal-title" id="myModalLabel" style={{ fontFamily: 'serif'}}>Đổi mật khẩu</h4>
                      </div>
                      <div className="modal-body">
                                                  <form role="form" >
                                        <div className="form-group">
                                            <label>Tên đăng nhập</label>
                                            <input type="text" className="form-control" id="txtUsername" ref="txtUsername" placeholder="Tên đăng nhập" />
                                        </div>
                                        <div className="form-group">
                                            <label>Mật khẩu cũ</label>
                                            <input type="password" className="form-control" id="txtPasswordOld" ref="txtPasswordOld" placeholder="Mật khẩu cũ" />
                                        </div>
                                        <div className="form-group">
                                            <label>Mật khẩu</label>
                                            <input type="password" className="form-control" id="txtPassword" ref="txtPassword" placeholder="Mật khẩu mới" />
                                        </div>
                                        <div className="form-group">
                                            <label>Nhập lại mật khẩu mới</label>
                                            <input type="password" className="form-control" id="txtPasswordRe" ref="txtPasswordRe" placeholder="Nhập lại mật khẩu mới" />
                                        </div>
                                        <div id="divShowsec" className="form-group hidden">
                                            <label>Nhập giá trị kết quả: (<span id="txtQuestion">dđ</span>)</label>
                                            <input type="text" className="form-control" id="txtSectext" ref="txtSectext" placeholder="Chuỗi bảo mật" />
                                        </div>
                                        </form>
             <div className="box-footer modal-footer">
                <button type="button" className="btn btn-primary" onClick={this.changePass}><i className="fa fa-key"></i> Đổi mật khẩu</button>
                <button type="button" className="btn btn-default " data-dismiss="modal" onClick={this.handleCancel}><i className="fa fa-sign-out"></i>Thoát</button>
             </div>
                                    </div>
                            </div>
			</div>
            </div>
           
        );
}
});
//ReactDOM.render(<Changepass/>, document.getElementById('contents'));
var count = 0;;