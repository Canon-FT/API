using BLL.Agents;
using BLL.Customers;
using BLL.Tests;
using Microsoft.AspNetCore.Hosting.Server;

namespace DAL.Mock
{
    public class CustomerRepositoryMock() : ICustomerRepository
    {
        private List<Customer> _Customers = new List<Customer>();

        public IReadOnlyList<Customer> Customers { get { return _Customers.AsReadOnly(); } }

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
