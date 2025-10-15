namespace GameDataParser_Assignment.UserInteraction
{
    public interface IUserInteractor
    {
        string ReadValidFilePath();
        void PrintMessage(string message);
        void PrintErrorMessage(string message);
    }



}
