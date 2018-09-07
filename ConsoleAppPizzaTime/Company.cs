using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppPizzaTime
{
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
                Thread.Sleep(1);
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
            catch (MyException)
            {
                //
                EventWaiter.Set();
            }
        }


        public void BeginParty(Pizza pizza)
        {
            Pizza = pizza;

            while (_StarterCount < _ThreadCount) Thread.Sleep(10);

            EventStarter.Set();
        }       
    }
}
