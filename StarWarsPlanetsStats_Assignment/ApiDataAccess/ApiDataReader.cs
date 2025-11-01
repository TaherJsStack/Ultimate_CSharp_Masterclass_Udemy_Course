namespace StarWarsPlanetsStats_Assignment.ApiDataAccess
{
    public class ApiDataReader : IApiDataReader
    {
        public async Task<string> Read(string baseAddress, string requestUri)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            HttpResponseMessage response = await client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            //Console.WriteLine("Response Content:");
            //Console.WriteLine(content);
            //return content;

            return await response.Content.ReadAsStringAsync();
        }
    }
}
