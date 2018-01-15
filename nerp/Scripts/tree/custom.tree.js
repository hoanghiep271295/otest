(function ($) {
    "use strict";
    $.fn.setTree = function (options, callback) {
        var dropdownList = this;
        // default parameters
        var settings = $.extend({
            data: null,
            onChoose: function () { },
            ajax: null,
            mapper: { id: "id", text: "text", parent: "parent", idext: "idext" },
            check: false,
            multiple: false
        }, options);
        // các giá trị để lưu chạy hàm callback
        dropdownList.value = "";
        dropdownList.name = "";

        var dataMapper = mappingData(settings.data, settings.mapper);
        if (dataMapper == null) {
            settings.data = [];
            dataMapper = [];
        }

        var optionsTree = {
            core: {
                data: dataMapper
            }
        };
        var name = "#" + dropdownList.attr("id")
        optionsTree["plugins"]=[]
        if (settings.check) {
            optionsTree["checkbox"] = {
                "keep_selected_style": false
            };
            optionsTree["plugins"] = ["checkbox", "search"]
        }
        if (settings.types) {
            optionsTree["plugins"].push("types")
            optionsTree["types"] = settings.types ||
                 {
                    "default": {
                        "icon": "glyphicon glyphicon-flash"
                    }
                }
            
        }
        dropdownList.jstree(optionsTree).on('loaded.jstree', function () {
            dropdownList.jstree('open_all');
        });
        if (settings.onChoose)
        {
            dropdownList.on("changed.jstree", function (e, data) {
                if (data.selected.length) {
                    var lst = [];
                    var count = data.selected.length;
                    for (var i = 0; i < count; i++)
                    {
                        lst.push(data.instance.get_node(data.selected[i]).original);
                    }
                    settings.onChoose(lst);
                    //alert('The selected node is: ' + data.instance.get_node(data.selected[0]).text);

                    //console.log(data.instance.get_node(data.selected[0]), data.instance.get_node(data.selected[0]).original);
                }
            });
        }

       
        function mappingData(data, config) {
            var dataMap = [];
            for (var i = 0; i < data.length; i++) {
                var obj = {};
                for (var key in config) {
                    if (config.hasOwnProperty(key)) {
                        var value = data[i][config[key]];
                        if (key == "parent" && (value == 0 || value == null || value == "null")) {
                            obj[key] = "#";
                        } else {
                            obj[key] = value;
                        }
                    }
                    if (settings.types) {
                        obj["type"] = data[i]["type"];
                    }
                }
                
                dataMap.push(obj);
            }
            return dataMap
        }

       
        function updateDataAndReload(data) {
            $ulDropdown.jstree("deselect_all");
            $ulDropdown.jstree(true).settings.core.data = data;
            $ulDropdown.jstree('open_all');
            $ulDropdown.jstree(true).refresh();
        }

        function getChecked() {
            var listChecked = $ulDropdown.jstree("get_selected", true);
            var listObject = [];
            for (var i = 0; i < listChecked.length; i++) {
                listObject.push(listChecked[i].original);
            }
            return listObject;
        }

        function remove_unicode(str) {
            str = str.toLowerCase();
            str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
            str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
            str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
            str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
            str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
            str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
            str = str.replace(/đ/g, "d");
            str = str.replace(/!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'| |\"|\&|\#|\[|\]|~|$|_/g, "-");

            str = str.replace(/-+-/g, "-"); //thay thế 2- thành 1- 
            str = str.replace(/^\-+|\-+$/g, "");

            return str;
        }

        //function getTemplate($that) {
        //    var name = $that.attr("id");
        //    if (name) {
        //        var nameInput = "inputDropdown" + name;
        //        var nameBtn = "btnDropdown" + name;
        //        var nameUl = "ulDropdown" + name;
        //        var templateDropdown = '<input type="text" class="form-control input-sm" id="' + nameInput + '" aria-label="..."><div class="input-group-btn"><button class="btn btn-primary btn-sm dropdown-toggle" type="button" data-toggle="dropdown" id="' + nameBtn + '"><span class="caret"></span></button><ul class="dropdown-menu" id="' + nameUl + '" style="right: 0; left: auto; width:400px;max-height:600px ;overflow:auto"></ul></div>';

        //        return {
        //            nameInputDropdown: "#"+nameInput,
        //            nameBtnDropdown: "#" + nameBtn,
        //            nameUlDropdown: "#" + nameUl,
        //            template: templateDropdown
        //        }
        //    }


       // }

        return dropdownList;
    };
}(jQuery));