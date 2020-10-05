using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Razor;

namespace Caviris_MIS4200.Models
{
    public class Property
    {
        public int propertyID { get; set; }

        [Display(Name = "Street Address")]
        [StringLength(100)]
        [Required]
        public string streetAddress { get; set; }

        
        [Display(Name = "City")]
       [StringLength(50)]
        [Required]
        public string city { get; set; }


        [Display(Name = "State")]
        [StringLength(50)]
        [Required]
        public string state { get; set; }


        [Display(Name = "Zip Code")]
        [Required]
        public string zipcode { get; set; }

        [Display(Name = "Owner Name")]
        public int ownerID { get; set; }
        public virtual Owner owner { get; set; }
    }
}