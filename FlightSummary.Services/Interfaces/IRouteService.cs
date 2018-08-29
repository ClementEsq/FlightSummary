namespace FlightSummary.Service.Interface
{
    public interface IRouteService : IFlightService
    {
        decimal GetCostOfFlightToAirline();
    }
}
