

namespace CookiesCookbookCSharpAssignment.DataAccess.FileAccess
{
    public static class FileFormatExtensions
    {
        public static string AsFileExtension(this FileFormat fileFormat) => fileFormat == FileFormat.json ? "json" : "txt";
    }

}
