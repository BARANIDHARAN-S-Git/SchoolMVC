using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolMVC.Models
{
    public class ClassModel
    {
        [Required()]
        public int classRoomNo { get; set; }

        public int NoOfStudentsInClass { get; set; }
    }
}