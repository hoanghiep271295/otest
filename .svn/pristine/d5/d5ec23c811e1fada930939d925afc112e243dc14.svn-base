var DragItem = React.createClass({
    preventDefault: function(event) {
        event.preventDefault();
    },

    drop: function(ev) {
        ev.preventDefault();
        //var data = ev.dataTransfer.getData("text");
        //ev.target.appendChild(document.getElementById(data));
        //debugger
        //event.preventDefault();

        var data;

        //  try {
        debugger
            data = JSON.parse(ev.dataTransfer.getData('text'));
            ev.target.appendChild(document.getElementById(data.id));

        //} catch (e) {
        //    // If the text data isn't parsable we'll just ignore it.
        //    return;
        //}

        //// Do something with the data
        //log.show(data, true);
        //console.log(data);

    },
    dragStart: function(event) {
        var data = {
            id: event.target.id,
            content: event.target.textContent
        };
      //  if()
          event.dataTransfer.setData('text', JSON.stringify(data));
        //event.dataTransfer.setData("text", event.target.id);
        //console.log(event.target.textContent);
    },
    dragEnter: function (event) {
        debugger
        if (event.target.className === "droptarget") {
            event.target.style.border = "3px dotted red";
            event.target.style.background = "#3CE9FF";
        }
    },
    dragLeave: function (event) {
        debugger
        if (event.target.className === "droptarget") {
            event.target.style.border = "";
            event.target.style.background = "#F5EDB2";

        }
    },
    render : function() {

        return(

            <div>
            <div id="div1" className="droptarget"
                 onDrop={this.drop}
                 onDragOver={this.preventDefault}
                 onDragLeave={this.dragLeave}
                 onDragEnter={this.dragEnter}>
              <div draggable="true"
                   onDragStart={this.dragStart}
                   id="dragtarget"
                   width="fit-content" height="auto">
                  Drop me please
              </div>
            </div>

            <div id="div2" className="droptarget"
                 onDrop={this.drop}
                 onDragOver={this.preventDefault}
                 onDragLeave={this.dragLeave}
                 onDragEnter={this.dragEnter}></div>

            </div>
            );

}

});


ReactDOM.render(<DragItem />, document.getElementById('container'));