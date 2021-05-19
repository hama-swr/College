using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Book.Data;

namespace Book.Pages.Newses
{
    public class IndexModel : PageModel
    {
        private readonly Book.Data.ApplicationDbContext _context;

        public IndexModel(Book.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<News> News { get;set; }

        public async Task OnGetAsync()
        {
            News = await _context.News.ToListAsync();
        }
    }
}
