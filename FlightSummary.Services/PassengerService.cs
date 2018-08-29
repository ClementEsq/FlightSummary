using FlightSummary.DataAccess;
using FlightSummary.Models;
using FlightSummary.Service.Interface;
using System;
using System.Collections.Generic;

namespace FlightSummary.Service
{
    public class PassengerService : FlightServiceBase<Passenger>, IPassengerService
    {
        private readonly IRepository<IList<Passenger>> _passengerRepository;

        public PassengerService(IRepository<IList<Passenger>> passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        public int GetNumberOfAirlinePassengers()
        {
            var passengers = _passengerRepository.Get();
            int count = 0;
            foreach (var passenger in passengers)
            {
                count += passenger.GetType() == typeof(AirlinePassenger) ? 1 : 0;
            }

            return count;
        }

        public int GetNumberOfGeneralPassengers()
        {
            var passengers = _passengerRepository.Get();
            int count = 0;
            foreach (var passenger in passengers)
            {
                count += passenger.GetType() == typeof(GeneralPassenger) ? 1 : 0;
            }

            return count;
        }

        public int GetNumberOfLoyaltyPassengers()
        {
            var passengers = _passengerRepository.Get();
            int count = 0;
            foreach (var passenger in passengers)
            {
                count += passenger.GetType() == typeof(LoyaltyPassenger) ? 1 : 0;
            }

            return count;
        }

        public int GetNumberOfPassengers()
        {
            return _passengerRepository.Get().Count;
        }

        public int GetPassengerBags()
        {
            var passengers = _passengerRepository.Get();
            int count = 0;
            foreach (var passenger in passengers)
            {
                var hasExtraBag = passenger.GetExtraBagUsageStatus() ?? false;
                count += hasExtraBag ? 2 : 1;
            }

            return count;
        }

        public void Load(string input)
        {
            var passengers = new List<Passenger>();
            var lines = input.Split(Environment.NewLine);
            for (var i = 0; i < lines.Length; ++i)
            {
                var passenger = ConvertLineFromFile(lines[i]);
                if (passenger != null)
                {
                    passengers.Add(passenger);
                }
            }

            _passengerRepository.Set(passengers);
        }

        protected override Passenger ConvertLineFromFile(string line)
        {
            var values = line.Split(' ');
            Passenger result;
            try
            {
                result = GetPassengerType(values);

                if (result != null)
                {
                    result.PassengerName = values[3];
                }
            }
            catch (Exception)
            {
                result = null;
            }

            return result;
        }

        private Passenger GetPassengerType(string[] values)
        {
            Passenger result = null;

            if (values[0].ToUpper().Equals("ADD") && values[1].ToUpper().Equals("PASSENGER"))
            {
                result = values[2].ToUpper().Equals("GENERAL") ? new GeneralPassenger() : result;

                result = values[2].ToUpper().Equals("AIRLINE") ? new AirlinePassenger() : result;

                result = result == null && values[2].ToUpper().Equals("LOYALTY") ?
                   new LoyaltyPassenger(int.Parse(values[4]), bool.Parse(values[5].ToLower()), bool.Parse(values[6].ToLower())) : result;
            }

            return result;
        }
    }
}
