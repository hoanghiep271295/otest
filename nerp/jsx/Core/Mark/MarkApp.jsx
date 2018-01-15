var MarkApp = React.createClass({
    getInitialState: function() {
        return {
            agGrid: { setRowData: null, getDataChange: null, setNextRow: null, setPrevRow: null },
            rowSelect: null,
            //Định nghĩa các cột trên lưới
            columnDefs: [
                { headerName: "Mã", field: "CODEVIEW", width: 100, editable: false },
                { headerName: "Họ tên", field: "NAME", width: 300, editable: false },
                { headerName: "Ngày sinh", field: "THEORDER", width: 100, type: 'date' },
                { headerName: "", button: { text: 'Chấm điểm', className: 'mark' }, width: 200, editable: false, type: 'button' }
            ],
            listSubject: [],
            listCourse: [],
            listExamtime: [],
            listStudent: [],
            datatype : [
               { CODE: 'type_class', NAME: 'Theo lớp' },
               { CODE: 'type_exam', NAME: 'Theo đợt thi' }
            ]
    }
    },
    componentWillMount: function () {
        console.log('coursecode', this.state.coursecode);
        
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

    componentDidMount: function () {
        this.refs["TYPE"].setValue(this.state.datatype[0].CODE);
        this.loadSubject();
        this.checkType({ value: this.state.datatype[0].CODE });
       
        
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
    loadExamtime: function (subjectcode) {
        $.ajax({
            url: '/Examtime/GetBySubject',
            dataType: 'json',
            data: {subjectcode: subjectcode},
            success: function (data) {
                if (data.ret >= 0) {
                    this.setState({ listExamtime: data.lst });
                    if (data.lst.length > 0) {
                        this.refs["EXAMTIMECODE"].setValue(data.lst[0].CODE);
                        this.loadDataByExamtime({ value: data.lst[0].CODE });
                    } else
                        this.loadDataByExamtime('');
                }
                
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }.bind(this)
        });
    },
    loadSubject: function (id) {
        $.ajax({
            url: '/Subject/GetAll',
            dataType: 'json',
            success: function (data) {
                if (data.ret >= 0) {
                    this.setState({listSubject: data.lst});
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }.bind(this)
        });
    },
    loadCourse: function(subjectcode) {
        $.ajax({
            url: '/Course/GetAll',
            dataType: 'json',
            data: {
                subjectcode: subjectcode
            },
            success: function (data) {
                if (data.ret >= 0) {
                    this.setState({ listCourse: data.lst });
                    if (data.lst.length > 0) {
                        this.refs["COURSECODE"].setValue(data.lst[0].CODE);
                        this.loadDataByCourse({ value: data.lst[0].CODE });
                    } else 
                        this.loadDataByCourse('');
                }
                
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }.bind(this)
        });
    },
    changeSubject: function(item) {
        var type = this.refs['TYPE'].getValue();
        if (type === 'type_class') {
            this.loadCourse(item.value);
        } else
            this.loadExamtime(item.value);
    },
    loadDataByExamtime: function (item) {

        var examtimecode = '';
        if (!!item)
            examtimecode = item.value;
        $.ajax({
            url: "/Examtime/GetStudentByExamtime",
            dataType: 'json',
            data: {
                examtimecode: item.value
            },
            success: function (data) {
                if (data.ret >= 0) {
                    this.setState({ listStudent: data.lst });
                    this.state.agGrid.setRowData(data.lst);
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }
        });
    },
    loadDataByCourse: function (item) {
        var coursecode = '';
        if (!!item)
            coursecode = item.value;
        $.ajax({
            url: "/Mark/GetStudentByCourse",
            dataType: 'json',
            data: {
                coursecode: coursecode
            },
            success: function (data) {
                if (data.ret >= 0) {
                    this.setState({ listStudent: data.lst });
                    this.state.agGrid.setRowData(data.lst);
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }
        });
    },
    checkType: function (item) {
        this.refs["SUBJECTCODE"].setValueString('');
        var type = item.value;
        if (type === 'type_class') // thi theo lớp thì load combo các lớp môn học lên
        {
            $('#listcourse').removeClass('hidden');
            $('#listexamtime').addClass('hidden');

        } else {
            $('#listexamtime').removeClass('hidden');
            $('#listcourse').addClass('hidden');
        }
            
            
    },

    render: function () {
        var self = this;
       
        return (
            <div>
                <div className="row" style={{paddingLeft: '14px', paddingBottom: '10px'}} >
                    <div className="row" >
                       <div className="col-sm-3">
                            <Combobox lst={this.state.datatype} valuefield='CODE' textfield='{NAME}' id='TYPE' callback={this.checkType} tooltip="Cách thức" multiple={false} ref='TYPE' />
                      </div>
                     </div>
                     <div className="row" style={{paddingTop: '10px'}}>
                        <div className="col-sm-3">
                                <Combobox lst={this.state.listSubject} valuefield='CODE' textfield='{NAME}' id='SUBJECTCODE' callback={this.changeSubject} tooltip="Môn học" multiple={false} ref='SUBJECTCODE' />
                        </div>

                      <div className="hidden" id='listcourse'>

                          <div className="col-sm-3">
                                <Combobox lst={this.state.listCourse} valuefield='CODE' textfield='{NAME}' id='COURSECODE' callback={this.loadDataByCourse} tooltip="Lớp môn học" multiple={false} ref='COURSECODE' />
                          </div>
                      </div>
                    <div className="hidden" id='listexamtime'>
                          <div className="col-sm-3">
                                <Combobox lst={this.state.listExamtime} valuefield='CODE' textfield='{NAME}' id='EXAMTIMECODE' callback={this.loadDataByExamtime} tooltip="Đợt thi" multiple={false} ref='EXAMTIMECODE' />
                          </div>
                    </div>
                     </div>
            </div>
                
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

//----------------
ReactDOM.render(
    <MarkApp />,
    document.getElementById('container')
);