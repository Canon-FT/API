using BLL.Agents;
using BLL.Tests;
using BLL.Customers;
using System;


namespace DAL.Mock
{
    public class TestRepositoryMock : ITestRepository
    {
        private List<Test> _Tests = new List<Test>();

        public IReadOnlyList<Test> Tests => _Tests.AsReadOnly();

        public TestRepositoryMock() 
        {
            _Tests.Add(new Test("CheckStatusPage", CustomerStatus.Error, new List<string> { "url" }));
            _Tests.Add(new Test("CheckService", CustomerStatus.Error, new List<string> { "service" }));
        }


        public bool Create(Test test)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Test test)
        {
            throw new NotImplementedException();
        }

        public Test Retrieve(string testType)
        {
            foreach (Test test in _Tests)
            {
                if (test.TestType == testType) return test;
            }
            return null;
        }

        public bool Update(Test test)
        {
            throw new NotImplementedException();
        }
    }
}
