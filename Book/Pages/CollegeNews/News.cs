using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Pages.Newses
{
    public class News
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }

        [Required]
        public string Photo { get; set; }

        [Required]
        public string Author { get; set; }

        [Required, MinLength(20, ErrorMessage = "Length must be 20 characters or more")]
        public string Content { get; set; }
        public NewsType NewsType { get; set; }
    }
}
