using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using BIT.Customer.Models;
using Oqtane.Repository;
using DevExpress.Xpo;
using BIT.Customer.Server.Repository;

namespace BIT.Customer.Repository
{
    public class CustomerRepository : ICustomerRepository, IService
    {
        bool isXpoInitialized;
        private readonly DevExpress.Xpo.UnitOfWork _db;
        ITenantResolver _tenantResolver;
        public bool IsXpoInitialized
        {
            get => isXpoInitialized;
            set => isXpoInitialized = value;
        }
        
        public CustomerRepository(ITenantResolver tenantResolver)
        {
            _tenantResolver = tenantResolver;
        }
        UnitOfWork GetUnitOfWork()
        {
            if(!IsXpoInitialized)
            {
                XpoHelper.InitXpo(_tenantResolver.GetTenant().DBConnectionString);
            }
            return XpoHelper.CreateUnitOfWork();
        }
        public IEnumerable<Models.Customer> GetCustomers(int ModuleId)
        {
            return GetUnitOfWork().Query<Models.Customer>().Where(item => item.ModuleId == ModuleId);
        }

        public Models.Customer GetCustomer(int CustomerId)
        {
            return GetUnitOfWork().Query<Models.Customer>().FirstOrDefault(Customer=>Customer.CustomerId==CustomerId);
        }

        public Models.Customer AddCustomer(Models.Customer Customer)
        {
            UnitOfWork session = GetUnitOfWork();
            session.Save(Customer);
            session.CommitChanges();
            return Customer;
        }

        public Models.Customer UpdateCustomer(Models.Customer customer)
        {
            var UoW = GetUnitOfWork();
            var CustomerInstance= UoW.Query<Models.Customer>().FirstOrDefault(Customer => Customer.CustomerId == customer.CustomerId);
            CustomerInstance.Name = customer.Name;
            UoW.CommitChanges();
            return CustomerInstance;
        }

        public void DeleteCustomer(int CustomerId)
        {
            var UoW = GetUnitOfWork();
            var CucstomerInstance = UoW.Query<Models.Customer>().FirstOrDefault(Customer => Customer.CustomerId == CustomerId);
            UoW.Delete(CucstomerInstance);
            UoW.CommitChanges();
        }
    }
}
