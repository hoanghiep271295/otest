var AgGrid = React.createClass({
    getInitialState: function () {
        //        console.log('Grid width:', $('#' + this.props.container));
        var initColDefs = this.calColumn();
        return {
            data: null,
            dataCopy: null,
            gridOptions: null,
            columnDefs: initColDefs,

            editList: [],
            removeList: [],
            newList: []
        }
    },
    calColumn:function()
    {
        var initColDefs = [];
        //        console.log('Grid with check:',this.props.headerCheckBox);
        !!this.props.headerCheckBox && initColDefs.push({ headerName: '', field: '', width: 28, editable: false, checkboxSelection: true, headerCheckboxSelection: true });
        //        console.log('Set check:',initColDefs);
        for (var i = 0; i < this.props.columnDefs.length; i++) {
            var obj = new Object();

            obj['headerName'] = this.props.columnDefs[i]['headerName'];
            obj['field'] = this.props.columnDefs[i]['field'];

            obj['width'] = parseInt(this.props.columnDefs[i]['width']);
            obj['editable'] = this.props.columnDefs[i]['editable'];

            if (this.props.columnDefs[i]['type'] === 'number') {
                obj['filter'] = 'number';
                obj['cellEditor'] = this.Number;

            }
            if (this.props.columnDefs[i]['type'] === 'checkbox') {
                obj['editable'] = false;
                obj['cellRenderer'] = this.CellRenderCheckbox;
                obj['cellStyle'] = { display: 'flex', 'align-items': 'center', 'justifyContent': 'center' };
            }
            if (this.props.columnDefs[i]['type'] === 'invcheckbox') {
                obj['editable'] = false;
                obj['cellRenderer'] = this.CellRenderInvCheckbox;
                obj['cellStyle'] = { display: 'flex', 'align-items': 'center', 'justifyContent': 'center' };
            }
            if (this.props.columnDefs[i]['type'] === 'date') {
                obj['cellFormatter'] = this.Datepicker;
            }
            if (this.props.columnDefs[i]['type'] === 'datetime') {
                obj['cellFormatter'] = this.Datetimepicker;
            }
            if (this.props.columnDefs[i]['type'] === 'option') {
                obj['select'] = this.props.columnDefs[i]['select'];
                obj['cellRenderer'] = this.CellRenderSelect;
                obj['cellStyle'] = { display: 'flex', 'align-items': 'center', 'justifyContent': 'center' };
                obj['valueType'] = this.props.columnDefs[i]['valueType'];
            }
            if (this.props.columnDefs[i]['type'] === 'button') {
                obj['button'] = this.props.columnDefs[i]['button'];
                obj['cellRenderer'] = this.CellRenderButton;
                obj['cellStyle'] = { display: 'flex', 'align-items': 'center', 'justifyContent': 'center' };
            }
            initColDefs.push(obj);
        }
        return initColDefs;
    },
    CellRenderCheckbox: function (params) {

        var checkbox = document.createElement("input");
        checkbox.type = "checkbox";
        checkbox.checked = params.value;
        checkbox.addEventListener('click', function () {
            //console.log(checkbox.checked);
            params.node.data[params.colDef.field] = checkbox.checked ? 1 : 0;
            this.state.gridOptions.api.refreshRows(params.note);
            this.Change(params.node.data);
        }.bind(this));
        return checkbox;
    },
    CellRenderInvCheckbox: function (params) {

        var checkbox = document.createElement("input");
        checkbox.type = "checkbox";
        checkbox.checked = !(params.value);
        checkbox.addEventListener('click', function () {
            //console.log(checkbox.checked);
            params.node.data[params.colDef.field] = checkbox.checked ? 0 : 1;
            this.state.gridOptions.api.refreshRows(params.note);
            this.Change(params.node.data);
        }.bind(this));
        return checkbox;
    },
    onCellClickedCheckbox: function (params) {
        params.node.data[params.colDef.field] = !params.node.data[params.colDef.field];
        params.node.data[params.colDef.field] = params.node.data[params.colDef.field] ? 1 : 0;
        this.state.gridOptions.api.refreshRows(params.note);
    },
    CellRenderSelect: function (params) {
        var select = document.createElement("select");
        for (var i = 0; i < params.colDef['select'].length; i++) {
            var option = document.createElement('option');
            option.text = params.colDef['select'][i].text;
            option.value = params.colDef['select'][i].value;
            select.appendChild(option);
        }
        select.value = params.value;
        select.addEventListener('change', function () {
            if (params.colDef.valueType === 'int') params.node.data[params.colDef.field] = parseInt(select.value);
            if (params.colDef.valueType === 'float') params.node.data[params.colDef.field] = parseFloat(select.value);
            if (params.colDef.valueType === null) params.node.data[params.colDef.field] = select.value;
            this.state.gridOptions.api.refreshRows(params.note);
            this.Change(params.node.data);
        }.bind(this));
        return select;

    },
    CellRenderButton: function (params) {
        var button = document.createElement("button");
        button.className = params.colDef['button'].className;
        button.innerText = params.colDef['button'].text;
        button.style.color = "white";
        button.style.backgroundColor = "#3447ca";
        button.addEventListener('click', () => this.onClickForButton(button.className, params.data));
        return button;
    },
    onClickForButton: function (className, data) {
        var examTimeCode;
        if (className === "createHall") {
            examTimeCode = data.CODE;
            $.ajax({
                url: '/ExamHallStudent/CreateExamHallStudent',
                dataType: 'json',
                data: { examTimeCode: examTimeCode },
                success: function (data) {
                    log.show('Tạo phòng thành công!', true);
                }.bind(this),
                error: function (xhr, status, err) {
                    log.show("Tạo phòng lỗi!", false);
                    console.log(err.toString());
                }
            });
        }
        var testStructCode;
        var subjectCode;
        if (className === "createExamform") {
            examTimeCode = data.CODE;
            testStructCode = data.TESTSTRUCTCODE;
            if (!!testStructCode) {
                $.ajax({
                    url: '/ExamForm/CreateExamFormJson',
                    dataType: 'json',
                    data: {
                        examTimeCode: examTimeCode,
                        testStructCode: testStructCode
                    },
                    success: (function (data) {
                        if (data.ret >= 0) log.show('Tạo đề thành công!', true);
                        else {
                            bootbox.alert('Không đủ câu hỏi để sinh đề hoặc chưa đặt số câu hỏi trong cấu trúc đề');
                        }
                    }).bind(this),
                    error: (function (xhr, status, err) {
                        log.show("Tạo đề lỗi!", false);
                        console.log(err.toString());
                    }).bind(this)
                });
            } else {
                log.show('Chưa có cấu trúc đề!', false);
            }

        }
        if (className === "mark") {
            log.show('Chấm điểm');
        }
    },
    Number: function () {
        this.init = function init(params) {
            this.eInput = document.createElement("INPUT");
            this.eInput.setAttribute("type", "number");
            params.value != null ? this.eInput.value = params.value : this.eInput.value = 0;
        };

        this.getGui = function getGui() {
            return this.eInput;
        };

        this.afterGuiAttached = function afterGuiAttached() {
            this.eInput.focus();
            this.eInput.select();
        };

        this.getValue = function getValue() {
            return parseInt(this.eInput.value);
        };
    },
    Datepicker: function (data) {
        return moment(data.value).format('DD/MM/YYYY');
    },
    Datetimepicker: function (data) {
        return moment(data.value).format('DD/MM/YYYY HH:mm');
    },
    myTabToNextCell: function (params) {
        var previousCell = params.previousCellDef;
        var lastRowIndex = previousCell.rowIndex;
        var nextRowIndex = params.backwards ? lastRowIndex + 1 : lastRowIndex - 1;

        var renderedRowCount = this.state.gridOptions.api.getModel().getRowCount();

        if (nextRowIndex < 0) { nextRowIndex = 0; }
        if (nextRowIndex >= renderedRowCount) { nextRowIndex = renderedRowCount - 1; }

        var result = {
            rowIndex: nextRowIndex,
            column: previousCell.column,
            floating: previousCell.floating
        };

        return result;
    },
    myNavigateToNextCell: function (params) {
        var previousCell = params.previousCellDef;
        var suggestedNextCell = params.nextCellDef;
        switch (params.key) {
            case 38:
                if (this.state.objectChange != null) { break; }
                var nextRowIndex = previousCell.rowIndex - 1;
                if (nextRowIndex < 0) {
                    return null;
                }
                return { rowIndex: nextRowIndex, column: previousCell.column, floating: previousCell.floating };

            case 40:
                if (this.state.objectChange != null) return;
                var nextRowIndex = previousCell.rowIndex + 1;
                var renderedRowCount = this.state.gridOptions.api.getModel().getRowCount();
                if (nextRowIndex >= renderedRowCount) {
                    return null;
                } else {
                    return { rowIndex: nextRowIndex, column: previousCell.column, floating: previousCell.floating };
                }
            case 37:
            case 39:
                return suggestedNextCell;
            default:
                throw 'this will never happen, navigation is always on of the 4 keys above';
        }
    },
    onSelectionChanged: function () {
        var SelectedRows = this.state.gridOptions.api.getSelectedRows();
    },
    Comparator: function (object_A, object_B) {
        if (object_A === null) return false;
        for (let i = 0; i < Object.keys(object_A).length; i++) {
            if (object_A[Object.keys(object_A)[i]] != object_B[Object.keys(object_A)[i]]) return false;
        }
        return true;
    },
    Exist: function (list, data) {
        if (list === null) return false;
        for (let i = 0; i < list.length; i++) {
            if (data.agGridID === list[i].agGridID) return true;
        }
        return false;
    },
    Change: function (data) {
        var dataBuffer = JSON.parse(JSON.stringify(data));
        delete dataBuffer.agGridID;
        if (!this.Exist(this.state.editList, data) && !this.Comparator(this.state.dataCopy[data.agGridID], dataBuffer)) {
            var editList = this.state.editList;
            editList.push(data);
            this.setState({ editList: editList });
        }
        else {
            if (this.Comparator(this.state.dataCopy[data.agGridID], dataBuffer) || 1) {
                var editList = this.state.editList;
                editList.splice(editList.indexOf(data), 1);
                this.setState({ editList: editList });
            }
        }
    },
    IsChange: function () {
        if (this.state.editList.length != 0 || this.state.removeList.length || this.state.newList.length) return true;
        return false;
    },
    componentWillMount: function () {
        this.setState({
            gridOptions: {
                columnDefs: this.state.columnDefs,
                rowData: null,
                rowSelection: 'multiple',
                suppressRowClickSelection: false,
                //doubleClickEdit : true,
                onSelectionChanged: this.onSelectionChanged,
                enableColResize: true,
                enableFilter: true,
                headerHeight: 30,
                rowHeight: 28,
                enableSorting: true,
                animateRows: true,
                navigateToNextCell: this.myNavigateToNextCell,
                tabToNextCell: this.myTabToNextCell,
                onGridReady: function (params) {

                    //params.api.sizeColumnsToFit();
                },
                onCellEditingStarted: function (event) {


                }.bind(this),
                onCellEditingStopped: function (event) {

                },
                onRowSelected: function (params) {
                    var selectedRows = this.state.gridOptions.api.getSelectedRows();

                }.bind(this),
                onCellValueChanged: function (event) {
                    this.Change(event.data);
                }.bind(this),
                onSelectionChanged: function () {
                    var selectedRows = this.state.gridOptions.api.getSelectedRows();
                    this.props.onRowSelect(selectedRows);
                }.bind(this)

            }
        });

    },
    componentDidMount: function () {
        this.props.initAgGrid(this.setRowData, this.getDataChange, this.setNextRow, this.setPrevRow, this.setSelect, this.setChoosen);
        var option = this.state.gridOptions;
        var gridDiv = document.querySelector('#' + this.props.container);
        new agGrid.Grid(gridDiv, option);
        this.state.gridOptions = option;
        this.fitToContainer();
        $('#' + this.props.container).keyup(function (e) {
            if (e.keyCode === 46) {
                //console.log("Delete Key press!");
                var selectedNodes = this.state.gridOptions.api.getSelectedNodes();
                //console.log(selectedNodes);

                if (selectedNodes != null) {
                    this.state.gridOptions.api.removeItems(selectedNodes);
                    this.state.gridOptions.api.refreshView();
                    var deleteList = this.state.removeList;
                    selectedNodes.forEach(function (item, index) {
                        deleteList.push(item.data.agGridID);
                    }.bind(this));
                    //console.log(deleteList);
                    this.setState({ removeList: deleteList });
                }
            }
        }.bind(this));
    },
    componentDidUpdate: function () {
        this.fitToContainer();
    },
    fitToContainer: function () {

        var gridDiv = document.querySelector('#' + this.props.container);
        var gridOptions = this.state.gridOptions;

        var columnDefs = this.state.columnDefs;
        //console.log(columnDefs);
        var sum = 0;
        columnDefs.forEach(function (item) {
            sum += item.width;
        });

        setTimeout(function () {
            var width = $('#' + this.props.container).width();
            //console.log($('#' + this.props.container).width(), this.props.container);

            columnDefs.forEach(function (item) {
                var col = gridOptions.columnApi.getColumn(item.field);
                gridOptions.columnApi.setColumnWidth(col, Math.floor((item.width / sum) * width));
            });
        }.bind(this), 200);

    },
    Refresh: function (data) {

        if (data != null) {

            var dataCopy = JSON.parse(JSON.stringify(data));
            this.setState({ dataCopy: dataCopy });
            var length = data.length;
            for (var i = 0; i < length; i++) {
                data[i].agGridID = i;
            }
            this.state.gridOptions.api.setRowData(data);
            this.state.gridOptions.api.refreshView();

        }
        this.setState({ dataCopy: dataCopy, removeList: [], newList: [], editList: [] });
    },
    setRowData: function (data) {
        if (data != null) {

            var dataCopy = JSON.parse(JSON.stringify(data));
            this.setState({ dataCopy: dataCopy });
            let length = data.length;
            for (var i = 0; i < length; i++) {
                data[i].agGridID = i;
            }

            this.state.gridOptions.api.setRowData(data);
            this.state.gridOptions.api.refreshView();
            this.setState({ dataCopy: dataCopy, removeList: [], newList: [], editList: [] });

            this.state.gridOptions.api.forEachNode(function (node) {
                if (node.childIndex === 0) {
                    node.setSelected(true);
                    return;
                }
            });
            this.fitToContainer();
        }
        else {
            console.log(' ***** data null .....!');
        }
    },
    setSelect: function (data) {
        if (data != null) {
            console.log('Assign row:',data);
            this.state.gridOptions.api.forEachNode(function (node) {
                 console.log('row:',node);
                if (node.data.CODE === data.CODE) {
                    node.setSelected(true);
                     console.log('selected:',node);
//                    return;
                }
                else{
                                    node.setSelected(false);

                }
            });
        }
        else {
            console.log(' ***** data null .....!');
        }
    },
    setChoosen: function (arr,keyfield) {
        if (arr != null) {
            console.log('Assign rows:', arr);
            var check = {};
            for (var i = 0; i < arr.length; i++) {
                var obj = arr[i];
                check[obj[keyfield]] = 1;
            }
            console.log('The check',check);
            this.state.gridOptions.api.forEachNode(function (node) {
                if (!isMiss(check[node.data[keyfield]])) {
                    node.setSelected(true);
                }
                else {
                    node.setSelected(false);
                }
            });
        }
        else {
            console.log(' ***** data null .....!');
        }

    },
    getDataChange: function () {

        let obj = new Object();

        obj['edit'] = this.state.editList;
        for (let i = 0; i < this.state.editList.length; i++) {
            delete obj['edit'][i].agGridID;
        }

        obj['delete'] = this.state.removeList;
        for (let i = 0; i < this.state.removeList.length; i++) {
            delete obj['delete'][i].agGridID;
        }

        return obj;
    },
    setNextRow: function (row) {
        if (!row) {
            let isStop = false;
            this.state.gridOptions.api.forEachNode(function (node) {
                if (!isStop) {
                    this.state.gridOptions.api.deselectAll();
                    node.setSelected(true);
                    isStop = true;
                }
            }.bind(this));
        }
        else {
            let isStop = false;
            let isNode = false;
            var firstNode = new Object();
            this.state.gridOptions.api.deselectAll();
            this.state.gridOptions.api.forEachNode(function (node) {
                if (isStop) return;
                if (node.rowIndex === 0) {
                    firstNode = node;
                    if (!row) return;
                }
                if (isNode) {
                    node.setSelected(true);
                    isStop = true;
                    return;
                }
                if (node.data.agGridID === row.agGridID) {
                    isNode = true;
                }

            }.bind(this));
            if (!isStop && isNode) {
                firstNode.setSelected(true);
            }
        }
    },
    setPrevRow: function (row) {

        if (!row) {
            let isStop = false;
            this.state.gridOptions.api.forEachNode(function (node) {
                if (!isStop) {
                    this.state.gridOptions.api.deselectAll();
                    node.setSelected(true);
                    isStop = true;
                }
            }.bind(this));
        }
        else {
            var prev = null;
            var isFirst = false;
            var isStop = false;
            this.state.gridOptions.api.deselectAll();
            this.state.gridOptions.api.forEachNode(function (node) {
                if (node.rowIndex === 0) {
                    if (node.data.agGridID === row.agGridID) isFirst = true;
                }
                else {
                    if (!isFirst && node.data.agGridID === row.agGridID && !isStop) {
                        prev.setSelected(true);
                        isStop = true;
                        return;
                    }
                }
                prev = node;

            }.bind(this));
            if (isFirst) prev.setSelected(true);
        }

    },
    shouldComponentUpdate: function (nextProps, nextState) {
        //console.log(nextState.columnDefs);
        //console.log(this.state.columnDefs);
        //console.log('Check componentUpdate', nextState.columnDefs !== this.state.columnDefs);
        if (nextState.columnDefs !== this.state.columnDefs) {
            this.state.gridOptions.api.setColumnDefs(this.props.columnDefs);
        }
        return true;
    },
    componentWillReceiveProps: function() {
        //console.log('Gan vao grid:',this.props.columnDefs);
        //!!this.props.headerCheckBox && initColDefs.push({ headerName: '', field: '', width: 28, editable: false, checkboxSelection: true, headerCheckboxSelection: true });
        //var initColDefs = this.calColumn();
        //console.log('New props:', initColDefs);
//        this.setState({ columnDefs: initColDefs });
    },
    render: function () {
        return (<div></div>);
    }
});