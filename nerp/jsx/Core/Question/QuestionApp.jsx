var QuestionApp = React.createClass({
    getInitialState: function() {
        return {
            //Danh sách trên cây
              lst: [1,2,3],
              currentcode: '',
              keyvalue: []
             ,cbo:[1,1,1,1]
            //Danh sách các nút lệnh thực hiện chức năng
            
        }
    },

    componentWillMount:function() {

    },
    componentDidMount: function () {
    
    },
    /**
  * Thiết lập một giá trị theo key - có thể là object
  */
    setKeyValue: function (key, value) {
        var keyvalue = this.state.keyvalue;
        keyvalue[key] = value;
        this.state.keyvalue = keyvalue;
    },
  /**
  * Lấy một giá trị theo key, nếu chưa có thì trả về null - dành cho các trường hợp cần truyền tham số từ các tab
  */
    getKeyValue: function (key) {
        var keyvalue = this.state.keyvalue;
        if (!isMiss(keyvalue[key])) return keyvalue[key];
        else return null;
    },
    /**
     * 
     * @param {} obj 
     * @param {} ev 
     * @returns {} 
     */
    loadTree: function (obj, ev) {
        //console.log('Load data for tree');hidTheType
        var subjectCode = '';
        if (!!obj)
            subjectCode = obj.value;
        $.ajax({
            url: '/SubjectContent/getAll',
            dataType: 'json',
            data: { subjectcode: subjectCode },
            success: function (data) {
                this.setState({
                    lst: data.lst
                });
                this.loadData(this.refs["SUBJECTCODE"].getValueString(), '');
            }.bind(this),
            error: function (xhr, status, err) {
                console.error(this.props.url, status, err.toString());
            }.bind(this)
        });
    },
    render:function() {
        return (
            <div>
                <SubjectContentList/>
            </div>);
    }
    
});


ReactDOM.render(
    <QuestionApp />,
    document.getElementById('container')
);