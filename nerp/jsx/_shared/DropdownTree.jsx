﻿/**
*Thực hiện tạo một trê trên đối tượng
*@para id: id của thẻ select của đối tượng được sinh ra
*@para title: hiển thị khi có combo
*@para lst: Danh sách dữ liệu
*@para mapper: Ánh xạ các trường với dữ liệu trên cây (config = { id: "CODE", text: "NAME", parent: "PARENTCODE", idext: "EXTCODE" };)
*@para check: Cho phép hiển thị check box hoặc không hiển thị check {true/false (false)}
*@para height: độ cao của cây height='300px' - không có mặc định full
*@para selectChildren: tự động chọn con khi cho phép chọn nhiều {true/false (false)}
*@para onSelect: Gọi khi một đối tượng được chọn (element - phần tử được chọn)
*@para onCheck: Gọi khi một đối tượng được check hoặc bỏ check (element - phần tử được chọn, status - đóng hay mở)
*@para onExpand: Gọi khi một đối tượng được expand (element - danh sách phần tử có thay đổi, status - đóng hay mở)
---- Các hàm cung cấp khác
*Các đối tượng được trả về bao gồm (id, text, parent, idext)
setValue(key) - thiết lập đối tượng được chọn
getValue(): lấy về đối tượng được chọn
setCheck(keys): Thiết lập các đối tượng được check 
getChecked(): trả về các đối tượng đang được check trên cây
*/
var DropdownTree = React.createClass({
    getInitialState () {
        return {
            value: null,
            checked:[],
            data:[]
        };
    },
    componentWillMount: function () {
//        console.log('Combo box willMount:', this.props.lst);
    },
    componentDidMount: function () {
        //console.log('Combo box didMount:', this.props.lst);
        if ($("#" + this.props.id).length > 0) {
            $("#" + this.props.id)[0].innerHTML = '';
        }

        var mapper = this.props.mapper;
        var data = this.processData(this.props.lst, mapper);
        //        console.log('Data:', data);
        this.setState({ data: data });
        var multiSelect = false;
        if (!!this.props.check && this.props.check) {
            multiSelect = true;
        }
        var selectChildren = false;
        if (!!this.props.selectChildren && this.props.selectChildren) {
            selectChildren = true;
        }
        var height = 300;
        if (!!this.props.height) {
            height = this.props.height;
        }
        //        console.log('multiSelect:',multiSelect);
        var options = {
            title: this.props.title,
            data: data,
            maxHeight: height,
            clickHandler: this.onSelect,
            expandHandler: this.onExpand,
            checkHandler: this.onCheck,
            closedArrow: '<i class="fa fa-caret-right" aria-hidden="true"></i>',
            openedArrow: '<i class="fa fa-caret-down" aria-hidden="true"></i>',
            multiSelect: multiSelect,
            selectChildren: selectChildren,
        }
        $("#" + this.props.id).DropDownTree(options);
    },
    shouldComponentUpdate: function (nextProps, nextState) {
//        console.log('Check componentUpdate', nextProps.lst !== this.props.lst, nextProps.lst);
        return nextProps.lst !== this.props.lst;
    },
    componentDidUpdate: function () {
//        console.log('Do update droptreee', this.props.lst);
        if ($("#" + this.props.id).length > 0) {
            $("#" + this.props.id)[0].innerHTML = '';
        }

        var mapper = this.props.mapper;
        var data = this.processData(this.props.lst, mapper);
        //        console.log('Data:', data);
        this.setState({ data: data });
        var multiSelect = false;
        if (!!this.props.check && this.props.check) {
            multiSelect = true;
        }
        var selectChildren = false;
        if (!!this.props.selectChildren && this.props.selectChildren) {
            selectChildren = true;
        }
        var height = 300;
        if (!!this.props.height) {
            height = this.props.height;
        }
        //        console.log('multiSelect:',multiSelect);
        var options = {
            title: this.props.title,
            data: data,
            maxHeight: height,
            clickHandler: this.onSelect,
            expandHandler: this.onExpand,
            checkHandler: this.onCheck,
            closedArrow: '<i class="fa fa-caret-right" aria-hidden="true"></i>',
            openedArrow: '<i class="fa fa-caret-down" aria-hidden="true"></i>',
            multiSelect: multiSelect,
            selectChildren: selectChildren,
        }
        $("#" + this.props.id).DropDownTree(options);
    },

    processData: function (lst, mapper)
    {
//        console.log(lst);
        var que = [];
        var data = [];
        //start to
        var i;
        for (i = 0; i < lst.length ; i++) {
//            console.log(mapper.parent, lst[i][mapper.parent]);
            var tempobj = lst[i];
            //Do process
            if (tempobj[mapper.parent] === '' || tempobj[mapper.parent] === '#' || tempobj[mapper.parent] === null) {
                //The root;
                var obj = { id: tempobj[mapper.id], title: tempobj[mapper.text], href: '#' + tempobj[mapper.id], dataAttrs: [{ title: 'parent', data: tempobj[mapper.parent] }, { title: 'text', data: tempobj[mapper.text] }, { title: 'id', data: tempobj[mapper.id] }, { title: 'idext', data: tempobj[mapper.idext] }] };
                que.push(obj);
                data.push(obj);
            }
        }
        while (que.length > 0) {
            var item = que[0];
            que.splice(0, 1);
            var children = [];
            for (i = 0; i < lst.length ; i++) {
                var tempobj = lst[i];
                //Do process
                if (tempobj[mapper.parent] === item.id) {
                    //The root;
                    var obj = { id: tempobj[mapper.id], title: tempobj[mapper.text], href: '#' + tempobj[mapper.id], dataAttrs: [{ title: 'parent', data: tempobj[mapper.parent] }, { title: 'text', data: tempobj[mapper.text] }, { title: 'id', data: tempobj[mapper.id] }, { title: 'idext', data: tempobj[mapper.idext] }] };
                    que.push(obj);
                    children.push(obj);
                }
            }
            if (children.length > 0) {
//                console.log('check', children, children !== []);
                item.data = children;
            }

        }
        return data;
    },
    /**
    *Thiết lập lựa chọn theo mã
    */
    setValue: function (key) {
//        console.log('Set value to :', key);
        if (!!key) {
          this.setState({ value: key });
        }
    },
    /**
    *Lấy về đối tượng đang được lựa chọn id, textContent, dataset
    */
    getValue: function () {
        return this.state.value;
    },
    /**
    *Thiết lập các check mặc định trên cây
    */
    setCheck:function(keys)
    {

    },
    /**
    *lấy về danh sách các check trên cây
    */
    getChecked:function()
    {
        return this.state.checked;
    },
    onSelect: function (element) {
        $("#"+this.props.id).SetTitle($(element).find("a").first().text());
        if (!!this.props.onSelect) {
            this.props.onSelect(element[0].dataset);
        }
//        console.log( element);
//        console.log('Select', element[0].id, element[0].dataset);
        this.setState({ value: element[0].dataset });
    },
    onCheck: function (element, status)
    {
        var checked = this.state.checked;
        var i = 0;
        var j = 0;
        var index = -1;
        var lstobj = [];
        for (i = 0; i < element.length; i++)
        {
            lstobj.push(element[i].dataset);
        }
        if (!!this.props.onCheck) {
            this.props.onCheck(lstobj, status);
        }
        for (j = 0; j < lstobj.length; j++)
        {
            index = -1;
            for(i=0;i<checked.length;i++)
            {
                if (lstobj[j].id === checked[i].id)
                {
                    index = i;
                }
            }
            if(index===-1 && status)
            {
                checked.push(lstobj[j]);
            }
            if(index!==-1 && (!status))
            {
                checked.splice(index, 1);//bỏ
            }
        }
        this.setState({ checked: checked });
    },
    onExpand: function (element, status)
    {
        if (!!this.props.onExpand) {
            this.props.onExpand(element[0].dataset, status);
        }
//        console.log('Expand:',element[0], status);
    },
    updateData (lst) {
        var mapper = this.props.mapper;
        var data = this.processData(lst, mapper);
        this.setState({ data: data });
//        console.log(data);
    },

    render () {
        return (<div className="dropdown dropdown-tree" id={this.props.id }></div>);
    }
});