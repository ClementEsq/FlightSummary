using FlightSummary.DataAccess;
using FlightSummary.Models;
using FlightSummary.Service.Interface;
using System.Collections.Generic;

namespace FlightSummary.Service
{
    public class CashFlowCalculationService : ICashFlowCalculationService
    {
        private readonly IRepository<Route> _routeRepository;
        private readonly IRepository<IList<Passenger>> _passengerRepository;
        private readonly IRepository<Aircraft> _aircraftRepository;

        public CashFlowCalculationService(IRepository<Route> routeRepository, IRepository<IList<Passenger>> passengerRepository, IRepository<Aircraft> aircraftRepository)
        {
            _routeRepository = routeRepository;
            _passengerRepository = passengerRepository;
            _aircraftRepository = aircraftRepository;
        }

        public decimal CalculateDiscountedAmountForPassengersOnFlight()
        {
            var passengers = _passengerRepository.Get();
            decimal discountedAmount = 0;

            foreach (var passenger in passengers)
            {
                var pointsUsageStatus = passenger.GetLoyaltyPointUsageStatus();
                var isUsingLoyaltyPoint = pointsUsageStatus ?? false;

                discountedAmount += isUsingLoyaltyPoint ? passenger.GetLoyaltyPoints() : 0;

            }

            return discountedAmount;
        }

        public decimal CalculateTotalRevenue()
        {
            var route = _routeRepository.Get();
            var passengers = _passengerRepository.Get();
            var pricePerTicket = route.TicketPrice;
            decimal totalRevenue = 0;

            foreach (var passenger in passengers)
            {
                totalRevenue += pricePerTicket;
            }

            return totalRevenue;
        }

        public decimal CalculateTotalCostOfFlightToAirline()
        {
            var route = _routeRepository.Get();
            var passengers = _passengerRepository.Get();
            var cost = route?.CostToAirlinePerPassenger * passengers?.Count;

            return cost ?? 0;
        }

        public decimal CalculateTotalRevenueFromPayingCustomers()
        {
            var route = _routeRepository.Get();
            var passengers = _passengerRepository.Get();
            var pricePerTicket = route.TicketPrice;
            decimal totalRevenueFromPayingCustomers = 0;

            foreach (var passenger in passengers)
            {
                var isPaying = passenger.IsPayingPassenger;

                totalRevenueFromPayingCustomers += isPaying ? pricePerTicket : 0;
            }

            return totalRevenueFromPayingCustomers;
        }
    }
}
