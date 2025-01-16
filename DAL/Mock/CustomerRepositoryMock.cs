using BLL.Agents;
using BLL.Customers;
using BLL.Tests;
using Microsoft.AspNetCore.Hosting.Server;

namespace DAL.Mock
{
    public class CustomerRepositoryMock : ICustomerRepository
    {
        private List<Customer> _Customers = new List<Customer>();

        private ITestRepository _TestRepository;

        public IReadOnlyList<Customer> Customers { get { return _Customers.AsReadOnly(); } }

        public CustomerRepositoryMock(ITestRepository testrepo)
        {
            _TestRepository = testrepo;

            // Mock data server
            Server server = new Server();
            server.GUID = "TESTSERVER";

            Server server2 = new Server();
            server2.GUID = "TESTSERVER2";

            // Mock data Test
            Test CheckStatusPage = _TestRepository.Retrieve("CheckStatusPage");
            var testplan = new TestPlan();

            var action1 = new TestAction(CheckStatusPage, 60, new Dictionary<string, string>() { { "url", "https://localhost:8443/status.htm" } });
            testplan.AddStep(action1, server);
            var action2 = new TestAction(CheckStatusPage, 60, new Dictionary<string, string>() { { "url", "http://localhost:8000/status.htm" } });
            testplan.AddStep(action2, server);

            // Mock data customer
            Customer customer = new Customer("Test Customer");
            customer.Servers.Add(server);
            customer.Servers.Add(server2);
            customer.Testplan = testplan;
            _Customers.Add(customer);
        }

        public string Create(Customer customer)
        {
            _Customers.Add(customer);
            return customer.GUID;
        }

        public bool Delete(Customer customer)
        {
            Customer? existingCustomer = Retrieve(customer.GUID);
            if (existingCustomer != null)
            {
                return _Customers.Remove(customer);
            }
            return false;
        }

        public Customer? FindByServer(Server server)
        {
            foreach(Customer c in _Customers)
            {
                foreach(Server s in  c.Servers)
                {
                    if(s.GUID == server.GUID)
                    {
                        return c;
                    }
                }
            }
            return null;
        }

        public Customer? Retrieve(string GUID)
        {
            foreach (Customer customer in _Customers)
            {
                if (customer.GUID == GUID) return customer;
            }
            return null;
        }

        public Server? RetrieveServer(string GUID)
        {
            foreach (Customer c in _Customers)
            {
               foreach(Server s in c.Servers)
                {
                    if (s.GUID == GUID) { return s; }
                }
            }
            return null;
        }

        public bool Update(Customer customer)
        {
            Delete(customer);
            Create(customer);
            return true;
        }
    }
}
