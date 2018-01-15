var AdmingroupPriorityAdd = React.createClass({
    getInitialState: function () {
        return {
            agGrid: { setRowData: null, getDataChange: null, setNextRow: null, setPrevRow: null, setSelect :null},
            rowSelect: null,
            columnDefs: [
                { headerName: "Mã hiển thị", field: "CODE", width: 100, editable: false },
                { headerName: "Tên", field: "NAME", width: 300, editable: false },
                { headerName: "Nhóm", field: "GROUPCODE", width: 100, editable: false },
                { headerName: "Phân hệ", field: "SYSCOMPONENTCODE", width: 100, editable: false },
            ],
            page: 1,
            searchstatus:[],
            loaded:null,
            popup:null,
            parentinfo:null
        };
    },
    componentWillMount: function () {
      
    },
    componentDidMount: function () {
        var id = this.props.id;
        this.refs[id+"_view"].checked=true;
        this.refs[id+"_add"].checked=true;
        this.refs[id+"_edit"].checked=true;
        this.refs[id+"_delete"].checked=true;

        this.setState({popup:this.refs[this.props.id+'_popup']});
//        console.log('List-componentDidMount:', new Date());
        //this.loadData();
    },
    //Thêm bắt buộc so với cái cũ - 
    ///**
    //*Danh sách các nút lệnh - để tương tác do cha củađối tượng này gọi (xem hàm dùng chung trong _shared/TabHeader.jsx, ButtonList.jsx )
    //*/
    //registerButton:function(){
    //    var obj = Object();
    //    //Đầy đủ nếu nó không thuộc các nhóm mặc định: { ref: 'cmdNew', callback: this.onPrint,title:'Hello',icon:'',tooltip:'Không rõ'}

    //    obj=[{ref: 'cmdAdd' , callback: this.onNewClick }
    //         , {ref: 'cmdEdit', callback: this.onEditClick}
    //         , { ref: 'cmdDelete', callback: this.onDeleteClick}
    //         , { ref: 'cmdRefresh', callback: this.Refresh}
    //         //, { ref: 'cmdSearch', callback: this.onSearch}
    //         //, { ref: 'cmdSearchSQL', callback: this.onSearch}
    //         //, { ref: 'cmdPrint', callback: this.onPrint}
    //    ];
    //    return obj;
    //},
    /**
    * Thực thao tác khi tab này được chọn - đối tượng parent (this.props.parent) truy xuất đến đối tượng cha đã gọi đối tượng này dùng để truy xuất thông tin chung trong các hệ thống (xem hàm dùng chung trong _shared/TabHeader.jsx)
    */
    onActive: function (parent) {
//        console.log('onActive Admingroupp-Priority-Add', new Date())
        var that=this;
        //Lấy bản ghi cha đang được chọn
        var objAdmingroup=this.props.parent.getKeyValue('admingroupCode');
        //Nếu chưa chọn
        if(isMiss(objAdmingroup))
        {
            //Thông báo và chuyển về trang cha
            bootbox.alert("Chưa chọn nhóm quản trị", function(){ that.props.parent.ChooseTab('admingroup') });
            return ;
        }
        //Kiểm tra việc lấy dữ liệu và lấy lại dữ liệu; hoặc chưa load, hoặc cha đã bị thay đổi
//        if(this.state.loaded===null || this.state.parentinfo!==objAdmingroup)
        {
            this.loadData();
            this.setState({loaded:true});//Có thể là giá trị khác để kiểm tra
            this.setState({parentinfo:objAdmingroup});//Trường hợp có thay đổi thì nhận lại mã mới
            //Gán lại tiêu đề lớn - cộng với tên nhóm
        }
//        this.props.parent.setParentTitle(this.props.parentTitle + '(' + objAdmingroup.NAME + ')');
//        console.log('onActive Admingroupp-Priority-Add: Finish', new Date())

    },
    /**
    *Khởi tạo lưới
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
    ///**
    //*Khi chọn một bản ghi đưa vào vùng chọn hiện tại
    //*/
    //onRowSelect: function (itemSelect) {
    //    console.log(itemSelect);
    //    if (!!itemSelect && itemSelect.length > 0)
    //        this.setState({ rowSelect: itemSelect });
    //},
    ///**
    //*Lấy lại toàn bộ dữ liệu 
    //*/
    //Refresh:function()
    //{
    //    this.loadData(this.state.searchstatus, this.state.rowSelect[0]);
    //},
    ///**
    //*Lấy lại toàn bộ dữ liệu được gọi bởi popup - với đối tượng vào để xử lý phù hợp
    //*/
    //ReloadList:function(obj)
    //{
    //    this.loadData(this.state.searchstatus,obj);

    //}
    //,
    ///**
    //* Cập nhật lại thông tin sau khi gọi xóa dữ liệu thành công
    //*/
    //ReloadListDelete: function () {
    //    //cập nhật lại danh sách
    //    this.loadData();//(this.state.currentcode);
    //},
    /**
    * Lấy dữ liệu 
    */
    loadData: function (obj, selectobject) {
//        console.log('admingrouppriorityAdd-loadData:', new Date());
        var ret;
        var that = this;
//        window.NProgress.start();
        var pageSize = $('#pageSize').val();
        if (isNaN(pageSize)) {
            pageSize = 0;
        }
        let page = this.state.page;
        if (isMiss(obj)) {
            obj = this.state.searchstatus;
        }
        var code = '';
        var codetype = false;
        var name = '';
        var nametype = false;
        if (!!obj.CODESEARCH)
        {
            code = obj.CODESEARCH.value;
            codetype = obj.CODESEARCH.type;
        }
        if (!!obj.NAMESEARCH) {
            name = obj.NAMESEARCH.value;
            nametype = obj.NAMESEARCH.type;
        }
//        console.log('admingrouppriorityAdd-Called:', new Date());
        $.ajax({
            url: "/admingroup/GetPriorityUnlisted",
            dataType: 'json',
            data: {
                page: page
                ,pageSize: pageSize
                , code: code
                , codetype: codetype
                , name: name
                , nametype: nametype
                ,admingroupcode:this.props.parent.getKeyValue('admingroupCode').CODE
            },
            success: function (data) {
                ret = data.data;
                //console.log(data.data);
                if (!data.data) {
                    this.setState({ rowSelect : null });
                }                
                this.state.agGrid.setRowData(data.data);//JSON.parse(data.data2));
                if (!isMiss(selectobject ))
                {
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
    
 //   /**
 //   * Xử lý cho trường hợp chỉ thêm mới
 //   */
 //   onNewClick: function () {
 //       var obj={};//nếu có một số thông tin về cha và cần truyền sẽ đưa vào đây
 //       this.state.popup.ClearInput(obj);
 //       this.state.popup.Show();
 //   },
 //   /**
 //   * Xử lý trường hợp sửa
 //   */
 //   onEditClick: function () {
 //       //Chỉ sửa cho một bản ghi
 //       if (this.state.rowSelect.length != 1)
 //       {
 //           bootbox.alert('Chọn nhiều hơn một bản ghi');
 //           return;
 //       }
 //       var obj=this.state.rowSelect[0];//Ban ghi hiện tại để sửa
 //       this.state.popup.SetInput(obj);
 //       this.state.popup.Show();
        
 //   },
 //   /**
 //   *Xử lý trường hợp nút lệnh gọi xóa bản ghi
 //   */
 //   onDeleteClick: function () {
 //       var that = this;
 //       bootbox.confirm({
 //           message: "Bạn có muốn delete bản ghi này",
 //           buttons: {
 //               confirm: {
 //                   label: 'Yes',
 //                   className: 'btn btn-success'
 //               },
 //               cancel: {
 //                   label: 'No',
 //                   className: 'btn btn-danger'        
 //               }
 //           },
 //           callback: function (result) {
 //               if (result)
 //               {
 //                   that.handDelete();
 //               }
 //               else
 //               {
 //                   log.show("Không xóa bản ghi", true);
 //               }                
 //           }
 //       });
 //   },
 //   /**
 //   *Xử lý trường hợp xóa bản ghi
 //   */
 //   handDelete: function(){
 //       if (!!this.state.rowSelect) {
 //           var data = [];
 //           this.state.rowSelect.forEach(function (item, index) {
 //               data.push(item.CODE);
 //           });
 //           var postData = { code: data };
 //           $.ajax({
 //               url: "/admingroup/Delete",
 //               type: "POST",
 //               dataType: "json",
 //               traditional: true,
 //               data: postData,
 //               success: function (data) {
 //                   if (data.ret >= 0) {
 //                       this.loadData();
 //                       log.show("Đã xoá bản ghi!",true);
 //                   }
 //                   else
 //                   {
 //                       log.show("Xoá không thành công!",false);
 //                   }
 //               }.bind(this),
 //               error: function (xhr, status, err) {
 //                   console.log(err.toString());
 //               }
 //           });
 //       }
 //       else{
 //           log.show("Không có bản ghi nào!",false);
 //       }
 //   },
 //   /**
 //   * Xử lý nút lệnh tìm kiếm
 //   */
 //   onSearch: function () {
 //       //$('#ModalSearchSkill').modal('show');
 //       //console.log('Search skill');
 //       var   dataSearch = [
 //                          { title: 'Mã', id: 'CODESEARCH', type: 'text' }
 //                          ,{ title: 'Tên', id: 'NAMESEARCH', type: 'text' }
 ////                          ,{ title: 'Ghi chú', id: 'NOTESEARCH', type: 'text' }
 //       ];
 //       obj = this.state.searchstatus;//Dữ liệu mặc định
 //       this.props.parent.ShowSearch(this.props.id+'_search',dataSearch, obj, this.doSearch);
 //       console.log('Gọi tìm kiếm');
 //   },
 //   /**
 //   * Xử lý lời gọi search - dựa tren id đã được gửi để lấy dữ liệu về
 //   */
 //   doSearch:function(obj)
 //   {
 //       //obj dữ liệu lấy về
 //       console.log('search based on:', obj.CODESEARCH, obj.NAMESEARCH, obj.NOTESEARCH);
 //       this.setState({ searchstatus: obj });
 //       this.loadData(obj);
 //   },
 //   /**
 //   *Xử lý tìm kiếm nâng cao
 //   */
 //   onSearchSQL: function () {
 //       console.log("search SQL SKILL");
 //   },
 //   /**
 //  *Lấy lại toàn bộ dữ liệu được gọi bởi popup - với đối tượng vào để xử lý phù hợp
 //  */
 //   onPrint:function()
 //   {
 //       bootbox.alert('In ấn ở đây');
 //       this.props.parent.setButtonStatus('cmdDelete',true);
 //       this.props.parent.setButtonStatus('cmdSearch', false);
 //   },
 //   /**
 //   *Hiển thị, được gọi bởi component cha 
 //   */
    Show: function () {
//        console.log('Call AdmingroupPriorityAdd', new Date());
        //Tên tương ứng với form đã được định nghĩa ở dưới
        this.onActive(this.props.parent);
        $('#' + this.props.id).modal('show');
        //$('#' + this.props.id).draggable({
        //    handle: ".modal-header"
        //});
    },
    /**
    *Ẩn form hiện tại
    */
    Hide: function () {
        $('#' +this.props.id).modal('hide');
    },
    /**
*gọi khi bấm nút ghi
*/
    SaveClick: function ()
    {
        this.SaveData(true);//true: kết thúc form
    },
    /**
    *gọi khi bấm nút ghi và tạo mới
    */
    SaveContinueClick: function () {
        this.SaveData(false);//false: không kết thúc, sẽ tự động tạo mới
    },
    /**
      *Thực tế ghi dữ liệu
    *para isClose xác định sau khi ghi xong sẽ đóng form, hay là tiếp tục tạo mới
    */
    SaveData:function(isClose){
        var data =[];
        var rowSelect= this.state.rowSelect;
        var objectcode=this.props.parent.getKeyValue("admingroupCode").CODE;
        var id = this.props.id;
        console.log('The check objec:',this.refs[id+"_add"]);
        var func = (this.refs[id+"_view"].checked?1:0);
        func += (this.refs[id+"_add"].checked?2:0);
        func += (this.refs[id+"_edit"].checked?4:0);
        func += (this.refs[id+"_delete"].checked?8:0);
        rowSelect.forEach(function (item, index) {
            data.push({OBJECTCODE:objectcode, PRIORITYCODE:item.CODE, SYSCOMPONENTCODE:item.SYSCOMPONENTCODE, FUNC:func});
        });
        var lst={data: JSON.stringify( data)};
        console.log('Add post:',lst);
        
        //Add or edit 1 item
        $.ajax({
            url: "/Admingroup/addpriority",
            type: 'POST',
            data:lst,
            dataType: 'json',
            success: function (data) {
                if (data.ret >= 0) {
                    if(isClose)
                    {
                        //Ghi và kết thúc
                        this.Hide();
                    }
                    else {
                        //Ghi và tạo form mới
                        this.ClearThing();
                    }
                    //Load lại dữ liệu trên grid
                    this.ReloadData(data.obj); //Truyền code để chọn đúng bản ghi - xử lý trên grid

                }
                else {
                    //Sử dụng bootbox để thông báo, thay vì thông báo của hệ thống
                    bootbox.alert('Lỗi ghi dữ liệu');
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.error('unknow:url', status, err.toString());
            }.bind(this)
        });

    },
    /**
    *Kiểm tra để gọi load lại cho dữ liệu từ component cha (danh sách)
    *para obj: là mã của bản ghi mới được thao tác
    */
    ReloadData:function(obj)
    {
        if(isMiss(this.props.ReloadData))
        {
            //console.log('Call load data');
            return false;
        }
        else
        {
            //console.log('Call load data!!!!!!!!!!!!!');
            this.props.ReloadData(obj);
            return true;
        }
    },
    /**
*Khi chọn một bản ghi đưa vào vùng chọn hiện tại
*/
    onRowSelect: function (itemSelect) {
//        console.log(itemSelect);
        if (!!itemSelect && itemSelect.length > 0)
            this.setState({ rowSelect: itemSelect });
    },
    render: function () {
        var id = this.props.id;
        var parent = this.props.parent;
        console.log('Cha cua add:', parent);
        return (
                <div  className="modal draggable fade" id={id} ref={id} role="dialog" aria-labelledby={id} aria-hidden="true">
                  <div className="modal-dialog">
                    <div className="modal-content">
                      <div className="modal-header">
                        <button type="button" className="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span className="sr-only">Close</span></button>
                        <h4 className="modal-title" id={id+"_form_title"} ref ={id+"_form_title"}>Thêm thông tin nhóm quản trị</h4>
                      </div>
                      <div className="modal-body">
                          <form className="form-horizontal" role="form">
                    <div className="row">
                        <div className="col-sm-3"><label><input type="checkbox" value="" id ={id+"_view"} ref ={id+"_view"} />Xem</label></div>
                        <div className="col-sm-3"><label><input type="checkbox" value="" id ={id+"_add"} ref ={id+"_add"}/>Thêm</label></div>
                        <div className="col-sm-3"><label><input type="checkbox" value="" id ={id+"_edit"} ref ={id+"_edit"}/>Sửa</label></div>
                        <div className="col-sm-3"><label><input type="checkbox" value="" id ={id+"_delete"} ref ={id+"_delete"}/>Xóa</label></div>
                   </div>
                    <div id={this.props.id+'_grid'} className="ag-fresh" style={{width: '100%', height:'400px'}}></div>
                        <AgGrid container={this.props.id+'_grid'}
                        initAgGrid={this.initAgGrid}
                        loadData={this.loadData}
                        onRowSelect={this.onRowSelect}
                        columnDefs={this.state.columnDefs}
                        headerCheckBox={true}
                        ref={this.props.id+'_grid'}
                        > 
                        
                        </AgGrid>
                          </form>
                      </div>
             <div className="box-footer modal-footer">
                 {/*Phần dành để hiển thị trạng thái - không thay đổi*/}
                <span className="label label-warning" style={{float:'left'}} id={id+"_status"} ref={id+"_status"}>i</span>
                <button type="button" className="btn btn-primary" onClick={this.SaveClick}><i className="fa fa-floppy-o"></i> Ghi</button>
                <button type="button" className="btn btn-default " data-dismiss="modal"><i className="fa fa-sign-out" ></i>Thoát</button>
              </div>

                    </div>
                  </div>
            </div>


        );
}
});

