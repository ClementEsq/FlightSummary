namespace FlightSummary.Service.Interface
{
    public interface ICashFlowCalculationService
    {
        decimal CalculateDiscountedAmountForPassengersOnFlight();
        decimal CalculateTotalRevenueFromPayingCustomers();
        decimal CalculateTotalRevenue();
        decimal CalculateTotalCostOfFlightToAirline();
    }
}
