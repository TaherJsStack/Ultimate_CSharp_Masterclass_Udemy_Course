namespace StarWarsPlanetsStats_Assignment.UserInteractions
{
    public interface IUserInteractor
    {
        void ShowMessage(string message);
        string? ReadFromuser();
    }
}