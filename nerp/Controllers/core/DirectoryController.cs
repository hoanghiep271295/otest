using System.Web.Mvc;
using IS.Sess;
using System.Dynamic;
using Newtonsoft.Json;

namespace nerp.Controllers.core
{
    public class DirectoryController : Controller
    {
        session ses = new session();
       /// <summary>
       /// Tất cả danh mục về về giáo viên
       /// </summary>
       /// <param name="id"></param>
       /// <param name="subid"></param>
       /// <returns></returns>
        public ActionResult Index(string id, string subid)
        {
            if(string.IsNullOrEmpty(id))
            {
                id = "armyrank";
            }
            //if (ses.isLogin() != 0)
            //{
            //    Response.Redirect("/admin/login");
            //}
            //if (ses.isLogin() != 0)
            //{
            //    //unlogined yet
            //    //                ses.gotoPage("/staff/login", "Thông báo", "Không có quyền thực hiện chức năng", 3000);
            //    return Redirect("/home/index");
            //}
            dynamic defaultobject = new ExpandoObject();
            defaultobject.defaulttab = id;
            defaultobject.thetype = ses.loginType;
            ViewBag.defaultvalue = JsonConvert.SerializeObject(defaultobject);

            string[] jsx = {
                "/Jsx/_Shared/ButtonList.jsx"
                ,"/Jsx/_Shared/PopupSearch.jsx"
                ,"/Scripts/Ag-grid/ag-grid.js"
                ,"/Jsx/_Shared/AgGrid.jsx"
                ,"/Jsx/_Shared/TabHeader.jsx"//Phụ trách hiển thị các tab
                ,"/jsx/core/armyrank/Armyrankpopup.jsx" //Hiển thị popup
                ,"/jsx/core/armyrank/Armyranklist.jsx"//Hiển thị danh sách
                ,"/jsx/core/leveltitle/leveltitlepopup.jsx" //Hiển thị popup
                ,"/jsx/core/leveltitle/leveltitlelist.jsx"//Hiển thị danh sách
                ,"/jsx/core/partyleveltitle/partyleveltitlepopup.jsx" //Hiển thị popup
                ,"/jsx/core/partyleveltitle/partyleveltitlelist.jsx"//Hiển thị danh sách
                ,"/jsx/Core/directory/DirectoryApp.jsx"//Tạo khai báo tab
                };
            ViewBag.jsx = jsx;
            return View("Adminindex");
        }
        /// <summary>
        /// Danh mục chung cho loại câu hỏi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subid"></param>
        /// <returns></returns>
        public ActionResult question(string id, string subid)
        {
            if (string.IsNullOrEmpty(id))
            {
                id = "questiontype";
            }
            dynamic defaultobject = new ExpandoObject();
            defaultobject.defaulttab = id;
            defaultobject.thetype = ses.loginType;
            ViewBag.defaultvalue = JsonConvert.SerializeObject(defaultobject);

            string[] jsx = {
                "/Jsx/_Shared/ButtonList.jsx"
                ,"/Jsx/_Shared/PopupSearch.jsx"
                ,"/Scripts/Ag-grid/ag-grid.js"
                ,"/Jsx/_Shared/AgGrid.jsx"
                ,"/Jsx/_Shared/TabHeader.jsx"//Phụ trách hiển thị các tab
                ,"/jsx/question/questionuse/questionusepopup.jsx" //Hiển thị popup
                ,"/jsx/question/questionuse/questionuselist.jsx"//Hiển thị danh sách
                ,"/jsx/question/questiontype/questiontypepopup.jsx" //Hiển thị popup
                ,"/jsx/question/questiontype/questiontypelist.jsx"//Hiển thị danh sách
                ,"/jsx/question/QuestionDirectoryApp.jsx"//Tạo khai báo tab
                };
            ViewBag.jsx = jsx;
            return View("Adminindex");
        }
        /// <summary>
        /// Danh mục chung cho subject
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subid"></param>
        /// <returns></returns>
        public ActionResult subject(string id, string subid)
        {
            if (string.IsNullOrEmpty(id))
            {
                id = "skill";
            }
            //if (ses.isLogin() != 0)
            //{
            //    Response.Redirect("/admin/login");
            //}
            //if (ses.isLogin() != 0)
            //{
            //    //unlogined yet
            //    //                ses.gotoPage("/staff/login", "Thông báo", "Không có quyền thực hiện chức năng", 3000);
            //    return Redirect("/home/index");
            //}
            dynamic defaultobject = new ExpandoObject();
            defaultobject.defaulttab = id;
            defaultobject.thetype = ses.loginType;
            ViewBag.defaultvalue = JsonConvert.SerializeObject(defaultobject);

            string[] jsx = {
                "/Jsx/_Shared/ButtonList.jsx"
                ,"/Jsx/_Shared/PopupSearch.jsx"
                ,"/Scripts/Ag-grid/ag-grid.js"
                ,"/Jsx/_Shared/AgGrid.jsx"
                ,"/Jsx/_Shared/TabHeader.jsx"//Phụ trách hiển thị các tab
                ,"/jsx/subject/skill/Skillpopup.jsx" //Hiển thị popup
                ,"/jsx/subject/skill/Skilllist.jsx"//Hiển thị danh sách
                ,"/jsx/subject/tag/Tagpopup.jsx" //Hiển thị popup
                ,"/jsx/subject/tag/Taglist.jsx"//Hiển thị danh sách
                ,"/jsx/subject/contenttype/contenttypepopup.jsx" //Hiển thị popup
                ,"/jsx/subject/contenttype/contenttypelist.jsx"//Hiển thị danh sách
                ,"/jsx/subject/SubjectDirectoryApp.jsx"//Tạo khai báo tab
                };
            ViewBag.jsx = jsx;
            return View("Adminindex");
        }
    }
}