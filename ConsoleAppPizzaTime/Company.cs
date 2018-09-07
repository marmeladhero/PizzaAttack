namespace ConsoleAppPizzaTime
{
    using System;
    using System.Threading;

    public class Company
    {
        private Pizza Pizza { set; get; }
        public ManualResetEvent EventWaiter = new ManualResetEvent(false);
        private ManualResetEvent EventStarter = new ManualResetEvent(false);
        
        private volatile int _StarterCount = 0;
        private volatile int _ThreadCount = 0;

        public Company(int workersCount)
        {
            Console.Clear();
            Console.WriteLine("Waiting all peoples...");

            for (int i = 0; i < workersCount; i++) {                               
                new Thread(TakePieceOfPizze).Start(new People($"Worker #{i + 1}"));
                Thread.Sleep(10);
                _ThreadCount++;
            }
        }

        private void RunThreads(object thread)
        {
            EventStarter.WaitOne();
            (thread as Thread).Start();
        }

        private void TakePieceOfPizze(object people)
        {
            try
            {                
                _StarterCount++;               
                EventStarter.WaitOne();

                while (true)
                {
                    People worker = people as People;
                    worker.TakePiece(Pizza);
                }
            }
            catch (Exception)
            {
                EventWaiter.Set(); // Сообщить в main о том что поток завершил роботу
            }
        }


        public void BeginParty(Pizza pizza)
        {
            Pizza = pizza;

            while (_StarterCount < _ThreadCount) Thread.Sleep(100);

            EventStarter.Set();
        }       
    }
}
