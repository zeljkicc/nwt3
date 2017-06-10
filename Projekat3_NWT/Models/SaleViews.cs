using Projekat3_NWT.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekat3_NWT.Models
{
    public class CreateSaleView
    {
        [Display(Name = "Date of Sale:")]
        public DateTime DateOfSale { get; set; }

        [Display(Name = "Price of Sale:")]
        public double Price { get; set; }


        public Property Property { get; set; }
        public string AgentId { get; set; }
        public string BuyerId { get; set; }

        public long PropertyId { get; set; }
        public long SaleId { get; set; }

        //public Contract Contract { get; set; }
        [Display(Name = "Title of Contract:")]
        public string contract_title { get; set; }

        [Display(Name = "Contract Content:")]
        public string contract_content { get; set; }

        [Display(Name = "Select Agent:")]
        public IEnumerable<ApplicationUser> AgentsList { get; set; }

        [Display(Name = "Select Buyer:")]
        public IEnumerable<ApplicationUser> ClientsList { get; set; }

        public CreateSaleView()
        {
            AgentsList = new List<ApplicationUser>();
            ClientsList = new List<ApplicationUser>();
        }

        public CreateSaleView(Sale sale)
        {
            
            AgentsList = new List<ApplicationUser>();
            ClientsList = new List<ApplicationUser>();

            this.contract_content = sale.Contract.content;
            this.contract_title = sale.Contract.title;

            this.DateOfSale = sale.DateOfSale;

            this.Property = sale.Property;

            this.PropertyId = sale.Property.Id;

            this.SaleId = sale.Id;

            this.Price = sale.Price;
        }
    }
}