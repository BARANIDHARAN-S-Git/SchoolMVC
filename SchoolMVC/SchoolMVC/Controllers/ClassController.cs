using BusinessLogicLibrary;
using HelperLibrary;
using SchoolMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolMVC.Controllers
{
    public class ClassController : Controller
    {
        School_HL helper = null;
        public ClassController()
        {
            helper = new School_HL();
        }

        public ActionResult Index()
        {
            var emplist = helper.ShowClassList();
            List<ClassModel> modelsList = new List<ClassModel>();
            foreach (var item in emplist)
            {
                modelsList.Add(new ClassModel{ classRoomNo = item.ClassRoomNo, NoOfStudentsInClass = item.NoOfSTudentsInClass });
            }

            return View(modelsList);
        }


        public ActionResult Details(int id)
        {

            var data = helper.SearchClass(id);
            ClassModel cls = new ClassModel();
            cls.classRoomNo = id;
            cls.NoOfStudentsInClass = data.NoOfSTudentsInClass;

            return View(cls);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {


                School_BLL bal = new School_BLL();
                bal.ClassRoomNo = Convert.ToInt32(Request["classRoomNo"]);
                bal.NoOfSTudentsInClass = Convert.ToInt32(Request["NoOfStudentsInClass"]);



                bool ans = helper.AddClass(bal);
                if (ans)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.exMsg = ex.Message;
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            var cls = helper.SearchClass(id);
            ClassModel model = new ClassModel();
            model.classRoomNo = id;
            model.NoOfStudentsInClass =cls.NoOfSTudentsInClass;

            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {

                var cls = helper.SearchClass(id);
                cls.ClassRoomNo = Convert.ToInt32(Request["classRoomNo"]);
                cls.NoOfSTudentsInClass = Convert.ToInt32(Request["NoOfStudentsInClass"]);

                bool ans = helper.EditClass(cls);


                if (ans)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            var cls = helper.SearchClass(id);
            ClassModel model = new ClassModel();
            model.classRoomNo= id;
            model.NoOfStudentsInClass = cls.NoOfSTudentsInClass;


            return View(model);
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                var dataFound = helper.SearchClass(id);
                if (dataFound != null)
                {
                    bool ans = helper.RemoveClass(id);
                    if (ans)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}