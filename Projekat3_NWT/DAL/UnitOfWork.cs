using Projekat3_NWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Projekat3_NWT.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext context;

        private IPropertyRepository propertyRepository;
        private IAddressRepository addressRepository;
        private ISalesRepository salesRepository;
        private IContractRepository contractRepository;
        private IRentRepository rentRepository;
        private IPropertyImageRepository propertyImageRepository;
        private IMessageRepository messageRepository;

        private IApplicationUserRepository userRepository;

        public UnitOfWork()
        {
            context = new ApplicationDbContext();
        }   

        public IPropertyRepository PropertyRepository
        {
            get
            {

                if (propertyRepository == null)
                    propertyRepository = new PropertyRepository(context);
                return propertyRepository;
            }
        }

        public IAddressRepository AddressRepository
        {
            get
            {

                if (addressRepository == null)
                    addressRepository = new AddressRepository(context);
                return addressRepository;
            }
        }

        public ISalesRepository SalesRepository
        {
            get
            {

                if (salesRepository == null)
                    salesRepository = new SalesRepository(context);
                return salesRepository;
            }
        }

        public IApplicationUserRepository ApplicationUserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new ApplicationUserRepository(context);
                return userRepository;
            }
        }

        public IContractRepository ContractRepository
        {
            get
            {
                if (contractRepository == null)
                    contractRepository = new ContractRepository(context);
                return contractRepository;
            }
        }

        public IRentRepository RentRepository
        {
            get
            {
                if (rentRepository == null)
                    rentRepository = new RentRepository(context);
                return rentRepository;
            }
        }

        public IPropertyImageRepository PropertyImageRepository
        {
            get
            {
                if (propertyImageRepository == null)
                    propertyImageRepository = new PropertyImageRepository(context);
                return propertyImageRepository;
            }
        }

        public IMessageRepository MessageRepository
        {
            get
            {
                if (messageRepository == null)
                    messageRepository = new MessageRepository(context);
                return messageRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public DbContext getDbContext()
        {
            return context;
        }
    }
}