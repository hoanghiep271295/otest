/**
*Thực hiện tạo một combo bõ từ dữ liệu được đưa vào
*@para lst: danh sách các đối tượng sinh ra combobox
*@para valuefield: trường lấy dữ liệu
*@para textfield: trường hiển thị dữ liệu; Nếu sử dụng nhiều trường thì phải sử dụng {} bao ngoài tên trường {CODEVIEW}-{NAME}
*@para topvalue: giá trị đầu tiên 
*@para toptitle: tiêu đề đầu tiên
*@para defaultvalue: Giá trị lựa chọn mặc định
*@para id: id của thẻ select của đối tượng được sinh ra
*@para multiple: cho phép chọn nhiều đối tượng / default: false
*@para tooltip: Hiển thị khi di chuột - mặc định là "Click chuột hoặc nhấn space để chọn "
*@para callback: Hàm xử lý khi lựa chọn một đối tượng
* ví dụ: <Combobox lst={this.state.cbo} valuefield='id' textfield='{text}' defaultvalue='5' id='cbo' callback={this.hell}></Combobox>
*/
var Combobox = React.createClass({
    componentDidMount: function () {
        //if(!!this.props.callback)
        //{
        //    var self = this;
        //    $('#' + this.props.id).change(function () {
        //        self.props.callback(this.value);
        //    });
        //}
        var that = this;
        $('#' + this.props.id).select2().on("change", function () {
                if (!!that.props.callback) {
                    that.props.callback(that.getData());
                }
        });
        this.setValue(this.props.defaultvalue);
    },
   
    componentDidUpdate:function()
    {

    },
    setValue:function(key)
    {
        console.log('set to:', key);
        if (!!key) {
            //            $('#' + this.props.id).val(this.props.defaultvalue);
            $('#' + this.props.id).select2("val", key);
        }
    },
    getValue:function()
    {
        return $('#' + this.props.id).select2("val");
    },
    getData:function()
    {
        return $('#' + this.props.id).select2('data');
    },
    render: function () {
        var select1 = [];
        if (this.props.toptitle != null) {
            select1.push(<option value={this.props.topvalue } key='none'>{this.props.toptitle}</option>);
        }
        var self = this;
        var dis = self.props.textfield;
        var fields = [];
        var id = dis.indexOf("{");
        // ReSharper disable once AssignedValueIsNeverUsed
        var clo = 0;
        if (id < 0)
        {
            //one field
            fields.push(dis);
        }
        else
        {
            while(id >= 0)
            {
                clo = dis.indexOf("}", id);
                fields.push(dis.substr(id + 1, clo - id-1).trim());
                id = dis.indexOf("{", clo);
            }
        }
        var i = 0;
        var multiple = '';
        if (!!this.props.multiple)
        {
            if(this.props.multiple===true)
            {
                multiple = 'multiple';
            }
        }
        var tooltip = "Click chuột hoặc nhấn space để chọn";
        if (!!this.props.tooltip)
        {
            tooltip = this.props.tooltip;
        }
        var count = fields.length;
        var temptext = "";
        var option = this.props.lst.map(function (item) {
            temptext = dis;
            for (i = 0; i < count; i++)
            {
                temptext =temptext.replace("{"+fields[i]+"}", item[fields[i]]); 
            }
            return <option value={item[self.props.valuefield] } key={item[self.props.valuefield]} >{temptext}</option>;
            });
        return (
            <div className="btn-group">
                    <select  className="form-control" multiple={multiple} id={this.props.id} title={tooltip}>
                        {select1}{option}
                        </select>
            </div>
        );
    }
});