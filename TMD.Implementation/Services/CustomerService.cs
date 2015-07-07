using System.Collections.Generic;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Customer GetCustomer(long vendorId)
        {
            return customerRepository.Find(vendorId);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return customerRepository.GetAll();
        }        
        public long AddCustomer(Customer customer)
        {
            if (customer.Id > 0)
                customerRepository.Update(customer);
            else
                customerRepository.Add(customer);

            customerRepository.SaveChanges();
            return customer.Id;
        }
    }
}

