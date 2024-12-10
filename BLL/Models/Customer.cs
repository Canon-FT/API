namespace FTAPI.Models
{
    public class Customer
    {
        public string Name { get; private set; }

        public string GUID { get; private set; }

        public string uFversion { get; private set; }

        public List<Server> Servers { get; private set; }

        public Customer(String name) {
            Name = name;
        }
    }
}
