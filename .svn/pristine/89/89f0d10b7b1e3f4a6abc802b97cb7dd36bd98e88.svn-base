
/**
*Kiểm tra xem đối tượng là không có - chưa được khởi tạo hoặc khởi tạo là null
*
*/
function isMiss(obj)
{
    return (obj === null || typeof obj === 'undefined' || obj === 'undefined');
}
/**
 * Kiểm tra nếu lỗi thì trả về giá trị default
 * @param {} obj : giá trị cần kiểm tra
 * @param {} defa : giá trị trả về mặc định nếu là không xác đinh
 * @returns {} 
 */
function checkMiss(obj, defa) {
    if (obj === null || typeof obj === 'undefined' || obj === 'undefined') {
        return defa;
    } else {
        return obj;
    }
}

/**
 * Dựa trên đối tượng lưu là span 
 * id: mã của đối tượng (sys_title) cho tiêu đề
 * title: tiêu đề được set vào
 */
function setTitle(id, title) {
    var element = document.getElementById(id);
    if (element !== null && element !== 'undefined') {
        element.innerHTML = title;
        return 0;
    }
    return -1;
}
/**
 * Lưu vào đường dẫn trái
 * id: mã đối tượng lưu (sys_path)
 * path: là mảng các đường dẫn; Home là mặc đinh;  path = [{ title: 'Data tables', status: '', link: '#1' }
        , { title: 'Thêm tí', status: '', link: '#2' }
        , { title: 'Tables', status: 'active', link: '' }];
 */
function setTree(id, path)
{
    var x = document.getElementById("sys_path");
    if (x === null || x === 'undefined')
     {
        return -1;
    }
    while (x.childNodes.length > 0) {
        x.removeChild(x.childNodes[0]);
    }
    var len = path.length;
    var firstItem = document.createElement("li");
    firstItem.innerHTML = '<a href="/"><i class="fa fa-dashboard"></i> Home </a>';
    x.appendChild(firstItem);
    for (var i = 0; i < len; i++)
    {
        var obj = path[i];
        var newLI = document.createElement("li");
        if (obj.status == 'active') {
            newLI.classList.add('active');
            newLI.innerHTML = obj.title;
        }
        else
        {
            newLI.innerHTML = '<a href="'+obj.link+'">'+obj.title+'</a>';
        }
        x.appendChild(newLI);
    }
    return 0;
}

/**
 *Try to convert text day dd/MM/yyyy to javascript datetime format 'yyyy-MM-dd' 
 */

function convertDate(textDate) {
    var currentdate = new Date();
    var d = currentdate.getDate();
    var m = currentdate.getMonth() + 1;
    var y = currentdate.getFullYear();
    var da = textDate.split("/");
    if (da.length == 3) {
        y = parseInt(da[2]);
        m = parseInt(da[1]);
        d = parseInt(da[0]);
    }
    var returndate = y + '-' + m + '-' + d;
    return returndate;
}
/**
 * Chuyển kiểu dữ liệu ajax về dang hiển thị tiếng anh
 */

function convertDateFormatEn(jsondate) {
    var reISO = /^(\d{4})-(\d{2})-(\d{2})T(\d{2}):(\d{2}):(\d{2}(?:\.\d*))(?:Z|(\+|-)([\d|:]*))?$/;
    var reMsAjax = /^\/Date\((d|-|.*)\)[\/|\\]$/;
    if (typeof jsondate === 'string') {
        var a = reISO.exec(jsondate);
        if (a) {
            var c = new Date(parseInt(jsondate));
            return c.toDateString();
        }
        a = reMsAjax.exec(jsondate);
        if (a) {
            var c = new Date(parseInt(a[1].toString()));
            return c.toDateString();
        }
        return jsondate;
    }
    return '';
}
///--- Chuyển kiểu dữ liệu ajax về dụng dữ liệu tiếng việt
function converDateFormat(jsondate) {
    var reISO = /^(\d{4})-(\d{2})-(\d{2})T(\d{2}):(\d{2}):(\d{2}(?:\.\d*))(?:Z|(\+|-)([\d|:]*))?$/;
    var reMsAjax = /^\/Date\((d|-|.*)\)[\/|\\]$/;
    if (typeof jsondate === 'string') {
        var a = reISO.exec(jsondate);
        if (a) {
            var c = new Date(parseInt(jsondate));
            var y = c.getFullYear();
            var m = c.getMonth() + 1;
            var d = c.getDate();
            if (y < 1755) {
                return "";
            }
            return d + "/" + m + "/" + y;
        }
        a = reMsAjax.exec(jsondate);
        if (a) {
            //            var b = a[1].split(/[-+,.]/);
            console.log(a[1].toString());
            var c = new Date(parseInt(a[1]));
            console.log(c);
            var y = c.getFullYear();
            var m = c.getMonth() + 1;
            var d = c.getDate();
            if (y < 1755) {
                return "";
            }
            return d + "/" + m + "/" + y;
        }
    }
    return jsondate;
}
/** 
Chuyen kieu du lieu tu json sang dang YYYY-MM-DD (co ca so 0) de dua vao input type = date
*/
function converDateFormatYMD(jsondate) {
    var reISO = /^(\d{4})-(\d{2})-(\d{2})T(\d{2}):(\d{2}):(\d{2}(?:\.\d*))(?:Z|(\+|-)([\d|:]*))?$/;
    var reMsAjax = /^\/Date\((d|-|.*)\)[\/|\\]$/;
    if (typeof jsondate === 'string') {
        var a = reISO.exec(jsondate);
        if (a) {
            var c = new Date(parseInt(jsondate));
            var y = c.getFullYear();
            var m = c.getMonth() + 1;
            var d = c.getDate();
            if (y < 1755) {
                return "";
            }
            return y + "-" + (m <= 9 ? '0' + m : m) + "-" + (d < 10 ? "0" + d : d);
        }
        a = reMsAjax.exec(jsondate);
        if (a) {
            //            var b = a[1].split(/[-+,.]/);
            console.log(a[1].toString());
            var c = new Date(parseInt(a[1]));
            console.log(c);
            var y = c.getFullYear();
            var m = c.getMonth() + 1;
            var d = c.getDate();
            if (y < 1755) {
                return "";
            }
            return y + "-" + (m <= 9 ? '0' + m : m) + "-" + (d < 10 ? "0" + d : d);

        }
    }
    return jsondate;
}
/**
 * Kiểm tra là ngày tháng thì trả về dạng ngày tháng đúng ngược lại trả về ''
 */
function checkDate(val) {
    var currentdate = new Date();
    var d = 1;
    var m1 = currentdate.getMonth() + 1;
    var y1 = currentdate.getFullYear();
    var m = m1;
    var y = y1;
    var t = 0;
    var da = val.split("/");
    if (val.length < 1 || val.length > 10) {
        return '';
    }
    switch (da.length) {
        case 0:
        case 1:
            //only number
            if (val.length == 2) {
                m = parseInt(val);
            }
            if (val.length == 4) {
                d = parseInt(val.substr(0, 2));
                m = parseInt(val.substr(2, 2));
            }
            if (val.length == 6) {
                d = parseInt(val.substr(0, 2));
                m = parseInt(val.substr(2, 2));
                y = parseInt(val.substr(4, 2));
                y += 2000;
            }
            if (val.leng == 8) {
                d = parseInt(val.substr(0, 2));
                m = parseInt(val.substr(2, 2));
                y = parseInt(val.substr(4, 4));
            }
            break;
        case 2:
            y = parseInt(da[1]);
            m = parseInt(da[0]);
            if (y < 13 && m < 31) {
                //in case try the month
                d = m;
                m = y;
                y = y1;
            }

            break;
        case 3:
            y = parseInt(da[2]);
            m = parseInt(da[1]);
            d = parseInt(da[0]);
            if (y < 100) {
                y += 2000;
            }
            break;
    }
    if (y * m * d == 0) {
        return '';
    }
    if (isNaN(y) || isNaN(m) || isNaN(d)) {
        return '';
    }
    var returndate = d + '/' + m + '/' + y;
    return returndate;
}
/**
 * convert decimal to string 
 */
function decimal2String(val) {
    if (val == null || val == 'undefined') {
        return "";
    }
    var s = val.toString();
    return s;
}
/**
 * Convert int to string
 */
function int2String(val) {
    if (val == null || val == 'undefined') {
        return "";
    }
    var s = val.toString();
    return s;
}
/**
 * null is empty
 */
function null2String(val) {
    if (val == null || val == 'undefined') {
        return '';
    }
    return val;
}
/**
 * Convert string of number contain , to ordinary format
 */
function string2number(val) {
    if (val == null || val == 'undefined') {
        return '';
    }
    return val.replace(/,/g, '');
}
/**
 * Gọi một hàm ajax
 * @param {} url : đường dẫn để gọi
 * @param {} data : dữ liệu truyền lên
 * @param {} onsucccessfull : hàm callback khi gọi thành công
 * @param {} onerror : hàm được gọi khi bị lỗi
 * @param {} method : phương thức gọi - mặc định là GET
 * @returns {} 
 */
function callAjax(url, data, onsucccessfull, onerror, method)
{
    if (isMiss(method))
    {
        method = 'GET';
    }
    $.ajax({
        url: url,
        dataType: 'json',
        data:data,
        success: onsucccessfull,
        error: onerror
    });
}
/**
 * Thiết lập giá trị khi được lựa chọn mới
 * @param {} key : Mã của giá trị cần thiết lập
 * @param {} value :Giá trị cần thiết lập
 * @returns {} 
 */
function setSession(key, value) {
    var data = {
        key: key,
        value:value
    };
    $.ajax({
        url: '/parameter/Set',
        dataType: 'json',
        data: data,
        success: function() {console.log('Ghi dữ liệu ok', data)},
    });
}
/**
 * Lấy giá trị của session
 * @param {} key : giá trị cần lấy
 * @param {} callback : khi lấy thành công sẽ gọi hàm này
 * @returns {} 
 */
function  getSession(key,callback) {
    var data = {
        key: key
    };
    $.ajax({
        url: '/parameter/Get',
        dataType: 'json',
        data: data,
        success: callback
    });

}