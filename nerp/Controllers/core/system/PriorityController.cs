using IS.Config;
using IS.fitframework;
using IS.Sess;
using IS.uni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nerp.Controllers.core
{
    public class PriorityController : Controller
    {
        session ses = new session();
      
        public JsonResult getAllSearch()
        {
            List<PRIORITY_OBJ> li = null;

            //Khai báo lấy dữ liệu
            PRIORITY_BUS bus = new PRIORITY_BUS();
            List<fieldpara> lipa = new List<fieldpara>();


            //order by theorder, with pagesize and the page
            li = bus.getAllBy2(" groupcode, name", lipa.ToArray());
            bus.CloseConnection();
            //li = li.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Json(new
            {
                lst = li,//Danh sách
                ret = 0//ok
            }, JsonRequestBehavior.AllowGet);
        }


    }
}