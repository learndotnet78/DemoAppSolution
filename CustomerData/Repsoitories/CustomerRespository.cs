using CustomerDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CustomerData.Repositories
{
    public class CustomerRespository : ICustomerRepository
    {
        readonly List<Customer> _list;
        int cnt = 3;
        public CustomerRespository()
        {
            _list = new List<Customer>();

            Customer customer = new()
            {
                CustomerID = 1,
                CustomerName = "Sam Johnson",
                Address = "12 Felix Drive",
                City = "Trenton",
                State = "NJ",
                Comments = "NJ Customer"
            };
            _list.Add(customer);

            customer = new()
            {
                CustomerID = 2,
                CustomerName = "Pam Michael",
                Address = "145 Maple Drive",
                City = "New York",
                State = "NY",
                Comments = "NY Customer"
            };
            _list.Add(customer);

            customer = new()
            {
                CustomerID = 3,
                CustomerName = "Jeff Byrce",
                Address = "15 Philadephia Avenue",
                City = "Philadephia",
                State = "PA",
                Comments = "PA Customer"
            };
            _list.Add(customer);


        }
        public Customer AddCustomer(Customer cust)
        {
            Customer custAdd = new()
            {
                CustomerID = cnt + 1,
                CustomerName = cust.CustomerName,
                Address = cust.Address,
                City = cust.City,
                State = cust.State,
                Comments = cust.Comments
            };
            _list.Add(custAdd);

            return _list.FirstOrDefault(x => x.CustomerID == cnt + 1);
        }

        public bool DeleteCustomer(int customerId)
        {
            if (_list != null)
            {
                Customer deleteCustomer = _list.FirstOrDefault(x => x.CustomerID == customerId);

                _list.Remove(deleteCustomer);

                return true;
            }

            return false;
        }

        public Customer GetCustomerById(int customerId)
        {
            return _list.FirstOrDefault(x => x.CustomerID == customerId);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _list;
        }

        public Customer UpdateCustomer(Customer cust)
        {
            Customer custUpd = _list.Where(x => x.CustomerID == cust.CustomerID).FirstOrDefault();

            if (custUpd != null)
            {
                custUpd.CustomerName = cust.CustomerName;
                custUpd.Address = cust.Address;
                custUpd.City = cust.City;
                custUpd.State = cust.State;
                custUpd.Comments = cust.Comments;
            }


            return custUpd;
        }
    }
}
