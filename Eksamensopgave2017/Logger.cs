using System;

namespace Eksamensopgave2017
{
    public static class Logger
    {
        public static Action<string> WriteMessage;

        public static void LogMessage(string msg)
        {
            WriteMessage(msg);
        }
    }
}