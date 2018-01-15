var StudentList = React.createClass({
    getInitialState: function() {
        return {
            agGrid: { setRowData: null, getDataChange: null, setNextRow: null, setPrevRow: null },
            rowSelect: null,
            //Định nghĩa các cột trên lưới
            columnDefs: [
                { headerName: "Mã", field: "CODEVIEW", width: 100, editable: false },
                { headerName: "Họ tên", field: "NAME", width: 300, editable: false },
                { headerName: "Ngày sinh", field: "THEORDER", width: 100, type: 'date' }
            ]
        }
    },
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

    componentWillMount: function () {
        
        
    },


    componentDidMount: function() {
        this.setState({ rowSelect: null });
        
    },
    shouldComponentUpdate: function (nextProps, nextState) {
        return nextProps.listStudent !== this.props.listStudent;
    },
    componentDidUpdate: function () {
        this.state.agGrid.setRowData(this.props.listStudent);
    },
    render: function () {
        
        return (
            <div>
              <div id="myGridSQ" className="ag-fresh" style={{width: '100%', height:'500px'}}>

              </div>
                    <AgGrid container='myGridSQ'
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
