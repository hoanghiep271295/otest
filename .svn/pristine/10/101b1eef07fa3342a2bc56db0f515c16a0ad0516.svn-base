/**
 * Hiển thị giao diện Tab
 * Tabs: Danh sách các tab cần hiển thị
 * Mỗi tab cần có các thông tin sau:
 * Com: tên component cần hiển thị chính trong tab - cái này chính là component phụ trách hiển thị danh sách (MenuComponent)
 * id: tên của tab - dạng id cần phải duy nhất trong một giao diện ('tab1_menu')
 * title: Tiêu đề ở trên tab ('Menu')
 * parentTitle: tiêu đề được đặt ở trên đầu cùng ('Quản lý menu')
 * suburl: đường dẫn mà khi chọn tab này sẽ thêm vào cuối cùng
 * basepath: là đường dẫn cơ bản không kể đến tab
 * path: danh sách các đường dẫn phía bên phải ([{ title: 'Cha của cái hiện tại', status: '', link: '/xyz/abc' },{ title: 'Cái hiện tại', status: 'active', link: '' }])
  ***********
  * Mỗi component cần có hàm registerButton trả về danh sách các nút lệnh tương tác(
  registerButton:function(){
        return [ { title: 'Thêm mới', callback: this.onNewClick, icon: ' fa fa-files-o', ref: 'cmdAdd1' }//Dạng nút lệnh mới không thuộc danh sách
                    , {ref: 'cmdEdit', callback: this.onEidtClick}//Dạng nút lệnh đã có trong danh sách nên để theo thứ tự này (cmdAdd, cmdEdit, cmdDelete, cmdRefresh, cmdSearch, cmdSearchSQL, cmdPrint, cmdFile)
        ];
    }
  )
  * Mỗi component cần có hàm onActive để thực hiện việc xử lý dữ liệu khi đối tượng này được chọn
  *
  *********** thông qua props.parent
  *Trong mỗi đối tượng sẽ có props.parent chính là truy xuất đến biến thể này để gọi các hàm nếu cần; props.title chính là tiêu đề đã được thiết lập cho tiêu đề cha của nó
  * setKeyValue/getKeyValue: cho phép gán một mã và một đối tượng lưu trữ, phần này được thiết kế để các tab có thể sử dụng biến này như là toàn cục dùng chung
  * getComponent: lấy về đối tượng trên tab khác để tương tác thông qua id đã gán cho tab - không nên dùng trừ trường hợp đặc biệt vì nó không thỏa mãn điều kiện đọc lập tương đối của các tab
  * setButton: Đặt lại danh sách các nút lệnh khi cần thiết - nếu là mặc định đã được quy định trong hàm registerButton
  * setParentTitle: cho phép đặc lại tiêu đề cha - nếu mặc định không cần đặt lại
  * setParentPath: đặt lại đường dẫn nếu cần - nếu mặc định đã được xác định từ đầu
  * ChooseTab: chọn một tab được hiển thị khi cần chuyển tab bằng chương trình
 * Hide(id): Ẩn một tab khi không cần thiết
 * UnHide(id): hiển thị lại một tab khi không cần thiết
 * setButtonStatus(id, status): Thiết lập lại trạng thái hiển thị của các buttton
  */
var TabHeader = React.createClass({
    getInitialState: function () {
        return {
            tab: []
            ,tabindex:0
            , keyvalue: []
            , buts:null
            , buttemp:null
        }
    },
    componentWillMount: function () {
        var that=this;
        var tab=[];
        this.props.Tabs.forEach(function (item, index) {
            tab.push({Com:item.Com,id:item.id, parentTitle:item.parentTitle,path:item.path, loaded:false, ins:null, buts:[], parent:that, suburl:item.suburl});
        });
       this.setState({ tab: tab});
    },
    componentDidMount: function () {
        //Thiết lập tab đầu tiên
        var def=this.props.defaulttab;
        if(isMiss(def))
        {
            def=this.state.tab[0].id;
            this.setState({defaulttab:def});
        }
        this.ChooseTab(def);
    },
    /**
    * Thiết lập một giá trị theo key - có thể là object
    */
    setKeyValue:function(key,value)
    {
        keyvalue=this.state.keyvalue;
        keyvalue[key]=value;
        this.state.keyvalue=keyvalue;
    },
    /**
    * Lấy một giá trị theo key, nếu chưa có thì trả về null - dành cho các trường hợp cần truyền tham số từ các tab
    */
    getKeyValue:function(key)
    {
        keyvalue=this.state.keyvalue;
        if (!isMiss(keyvalue[key])) return keyvalue[key];
        else return null;
    },
    shouldComponentUpdate: function (nextProps, nextState) {
        //Chỉ render lại khi có sự thay đổi thực sự
        return (nextProps.Tabs !== this.props.Tabs || nextProps.Buts!==this.props.Buts);
    },
    /**
    *Lấy một component anh em thông qua tên - Không nên sử dụng nếu không quá cần thiết; nếu chỉ sử dụng để truyền tham số nên truyền thông qua getKeyValue and setKeyValue
    */
    getComponent:function(id)
    {
        var index=0;
        var tab=this.state.tab;
        var obj=null;
       
        while(index<tab.length)
        {
            var temp=tab[index];
            if(temp.id===id)
            {
                obj=temp;
                break;
            }
            index++;
        }
        if(!isMiss(obj))
        {
            return obj.ins;
        }
        else
        {
            return null;
        }
    },

    /**
    *Thiết lập lại danh sách các nút lệnh - khi có thay đổi đặc biệt từ tab
    */
    setButton:function(list)
    {
        if (!isMiss( list )) {
            var buts = this.calButton(list);
           // console.log('Gen the but:', list);
            var ins = ReactDOM.render(<ButtonList list={buts } />, document.getElementById('button_group'));
            ins.resetButton();

            //Lưu lại con trỏ button
            this.setState({ buts: ins });
        }
        else
        {
            document.getElementById('button_group').innerHTML = '';//clear all
            this.setState({ buts: null });
        }
    },
    /**
    * Đặt lại tiêu đề lớn của chương trình
    */
    setParentTitle:function(title)
    {
        setTitle('sys_title', title);
    },
    /**
    * Đặt lại tiêu đề lớn của chương trình
    */
    setParentPath:function(path)
    {
        setTree('sys_path', path);
    },
    /**
    *Chuyển trạng thái buttton sang trạng thái mới
    */
    setButtonStatus:function(id, status)
    {
        var but = this.state.buts;
        if(!isMiss(but)) {
//            console.log('call buttons to process');
            but.setButtonStatus(id, status);
        }

    },
    calButton:function(client)
    {
        //    //Các nút lệnh chuẩn nếu không có gì thay đổi sẽ chọn từ các nút lệnh này
        var thelist = {};
        thelist['cmdFile'] = { title: 'Xuất file', callback: null, icon: 'fa fa-print', ref: 'cmdFile', tooltip: 'Xuất file' };
        thelist['cmdSearchSQL'] = { title: 'Lọc nâng cao', callback: null, icon: 'fa fa-database', ref: 'cmdSearchSQL', tooltip: 'Lọc nâng cao' };
        thelist['cmdRefresh'] = { title: 'Làm mới', callback: null, icon: 'fa fa-refresh', ref: 'cmdRefresh', tooltip: 'Lấy lại dữ liệu' };
        thelist['cmdPrint'] = { title: 'In', callback: null, icon: 'fa fa-print', ref: 'cmdPrint', tooltip: 'In ấn' };
        thelist['cmdAdd'] = { title: 'Thêm', callback: null, icon: ' fa fa-files-o', ref: 'cmdAdd', tooltip: 'Thêm mới bản ghi' };
        thelist['cmdEdit'] = { title: 'Sửa', callback: null, icon: 'fa fa-edit', ref: 'cmdEdit', tooltip: 'Sửa bản ghi' };
        thelist['cmdDelete'] = { title: 'Xóa', callback: null, icon: 'fa fa-trash', ref: 'cmdDelete', tooltip: 'Xóa bản ghi' };
        thelist['cmdSearch'] = { title: 'Lọc', callback: null, icon: 'fa fa-filter', ref: 'cmdSearch', tooltip: 'Lọc thông tin' };
        this.setState({buttemp:thelist});
        var buttemp = thelist;
        var buts=[];
        if (!isMiss(client))
        {
            //Thêm các nút lệnh mới vào
            client.forEach(function(obj, index)
            {
                var temp = null;
                if (!isMiss( buttemp )) {
                    temp = buttemp[obj.ref];
                }

                if (isMiss(temp)) {
                    //new one
                    temp={title: obj.title, callback: obj.callback, icon: obj.icon, ref: obj.ref,tooltip:obj.tooltip};
                    buts.push(temp);
                }
            });
            for (var key in buttemp) {
                var temp = buttemp[key];
                obj = null;
                for(var i in client)
                {
                    if (temp.ref === client[i].ref) {
                        obj = client[i];
                        break;
                    }
                }
                if(!isMiss( obj))
                {
                    temp.callback=obj.callback;
                    if(!isMiss( obj.tooltip))
                    {
                        temp.tooltip=obj.tooltip;
                    }
                    if(!isMiss( obj.icon))
                    {
                        temp.icon=obj.icon;
                    }
                    if(!isMiss( obj.title))
                    {
                        temp.title=obj.title;
                    }
                    buts.push(temp);
                }
            }

        }
        return buts;
    },
    Hide(id) {
        var index = 0;
        var tab = this.state.tab;
        var obj = null;

        while (index < tab.length) {
            var temp = tab[index];
            if (temp.id === id) {
                obj = temp;
                break;
            }
            index++;
        }
        if (obj !== null) {
            //Found id
            $('.nav-tabs a[href="#' + obj.id + '"]').hide();
        }

    },
    UnHide(id) {
        var index = 0;
        var tab = this.state.tab;
        var obj = null;

        while (index < tab.length) {
            var temp = tab[index];
            if (temp.id === id) {
                obj = temp;
                break;
            }
            index++;
        }
        if (obj !== null) {
            //Found id
            $('.nav-tabs a[href="#' + obj.id + '"]').show();
        }
    },
    /**
    * Xử lý khi một tab được chọn, gọi cho các tab thực hiện chuẩn bị nếu cần thiết 
    */
ChooseTab:function(id)
{
    var index=0;
    var tab=this.state.tab;
    var obj=null;
       
    while(index<tab.length)
    {
        var temp=tab[index];
        if(temp.id===id)
        {
            obj=temp;
            break;
        }
        index++;
    }
    if(obj!==null)
    {
        this.setState({tabindex:index});
        if(!obj.loaded)
        {
            var Com=obj.Com;
            var ins=ReactDOM.render(<Com parent={obj.parent} parentTitle={obj.parentTitle} id={obj.id}/>, document.getElementById(obj.id));
            obj.loaded=true;
            obj.ins = ins;
            if (!isMiss(ins.registerButton)) {
                obj.buts = this.calButton(ins.registerButton());
            }
            else
            {
                obj.buts = this.calButton(ins.state.buts);
            }
            tab[index] = obj;
            this.setState({ tab:tab});
//            this.state.tab[index]=obj;
        }
//        console.log('Set button to:', obj.ins, obj.buts, obj.buts[0].callback);
        this.setButton(obj.buts);
        this.setParentPath(obj.path);
        this.setParentTitle(obj.parentTitle);
        $('.nav-tabs a[href="#' + obj.id + '"]').tab('show');
        //Chỉ đổi khi url này khác '' và được định nghĩa
        if (checkMiss(obj.suburl, '') !== '') {
            var objurl = { Page: 'currentpage', Url: this.props.basepath + '/' + obj.suburl };
            history.pushState(objurl, objurl.Page, objurl.Url);
        }
        if(!isMiss(obj.ins.onActive))
        {
            obj.ins.onActive(this);
        }
    }
        //console.log('obj:',obj);
        //console.log('event:',event.target);
    },
    /**
    *Thực hiện lời gọi search
    */
    ShowSearch:function(id, list,obj, callbackfucntion)
    {
        var ins=ReactDOM.render(<PopupSearch list={list} callbackfunction={callbackfucntion} id={id} obj={obj}/>, document.getElementById('public_search_span'));
        ins.Show();
    },
    render: function() {
        var lheading=[];
        var lcontent=[];
        var tab=this.props.Tabs;
        var that=this;
        tab.forEach(function (item, index) {
            lheading.push(<li key={item.id} ><a href={'#'+item.id} data-toggle='tab' onClick={()=>that.ChooseTab(item.id)} >{item.title}</a></li>);
            lcontent.push(<div key={'content'+item.id} className="tab-pane" id={item.id} parent={that}></div>);
});
return (
        <div className="row">
            <div className="col-xs-12">
                <span id="public_search_span"></span>
            <div className="nav-tabs-custom" >
                <ul className="nav nav-tabs" >
                {lheading}
                </ul>
             <span style={{float:'right', margin:'-42px 5px 0px 0px'}} id="button_group"></span>
            <div className="tab-content">
                {lcontent}
            </div>
            </div>
            </div>
        </div>
        );
    }
});