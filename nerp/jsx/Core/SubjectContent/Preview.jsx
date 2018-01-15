var Preview = React.createClass({
    getInitialState: function() {
        return {
   
        }
    },
    componentWillMount: function () {
        this.loadData();
        
    },


    componentDidMount: function() {
        
        
    },
    loadData: function () {
        var defaultvalue = window.getDefaultFromServer();
        var code = defaultvalue.code;
        $.ajax({
            url: "/SubjectContent/GetByCode",
            dataType: 'json',
            data: {
                code: code
            },
            success: function (data) {
                if (data.ret >= 0) {
                    //  this.setState({ data: data.data });
                    var note = data.data.NOTE;
                    setTitle('sys_title', data.data.NAME);
                    document.getElementById('subjectcontent').innerHTML = note;
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.log(err.toString());
            }
        });
    },
    render: function () {
        var self = this;
        return (

           <div className="box">
            <div className="row">
                <div id='listsubject' className="content" style={{width: '100%' , height:'515px'}}>
                     <div id='subjectcontent' >

                     </div>
                </div>
            </div>

         </div>

        );
}

});

//----------------
ReactDOM.render(
    <Preview />,
    document.getElementById('container')
);