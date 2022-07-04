using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter name of the employee")]
        
        public string Name { get; set; }
        [Required]
        public Dept Department { get; set; }

    }
}
