using System.Threading.Tasks;

namespace FlightSummary.Data.Interfaces
{
    public interface IFileWriter
    {
        Task WriteToFileAsync(string filePath, string value);
    }
}
