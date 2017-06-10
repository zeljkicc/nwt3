using Projekat3_NWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Projekat3_NWT.DAL
{
    public class PropertyImageRepository : Repository<PropertyImage>, IPropertyImageRepository
    {
        public PropertyImageRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<PropertyImage> GetImagesByPropertyId(long PropertyId)
        {
            return Find(i => i.Property.Id == PropertyId);
        }
    }
}