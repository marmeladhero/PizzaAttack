namespace ConsoleAppPizzaTime
{
    public class People
    {
        public string WorkerName { get; }
        private int _PizzasCount = 0;

        public People(string name)
        {
            WorkerName = name;
        }

        public void TakePiece(Pizza pizza)
        {
            pizza.PieceTake();
            _PizzasCount++;
            Logger.Log($"{WorkerName}-> Sum {_PizzasCount}");
        }
    }
}
