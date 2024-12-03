namespace FTAPI.Models
{
    public class Customer
    {
        public String Name { get; private set; }

        public int Id { get; private set; }

        public Customer(String name) {
            Name = name;
        }
    }
}
