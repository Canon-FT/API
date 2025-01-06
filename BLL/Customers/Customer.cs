using BLL.Tests;

namespace BLL.Customers
{
    public class Customer
    {
        public string Name;

        public string GUID;

        public string uFversion;

        public List<Server> Servers { get; private set; }

        public TestPlan Testplan;

        public Customer(string name)
        {
            Name = name;
            Servers = new List<Server>();
        }
    }
}
