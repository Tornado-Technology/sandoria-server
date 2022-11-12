namespace Program.Utilites
{
    public static class Logger
    {
        private static readonly Dictionary<LogLevel, LogLevelData> _logeLeveldatas = new Dictionary<LogLevel, LogLevelData>()
        {
            { LogLevel.Fatal, new LogLevelData(ConsoleColor.DarkRed, "Fatal") },
            { LogLevel.Error, new LogLevelData(ConsoleColor.Red, "Error") },
            { LogLevel.Warning, new LogLevelData(ConsoleColor.Yellow, "Warning") },
            { LogLevel.Alert, new LogLevelData(ConsoleColor.Yellow, "Alert") },
            { LogLevel.Info, new LogLevelData(ConsoleColor.White, "Info") },
            { LogLevel.Debug, new LogLevelData(ConsoleColor.Gray, "Debug") },
        };

        private static void Log(LogLevel level, string message)
        {
            LogLevelData levelData = _logeLeveldatas[level];
            Console.ForegroundColor = levelData.Color;
            Console.WriteLine($"[{DateTime.Now}][{levelData.Prefix}] {message}");
        }

        public static void Fatal(string message)
        {
            Log(LogLevel.Fatal, message);
        }

        public static void Error(string message)
        {
            Log(LogLevel.Error, message);
        }

        public static void Wraning(string message)
        {
            Log(LogLevel.Warning, message);
        }

        public static void Alert(string message)
        {
            Log(LogLevel.Alert, message);
        }

        public static void Info(string message)
        {
            Log(LogLevel.Info, message);
        }

        public static void Debug(string message)
        {
            Log(LogLevel.Debug, message);
        }

        private struct LogLevelData
        {
            public ConsoleColor Color = ConsoleColor.White;
            public string Prefix = "Log";

            public LogLevelData(ConsoleColor color, string prefix)
            {
                Color = color;
                Prefix = prefix;
            }
        }

        public enum LogLevel : byte
        {
            Fatal,
            Error,
            Warning,
            Alert,
            Info,
            Debug,
        }
    }
}
