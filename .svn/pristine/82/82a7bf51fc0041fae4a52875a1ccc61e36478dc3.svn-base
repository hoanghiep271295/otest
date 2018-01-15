var ExamHallStudentList = React.createClass( {
    getInitialState: function() {
        return {
            //Phục vụ cho lưới
            agGrid: { setRowData: null, getDataChange: null, setNextRow: null, setPrevRow: null },
            rowSelect: null,
            //Định nghĩa các cột trên lưới
            columnDefs: [
                 { headerName: "Mã sinh viên", field: "CODEVIEW", width: 100, editable: false },
                 { headerName: "Tên sinh viên", field: "NAME", width: 250, editable: false },
                 { headerName: "Ngày sinh", field: "BIRTHDAY", width: 100, editable: false, type: 'date' },
               //   { headerName: "Đề thi", field: "EXAMFORMNAME", width: 100, editable: false }
            ],
            searchstatus: [],
            loaded: null, //Kiểm tra chỉ load dữ liệu lần đầu tiêns
            parentinfo: null,
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
       // this.loadData();

    },
    
    /**
    *Hàm thiết lập cho lưới
    */
    initAgGrid: function (setRowData, getDataChange, setNextRow, setPrevRow, setSelect) {
        var agGrid = {
            setRowData: setRowData,
            getDataChange: getDataChange,
            setNextRow: setNextRow,
            setPrevRow: setPrevRow,
            setSelect: setSelect
        };
        this.setState({ agGrid: agGrid });
    },
    //Thêm bắt buộc so với cái cũ -
    /**
    *Danh sách các nút lệnh - để tương tác do cha củađối tượng này gọi (xem hàm dùng chung trong _shared/TabHeader.jsx, ButtonList.jsx )
    */
    registerButton: function () {
        var obj = Object();
        //Đầy đủ nếu nó không thuộc các nhóm mặc định: { ref: 'cmdNew', callback: this.onPrint,title:'Hello',icon:'',tooltip:'Không rõ'}
        obj = [
            //   { ref: 'cmdAdd', callback: this.onNewClick }
           //, { ref: 'cmdSearchSQL', callback: this.onSearchSQL }
             , { ref: 'cmdPrint', callback: this.onPrint }
             , { ref: 'cmdSearch', callback: this.onSearch }
            // , { ref: 'cmdEdit', callback: this.onEditClick }
          //   , { ref: 'cmdDelete', callback: this.onDeleteClick }
             , { ref: 'cmdRefresh', callback: this.Refresh }
        ];
        return obj;
    },
   
    /**
* Thực thao tác khi tab này được chọn - đối tượng parent (this.props.parent) truy xuất đến đối tượng cha đã gọi đối tượng này dùng để truy xuất thông tin chung trong các hệ thống (xem hàm dùng chung trong _shared/TabHeader.jsx)
*/
    onActive: function () {

        var that = this;
        var examhall = this.props.parent.getKeyValue('examhall');
        var examtime = this.props.parent.getKeyValue('examtime');
        if (isMiss(examhall)) {
            // kiểm tra xem đã chọn đợt hay chưa
            var objGrade = this.props.parent.getKeyValue('examtime');
            if (isMiss(examtime)) {
                // thông báo về trang cha
                bootbox.alert("Chưa chọn đợt thi", function () { that.props.parent.ChooseTab('examtime') });
                return;
            }
            // thông báo về trang cha
            bootbox.alert("Chưa chọn phòng thi", function () { that.props.parent.ChooseTab('examhall') });
            return;
        }
        if (this.state.loaded === null || this.state.parentinfo !== examhall) {
            this.setState({ parentinfo: examhall });//Trường hợp có thay đổi thì nhận lại mã mới
            this.loadData();
            this.setState({ loaded: true });//Có thể là giá trị khác để kiểm tra

            //Gán lại tiêu đề lớn - cộng với tên nhóm
        }
        if (!!examhall)
            this.props.parent.setParentTitle(this.props.parentTitle + '(' + examhall[0].NAME + ')');
    },
    loadCourse: function (subjectcode) {
        $.ajax({
            url: '/Course/GetAll',
            dataType: 'json',
            data: { subjectcode: subjectcode },
            success: function (data) {
                //    this.loadData(data.classDefault.GRADECODE, data.classDefault.CODE);
                if (data.ret >= 0) {
                    this.setState({ listCourse: data.lst });   
                }

            }.bind(this),
            error: function (xhr, status, err) {
                console.error('URLNAYODAU', status, err.toString());
            }.bind(this)
        });
    },
    /**
*Khi chọn một bản ghi đưa vào vùng chọn hiện tại
*/
    onRowSelect: function (itemSelect) {

        //        console.log('RowSelect:', itemSelect);
        if (!!itemSelect && itemSelect.length > 0) {
            this.setState({ rowSelect: itemSelect });
        }
        //this.props.parent.setKeyValue('examform', null);
        //this.props.parent.setKeyValue('examhall', null);
        //this.props.parent.setKeyValue('examhallstudent', null);
        //this.props.parent.setKeyValue('examtime', itemSelect);

    },
    /**
*Lấy lại toàn bộ dữ liệu
*/
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
        var examhallcode = this.props.parent.getKeyValue('examhall')[0].CODE;
        var ret;
        $.ajax({
            url: "/ExamHallStudent/GetList",
            dataType: 'json',
            data: {
                examhallcode: examhallcode
            },
            success: function (data) {
                if (data.ret >= 0) {
                    this.setState({ rowSelect: null });
                    var lst = [];
                    if (data.lst.length > 0) {
                        data.lst.forEach(function (item, key) {
                            var obj = new Object();;
                            obj.EXAMHALLSTUDENTCODE = item[0].Value;
                            obj.CODEVIEW = item[1].Value;
                            obj.NAME = item[2].Value;
                            obj.BIRTHDAY = item[3].Value;
                            obj.REALBEGINTIME = item[4].Value;
                            obj.REALENDTIME = item[5].Value;
                            obj.EXAMFORMCODE = item[6].Value;
                            obj.LOCK = item[7].Value;
                            obj.FINALENDTIME = item[8].Value;
                            lst.push(obj);
                        });
                    }
                    this.state.agGrid.setRowData(lst);
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }
        });
        //window.NProgress.done();
        return ret;
    },
    /**
    *Hàm thực hiện khi chọn nút thêm mới (được quy định trong danh sách nút)
    */
    onNewClick: function () {
        
        this.state.popup.Show();

    },
    onEditClick: function () {
        if (this.state.rowSelect === null) {
            bootbox.alert('Chưa chọn bản ghi hoặc nhiều hơn một bản ghi');
        }
        else {
            var currentobj = this.state.rowSelect[0];
            var obj = {
                NAME: currentobj.NAME
                        , CODE: currentobj.CODE
                        , NOTE: currentobj.NOTE
                        , CODEVIEW: currentobj.CODEVIEW
                        , LOCK: currentobj.LOCK
                        , YEAR: currentobj.YEAR
                        , TERM: currentobj.TERM
                        , TESTSTRUCTCODE: currentobj.TESTSTRUCTCODE
            };
            //gọi hàm từ trong đối tượng popup form để thiết lập tham số, sau đó hiển thị
            this.state.popup.SetInput(obj);
            this.state.popup.Show();
            //            console.log(obj);
        }

    },
    onDeleteClick: function () {
        var that = this;
        if (!this.state.rowSelect) {
            bootbox.alert("Chưa chọn bản ghi");
            return false;
        }
        if (this.state.rowSelect.length === 0) {
            bootbox.alert("Chưa chọn bản ghi");
            return false;
        }
        //  confirm.show(null,this.handDelete,null);
        bootbox.confirm({
            message: "Xóa các bản ghi được lựa chọn ?",
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn btn-danger'
                },
                cancel: {
                    label: 'No',
                    className: 'btn btn-default'
                }
            },
            callback: function (result) {
                if (result) {
                    that.handDelete();
                }
                else {
                    console.log("No items have been deleted", true);
                }
            }
        });

        //// confirm.show(null,this.handDelete,null);
    },
    /**
    *Thực hiện thao tác xóa
    */
    handDelete: function () {
        if (!!this.state.rowSelect) {
            var data = [];
            this.state.rowSelect.forEach(function (item) {
                data.push(item.CODE);
            });
            var postData = { listCode: data };
            $.ajax({
                url: "/Examhallstudent/delete",
                type: "POST",
                dataType: "json",
                traditional: true,
                data: postData,
                success: function (data) {
                    if (data.ret >= 0) {
                        this.ReloadListDelete();
                    }
                    else {
                        bootbox.alert("Bản ghi có tham chiếu, cần xóa các menu con trước!", false);

                    }
                }.bind(this),
                error: function (xhr, status, err) {
                    console.log(err.toString());
                }
            });
        }
        else {
            bootbox.alert("Không có bản ghi nào!", false);
        }
    },

    /**
 * Xử lý nút lệnh tìm kiếm
 */
    onSearch: function () {
        //$('#ModalSearchSkill').modal('show');
        //console.log('Search skill');
        var dataSearch = [
                           { title: 'Mã', id: 'CODESEARCH', type: 'text' }
                           , { title: 'Tên', id: 'NAMESEARCH', type: 'text' }
                           , { title: 'Ghi chú', id: 'NOTESEARCH', type: 'text' }
                           , { title: 'Năm học', id: 'YEAR', type: 'number' }
        ];
        obj = this.state.searchstatus;//Dữ liệu mặc định
        this.props.parent.ShowSearch(this.props.id + '_search', dataSearch, obj, this.doSearch);
        //        console.log('Gọi tìm kiếm');
    },
    /**
    * Xử lý lời gọi search - dựa tren id đã được gửi để lấy dữ liệu về
    */
    doSearch: function (obj) {
        //obj dữ liệu lấy về
        //obj dữ liệu lấy về
        //        console.log('search based on:', obj.CODESEARCH, obj.NAMESEARCH, obj.NOTESEARCH);
        this.setState({ searchstatus: obj });
        this.loadData(obj);
    },
    /**
*Xử lý tìm kiếm nâng cao
*/
    onSearchSQL: function () {
        // console.log("search SQL SKILL");
    },
    /**
   *Lấy lại toàn bộ dữ liệu được gọi bởi popup - với đối tượng vào để xử lý phù hợp
   */
    onPrint: function () {
        //bootbox.alert('In ấn ở đây');
        //this.props.parent.setButtonStatus('cmdDelete', true);
        //this.props.parent.setButtonStatus('cmdSearch', false);
        var currentobj = this.state.rowSelect[0];
        var CODEVIEW = currentobj.CODEVIEW;
        var typeCodeView = false;
        var NAME = currentobj.NAME;
        var typeName = false;
        var NOTE = currentobj.NOTE;
        var typeNote = false;

        var parameter = "code=" + this.state.currentcode + "&reporttype=TestStruct";
        open("/report/reporting.aspx?" + parameter);
    }
    ,
    render: function () {
        var listCourse = this.props.parent.getKeyValue('listCourse');
        return (
                <div id={this.props.id+'_list'} className="tab-pane fade in active ">{/*Cần phải gán ref để truy xuất đến đối tượng này*/}
                 <ExamHallStudentPopup setData={this.setData} onPre={this.onPrevClick} onNext={this.onNextClick} ReloadData={this.ReloadList} ref={this.props.id+'_Popup'} id={this.props.id+'_Popup'} listCourse={listCourse} app={this.props.parent} />
                <div id={this.props.id+'_grid'} className="ag-fresh customgrid">
                </div>
                    <AgGrid container={this.props.id+'_grid'}
initAgGrid={this.initAgGrid}
loadData={this.loadData}
onRowSelect={this.onRowSelect}
columnDefs={this.state.columnDefs}
headerCheckBox={true}>
</AgGrid>
</div>


);
}

} );

////----------------
//ReactDOM.render(
//<TestStructList />,
//document.getElementById('container')
//);