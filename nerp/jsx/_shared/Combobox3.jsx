/**
*Thực hiện tạo một combo bõ từ dữ liệu được đưa vào
*@para lst: danh sách các đối tượng sinh ra combobox
*@para valuefield: trường lấy dữ liệu
*@para textfield: trường hiển thị dữ liệu; Nếu sử dụng nhiều trường thì phải sử dụng {} bao ngoài tên trường {CODEVIEW}-{NAME}
*@para topvalue: giá trị đầu tiên
*@para toptitle: tiêu đề đầu tiên
*@para defaultvalue: Giá trị lựa chọn mặc định
*@para id: id của thẻ select của đối tượng được sinh ra
*@para callback: Hàm xử lý khi lựa chọn một đối tượng
*/
var Combobox3 = React.createClass({
    getInitialState: function () {
        return {
            data: [], onChange:null
        };
    },
    componentWillMount: function () {
       // component.add(this.props.id, this);
    },
    componentDidMount: function () {   
    },
    componentDidUpdate:function() {
        $('#' + this.props.id).unbind().change(function() {
            $('#' + this.props.id).val($('#' + this.props.id).val());
            //consolelog($('#' + this.props.id).val());
        }.bind(this));
    },
    updatedata: function (data,type,name) {
        var $el = $("#" + this.props.id);
        $el.empty();
      
        if (!!data) {   
            if (!!type&&!!name) {
                var b = document.createElement('option');
                b.value = '';
                b.innerText = name;
                document.getElementById(this.props.id).appendChild(b);                 
            }
            data.map(function(item) {           
                var a = document.createElement('option');
                a.value = item.CODE;
                a.innerText = item.NAME;
                document.getElementById(this.props.id).appendChild(a);
                return;
            }.bind(this));
        } else {
            log.show("Không có cha",false);
        }
       
    },
    render: function () {          
       
        return (
      
             <select id={this.props.id} name="cboName" className="form-control">
              </select>
     
      );
}
});
