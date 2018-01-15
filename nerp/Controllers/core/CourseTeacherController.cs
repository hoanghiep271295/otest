using IS.fitframework;
using IS.Sess;
using IS.uni;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Dynamic;
using System.Web.Mvc;
using IS.Config;
using IS.Lang;

namespace nerp.Controllers.core
{
    public class CourseTeacherController : Controller
    {
        private readonly session _ses = new session();

        // GET: CourseStudent
      /// <summary>
      /// 
      /// </summary>
      /// <param name="id">markcode</param>
      /// <param name="subid">coursecode</param>
      /// <returns></returns>
        public ActionResult Index(string id, string subid)
        {
            dynamic defaultobject = new ExpandoObject();
            defaultobject.markcode = id;
            defaultobject.coursecode = subid;
            defaultobject.thetype = _ses.loginType;
            ViewBag.defaultvalue = JsonConvert.SerializeObject(defaultobject);

            string[] jsx = {
                "/Scripts/reactselect/prop-types.js"
                ,"/Scripts/reactselect/react-input-autosize.js"
                ,"/Scripts/reactselect/classname.js"
                ,"/Scripts/reactselect/react-select.js"
                , "/Jsx/_Shared/ButtonList.jsx"
                ,"/Jsx/_Shared/PopupSearch.jsx"
                ,"/Jsx/_Shared/Combobox.jsx"
                ,"/Jsx/_Shared/DropDownTree.jsx"
                 ,"/Scripts/Dropdowntree/dropdowntree.js"
                ,"/Jsx/_Shared/Tree.jsx"
                ,"/Scripts/Ag-grid/ag-grid.js"
                ,"/Jsx/_Shared/AgGrid.jsx"
                ,"/Jsx/_Shared/TabHeader.jsx"
                  ,"/jsx/Core/CourseStudent/Coursestudied.jsx"
                ,"/jsx/Core/CourseStudent/PopupMark.jsx"
                 ,"/jsx/Core/CourseStudent/CoursestudentApp.jsx"
            };
            ViewBag.jsx = jsx;
            return View("Adminindex");//Lấy index mặc định trong share
        }

    }
}