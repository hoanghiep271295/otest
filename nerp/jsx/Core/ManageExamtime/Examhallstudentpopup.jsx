/**
 * Quy tắc đặt tên
 *Cung cấp ra ngoài các hàm:
 * ClearInput(obj): Xóa các text box - được gọi từ cha
 * SetInput(obj): Thiết lập thông tin trên các ô text tương ứng - được gọi từ cha
 * ReloadData(): callback function được gán từ cha vào để cập nhật lại thông tin của cha nếu cần thiết
 */
var ExamHallStudentPopup = React.createClass({
    componentWillMount: function () {
        //Load các thông tin về danh mục các thứ khác nếu cần hiết
    },
    componentDidMount: function () {
    },

    /**
    *Hiển thị, được gọi bởi component cha
    */
    Show: function () {
        $('#' + this.props.id).modal('show');
    },
    /**
    *Ẩn form hiện tại
    */
    Hide: function () {
        $('#' + this.props.id).modal('hide');
    },    /**
    *hàm được gọi để xóa dữ liệu trên form cho phép thêm mới; được gọi bởi component có component này (list)
    */
    ClearInput:function(obj){
        this.ClearThing();//clear
    },
    /**
    *Hàm gán dữ liệu để sửa, được gọi bởi component cha của component này
    *para obj: thông tin về dữ liệu được thay đổi
    */
    SetInput: function (obj) {
        //Sử dụng cú pháp của react để thực hiện tương tác dữ liệu
        this.refs[this.props.id + "_EXAMHALLSTUDENTCODE"].value = obj.EXAMHALLSTUDENTCODE;
        this.refs[this.props.id + "_CODEVIEW"].value = obj.CODEVIEW;
        this.refs[this.props.id + "_NAME"].value = obj.NAME;
        this.refs[this.props.id + "_BIRTHDAY"].value = obj.BIRTHDAY;
        this.refs[this.props.id + "_LOCK"].checked = (obj.LOCK === 0);
     //   this.refs[this.props.id + "_EXAMFORMCODE"].value = obj.EXAMFORMCODE;
        this.refs[this.props.id + "_REALBEGINTIME"].value = moment(obj.REALBEGINTIME).format('YYYY-MM-DDTHH:mm');
        this.refs[this.props.id + "_REALENDTIME"].value = moment(obj.REALENDTIME).format('YYYY-MM-DDTHH:mm');
        this.refs[this.props.id + "_FINALENDTIME"].value = moment(obj.FINALENDTIME).format('YYYY-MM-DDTHH:mm');
        //Set status
        this.refs[this.props.id + "_status"].innerHTML = 'edit';
    },

    /**
   *Kiểm tra để gọi load lại cho dữ liệu từ component cha (danh sách)
   *para obj: là mã của bản ghi mới được thao tác
   */
    ReloadData: function (obj) {
        if (isMiss(this.props.ReloadData)) {
            //console.log('Call load data');
            return false;
        }
        else {
            //console.log('Call load data!!!!!!!!!!!!!');
            this.props.ReloadData(obj);
            return true;
        }
    },
    /**
    *gọi khi bấm nút ghi
    */
    SaveClick: function ()
    {
        this.SaveData(true);
    },
    /**
     *Thực tế ghi dữ liệu
   *para isClose xác định sau khi ghi xong sẽ đóng form, hay là tiếp tục tạo mới
   */
    SaveData: function (isClose) {
        var data = {
            CODE: this.refs[this.props.id + "_EXAMHALLSTUDENTCODE"].value,
            REALBEGINTIME: this.refs[this.props.id + "_REALBEGINTIME"].value,
            REALENDTIME: this.refs[this.props.id + "_REALENDTIME"].value,
            FINALENDTIME: this.refs[this.props.id + "_FINALENDTIME"].value,
            LOCK: this.refs[this.props.id + "_LOCK"].checked ? 0 : 1
    }
        //Add or edit 1 item
        $.ajax({
            url: "/ExamHallStudent/UpdateJson",
            type: 'POST',
            data: data,
            dataType: 'json',
            success: function (data) {
                if (data.ret >= 0) {
                    if (isClose) {
                        //Ghi và kết thúc
                        this.Hide();
                    }
                    else {
                        //Ghi và tạo form mới
                        this.ClearThing();
                    }
                    //Load lại dữ liệu trên grid
                    this.ReloadData(data.obj); //Truyền code để chọn đúng bản ghi - xử lý trên grid

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
        return (
                <div className="modal fade" id={id} ref={id} role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                  <div className="modal-dialog">
                    <div className="box box-info">
                      <div className="modal-header with-border">
                        <button type="button" className="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span className="sr-only">Close</span></button>
                        <h4 className="modal-title" id={id+"_form_title"} ref={id+"_form_title"}>Thay đổi thông tin</h4>
                      </div>
                      <div className="modal-body">
                          <form className="form-horizontal" role="form">
                              <input type="text" id={id + "_EXAMHALLSTUDENTCODE"} ref={id + "_EXAMHALLSTUDENTCODE"} className="form-control col-md-10 hidden" />
                              <div className="form-group">
                                  <label className="col-sm-2 control-label">Mã sinh viên</label>
                                  <div className="col-sm-10">
                                      <input type="text" className="form-control" id={id+"_CODEVIEW"} ref={id+"_CODEVIEW"} disabled/>
                                  </div>
                              </div>
                              <div className="form-group">
                                  <label className="col-sm-2 control-label">Tên</label>
                                  <div className="col-sm-10">
                                      <input type="text" className="form-control" id={id+"_NAME"} ref={id+"_NAME"} disabled/>
                                  </div>
                              </div>
                              
                              <div className="form-group">
                                  <label className="col-sm-2 control-label">Ngày sinh</label>
                                  <div className="col-sm-10">
                                      <input type="text" className="form-control" id={id + "_BIRTHDAY"} ref={id + "_BIRTHDAY"} disabled/>
                                  </div>
                              </div>
                                <div className="form-group">
                                  <div className="col-sm-offset-2 col-sm-10">
                                      <div className="checkbox">
                                          <label>
                                              <input type="checkbox" id={id+"_LOCK"} ref={id+"_LOCK"} /> Hiển thị
                                          </label>
                                      </div>
                                  </div>
                                </div>
                                <div className="form-group">
                                  <label className="col-sm-2 control-label">Thời điểm bắt đầu</label>
                                  <div className="col-sm-4">
                                      <input type="datetime-local" className="form-control" id={id + "_REALBEGINTIME"} ref={id + "_REALBEGINTIME" } />
                                  </div>
                                   <label className="col-sm-2 control-label">Thời điểm kết thúc</label>
                                  <div className="col-sm-4">
                                     <input type="datetime-local" className="form-control" id={id + "_REALENDTIME"} ref={id + "_REALENDTIME" } />
                                  </div>
                            </div>
                              <div className="form-group">
                                  <label className="col-sm-2 control-label">Thời điểm bắt buộc kết thúc</label>
                                  <div className="col-sm-4">
                                      <input type="datetime-local" className="form-control" id={id + "_FINALENDTIME"} ref={id + "_FINALENDTIME" } />
                                  </div>
                                  
                              </div>
                            
                          </form>
                      </div>
             <div className="box-footer modal-footer">{/*Phần dành để hiển thị trạng thái - không thay đổi*/}
                <span className="label label-warning" style={{float:'left'}} id={id+"_status"} ref={id+"_status"}>i</span>
                <button type="button" className="btn btn-primary" onClick={this.SaveClick}><i className="fa fa-floppy-o"></i> Ghi</button>
                <button type="button" className="btn btn-default " data-dismiss="modal"><i className="fa fa-sign-out"></i>Thoát</button>
             </div>

                    </div>
                  </div>
                </div>
            );
}
});