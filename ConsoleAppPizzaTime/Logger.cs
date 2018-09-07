namespace ConsoleAppPizzaTime
{
    using System;
    using System.IO;
    
    public class Logger
    {
        public static object locker = new object();

        public static void Log(string strText)
        {
            lock (locker)
            {
                using (StreamWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + '\\' + DateTime.Now.ToString("yyyy.MM.dd") + ".txt", true))
                {
                    writer.Write(strText + Environment.NewLine);
                }
            }
        }
    }
}
