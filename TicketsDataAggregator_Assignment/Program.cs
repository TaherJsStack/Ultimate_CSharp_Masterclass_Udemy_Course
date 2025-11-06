
using TicketsDataAggregator_Assignment.TicketsAggregation;

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





