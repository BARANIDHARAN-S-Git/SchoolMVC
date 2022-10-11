using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLibrary;

namespace DataAccessLibrary
{
    public class School_DAL
    {
        public bool InsertStudent(School_BLL Student)
        {

            int id = 0;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolCnString"].ConnectionString))
            {
               
                SqlCommand command = new SqlCommand("[dbo].[sp_InsertStudent]", cn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RegisterNumber", Student.RegisterNumber);
                command.Parameters.AddWithValue("@StudentName", Student.StudenName);
                command.Parameters.AddWithValue("@Age", Student.Age);
              
                cn.Open();
                id = command.ExecuteNonQuery();
                cn.Close();

            }
            if (id >0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        public int StudentCount()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolCnString"].ConnectionString);

            SqlCommand cmd = new SqlCommand("select count(*) from Student", cn);
            cn.Open();

            int cnt = (int)cmd.ExecuteScalar();
            cn.Close();
            cn.Dispose();
            return cnt;


        }

        public bool UpdateStudent(School_BLL Student)
        {

          
            SqlConnection cn = new SqlConnection("Data Source = LAPTOP-1GKJ0ROI\\SQLEXPRESS02; Initial Catalog = School; Integrated Security = True");
            SqlCommand command = new SqlCommand("[dbo].[sp_UpdateStudent]", cn);

            command.CommandType = System.Data.CommandType.StoredProcedure;
          
            command.Parameters.AddWithValue("@p_RegisterNumber", Student.RegisterNumber);
            command.Parameters.AddWithValue("@p_StudentName", Student.StudenName);
            command.Parameters.AddWithValue("@p_Age", Student.Age);
        

            cn.Open();
            int i = command.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();
            cn.Dispose();
            return status;

        }
        public bool DeleteStudent(int Student_RoolNo)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolCnString"].ConnectionString);

            SqlCommand cmdDelete = new SqlCommand("[dbo].sp_DeleteStudent", cn);
            cmdDelete.CommandType = System.Data.CommandType.StoredProcedure;
            cmdDelete.Parameters.AddWithValue("@p_RegisterNumber", Student_RoolNo);
            cn.Open();
            int i = cmdDelete.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();
            cn.Dispose();
            return status;

        }
        public School_BLL FindStudent(int Stuent_RollNo)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolCnString"].ConnectionString);
            SqlCommand cmdSelect = new SqlCommand("[dbo].sp_FindStudent", cn);
            cmdSelect.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSelect.Parameters.AddWithValue("@p_RegisterNumber", Stuent_RollNo);
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@p_StudentName";
            p1.SqlDbType = System.Data.SqlDbType.NVarChar;
            p1.Size = 30;
            p1.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p1);


           


            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@p_Age";
            p2.SqlDbType = System.Data.SqlDbType.Int;
            
            p2.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p2);


            cn.Open();
            cmdSelect.ExecuteNonQuery();

            School_BLL Studentfound = new School_BLL();

            Studentfound.StudenName = p1.Value.ToString();
            Studentfound.Age= Convert.ToInt32(p2.Value);
       
            




            cn.Close();
            cn.Dispose();


            return Studentfound;



        }



   
        public List<School_BLL> StudentList()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolCnString"].ConnectionString);

            SqlCommand cmdlist = new SqlCommand("select * from  [dbo].fn_Studentlist()", cn);
            cn.Open();
            SqlDataReader dr = cmdlist.ExecuteReader();
            List<School_BLL> emplist = new List<School_BLL>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    School_BLL bal = new School_BLL();
                    bal.RegisterNumber = Convert.ToInt32(dr["RegisterNumber"]);
                    bal.StudenName = dr["StudentName"].ToString();
                    bal.Age = Convert.ToInt32(dr["Age"]);
                   
                    
                    emplist.Add(bal);
                }
            }
            cn.Close();
            cn.Dispose();
            return emplist;

        }
      


        public bool InsertSubject(School_BLL Subject)
        {

            int id = 0;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolCnString"].ConnectionString))
            {
              
                SqlCommand command = new SqlCommand("[dbo].[sp_InsertSubject]", cn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SubjectId", Subject.SubjectId);
                command.Parameters.AddWithValue("@SubjectName", Subject.SubjectName);
               
                cn.Open();
                id = command.ExecuteNonQuery();
                cn.Close();

            }
            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        

        public bool UpdateSubject(School_BLL Subject)
        {


            SqlConnection cn = new SqlConnection("Data Source = LAPTOP-1GKJ0ROI\\SQLEXPRESS02; Initial Catalog = School; Integrated Security = True");
            SqlCommand command = new SqlCommand("[dbo].[sp_UpdateSubject]", cn);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@p_SubjectId", Subject.SubjectId);
            command.Parameters.AddWithValue("@p_SubjectName", Subject.SubjectName);
           

            cn.Open();
            int i = command.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();
            cn.Dispose();
            return status;

        }
        public bool DeleteSubject(int SubjectId)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolCnString"].ConnectionString);

            SqlCommand cmdDelete = new SqlCommand("[dbo].[sp_DeleteSubject]", cn);
            cmdDelete.CommandType = System.Data.CommandType.StoredProcedure;
            cmdDelete.Parameters.AddWithValue("@p_SubjectId", SubjectId);
            cn.Open();
            int i = cmdDelete.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();
            cn.Dispose();
            return status;

        }
        public School_BLL FindSubject(int SubjectId)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolCnString"].ConnectionString);
            SqlCommand cmdSelect = new SqlCommand("[dbo].[sp_FindSubject]", cn);
            cmdSelect.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSelect.Parameters.AddWithValue("@p_SubjectId", SubjectId);
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@p_SubjectName";
            p1.SqlDbType = System.Data.SqlDbType.NVarChar;
            p1.Size = 30;
            p1.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p1);







            cn.Open();
            cmdSelect.ExecuteNonQuery();

            School_BLL Subjectfound = new School_BLL();

            Subjectfound.StudenName = p1.Value.ToString();
         





            cn.Close();
            cn.Dispose();


            return Subjectfound;



        }




        public List<School_BLL> SubjectList()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolCnString"].ConnectionString);

            SqlCommand cmdlist = new SqlCommand("select * from  [dbo].[fn_Subjectlist]()", cn);
            cn.Open();
            SqlDataReader dr = cmdlist.ExecuteReader();
            List<School_BLL> emplist = new List<School_BLL>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    School_BLL bal = new School_BLL();
                    bal.SubjectId = Convert.ToInt32(dr["SubjectId"]);
                    bal.SubjectName = dr["SubjectName"].ToString();
                   

                    emplist.Add(bal);
                }
            }
            cn.Close();
            cn.Dispose();
            return emplist;

        }

   


        public bool InsertClass(School_BLL Class)
        {

            int id = 0;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolCnString"].ConnectionString))
            {

                SqlCommand command = new SqlCommand("[dbo].[sp_InsertClass]", cn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@classRoomNo", Class.ClassRoomNo);
                command.Parameters.AddWithValue("@NoOfStudentsInClass", Class.NoOfSTudentsInClass);

                cn.Open();
                id = command.ExecuteNonQuery();
                cn.Close();

            }
            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }


        public bool UpdateClass(School_BLL Class)
        {


            SqlConnection cn = new SqlConnection("Data Source = LAPTOP-1GKJ0ROI\\SQLEXPRESS02; Initial Catalog = School; Integrated Security = True");
            SqlCommand command = new SqlCommand("[dbo].[sp_UpdateClass]", cn);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@p_classRoomNo", Class.ClassRoomNo);
            command.Parameters.AddWithValue("@p_NoOfStudentsInClass", Class.NoOfSTudentsInClass);


            cn.Open();
            int i = command.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();
            cn.Dispose();
            return status;

        }
        public bool DeleteClass(int Class_RoomNo)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolCnString"].ConnectionString);

            SqlCommand cmdDelete = new SqlCommand("[dbo].[sp_DeleteClass]", cn);
            cmdDelete.CommandType = System.Data.CommandType.StoredProcedure;
            cmdDelete.Parameters.AddWithValue("@p_classRoomNo", Class_RoomNo);
            cn.Open();
            int i = cmdDelete.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();
            cn.Dispose();
            return status;

        }
        public School_BLL FindClass(int Class_RoomNo)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolCnString"].ConnectionString);
            SqlCommand cmdSelect = new SqlCommand("[dbo].[sp_FindClass]", cn);
            cmdSelect.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSelect.Parameters.AddWithValue("@p_classRoomNo ", Class_RoomNo);
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@p_NoOfStudentsInClass";
            p1.SqlDbType = System.Data.SqlDbType.Int;
            p1.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p1);







            cn.Open();
            cmdSelect.ExecuteNonQuery();

            School_BLL Classfound = new School_BLL();

            Classfound.NoOfSTudentsInClass= Convert.ToInt32(p1.Value);






            cn.Close();
            cn.Dispose();


            return Classfound;



        }




        public List<School_BLL> ClassList()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolCnString"].ConnectionString);

            SqlCommand cmdlist = new SqlCommand("select * from  [dbo].[fn_Classlist]()", cn);
            cn.Open();
            SqlDataReader dr = cmdlist.ExecuteReader();
            List<School_BLL> emplist = new List<School_BLL>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    School_BLL bal = new School_BLL();
                    bal.ClassRoomNo = Convert.ToInt32(dr["classRoomNo"]);
                    bal.NoOfSTudentsInClass = Convert.ToInt32(dr["NoOfStudentsInClass"]);


                    emplist.Add(bal);
                }
            }
            cn.Close();
            cn.Dispose();
            return emplist;

        }


    }

}