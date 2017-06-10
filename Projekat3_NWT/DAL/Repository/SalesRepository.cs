using Projekat3_NWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat3_NWT.DAL
{
    public class SalesRepository : Repository<Sale>, ISalesRepository
    {
        public SalesRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public Sale GetSaleByPropertyId(long PropertyId)
        {

            return Find(r => r.Property.Id == PropertyId).FirstOrDefault();
        }
    }
}