using Program.Utilites;
using System.Net;
using System.Net.Sockets;

namespace Program
{
    public sealed class Server
    {
        private string _ip;
        private int _port;
        private IPEndPoint _ipPoint;
        private TcpListener _listener;
        private List<Client> _clients = new List<Client>();

        public Server(string ip, int port)
        {
            _ip = ip;
            _port = port;
            _ipPoint = new IPEndPoint(IPAddress.Any, _port);
            _listener = new TcpListener(_ipPoint);
        }

        public void Start()
        {
            Logger.Info($"Server starting...");
            
            _listener.Start();

            Logger.Info($"Server listening {_ip}:{_port}.");
          
            while (true)
            {
                _listener.BeginAcceptTcpClient(Accept, null);
            }
        }

        private async void Accept(IAsyncResult result)
        {
            Client client = RegisterClient(_listener.EndAcceptTcpClient(result));
            await client.BufferRead();
        }

        private Client RegisterClient(TcpClient TCPClient)
        {
            Client client = new Client(TCPClient);
            _clients.Add(client);
            Logger.Info($"Client connected: {client.ID}");
            return client;
        }
    }
}
