using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_Pages_Tutorial.Data
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A Name is Required"), StringLength(100)]
        public string Name { get; set; }


        

    }
}
