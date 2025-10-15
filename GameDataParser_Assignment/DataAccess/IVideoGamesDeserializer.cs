using GameDataParser_Assignment.Model;

namespace GameDataParser_Assignment.DataAccess
{
    public interface IVideoGamesDeserializer
    {
        List<VideoGame> DeserializeFrom(string fileName, string fileContent);
    }


}
