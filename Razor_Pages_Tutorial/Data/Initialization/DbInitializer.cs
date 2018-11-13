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


            foreach (var bug in bugs)
            {
                var bugComment = new Comment() {BugID = bug.BugID};

            }



        }
    }
}
