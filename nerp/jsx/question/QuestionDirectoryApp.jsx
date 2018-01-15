
var QuestionDirectoryApp = React.createClass({
    render: function () {
        var path=[{ title: 'Loại câu hỏi', status: 'active', link: '' }];;
        var tab=[];
        //Thêm một tab - id nên đăt theo đung luat de sau nay load duoc tu controller mac dinh
        tab.push({ Com: QuestiontypeList, id: 'questiontype', suburl: 'questiontype', title: 'Loại câu hỏi', parentTitle: 'Danh sách loại câu hỏi', path: path });
        //Thêm một tab
        path = [{ title: 'Câu hỏi theo tình huống sử dụng', status: 'active', link: '' }];;
        tab.push({ Com: QuestionuseList, id: 'questionuse', suburl: 'questionuse', title: 'Câu hỏi theo tình huống sử dụng', parentTitle: 'Danh sách câu hỏi theo tình huống sử dụng', path: path });
        //Thêm một tab
        //path=[{ title: 'Hình thức nội dung', status: 'active', link: '' }];;
        //tab.push({ Com: ContenttypeList, id: 'contenttype', suburl: 'contenttype', title: 'Hình thức nội dung', parentTitle: 'Danh sách hình thức nội dung', path: path });
        //var buts=[];
        ////Thêm một tab
        //path=[{ title: 'Danh sách 3', status: 'active', link: '' }];;
        //tab.push({Com:List1, id:'newone', title:'Danh sách 3', parentTitle:'Cập nhật danh sách 3', path:path});
        var obj = window.getDefaultFromServer();
        var defaulttab = "questiontype";//tab mặc định khi khoong chọn
        if(!isMiss(obj.defaulttab))
        {
            defaulttab=obj.defaulttab;
        }
        //        console.log('Default to:', defaulttab);
        return (
                <TabHeader Tabs={tab} ref='TabHeader' defaulttab={defaulttab} basepath='/directory/question' />
        );
}
});

ReactDOM.render(<QuestionDirectoryApp/>, document.getElementById('container'));