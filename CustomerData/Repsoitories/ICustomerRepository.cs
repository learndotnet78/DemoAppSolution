using CustomerDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerData.Repositories
{
    public interface ICustomerRepository
    {
        public IEnumerable<Customer> GetCustomers();
        public Customer GetCustomerById(int customerId);
        public Customer AddCustomer(Customer customer);
        public Customer UpdateCustomer(Customer customer);
        public bool DeleteCustomer(int customerId);

    }
}
