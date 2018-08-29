namespace FlightSummary.Service.Interface
{
    public interface IFlightValidationService
    {
        bool IsAdjustedRevenueWithinCostOfFlight();
        bool IsPassengerCountOnAircraftAboveMaxSeats();
    }
}
