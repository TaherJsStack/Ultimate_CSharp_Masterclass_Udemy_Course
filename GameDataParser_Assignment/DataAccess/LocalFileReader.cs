namespace GameDataParser_Assignment.DataAccess
{
    public class LocalFileReader : IFileReader
    {
        public string Read(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }


}
