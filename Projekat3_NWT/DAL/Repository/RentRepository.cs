using Projekat3_NWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat3_NWT.DAL
{
    public class RentRepository : Repository<Rent>, IRentRepository
    {
        public RentRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public Rent GetRentByPropertyId(long PropertyId)
        {
            return dbSet.Where(r => r.Property.Id == PropertyId).FirstOrDefault();
               // Find(r => r.Property.Id == PropertyId).First();
        }
    }
}