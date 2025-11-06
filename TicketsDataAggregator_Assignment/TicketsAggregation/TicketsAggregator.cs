
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig;
using System.Globalization;
using System.Text;

namespace TicketsDataAggregator_Assignment.TicketsAggregation
{
    public class TicketsAggregator
    {
        private readonly string _ticketsFolder;
        private readonly Dictionary<string, CultureInfo> _domainToCultureMapping = new()
        {
            [".com"] = new CultureInfo("en-US"),
            [".fr"] = new CultureInfo("fr-FR"),
            [".jp"] = new CultureInfo("ja-JP")
        };
        public TicketsAggregator(string ticketsFolder)
        {
            _ticketsFolder = ticketsFolder;
        }

        public void Run()
        {
            var stringBuilder = new StringBuilder();

            foreach (var filePath in Directory.GetFiles(_ticketsFolder + "\\", @"*.pdf"))
            {

                Console.WriteLine($"{filePath}");

                using PdfDocument document = PdfDocument.Open(filePath);
                // Page number starts from 1, not 0.
                Page page = document.GetPage(1);
                //ProccessPage(stringBuilder, page);
                var lines = ProccessPage(page);
                stringBuilder.Append(string.Join("\n", lines));

            }
            SaveTicketsData(stringBuilder);
        }

        private IEnumerable<string> ProccessPage(Page page)
        {
            string text = page.Text;
            var split = text.Split(
                new[] { "Title:", "Date:", "Time:", "Visit us:" },
                StringSplitOptions.None
            );

            var domain = ExtractDomain(split.Last());
            var ticketCulture = _domainToCultureMapping[domain];

            for (int i = 1; i < split.Length - 3; i += 3)
            {
                yield return BuildTicketData(split, i, ticketCulture);
            }
        }

        private static string BuildTicketData(string[] split, int i, CultureInfo ticketCulture)
        {
            var title = split[i];
            var dateAsStriong = split[i + 1];
            var timeAsStriong = split[i + 2];

            var date = DateOnly.Parse(dateAsStriong, ticketCulture);
            var time = TimeOnly.Parse(timeAsStriong, ticketCulture);

            var dateAsStringInvariant = date.ToString(CultureInfo.InvariantCulture);
            var timeAsStringInvariant = time.ToString(CultureInfo.InvariantCulture);

            var ticketData = $"{title,-40} | {dateAsStringInvariant}|{timeAsStringInvariant} \n";

            return ticketData;
        }

        private void SaveTicketsData(StringBuilder stringBuilder)
        {
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
}




