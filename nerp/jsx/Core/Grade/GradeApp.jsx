
var GradeApp = React.createClass({
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
        var path = [{ title: 'Khóa', status: 'active', link: '' }];;
        var tab=[];
        //Thêm một tab - id nên đăt theo đung luat de sau nay load duoc tu controller mac dinh
        tab.push({ Com: GradeList, id: 'grade', suburl: 'grade', title: 'Khóa', parentTitle: 'Danh sách khóa', path: path });
        //Thêm một tab
        path=[{ title: 'Lớp', status: 'active', link: '' }];;
        tab.push({ Com: ClassList, id: 'class', suburl: 'class', title: 'Lớp', parentTitle: 'Danh sách lớp học', path: path });
        //Thêm một tab
        path = [{ title: 'Sinh viên', status: 'active', link: '' }];;
        tab.push({ Com: StudentList, id: 'student', suburl: 'student', title: 'Sinh viên', parentTitle: 'Danh sách sinh viên', path: path });
        //Thêm một tab
        //path=[{ title: 'Nhóm phân quyền', status: 'active', link: '' }];;
        //tab.push({Com:AdmingroupStaff, id:'admingroupstaff',suburl:'admingroup', title:'Phân quyền cho cán bộ', parentTitle:'Cán bộ giáo viên trong nhóm ',  path:path});
        //var buts=[];
        ////Thêm một tab
        //path=[{ title: 'Danh sách 3', status: 'active', link: '' }];;
        //tab.push({Com:List1, id:'newone', title:'Danh sách 3', parentTitle:'Cập nhật danh sách 3', path:path});
        var obj = window.getDefaultFromServer();
        var defaulttab = "grade";
        if(!isMiss(obj.defaulttab))
        {
            defaulttab=obj.defauhlttab;
        }
//        console.log('Default to:', defaulttab);
        return (
                <TabHeader Tabs={tab} ref='TabHeader' defaulttab={defaulttab} basepath='/grade/index' />
        );
    }
});

ReactDOM.render(<GradeApp/>, document.getElementById('container'));