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
    public class DetailsModel : PageModel
    {
        private readonly Razor_Pages_Tutorial.Data.ApplicationDbContext _context;

        public DetailsModel(Razor_Pages_Tutorial.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public string ErrorMessage { get; set; }


        public Bug Bug { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bug = await _context.Bug.Include(x => x.Comments).AsNoTracking().FirstOrDefaultAsync(m => m.BugID == id);

            if (Bug == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
