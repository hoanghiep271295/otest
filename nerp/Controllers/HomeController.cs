using System.Dynamic;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using IS.Sess;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;

namespace nerp.Controllers
{
    public class HomeController : Controller
    {
        session ses = new session();
        /// <summary>
        /// Hiển thị giao diện chính
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //Thiết lập các tham số truyền xuống theo mô hình một đối tượng
            dynamic defaultobject = new ExpandoObject();
            defaultobject.url = "123";
            defaultobject.subcode= "456";
            defaultobject.thedate = "2017-2-3";
            ViewBag.defaultvalue = JsonConvert.SerializeObject(defaultobject);

            string[] jsx = {
               "/Scripts/reactselect/prop-types.js"
               ,"/Scripts/reactselect/react-input-autosize.js"
               ,"/Scripts/reactselect/classname.js"
               ,"/Scripts/reactselect/react-select.js"
                ,"/jsx/_shared/Combobox.jsx"
                ,"/Scripts/Dropdowntree/dropdowntree.js"
                ,"/jsx/_shared/DropdownTree.jsx"
                ,"/jsx/Core/home/HomeIndex.jsx"
                };
            ViewBag.jsx = jsx;
            return View("Adminindex");
            //return View();
        }
        public ActionResult Warning()
        {
            dynamic defaultobject = new ExpandoObject();
            defaultobject.url = ses.targetpage;
            defaultobject.inform = ses.inform;
            defaultobject.title = ses.title;
            defaultobject.waitingtime = ses.waitingtime;
            ViewBag.defaultvalue = JsonConvert.SerializeObject(defaultobject);
            ;// defaultvalue;//defaultobject;
            string[] jsx = {
               "/Scripts/reactselect/prop-types.js"
                ,"/jsx/Core/home/homewarning.jsx"
                };
            ViewBag.jsx = jsx;
            return View("Adminindex");
            //return View();
        }
        public ActionResult Admin()
        {
            if(ses.isLogin()!=0)
            {
                Response.Redirect("/admin/login");
            }
            dynamic defaultobject = new ExpandoObject();
            defaultobject.thetype = ses.loginType;
            defaultobject.name = ses.loginFullName;
            ViewBag.defaultvalue = JsonConvert.SerializeObject(defaultobject);
            string[] jsx = {
                "/jsx/Core/home/HomeAdmin.jsx"
                };
            ViewBag.jsx = jsx;
            return View("Adminindex");
        }


        public JsonResult SurveyQuiz()
        {
            var poll = new
            {
                question = "Which is your favourite fruit?",
                choices = VotingHub.poll.Select(x => new { name = x.Key, count = x.Value }).ToList()
            };
            return Json(poll, JsonRequestBehavior.AllowGet);
        }
    public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            string defaultvalue = "{\"code\":\"123\", \"subcode\":\"345\", \"thedate\":\"2017-2-3\"}";
            ViewBag.defaultvalue = defaultvalue;
            string[] jsx = {
                "/jsx/Core/home/HomeIndex.jsx"
                };
            ViewBag.jsx = jsx;

            return View("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}