using BLL.Agents;

namespace BLL.Tests.Results
{
    public interface IResultRepository
    {
        public IReadOnlyList<Result> Results { get; }

        public bool Create(Result result);

        public List<Result> Retrieve(string testType, Agent reporter, int timeFrame);

        public List<Result> Retrieve(Test test, Agent reporter, int timeFrame);

        public bool Update(Result result);

        public bool Delete(Result result);
    }
}
