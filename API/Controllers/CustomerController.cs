using BLL.Customers;
using Microsoft.AspNetCore.Mvc;

namespace CanonFT_API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CustomerController(ICustomerRepository customerRepository) : ControllerBase
    {
        private ICustomerRepository _CustomerRepository = customerRepository;

        [HttpGet(Name = "RetrieveCustomers")]
        public IActionResult RetrieveCustomers()
        {
            return Ok(_CustomerRepository.Customers);
        }

        [HttpPost(Name = "CreateCustomer")]
        public string CreateCustomer(Customer customer)
        {
            return _CustomerRepository.Create(customer);
        }

        [HttpGet("{cid}", Name = "RetrieveCustomer")]
        public IActionResult RetrieveCustomer([FromRoute] string cid)
        {
            Customer? customer = _CustomerRepository.Retrieve(cid);
            if(customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPut("{cid}", Name = "UpdateCustomer")]
        public IActionResult UpdateCustomer([FromRoute] string cid, Customer customer)
        {
            if(customer.GUID != cid) return BadRequest();
            return Ok(_CustomerRepository.Update(customer));
        }

        [HttpDelete("{cid}", Name = "DeleteCustomer")]
        public IActionResult DeleteCustomer([FromRoute] string cid)
        {
            Customer? customer = _CustomerRepository.Retrieve(cid);
            if (customer == null) return NotFound();
            return Ok(_CustomerRepository.Delete(customer));
        }

        [HttpGet("{cid}/Server", Name = "RetrieveServers")]
        public IActionResult RetrieveCustomerServers([FromRoute] string cid)
        {
            Customer? customer = _CustomerRepository.Retrieve(cid);
            if (customer == null) return NotFound();
            return Ok(customer.Servers);
        }

        [HttpPost("{cid}/Server", Name = "CreateServer")]
        public IActionResult CreateServer([FromRoute] string cid, Server server)
        {
            Customer? customer = _CustomerRepository.Retrieve(cid);
            if (customer == null) return NotFound();
            customer.Servers.Add(server);
            return Ok();
        }

        [HttpGet("{cid}/Server/{sid}", Name = "RetrieveServer")]
        public IActionResult RetrieveCustomerServer([FromRoute] string cid, [FromRoute] string sid)
        {
            Customer? customer = _CustomerRepository.Retrieve(cid);
            if (customer == null) return NotFound();
            Server? server = _CustomerRepository.RetrieveServer(sid);
            if (server == null) return NotFound();
            return Ok(server);
        }

        [HttpPut("{cid}/Server/{sid}", Name = "UpdateServer")]
        public IActionResult UpdateServer([FromRoute] string cid, [FromRoute] string sid, Server server)
        {
            Customer? customer = _CustomerRepository.Retrieve(cid);
            if (customer == null) return NotFound();
            Server? existingServer = _CustomerRepository.RetrieveServer(sid);
            if (existingServer == null) return NotFound();
            customer.Servers.Remove(existingServer);
            customer.Servers.Add(server);
            return Ok(_CustomerRepository.Update(customer));
        }

        [HttpDelete("{cid}/Server/{sid}", Name = "DeleteServer")]
        public IActionResult DeleteServer([FromRoute] string cid, [FromRoute] string sid)
        {
            Customer? customer = _CustomerRepository.Retrieve(cid);
            if (customer == null) return NotFound();
            Server? server = _CustomerRepository.RetrieveServer(sid);
            if (server == null) return NotFound();
            customer.Servers.Remove(server);
            return Ok(_CustomerRepository.Update(customer));
        }
    }
}
