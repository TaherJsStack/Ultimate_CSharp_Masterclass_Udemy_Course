namespace StarWarsPlanetsStats_Assignment.UserInteractions
{
    public class ConsoleUserInteractor : IUserInteractor
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
        public string? ReadFromuser()
        {
            return Console.ReadLine();
        }
    }
}