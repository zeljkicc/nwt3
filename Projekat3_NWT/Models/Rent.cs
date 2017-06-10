using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projekat3_NWT.Models
{
    public class Rent
    {
        public long Id { get; set; }

        [Display(Name = "Monthly Fee")]
        public double MonthlyFee { get; set; }

        [Display(Name = "Start Date")]
        public DateTime startDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime endDate { get; set; }

        [Display(Name = "Agent")]
        public virtual ApplicationUser Agent { get; set; }

        [Display(Name = "Renter")]
        public virtual ApplicationUser client { get; set; }

        public virtual Contract Contract { get; set; }

        [Display(Name = "Property")]
        public virtual Property Property { get; set; }

    }
}