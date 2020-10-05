using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;

namespace Caviris_MIS4200.Models
{
    public class Renter
    {
        public int renterID { get; set; }

        [Display(Name = "First Name")]
        [StringLength(20)]
        [Required]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(20)]
        [Required]
        public string lastName { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\(\d{3}\) |\d{3}-)\d{3}-\d{4}$",
            ErrorMessage = "Phone numbers must be in the format (xxx) xxx-xxxx or xxx-xxx-xxxx")]
        [Required]
        public string phoneNumber { get; set; }

        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime birthday { get; set; }
        public ICollection<PropertyRenter> propertyRenter { get; set; }

        [Display(Name = "Renter Name")]
        public string fullName
        {
            get
            {
                return lastName + ", " + firstName;
            }
        }
    }
}
