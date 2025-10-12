

namespace CookiesCookbookCSharpAssignment.DataAccess.FileAccess
{
    public class FileMetaData
    {
        public string Name { get; }
        public FileFormat FileFormat { get; }

        public FileMetaData(string name, FileFormat fileFormat)
        {
            Name = name;
            FileFormat = fileFormat;
        }

        public string ToPath() => $"{Name}.{FileFormat.AsFileExtension()}";
    }

}
