namespace BLL.Customers
{
    public class Server()
    {
        private string _GUID;
        public string GUID
        {
            get { return _GUID; }
            set { if (value.Length > 0) { _GUID = value; } }
        }

        private string _Hostname;
        public string Hostname
        {
            get { return _Hostname; }
            set { if (value.Length > 0) { _Hostname = value; } }
        }

        private string _IP;
        public string IP
        {
            get { return _IP; }
            set { if (value.Length > 0) { _IP = value; } }
        }

        private DateTime? _HeartBeat;
        public DateTime? HeartBeat
        {
            get { return _HeartBeat; }
            set { if (_HeartBeat == null || value > _HeartBeat) _HeartBeat = value; }
        }
    }
}
