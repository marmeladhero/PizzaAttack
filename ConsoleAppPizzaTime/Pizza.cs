namespace ConsoleAppPizzaTime
{
    using System;
    using System.Threading;

    public class Pizza
    {
        private static int Count;
        private object _locker = new object();

        public Pizza(int iCount)
        {
            Count = iCount;
        }

        public void PieceTake()
        {
            lock (_locker)
            {
                if (Count > 0)
                {
                    Interlocked.Decrement(ref Count);
                    Console.WriteLine($"Pizza count:{Count}");
                }
                else
                {
                    throw new Exception();
                }
            }
        }
    }
}
