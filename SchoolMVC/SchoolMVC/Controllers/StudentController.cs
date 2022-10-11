using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLibrary;
using HelperLibrary;
using SchoolMVC.Models;

namespace SchoolMVC.Controllers
{
    public class StudentController : Controller
    {
        
        School_HL helper = null;
        public StudentController()
        {
            helper = new School_HL();
        }
       
        public ActionResult Index()
        {
            var emplist = helper.ShowEmployeeList();
            List<StudentModel> modelsList = new List<StudentModel>();
            foreach (var item in emplist)
            {
                modelsList.Add(new StudentModel { RegisterNumber = item.RegisterNumber, StudentName = item.StudenName, Age = item.Age});
            }

            return View(modelsList);
        }

  
        public ActionResult Details(int id)
        {

            var data = helper.SearchStudent(id);
            StudentModel stud= new StudentModel();
            stud.RegisterNumber = id;
            stud.StudentName = data.StudenName;
            stud.Age = data.Age;
            return View(stud);
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
                bal.RegisterNumber= Convert.ToInt32(Request["RegisterNumber"]);
                bal.StudenName = Request["StudentName"].ToString();
                bal.Age = Convert.ToInt32(Request["Age"]);
               
                

                bool ans = helper.AddStudent(bal);
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
            var Stud = helper.SearchStudent(id);
            StudentModel model = new StudentModel();
            model.RegisterNumber = id;
            model.StudentName = Stud.StudenName;
            model.Age= Stud.Age;
            return View(model);
        }

        
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
               
                var stud = helper.SearchStudent(id);
                stud.RegisterNumber = Convert.ToInt32(Request["RegisterNumber"]);
                stud.StudenName = Request["StudentName"].ToString();
                stud.Age = Convert.ToInt32(Request["Age"]);
                bool ans = helper.EditStudent(stud);


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
            var stud = helper.SearchStudent(id);
            StudentModel model = new StudentModel();
            model.RegisterNumber = id;
            model.StudentName = stud.StudenName;
            model.Age = stud.Age;
            

            return View(model);
        }

      
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                
                var dataFound = helper.SearchStudent(id);
                if (dataFound != null)
                {
                    bool ans = helper.RemoveStudent(id);
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