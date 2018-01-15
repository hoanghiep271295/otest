var SkillApp = React.createClass({
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
    componentDidMount: function () {

    },
    render: function () {
        var path = [{ title: 'Kỹ năng', status: 'active', link: '' }];;
        var tab = [];
        //Thêm một tab - id nên đăt theo đung luat de sau nay load duoc tu controller mac dinh
        tab.push({ Com: SkillList, id: 'skill', suburl: 'skill', title: 'Kỹ năng', parentTitle: 'Danh sách Kỹ năng', path: path });
        //Thêm một tab
        path = [{ title: 'Nội dung theo bố cục', status: 'active', link: '' }];;
        tab.push({ Com: ContentTypeList, id: 'contenttype', suburl: 'contenttype', title: 'Nội dung theo bố cục', parentTitle: 'Danh sách phân loại nội dung theo bố cục', path: path });
        //Thêm một tab
        path = [{ title: 'Nội dung theo chủ điểm', status: 'active', link: '' }];;
        tab.push({ Com: TagList, id: 'tag', suburl: 'tag', title: 'Nội dung theo chủ điểm', parentTitle: 'Danh sách phân loại nội dung theo chủ điểm', path: path });


        //path=[{ title: 'Nhóm phân quyền', status: 'active', link: '' }];;
        //tab.push({Com:AdmingroupStaff, id:'admingroupstaff',suburl:'admingroup', title:'Phân quyền cho cán bộ', parentTitle:'Cán bộ giáo viên trong nhóm ',  path:path});
        //var buts=[];
        ////Thêm một tab
        //path=[{ title: 'Danh sách 3', status: 'active', link: '' }];;
        //tab.push({Com:List1, id:'newone', title:'Danh sách 3', parentTitle:'Cập nhật danh sách 3', path:path});
        var obj = window.getDefaultFromServer();
        var defaulttab = "skill";//tab mặc định khi khoong chọn
        if (!isMiss(obj.defaulttab)) {
            defaulttab = obj.defaulttab;
        }
        //        console.log('Default to:', defaulttab);
        return (
                <TabHeader Tabs={tab} ref='TabHeader' defaulttab={defaulttab} basepath='/admin/skill' />
        );
    }
});

ReactDOM.render(<skillApp />, document.getElementById('container'));