
using SRP_APP;
using SRP_APP.DataAccess;

var names = new Names();
var path = new NamesFilePathBuilder().BuildFilePath();

var stringsTextualrRepository = new StringsTextualrRepository();

if (File.Exists(path))
{
    Console.WriteLine("Names file already exists. Loading names.");
    var stringsFromFile = stringsTextualrRepository.Read(path);
    names.AddNames(stringsFromFile);
}
else
{
    Console.WriteLine("Names file does not yet exist.");

    //let's imagine they are given by the user
    names.AddName("Taher");
    names.AddName("John");
    names.AddName("not a valid name");
    names.AddName("Claire");
    names.AddName("123 definitely not a valid name");

    Console.WriteLine("Saving names to the file.");
    stringsTextualrRepository.Write(path, names.NamesList);
}
Console.WriteLine(new NamesFormattor().Format(names.NamesList));

Console.ReadLine();










