using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Caviris_MIS4200.Models
{
    public class Owner
    {
        public int ownerID { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [StringLength(20)]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(20)]
        public string lastName { get; set; }

        [Display(Name = "Phone Number")]
        [RegularExpression(@"^(\(\d{3}\) |\d{3}-)\d{3}-\d{4}$",
            ErrorMessage = "Phone numbers must be in the format (xxx) xxx-xxxx or xxx-xxx-xxxx")]
        [Required]
        public string phoneNumber { get; set; }
        public ICollection<Property> property { get; set; }

        [Display(Name = "Full Name")]
        
        public string fullName
        {
            get
            {
                return lastName + ", " + firstName;
            }
        }



    }
}