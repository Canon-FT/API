namespace BLL.Customers
{
    public interface ICustomerRepository
    {
        public IReadOnlyList<Customer> Customers { get; }

        public string Create(Customer customer);
        public Customer? Retrieve(string GUID);
        public bool Update(Customer customer);
        public bool Delete(Customer customer);
        public Customer? FindByServer(Server server);
        public Server? RetrieveServer(string GUID);

    }
}
