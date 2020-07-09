using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace exercise_8.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public String firstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public String lastName { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public String email { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public String phoneNum { get; set; }

        [Display(Name = "Notes")]
        public String notes { get; set; }
    }
}
