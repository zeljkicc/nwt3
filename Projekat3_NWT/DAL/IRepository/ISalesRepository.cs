using Projekat3_NWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat3_NWT.DAL
{
    public interface ISalesRepository : IRepository<Sale>
    {
        Sale GetSaleByPropertyId(long PropertyId);
    }
}
