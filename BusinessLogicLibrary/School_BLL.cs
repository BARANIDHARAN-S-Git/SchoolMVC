using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLibrary
{
    public class School_BLL
    {
        
            private int _RegisterNumber;

            public int RegisterNumber
            {
                get { return _RegisterNumber; }
                set {_RegisterNumber = value; }
            }

            


            private string _StudentName;

            public string StudenName
            {

                get { return _StudentName; }
                set
                {
                   
                    
                        _StudentName = value;
                    

                }
            }

            private int _Age;

            public int Age
            {
                
                get { return _Age; }
                set { _Age = value; }
            }


       

        private int _SubjectId;
        public int SubjectId
        {
            get { return _SubjectId; }
            set { _SubjectId = value; }
        }

        private String _SubjectName;

        public string SubjectName
        {
            get
            {
                return _SubjectName;
            }
            set
            {
                _SubjectName = value;
            }
        }

       
        private int _classRoomNo;
        public int ClassRoomNo
        {
            get { return _classRoomNo; }
            set { _classRoomNo = value; }
        }

        private int _NoOfSTudentsInClass;
        public int NoOfSTudentsInClass
        {
            get { return _NoOfSTudentsInClass; }
            set { _NoOfSTudentsInClass = value; }
        }

       
    }
    
}
