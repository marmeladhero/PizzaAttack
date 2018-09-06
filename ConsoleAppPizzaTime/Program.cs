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
            Company company = new Company(4, new Pizza(30));
            company.BeginParty();

            Console.WriteLine("Out of pizza");
            Console.ReadKey();
        }
    }
}
