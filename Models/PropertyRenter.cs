using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Caviris_MIS4200.Models
{
    public class PropertyRenter
    {
        public int propertyRenterID { get; set; }

        [Display(Name = "Date Property was Rented on")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime dateTimeRented { get; set; }

        [Display(Name = "Monthly Rent")]
        [DataType(DataType.Currency)]
        [Required]
        public decimal monthlyRent { get; set; }

        [Display(Name = "Date Lease Ended")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}" , ApplyFormatInEditMode = true)]
        [Required]
        public DateTime dateTimeEnded { get; set; }


        [Display(Name = "Property Street Address")]
        //[StringLength(200)]
        [Required]
        public int propertyID { get; set; }

        [Display(Name = "Renter Name")]
        public int renterID { get; set; }

        public virtual Property property { get; set; }
        public virtual Renter renter { get; set; }
        //public string PropertyRenterInfo
        //{
        //    get
        //    {
        //        return renter.fullName + " rented " + property.streetAddress + " from " + dateTimeRented.ToShortDateString() + dateTimeEnded.ToShortDateString();
        //    }
        //}

    }
}