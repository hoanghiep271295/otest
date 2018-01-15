var PopupSearchSQL = React.createClass({
    getInitialState: function () {
        return {
            agGrid: { setRowData: null, getDataChange: null, setNextRow: null, setPrevRow: null },
            rowSelect: null,
            columnDefs: [
                { headerName: "Lệnh SQL", field: "NAME", width: 500, editable: false },
                { headerName: "Diễn giải", field: "NOTE", width: 500, editable: false }
            ],
            tab: null,
            page : 1,
        };
    },
    componentWillMount: function () {
        var tab = new Tab(false, 'popupsearchSQL', 'PopupSearchSQL', null, null, null, null, null, null, null);
        component.add('popupsearchSQL', this);
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
        var pageSize = $('#pageSize').val();
        if (isNaN(pageSize)) {
            pageSize = 0;
        }
        let page = this.state.page;
        var CODEVIEW = !!$('#CODESEARCH').val() ? $('#CODESEARCH').val() : null;
        var NAME = !!$('#NAMESEARCH').val() ? $('#NAMESEARCH').val() : null;
        var NOTE = !!$('#NOTESEARCH').val() ? $('#NOTESEARCH').val() : null;
        var postdata = {
            page: page,
            pageSize: pageSize,
            codeView: CODEVIEW,
            name: NAME,
            note: NOTE,
        };
        $.ajax({
            url: "/PopupSearchSQL/getList",
            dataType: 'json',
            data: postdata,
            success: function (data) {
                ret = data.data;
                if (!data.data) {
                    this.setState({ rowSelect : null });
                }                
                this.state.agGrid.setRowData(JSON.parse(data.data2));
                
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }
        });
        NProgress.done();
        return ret;
    },
    refreshRowData: function(){
        this.loadData();
    },
    componentDidMount: function () {
        this.loadData();
    },
    onRowSelect: function (itemSelect) {
        //console.log(itemSelect);
        this.setState({ rowSelect: itemSelect });
        if (itemSelect.length > 0)
        {$('#SQLNAME').val(itemSelect[0].NAME);
        $('#SQLNOTE').val(itemSelect[0].NOTE);
        }
            
    },
    render: function () {
        //var datasearch = this.state.dataSearch;
        //var listRow = [];
        //if (!!datasearch) {
        //    datasearch.forEach(function (item, index) {
        //         listRow.push(<Field title={item.title} id={item.id} type={item.type} key={index } />)
        //    });
        //}
        return (
            <div className="modal fade" id="ModalSearchSQL" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
              <div className="modal-dialog">
                <div className="modal-content">
                  <div className="modal-header">
                    <button type="button" className="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span className="sr-only">Close</span></button>
                    <h4 className="modal-title" id="myModalLabel">Lọc theo lệnh SQL</h4>
                  </div>
        
                    <div className="modal-body">
                            <form className="form-horizontal" role="form">
                                <div className="form-group">
                                   <label className="col-sm-2 control-label">Lệnh SQL</label>
                                   <div className="col-sm-10">
                                        <input className="form-control" id="SQLNAME" type="text"/> 
                                   </div>
                                </div>
                                <div className="form-group">
                                   <label className="col-sm-2 control-label">Diễn giải</label>
                                   <div className="col-sm-10">
                                        <input className="form-control" id="SQLNOTE" type="text"/> 
                                   </div>
                                </div>
                           </form>
                    
                            <div className="modal-footer">
                                <button type="button" className="btn btn-primary" onClick={this.state.searchSQL}>Kiểm tra</button>
                            </div>
                    
                            <div id="myGridSQL" className="ag-fresh" style={{width: '790px', height:'300px'}}>
                    
                            </div>
                            <AgGrid container='myGridSQL'
                                    initAgGrid={this.initAgGrid}
                                    loadData={this.loadData}
                                    onRowSelect={this.onRowSelect}
                                    columnDefs={this.state.columnDefs}
                                    headerCheckBox={false}>
                            </AgGrid>
                    </div>
                  
                  <div className="modal-footer">
                    <button type="button" className="btn btn-primary" onClick={this.state.search}>Tìm kiếm</button>
                    <button type="button" className="btn btn-danger" data-dismiss="modal">Đóng</button>
                  </div>
                </div>
              </div>
            </div>
        )
    },
});
