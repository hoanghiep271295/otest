
var QuestionChildApp = React.createClass({
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
    /**
* Thiết lập một giá trị theo key - có thể là object
*/
    setKeyValue: function (key, value) {
        this.refs.TabHeader.setKeyValue(key, value);
    },
    /**
    * Lấy một giá trị theo key, nếu chưa có thì trả về null - dành cho các trường hợp cần truyền tham số từ các tab
    */
    getKeyValue: function (key) {
        return this.refs.TabHeader.getKeyValue(key);
    },
    ChooseTab:function(id) {
        this.refs.TabHeader.ChooseTab(id);
    },
    FirstTab:function() {
        this.refs.TabHeader.ChooseTab('questiongroup');
    },
    componentWillMount: function () {
       
        
    },
    componentDidMount: function(){
        
        
    },
    render: function () {
        var path=[{ title: 'Câu hỏi', status: 'active', link: '' }];;
        var tab=[];
        //Thêm một tab - id nên đăt theo đung luat de sau nay load duoc tu controller mac dinh
        tab.push({ Com: ListQGROUP, id: 'questiongroup', suburl: '', title: 'Các câu hỏi', parentTitle: 'Danh sách các câu hỏi', path: path });
        //Thêm một tab
        path=[{ title: 'Câu hỏi',  link: '/question/index' }, { title: 'Chi tiết Câu hỏi', status: 'active', link: '' }];
        tab.push({ Com: ListQuestion, id: 'question', suburl: '', title: 'Chi tiết câu hỏi', parentTitle: 'Danh sách chi tiết câu hỏi', path: path });
        //Thêm một tab
        path = [{ title: 'Câu trả lời', link: '/question/index' }, { title: 'Trả lời', status: 'active', link: '' }];
        tab.push({ Com: ListAnswer, id: 'answer', suburl: '', title: 'Trả lời', parentTitle: 'Danh sách câu trả lời', path: path });
        //Thêm một tab
        //path=[{ title: 'Nhóm phân quyền', status: 'active', link: '' }];;
        //tab.push({Com:AdmingroupStaff, id:'admingroupstaff',suburl:'admingroup', title:'Phân quyền cho cán bộ', parentTitle:'Cán bộ giáo viên trong nhóm ',  path:path});
        //var buts=[];
        ////Thêm một tab
        //path=[{ title: 'Danh sách 3', status: 'active', link: '' }];;
        //tab.push({Com:List1, id:'newone', title:'Danh sách 3', parentTitle:'Cập nhật danh sách 3', path:path});
        var obj = window.getDefaultFromServer();
        var defaulttab = "questiongroup";//tab mặc định khi khoong chọn
        if(!isMiss(obj.defaulttab))
        {
            defaulttab=obj.defaulttab;
        }
//        console.log('Default to:', defaulttab);
        return (
                <TabHeader Tabs={tab} ref='TabHeader' defaulttab={defaulttab} basepath='/question/index' />
        );
    }
});

//ReactDOM.render(<EthnicApp/>, document.getElementById('container'));