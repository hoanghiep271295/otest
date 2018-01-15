﻿var LeveltitleList = React.createClass( {
    getInitialState: function() {
        return {
            //Phục vụ cho lưới
            agGrid: { setRowData: null, getDataChange: null, setNextRow: null, setPrevRow: null },
            rowSelect: null,
            //Định nghĩa các cột trên lưới
            columnDefs: [
                { headerName: "Mã", field: "CODEVIEW", width: 100, editable: false },
                { headerName: "Tên", field: "NAME", width: 350, editable: false },
            //    { headerName: "Thứ tự", field: "THEORDER", width: 100, align: 'center', editable: false },
                 { headerName: "Hiển thị", field: "LOCK", width: 100, editable: false, type: 'invcheckbox' },
                 { headerName: "Thứ tự", field: "THEORDER", width: 100, align: 'center', editable: false },
                 { headerName: "Mức", field: "COMPARELEVEL", width: 100, align: 'center', editable: false },
                { headerName: "Ghi chú", field: "NOTE", width: 200, align: 'center', editable: false },
            ],
            buts:[{ ref: 'cmdAdd', callback: this.onNewClick }
                         , { ref: 'cmdEdit', callback: this.onEditClick }
                         , { ref: 'cmdDelete', callback: this.onDeleteClick }
                         , { ref: 'cmdRefresh', callback: this.Refresh }
                         , { ref: 'cmdSearch', callback: this.onSearch }
            //             , { ref: 'cmdSearchSQL', callback: this.onSearchSQL }
                         , { ref: 'cmdPrint', callback: this.onPrint }
            ],
            searchstatus: [],
            loaded: null, //Kiểm tra chỉ load dữ liệu lần đầu tiên
            popup: null
        };
    },
    componentWillMount:function()
    {
    },

    componentDidMount: function () {
        this.setState({ popup: this.refs[this.props.id + '_Popup'] });
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

    /**
* Thực thao tác khi tab này được chọn - đối tượng parent (this.props.parent) truy xuất đến đối tượng cha đã gọi đối tượng này dùng để truy xuất thông tin chung trong các hệ thống (xem hàm dùng chung trong _shared/TabHeader.jsx)
*/
    onActive: function (parent) {
        if (this.state.loaded === null) {
            this.loadData();
            this.setState({ loaded: true });//Có thể là giá trị khác để kiểm tra
        }
    },

    /**
*Khi chọn một bản ghi đưa vào vùng chọn hiện tại
*/
    onRowSelect: function (itemSelect) {
        //        console.log('RowSelect:', itemSelect);
        if (!!itemSelect && itemSelect.length > 0) {
            this.setState({ rowSelect: itemSelect });
            //Lưu dữ liệu về bản ghi đang được chọn
            //            this.props.parent.setKeyValue('admingroupCode', { CODE: itemSelect[0].CODE, NAME: itemSelect[0].NAME });
        }

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
//        console.log('Reload and choose this:',obj);
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
    loadData: function (obj, selectobject) {
        //        console.log('List-loadData:', new Date());
        var ret;
        var that = this;
        //        window.NProgress.start();
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
        if (!isMiss(obj)) {
            if (!isMiss(obj.CODESEARCH)) {
                code = obj.CODESEARCH.value;
                codetype = obj.CODESEARCH.type;
            }
            if (!isMiss(obj.NAMESEARCH)) {
                name = obj.NAMESEARCH.value;
                nametype = obj.NAMESEARCH.type;
            }
            if (!isMiss(obj.NAMESEARCH)) {
                note = obj.NOTESEARCH.value;
                notetype = obj.NOTESEARCH.type;
            }
        }
        $.ajax({
            url: "/leveltitle/getAllSearch",
            dataType: 'json',
            data: {
                page: page
                , pageSize: pageSize
                , code: code
                , thetype: codetype
                , name: name
                , nametype: nametype
                , note: note
                , notetype: notetype
            },
            success: function (data) {
                if (data.ret>=0) {
                    this.setState({ rowSelect: null });
                }
                this.state.agGrid.setRowData(data.lst);//JSON.parse(data.data2));
                if (!isMiss(selectobject)) {
                    that.state.agGrid.setSelect(selectobject);
                }
                //                this.setDisplay(page, pageSize, data);
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

        var obj = { };
        //gọi hàm từ trong đối tượng popup form để thiết lập tham số, sau đó hiển thị
        console.log(this.state.popup);
        this.state.popup.ClearInput(obj);
        this.state.popup.Show();

    },
    /**
    *Hàm thực hiện khi sửa bản ghi
    */
    onEditClick: function () {
        if (this.state.rowSelect.length != 1)
        {
            bootbox.alert('Chưa chọn bản ghi hoặc nhiều hơn một bản ghi');
        }
        else
        {
            var currentobj = this.state.rowSelect[0];
            var obj = { NAME: currentobj.NAME
                        , CODE: currentobj.CODE
                        , NOTE: currentobj.NOTE
                        , CODEVIEW: currentobj.CODEVIEW
                        , LOCK: currentobj.LOCK
                        , THEORDER: currentobj.THEORDER
                        , COMPARELEVEL: currentobj.COMPARELEVEL
            };
            //gọi hàm từ trong đối tượng popup form để thiết lập tham số, sau đó hiển thị
            this.state.popup.SetInput(obj);
            this.state.popup.Show();
//            console.log(obj);
        }

    },
    /**
    *gọi khi click vào nút xóa
    */
    onDeleteClick: function () {
        var that = this;
        if (!this.state.rowSelect) {
            bootbox.alert("Chưa chọn bản ghi");
            return false;
        }
        if (this.state.rowSelect.length == 0) {
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
            var postData = { code: data };
            $.ajax({
                url: "/leveltitle/delete",
                type: "POST",
                dataType: "json",
                traditional: true,
                data: postData,
                success: function (data) {
                    if (data.ret >= 0) {
                        this.ReloadListDelete();
                    }
                    else {
                        if (data.ret == -2) {
                            bootbox.alert("Bản ghi có tham chiếu, cần xóa các menu con trước!", false);
                        }
                        else {
                            bootbox.alert("Lỗi khi xóa dữ liệu!", false);
                        }
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
                           ,{ title: 'Ghi chú', id: 'NOTESEARCH', type: 'text' }
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
//        console.log('search based on:', obj.CODESEARCH, obj.NAMESEARCH, obj.NOTESEARCH);
        this.setState({ searchstatus: obj });
        this.loadData(obj);
    },
    /**
*Xử lý tìm kiếm nâng cao
*/
    onSearchSQL: function () {
//        console.log("search SQL SKILL");
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
        var NOTE = currentobj.NOTE
        var typeNote = false;

        var parameter = "code=" + this.state.currentcode + "&reporttype=Religion";
        open("/report/reporting.aspx?" + parameter);
    }
    ,
    render: function () {
        return (
                <div id={this.props.id+'_list'} className="tab-pane fade in active ">
                    {/*Cần phải gán ref để truy xuất đến đối tượng này*/}
                                       <LeveltitlePopup setData={this.setData} onPre={this.onPrevClick} onNext={this.onNextClick} ReloadData={this.ReloadList} ref={this.props.id+'_Popup'} id={this.props.id+'_Popup'} />
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