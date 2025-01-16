using BLL.Agents;
using System.Text.Json.Serialization;

namespace BLL.Tests.Results
{
    public class Result
    {
        private Test? _Test = null;
        private string _TestType = "";
        public string TestType
        {
            get { return (_Test != null) ? _Test.TestType : _TestType; }
            set { if (_Test == null) _TestType = value; }
        }

        public DateTime Timestamp { get; set; }

        public bool Succes { get; set; }

        private Agent? _ReportedBy = null;
        private string _Reporter = "";
        public string Reporter
        {
            get { return (_ReportedBy != null) ? _ReportedBy.GUID : _Reporter; }
            set { if (_ReportedBy == null) _Reporter = value; }
        }

        public Result(Test test, DateTime timestamp, bool success, Agent reportedBy)
        {
            _Test = test;
            Timestamp = timestamp;
            Succes = success;
            _ReportedBy = reportedBy;
        }

        [JsonConstructor]
        public Result() {}

    }
}
