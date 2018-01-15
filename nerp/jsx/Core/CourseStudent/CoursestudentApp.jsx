var CourseStudentApp = React.createClass({
    getInitialState: function () {
        return {
            coursecode: null,
            subjectcode: null,
            lstSubjectContent: [],
            keyvalue: []
        }
    },
    componentWillMount: function () {
        console.log('coursecode', this.state.coursecode);

    },


    componentDidMount: function () {
        this.getCourse();

    },
    setKeyValue: function (key, keyvalue) {
        keyvalue = this.state.keyvalue;
        keyvalue[key] = value;
        this.state.keyvalue = keyvalue;
    },
    /**
    * Lấy một giá trị theo key, nếu chưa có thì trả về null - dành cho các trường hợp cần truyền tham số từ các tab
    */
    getKeyValue: function () {
        var keyvalue = this.state.keyvalue;
        if (!isMiss(keyvalue[key])) return keyvalue[key];
        else return null;
    },
    getCourse: function (id) {
        var defaultvalue = window.getDefaultFromServer();
        var coursecode = defaultvalue.coursecode;
        $.ajax({
            url: '/Course/GetById',
            dataType: 'json',
            data: {
                code: coursecode
            },
            success: function (data) {
                if (data.ret >= 0) {
                    setTitle('sys_title', data.data.NAME);
                    //    this.setState({ subjectcode: data.data.SUBJECTCODE });
                    this.loadData(data.data.SUBJECTCODE);
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }.bind(this)
        });
    },
    loadData: function (subjectcode) {

        $.ajax({
            url: "/SubjectContent/getAll",
            dataType: 'json',
            data: {
                subjectcode: subjectcode
            },
            success: function (data) {
                if (data.ret >= 0) {
                    this.setState({ lstSubjectContent: data.lst });
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }
        });
    },
    //clickShow: function () {
    //    var value = $('#thetree').css('display');
    //    if (value === 'block') {
    //        document.getElementById('thetree').style.display = 'none';
    //        document.getElementById('subjectcontent').style.removeProperty('float');
    //        //   $('subjectcontent').css('float', '');
    //    } else {
    //        document.getElementById('thetree').style.display = 'block';
    //        document.getElementById('subjectcontent').style.float = 'right';
    //    }

    //},
    loadCourseContent: function () {
        var defaultvalue = window.getDefaultFromServer();
        var coursecode = defaultvalue.coursecode;
        $.ajax({
            url: "/CourseContent/GetList",
            dataType: 'json',
            data: {
                coursecode: coursecode
            },
            success: function (data) {
                if (data.ret >= 0) {
                    this.setState({ lstCourseContent: data.lst });
                    this.getListStudied();
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }
        });
    },
    getListStudied: function () {
        var defaultvalue = window.getDefaultFromServer();
        var coursecode = defaultvalue.coursecode;
        $.ajax({
            url: '/CourseStudied/GetListStudied',
            dataType: 'json',
            data: { coursecode: coursecode },
            success: function (data) {
                setTimeout(function () {
                    this.setState({ listStudied: data.data });
                }.bind(this), 100);
                setTimeout(function () {
                    this.display(data.data);
                }.bind(this), 100);

            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }
        });
    },
    // hiển thị check tree lúc load lên
    display: function (lst) {

        $('#coursecontent_tree').jstree("deselect_all");
        var listCourseContent = this.state.lstCourseContent;
        // chỉ enable những node thuộc coursecontent
        var jsonNodes = $('#coursecontent_tree').jstree(true).get_json('#', { flat: true }); // danh sách các node 
        jsonNodes.forEach(function (node, key) {
            $("#coursecontent_tree").jstree('disable_node', node);
        });
        var listStudied = lst;
        if (listStudied) {
            jsonNodes.forEach(function (val) {
                for (var i = 0; i < listStudied.length; i++) {
                    var id = val.id;
                    var subjectcontentcode = listStudied[i].SUBJECTCONTENTCODE;
                    if (id === subjectcontentcode) {
                        $('#coursecontent_tree').jstree('enable_node', val);
                    }
                }
            });
        }
    },
    // hàm này để lấy contenttype
    // truyền vào contenttypecode, trả về contentType là codeview
    getContentType: function (contentTypeCode, contentType) {
        // get contentype by id
        $.ajax({
            url: "/ContentType/GetByIdJson",
            dataType: 'json',
            type: 'POST',
            data: {
                code: contentTypeCode
            },
            success: function (data) {
                if (data.ret >= 0) {
                    contentType(data.data.CODEVIEW);
                } else {
                    contentType('');
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }.bind(this)
        });
    },
    // nội dung bài học
    getSubjectContent: function (subjectcontentcode) {
        if (subjectcontentcode === null || typeof subjectcontentcode === "undefined")
            subjectcontentcode = this.props.id;
        $.ajax({
            url: '/SubjectContent/GetById',
            dataType: 'json',
            data: { id: subjectcontentcode },
            success: function (data) {
                if (!!data.data) {
                    var note = data.data.NOTE;
                    //if (note === '') {
                    //    var c = document.getElementById('thongbao');
                    //    document.getElementById('thongbao').style.display = 'block';
                    //} else
                    //    document.getElementById('thongbao').style.display = 'none';
                    note = note.split("&lt;").join("<").split("&gt;").join(">");
                    note = note.split("&gt;").join(">");
                    note = note.replace('"ContentQuestion', '"/ContentQuestion');
                    //this.setState({ note: note });
                    document.getElementById('subjectcontent').innerHTML = note;
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }
        });
    },
    redirec: function (subjectcontentcode) {
        var defaultvalue = window.getDefaultFromServer();
        var markcode = defaultvalue.markcode;
        $.ajax({
            url: '/SubjectContentTest/GetBySubjectContentJson',
            dataType: 'json',
            data: {
                subjectcontentcode: subjectcontentcode
            },
            success: function (data) {
                if (data.ret >= 0) {
                    var examtimecode = data.examtimecode;
                    window.location.href = '/StudentExam/Index/' + markcode + '/' + examtimecode;
                }

            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }
        });
    },
    TreeSelect: function (item) {
        var contenttypecode = '';
        if (!!item)
            contenttypecode = item[0].type;
        this.getContentType(contenttypecode, function (contentType) {
            // nếu là trường hợp này, chuyển sang trang cho sinh viên thi
            if (contentType === 'TH' || contentType === 'KT' || contentType === 'BT') {
                //  console.log('CHUYỂN trang cho sinh viên thi');
                this.redirec(item[0].id);
            } else { // ngược lại thì load nội dung con và nội dung bài học

                this.getSubjectContent(item[0].id);

            }
        }.bind(this));

    },
    render: function () {
        var self = this;
        var config = { id: "CODE", text: "NAME", parent: "PARENTCODE", idext: "EXTENSIONCODE", type: 'CONTENTTYPE' };
        return (

        <div className="box">
            <div className="row" style={{ marginLeft: '5px'}}>
            
                  <div className="col-xs-3" id='thetree' style={{borderRight: '1px solid gray', minHeight:515, position: 'fixed' }}>
                       <Tree height='500px' ref='coursecontent_tree' id='coursecontent_tree' data={this.state.lstSubjectContent} mapper={config} callback={this.TreeSelect} />
                  </div>
                <div id='listsubject' className="content" style={{width: '100%' , height:'515px'}}>
                     <div className="col-xs-8" id='subjectcontent' style={{ float: 'right' }}>

                     </div>
                </div>
            </div>

        </div>

        );
    }

});

//----------------
ReactDOM.render(
    <CourseStudentApp />,
    document.getElementById('container')
);

//<button className="button-list" onClick={this.clickShow}></button>