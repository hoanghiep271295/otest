using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS.uni;
using IS.Sess;
using IS.fitframework;
namespace uni.Controllers
{
    public class academiclevelController : Controller
    {
        session ses = new session();
        //
        // GET: /academiclevel/
        public ActionResult index()
        {
            if(TempData["academiclevel_mess"]!=null)
            {
                ViewBag.errormess = TempData["academiclevel_mess"].ToString();
            }
            ACADEMICLEVEL_BUS bus = new ACADEMICLEVEL_BUS();
            List<ACADEMICLEVEL_OBJ> li = bus.getAllBy2("theorder");//get all object
            bus.CloseConnection();
            return View(li);
        }
        public ActionResult add()
        {
            ACADEMICLEVEL_OBJ obj = new ACADEMICLEVEL_OBJ();
            return View(obj);
        }
        public ActionResult edit(string id)
        {
            ACADEMICLEVEL_BUS bus = new ACADEMICLEVEL_BUS();
            ACADEMICLEVEL_OBJ obj = bus.GetByID(new ACADEMICLEVEL_OBJ.BusinessObjectID(id));
            bus.CloseConnection();
            return View("add",obj);
        }
        public ActionResult delete(string id)
        {
            TempData["academiclevel_mess"] = "";
            int ret = 0;
            ACADEMICLEVEL_BUS bus = new ACADEMICLEVEL_BUS();
            ACADEMICLEVEL_OBJ obj = bus.GetByID(new ACADEMICLEVEL_OBJ.BusinessObjectID(id));
            if(obj==null)
            {
                TempData["academiclevel_mess"] = "Không tồn tại bản ghi cần xóa";
            }
            else
            {
                ret = bus.delete(obj._ID);
                if (ret < 0)
                {
                    TempData["academiclevel_mess"] = "Xóa dữ liệu không thành công";
                }
                else
                {
                    TempData["academiclevel_mess"] = string.Format("Xóa dữ liệu '{0}' thành công", obj.NAME);
                }
            }
            bus.CloseConnection();
            return RedirectToAction("index", "academiclevel");
        }
        [HttpPost]
        public ActionResult save(ACADEMICLEVEL_OBJ obj)
        {
            bool add = (obj.CODE=="" || obj.CODE==null);
            int ret = 0;
            ACADEMICLEVEL_BUS bus = new ACADEMICLEVEL_BUS();
            if(add)
            {
                obj.CODE = bus.genNextCode(obj);
            }
            obj._ID.CODE = obj.CODE;
            obj.EDITTIME = DateTime.Now;
            obj.EDITUSER = ses.loginCode;
            obj.LOCKDATE = obj.EDITTIME;
//            obj.WHOIS = "";
            if(add)
            {
                ret = bus.insert(obj);
            }
            else
            {
                ret = bus.update(obj);
            }
            if(ret>=0)
            {
                return RedirectToAction("index", "academiclevel");
            }
            ViewBag.errormess = "Ghi không thành công";
            return View("add", obj);
        }
    }
}