﻿using System.Dynamic;
using System.Web.Mvc;
using IS.Sess;
using Newtonsoft.Json;

namespace nerp.Controllers.core
{
    public class DropDownTreeController : Controller
    {
        // GET: DropDownTree
        readonly session _ses = new session();
        public ActionResult Index(string id)
        {
            dynamic defaultobject = new ExpandoObject();
            defaultobject.defaulttab = id;
            defaultobject.thetype = _ses.loginType;
            ViewBag.defaultvalue = JsonConvert.SerializeObject(defaultobject);
            string[] jsx =
            {
             "/Scripts/reactselect/prop-types.js"
               ,"/Scripts/reactselect/react-input-autosize.js"
               ,"/Scripts/reactselect/classname.js"
               ,"/Scripts/reactselect/react-select.js"
                ,"/jsx/_shared/Combobox.jsx"
                ,"/Scripts/Dropdowntree/dropdowntree.js"
                ,"/jsx/_shared/DropdownTree.jsx"
                ,"/jsx/Core/home/homeindexTest.jsx"
            };
            ViewBag.jsx = jsx;
            return View("Adminindex");
        }

        public ActionResult Index2(string id)
        {
            dynamic defaultobject = new ExpandoObject();
            defaultobject.defaulttab = id;
            defaultobject.thetype = _ses.loginType;
            ViewBag.defaultvalue = JsonConvert.SerializeObject(defaultobject);
            string[] jsx =
            {
              "/jsx/exam/studentexam/DragandDrop2.jsx"
            };
            ViewBag.jsx = jsx;
            return View("StudentIndex");
        }

        public ActionResult Index3()
        {
            dynamic defaultobject = new ExpandoObject();
            defaultobject.thetype = _ses.loginType;
            ViewBag.defaultvalue = JsonConvert.SerializeObject(defaultobject);
            string[] jsx =
            {
              "/jsx/exam/studentexam/DragandDrop3.jsx"
            };
            ViewBag.jsx = jsx;
            return View("StudentIndex");
        }


    }
}