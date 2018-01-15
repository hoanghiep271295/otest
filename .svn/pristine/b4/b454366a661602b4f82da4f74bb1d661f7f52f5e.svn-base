
var WarehouseApp = React.createClass({
    componentWillMount: function () { },
    componentDidMount: function(){ },
    render: function () {
        var path=[{ title: 'Cấp kho', status: 'active', link: '' }];
        var tab=[];
        //Thêm một tab - id nên đăt theo đung luat de sau nay load duoc tu controller mac dinh
        tab.push({Com:WarehouseList, id:'warehouse',suburl:'warehouse', title:'Danh mục kho', parentTitle:'Danh mục kho', path:path});
        ////Thêm một tab
        //path=[{ title: 'Danh sách 2', status: 'active', link: '' }];;
        //tab.push({Com:List2, id:'timeline', title:'Danh sách 2', parentTitle:'Cập nhật danh sách 2',  path:path});
        var buts=[];
        ////Thêm một tab
        //path=[{ title: 'Danh sách 3', status: 'active', link: '' }];;
        //tab.push({Com:List1, id:'newone', title:'Danh sách 3', parentTitle:'Cập nhật danh sách 3', path:path});
        var obj = getDefaultFromServer();
        var defaulttab="warehouse";
        if(!isMiss(obj.defaulttab))
        {
            defaulttab=obj.defaulttab;
        }
        console.log('Set default tab to:', defaulttab);
        return (
                <TabHeader Tabs={tab} ref='TabHeader' defaulttab={defaulttab} basepath='/warehouse/index/' />
        );
    }
});

ReactDOM.render(<WarehouseApp/>, document.getElementById('container'));