using CanonFT_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CanonFT_API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CustomerController : ControllerBase
    {

        [HttpGet(Name = "GetCustomers")]
        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>();
        }

        [HttpGet("{id:int}", Name = "GetCustomer")]
        public Customer GetCustomer(int id)
        {
            return new Customer("Test");
        }
    }
}
