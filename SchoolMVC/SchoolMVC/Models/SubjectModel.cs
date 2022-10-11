using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolMVC.Models
{
    public class SubjectModel
    {

        [Required()]
        public int SubjectId { get; set; }
        
        [MaxLength(20, ErrorMessage = "Cannot be greater than 20 characters")]
        [MinLength(3, ErrorMessage = "cannot be lesser than 3 characters")]
        public string SubjectName { get; set; }    
    }
}