
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig;

const string TicketsFolder = @"Tickets\";

try
{
	var ticketsAggregator = new TicketsAggregator(TicketsFolder);
	ticketsAggregator.Run();
}
catch (Exception ex)
{

    Console.WriteLine("" + ex.Message);
}

Console.ReadKey();

public class TicketsAggregator
{
	private readonly string _ticketsFolder;

    public TicketsAggregator(string ticketsFolder)
    {
        _ticketsFolder = ticketsFolder;
    }

    public void Run()
    {

        foreach (var filePath in Directory.GetFiles(_ticketsFolder, @"*.pdf")) {
            
            Console.WriteLine($"{filePath}");
            
            using PdfDocument document = PdfDocument.Open(filePath);
            // Page number starts from 1, not 0.
            Page page = document.GetPage(1);
            string text = page.Text;

            var split = text.Split(
                new[] {"Title:", "Date:", "Time:", "Visit us:" }, 
                StringSplitOptions.None
                );

            for (int i = 1; i < split.Length -3; i += 3)
            {
                var title = split[i];
                var date = split[i + 1];
                var time = split[i + 2];
            }


        }

    }
}





