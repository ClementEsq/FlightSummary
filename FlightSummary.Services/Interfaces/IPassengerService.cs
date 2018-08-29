namespace FlightSummary.Service.Interface
{
    public interface IPassengerService : IFlightService
    {
        int GetNumberOfPassengers();
        int GetNumberOfGeneralPassengers();
        int GetNumberOfAirlinePassengers();
        int GetNumberOfLoyaltyPassengers();
        int GetPassengerBags();
    }
}
