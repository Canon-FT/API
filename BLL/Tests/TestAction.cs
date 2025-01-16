using BLL.Agents;
using BLL.Customers;

namespace BLL.Tests
{
    public class TestAction
    {
        private string? _GUID = null;

        public string? GUID { get { return _GUID; } set { if (_GUID == null) { _GUID = value; } } }

        private Test _Test;

        public string TestType { get { return _Test.TestType; } }

        public int Frequency { get; private set; } // in minutes

        private Dictionary<string, string> _Parameters = new Dictionary<string, string>();

        public IReadOnlyDictionary<string, string> Parameters { get { return _Parameters.AsReadOnly(); } }

        private TestAction? _DependsOn;

        public string? DependsOn { get { return ((_DependsOn != null) ? _DependsOn.GUID : null); } }

        public TestAction(Test test, int frequency, Dictionary<string, string> parameters, string? guid = null, TestAction? dependsOn = null)
        {
            _Test = test;
            Frequency = frequency;
            _DependsOn = dependsOn;
            _GUID = guid;

            foreach(string key in _Test.Parameters)
            {
                _Parameters[key] = (parameters.ContainsKey(key)) ? parameters[key] : "";
            }
        }
    }
}
