
var EthnicApp = React.createClass({
    //getInitialState: function () {
    //    return {
    //        dataSearch: [],
    //        tab: [],
    //        tabindex:0,
    //        buts: [ { title: 'Thêm mới', callback: this.onNewClick, icon: ' fa fa-files-o', ref: 'cmdAdd' }
    //                , { title: 'Sửa', callback: this.onEidtClick, icon: 'fa fa-edit', ref: 'cmdEdit' }
    //                , { title: 'Xóa', callback: this.onDeleteClick, icon: 'fa fa-trash-o fa-fw', ref: 'cmdDel' }
    //                , { title: 'In', callback: this.onReportClick, icon: 'fa fa-line-chart', ref: 'cmdPri' }
    //                , { title: 'Lọc', callback: this.searchCall, icon: 'fa fa-filter', ref: 'cmdFil' }],
    //    }
    //},
    componentWillMount: function () {
       
        
    },
    componentDidMount: function(){
        
        
    },
    render: function () {
        var path=[{ title: 'Dân tộc', status: 'active', link: '' }];;
        var tab=[];
        //Thêm một tab - id nên đăt theo đung luat de sau nay load duoc tu controller mac dinh
        tab.push({ Com: EthnicList, id: 'ethnic', suburl: 'ethnic', title: 'Dân tộc', parentTitle: 'Danh sách dân tộc', path: path });
        //Thêm một tab
        path=[{ title: 'Tôn giáo', status: 'active', link: '' }];;
        tab.push({ Com: ReligionList, id: 'religion', suburl: 'religion', title: 'Tôn giáo', parentTitle: 'Danh sách tôn giáo ', path: path });
        //Thêm một tab
        //path=[{ title: 'Nhóm phân quyền', status: 'active', link: '' }];;
        //tab.push({Com:AdmingroupStaff, id:'admingroupstaff',suburl:'admingroup', title:'Phân quyền cho cán bộ', parentTitle:'Cán bộ giáo viên trong nhóm ',  path:path});
        //var buts=[];
        ////Thêm một tab
        //path=[{ title: 'Danh sách 3', status: 'active', link: '' }];;
        //tab.push({Com:List1, id:'newone', title:'Danh sách 3', parentTitle:'Cập nhật danh sách 3', path:path});
        var obj = getDefaultFromServer();
        var defaulttab = "ethnic";//tab mặc định khi khoong chọn
        if(!isMiss(obj.defaulttab))
        {
            defaulttab=obj.defaulttab;
        }
//        console.log('Default to:', defaulttab);
        return (
                <TabHeader Tabs={tab} ref='TabHeader' defaulttab={defaulttab} basepath='/admin/ethnic' />
        );
    }
});

ReactDOM.render(<EthnicApp/>, document.getElementById('container'));