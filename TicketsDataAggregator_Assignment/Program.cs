
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig;
using UglyToad.PdfPig.DocumentLayoutAnalysis;
using System.Globalization;

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
    private readonly Dictionary<string, string> _domainToCultureMapping = new()
    {
        [".com"] = "en-US",
        [".fr"] = "fr-FR",
        [".jp"] = "ja-JP",

    };
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

            var domain = ExtractDomain(split.Last());
            var ticketCulture = _domainToCultureMapping[domain];

            for (int i = 1; i < split.Length -3; i += 3)
            {
                var title = split[i];
                var dateAsStriong = split[i + 1];
                var timeAsStriong = split[i + 2];
            
                var date = DateOnly.Parse(dateAsStriong, new CultureInfo(ticketCulture));
                var time = TimeOnly.Parse(dateAsStriong, new CultureInfo(timeAsStriong));

            }


        }

    }

    private static string ExtractDomain(string webAddress)
    {
        var lastDotIndex = webAddress.LastIndexOf(".");
        return webAddress.Substring(lastDotIndex);
    }
}





