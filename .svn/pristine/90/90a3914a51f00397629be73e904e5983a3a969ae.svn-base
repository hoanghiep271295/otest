var StudentPriorityAdd = React.createClass({
    
    componentDidMount: function () {
        var id = this.props.id;
        this.setState({popup:this.refs[this.props.id+'_popup']});
    },
   /**
    *Hiển thị, được gọi bởi component cha 
    */
    Show: function () {
        //Tên tương ứng với form đã được định nghĩa ở dưới
        //this.onActive(this.props.parent);
        $('#' + this.props.id).modal('show');
    },
    /**
    *Ẩn form hiện tại
    */
    Hide: function () {
        $('#' +this.props.id).modal('hide');
    },
    SetInput: function (obj) {
        this.setState({parentobject:obj});
    },
    /**
        *gọi khi bấm nút ghi
    */
    SaveClick: function ()
    {
        this.SaveData(true);//true: kết thúc form
    },
    
    /**
      *Thực tế ghi dữ liệu
    *para isClose xác định sau khi ghi xong sẽ đóng form, hay là tiếp tục tạo mới
    */
    SaveData:function(isClose){
        //var data =[];
        var id = this.props.id;
        //var rowSelect = this.state.rowSelect;
        var parentobject = this.state.parentobject;//Bản ghi giáo viên
        var passwordnew = this.refs[id + "_PASSWORDNEW"].value;
        var passwordnewre = this.refs[id + "_PASSWORDNEWRE"].value;

        //rowSelect.forEach(function (item, index) {
        //    data.push({ OBJECTCODE: item.OBJECTCODE, ADMINGROUPCODE: item._ADMINGROUPCODE.CODE});
        //});
        var lst={studentcode:parentobject.CODE,  passwordnew:passwordnew, passwordnewre:passwordnewre};
        //console.log('Add post:',lst);
        
        //Add or edit 1 item
        $.ajax({
            url: "/Student/dochangepass",
            type: 'POST',
            data:lst,
            dataType: 'json',
            success: function (data) {
                if (data.ret >= 0) {
                    this.Hide();
                }
                else {
                    //Sử dụng bootbox để thông báo, thay vì thông báo của hệ thống
                    bootbox.alert('Lỗi ghi dữ liệu');
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.error('unknow:url', status, err.toString());
            }.bind(this)
        });

    },
    render: function () {
        var id = this.props.id;
        var parent = this.props.parent;
        console.log('Cha cua add:', parent);
        return (
                <div  className="modal fade" id={id} ref={id} role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                  <div className="modal-dialog">
                    <div className="modal-content">
                      <div className="modal-header">
                        <button type="button" className="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span className="sr-only">Close</span></button>
                        <h4 className="modal-title" id={id+"_form_title"} ref ={id+"_form_title"}>Đổi mật khẩu</h4>
                      </div>
                      <div className="modal-body">
                          <form className="form-horizontal" role="form">
                              
                              <div className="form-group">
                                  <label className="col-sm-4 control-label">Mật khẩu mới</label>
                                  <div className="col-sm-8">
                                      <input type="password" className="form-control" id={id + "_PASSWORDNEW"} ref={id + "_PASSWORDNEW"} />
                                  </div>
                              </div>
                              <div className="form-group">
                                  <label className="col-sm-4 control-label">Nhập lại mật khẩu</label>
                                  <div className="col-sm-8">
                                      <input type="password" className="form-control" id={id + "_PASSWORDNEWRE"} ref={id + "_PASSWORDNEWRE"} />
                                  </div>
                              </div>
                          </form>
                      </div>
             <div className="box-footer modal-footer">
                 {/*Phần dành để hiển thị trạng thái - không thay đổi*/}
                <span className="label label-warning" style={{float:'left'}} id={id+"_status"} ref={id+"_status"}>i</span>
                <button type="button" className="btn btn-primary" onClick={this.SaveClick}><i className="fa fa-floppy-o"></i> Ghi</button>
                <button type="button" className="btn btn-default " data-dismiss="modal"><i className="fa fa-sign-out" ></i>Thoát</button>
              </div>

                    </div>
                  </div>
            </div>


        );
}
});

