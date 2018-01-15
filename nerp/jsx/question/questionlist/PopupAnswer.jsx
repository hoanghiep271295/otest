﻿/**
 * Quy tắc đặt tên
 * QUESTIONGROUP :Câu hỏi hay được hiểu hay hơn chính là đầu bài của câu hỏi
 * QUESTION : câu hỏi con trong một đề bài
 * ANSWER : Câu trả lời cho một câu hỏi con 
 * TRUEANSWER : Nếu là 0 tức là câu trả lời sai và là 1 tức là câu trả lời đúng
 * các questiontype :Các hình thức câu hỏi thi khác nhau
    MC: câu hỏi một nhiều - có thể là 1 câu hỏi có nhiều đáp án và chọn một đáp án đúng
    PA: câu hỏi dạng ghép đôi - hiển thị một danh sách các câu hỏi bên trái, danh sách các câu hỏi bên phải ghép lại thành cặp
    FI: Câu hỏi điền vào đoạn trống - Có một đoạn các câu hỏi và sau đó có danh sách các đáp án (có thể dư hoặc không dư) để điền vào
    FG: Câu hỏi điền vào đoạn trống tự gõ từ - Có một đoạn các câu hỏi và sau đó người thi phải tự điền từ thích hợp vào ô trống.
    CO: Dạng câu hỏi tổng kết - cho một đoạn đọc; sau đó tiến hành đưa ra một câu hỏi và có nhiều đáp án trả lời độc lập - true/false, true/false/not given
    RW: Viết lại câu; Một câu hỏi có thể có nhiều đáp án đúng (để cho phép so sánh chỉ cần đúng một trong các đáp án đó là tính điểm)
    LA: Nghe nói - lưu lại một file không có answer
    WR: Bài viết (tự luận)
 */
var PopupAnswer = React.createClass({
    componentWillMount: function() {
    },
    componentDidMount: function () {
        window.initEditor('CONTENTANSWER');
    },

    //onsavequestion here is when we change any answer we have to update the question with their answer
    //update Question follow answer changed
    //questiontype here post to server to determine what kind of question need to update
    onSaveQuestion: function (obj,questiontype) {
        //var node = new Object();
        ////mã của câu hỏi 
        //node.QUESTIONGROUPCODE = obj.QUESTIONGROUPCODE;
        ////mã của câu hỏi con
        //node.CODE = obj.CODE;
        //// mã hiển thị của câu hỏi còn
        //node.CODEVIEW = obj.CODEVIEW;
        ////tên của câu hỏi con
        //node.NAME = obj.NAME;
        ////trạng thái hiển thị của câu hỏi con
        //node.LOCK =obj.LOCK;
        ////thứ tự hiển thị
        //node.ORD = obj.ORD;
        ////điểm cho câu hỏi 
        //node.MARK = obj.MARK;
        ////nội dung câu hỏi
        //node.CONTENT = obj.CONTENT;
        ////mã câu trả lời
        //node.ANSWERCODE = obj.ANSWERCODE;
        //$.ajax({
        //    url: "/Question/UpdateQuestion",
        //    dataType: 'json',
        //    data: {
        //        QUESTIONGROUPCODE: node.QUESTIONGROUPCODE,
        //        CODE: node.CODE,
        //        CODEVIEW: node.CODEVIEW,
        //        NAME: node.NAME,
        //        LOCK: node.LOCK,
        //        ORD: node.ORD,
        //        MARK: node.MARK,
        //        ANSWERCODE : node.ANSWERCODE,
        //        CONTENT: node.CONTENT,
        //        typeQuestion:questiontype
        //    },
        //    success: function (data) {
        //        if (data.ret >= 0) {
        //            console.log('ok');
        //        }
        //    }.bind(this),
        //    error: function (xhr, status, err) {
        //        console.log(err.toString());
        //    }
        //});
    },
    /**
*Hiển thị, được gọi bởi component cha
*/
    Show: function () {
        $('#' + this.props.id).modal('show');
        var questiontype = this.props.parent.getKeyValue('questiontypecodeview');
        var id = this.props.id;
        console.log(questiontype);
        switch (questiontype) {

            case 'LA':
            case 'MS':
            case 'WR':
                document.getElementById(id + '_QUESTIONTOP').style.display = 'none';
                break;
            default:
                document.getElementById(id + '_QUESTIONTOP').style.display = 'block';
        }
    },
    /**
    *Ẩn form hiện tại
    */
    Hide: function () {
        $('#' + this.props.id).modal('hide');
    },
    /**
*hàm được gọi để xóa dữ liệu trên form cho phép thêm mới; được gọi bởi component có component này (list)
*/
    initChild:function(questiongtypecodeview) {
        console.log('init child:', questiongtypecodeview);
        var ins = null;
        //var result =null;
        //// ReSharper disable once AssignedValueIsNeverUsed
        //var title = null;
        switch (questiongtypecodeview) {
            //câu hỏi một nhiều 
            //nội dung câu trả lời đều nằm trong tinyMCE hết : answercontent 
            //1
            case 'MS':        
                ins = ReactDOM.render(<TheNull/>, document.getElementById('answer_detail'));
                
                break;
            case 'MC':        
                ins = ReactDOM.render(<TheNull/>, document.getElementById('answer_detail'));
                break;
                // câu hỏi dạng ghép đôi
                //nội dung câu trả lời đều nằm trong tinyMCE hết : answercontent 
                //2
            case 'PA':          
                ins = ReactDOM.render(<TheNull/>, document.getElementById('answer_detail'));
                break;
                //Dạng câu hỏi tổng kết 
                //loại này cũng giống như multichoice không phải gõ từ làm gì mà chỉ cần 
                //có một ô combobox cho chọn true/false/not given là xong
                //3
            case 'CO':
                ins = ReactDOM.render(<TheNull/>, document.getElementById('answer_detail'));
                //ins = ReactDOM.render(<COAnswer  />, document.getElementById('answer_detail'));
                //result = (<COAnswer/>); 
                break;
                //Câu hỏi điền vào đoạn trống 
                //dạng này cũng là dạng kéo thả nên nội dung 
                //câu trả lời có thể cho vào trong tinyMCE được, tương tự như MC hay PA
                //4
            case 'FI':
                break;
                //Câu hỏi điền vào đoạn trống tự gõ từ 
                //Vì dạng so sánh text khá khó nếu để trong dạng HTML hoặc hiện tại thì tôi chưa làm được
                //5
            case 'FG':
             //   result = (<FGAnswer/>);
                //title = 'câu hỏi điền vào đoạn trống tự gõ từ : FG';
                break;      
                //Viết lại câu; Một câu hỏi có thể có nhiều đáp án đúng
                //ở đây nhập dạng không thường không cho vào tinyMCE 
                //vì chưa biết cách bóc tách từ HTML ra để so sánh
                //6
            case 'RW':
            //    result = (<RWAnswer/>);
               // title = 'viết lại câu : RW';
                break;
                //dạng  bài viết thì không cần thiết phải hiển thị nội dung câu trả lời làm gì cả,cũng có thể hiển thị dàn ý
                //các ý để chấm điểm cũng được
                //cho nhập dạng 
                //7
            case 'WR':
                //title = 'viết bài văn tự luận : WR';          
                break;
                //do nothing, trong trường hợp mã dữ 
                //cũng làm tương tự sẽ có một vài gợi ý để các cô chấm liệu
                //từ tab 2, 3 sang tab này là null
                //8
            case 'LA':
                //title = 'câu hỏi nghe nói : LA';
                break;
            default:
                //result = 'do nothing';
                //title = 'chưa xác định';   
                break;
        }
    },
    ClearInput: function (obj) {
        var id = this.props.id;
        var questiontypecodeview = obj.QUESTIONTYPECODEVIEW;
        this.refs[id + '_QUESTIONGROUPCODE'].value = obj.QUESTIONGROUPCODE;
        this.refs[id + '_QUESTIONGROUPNAME'].innerHTML = obj.QUESTIONGROUPNAME;
        this.refs[id + '_QUESTIONCODE'].value = obj.QUESTIONCODE;
        this.refs[id + '_QUESTIONNAME'].innerHTML = obj.QUESTIONNAME;
        this.refs[id + '_QUESTIONCONTENT'].innerHTML = obj.QUESTIONCONTENT;
        this.refs[id + '_QUESTIONGROUPCONTENT'].innerHTML = obj.QUESTIONGROUPCONTENT;
        this.initChild(questiontypecodeview);
        this.ClearThing();//clear
    },
    /**
    *thực tế xóa trên form
    */
    ClearThing: function () {
        var id = this.props.id;
        this.refs[id + '_CODE'].value = '';
        this.refs[id + '_NAME'].value = 'Đáp án_';
        this.refs[id + '_THEORDER'].value = '';
        this.refs[id + '_CONTENT'].value = '';
        this.refs[id + '_TRUEANSWER'].value = '';
        $('textarea.CONTENTANSWER').html('');
        window.tinymce.get(this.props.id + '_CONTENT').setContent($('textarea.CONTENTANSWER').val());
        //Set status
        this.refs[this.props.id + "_status"].innerHTML = 'new';

    },
    /**
    *Hàm gán dữ liệu để sửa, được gọi bởi component cha của component này
    *para obj: thông tin về dữ liệu được thay đổi
    */
    SetInput: function (obj) {
        var id = this.props.id;
        this.refs[id + '_CODE'].value = obj.CODE;
        this.refs[id + '_QUESTIONGROUPCODE'].value = obj.QUESTIONGROUPCODE;
        this.refs[id + '_QUESTIONGROUPNAME'].innerHTML = obj.QUESTIONGROUPNAME;
        this.refs[id + '_QUESTIONCODE'].value = obj.QUESTIONCODE;
        this.refs[id + '_QUESTIONNAME'].innerHTML = obj.QUESTIONNAME;
        this.refs[id + '_QUESTIONCONTENT'].innerHTML = obj.QUESTIONCONTENT;
        this.refs[id + '_QUESTIONGROUPCONTENT'].innerHTML = obj.QUESTIONGROUPCONTENT;
        //-----Gán thông tin hiển thị
        this.refs[id + '_NAME'].value = obj.NAME;
        this.refs[id + '_THEORDER'].value = obj.THEORDER;
        this.refs[id + '_CONTENT'].value = obj.CONTENT;
        this.refs[id + '_TRUEANSWER'].value = obj.TRUEANSWER;


        var questiontypecodeview = obj.QUESTIONTYPECODEVIEW;
        this.initChild(questiontypecodeview);

        $('textarea.CONTENTANSWER').html(obj.CONTENT);
        window.tinymce.get(this.props.id + '_CONTENT').setContent($('textarea.CONTENTANSWER').val());

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
    SaveClick: function () {
        this.SaveData(true);
    },
    SaveContinueClick: function () {
        this.SaveData(false);
    },
    SaveData: function (isClose) {
        var content = $('textarea.CONTENTANSWER').html();
        content = content.replace(new RegExp('src="ContentQuestion', 'g'), 'src="/ContentQuestion');
        content = content.replace(new RegExp('src="../../ContentQuestion', 'g'), 'src="/ContentQuestion');
        var data = {
            QUESTIONGROUPCODE: this.refs[this.props.id + '_QUESTIONGROUPCODE'].value
            ,QUESTIONCODE: this.refs[this.props.id + '_QUESTIONCODE'].value
            , CODE: this.refs[this.props.id + '_CODE'].value
            , NAME: this.refs[this.props.id + '_NAME'].value
            , THEORDER: this.refs[this.props.id + '_THEORDER'].value
            , CONTENT: content
            , TRUEANSWER: this.refs[this.props.id + '_TRUEANSWER'].value
        };
        $.ajax({
            url: "/Question/UpdateAnswer",
            dataType: 'json',
            type: 'post',
            data: data,
            success: function (data) {
                if (data.ret >= 0) {
                    log.show("Ghi thành công!", true);
                    if (isClose) {
                        this.Hide();
                    } else {
                        this.ClearThing();
                    }
                    this.ReloadData();
                }
                else {
                    log.show("Ghi lỗi!", false);
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }
        });
    },
    render: function () {
      
        var title = '';
        var id = this.props.id;

        return (
                <div className="modal fade bounceInRight" id={id} ref={id} role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                  <div className="modal-dialog" style={{ fontFamily: 'serif'}}>
                    <div className="modal-content">
                      <div className="modal-header">
                        <button type="button" className="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span className="sr-only">Close</span></button>
                        <h4 className="modal-title" id="myModalLabel" style={{ fontFamily: 'serif'}}>Thêm bản ghi mới câu trả lời của dạng {title}</h4>
                      </div>
                      <div className="modal-body">
                          <form className="form-horizontal" id='myform' role="form" style={{ 'fontFamily': 'serif' }}>
                              <input type="text"  ref={id + '_CODE'} id={id + '_CODE'} className="form-control col-md-10 hidden" />
                              <div className="form-group">
                                  <label className="col-sm-2 control-label">Câu hỏi</label>
                                  <div className="col-sm-10">
                                        <input type="hidden" className="form-control" ref={id + '_QUESTIONGROUPCODE'} id={id + '_QUESTIONGROUPCODE'} disabled />
                                 <div style={{'height':'30px','textAlign':'center',overflowY:'scroll'}} type="text" className="form-control" ref={id + '_QUESTIONGROUPNAME'} id={id + '_QUESTIONGROUPNAME'}></div>
                                 <div style={{'height':'30px','textAlign':'center',overflowY:'scroll'}} type="text" className="form-control" ref={id + '_QUESTIONGROUPCONTENT' } id={id + '_QUESTIONGROUPCONTENT' }>

                                 </div>
                              </div>
                                 </div>
                              <div className="form-group" ref={id + '_QUESTIONTOP'} id={id + '_QUESTIONTOP'}>
                                  <label className="col-sm-2 control-label">Câu hỏi</label>
                                  <div className="col-sm-10">
                                        <input type="hidden" className="form-control" ref={id + '_QUESTIONCODE'} id={id + '_QUESTIONCODE'} disabled />
                                   <div style={{'height':'30px','textAlign':'center',overflowY:'scroll'}} type="text" className="form-control" ref={id + '_QUESTIONNAME'} id={id + '_QUESTIONNAME'} ></div>
                                      <div style={{ 'overflowY':'scroll' , minHeight:'30px',overflow:'scroll',height:'fit-content' }} className="form-control" ref={id + '_QUESTIONCONTENT' } id={id + '_QUESTIONCONTENT' }></div>
                                 </div>
                                  </div>
                              <div className="form-group">
                                  <label className="col-sm-2 control-label">Tên gọi nhớ</label>
                                  <div className="col-sm-10">
                                      <input type="text" className="form-control" ref={id + '_NAME'} id={id + '_NAME'} />
                                  </div>
                              </div>
                              <div className="form-group">
                                  <label className="col-sm-2 control-label">Thứ tự trả lời</label>
                                  <div className="col-sm-10">
                                      <input type="number" className="form-control" ref={id + '_THEORDER'} id={id + '_THEORDER'} />
                                  </div>
                                </div>                           
                                <div id='answer_detail'>
                                    
                                </div>

                              <div className="form-group" id="answercontent">
                                  <label className="col-sm-2 control-label">Nội dung câu trả lời</label>
                                  <div className="col-sm-10">
                                      <textarea className="CONTENTANSWER form-control" ref={id + '_CONTENT'} id={id + '_CONTENT'} placeholder="Message"></textarea>
                                  </div>
                              </div>
                              <div className="form-group" id="answertrue">
                                        <label className="col-sm-2 control-label">Đáp án đúng</label>
                                        <div className="col-sm-10">
                                           <select  name="TRUEANSWER" ref={id + '_TRUEANSWER'} id={id + '_TRUEANSWER'} style={{ 'height': '30px', 'width': '100%', 'textAlign': 'center' }} defaultValue='1'>
                                            <option value="0">Không phải câu trả lời đúng</option>
                                            <option value="1" >Là câu trả lời đúng</option>
                                           </select>
                                        </div>
                              </div>
                          </form>
                      </div>
             <div className="box-footer modal-footer">{/*Phần dành để hiển thị trạng thái - không thay đổi*/}
                <span className="label label-warning" style={{float:'left'}} id={id+"_status"} ref={id+"_status"}>i</span>
                <button type="button" className="btn btn-primary" onClick={this.SaveClick}><i className="fa fa-floppy-o"></i> Ghi</button>
                <button type="button" className="btn btn-primary" onClick={this.SaveContinueClick}><i className="fa fa-plus-circle"></i> Ghi và thêm mới</button>
                <button type="button" className="btn btn-default " data-dismiss="modal"><i className="fa fa-sign-out"></i>Thoát</button>
             </div>
                    </div>
                  </div>
                </div>
            );
    }
});
var TheNull = React.createClass({
    render: function() {
        return (<div></div>);
    }
});

