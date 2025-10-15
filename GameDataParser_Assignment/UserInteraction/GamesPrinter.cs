

using GameDataParser_Assignment.Model;

namespace GameDataParser_Assignment.UserInteraction
{
    public class GamesPrinter : IGamesPrinter
    {
        private IUserInteractor _userInteractor;

        public GamesPrinter(IUserInteractor userInteractor)
        {
            _userInteractor = userInteractor;
        }

        public void Print(List<VideoGame> videoGames)
        {
            if (videoGames.Count > 0)
            {
                _userInteractor.PrintMessage("");
                _userInteractor.PrintMessage("Loaded games Are: ");
                foreach (var videoGame in videoGames)
                {
                    _userInteractor.PrintMessage(videoGame.ToString());
                }
            }
            else
            {
                _userInteractor.PrintMessage("No Games are present in the input file.");
            }
        }
    }



}
