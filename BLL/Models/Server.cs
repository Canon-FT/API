namespace FTAPI.Models
{
    public class Server
    {
        public string Hostname { get; private set; }

        public string IP { get; private set; }

        public DateTime HeartBeat { get; private set; }

        public string GUID { get; private set; }

        public  Server()
        {

        }

    }
}
