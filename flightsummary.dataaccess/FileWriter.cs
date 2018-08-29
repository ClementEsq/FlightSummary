using FlightSummary.Data.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FlightSummary.Data
{
    public class FileWriter : IFileWriter
    {
        public async Task WriteToFileAsync(string filePath, string value)
        {
            using (var file = new StreamWriter(filePath))
            {
                await file.WriteAsync(value);
            }
        }
    }
}
