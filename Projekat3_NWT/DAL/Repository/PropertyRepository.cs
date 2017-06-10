using Projekat3_NWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat3_NWT.DAL
{
    public class PropertyRepository : Repository<Property>, IPropertyRepository
    {
        public PropertyRepository(ApplicationDbContext context)
            : base(context)
        {

        }
    }
}