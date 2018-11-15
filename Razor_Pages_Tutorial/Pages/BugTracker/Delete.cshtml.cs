using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor_Pages_Tutorial.Data;

namespace Razor_Pages_Tutorial.Pages.BugTracker
{
    public class DeleteModel : PageModel
    {
        private readonly Razor_Pages_Tutorial.Data.ApplicationDbContext _context;

        public DeleteModel(Razor_Pages_Tutorial.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bug Bug { get; set; }

        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bug = await _context.Bug.AsNoTracking().FirstOrDefaultAsync(m => m.BugID == id);

            if (Bug == null)
            {
                return NotFound();
            }


            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again.";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bug = await _context.Bug.AsNoTracking().FirstOrDefaultAsync(x => x.BugID == id);

            if (bug == null)
            {
                return NotFound();
            }

            try
            {
                _context.Bug.Remove(bug);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("./Delete", new {id, saveChangesError = true});
            }
        }
    }
}
