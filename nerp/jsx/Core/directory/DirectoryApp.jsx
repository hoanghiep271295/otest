
var DirectoryApp = React.createClass({
    render: function () {
        var path=[{ title: 'Quân hàm', status: 'active', link: '' }];;
        var tab=[];
        //Thêm một tab - id nên đăt theo đung luat de sau nay load duoc tu controller mac dinh
        tab.push({ Com: ArmyrankList, id: 'armyrank', suburl: 'armyrank', title: 'Quân hàm', parentTitle: 'Danh sách quân hàm', path: path });
        //Thêm một tab
        path=[{ title: 'Chức vụ', status: 'active', link: '' }];;
        tab.push({ Com: LeveltitleList, id: 'leveltitle', suburl: 'leveltitle', title: 'Chức vụ', parentTitle: 'Danh sách chức vụ', path: path });
        //Thêm một tab
        path=[{ title: 'Chức vụ Đảng', status: 'active', link: '' }];;
        tab.push({ Com: PartyleveltitleList, id: 'partyleveltitle', suburl: 'partyleveltitle', title: 'Chức vụ Đảng', parentTitle: 'Danh sách chức vụ Đảng', path: path });
        //var buts=[];
        ////Thêm một tab
        //path=[{ title: 'Danh sách 3', status: 'active', link: '' }];;
        //tab.push({Com:List1, id:'newone', title:'Danh sách 3', parentTitle:'Cập nhật danh sách 3', path:path});
        var obj = getDefaultFromServer();
        var defaulttab = "armyrank";//tab mặc định khi khoong chọn
        if(!isMiss(obj.defaulttab))
        {
            defaulttab=obj.defaulttab;
        }
//        console.log('Default to:', defaulttab);
        return (
                <TabHeader Tabs={tab} ref='TabHeader' defaulttab={defaulttab} basepath='/directory/index' />
        );
    }
});

ReactDOM.render(<DirectoryApp/>, document.getElementById('container'));