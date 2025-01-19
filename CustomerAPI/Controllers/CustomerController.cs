using CustomerData.Repositories;
using CustomerDomain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRespository customerRespository;
        public CustomerController()
        {
            customerRespository = new CustomerRespository();

        }

        [HttpGet]
        public IEnumerable<Customer> GetAllCustomers()
        {
            IEnumerable<Customer> lstCustomers = null;

            if (customerRespository != null)
            {
                lstCustomers = customerRespository.GetCustomers();
            }
            return lstCustomers;
        }

        [HttpGet("{customerID}")]
        public IActionResult GetAllCustomerById(int customerID)
        {
            var customer = customerRespository.GetCustomerById(customerID);
            return Ok(customer);
        }

        [HttpPost]
        [Route("AddCustomer")]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            if (customer != null)
            {
                var objCustomer = customerRespository.AddCustomer(customer);
                return Ok(objCustomer);
            }

            return Ok();
        }

        [HttpPost]
        [Route("UpdateCustomer")]
        public IActionResult UpdateCustomer([FromBody] Customer customer)
        {
            if (customer != null)
            {
                var objCustomer = customerRespository.UpdateCustomer(customer);
                return Ok(objCustomer);
            }

            return Ok();
        }

        [HttpDelete]
        [Route("DeleteCustomer")]
        public JsonResult Delete(int customerID)
        {
            var boolVal = customerRespository.DeleteCustomer(customerID);
            if (boolVal)
                return new JsonResult("Deleted Successfully.");
            else
                return new JsonResult("Custoemr was not deleted.");
        }
    }
}
