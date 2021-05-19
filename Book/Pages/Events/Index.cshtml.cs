﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Book.Data;

namespace Book.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly Book.Data.ApplicationDbContext _context;

        public IndexModel(Book.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get; set; }

        public async Task OnGetAsync()
        {
            Event = await _context.Events.ToListAsync();
            Event = Event.OrderByDescending(e => e.Id).ToList();
        }
    }
}
