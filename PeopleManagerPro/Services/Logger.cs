using System;
using System.IO;

namespace PeopleManagerPro.Services
{
    public static class Logger
    {
        public static void Log(string message)
        {
            using (StreamWriter writer = new StreamWriter("activity.log", true))
            {
                writer.WriteLine($"[{DateTime.Now}] {message}");
            }
        }
    }
}
