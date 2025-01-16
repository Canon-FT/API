using BLL.Customers;

namespace BLL.Tests
{
    public class Test(string testType, CustomerStatus statusWhenFailed, List<string> parameters)
    {
        public string TestType { get; private set; } = testType;

        public CustomerStatus StatusWhenFailed { get; private set; } = statusWhenFailed;

        public IReadOnlyList<string> Parameters { get { return parameters.AsReadOnly(); } }
    }
}
