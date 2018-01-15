﻿
var SubjectApp = React.createClass({
    render: function () {
        var tab = [];
        var path=[{ title: 'Môn học', status: 'active', link: '' }];
        //Thêm một tab - id nên đăt theo đung luat de sau nay load duoc tu controller mac dinh
        tab.push({ Com: SubjectList, id: 'subject', suburl: 'subject', title: 'Môn học', parentTitle: 'Danh sách môn học', path: path });
        //Thêm một tab
        path=[{ title: 'Lớp môn học', status: 'active', link: '' }];;
        tab.push({ Com: CourseList, id: 'course', suburl: 'course', title: 'Khóa học', parentTitle: 'Danh sách khóa học', path: path });
        //Thêm một tab
        path=[{ title: 'Sinh viên', status: 'active', link: '' }];;
        tab.push({ Com: CourseRegisterStudent, id: 'studentregister', suburl: 'studentregister', title: 'Danh sách sinh viên', parentTitle: 'Danh sách sinh viên', path: path });
        //Thêm một tab
        //path = [{ title: 'Bài học', status: 'active', link: '' }];;
        //tab.push({ Com: CourseStudied, id: 'coursestudied', suburl: 'coursestudied', title: 'Danh sách bài học', parentTitle: 'Danh sách bài học', path: path });
        ///giá trị mặc định 
        var obj = window.getDefaultFromServer();
        var defaulttab = "subject";//tab mặc định khi không chọn
        if(!isMiss(obj.defaulttab))
        {
            defaulttab=obj.defaulttab;
        }
        // console.log('Default to:', defaulttab);
        return (
                <TabHeader Tabs={tab} ref='TabHeader' defaulttab={defaulttab} basepath='/subject/subject' />
        );
}
});

    ReactDOM.render(<SubjectApp/>, document.getElementById('container'));