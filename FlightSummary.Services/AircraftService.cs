using FlightSummary.DataAccess;
using FlightSummary.Models;
using FlightSummary.Service.Interface;
using System;

namespace FlightSummary.Service
{
    public class AircraftService : FlightServiceBase<Aircraft>, IAircraftService
    {
        private readonly IRepository<Aircraft> _aircraftRepository;

        public AircraftService(IRepository<Aircraft> aircraftRepository)
        {
            _aircraftRepository = aircraftRepository;
        }

        public int GetNumberOfSeatsOnPlane()
        {
            return _aircraftRepository.Get().TotalSeats;
        }

        public void Load(string input)
        {
            var lines = input.Split(Environment.NewLine);
            for (var i = 0; i < lines.Length; ++i)
            {
                var aircraft = ConvertLineFromFile(lines[i]);
                if (aircraft != null)
                {
                    _aircraftRepository.Set(aircraft);
                    break;
                }
            }
        }

        protected override Aircraft ConvertLineFromFile(string line)
        {
            var values = line.Split(' ');
            Aircraft result;
            try
            {
                result = values[0].ToUpper().Equals("ADD") && values[1].ToUpper().Equals("AIRCRAFT") ?
                   new Aircraft()
                   {
                       AircraftModel = values[2],
                       TotalSeats = int.Parse(values[3])
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
