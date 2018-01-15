﻿/**
 * Tham số đầu vào:
 * questiontypecode: Kiểu loại
 * Hàm cung cấp ra ngoài
 * SaveData (obj={code,questiontypecode, subjectcode, subjectcontentcode, questionusecodelist}, onOk, onError)
 * ClearInput(obj): xóa các đối tượng
 * SetInput(obj): Thiết lập thông số đối tượng
 */
var MSPopup = React.createClass({
    getInitialState: function () {
        return {
            first: true,
            thecontent:''
        }
    },
    componentWillMount: function () {
    },
    finishInit: function () {
        this.setState({ first: false });
        var id = this.props.id;
        $('#' + id + '_mce').html(this.state.thecontent);
        window.tinymce.get(id + '_mce').setContent($('#' + id + '_mce').val());
    },
    setEditorContent: function (value) {
        var id = this.props.id;
        if (this.state.first) {
            this.setState({ thecontent: value });
        } else {
            $('#'+id + '_mce').html(value);
            window.tinymce.get(id + '_mce').setContent($('#' + id + '_mce').val());
        }
    },
    componentDidMount: function () {    
        var id = this.props.id;
        console.log('initEditorByID to ', id + '_mce');
        window.initEditorByID(id+'_mce', this.finishInit);
    },
    /**
    *hàm được gọi để xóa dữ liệu trên form cho phép thêm mới; được gọi bởi component có component này (list)
    */
    ClearInput: function () {
        this.ClearThing();//clear
    },
    /**
    *thực tế xóa trên form
    */
    ClearThing: function () {
//        this.refs[this.props.id + "_CODE"].value = "";
        this.refs[this.props.id + "_CODEVIEW"].value = "";
        this.refs[this.props.id + "_NAME"].value = "";
        this.refs[this.props.id + "_LOCK"].checked = true;//Mặc định là hiển thị
        this.refs[this.props.id + "_MARK"].value = "1";//mặc định là 1 điểm
        this.setEditorContent('');

    },
    /**
    *Hàm gán dữ liệu để sửa, được gọi bởi component cha của component này
    *para obj: thông tin về dữ liệu được thay đổi
    */
    SetInput: function (obj) {
        //Sử dụng cú pháp của react để thực hiện tương tác dữ liệu
        //this.refs[this.props.id + "_CODE"].value = obj.CODE;
        this.refs[this.props.id + "_CODEVIEW"].value = obj.CODEVIEW;
        this.refs[this.props.id + "_NAME"].value = obj.NAME;
        this.refs[this.props.id + "_LOCK"].checked = (obj.LOCK === 0);
        this.refs[this.props.id + "_MARK"].value = obj.MARK;
        this.setEditorContent(obj.CONTENT);
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
    * Ghi bản ghi, được gọi từ đối tượng cha khi click vào nút lệnh
    * @param {} obj : Đối tương truyền dữ liệu từ cha vào
    * @param {} onOk : khi thành công gọi 
    * @param {} onFail : Khi không thành công
    * @param {} onError : Khi lỗi
    * @returns {} 
    */
    SaveData: function (obj, onOk, onFail, onError) {
        var id = this.props.id;
        var questiontypecode = obj.questiontypecode;
        var subjectcode = obj.subjectcode;
        var subjectcontentcode = obj.subjectcontentcode;
        var questionusecodelist = obj.questionusecodelist;
        var code = obj.code;
        //console.log(tinymce.get(id + '_mce'));
       /// $('#' +id + '_mce').html(window.tinymce.get(id + '_mce').getContent());
        var content = $('#' + id + '_mce').html();
        content = content.replace(new RegExp('src="ContentQuestion', 'g'), 'src="/ContentQuestion');
        content = content.replace(new RegExp('src="../../ContentQuestion', 'g'), 'src="/ContentQuestion');
        var data = {
            NAME: this.refs[this.props.id + "_NAME"].value,
            CODEVIEW: this.refs[this.props.id + "_CODEVIEW"].value,
            MARK: this.refs[this.props.id + "_MARK"].value,
            LOCK: this.refs[this.props.id + "_LOCK"].checked ? 0 : 1,
            CODE: code,
            CONTENT: content,
            SUBJECTCODE: subjectcode,
            SUBJECTCONTENTCODE: subjectcontentcode,
            QUESTIONTYPECODE: questiontypecode,
            QUESTIONUSECODELIST: questionusecodelist
    }
        $.ajax({
            url: "/Question/UpdateQGROUP",
            dataType: 'json',
            data: data,
            type: "POST",
            success: function (data) {
                if (data.ret >= 0) {
                    if (!isMiss(onOk)) {
                        onOk(data);
                    }
                }
                else {
                    if (!isMiss(onFail)) {
                        onFail(data);
                    }
                }
            }.bind(this),
            error: function (xhr, status, err) {
                if (!isMiss(onError)) {
                    onError(err);
                }
            }.bind(this)
        });
    },

    render: function () {
        var id = this.props.id;
//        console.log('gen it');
        return (
            <div>
                              <div className="form-group">
                                  <label className="col-sm-2 control-label">Mã câu hỏi trong nhóm</label>
                                  <div className="col-sm-10">
                                      <input type="text" className="form-control" ref={id + '_CODEVIEW'} id={id + '_CODEVIEW'} />
                                  </div>
                              </div>
                              
                              <div className="form-group">
                                  <label className="col-sm-2 control-label">Mô tả gợi nhớ câu hỏi</label>
                                  <div className="col-sm-10">
                                      <input type="text" className="form-control" ref={id + '_NAME'} id={id + '_NAME'}/>
                                  </div>
                              </div>
                              <div className="form-group">
                                  <div className="col-sm-offset-2 col-sm-10">
                                      <div className="checkbox">
                                          <label>
                                              <input type="checkbox" ref={id + '_LOCK'} id={id + '_LOCK'}/> Hiển thị
                                          </label>
                                      </div>
                                  </div>
                              </div>
                            <div className="form-group">
                                    <label className="col-sm-2 control-label">Điểm</label>
                                    <div className="col-sm-10">
                                      <input type="number" className="form-control" ref={id + '_MARK'} id={id + '_MARK'}
                                             min='0.1' max='10' maxLength="2"
                                             placeholder="Only float with comma !" step="0.01" />
                                    </div>
                            </div>

                              <div className="form-group">
                                  <label className="col-sm-2 control-label">Nội dung câu hỏi</label>
                                  <div className="col-sm-10">
                                      <textarea className="tinymce form-control contentQG" ref={id + '_mce'} id={id + '_mce'}></textarea>
                                  <input name="image" type="file" id={id + '_mce_uploadfileimage'} className="hidden" width="100" height="100" />
                                  <input name="media" type="file" id={id + '_mce_uploadfilemedia'} className="hidden" width="100" height="100" />

                                  </div>
                              </div>

                      </div>
                    
            );
    },
});