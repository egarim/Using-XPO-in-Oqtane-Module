using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Repository;
using BIT.Customer.Models;
using BIT.Customer.Repository;
using BIT.Customer.Server.Repository;

namespace BIT.Customer.Manager
{
    public class CustomerManager : IInstallable, IPortable
    {
        private ICustomerRepository _CustomerRepository;
        private ISqlRepository _sql;

        public CustomerManager(ICustomerRepository CustomerRepository, ISqlRepository sql)
        {
            _CustomerRepository = CustomerRepository;
            _sql = sql;
        }

        public bool Install(Tenant tenant, string version)
        {
            XpoHelper.InitXpo(tenant.DBConnectionString);
            //return _sql.ExecuteScript(tenant, GetType().Assembly, "BIT.Customer." + version + ".sql");
            return true;
        }

        public bool Uninstall(Tenant tenant)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "BIT.Customer.Uninstall.sql");
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<Models.Customer> Customers = _CustomerRepository.GetCustomers(module.ModuleId).ToList();
            if (Customers != null)
            {
                content = JsonSerializer.Serialize(Customers);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Models.Customer> Customers = null;
            if (!string.IsNullOrEmpty(content))
            {
                Customers = JsonSerializer.Deserialize<List<Models.Customer>>(content);
            }
            if (Customers != null)
            {
                foreach(var Customer in Customers)
                {
                    _CustomerRepository.AddCustomer(new Models.Customer { ModuleId = module.ModuleId, Name = Customer.Name });
                }
            }
        }
    }
}