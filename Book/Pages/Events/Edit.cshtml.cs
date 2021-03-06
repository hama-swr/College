using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Book.Data;

namespace Book.Pages.Events
{
    public class EditModel : PageModel
    {
        private readonly Book.Data.ApplicationDbContext _context;
        private readonly IHtmlHelper htmlHelper;
        public IEnumerable<SelectListItem> EventTypes { get; set; }

        public EditModel(Book.Data.ApplicationDbContext context,
                                          IHtmlHelper htmlHelper)
        {
            _context = context;
            this.htmlHelper = htmlHelper;
        }

        [BindProperty]
        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            EventTypes = htmlHelper.GetEnumSelectList<EventType>();

            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            EventTypes = htmlHelper.GetEnumSelectList<EventType>();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(Event.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
