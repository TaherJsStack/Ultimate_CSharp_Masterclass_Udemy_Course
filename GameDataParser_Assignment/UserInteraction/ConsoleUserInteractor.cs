namespace GameDataParser_Assignment.UserInteraction
{
    public class ConsoleUserInteractor : IUserInteractor
    {
        public void PrintErrorMessage(string message)
        {
            var oraginForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = oraginForegroundColor;
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string ReadValidFilePath()
        {
            bool isFilePathValid = false;
            string fileName = default;
            do
            {
                Console.WriteLine("Enter File Name that you want to read: ");
                fileName = Console.ReadLine();

                if (fileName is null)
                {
                    Console.WriteLine("the file name cannot be null");
                }
                else if (fileName == string.Empty)
                {
                    Console.WriteLine("the file name cannot be empty. ");
                }
                else if (!File.Exists(fileName))
                {
                    Console.WriteLine("the file name does not exist. ");
                }
                else
                {
                    isFilePathValid = true;
                }

            } while (!isFilePathValid);
            return fileName;
        }
    }

}
