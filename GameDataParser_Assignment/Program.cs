using GameDataParser_Assignment.App;
using GameDataParser_Assignment.DataAccess;
using GameDataParser_Assignment.logging;
using GameDataParser_Assignment.UserInteraction;

Console.WriteLine("Files Names:\n 1- games.json \n 2- gamesInvalidFormat.json ");

var userInteractor = new ConsoleUserInteractor();
var app = new GameDataParserApp(
    userInteractor,
    new GamesPrinter(userInteractor),
    new VideoGamesDeserialize(userInteractor),
    new LocalFileReader()
    );
var logger = new Logger("log.txt");

try
{
    app.Run();
}
catch( Exception ex)
{
    Console.WriteLine("Sorry! the application has experienced an unexpected error " + 
        "and will have to Closed");
    logger.Log(ex);
}


Console.ReadKey();





