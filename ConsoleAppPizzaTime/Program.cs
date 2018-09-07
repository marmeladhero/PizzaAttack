namespace ConsoleAppPizzaTime
{
    using System;

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

                Console.WriteLine("Out of pizza. Press any Key and wait for program will close");
                Console.ReadKey();
                break;

            } while (true);

            return;
        }
    }
}
