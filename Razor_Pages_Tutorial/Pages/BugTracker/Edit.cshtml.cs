using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Razor_Pages_Tutorial.Data;

namespace Razor_Pages_Tutorial.Pages.BugTracker
{
    public class EditModel : PageModel
    {
        private readonly Razor_Pages_Tutorial.Data.ApplicationDbContext _context;

        public EditModel(Razor_Pages_Tutorial.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bug Bug { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bug = await _context.Bug.FindAsync(id);

            if (Bug == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var bugtoUpdate = await _context.Bug.FindAsync(id);

            if (await TryUpdateModelAsync<Bug>(
                bugtoUpdate,
                "bug",
                s => s.Title, s => s.Severity, s => s.CreateDate))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();


            //Orginal Update Code before using FindAsync and TryUpdateModel
            #region Method Original
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Attach(Bug).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!BugExists(Bug.BugID))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return RedirectToPage("./Index");
            #endregion
        }

        private bool BugExists(int id)
        {
            return _context.Bug.Any(e => e.BugID == id);
        }
    }
}
