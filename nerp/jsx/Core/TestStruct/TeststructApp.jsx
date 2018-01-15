﻿
var TestStructApp = React.createClass({
    getInitialState: function () {
        return {
            cbo: [],
            lstSubjectContent: []
        };
    },
    componentWillMount: function () {    
    },
    componentDidMount: function() {
        this.loadCombobox();
    },
    changeData: function (item) {
    //    console.log(item);
        var subjectcode = this.refs["SUBJECTCODE"].getValueString();
        if (!!item) {
            this.refs.TabHeader.setKeyValue("subjectcode", item.value);
            this.loadDropDownTree(item.value);
        }
        this.refs.TabHeader.ChooseTab("teststruct");
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
                console.error('unknow:url', status, err.toString());
            }.bind(this)
        });
    },
    loadDropDownTree: function(subjectcode) {
        //console.log('Load data for tree');hidTheType
        
        $.ajax({
            url: '/SubjectContent/getAll',
            dataType: 'json',
            data: { subjectcode: subjectcode },
            success: function (data) {
                if (data.ret >= 0) {
                    this.setState({
                        lstSubjectContent: data.lst
                    });
                    this.refs.TabHeader.setKeyValue("lstsubjectcontent", data.lst);
                 //   if (data.lst.length > 0)
                   //     this.refs['dropSubjectContent'].setValue(data.lst[0].CODE);
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.error('unknow:url', status, err.toString());
            }.bind(this)
        });
    },
    render: function () {
        var path = [{ title: 'Cấu trúc đề', status: 'active', link: '' }];;
        var tab=[];
        //Thêm một tab - id nên đăt theo đung luat de sau nay load duoc tu controller mac dinh
        tab.push({ Com: TestStructList, id: 'teststruct', suburl: 'teststruct', title: 'Cấu trúc đề', parentTitle: 'Danh sách cấu trúc đề', path: path });
        //Thêm một tab
        path=[{ title: 'Chi tiết cấu trúc đề', status: 'active', link: '' }];;
        tab.push({Com: TestStructDetailList
            , id: 'teststructdetail', suburl: 'teststructdetail', title: 'Chi tiết cấu trúc đề', parentTitle: 'Chi tiết cấu trúc đề', path: path });
       
        var obj = window.getDefaultFromServer();
        var defaulttab = "tesstruct";
        if(!isMiss(obj.defaulttab))
        {
            defaulttab=obj.defauhlttab;
        }
//        console.log('Default to:', defaulttab);
        return (
            <div>
                <div className="col-sm-3 subjectcodehead">
                    <Combobox lst={this.state.cbo}  valuefield='CODE' textfield='{NAME}' id='SUBJECTCODE' callback={this.changeData} tooltip="Click hoặc space chọn" multiple={false} ref='SUBJECTCODE' />
                </div>
                <TabHeader Tabs={tab} ref='TabHeader' defaulttab={defaulttab} basepath='/teststruct/index' />
                </div>
        );
    }
});

ReactDOM.render(<TestStructApp />, document.getElementById('container'));