var CourseStudied = React.createClass( {
    getInitialState: function() {
        return {
            loaded: null, //Kiểm tra chỉ load dữ liệu lần đầu tiên
            currentCourseCode: '',
            currentSubjectCode: '',
            lstSubjectContent: [],
            lstCourseContent: [], // bản chất là subjectcontent
            listStudied: [],
            popup: null,
            page: 1
        };
    },
    componentWillMount:function()
    {

    },
    componentDidMount: function () {
        //Lấy giá trị của popup dùng về sau
        this.setState({ popup: this.refs[this.props.id + '_Popup'] });
       
    },

    onActive: function (parent) {
        var objSubject = this.props.parent.getKeyValue('subjectCode');
        var objCourse = this.props.parent.getKeyValue('courseCode');
        var that = this;
        // nếu chưa chọn cha
        if (isMiss(objSubject)) {
            // thông báo về trang cha
            bootbox.alert("Chưa chọn môn học", function() { that.props.parent.ChooseTab('subject') });
            return;
        } else {
            if (isMiss(objCourse)) {
                // thông báo về trang cha
                bootbox.alert("Chưa chọn lớp môn học", function() { that.props.parent.ChooseTab('course') });
                return;
            }
        }
        //Chỉ load lại dữ liệu khi lần đầu - nếu phụ thuộc xem trong admingrouplist/admingrouppriority
        var subjectcode = this.props.parent.getKeyValue('subjectCode').CODE;
        var coursecode = this.props.parent.getKeyValue('courseCode').CODE;
        this.loadData();
        this.loadCourseContent();
        //// load lại nội dung môn học
        //if (this.state.currentSubjectCode !== subjectcode && !!subjectcode) {
        //    this.loadData();
        //    this.setState({ currentSubjectCode: subjectcode });
        //}
        //// load lại nội dung lớp môn học
        //if (this.state.currentCourseCode !== coursecode && !!coursecode) {

        //    this.loadCourseContent();
        //    this.setState({ currentCourseCode: coursecode });
        //}
    },

    Refresh: function () {
        this.loadData(this.state.searchstatus, this.state.rowSelect[0]);
    },
    /**
    *Lấy lại toàn bộ dữ liệu được gọi bởi popup - với đối tượng vào để xử lý phù hợp
    */
    ReloadList: function (obj) {
        //Mặc định theo giá trị tìm kiếm hiện tại, thiết lập theo bản ghi hiện tại
        this.loadData(this.state.searchstatus, obj);

    }
    ,
    /**
    * Cập nhật lại thông tin sau khi gọi xóa dữ liệu thành công
    */
    ReloadListDelete: function () {
        //cập nhật lại danh sách
        this.loadData();//(this.state.currentcode);
    },
    /**
* Lấy dữ liệu
*/
    loadData: function () {
        var subjectcode = this.props.parent.getKeyValue("subjectCode").CODE;
        $.ajax({
            url: "/SubjectContent/getAll",
            dataType: 'json',
            data: {
                subjectcode: subjectcode
            },
            success: function (data) {
                if (data.ret>=0) {
                    this.setState({ lstSubjectContent: data.lst });
                    // hiển thị nút ghi nhận hay ko
                    if (data.lst.length <= 0)
                        document.getElementById('updatecontent').style.display = "none";
                    else
                        document.getElementById('updatecontent').style.display = "block";
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }
        });
    },
    // LOAD NỘi dung của lớp môn học
    loadCourseContent: function() {
        var coursecode = this.props.parent.getKeyValue("courseCode").CODE;
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
        var subjectcode = this.props.parent.getKeyValue("subjectCode").CODE;
        var coursecode = this.props.parent.getKeyValue("courseCode").CODE;
        var postdata = {
            subjectcode: subjectcode,
            coursecode: coursecode
        };
        $.ajax({
            url: '/CourseStudied/GetListStudied',
            dataType: 'json',
            data: postdata,
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
        jsonNodes.forEach(function(node, key) {
            $("#coursecontent_tree").jstree('enable_node', node);
        });
        var listId = []; // chứa subjectcontentcode ứng với coursecontent
        listCourseContent.forEach(function (val, key) {
            listId.push(val.CODE);

        });
     //   var enableNodes = jsonNodes; 
        if (listId.length > 0) {
            jsonNodes.forEach(function (val1) {
                if (listId.indexOf(val1.id) === -1)
                    $("#coursecontent_tree").jstree('disable_node', val1);
                   
            });
        }
        // select vào các ô đã được chọn vào coursestudied
        //  var listStudied = this.state.listStudied;// danh sách nội dung đã học
        var listStudied = lst;
        if (listStudied) {
            jsonNodes.forEach(function (val) {
                for (var i = 0; i < listStudied.length; i++) {
                    var id = val.id;
                    var subjectcontentcode = listStudied[i].SUBJECTCONTENTCODE;
                    if (id === subjectcontentcode) {
                        $('#coursecontent_tree').jstree('select_node', val);
                    }
                }
            });
        }
    },
   
    onSave: function () {
        var result = 0; // kết quả sau khi update và delete

        /// update
        var liSubjectContentCode = [];
        var liContentTypeCode = [];
        // danh sách các node được chọn
        var listSelected = $('#coursecontent_tree').jstree('get_checked', true);
        listSelected.forEach(function (item, index) {
            liSubjectContentCode.push(item.id);
            liContentTypeCode.push(item.original.type);
        });
        var coursecode = this.props.parent.getKeyValue('courseCode').CODE;
        var subjectcode = this.props.parent.getKeyValue('subjectCode').CODE;
        var updateData = {
            liSubjectContentCode: liSubjectContentCode,
            subjectcode: subjectcode,
            coursecode: coursecode,
            liContentTypeCode: liContentTypeCode
        };
        //// delete các subjectcontent cũ bị uncheck
        var deleteData = [];
        this.state.listStudied.forEach(function (item, key) {
            var c = liSubjectContentCode.indexOf(item.SUBJECTCONTENTCODE);
            if (liSubjectContentCode.indexOf(item.SUBJECTCONTENTCODE) < 0) {
                deleteData.push(item.CODE);
            }
        });
        $.ajax({
            url: '/CourseStudied/Update',
            dataType: 'json',
            traditional: true,
            data: updateData,
            success: function (data) {
                if (data.ret1 < 0) {
                    log.show('Tạo phòng thi lỗi!', false);
                } else if (data.ret2 < 0) {
                    log.show('Tạo đề thi lỗi!', false);
                } else if (data.ret >= 0) {
                    if (deleteData.length > 0)
                        this.onDelete(deleteData);
                    else
                        log.show('Update thành công', true);
                } else
                    log.show("Update lỗi!", false);
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }.bind(this)
        });

    },
    onDelete: function(deleteData) {
        $.ajax({
            url: '/CourseStudied/Delete',
            dataType: 'json',
            traditional: true,
            data: { liId: deleteData },
            success: function (data) {
                if (data.ret >= 0) {
                    log.show("Update thành công!", true);
                } else
                    log.show("Update lỗi!", false);


            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }.bind(this)
        });
    },
    render: function () {
        var config = { id: "CODE", text: "NAME", parent: "PARENTCODE", idext: "EXTENSIONCODE", type: 'CONTENTTYPE'};
        return (
                <div id={this.props.id+'_list'} className="tab-pane fade in active ">{/*Cần phải gán ref để truy xuất đến đối tượng này*/}
                 
                    <div id={this.props.id+'_grid'} className="ag-fresh customgrid">
                         <Tree id='coursecontent_tree' data={this.state.lstSubjectContent} mapper={config} callback={this.TreeSelect} height='495px' check='true'/>
                        <button id='updatecontent' className='updatecontent' onClick={this.onSave}>Ghi nhận</button>
                    </div>
                   
                </div>


);
}

} );