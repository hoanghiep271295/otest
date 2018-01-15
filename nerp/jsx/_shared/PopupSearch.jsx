/**
*Thực hiện tạo một popup tìm kiếm
*state dataSearch: dữ liệu sẽ tìm kiếm, được set tại List: mã, tên, ghi chú ...
*prop id: id của mỗi input
*prop title: label, bên cạnh input: Mã, tên, ghi chú ...
*prop type: kiểu input: text, number...
*select: chọn kiểu tìm kiếm cho mỗi input. Có 2 loại tìm kiếm là contain và equal
*para id: định dạng: type + (prop) id
*/
var PopupSearch = React.createClass({
    getInitialState: function () {
        return {
            dataSearch: []
        };
    },
    componentWillMount: function () {
        //var tab = new Tab(false, 'popupsearch', 'PopupSearch', null, null, null, null, null, null, null);
        //component.add('popupsearch', this);
    },
    Show:function()
    {
        $('#public_search').modal('show');
    },
    Hide:function()
    {
        $('#public_search').modal('hide');
    },
    doSearch:function()
    {
        console.log('Hit the search');
        var datasearch = this.props.list;
        var obj = [];
        var listRow = [];
        if (!!datasearch) {
            datasearch.forEach(function (item, index) {
                obj[item.id] = { 'type': $('#' + 'public_search_type_' + item.id).val(), 'value': $('#' + 'public_search_' + item.id).val() };
                });
        }
        this.props.callbackfunction(obj);
        this.Hide();
    },
    getDefault:function(id, list)
    {
        if(list===null)
        {
            return null;
        }
        if (!list[id])
        {
            return null;
        }
        return list[id];
    },
    render: function () {
        var datasearch = this.props.list;
        var defaultvalue = this.props.obj;
        var listRow = [];
        var that = this;
        if (!!datasearch) {
            datasearch.forEach(function (item, index) {
                var obj = that.getDefault(item.id, defaultvalue);
                listRow.push(<Field title={item.title} id={item.id} type={item.type} key={index } combo = {item.combo} obj={obj}/>);
            });
        }
        console.log('Sinh ra cho', datasearch);
        return (
            <div className="modal fade" id="public_search" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div className="modal-dialog">
                    <div className="modal-content">
                        <div className="modal-header">
                            <button type="button" className="close" data-dismiss="modal"><span aria-hidden="true">&times;</span
><span className="sr-only">Close</span></button>
                            <h4 className="modal-title" id="myModalLabel">Tìm kiếm</h4>
                        </div>
                        <div className="modal-body">
                            <form className="form-horizontal" role="form">
                                {listRow}
                            </form>
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-primary" onClick={this.doSearch}>Tìm kiếm</button>
                            <button type="button" className="btn btn-danger" data-dismiss="modal">Đóng</button>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
});
var Field = React.createClass({
    componentDidMount: function () {
        var obj = this.props.obj;
        console.log(obj);
        if (obj === null) {
            obj = { 'type': false, 'value': '' };
        }
        console.log(obj);
        $('#public_search_' + this.props.id).val(obj.value);
        var index = 0;
        if (obj.type)
        {
            index = 1;
        }
        $('#public_search_type_' + this.props.id).prop('selectedIndex', index);
        console.log('Search default:', obj);
        //this.ChooseTab(this.props.defaulttab);
    },
    render: function () {
        var id = 'public_search_type_' + this.props.id;
        return (
            <div className="form-group">
                <label className="col-sm-2 control-label">{this.props.title}</label>
                <div className="combobox-component comboboxSearch col-sm-2" >
                    <select id={id} style={{ display: this.props.combo }}  >
                        <option value='false'>Contain</option>
                        <option value='true'>Equal</option>
                    </select>
                </div>
                 <div className="col-sm-8">
                    <input className="form-control" id={'public_search_'+this.props.id} type={this.props.type}   />
                 </div>
            </div>
        );
    }
});