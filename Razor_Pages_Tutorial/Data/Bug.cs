using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_Pages_Tutorial.Data
{
    public class Bug
    {
        public int BugID { get; set; }

        public DateTime CreateDate { get; set; }

        public string Title { get; set; }

        public BugSeverity Severity { get; set; }

        public ICollection<Comment> Comments { get; set; }

    }


    public enum BugSeverity
    {
        Undefined = 0,
        Low = 1,
        Medium = 2,
        High = 3,
        Critical = 4
    }

    


    public class Comment
    {
        public int CommentID { get; set; }
        public int BugID { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }

        public Bug Bug { get; set; }

    }


       
}
