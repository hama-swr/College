using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Pages.Newses
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public NewsType NewsType { get; set; }
    }
}
