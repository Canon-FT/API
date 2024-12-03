using FTAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CanonFT_API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CustomerController : ControllerBase
    {

        [HttpGet(Name = "RetrieveCustomers")]
        public IEnumerable<Customer> RetrieveCustomers()
        {
            return new List<Customer>();
        }

        [HttpGet("{id:int}", Name = "RetrieveCustomer")]
        public Customer RetrieveCustomer(int id)
        {
            return new Customer("Test");
        }

        [HttpPut("{id:int}", Name = "UpdateCustomer")]
        public void UpdateCustomer(Customer customer)
        {
            return;
        }

        [HttpPost(Name = "CreateCustomer")]
        public void CreateCustomer(Customer customer)
        {
            return;
        }

        [HttpDelete(Name = "DeleteCustomer")]
        public void DeleteCustomer(Customer customer)
        {
            return;
        }
    }
}
