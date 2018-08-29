using FlightSummary.Service.Interface;

namespace FlightSummary.Service
{
    public class FlightValidationService : IFlightValidationService
    {
        private readonly ICashFlowCalculationService _cashFlowCalculationService;
        private readonly IAircraftService _aircraftService;
        private readonly IPassengerService _passengerService;

        public FlightValidationService(ICashFlowCalculationService cashFlowCalculationService, IAircraftService aircraftService, IPassengerService passengerService)
        {
            _cashFlowCalculationService = cashFlowCalculationService;
            _aircraftService = aircraftService;
            _passengerService = passengerService;
        }

        public bool IsAdjustedRevenueWithinCostOfFlight()
        {
            var totalRevenueFromPayingCustomers = _cashFlowCalculationService.CalculateTotalRevenueFromPayingCustomers();
            var costOfFlightToAirline = _cashFlowCalculationService.CalculateTotalCostOfFlightToAirline();

            var discountedAmount = _cashFlowCalculationService.CalculateDiscountedAmountForPassengersOnFlight();
            var adjustedRevenue = totalRevenueFromPayingCustomers - discountedAmount;

            return adjustedRevenue > costOfFlightToAirline;
        }


        public bool IsPassengerCountOnAircraftAboveMaxSeats()
        {
            return _passengerService.GetNumberOfPassengers() <= _aircraftService.GetNumberOfSeatsOnPlane();
        }
    }
}
