/**
 * Hiển thị danh sách các nút lệnh trên bảng
 * list: Danh sách các nút lệnh sẽ được hiển thị - danh sách này nên được lưu vào trong state để đảm bảo không render lại khi cập nhật lại phẩn hiển thị chính
 * Ví dụ: buts: [{ title: 'Thêm mới', callback: this.onNewClick, icon: ' fa fa-files-o', ref: 'cmdAdd' }, { title: 'Sửa', callback: this.onEidtClick, icon: 'fa fa-edit', ref: 'cmdEdit' }, { title: 'Xóa', callback: this.docallback, icon: 'fa fa-trash-o fa-fw', ref: 'cmdDel' }, { title: 'In', callback: this.docallback, icon: 'fa fa-line-chart', ref: 'cmdPri' }, { title: 'Lọc', callback: this.docallback, icon: 'fa fa-filter', ref: 'cmdFil' }],
 */
var ButtonList = React.createClass({
    //getInitialState: function () {
    //    return {
    //        butstatus: []
    //    }
    //},
    componentWillMount: function () {
        //var status=[];
        //var thelist = this.props.list;
        //var namesList = thelist.map(function (item) {
        //    status[item.ref]=false;
        //});
        //this.setState({butstatus:status});
    },
    componentDidMount: function () {
       
    },
    shouldComponentUpdate: function (nextProps, nextState) {
        //console.log('Check componentUpdate', nextProps.list, this.props.list, nextProps.list !== this.props.list, nextProps.list == this.props.list);
        return nextProps.list !== this.props.list;
    },
    /**
    *Đặt lại trạng thái của nút lệnh
    */
    setButtonStatus:function(id, status) {
//        console.log('Set button id:', id);
        if(!isMiss(this.refs[id]))
        {
//            console.log('Do Set button id:', id, status, this.refs[id]);
            this.refs[id].disabled = !status;
        }
    },
    resetButton:function() {
        var thelist = this.props.list;
        if (!isMiss(thelist)) {
            var namesList = thelist.map(function(item) {
                this.refs[item.ref].disabled = false;
            }.bind(this));
        }
    },

    render: function () {
        //console.log(this.props.list);
        var that=this;
        var buts = [];
        var thelist = this.props.list;
        if(!isMiss(thelist))
        {
            var namesList = thelist.map(function (item) {
            buts.push(<button type="button" className="btn btn-default" onClick={item.callback} ref={item.ref} key={item.ref} title={item.tooltip}><i className={item.icon } title={item.tooltip}> </i> {item.title}</button>);
            });
        }
return (
            <div className="btn-group" style={{float:'right'}}>
            {buts}
            </div>
        );
}
});