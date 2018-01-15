using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using IS.Config;
using IS.fitframework;
using IS.localcomm;
using IS.Lang;
using IS.Sess;
using IS.uni;
using Newtonsoft.Json;
using System.Dynamic;
namespace nerp.Controllers.test
{
    public class TestStructContentController : Controller
    {
        session ses = new session();
        localcommonlib com = new localcommonlib();
        // GET: TestStructContent
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// kiểm tra 1 đối tượng 
        /// nếu là teststructcode hoặc là cha-> load teststructcontent
        /// nếu là lá thì load teststructdetail
        /// </summary>
        /// <param name="code">mã cần kiểm tra</param>
        
        /// <returns>
        /// ret = -1: LỖI;
        /// data.count > 0: có con
        /// </returns>
        public JsonResult CheckParent(string code, string teststructcode)
        {
            var ret = -1;
            List<TESTSTRUCTCONTENT_OBJ> liTestStructContent = new List<TESTSTRUCTCONTENT_OBJ>();
            List<TESTSTRUCTDETAIL_OBJ> liTestStructDetail = null;
            TESTSTRUCTCONTENT_BUS bus = new TESTSTRUCTCONTENT_BUS();
            var res = bus.getAllBy2("THEORDER", new fieldpara("PARENTCODE", code, 0));
            if (res != null && res.Count > 0)
                ret = 1;
            if ( ret >= 0)
            {     
                    liTestStructContent = res;               
            }
            else  // là nút lá-> get teststructdetail
            {
                  TESTSTRUCTDETAIL_BUS bus2 = new TESTSTRUCTDETAIL_BUS();
                  List<fieldpara> lipa = new List<fieldpara>();
                  lipa.Add( new fieldpara("TESTSTRUCTCODE", teststructcode, 0));
                  lipa.Add(new fieldpara("TESTSTRUCTCONTENTCODE", code, 0));
                  var res2 = bus2.getAllBy2("CODE", lipa.ToArray());
                if (res2 != null)
                {
                    ret = 2;
                    liTestStructDetail = res2;
                }
                bus2.CloseConnection();
            }
            bus.CloseConnection();
          
            return Json(new {ret = ret, liTestStructContent = liTestStructContent, liTestStructDetail  = liTestStructDetail }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(TESTSTRUCTCONTENT_OBJ obj)
        {
            TESTSTRUCTCONTENT_BUS bus = new TESTSTRUCTCONTENT_BUS();
            int ret = 0;
            int add = 0;
            TESTSTRUCTCONTENT_OBJ objTemp = null;
            //kiểm tra tồn tại cho trường hợp sửa
            if (!string.IsNullOrEmpty(obj.CODE))//edit
            {
                objTemp = bus.GetByID(new TESTSTRUCTCONTENT_OBJ.BusinessObjectID(obj.CODE));
            }
            else
            {
                objTemp = new TESTSTRUCTCONTENT_OBJ();
            }
            if (ret < 0)
            {
                //đóng kết nối trước khi trả về
                bus.CloseConnection();
                //ban ghi sửa đã bị xóa
                return Json(new { sussess = ret }, JsonRequestBehavior.AllowGet);
            }
            //hết kiểm tra tồn tại bản ghi
            objTemp.EDITTIME = DateTime.Now;//Thời điểm sủa bản ghi
            objTemp.EDITUSER = ses.loginCode;//Người sửa bản ghi
            objTemp.CODEVIEW = obj.CODEVIEW;
            objTemp.NAME = obj.NAME;
            objTemp.SUBJECTCODE = obj.SUBJECTCODE;
            objTemp.TESTSTRUCTCODE = obj.TESTSTRUCTCODE;
            objTemp.PARENTCODE = obj.PARENTCODE;
            objTemp.NOTE = obj.NOTE;
            objTemp.LOCK = obj.LOCK;
            objTemp.THEORDER = obj.THEORDER;
            objTemp.TOTALTIME = obj.TOTALTIME;
            objTemp.UNIVERSITYCODE = ses.gUNIVERSITYCODE;
            //Kiểm tra tình trạng sửa hay là thêm mới
            if (string.IsNullOrEmpty(obj.CODE))
            {
                //Thêm mới
                add = 1;
                //Sinh mã
                objTemp.CODE = bus.genNextCode(obj);
                objTemp.LOCKDATE = DateTime.Now;
            }
            if (add == 1)
            {
                ret = bus.insert(objTemp);
            }
            else
            {
                //gán _ID để xác định bản ghi sẽ được cập nhật
                objTemp._ID.CODE = obj.CODE;
                ret = bus.update(objTemp);
            }
            int pagecount = 0;
            int currentpage = 0;
            if (ret >= 0)
            {
                List<fieldpara> lipa = new List<fieldpara>();
                lipa.Add(new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE, 0));
                objTemp._ID.CODE = objTemp.CODE;
                ret = bus.checkPage(objTemp._ID, "CODE", AppConfig.item4page(), out pagecount, out currentpage, lipa);
            }
            bus.CloseConnection();
            //some thing like that
            return Json(new {obj=objTemp.CODE, ret = ret, pagecount = pagecount, currentpage = currentpage }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(List<string> code)
        {
            var ret = 0;
            var bus = new TESTSTRUCTCONTENT_BUS();
            List<TESTSTRUCTCONTENT_OBJ.BusinessObjectID> deletedata = new List<TESTSTRUCTCONTENT_OBJ.BusinessObjectID>();
            List<fieldpara> lipa = new List<fieldpara>();
            if (code == null)
                ret = -1;
            else
            {

                foreach (string t in code)
                {
                    if (t != null)
                    {
                        var item = bus.GetByID(new TESTSTRUCTCONTENT_OBJ.BusinessObjectID(t));
                        if (item != null)
                        {
                            lipa.Clear();
                            lipa.Add(new fieldpara("PARENTCODE", t, 0));
                            lipa.Add(new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE, 0));
                            ret =  bus.checkCode(null, lipa.ToArray());
                            if (ret == 0)
                                deletedata.Add(item._ID);
                            else
                            {
                                ret = -3;
                                return Json(new
                                {
                                    ret
                                }, JsonRequestBehavior.AllowGet);
                            }

                        }
                    }
                }

            }
            if (deletedata.Count > 0)
            {
                //mặc định khi vào danh sách này là xóa thành công nên ret= 1;
                //duyệt toàn bộ danh sách bản ghi để xóa
                bus.BeginTransaction();
                ret = bus.DeletetMultiItems(deletedata);
                if (ret < 0)
                {
                    //Trong trường hợp nhiều thao tác, có một thao tác không thành công,
                    //hàm này được gọi để quay lại trạng thái trước khi thực hiện (bắt đầu từ khi gọi BeginTransaction()
                    bus.RollbackTransaction();
                }
                else
                {
                    //Sau khi thao tác dữ liệu thành công, hàm này được gọi để thực hiện ghi vào cơ sở dữ liệu
                    bus.CommitTransaction();
                }
            }
            bus.CloseConnection();
            return Json(new
            {
                ret
            }, JsonRequestBehavior.AllowGet);
        }
    }
}