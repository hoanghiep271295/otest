
var ExamTimeApp = React.createClass({
    getInitialState: function () {
        return {
            cbo: []
    };
    },
    componentWillMount: function () {    
    },
    componentDidMount: function() {
        this.loadCombobox();
    },
    changeData: function (item) {
        console.log(item);
        var subjectcode = this.refs["SUBJECTCODE"].getValueString();
        if (!!item) {
            this.refs.TabHeader.setKeyValue("subjectcode", item.value);
        }
        this.refs.TabHeader.ChooseTab("examtime");
    },

    loadCombobox: function () {
        $.ajax({
            url: '/Subject/GetAll',
            dataType: 'json',
            success: function (data) {
                this.setState({
                    cbo: data.lst
                });
                if (!!data.lst) {
                    this.refs["SUBJECTCODE"].setValueString(data.lst[0].CODE);
                    this.changeData({ value: data.lst[0].CODE });
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.error('URLNAYODAU', status, err.toString());
            }.bind(this)
        });
    },
    render: function () {
        var path = [{ title: 'Đợt thi', status: 'active', link: '' }];
        var tab=[];
        //Thêm một tab - id nên đăt theo đung luat de sau nay load duoc tu controller mac dinh
        tab.push({ Com: ExamTimeList, id: 'examtime', suburl: 'examtime', title: 'Đợt thi', parentTitle: 'Danh sách đợt thi', path: path });
        tab.push({ Com: ExamFormList, id: 'examformlist', suburl: 'examformlist', title: 'Danh sách đề thi', parentTitle: 'Danh sách đề thi', path: path });
        //Thêm một tab - id nên đăt theo đung luat de sau nay load duoc tu controller mac dinh
        tab.push({ Com: ExamHallList, id: 'examhall', suburl: 'examhall', title: 'Phòng thi', parentTitle: 'Danh sách phòng thi', path: path });
        //Thêm một tab - id nên đăt theo đung luat de sau nay load duoc tu controller mac dinh
        tab.push({ Com: ExamHallStudentList, id: 'examhallstudent', suburl: 'examhallstudent', title: 'Sinh viên trong phòng thi', parentTitle: 'Danh sách sinh viên', path: path });
        var obj = window.getDefaultFromServer();
        var defaulttab = "examtime";
        if(!isMiss(obj.defaulttab))
        {
            defaulttab=obj.defauhlttab;
        }
//        console.log('Default to:', defaulttab);
        return (
            <div>
                <div className="col-sm-3 subjectcodehead">
                    <div>
                        <Combobox lst={this.state.cbo} valuefield='CODE' textfield='{NAME}' id='SUBJECTCODE' callback={this.changeData} tooltip="Click hoặc space chọn" multiple={false} ref='SUBJECTCODE' />
                    </div>
                    
                </div>
                <TabHeader Tabs={tab} ref='TabHeader' defaulttab={defaulttab} basepath='/examtime/manage' />
                </div>
        );
    }
});

ReactDOM.render(<ExamTimeApp />, document.getElementById('container'));