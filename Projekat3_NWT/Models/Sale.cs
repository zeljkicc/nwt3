using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projekat3_NWT.Models
{
    public class Sale
    {
        public long Id { get; set; }
        public DateTime DateOfSale { get; set; }
        public double Price { get; set; }

        public virtual Property Property { get; set; }
        public virtual ApplicationUser Agent { get; set; }
        public virtual ApplicationUser Buyer { get; set; }
        public virtual Contract Contract { get; set; }

        public Sale()
        {

        }

        public Sale(CreateSaleView createSaleView)
        {
            this.Id = createSaleView.SaleId;
            this.DateOfSale = createSaleView.DateOfSale;
        }

    }
}