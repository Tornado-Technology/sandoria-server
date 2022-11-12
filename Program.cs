namespace Program
{
    public sealed class Program
    {
        private const string DEFAULT_IP = "127.0.0.1";
        private const int DEFAULT_PORT = 7070;

        public static void Main(string[] arguments)
        {
            // TODO: Load it's from .config file
            Server server = new Server(DEFAULT_IP, DEFAULT_PORT);
            server.Start();
        }
    }
}