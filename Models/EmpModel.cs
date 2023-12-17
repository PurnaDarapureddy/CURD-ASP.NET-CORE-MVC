using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication13.Models
{
    public class EmpModel
    {
        [Display(Name ="ID")]
        public int empid { get; set; }

        [Required(ErrorMessage ="First Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage ="City is required")]
        public string City { get; set; }

        [Required(ErrorMessage ="Adress is Required")]
        public string Address { get; set; }
    }
}
