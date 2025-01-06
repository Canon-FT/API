using BLL.Customers;
using BLL.Tests;

namespace BLL.Agents
{
    public class Agent(string guid, Server server)
    {
        public string GUID = guid;

        public Server InstallationServer = server;

        private string Version;

        public List<TestAction> Configuration = new List<TestAction>();

        private DateTime? _InstallationDate;
        public DateTime? InstallationDate
        {
            get { return _InstallationDate; }
            set { _InstallationDate = (value < DateTime.Now) ? value : DateTime.Now; }
        }

        private DateTime? _HeartBeat;
        public DateTime? HeartBeat
        {
            get { return _HeartBeat; }
            set { if (_HeartBeat == null || value > _HeartBeat) { _HeartBeat = value; } }
        }

        public AgentStatus Status 
        { 
            get 
            { 
                if(HeartBeat == null) { return AgentStatus.Unknown; }
                else if(((DateTime)HeartBeat).AddMinutes(30f) < DateTime.Now) { return AgentStatus.Offline; }
                else { return AgentStatus.Online; }
            }
        }
    }
}
