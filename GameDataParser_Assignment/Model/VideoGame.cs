

namespace GameDataParser_Assignment.Model
{
    public class VideoGame
    {
        public string Title { set; get; }
        public int ReleaseYear { set; get; }
        public double Rating { set; get; }

        public override string ToString() => $"{Title} ===> relased In {ReleaseYear}, rating: {Rating} ";
    };

}
