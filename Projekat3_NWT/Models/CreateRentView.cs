using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekat3_NWT.Models
{
    public class CreateRentView
    {

        [Display(Name = "Monthly Fee")]
        public double MonthlyFee { get; set; }

        [Display(Name = "Start Date")]
        public DateTime startDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime endDate { get; set; }

        [Display(Name = "Title of Contract")]
        public string contract_title { get; set; }

        [Display(Name = "Contract Content")]
        public string contract_content { get; set; }

        public virtual ApplicationUser Agent { get; set; }
        public virtual ApplicationUser Client { get; set; }

        public virtual Contract Contract { get; set; }

        public long RentId { get; set; }
        public string AgentId { get; set; }
        public string BuyerId { get; set; }
        public long PropertyId { get; set; }

        public Property Property { get; set; }
        
        [Display(Name = "Select Agent")]
        public IEnumerable<ApplicationUser> AgentsList { get; set; }

        [Display(Name = "Select Renter")]
        public IEnumerable<ApplicationUser> ClientsList { get; set; }
    }
}