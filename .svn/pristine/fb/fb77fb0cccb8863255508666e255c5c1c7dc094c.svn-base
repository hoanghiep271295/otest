(function ($) {
    "use strict";

    $.fn.dropdownTree = function (options, callback) {

        var dropdownList = this;
        var isRunFirst = false;
        // default parameters
        var settings = $.extend({
            data: null,
            onChoose: function () { },
            ajax: null,
            mapper: { id: "id", text: "text", parent: "parent", idext: "idext" },
            check: false
        }, options);

        // các giá trị để lưu chạy hàm callback
        dropdownList.value = "";
        dropdownList.name = "";

        var dataMapper = mappingData(settings.data, settings.mapper);

        this.addClass("input-group");
        if (dataMapper == null) {
            settings.data = [];
            dataMapper = [];
        }

        var dropdownTemp = getTemplate(dropdownList);
        this.append(dropdownTemp.template);

        var $inputDropdown = dropdownList.find(dropdownTemp.nameInputDropdown);
        var $buttonDropdown = dropdownList.find(dropdownTemp.nameBtnDropdown);
        var $ulDropdown = dropdownList.find(dropdownTemp.nameUlDropdown);

        var optionsTree = {
            core: {
                data: dataMapper
            }
        };

        var name = "#" + dropdownList.attr("id")
        optionsTree["plugins"] = []
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

        $ulDropdown.jstree(optionsTree).on('loaded.jstree', function () {
            $ulDropdown.jstree('open_all');
        });

        $ulDropdown.on("select_node.jstree", function (e, data) {
            handlingEvent(data);
            if (!settings.check) {
                $buttonDropdown.parent().removeClass("open");
                updateDataAndReload(dataMapper);
            }
        });
        if (settings.check) {
            $ulDropdown.on("deselect_node.jstree", function (evt, data) {
                handlingEvent(data);
            });
        }

        $buttonDropdown.on("click", function (e) {
            e.preventDefault();
            toggleDropdown();
        });

        $inputDropdown.on("focus", function (e) {
            e.preventDefault();
            toggleDropdown();
        });

        $inputDropdown.on("blur", function (e) {
            e.preventDefault();
            toggleDropdown();
        });

        $(document).click(function (event) {
            if ($buttonDropdown.parent().hasClass("open")) {
                if (!$(event.target).closest(name).length && !$(event.target).is(name)) {
                    if ($buttonDropdown.parent().hasClass("open")) {
                        $buttonDropdown.parent().removeClass("open")
                    }
                }
            }
        });

        var to = false;
        $inputDropdown.on("keyup", function (e) {
            if (!$buttonDropdown.parent().hasClass("open")) {
                $buttonDropdown.parent().addClass("open");
            }
            var key = e.keyCode
            var inputCurrentData = $(this).val();
            if (!settings.check) {
                if (settings.ajax == null) {

                    if (inputCurrentData == "") {
                        updateDataAndReload(dataMapper)
                    } else {
                        var result = $.grep(dataMapper, function (e) { return remove_unicode(e.text).indexOf(remove_unicode(inputCurrentData)) > -1 });
                        if (result.length == 0) {
                            var dataError = { id: "1", text: "Không có giá trị nào tìm thấy", parent: "#", idext: "1", icon: "glyphicon glyphicon-remove-circle" };
                            updateDataAndReload(dataError);
                            //$ulDropdown.text("không có giá trị nào")
                        } else {
                            var listObj = [];
                            for (var i = 0; i < result.length; i++) {
                                var getParents = $.grep(dataMapper, function (e) { return result[i].idext.indexOf(e.idext) > -1 });
                                listObj.push.apply(listObj, getParents);
                            }

                            listObj = $.unique(listObj);
                            updateDataAndReload(listObj)
                        }
                    }
                } else {
                    var dataSend = {};
                    if (settings.ajax.keyData) {
                        dataSend[settings.ajax.keyData] = inputCurrentData;
                    } else {
                        dataSend = null;
                    }

                    getDataAjax(dataSend, function (result) {
                        var renderData = mappingData(result, settings.mapper);
                        updateDataAndReload(renderData)
                    })
                }
                return;
            } else {
                if (to) { clearTimeout(to); }
                to = setTimeout(function () {
                    var v = $inputDropdown.val();
                    $ulDropdown.jstree(true).search(v);
                }, 250);
            }
        });

        function toggleDropdown() {
            if (!$buttonDropdown.parent().hasClass("open")) {
                $buttonDropdown.parent().addClass("open");
            } else {
                $buttonDropdown.parent().removeClass("open");
            }
        };

        function getDataAjax(dataRequest, callback) {
            $.ajax({
                type: settings.ajax.type || 'GET',
                dataType: 'json',
                contentType: settings.ajax.contentType || 'application/json; charset=utf-8',
                headers: settings.ajax.headers || { 'Content-Type': 'application/x-www-form-urlencoded' },
                data: dataRequest || null,
                url: settings.ajax.url,
                success: callback,
                error: function (xhr, ajaxOptions, thrownError) {
//                    alert('Error: ' + xhr.status || ' - ' || thrownError);
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

        function handlingEvent(data) {
            $inputDropdown.val(data.node.text);
            dropdownList.value = data.node.original;
            dropdownList.name = data.node.text;
            if (settings.check) {

                $inputDropdown.val("");
                dropdownList.value = getChecked();
                var countChecked = dropdownList.value.length;
                if (countChecked > 3) {
                    $inputDropdown.val("Có " + countChecked + " giá trị được chọn!")
                } else {
                    for (var i = 0; i < dropdownList.value.length; i++) {
                        $inputDropdown.val($inputDropdown.val() + dropdownList.value[i].text + ",")
                    }
                }
                //$inputDropdown.val();
            }

            settings.onChoose();
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

        function getTemplate($that) {
            var name = $that.attr("id");
            if (name) {
                var nameInput = "inputDropdown" + name;
                var nameBtn = "btnDropdown" + name;
                var nameUl = "ulDropdown" + name;
                var templateDropdown = '<input type="text" class="form-control input-sm" id="' + nameInput + '" aria-label="..."><div class="input-group-btn"><button class="btn btn-primary btn-sm dropdown-toggle" type="button" data-toggle="dropdown" id="' + nameBtn + '"><span class="caret"></span></button><ul class="dropdown-menu" id="' + nameUl + '" style="right: 0; left: auto; width:400px;max-height:600px ;overflow:auto"></ul></div>';

                return {
                    nameInputDropdown: "#" + nameInput,
                    nameBtnDropdown: "#" + nameBtn,
                    nameUlDropdown: "#" + nameUl,
                    template: templateDropdown
                }
            }


        }

        return dropdownList;
    };
}(jQuery));