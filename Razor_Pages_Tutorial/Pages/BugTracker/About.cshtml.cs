using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor_Pages_Tutorial.Data;
using Razor_Pages_Tutorial.Models;

namespace Razor_Pages_Tutorial.Pages.BugTracker
{
    public class AboutModel : PageModel
    {
        private readonly ApplicationDbContext ctx;

        public AboutModel(ApplicationDbContext context)
        {
            ctx = context;
        }

        public IList<CommentDateGroup> CommentDates { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<CommentDateGroup> data =
                from comment in ctx.Comments
                group comment by comment.CreateDate into dateGroup
                select new CommentDateGroup()
                {
                    CommentDate = dateGroup.Key,
                    CommentCount= dateGroup.Count()
                };

            CommentDates = await data.AsNoTracking().ToListAsync();
        }
    }
}