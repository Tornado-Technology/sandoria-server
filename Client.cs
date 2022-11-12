using Program.Utilites;
using System.Net.Sockets;
using System.Text;

namespace Program
{
    public class Client
    {
        public const int BUFFER_SIZE = 1024;

        public readonly Guid ID;

        private TcpClient _client;
        private NetworkStream _stream;

        public Client(TcpClient client)
        {
            ID = Guid.NewGuid(); 
            _client = client;
            _stream = client.GetStream();
        }

        public async Task BufferRead()
        {
            while (true)
            {
                byte[] buffer = new byte[BUFFER_SIZE];
                await _stream.ReadAsync(buffer);
                
                if (buffer.Length == 0)
                {
                    continue;
                }

                string content = Encoding.ASCII.GetString(buffer);
                Logger.Info($"Recived from {ID}:\n{content}");
            }
        }
    }
}
    