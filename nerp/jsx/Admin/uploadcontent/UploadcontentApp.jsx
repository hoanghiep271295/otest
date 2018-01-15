
var UploadcontentApp = React.createClass({
    getInitialState: function () {
        return {
            imgurl: '',
            filename: [],
            filedata: null
    }
    },
    componentWillMount: function () {
       
        
    },
    componentDidMount: function(){
        
        
    },
    send2Server: function() {
            var data = this.state.filedata;
            if (data === null) {
                bootbox.alert('Không có dữ liệu');
            } else {

                $.ajax({
                    url: "/admin/UploadSubjectContent",
                        type: "POST",
                        data: data,
                        contentType: false,
                        processData: false,
                        success: function (data) {
                            console.log(data.ret);
                            if (data.ret >= 0) {
                                console.log(data.location);
                                this.setState({ imgurl: data.location });
                                this.setState({ filedata: null });
                                this.refs.FILEUPLOAD1.value = "";
                                this.refs.title.value = 'Cập nhật thành công';
                            } else {
                                this.refs.title.value = 'Cập nhật lỗi ' + data.ret;
                                bootbox.alert('Ghi dữ liệu bị lỗi:' + data.ret);
                            }
                        }.bind(this)
                    })
                    .done(function() {
                        console.log("xong roi");
                        //$(this).addClass("done");
                    });
            
            //f.onloadend = () => {
            //    consolelog('Xong roi');
            //    //this.setState({
            //    //    file: file,
            //    //    imagePreviewUrl: reader.result
            //    //});
            //}
            //f.readAsDataURL(file);
        }
    },
    changeEvent1: function (e) {
        var data = new FormData();
        var files = e.target.files;
        var hasfile = 0;
        for (var x = 0; x < files.length; x++) {
            data.append("file" + x, files[x]);
            hasfile++;
            console.log('Have file');
        }
        this.setState({ filedata: data });
        this.refs.title.value = 'Đã chọn file mới';

    },
    sendQuestion2Server: function () {
        var data = this.state.filequestion;
        if (data === null) {
            bootbox.alert('Không có dữ liệu');
        } else {

            $.ajax({
                url: "/admin/UploadQuestion",
                type: "POST",
                data: data,
                contentType: false,
                processData: false,
                success: function (data) {
                    console.log(data.ret);
                    if (data.ret >= 0) {
                        this.setState({ filequestion: null });
                        this.refs.question.value = "";
                        this.refs.title.value = 'Cập nhật thành công';
                    } else {
                        bootbox.alert('Ghi dữ liệu bị lỗi:' + data.ret);
                        this.refs.title.value = 'Cập nhật lỗi ' + data.ret;
                    }
                }.bind(this)
            })
                .done(function () {
                    console.log("xong roi");
                });
        }
    },
    selectedQuestion:function(e) {
        var data = new FormData();
        var files = e.target.files;
        var hasfile = 0;
        for (var x = 0; x < files.length; x++) {
            data.append("file" + x, files[x]);
            hasfile++;
            console.log('Have file');
        }
        this.setState({ filequestion: data });
        this.refs.title.value = 'Đã chọn file mới';

    },
    render: function () {

        return (
            <div>
            <input type="text" className="form-control hidden" ref="IMG" id="IMG" />
                <input type="text" className="form-control " ref="title" id="title" />
            <input type="file" accept=".xlsx" className="form-control col-sm-6 " ref="FILEUPLOAD1" id="FILEUPLOAD1"   onChange={this.changeEvent1} />
                <button type="button" className="btn  btn-info pull-right" onClick={this.send2Server}>Ghi nhận</button>
                <hr/>
                            <input type="file" accept=".xlsx" className="form-control col-sm-6 " ref="question" id="question" onChange={this.selectedQuestion} />
                <button type="button" className="btn  btn-info pull-right" onClick={this.sendQuestion2Server}>Ghi nhận ngân hàng</button>

            <img id="SHOWIMG1"  src={this.state.imgurl} alt="Chưa có ảnh" />            
            </div>
            
                
        );
    }
});

ReactDOM.render(<UploadcontentApp/>, document.getElementById('container'));