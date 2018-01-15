﻿/**
*Thực hiện tạo một combo bõ từ dữ liệu được đưa vào
*@para lst: danh sách các đối tượng sinh ra combobox
*@para valuefield: trường lấy dữ liệu
*@para textfield: trường hiển thị dữ liệu; Nếu sử dụng nhiều trường thì phải sử dụng {} bao ngoài tên trường {CODEVIEW}-{NAME}
*@para topvalue: giá trị đầu tiên 
*@para toptitle: tiêu đề đầu tiên
*@para defaultvalue: Giá trị lựa chọn mặc định
*@para id: id của thẻ select của đối tượng được sinh ra
*@para multiple: cho phép chọn nhiều đối tượng / default: false
*@para tooltip: Hiển thị trong ô khi chưa chọn dữ liệu - mặc định là "Chọn... "
*@para callback(obj): Hàm xử lý khi lựa chọn một đối tượng
* ví dụ: <Combobox lst={this.state.cbo} valuefield='id' textfield='{text}' defaultvalue='5' id='cbo' callback={this.hell}></Combobox>
 * **
 * Các hàm thực hiện đặt và lấy dữ liệu
 * setList(): thiết lập lại danh sách các cái cần hiển thị
 * setValue(): thiết lập lại danh sách đã chọn
 * getValue(): lấy danh sách đã chọn
 * setValueString(): thiết lập danh sách chọn theo chuỗi phân biệt bởi dấu ','
 * getValueString(): lấy danh sách đã chọn theo mã cách nhau bởi dấu ','
*/
var Combobox = React.createClass({
    getInitialState () {
        return {
            value: '',
            options: []
        };
    },
    componentWillMount: function () {
        var options = [];
        if (this.props.toptitle != null) {
            options.push({ value: this.props.topvalue, label: this.props.toptitle });
         }
        var self = this;
        var dis = checkMiss(self.props.textfield, '{NAME}');//default is name
        var valfield = checkMiss(self.props.valuefield, 'CODE');
        var fields = [];
        var id = dis.indexOf("{");
        // ReSharper disable once AssignedValueIsNeverUsed
        var clo = 0;
        if (id < 0) {
            //one field
            fields.push(dis);
        }
        else {
            while (id >= 0) {
                clo = dis.indexOf("}", id);
                fields.push(dis.substr(id + 1, clo - id - 1).trim());
                id = dis.indexOf("{", clo);
            }
        }
        var count = fields.length;
        var temptext = "";
        var option = this.props.lst.map(function (item) {
            temptext = dis;
            for (i = 0; i < count; i++)
            {
                temptext =temptext.replace("{"+fields[i]+"}", item[fields[i]]); 
            }
            options.push({ value: item[valfield], label: temptext });
        });
        this.setState({ options: options });
    },
    setList: function (lst) {
        if (isMiss(lst))
        {
            this.setState({ options: [] });
            return 0;
        }
        var options = [];
        if (this.props.toptitle != null) {
            options.push({ value: this.props.topvalue, label: this.props.toptitle });
        }
        var self = this;
        var dis = checkMiss(self.props.textfield, '{NAME}');//default is name
        var valfield = checkMiss(self.props.valuefield, 'CODE');
        var fields = [];
        var id = dis.indexOf("{");
        // ReSharper disable once AssignedValueIsNeverUsed
        var clo = 0;
        if (id < 0) {
            //one field
            fields.push(dis);
        }
        else {
            while (id >= 0) {
                clo = dis.indexOf("}", id);
                fields.push(dis.substr(id + 1, clo - id - 1).trim());
                id = dis.indexOf("{", clo);
            }
        }
        var count = fields.length;
        var temptext = "";
        var option = lst.map(function (item) {
            temptext = dis;
            for (i = 0; i < count; i++) {
                temptext = temptext.replace("{" + fields[i] + "}", item[fields[i]]);
            }
            options.push({ value: item[valfield], label: temptext });
        });
        this.setState({ options: options });
    },
    componentDidMount: function () {
//        this.setValue(this.props.defaultvalue);
        this.setState({ value: this.props.defaultvalue });

    },
    componentDidUpdate: function () {

    },
    componentWillReceiveProps: function (nextProps)
    {
        var options = [];
        if (this.props.toptitle != null) {
            options.push({ value: nextProps.topvalue, label: nextProps.toptitle });
        }
        var self = this;
        var dis = nextProps.textfield;
        var fields = [];
        var id = dis.indexOf("{");
        // ReSharper disable once AssignedValueIsNeverUsed
        var clo = 0;
        if (id < 0) {
            //one field
            fields.push(dis);
        }
        else {
            while (id >= 0) {
                clo = dis.indexOf("}", id);
                fields.push(dis.substr(id + 1, clo - id - 1).trim());
                id = dis.indexOf("{", clo);
            }
        }
        var count = fields.length;
        var temptext = "";
        var option = nextProps.lst.map(function (item) {
            temptext = dis;
            for (i = 0; i < count; i++) {
                temptext = temptext.replace("{" + fields[i] + "}", item[fields[i]]);
            }
            options.push({ value: item[self.props.valuefield], label: temptext });
        });
        this.setState({ options: options });
    },
    //shouldComponentUpdate: function (nextProps, nextState) {
    //    //console.log('Check componentUpdate', nextProps.lst !== this.props.lst);
    //    //return nextProps.lst !== this.props.lst;
    //},
    getOptionByValue(key) {
        var options = this.state.options;
        var theitem = null;//not found
        options.map(function (item) {
            if (item.value === key) {
                theitem = item;
            }
        });
        return theitem;
    },
    setValue: function (key) {
        if (!!key) {
            this.setState({value:key});
        }
    },
    setValueString: function (str) {
        console.log(str);
        var that = this;
        var multiple = false;
        if (!!this.props.multiple) {
            if (this.props.multiple === true) {
                multiple = true;
            }
        }
        var temp = "" + str;
        if (multiple) {
            var key = temp.toString().split(",");
            var chose = [];
            key.map(function (item) {
                chose.push(that.getOptionByValue(item));
            });
            this.setState({ value: chose });
        } else {
            var theitem = this.getOptionByValue(str);
            this.setState({ value: theitem });

        }
       
    },
    getValue: function () {
        return this.state.value;
    },
    getValueString: function () {
        var multiple = false;
        if (!!this.props.multiple) {
            if (this.props.multiple === true) {
                multiple = true;
            }
        }
        var temp = "";
//        console.log('get value to string:', this.state.value);
        var chose = this.state.value;
        if (multiple) {
            chose.map(function (item) {
                if (temp !== "") {
                    temp = temp + ',';
                }
                if (!isMiss(item )) {
                    temp = temp + item.value;
                }
            });
        } else {
            if (!isMiss(chose)) {
                temp = chose.value;
            }
        }
        return temp;
    },
    onChange: function (val) {
        if (!!this.props.callback) {
            this.props.callback(val);
        }
        this.setState({ value: val });
    },
    render () {
        var multiple = '';
        if (!!this.props.multiple)
        {
            if(this.props.multiple===true)
            {
                multiple = 'multiple';
            }
        }
        var placeholder = 'Chọn...';
        if (!!this.props.tooltip)
        {
            placeholder = this.props.tooltip;
        }
        return(
            <Select options={this.state.options} onChange= {this.onChange} value= {this.state.value} multi={multiple} placeholder={placeholder }/>
            );
    }
});