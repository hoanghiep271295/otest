var ExamTimeList = React.createClass({
    getInitialState: function() {
        return {
            //Phục vụ cho lưới
            agGrid: { setRowData: null, getDataChange: null, setNextRow: null, setPrevRow: null },
            rowSelect: null,
            //Định nghĩa các cột trên lưới
            columnDefs: [
                { headerName: "Mã", field: "CODEVIEW", width: 100, editable: false },
                { headerName: "Tên", field: "NAME", width: 200, editable: false },
                { headerName: "Học kỳ", field: "TERM", width: 100, editable: false },
                { headerName: "Năm học", field: "YEAR", width: 100, editable: false },
                { headerName: "Số đề", field: "TESTCOUNT", width: 100, editable: false },
                { headerName: "Hiển thị", field: "LOCK", width: 100, editable: false, type: 'invcheckbox' },
                { headerName: "Ghi chú", field: "NOTE", width: 250, align: 'center', editable: false },
            ],
            searchstatus: [],
            listTestStruct: [],
            loaded: null, //Kiểm tra chỉ load dữ liệu lần đầu tiên
            currentSubjectCode: null,
            popup: null,
            page: 1
        };
    },
    componentWillMount: function() {

    },
    componentDidMount: function() {
        //Lấy giá trị của popup dùng về sau
        this.setState({ popup: this.refs[this.props.id + '_Popup'] });


    },
    getTestStuct: function() {
        // get contentype by id
        $.ajax({
            url: "/TestStruct/GetAll",
            dataType: 'json',
            type: 'POST',
            data: {
                subjectCode: this.props.parent.getKeyValue("subjectcode")
            },
            success: function(data) {
                if (data.ret >= 0) {
                    this.setState({ listTestStruct: data.liTestStruct });
                }
            }.bind(this),
            error: function(xhr, status, err) {
                console.log(err.toString());
            }
        });
    },
    /**
    *Hàm thiết lập cho lưới
    */
    initAgGrid: function(setRowData, getDataChange, setNextRow, setPrevRow, setSelect) {
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
    registerButton: function() {
        var obj = Object();
        //Đầy đủ nếu nó không thuộc các nhóm mặc định: { ref: 'cmdNew', callback: this.onPrint,title:'Hello',icon:'',tooltip:'Không rõ'}
        obj = [
           // { ref: 'cmdAdd', callback: this.onNewClick }
//             , { ref: 'cmdSearchSQL', callback: this.onSearchSQL }
            , { ref: 'cmdPrint', callback: this.onPrint }, { ref: 'cmdSearch', callback: this.onSearch },
        //    { ref: 'cmdEdit', callback: this.onEditClick }, { ref: 'cmdDelete', callback: this.onDeleteClick },
            { ref: 'cmdRefresh', callback: this.Refresh }
        ];
        return obj;
    },
    /**
* Thực thao tác khi tab này được chọn - đối tượng parent (this.props.parent) truy xuất đến đối tượng cha đã gọi đối tượng này dùng để truy xuất thông tin chung trong các hệ thống (xem hàm dùng chung trong _shared/TabHeader.jsx)
*/
    onActive: function(parent) {
        //Chỉ load lại dữ liệu khi lần đầu - nếu phụ thuộc xem trong admingrouplist/admingrouppriority
        var subbjectcode = this.props.parent.getKeyValue("subjectcode");

        if (this.state.loaded === null || this.state.currentSubjectCode !== subbjectcode) {

            this.loadData();
            this.getTestStuct();
            this.setState({ loaded: true }); //Có thể là giá trị khác để kiểm tra
            var subjectcode = this.props.parent.getKeyValue("subjectcode");
            this.setState({ currentSubjectCode: subjectcode });
        }
    },

    /**
*Khi chọn một bản ghi đưa vào vùng chọn hiện tại
*/
    onRowSelect: function(itemSelect) {

//        console.log('RowSelect:', itemSelect);
        if (!!itemSelect && itemSelect.length > 0) {
            this.setState({ rowSelect: itemSelect });
        }
        this.props.parent.setKeyValue('examform', null);
        this.props.parent.setKeyValue('examhall', null);
        this.props.parent.setKeyValue('examhallstudent', null);
        this.props.parent.setKeyValue('examtime', itemSelect);

    },
    /**
*Lấy lại toàn bộ dữ liệu
*/
    Refresh: function() {
        this.loadData(this.state.searchstatus, this.state.rowSelect[0]);
    },
    /**
    *Lấy lại toàn bộ dữ liệu được gọi bởi popup - với đối tượng vào để xử lý phù hợp
    */
    ReloadList: function(obj) {
        //Mặc định theo giá trị tìm kiếm hiện tại, thiết lập theo bản ghi hiện tại
        this.loadData(this.state.searchstatus, obj);

    },
    /**
    * Cập nhật lại thông tin sau khi gọi xóa dữ liệu thành công
    */
    ReloadListDelete: function() {
        //cập nhật lại danh sách
        this.loadData(); //(this.state.currentcode);
    },
    /**
* Lấy dữ liệu
*/
    loadData: function(obj, selectobject) {
        var subjectcode = this.props.parent.getKeyValue("subjectcode");
        var ret;
        var that = this;
        var pageSize = $('#pageSize').val();
        if (isNaN(pageSize)) {
            pageSize = 0;
        }
        var page = this.state.page;
        if (isMiss(obj)) {
            obj = this.state.searchstatus;
        }
        var code = '';
        var codetype = false;
        var name = '';
        var nametype = false;
        var note = '';
        var notetype = false;
        var year = '';
        //Truyền các tham số tìm kiếm
        if (!!obj.CODESEARCH) {
            code = obj.CODESEARCH.value;
            codetype = obj.CODESEARCH.type;
        }
        if (!!obj.NAMESEARCH) {
            name = obj.NAMESEARCH.value;
            nametype = obj.NAMESEARCH.type;
        }
        if (!!obj.NOTESEARCH) {
            note = obj.NOTESEARCH.value;
            notetype = obj.NOTESEARCH.type;
        }
        if (!!obj.YEAR) {
            year = obj.YEAR.value;
        }
        $.ajax({
            url: "/Examtime/getAllSearch",
            dataType: 'json',
            data: {
                page: page,
                pageSize: pageSize,
                subjectcode: subjectcode,
                code: code,
                codetype: codetype,
                name: name,
                nametype: nametype,
                note: note,
                notetype: notetype,
                year: year
            },
            success: function(data) {
                if (data.ret >= 0) {
                    this.setState({ rowSelect: null });
                }
                this.state.agGrid.setRowData(data.lst); //JSON.parse(data.data2));
                if (!isMiss(selectobject)) {
                    that.state.agGrid.setSelect(selectobject);
                }
                //                this.setDisplay(page, pageSize, data);
            }.bind(this),
            error: function(xhr, status, err) {
                console.log(err.toString());
            }
        });
        //window.NProgress.done();
        return ret;
    },


    /**
 * Xử lý nút lệnh tìm kiếm
 */
    onSearch: function() {
        //$('#ModalSearchSkill').modal('show');
        //console.log('Search skill');
        var dataSearch = [
            { title: 'Mã', id: 'CODESEARCH', type: 'text' }, { title: 'Tên', id: 'NAMESEARCH', type: 'text' },
            { title: 'Ghi chú', id: 'NOTESEARCH', type: 'text' }, { title: 'Năm học', id: 'YEAR', type: 'number' }
        ];
       var obj = this.state.searchstatus; //Dữ liệu mặc định
        this.props.parent.ShowSearch(this.props.id + '_search', dataSearch, obj, this.doSearch);
//        console.log('Gọi tìm kiếm');
    },
    /**
    * Xử lý lời gọi search - dựa tren id đã được gửi để lấy dữ liệu về
    */
    doSearch: function(obj) {
        //obj dữ liệu lấy về
        //obj dữ liệu lấy về
//        console.log('search based on:', obj.CODESEARCH, obj.NAMESEARCH, obj.NOTESEARCH);
        this.setState({ searchstatus: obj });
        this.loadData(obj);
    },
    /**
*Xử lý tìm kiếm nâng cao
*/
    onSearchSQL: function() {
        // console.log("search SQL SKILL");
    },
    /**
   *Lấy lại toàn bộ dữ liệu được gọi bởi popup - với đối tượng vào để xử lý phù hợp
   */
    onPrint: function() {
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

        var parameter = "code=" + this.state.currentcode + "&reporttype=ExamTime";
        open("/report/reporting.aspx?" + parameter);
    },
    render: function() {
        return (
            <div id={this.props.id +'_list'} className="tab-pane fade in active ">
                <div id={this.props.id + '_grid'} className="ag-fresh customgrid">
                </div>
                <AgGrid container={this.props.id + '_grid'}
                        initAgGrid={this.initAgGrid}
                        loadData={this.loadData}
                        onRowSelect={this.onRowSelect}
                        columnDefs={this.state.columnDefs}
                        headerCheckBox={true}>
                </AgGrid>
            </div>
        );
    }
});

////----------------
//ReactDOM.render(
//<TestStructList />,
//document.getElementById('container')
//);