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
'use strict';

var Combobox = React.createClass({
    displayName: 'Combobox',

    componentDidMount: function componentDidMount() {
        if (!!this.props.callback) {
            var self = this;
            $('#' + this.props.id).change(function () {
                self.props.callback(this.value);
            });
        }
    },
    componentDidUpdate: function componentDidUpdate() {
        if (!!this.props.defaultvalue) {
            $('#' + this.props.id).val(this.props.defaultvalue);
        }
    },

    render: function render() {
        var select1 = [];
        if (this.props.toptitle != null) {
            select1.push(React.createElement(
                'option',
                { value: this.props.topvalue, key: 'none' },
                this.props.toptitle
            ));
        }
        var self = this;
        var dis = self.props.textfield;
        var fields = [];
        var id = dis.indexOf("{");
        // ReSharper disable once AssignedValueIsNeverUsed
        var clo = 0;
        if (id < 0) {
            //one field
            fields.push(dis);
        } else {
            while (id >= 0) {
                clo = dis.indexOf("}", id);
                fields.push(dis.substr(id + 1, clo - id - 1).trim());
                id = dis.indexOf("{", clo);
            }
        }
        var i = 0;
        var count = fields.length;
        var temptext = "";
        var option = this.props.lst.map(function (item) {
            temptext = dis;
            for (i = 0; i < count; i++) {
                temptext = temptext.replace("{" + fields[i] + "}", item[fields[i]]);
            }
            return React.createElement(
                'option',
                { value: item[self.props.valuefield], key: item[self.props.valuefield] },
                temptext
            );
        });
        return React.createElement(
            'div',
            { className: 'btn-group' },
            React.createElement(
                'select',
                { className: 'form-control', id: this.props.id },
                select1,
                option
            )
        );
    }
});

