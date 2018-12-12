using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor_Pages_Tutorial.Data;
using Razor_Pages_Tutorial.Util;

namespace Razor_Pages_Tutorial.Pages.BugTracker
{
    public class IndexModel : PageModel
    {

        //Sort Functionality
        public string DateSort { get; set; }
        public string TitleSort { get; set; }
        public string SeveritySort { get; set; }

        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }



        private readonly Razor_Pages_Tutorial.Data.ApplicationDbContext _context;

        public IndexModel(Razor_Pages_Tutorial.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public PaginatedList<Bug> Bug { get;set; }

        public async Task OnGetAsync(string sortOrder,string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;

            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            TitleSort = sortOrder == "Title" ? "title_desc" : "Title";
            SeveritySort = sortOrder == "Severity" ? "severity_desc" : "Severity";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }


            CurrentFilter = searchString;


            var bugs =  _context.Bug.AsQueryable();

            //filtering
            if (!String.IsNullOrEmpty(searchString))
            {
                bugs = bugs.Where(x => x.Title.Contains(searchString));

            }


            //sorting
            switch (sortOrder)
            {
                case "date_desc":
                    bugs = bugs.OrderByDescending(x => x.CreateDate);
                    break;
                case "Date":
                    bugs = bugs.OrderBy(x => x.CreateDate);
                    break;
                case "title_desc":
                    bugs = bugs.OrderByDescending(x => x.Title);
                    break;
                case "Title":
                    bugs = bugs.OrderBy(x => x.Title);
                    break;
                case "severity_desc":
                    bugs = bugs.OrderByDescending(x => x.Severity);
                    break;
                case "Severity":
                    bugs = bugs.OrderBy(x => x.Severity);
                    break;
                default:
                    bugs = bugs.OrderBy(x => x.CreateDate);
                    break;
            }


            int pageSize = 20;
            Bug = await PaginatedList<Bug>.CreateAsync(bugs.AsNoTracking(), pageIndex ?? 1, pageSize);

        }
    }
}
