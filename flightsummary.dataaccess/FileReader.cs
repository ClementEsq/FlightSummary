using System.IO;

namespace FlightSummary.Data
{
    public class FileReader : IFileReader
    {
        public string ReadFromFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
