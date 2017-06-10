using Projekat3_NWT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat3_NWT.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IPropertyRepository PropertyRepository { get; }
        IAddressRepository AddressRepository { get; }
        ISalesRepository SalesRepository { get; }

        //proba 
        IApplicationUserRepository ApplicationUserRepository { get; }

        void Save();

        DbContext getDbContext();
    }
}
