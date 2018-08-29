using FlightSummary.Data;
using FlightSummary.Data.Interfaces;
using FlightSummary.DataAccess;
using FlightSummary.Models;
using FlightSummary.Service;
using FlightSummary.Service.Interface;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace FlightSummary.Extentions
{
    public static class ServiceExtentions
    {
        public static IServiceCollection RegisterMyServices(this IServiceCollection serviceCollection)
        {
            ConfigureRepositories(serviceCollection);
            ConfigureHelpers(serviceCollection);
            ConfigureFlightServices(serviceCollection);
            return serviceCollection;
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            ConfigureRepositories(serviceCollection);
            ConfigureHelpers(serviceCollection);
            ConfigureFlightServices(serviceCollection);
        }

        private static void ConfigureRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IRepository<Aircraft>, AircraftRepository>();
            serviceCollection.AddSingleton<IRepository<Route>, RouteRepository>();
            serviceCollection.AddSingleton<IRepository<IList<Passenger>>, PassengerRepository>();
        }

        private static void ConfigureHelpers(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IFileReader, FileReader>();
            serviceCollection.AddScoped<IFileWriter, FileWriter>();
        }

        private static void ConfigureFlightServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAircraftService, AircraftService>();
            serviceCollection.AddTransient<ICashFlowCalculationService, CashFlowCalculationService>();
            serviceCollection.AddTransient<IFlightSummaryService, FlightSummaryService>();
            serviceCollection.AddTransient<IFlightValidationService, FlightValidationService>();
            serviceCollection.AddTransient<IPassengerService, PassengerService>();
            serviceCollection.AddTransient<IRouteService, RouteService>();

        }
    }
}
