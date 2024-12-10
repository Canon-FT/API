namespace FTAPI.Models
{
    public class Agent { 

        public int Version { get; private set; }

        public string GUID { get; private set; }

        public DateTime InstalledAt { get; private set; }

        public DateTime HeartBeat { get; private set; }

        public string Configuration { get; private set; }

        public AgentStatus Status { get; private set; }

        public Agent() { }
    }
}
