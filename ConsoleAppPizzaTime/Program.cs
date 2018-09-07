using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppPizzaTime
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.Write("Enter num of employees: ");
                if (!int.TryParse(Console.ReadLine(), out int iCount))
                    continue;
                Console.Write("Enter count of pizza pieces: ");
                if (!int.TryParse(Console.ReadLine(), out int iPizzaCount))
                    continue;                
                Company company = new Company(iCount);
                company.BeginParty(new Pizza(iPizzaCount));                
                
                while (iCount != 0)
                {
                    company.EventWaiter.WaitOne();
                    iCount--;
                }

                Console.WriteLine("Out of pizza. Press any Key");
                Console.ReadKey();
                break;

            } while (true);

            return;
        }
    }
}
