//FI Question,first render questiongroup htmldrangerous
//render ul contain list answer
var QuestionTypeFI = React.createClass({
    componentDidMount: function () {
        document.getElementById(this.props.id + '_questiontypeFI').innerHTML =this.props.objQuestionGroup.CONTENT;
       // $('#' + this.props.id + '_questiontypeFI').scrollTop(300);
        //var timerId = 0;
        //function testPos(l, h) {
        //    timerId = window.setInterval(function () {
        //        var leftUl = l;
        //        var ulTop = leftUl.offset().top;
        //        var ulBottom = ulTop + leftUl.height();
        //        console.log(h.offset().top >= ulTop && h.offset().top <= ulTop + 20)
        //        if (h.offset().top >= ulTop && h.offset().top <= ulTop + 20) {
        //            leftUl.scrollTop(leftUl.scrollTop() - 1);
        //        }
        //        if (h.offset().top + h.height() <= ulBottom && h.offset().top + h.height() >= ulBottom - 20) {
        //            leftUl.scrollTop(leftUl.scrollTop() + 1);
        //        }
        //    }, 10);
        //}
        //$(function () {
        //    $(".sortable").sortable({
        //        connectWith: ".connected-sortable",
        //        cancel: ".not-sortable",
        //        activate: function (event, ui) {
        //            ui.item.prev().removeClass("highlight");
        //            ui.item.prev().children(".hint").show();
        //        },
        //        start: function (event, ui) {
        //            testPos($('ul.static.sortable.connected-sortable'), ui.helper);
        //        },
        //        stop: function (event, ui) {
        //            clearInterval(timerId)
        //            ui.item.prev().children(".hint").hide();
        //            var nextItemclass = ui.item.next().attr("class");
        //            var prevItemClass = ui.item.prev().attr("class");
        //            if ((nextItemclass === "sortableRow") && (ui.item.parent().hasClass('static'))) {
        //                $(".right").append(ui.item.next());
        //            }
        //            if ((prevItemClass === "sortableRow") && (ui.item.parent().hasClass('static'))) {
        //                $(".right").append(ui.item.prev());
        //            }
        //            if (prevItemClass === "not-sortable") {
        //                ui.item.prev().addClass("highlight");
        //            }
        //        },
        //        placeholder: "sortable-placeholder",
        //        helpler: 'clone'
        //    });
        //});
    },
    render() {
        var listanswer = [];
        var value = 1;
        this.props.dataAnswer.map( (rowitem)=> {
            if (rowitem.QUESTIONGROUPCODE === this.props.id) {
                listanswer.push(
                  <Drag key={value}
                        index={value}
                        id={rowitem.QUESTIONGROUPCODE+"_"+ rowitem.CODE}
                        content={rowitem.CONTENT}
                        type={this.props.type} />
                    );
                value++;
            }
    });
return (
        <div>
        <div className="container questiongroup dragFi">
        <b>{this.props.number}.</b>
        </div>
        <div className="fieldsetGroup lineHeight">
             <ul className="portfolio-grid">
                 {listanswer}
             </ul>
                <div className="container-fluid">
                   <span id={this.props.id + '_questiontypeFI'}></span>
                </div>
        </div>
        </div>
       );
}
});
