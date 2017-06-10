using Projekat3_NWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Projekat3_NWT.DAL
{
    public class ContractRepository : Repository<Contract>, IContractRepository
    {
        public ContractRepository(DbContext context) : base(context)
        {
        }
    }
}