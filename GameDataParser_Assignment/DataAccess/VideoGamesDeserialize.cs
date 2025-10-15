
using GameDataParser_Assignment.Model;
using GameDataParser_Assignment.UserInteraction;
using System.Text.Json;

namespace GameDataParser_Assignment.DataAccess
{
    public class VideoGamesDeserialize : IVideoGamesDeserializer
    {
        private readonly IUserInteractor _userInteractor;

        public VideoGamesDeserialize(IUserInteractor userInteractor)
        {
            _userInteractor = userInteractor;
        }

        public List<VideoGame> DeserializeFrom(string fileName, string fileContent)
        {
            try
            {
                return JsonSerializer.Deserialize<List<VideoGame>>(fileContent);
            }
            catch (JsonException ex)
            {
                _userInteractor.PrintErrorMessage($"json in {fileName} was not " + $"in a valid format. json body: ");
                _userInteractor.PrintErrorMessage(fileContent);
                throw new JsonException($" {ex.Message} the file is: {fileName} ", ex);
            };
        }
    }


}
