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

        [HttpPost(Name = "CreateCustomer")]
        public string CreateCustomer(Customer customer)
        {
            return "GUID";
        }

        [HttpGet("{cid:int}", Name = "RetrieveCustomer")]
        public Customer RetrieveCustomer(int cid)
        {
            return new Customer("Test");
        }

        [HttpPut("{cid:int}", Name = "UpdateCustomer")]
        public void UpdateCustomer(Customer customer)
        {
            return;
        }

        [HttpDelete("{cid:int}", Name = "DeleteCustomer")]
        public void DeleteCustomer(int cid)
        {
            return;
        }

        [HttpGet("{cid:int}/Server", Name = "RetrieveServers")]
        public IEnumerable<Server> RetrieveCustomerServers(int cid)
        {
            return new List<Server>();
        }

        [HttpPost("{cid:int}/Server", Name = "CreateServer")]
        public string CreateServer(int cid, Server server)
        {
            return "GUID";
        }

        [HttpGet("{cid:int}/Server/{sid}", Name = "RetrieveServer")]
        public Server RetrieveCustomerServer(int cid, int sid)
        {
            return new Server();
        }

        [HttpPut("{cid:int}/Server/{sid}", Name = "UpdateServer")]
        public void UpdateServer(int cid, Server server)
        {
            return;
        }

        [HttpDelete("{cid:int}/Server/{sid}", Name = "DeleteServer")]
        public void UpdateServer(int cid, int sid)
        {
            return;
        }
    }
}
