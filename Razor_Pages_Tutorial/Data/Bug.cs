using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_Pages_Tutorial.Data
{
    public class Bug
    {
        public int BugID { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }

        public string Title { get; set; }

        public BugSeverity Severity { get; set; }

        [Display(Name="Comments")]
        public ICollection<Comment> Comments { get; set; }

        
        public ICollection<Customer> Contacts { get; set; }

    }
}
