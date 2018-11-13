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
    public class IndexModel : PageModel
    {
        private readonly Razor_Pages_Tutorial.Data.ApplicationDbContext _context;

        public IndexModel(Razor_Pages_Tutorial.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Bug> Bug { get;set; }

        public async Task OnGetAsync()
        {
            Bug = await _context.Bug.ToListAsync();
        }
    }
}
