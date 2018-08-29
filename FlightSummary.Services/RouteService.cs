using FlightSummary.DataAccess;
using FlightSummary.Models;
using FlightSummary.Service.Interface;
using System;

namespace FlightSummary.Service
{
    public class RouteService : FlightServiceBase<Route>, IRouteService
    {
        private readonly IRepository<Route> _routeRepository;

        public RouteService(IRepository<Route> routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public decimal GetCostOfFlightToAirline()
        {
            return _routeRepository.Get().CostToAirlinePerPassenger;
        }

        public void Load(string input)
        {
            var lines = input.Split(Environment.NewLine);
            for (var i = 0; i < lines.Length; ++i)
            {
                var route = ConvertLineFromFile(lines[i]);
                if(route != null)
                {
                    _routeRepository.Set(route);
                    break;
                }
            }
        }

        protected override Route ConvertLineFromFile(string line)
        {
            var values = line.Split(' ');
            Route result;
            try
            {
                result = values[0].ToUpper().Equals("ADD") && values[1].ToUpper().Equals("ROUTE") ?
                   new Route()
                   {
                       Origin = values[2],
                       Destination = values[3],
                       CostToAirlinePerPassenger = decimal.Parse(values[4]),
                       TicketPrice = decimal.Parse(values[5])
                   } : null;
            }
            catch (Exception)
            {
                result = null;
            }

            return result;
        }
    }
}
