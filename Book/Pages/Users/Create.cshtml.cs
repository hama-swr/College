using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Book.Data;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Book.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly Book.Data.ApplicationDbContext _context;
        private readonly IHtmlHelper htmlHelper;
        public IEnumerable<SelectListItem> UserTypes { get; set; }

        public CreateModel(Book.Data.ApplicationDbContext context,
                                            IHtmlHelper htmlHelper)
        {
            _context = context;
            this.htmlHelper = htmlHelper;

        }

        public IActionResult OnGet()
        {
            UserTypes = htmlHelper.GetEnumSelectList<UserType>();

            return Page();
        }

        [BindProperty]
        public User User { get; set; }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            UserTypes = htmlHelper.GetEnumSelectList<UserType>();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.User.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
