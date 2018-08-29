using FlightSummary.Data;
using FlightSummary.Data.Interfaces;
using FlightSummary.Service.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FlightSummary
{
    public class ApplicationFactory
    {
        private IServiceProvider _services;

        public ApplicationFactory(IServiceProvider services)
        {
            _services = services;
        }

        public IFileReader GetFileReader()
        {
            var fileReader = _services.GetRequiredService<IFileReader>();

            return fileReader;
        }

        public IFileWriter GetFileWriter()
        {
            var fileWriter = _services.GetRequiredService<IFileWriter>();

            return fileWriter;
        }

        public IRouteService GetRouteService()
        {
            var routeService = _services.GetRequiredService<IRouteService>();

            return routeService;
        }

        public IAircraftService GetAircraftService()
        {
            var aircraftService = _services.GetRequiredService<IAircraftService>();

            return aircraftService;
        }

        public IPassengerService GetPassengerService()
        {
            var passengerService = _services.GetRequiredService<IPassengerService>();

            return passengerService;
        }

        public IFlightSummaryService GetFlightSummaryService()
        {
            var flightSummaryService = _services.GetRequiredService<IFlightSummaryService>();

            return flightSummaryService;
        }
    }
}
