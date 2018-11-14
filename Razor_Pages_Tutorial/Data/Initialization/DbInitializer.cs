using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_Pages_Tutorial.Data.Initialization
{
    public class DbInitializer
    {

        public static void Initialize(ApplicationDbContext context)
        {
  

            if (context.Bug.Any())
            {
                EveryBugGetsAComment(context);
                return;

            }


            var bugs = new Bug[]
            {
                new Bug()
                {
                    Severity = BugSeverity.Medium, CreateDate = DateTime.Now, Title = "Data does not display correctly"
                },
                new Bug() {Severity = BugSeverity.Medium, CreateDate = DateTime.Now, Title = "input error"},
                new Bug() {Severity = BugSeverity.Medium, CreateDate = DateTime.Now, Title = "css error"},
                new Bug() {Severity = BugSeverity.Medium, CreateDate = DateTime.Now, Title = "Exception thrown"},
                new Bug() {Severity = BugSeverity.Medium, CreateDate = DateTime.Now, Title = "error2"},
                new Bug()
                {
                    Severity = BugSeverity.Medium, CreateDate = DateTime.Now, Title = "Data does not display correctly"
                }
            };

            foreach (var bug in bugs)
            {
                context.Bug.Add(bug);
            }

            context.SaveChanges();

            EveryBugGetsAComment(context);


        }

        private static void EveryBugGetsAComment(ApplicationDbContext ctx)
        {
            //get bugs without comments
            var bugs = ctx.Bug.Where(x => !ctx.Comments.Any(y => y.BugID == x.BugID)).ToList();

            foreach (var bug in bugs)
            {
                var bugComment = new Comment()
                {
                    BugID = bug.BugID, CreateDate = DateTime.Now,
                    CommentText = $"This is a test comment for bug {bug.BugID}"
                };

                ctx.Comments.Add(bugComment);
                ctx.SaveChanges();
            }
        }
    }
}
