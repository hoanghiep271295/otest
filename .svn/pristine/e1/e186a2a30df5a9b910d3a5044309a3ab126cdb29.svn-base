var DetailQGROUP = React.createClass({
    getInitialState: function () {
        return {
            agGrid: { setRowData: null, getDataChange: null, setNextRow: null, setPrevRow: null },
            rowSelect: null,
            columnDefs: [
                { headerName: "Mã hiển thị", field: "CODEVIEW", width: 100, editable: false },
                { headerName: "Tên", field: "NAME", width: 300, editable: false },
                { headerName: "Lock", field: "LOCK", width: 100, editable: false, type: 'checkbox' },
                { headerName: "Ghi chú", field: "NOTE", width: 400, editable: false }
            ],
            tab: null,
            page: 1,
            
        };
    },
    componentWillMount: function () {
        var tab = new Tab(true, 'detailQGROUP', 'Chi tiết nhóm câu hỏi', this.onNewClick, null, this.onDeleteClick, this.onNextClick, this.onPrevClick, null, this.onActive, this.onSearch, this.onSearchSQL);
        tab.pushToList();
        this.setState({ tab: tab });
        component.add('detailQGROUP', this);
    },
    initAgGrid: function (setRowData, getDataChange, setNextRow, setPrevRow) {
        var agGrid = {
            setRowData: setRowData,
            getDataChange: getDataChange,
            setNextRow: setNextRow,
            setPrevRow: setPrevRow
        };
        this.setState({ agGrid: agGrid });
    },
    loadData: function () {
        var ret;
        NProgress.start();
        var pageSize = $('#pageSizeClass').val();
        if (isNaN(pageSize)) {
            pageSize = 0;
        }
        let page = this.state.page;
        $.ajax({
            url: "/Class/getList",
            dataType: 'json',
            data: {
                gradecode: $('#hidGRADECODE').val(),
                page: page,
                pageSize: pageSize
            },
            success: function (data) {
                ret = data.data;
                if (!!data.data) {
                    this.setState({ rowSelect: null });
                }
                this.state.agGrid.setRowData(JSON.parse(data.data2));
                this.setDisplay(page, pageSize, data);
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }
        });
        NProgress.done();
        return ret;
    },
    setDisplay: function (page, pageSize, data) {
        //// set phần hiển thị số bản ghi
        //$("#startIndexClass").text((page - 1) * pageSize + 1);
        //if (page == data.totalPage) {
        //    $("#endIndexClass").text(data.totalItem);
        //} else
        //    $("#endIndexClass").text(page * pageSize);
        //$("#totalItemClass").text(data.totalItem);
        //// disable nút <,>
        //if (page == 1)
        //    $("#prePageClass").prop('disabled', true);
        //else
        //    $("#prePageClass").prop('disabled', false);
        //if (page == data.totalPage)
        //    $("#nextPageClass").prop('disabled', true);
        //else
        //    $("#nextPageClass").prop('disabled', false);
    },
    setData: function (data) {
        //if (!!data) {
        //    $('#CODE_CLASS').val(data.CODE);
        //    $('#CODEVIEW_CLASS').val(data.CODEVIEW);
        //    $('#NAME_CLASS').val(data.NAME);
        //    $('#LOCK_CLASS').prop('checked', data.LOCK);
        //    $('#NOTE_CLASS').val(data.NOTE);
        //    $('#AMOUNT').val(data.AMOUNT);
        //    $('#DEPARTMENTCODE').val(data.DEPARTMENTCODE);
        //    $('#DEPARTMENTCODE2').val(data.DEPARTMENTCODE2);
        //}
        //else {
        //    this.clearData();
        //}
    },
    clearData: function () {
    //    $('#CODE_CLASS').val("");
    //    $('#CODEVIEW_CLASS').val("");
    //    $('#NAME_CLASS').val("");
    //    $('#LOCK_CLASS').prop('checked', false);
    //    $('#NOTE_CLASS').val("");
    //    $('#AMOUNT').val('0');
    //    $('#DEPARTMENTCODE').val('');
    //    $('#DEPARTMENTCODE2').val('');
    //},
    //onNewClick: function () {
    //    $('#NewModalClass').modal('show');
    //    var rowSelect = this.state.rowSelect;
    //    if (!!rowSelect && !!rowSelect[0]) {
    //        this.setData(rowSelect[0]);
    //    } else
    //        this.clearData();
    },
    onDeleteClick: function () {
        //if (!!this.state.rowSelect) {
        //    var data = [];
        //    this.state.rowSelect.forEach(function (item, index) {
        //        data.push(item.CODE);
        //    });
        //    var id = { code: data };
        //    $.ajax({
        //        url: "/Class/delete",
        //        type: "POST",
        //        dataType: "json",
        //        traditional: true,
        //        data: id,
        //        success: function (data) {
        //            if (data.ret >= 0) {
        //                this.refreshRowData();
        //                alert('>> Success! <<');
        //            }
        //        }.bind(this),
        //        error: function (xhr, status, err) {
        //            console.log(err.toString());
        //        }
        //    });
        //}
    },

    onNextClick: function () {
        //!!this.state.rowSelect && this.state.agGrid.setNextRow(this.state.rowSelect[0]);
        //setTimeout(function () {
        //    this.setData(this.state.rowSelect[0]);
        //}.bind(this), 200);
        var listQGROUP = component.get('listQGROUP');
        listQGROUP.onNextClick();
        var rowSelect = listQGROUP.state.rowSelect;
        //this.loadData();
        $('#pageSizeClass').val(20);
        $('#gradecode').text(rowSelect[0].CODEVIEW);
        $('#gradename').text(rowSelect[0].NAME);
    },
    onPrevClick: function () {
        //!!this.state.rowSelect && this.state.agGrid.setPrevRow(this.state.rowSelect[0]);
        //setTimeout(function () {
        //    this.setData(this.state.rowSelect[0]);
        //}.bind(this), 200);
        var listQGROUP = component.get('listQGROUP');
        listQGROUP.onPrevClick();
        var rowSelect = listQGROUP.state.rowSelect;
        //this.loadData();
        $('#pageSizeClass').val(20);
        $('#gradecode').text(rowSelect[0].CODEVIEW);
        $('#gradename').text(rowSelect[0].NAME);
    },
    onKeyUp: function (event) {
        //var keypressed = event.keyCode || event.which;
        //if (keypressed == 13) {
        //    this.setState({ page: 1 });
        //    setTimeout(function () {
        //        this.loadData();
        //    }.bind(this), 200);
        //}
    },
    onRowSelect: function (itemSelect) {
        //this.setState({ rowSelect: itemSelect });
    },
    onActive: function () {
        dataSearch = [
                { title: 'Mã', id: 'CODESEARCH', type: 'text' },
                { title: 'Tên', id: 'NAMESEARCH', type: 'text' },
                { title: 'Ghi chú', id: 'NOTESEARCH', type: 'text' },
        ];
        console.log(component.get('app'));
        var app = component.get('app');
        app.setState({ dataSearch: dataSearch });

        this.loadData();
        var listQGROUP = component.get('listQGROUP');
        var rowSelect = listQGROUP.state.rowSelect;
        //this.loadData();
        $('#pageSizeClass').val(20);
        $('#gradecode').text(rowSelect[0].CODEVIEW);
        $('#gradename').text(rowSelect[0].NAME);
    },
    onSearch: function () {
        $('#ModalSearchClass').modal('show');
        console.log('Search class');
    },
    onSearchSQL: function () {

    },
    prePage: function () {
        //this.setState({ page: this.state.page - 1 });
        //setTimeout(function () {
        //    this.loadData();
        //}.bind(this), 200);
    },
    nextPage: function () {
        //this.setState({ page: this.state.page + 1 });
        //setTimeout(function () {
        //    this.loadData();
        //}.bind(this), 200);
    },

    refreshRowData: function () {
        this.loadData();
    },
    render: function () {
        return (
           <div id="detailQGROUP" className="tab-pane fade in">
               
               
               <div className="table-before">
                    <div>
                        <div>
                            <span id='gradecode'></span>
                        </div>
                        -
                        <div>
                            <span id='gradename'></span>
                        </div>
                    </div>
                   </div>
        </div>
            )
},
});
