using Projekat3_NWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat3_NWT.DAL
{
    public interface IRentRepository : IRepository<Rent>
    {
        Rent GetRentByPropertyId(long PropertyId);
    }
}