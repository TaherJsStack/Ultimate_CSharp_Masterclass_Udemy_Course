
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig;
using UglyToad.PdfPig.DocumentLayoutAnalysis;
using System.Globalization;
using System.Text;

const string TicketsFolder = @"Tickets";

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
        var stringBuilder = new StringBuilder();

        foreach (var filePath in Directory.GetFiles(_ticketsFolder+"\\", @"*.pdf")) {
            
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

                var culture = new CultureInfo(ticketCulture);

                var date = DateOnly.Parse(dateAsStriong, culture);
                var time = TimeOnly.Parse(timeAsStriong, culture);

                var dateAsStringInvariant = date.ToString(CultureInfo.InvariantCulture);
                var timeAsStringInvariant = time.ToString(CultureInfo.InvariantCulture);

                var tickeData = $"{title, -40} | {dateAsStringInvariant}|{timeAsStringInvariant} \n";

                stringBuilder.Append(tickeData);
            }
        }

        var resultpath = Path.Combine(_ticketsFolder, "aggregatedTickets.txt");
        File.WriteAllText(resultpath, stringBuilder.ToString());
        Console.WriteLine("Results Saved To: " + _ticketsFolder + " Folder" + "\nIn:" + resultpath);

    }

    private static string ExtractDomain(string webAddress)
    {
        var lastDotIndex = webAddress.LastIndexOf(".");
        return webAddress.Substring(lastDotIndex);
    }
}





