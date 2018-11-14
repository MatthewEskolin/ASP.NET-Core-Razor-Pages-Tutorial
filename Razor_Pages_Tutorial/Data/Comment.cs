using System;

namespace Razor_Pages_Tutorial.Data
{
    public class Comment
    {
        public string CommentText { get; set; }

        public int CommentID { get; set; }
        public int BugID { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }

        public int TestId { get; set; }
        public Bug Bug { get; set; }

    }
}