var RadioInput = React.createClass( {
    handleClick: function() {
        this.props.onChoiceSelect( this.props.choice );
    },
    render: function() {
        var disable = this.props.disable;
        var classString = !disable ?  "radio" :  "radio disabled";
        return (
            <div className={classString}>
                <label className={this.props.classType}>
                    <input type="radio" name="optionsRadios" id={this.props.index} value={this.props.choice} onChange={this.handleClick}  />
                    {this.props.choice}
                </label>
            </div>
        );
    }
} );


var QuizContainer = React.createClass( {
    getInitialState: function() {
        return {           
            current_quiz: { question : '', choices:[] },
            user_choice: "",
			is_done: false           
        };
    },
	componentDidMount: function() {
    $.ajax({
      url: this.props.url,
      dataType: 'json',
      success: function(data) {
        this.setState( {           
            current_quiz: data,
            user_choice: "",
			is_done: false           
        });
      }.bind(this),
      error: function(xhr, status, err) {
        console.error('unknow:url', status, err.toString());
      }.bind(this)
    });
	    //set title
    setTitle('sys_title', 'Sơ đồ bảng biểu gì đó');
        //Set path
    var path = [{ title: 'Data tables', status: '', link: '#1' }
        , { title: 'Thêm tí', status: '', link: '#2' }
        , { title: 'Tables', status: 'active', link: '' }];
    setTree('sys_path', path);
   },
    selectedAnswer: function( option ) {
        this.setState( { user_choice: option } );
    },
    handleSubmit: function() {           			

				var selectedChoice = this.state.user_choice;
				 var vhub = $.connection.votingHub;
				  $.connection.hub.start().done(function () {				
                    // Call the Send method on the hub.
                    vhub.server.send(selectedChoice);
                    // Clear text box and reset focus for next comment.                   
				});
				this.setState({ is_done: true });
        },
    render: function() {
        var self = this;

		if (this.state.is_done === true){
			return (
				<div className="quizContainer">
					<h1>Thank you for your vote. </h1>
				</div>
			);
		}
		else 
		{
        var choices = this.state.current_quiz.choices.map( function( choice, index ) {           
            return (
                <RadioInput key={choice.name} choice={choice.name} index={index} onChoiceSelect={self.selectedAnswer} />
            );
        } );
        var button_name = "Submit";
        return(
    <div className="box">
        <div className="box-header">
            <h3 className="box-title">Data Table With Full Features</h3>
        </div>
        <div className="box-body">
            <table id="example1" className="table table-bordered table-striped">
                <thead>
                    <tr>
                        <th>Rendering engine</th>
                        <th>Browser</th>
                        <th>Platform(s)</th>
                        <th>Engine version</th>
                        <th>CSS grade</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Trident</td>
                        <td>
                            Internet
                            Explorer 4.0
                        </td>
                        <td>Win 95+</td>
                        <td> 4</td>
                        <td>X</td>
                    </tr>
                    <tr>
                        <td>Trident</td>
                        <td>
                            Internet
                            Explorer 5.0
                        </td>
                        <td>Win 95+</td>
                        <td>5</td>
                        <td>C</td>
                    </tr>
                   
                    <tr>
                        <td>Gecko</td>
                        <td>Seamonkey 1.1</td>
                        <td>Win 98+ / OSX.2+</td>
                        <td>1.8</td>
                        <td>A</td>
                    </tr>
                    <tr>
                        <td>Gecko</td>
                        <td>Epiphany 2.20</td>
                        <td>Gnome</td>
                        <td>1.8</td>
                        <td>A</td>
                    </tr>
                    <tr>
                        <td>Webkit</td>
                        <td>Safari 1.2</td>
                        <td>OSX.3</td>
                        <td>125.5</td>
                        <td>A</td>
                    </tr>
                    <tr>
                        <td>Webkit</td>
                        <td>Safari 1.3</td>
                        <td>OSX.3</td>
                        <td>312.8</td>
                        <td>A</td>
                    </tr>
                    <tr>
                        <td>Webkit</td>
                        <td>Safari 2.0</td>
                        <td>OSX.4+</td>
                        <td>419.3</td>
                        <td>A</td>
                    </tr>
                    <tr>
                        <td>Webkit</td>
                        <td>Safari 3.0</td>
                        <td>OSX.4+</td>
                        <td>522.1</td>
                        <td>A</td>
                    </tr>
                   
                    <tr>
                        <td>Tasman</td>
                        <td>Internet Explorer 5.1</td>
                        <td>Mac OS 7.6-9</td>
                        <td>1</td>
                        <td>C</td>
                    </tr>
                    
                    <tr>
                        <td>Other browsers</td>
                        <td>All others</td>
                        <td>-</td>
                        <td>-</td>
                        <td>U</td>
                    </tr>
                </tbody>
                <tfoot>
                    <tr>
                        <th>Rendering engine</th>
                        <th>Browser</th>
                        <th>Platform(s)</th>
                        <th>Engine version</th>
                        <th>CSS grade</th>
                    </tr>
                </tfoot>
            </table>
        </div>
        
    </div>

        );
		}
    }
} );

React.render(
    <QuizContainer url="/home/surveyquiz" />,
    document.getElementById('container')
);