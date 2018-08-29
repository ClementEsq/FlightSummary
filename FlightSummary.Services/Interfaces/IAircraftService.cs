namespace FlightSummary.Service.Interface
{
    public interface IAircraftService : IFlightService
    {
        int GetNumberOfSeatsOnPlane();
    }
}
