﻿/**
 * Quy tắc đặt tên
 *Cung cấp ra ngoài các hàm: 
 * ClearInput(obj): Xóa các text box - được gọi từ cha
 * SetInput(obj): Thiết lập thông tin trên các ô text tương ứng - được gọi từ cha
 * ReloadData(): callback function được gán từ cha vào để cập nhật lại thông tin của cha nếu cần thiết
 */
var ExamTimeStudentPopup = React.createClass({
    getInitialState: function() {
        return {
            agGrid: { setRowData: null, getDataChange: null, setNextRow: null, setPrevRow: null },
            rowSelect: null,
            columnDefs: [
                { headerName: "Mã sinh viên", field: "CODEVIEW", width: 100,align: 'center', editable: false },
                { headerName: "Tên sinh viên", field: "NAME", width: 150,align: 'center', editable: false },
                { headerName: "Số điện thoại", field: "PHONE", width: 120,align: 'center', editable: false },
                { headerName: "Email", field: "EMAIL", width: 120, align: 'center', editable: false }
            ]
        };
    },
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
    componentWillMount: function() {
        var listCourse = this.props.listCourse;
        if (listCourse.length > 0) {
            this.refs['COURSECODE'].setValueString(listCourse[0].CODE);
        }
    },
    componentDidMount: function() {
        
    },
    shouldComponentUpdate: function (nextProps, nextState) {
        return nextProps.listCourse !== this.props.listCourse;
    },
    onRowSelect : function(itemSelect) {
        if (!!itemSelect && itemSelect.length > 0) {
            this.setState({ rowSelect: itemSelect });
        }
    }
    ,
    /**
     load danh sách sinh viên thuộc course nhưng chưa được thêm vào đợt thi
     */
    loadData: function (item) {
 
        $.ajax({
            url: '/ExamHallStudent/GetAllStudent',
            traditional: true,
            data: {
                courseCode: item.value,
                examtimeCode: this.props.app.getKeyValue('examtime')[0].CODE
            },
            dataType: 'json',    
            success: function (data) {
                if (data.ret >= 0) {
                    this.state.agGrid.setRowData(data.data);                   
                }
              //  this.state.agGrid.setRowData(data.data);
            }.bind(this),
            error: function (xhr, status, err) {
                console.error(this.props.url, status, err.toString());
            }.bind(this)
        });
    },
    Show: function () {
        //var listCourse = this.props.app.getKeyValue('listCourse');
        //this.refs["COURSECODE"].setValueString(listCourse[0].CODE);
        this.loadData({ value: this.refs['COURSECODE'].getValueString() });
        $('#' + this.props.id).modal('show');
    },
    /**
    *Ẩn form hiện tại
    */
    Hide: function () {
        $('#' + this.props.id).modal('hide');
    },
    /**
    *hàm được gọi để xóa dữ liệu trên form cho phép thêm mới; được gọi bởi component có component này (list)
    */
    /**
    *hàm được gọi để xóa dữ liệu trên form cho phép thêm mới; được gọi bởi component có component này (list)
    */
    ClearInput: function () {
        console.log("do clear");
        this.loadData();
        
    },
    /**
    *Hàm gán dữ liệu để sửa, được gọi bởi component cha của component này
    *para obj: thông tin về dữ liệu được thay đổi
    */
    SetInput: function () {
        //Set status
        this.refs[this.props.id + "_status"].innerHTML = 'edit';
    },

    /**
   *Kiểm tra để gọi load lại cho dữ liệu từ component cha (danh sách)
   *para obj: là mã của bản ghi mới được thao tác
   */
    ReloadData: function () {
        var coursecode = this.refs["COURSECODE"].getValue().value;
        if (isMiss(this.props.ReloadData)) {
            return false;
        }
        else {
            this.props.ReloadData();
            return true;
        }
    },
    /**
    *gọi khi bấm nút ghi
    */
    SaveClick: function ()
    {
        this.SaveData(true);
    },
    /**
    *gọi khi bấm nút ghi và tạo mới
    */
    SaveContinueClick: function () {
        this.SaveData(false);
    },
    /**
     *Thực tế ghi dữ liệu
   *para isClose xác định sau khi ghi xong sẽ đóng form, hay là tiếp tục tạo mới
   */
    SaveData: function (isClose) {
        //Add or edit 1 item
        
        if (!!this.state.rowSelect) {
            var listStudentCode = [];
            this.state.rowSelect.forEach(function(item) {
                listStudentCode.push(item.CODE);
            });
            var postData = {
                listStudentCode: listStudentCode,
                courseCode: this.refs["COURSECODE"].getValue().value,
                examTimeCode: this.props.app.getKeyValue('examtime')[0].CODE
        };
            if (!!listStudentCode.length) {
                $.ajax({
                    url: "/ExamHallStudent/Insert",
                    type: 'POST',
                    data: postData,
                    dataType: 'json',
                    traditional: true,
                    success: function (data) {
                        if (data.ret >= 0) {
                            if (isClose) {
                                this.Hide();
                            }
                            //sau khi ghi dữ liệu thành công thì cần reload lại grid ở bên ngoài 
                            //và cả grid ở bên trong popup
                            this.loadData({ value: this.refs["COURSECODE"].getValue().value });
                            //set cho nó thời gian trễ để server kịp thời xử lý
                            //load lại dữ liệu ở grid ngoài cùng
                                this.ReloadData();
                      
                        } else {
                            log.show('Lỗi ghi dữ liệu',false);
                        }
                    }.bind(this),
                    error: function (xhr, status, err) {
                        console.error(this.props.url, status, err.toString());
                    }.bind(this)
                });
            }
            
        }
    },
    //thao tác khi click trực tiếp vào 1 element, xử lý sự kiện onclick item
    ComboOnSelect: function (element) {
        console.log('On ComboOnSelect', element);
        if (!!element.parent) {
            console.log("do oncheck");
            var gradecode = element.parent;
            var classcode = element.id;
            this.loadData(gradecode, classcode);
        }
        
    },
    //thao tác khi check  vào một note bất kì, khi hiển thị ở dạng checkbox
    ComboOnCheck: function (elements, status) {
        console.log("on ComboOnCheck", elements, status);
        var gradecode = elements.parent;
        var classcode = elements.id;
        console.log("do oncheck");
        this.loadData(gradecode,classcode);
    },
    //thao tác khi click expand tree
    ComboOnExpand: function (element, status) {
        console.log('ComboOnExpand', element, status);
    },
    /**
     * Hien thi danh sach cay len tren popup bao gồm khóa học và lớp học
     * 
     * @returns {} 
     */
   

    render: function () {
        var listCourse = this.props.listCourse;
        return (
                <div className="modal fade" id={ this.props.id} ref={ this.props.id} role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                  <div className="modal-dialog" style={{'width':'75%'}}>
                    <div className="box box-info">
                      <div className="modal-header with-border">
                        <button type="button" className="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span className="sr-only">Close</span></button>
                        <h4 className="modal-title" id={ this.props.id +"_form_title"} ref={this.props.id+"_form_title"} >Thêm sinh viên vào đợt thi</h4>
                          <input type="hidden" id={this.props.id+ "_parentCode"} ref={this.props.id+ "_parentCode"} />{/*Lưu lại mã code của cha hiện tại*/}    
                      </div>
                      <div className="modal-body">
                      <form className="form-horizontal" id='myform' role="form">
                            <div className="form-group">
                                <label  className="col-sm-2 control-label">Chọn lớp </label>
                                 <div className="col-sm-10">
                           <Combobox lst={listCourse} valuefield='CODE' textfield='{NAME}' id='COURSECODE' callback={this.loadData} tooltip="Click hoặc space chọn" multiple={false} ref='COURSECODE' />
                          
                        </div>
                                </div>
                                </form>
                                <div className="form-group">
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
                     
                        </div>
                        <div className="box-footer modal-footer">{/*Phần dành để hiển thị trạng thái - không thay đổi*/}
                        <span className="label label-warning" style={{float:'left'}} id={this.props.id+"_status"} ref={this.props.id+"_status"}>i</span>
                        <button type="button" className="btn btn-primary" onClick={this.SaveClick}><i className="fa fa-floppy-o"></i> Ghi</button>
                        <button type="button" className="btn btn-primary" onClick={this.SaveContinueClick}><i className="fa fa-plus-circle"></i> Ghi và thêm mới</button>
                        <button type="button" className="btn btn-default " data-dismiss="modal"><i className="fa fa-sign-out"></i>Thoát</button>
                        </div>

    </div>
  </div>
</div>
            );
}
});


