var CourseContentList = React.createClass( {
    getInitialState: function() {
        return {
            loaded: null, //Kiểm tra chỉ load dữ liệu lần đầu tiên
            currentCourseCode: '',
            currentSubjectCode: '',
            lstSubjectContent: [],
            lstCourseContent: [], // bản chất là subjectcontent
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
        //Chỉ load lại dữ liệu khi lần đầu - nếu phụ thuộc xem trong admingrouplist/admingrouppriority
        var coursecode = this.props.parent.getKeyValue("coursecode");
        var subjectcode = this.props.parent.getKeyValue("subjectcode");
        // load lại nội dung môn học
        if (this.state.currentSubjectCode !== subjectcode) {

            this.loadData();
            this.setState({ currentSubjectCode: subjectcode });
        }
        // load lại nội dung lớp môn học
        if (this.state.currentCourseCode !== coursecode) {

            this.loadCourseContent();
            this.setState({ currentCourseCode: coursecode });
        }
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
        var subjectcode = this.props.parent.getKeyValue("subjectcode");
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
    loadCourseContent: function() {
        var coursecode = this.props.parent.getKeyValue("coursecode");
        $.ajax({
            url: "/CourseContent/GetList",
            dataType: 'json',
            data: {
                coursecode: coursecode
            },
            success: function (data) {
                if (data.ret >= 0) {
                    this.setState({ lstCourseContent: data.lst });
                    
                    this.display(data.lst);
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }
        });
    },
    // hiển thị check tree lúc load lên
    display: function (list) {
        
        $('#coursecontent_tree').jstree("deselect_all");
        var listCourseContent = list;
        if (!!list || list.length >= 0) {
                var jsonNodes = $('#coursecontent_tree').jstree(true).get_json('#', { flat: true }); // danh sách các node trong tree
                jsonNodes.forEach(function (node, key) {
                    listCourseContent.forEach(function (item, key) {
                        if (node.id === item.CODE) {
                            $('#coursecontent_tree').jstree('select_node', node);
                        }
                    });
                });
        }     
    },
    onDelete: function(deleteData) {
        $.ajax({
            url: '/CourseContent/Delete',
            dataType: 'json',
            traditional: true,
            method: 'POST',
            data: {
                liId: deleteData,
                coursecode: this.props.parent.getKeyValue('coursecode')
                },
            success: function (data) {
                if (data.ret >= 0) {
                    this.loadCourseContent();
                    log.show("Update thành công!", true);
                } else
                    log.show("Update lỗi!", true);
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }
        });
    },
    onSave: function () {
        // kiểm tra xem đã chọn lớp môn học chưa
        var subjectcode = this.props.parent.getKeyValue("subjectcode");
        var coursecode = this.props.parent.getKeyValue("coursecode");
        if (!subjectcode)
            bootbox.alert("Chưa chọn môn học");
        else if (!coursecode)
            bootbox.alert("Chưa chọn lớp môn học");
        else {
            // lấy danh sách các node được check
            var liSubjectContentCode = [];
            var listSelected = $('#coursecontent_tree').jstree('get_selected');
            listSelected.forEach(function (item, index) {
                liSubjectContentCode.push(item);
            });
            // delete các subjectcontent cũ bị uncheck
            var deleteData = [];
            this.state.lstCourseContent.forEach(function (item, key) {
                var c = liSubjectContentCode.indexOf(item.CODE);
                if (liSubjectContentCode.indexOf(item.CODE) < 0) {
                    deleteData.push(item.CODE);
                }
            });
            /// update
            $.ajax({
                url: '/CourseContent/Update',
                dataType: 'json',
                method: 'POST',
                traditional: true,
                data: {
                    liSubjectContentCode: liSubjectContentCode,
                    subjectcode: subjectcode,
                    coursecode: coursecode
                },
                success: function (data) {
                    if (data.ret >= 0) {
                        if (!!deleteData && deleteData.length > 0)
                            this.onDelete(deleteData);
                        else
                            log.show("Update thành công!", true);
                    } else {
                        log.show("Update lỗi!", false);
                    }
                }.bind(this),
                error: function (xhr, status, err) {
                    console.log(err.toString());
                }

            });
        }
    },
  
    render: function () {
        var config = { id: "CODE", text: "NAME", parent: "PARENTCODE", idext: "EXTENSIONCODE" };
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