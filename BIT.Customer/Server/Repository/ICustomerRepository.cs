using System.Collections.Generic;
using BIT.Customer.Models;

namespace BIT.Customer.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Models.Customer> GetCustomers(int ModuleId);
        Models.Customer GetCustomer(int CustomerId);
        Models.Customer AddCustomer(Models.Customer Customer);
        Models.Customer UpdateCustomer(Models.Customer Customer);
        void DeleteCustomer(int CustomerId);
    }
}
