using FlightSummary.Extentions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FlightSummary
{
    public static class Program
    {
        private static string _inputPath;
        private static string _outputFolder;

        public static async Task Main(string[] args)
        {
            Initialise();

            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.RegisterMyServices();
            var servicesProvider = serviceCollection.BuildServiceProvider();

            var applicationFactory = new ApplicationFactory(servicesProvider);

            var fr = applicationFactory.GetFileReader();
            var rs = applicationFactory.GetRouteService();
            var asrv = applicationFactory.GetAircraftService();
            var ps = applicationFactory.GetPassengerService();
            var fss = applicationFactory.GetFlightSummaryService();
            var fw = applicationFactory.GetFileWriter();
            var files = Directory.GetFiles(_inputPath);

            for (var i = 0; i < files.Length; ++i)
            {
                try
                {
                    var currentInput = fr.ReadFromFile(files[i]);

                    rs.Load(currentInput);
                    asrv.Load(currentInput);
                    ps.Load(currentInput);

                    var flightSummary = fss.CreateFlightSummary();
                    var output = ConvertFlightSummaryToJsonObject(flightSummary);
                    var fileName = $@"output_{i}.txt";
                    var fullOutputFilePath = Path.Combine(_outputFolder, fileName);

                    await fw.WriteToFileAsync(fullOutputFilePath, output);

                    Console.WriteLine($"{Environment.NewLine}INPUT:");
                    Console.WriteLine(currentInput);
                    Console.WriteLine($"{Environment.NewLine}OUTPUT:");
                    Console.WriteLine(output);
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error occured at [index {i} - file{files[i]}]: {ex.Message}");
                }
            }

            Console.WriteLine($"Go to [{_outputFolder}] for output files");
            Console.ReadKey();
        }

        private static void Initialise()
        {
            var envSep = Path.DirectorySeparatorChar;

            _inputPath = $@"{Environment.CurrentDirectory}{Path.DirectorySeparatorChar}input_files";
            _outputFolder = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}{envSep}FlightSummary{envSep}Output{envSep}";
            Directory.CreateDirectory(_outputFolder);
        }

        private static string ConvertFlightSummaryToJsonObject(Models.FlightSummary flightSummary)
        {
            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var setting = new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(flightSummary, setting);
        }
    }
}
