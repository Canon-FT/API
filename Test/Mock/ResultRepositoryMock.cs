using BLL.Agents;
using BLL.Tests;
using BLL.Tests.Results;

namespace DAL.Mock
{
    public class ResultRepositoryMock : IResultRepository
    {
        private List<Result> _Results = new List<Result>();
        public IReadOnlyList<Result> Results {  get { return _Results.AsReadOnly(); } }

        public bool Create(Result result)
        {
            _Results.Add(result);
            return true;
        }

        public bool Delete(Result result)
        {
            _Results.Remove(result);
            return true;
        }

        public List<Result> Retrieve(string testType, Agent reporter, int timeframe)
        {
            DateTime startDate = DateTime.Now.AddMinutes(-timeframe);
            List<Result> results = new List<Result>();
            foreach(Result result in _Results)
            {
                if(result.TestType.Equals(testType) && result.Reporter.Equals(reporter) && result.Timestamp > startDate)
                {
                    results.Add(result);
                }
            }
            return results;
        }

        public List<Result> Retrieve(Test test, Agent reporter, int timeframe)
        {
            return Retrieve(test.TestType, reporter, timeframe);
        }

        public bool Update(Result result)
        {
            Delete(result);
            return Create(result);
        }
    }
}
