using FlightSummary.Service.Interface;

namespace FlightSummary.Service
{
    public class FlightSummaryService : IFlightSummaryService
    {
        private readonly IPassengerService _passengerService;
        private readonly ICashFlowCalculationService _cashFlowCalculationService;
        private readonly IFlightValidationService _flightValidationService;

        public FlightSummaryService(ICashFlowCalculationService cashFlowCalculationService, IPassengerService passengerService, IFlightValidationService flightValidationService)
        {
            _passengerService = passengerService;
            _cashFlowCalculationService = cashFlowCalculationService;
            _flightValidationService = flightValidationService;
        }

        public Models.FlightSummary CreateFlightSummary()
        {
            var totalFlightDiscount = _cashFlowCalculationService.CalculateDiscountedAmountForPassengersOnFlight();
            var loyaltyPointsUsed = (int)totalFlightDiscount;
            var totalRevenueFromPayingCustomers = _cashFlowCalculationService.CalculateTotalRevenueFromPayingCustomers();
            var costOfFlightToAirline = _cashFlowCalculationService.CalculateTotalCostOfFlightToAirline();
            var isPassengersWithinSeatCountOnPlane = _flightValidationService.IsPassengerCountOnAircraftAboveMaxSeats();
            var isAdjustedRevenueWithinCostOfFLight = _flightValidationService.IsAdjustedRevenueWithinCostOfFlight();

            return new Models.FlightSummary()
            {
                Passengers = _passengerService.GetNumberOfPassengers(),
                GeneralPassengers = _passengerService.GetNumberOfGeneralPassengers(),
                AirlinePassengers = _passengerService.GetNumberOfAirlinePassengers(),
                LoyaltyPassengers = _passengerService.GetNumberOfLoyaltyPassengers(),
                Bags = _passengerService.GetPassengerBags(),
                LoyaltyPointsUsed = loyaltyPointsUsed,
                CostOfFlight = (int)costOfFlightToAirline,
                RevenueBeforeDiscounts = (int)_cashFlowCalculationService.CalculateTotalRevenue(),
                RevenueAfterDiscounts = (int)(totalRevenueFromPayingCustomers - totalFlightDiscount),
                CanFlightProceed = isPassengersWithinSeatCountOnPlane && isAdjustedRevenueWithinCostOfFLight
            };
        }
    }
}
