using System.Diagnostics;

namespace _Root.CleanCode.Shared.Ports
{
    public static class Dbg
    {
        [Conditional("DEBUG")]
        public static void Log(object msg) => System.Console.WriteLine(msg);

        [Conditional("DEBUG")]
        public static void Warn(object msg) => System.Console.WriteLine("[WARN] " + msg);

        [Conditional("DEBUG")]
        public static void Error(object msg) => System.Console.WriteLine("[ERROR] " + msg);
    }
}