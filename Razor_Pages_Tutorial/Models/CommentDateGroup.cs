using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_Pages_Tutorial.Models
{

    public class CommentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? CommentDate { get; set; }
        public int CommentCount { get; set; }

    }

}
