namespace BLL.Tests
{
    public interface ITestRepository
    {
        public IReadOnlyList<Test> Tests { get; }

        public bool Create(Test test);

        public Test Retrieve(string testType);

        public bool Update (Test test);

        public bool Delete(Test test);
    }
}
