
var SubjectDirectoryApp = React.createClass({
    render: function () {
        var path=[{ title: 'Kỹ năng', status: 'active', link: '' }];;
        var tab=[];
        //Thêm một tab - id nên đăt theo đung luat de sau nay load duoc tu controller mac dinh
        tab.push({ Com: SkillList, id: 'skill', suburl: 'skill', title: 'Kỹ năng', parentTitle: 'Danh sách kỹ năng', path: path });
        //Thêm một tab
        path=[{ title: 'Chủ đề', status: 'active', link: '' }];;
        tab.push({ Com: TagList, id: 'tag', suburl: 'tag', title: 'Chủ đề', parentTitle: 'Danh sách chủ đề', path: path });
        //Thêm một tab
        path=[{ title: 'Hình thức nội dung', status: 'active', link: '' }];;
        tab.push({ Com: ContenttypeList, id: 'contenttype', suburl: 'contenttype', title: 'Hình thức nội dung', parentTitle: 'Danh sách hình thức nội dung', path: path });
        var buts=[];
        ////Thêm một tab
        //path=[{ title: 'Danh sách 3', status: 'active', link: '' }];;
        //tab.push({Com:List1, id:'newone', title:'Danh sách 3', parentTitle:'Cập nhật danh sách 3', path:path});
        var obj = window.getDefaultFromServer();
        var defaulttab = "skill";//tab mặc định khi khoong chọn
        if(!isMiss(obj.defaulttab))
        {
            defaulttab=obj.defaulttab;
        }
//        console.log('Default to:', defaulttab);
        return (
                <TabHeader Tabs={tab} ref='TabHeader' defaulttab={defaulttab} basepath='/directory/subject' />
        );
    }
});

ReactDOM.render(<SubjectDirectoryApp/>, document.getElementById('container'));