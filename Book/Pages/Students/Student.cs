using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Pages.Students
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string College { get; set; }
        public Department Department { get; set; }
        public string Photo { get; set; }

        [Range(1, 5, ErrorMessage = "Please enter a value between 1 and 5")]
        public int Grade { get; set; }

        [Required,RegularExpression("^[A-E]*$", ErrorMessage = "Please enter a character from A to E.")]
        public string Group { get; set; }
    }    
}
