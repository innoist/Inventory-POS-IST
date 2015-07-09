using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface ICustomerService
    {
        Customer GetCustomer(long customerId);
        IEnumerable<Customer> GetAllCustomers();
        long AddCustomer(Customer customer);
        Customer GetCustomerByEmailOrPhone(string query);
    }
}
