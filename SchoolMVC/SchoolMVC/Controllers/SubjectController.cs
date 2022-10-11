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
    public class SubjectController : Controller
    {

        School_HL helper = null;
        public SubjectController()
        {
            helper = new School_HL();
        }

        public ActionResult Index()
        {
            var emplist = helper.ShowSubjectList();
            List<SubjectModel> modelsList = new List<SubjectModel>();
            foreach (var item in emplist)
            {
                modelsList.Add(new SubjectModel { SubjectId = item.SubjectId, SubjectName = item.SubjectName});
            }

            return View(modelsList);
        }


        public ActionResult Details(int id)
        {

            var data = helper.SearchSubject(id);
            SubjectModel sub = new SubjectModel();
            sub.SubjectId = id;
            sub.SubjectName = data.SubjectName;
           
            return View(sub);
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
                bal.SubjectId = Convert.ToInt32(Request["SubjectId"]);
                bal.SubjectName = Request["SubjectName"].ToString();
               


                bool ans = helper.AddSubject(bal);
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
            var Sub = helper.SearchSubject(id);
            SubjectModel model = new SubjectModel();
            model.SubjectId = id;
            model.SubjectName = Sub.SubjectName;
           
            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {

                var sub = helper.SearchSubject(id);
                sub.SubjectId= Convert.ToInt32(Request["SubjectId"]);
                sub.SubjectName= Request["SubjectName"].ToString();
                
                bool ans = helper.EditSubject(sub);


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
            var sub = helper.SearchSubject(id);
            SubjectModel model = new SubjectModel();
            model.SubjectId = id;
            model.SubjectName = sub.SubjectName;
           

            return View(model);
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                var dataFound = helper.SearchSubject(id);
                if (dataFound != null)
                {
                    bool ans = helper.RemoveSubject(id);
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
