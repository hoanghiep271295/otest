/**
 * Quy tắc đặt tên
 *Cung cấp ra ngoài các hàm: 
 * ClearInput(obj): Xóa các text box - được gọi từ cha
 * SetInput(obj): Thiết lập thông tin trên các ô text tương ứng - được gọi từ cha
 * ReloadData(): callback function được gán từ cha vào để cập nhật lại thông tin của cha nếu cần thiết
 */
var SysmenuPopup = React.createClass({
    getInitialState: function () {
        return {
            //Danh sách các phân quyền
            lst: []
        };
    },
    componentWillMount: function () {
        //Load các thông tin về danh mục các thứ khác nếu cần hiết
        this.loadCombo();
    },
    componentDidMount: function () {

    },
    /**
     * Lấy toàn bộ thông tin về các phân quyền để chọn
     * @returns {} 
     */
    loadCombo: function () {
        //console.log('Load data for tree');hidTheType
        $.ajax({
            url: '/priority/getAllSearch',
            dataType: 'json',
//            data: postdata,
            success: function (data) {
                if (data.ret >= 0) {
                    this.setState({
                        lst: data.lst
                    });
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.error('unknow:url', status, err.toString());
            }.bind(this)
        });
    },

    /**
    *hàm được gọi để xóa dữ liệu trên form cho phép thêm mới; được gọi bởi component có component này (list)
    */
    ClearInput:function(obj){
        this.refs.sysmenu_popup_parentcode.value = obj.PARENTCODE;
        this.refs.sysmenu_popup_parentextcode.value = obj.PARENTEXT;
        this.refs.sysmenu_popup_thetype.value = obj.THETYPE;
        this.refs.txtParent.value = obj.PARENTNAME;
        this.ClearThing();//clear
    },
    /**
    *thực tế xóa trên form
    */
    ClearThing:function()
    {
        this.refs.sysmenu_popup_code.value = '';
        this.refs.txtName.value = '';
        this.refs.txtTheorder.value = '';
        this.refs.txtNote.value = '';
        this.refs.txtIcon.value = '';
//        this.refs.txtPriority.value = '';
        this.refs.txtLink.value = '';
        this.refs.chkLock.checked = true;
        this.refs.cboPriority.setValueString('');
        //Set status
        this.refs.sysmenu_popup_status.innerHTML = 'new';

    },
    /**
    *Hàm gán dữ liệu để sửa, được gọi bởi component cha của component này
    *para obj: thông tin về dữ liệu được thay đổi
    */
    SetInput: function (obj) {
        this.refs.sysmenu_popup_code.value = obj.CODE;
        this.refs.sysmenu_popup_parentcode.value = obj.PARENTCODE;
        this.refs.sysmenu_popup_parentextcode.value = obj.PARENTEXT;
        this.refs.sysmenu_popup_thetype.value = obj.THETYPE;
        this.refs.txtParent.value = obj.PARENTNAME;
        this.refs.txtName.value = obj.NAME;
        this.refs.txtTheorder.value = obj.THEORDER;
        this.refs.txtNote.value = obj.NOTE;
        this.refs.txtIcon.value = obj.ICON;
//        this.refs.txtPriority.value = obj.PRIORITYCODE;
        this.refs.txtLink.value = obj.LINK;
        this.refs.chkLock.checked = (obj.LOCK === 0);
        console.log('obj', obj);
        this.refs.cboPriority.setValueString(obj.PRIORITYCODE);

        //Set status
        this.refs.sysmenu_popup_status.innerHTML = 'edit';
    },
    /**
    *Hiển thị, được gọi bởi component cha
    */
    Show: function () {
        $('#NewModalSQ').modal('show');
    },
    /**
    *Ẩn form hiện tại
    */
    Hide: function () {
        $('#NewModalSQ').modal('hide');
    },
    /**
    *Kiểm tra để gọi load lại cho dữ liệu từ component cha (danh sách)
    *para obj: là mã của bản ghi mới được thao tác
    */
    ReloadData:function(obj)
    {
        if(this.props.ReloadData===null||this.props.ReloadData==='undefined')
        {
            return false;
        }
        else
        {
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
    *gọi khi bấm nút ghi và tạo mới
    */
    SaveContinueClick: function () {
        this.SaveData(false);
    },
    /**
    *Thực tế ghi dữ liệu
    *para isClose xác định sau khi ghi xong sẽ đóng form, hay là tiếp tục tạo mới
    */
    SaveData:function(isClose){
        //try to save data
//        console.log("Ghi dữ liệu");
        var NAME = this.refs.txtName.value;
        var LINK = this.refs.txtLink.value;
        var THEORDER = this.refs.txtTheorder.value;
        var NOTE = this.refs.txtNote.value;
        var LOCK = 0;
        if (!this.refs.chkLock.checked)
        {
            LOCK = 1;
        }
        var ICON = this.refs.txtIcon.value;
        var PRIORITYCODE = this.refs.cboPriority.getValueString();//this.refs.txtPriority.value;
        console.log('priority is:', PRIORITYCODE);
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
            EXTENSIONCODE: EXTENSIONCODE,
            THETYPE: THETYPE
        }
            //Add or edit 1 item
            $.ajax({
                url: "/sysmenu/update",
                type: 'POST',
                data: data,
                dataType: 'json',
                success: function (data) {
                    if (data.ret >= 0) {
                        if(isClose)
                        {
                            this.Hide();
                        }
                        else {
                            this.ClearThing();
                        }
                        this.ReloadData(data.CODE);

                    }
                    else {
                        bootbox.alert('Lỗi ghi dữ liệu');
                    }
                }.bind(this),
                error: function (xhr, status, err) {
                    console.error('unknow:url', status, err.toString());
                }.bind(this)
            });

    },
    render: function () {
        return (
<div className="modal fade" id="NewModalSQ" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div className="modal-dialog">
          <div className="box box-info" >
              {/*Tiêu đề của form*/}
            <div className="box-header with-border">
                <button type="button" className="close ui-icon-circle-close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span className="sr-only">Close</span></button>
              <h3 className="box-title">Cập nhật menu  </h3>              
                <input type="hidden" id="sysmenu_popup_code" ref="sysmenu_popup_code" />{/*Lưu lại mã code của bản ghi hiện tại*/}
                <input type="hidden" id="sysmenu_popup_parentcode" ref="sysmenu_popup_parentcode" />{/*Lưu lại mã code của cha hiện tại*/}
                <input type="hidden" id="sysmenu_popup_parentextcode" ref="sysmenu_popup_parentextcode" />{/*Lưu lại mã extcode của cha hiện tại*/}
                <input type="hidden" id="sysmenu_popup_thetype" ref="sysmenu_popup_thetype" />{/*Lưu lại mã kiểu menu hiện tại*/}
            </div>
              {/*Nội dung của form*/}
                  <div className="modal-body" >{/*Trong trường hợp nhiều trường hơn - độ cao vượt quá trang thì đặt thông số này để xác định độ cao tối đa tự động tạo thanh cuộn: style={{ height: '300px', overflow:'auto'}}*/}
            <form className="form-horizontal">
              <div className="box-body">
                <div className="form-group">
                  <label htmlFor="txtCodeview" className="col-sm-3 control-label">Menu cấp trên</label>
                  <div className="col-sm-9">
                    <input type="text" className="form-control" id="txtParent" ref='txtParent' placeholder="Menu cấp trên" readOnly />
                  </div>
                </div>
                <div className="form-group">
                  <label htmlFor="txtName" className="col-sm-3 control-label">Tên</label>
                  <div className="col-sm-9">
                    <input type="text" className="form-control" id="txtName" ref='txtName' placeholder="Tên menu" />
                  </div>
                </div>
                <div className="form-group">
                  <label htmlFor="txtLink" className="col-sm-3 control-label">Tên</label>
                  <div className="col-sm-9">
                    <input type="text" className="form-control" id="txtLink" ref='txtLink' placeholder="Đường dẫn" />
                  </div>
                </div>
                <div className="form-group">
                  <label htmlFor="txtTheorder" className="col-sm-3 control-label">Thứ tự</label>
                  <div className="col-sm-9">
                    <input type="number" className="form-control" id="txtTheorder" ref='txtTheorder' placeholder="Thứ tự hiển thị" />
                  </div>
                </div>
                <div className="form-group">
                  <label htmlFor="txtNote" className="col-sm-3 control-label">Ghi chú</label>
                  <div className="col-sm-9">
                    <input type="text" className="form-control" id="txtNote" ref='txtNote' placeholder="Ghi chú" />
                  </div>
                </div>
                <div className="form-group">
                    <label htmlFor="txtTheorder" className="col-sm-3 control-label">Hiển thị</label>
                  <div className="col-sm-9">
                    <input type="checkbox"  id="chkLock" ref='chkLock'  />
                  </div>
                </div>

                <div className="form-group">
                  <label htmlFor="txtIcon" className="col-sm-3 control-label">Biểu tượng</label>
                  <div className="col-sm-9">
                    <input type="text" className="form-control" id="txtIcon" ref='txtIcon' placeholder="Biểu tượng: fa fa-user" />
                  </div>
                </div>
                <div className="form-group">
                  <label htmlFor="txtPriority" className="col-sm-3 control-label">Phân quyền</label>
                  <div className="col-sm-9">
                    {/*<input type="text" className="form-control" id="txtPriority" ref='txtPriority' placeholder="Phân quyền: SUPADMIN, ADMINMENU" />*/}
                      <Combobox lst={this.state.lst} valuefield='CODE' textfield='{CODE}-{NAME}' id='cboPriority' ref='cboPriority' tooltip='Phân quyền' multiple={true} defaultvalue="" />
                  </div>
                </div>

              </div>
                {/*Các nút lệnh ở dưới*/}
            </form>
                  </div>
              <div className="box-footer modal-footer">
                <span className="label label-warning" style={{float:'left'}} id="sysmenu_popup_status" ref='sysmenu_popup_status'>i</span>
                <button type="button" className="btn btn-primary" onClick={this.SaveClick}><i className="fa fa-floppy-o"></i> Ghi</button>
                <button type="button" className="btn btn-primary" onClick={this.SaveContinueClick}><i className="fa fa-plus-circle"></i> Ghi và thêm mới</button>
                <button type="button" className="btn btn-default " data-dismiss="modal"><i className="fa fa-sign-out" ></i>Thoát</button>
              </div>
                  </div>

        </div>
    

</div>
            );
    }
});