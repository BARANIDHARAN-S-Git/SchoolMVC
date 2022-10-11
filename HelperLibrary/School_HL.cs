using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLibrary;
using DataAccessLibrary;

namespace HelperLibrary
{
    public class School_HL
    {

        School_DAL dal = null;
        public School_HL()
        {
            dal = new School_DAL();
        }


        public bool AddStudent(School_BLL Student)
        {
            return dal.InsertStudent(Student);

        }


        public bool EditStudent(School_BLL Student)
        {
            return dal.UpdateStudent(Student);
        }
        public bool RemoveStudent(int Student_id)
        {
            return dal.DeleteStudent(Student_id);
        }
        public School_BLL SearchStudent(int student_id )
        {
            return dal.FindStudent(student_id);
        }

       



        public List<School_BLL> ShowEmployeeList()
        {
            return dal.StudentList();
        }



        




        public bool AddSubject(School_BLL Subject)
        {
            return dal.InsertSubject(Subject);

        }


        public bool EditSubject(School_BLL Subject)
        {
            return dal.UpdateSubject(Subject);
        }
        public bool RemoveSubject(int Subject_Id)
        {
            return dal.DeleteSubject(Subject_Id);
        }
        public School_BLL SearchSubject(int Subject_id)
        {
            return dal.FindSubject(Subject_id);
        }





        public List<School_BLL> ShowSubjectList()
        {
            return dal.SubjectList();
        }


        public bool AddClass(School_BLL Class)
        {
            return dal.InsertClass(Class);

        }


        public bool EditClass(School_BLL Class)
        {
            return dal.UpdateClass(Class);
        }
        public bool RemoveClass(int Class_RoomNo)
        {
            return dal.DeleteClass(Class_RoomNo);
        }
        public School_BLL SearchClass(int Class_RoomNo)
        {
            return dal.FindClass(Class_RoomNo);
        }





        public List<School_BLL> ShowClassList()
        {
            return dal.ClassList();
        }









    }
}

