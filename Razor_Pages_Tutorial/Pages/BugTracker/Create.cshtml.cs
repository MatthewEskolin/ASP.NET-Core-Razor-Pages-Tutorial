using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Razor_Pages_Tutorial.Data;

namespace Razor_Pages_Tutorial.Pages.BugTracker
{
    public class CreateModel : PageModel
    {
        private readonly Razor_Pages_Tutorial.Data.ApplicationDbContext _context;

        public CreateModel(Razor_Pages_Tutorial.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {

            //prepopulate page model.

         //   Bug.CreateDate = DateTime.Now;

            return Page();


        }

        [BindProperty]
        public Bug Bug { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyBug = new Bug();
            if (await TryUpdateModelAsync<Bug>(
                emptyBug, "bug", x => x.Title, x => x.Severity))
            {
                emptyBug.CreateDate = DateTime.Now;

                _context.Bug.Add(emptyBug);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }


            _context.Bug.Add(Bug);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}