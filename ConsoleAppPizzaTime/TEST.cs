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
        private Dictionary<Thread, People> LstWorkers { set; get; } = new Dictionary<Thread, People>();
        private Pizza Pizza { set; get; }
 
        public Company(int workersCount, Pizza pizza)
        {            
            Pizza = pizza;
            for (int i = 0; i < workersCount; i++)
            {
                LstWorkers.Add(new Thread(TakePieceOfPizze), new People($"Worker #{i + 1}"));
            }
        }

        private void TakePieceOfPizze(object people)
        {
            try
            {
                while (true)
                {
                    People worker = people as People;
                    worker.TakePiece(Pizza);
                }
            }
            catch (MyException)
            {          
            }
        }


        public void BeginParty()
        {
            foreach(var worker in LstWorkers)
            {
                worker.Key.Start(worker.Value);                
            }
        }       
    }
}
