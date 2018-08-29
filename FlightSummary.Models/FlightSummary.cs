namespace FlightSummary.Models
{
    public class FlightSummary
    {
        public int Passengers { get; set; }
        public int GeneralPassengers { get; set; }
        public int AirlinePassengers { get; set; }
        public int LoyaltyPassengers { get; set; }
        public int Bags { get; set; }
        public int LoyaltyPointsUsed { get; set; }
        public int CostOfFlight { get; set; }
        public int RevenueBeforeDiscounts { get; set; }
        public int RevenueAfterDiscounts { get; set; }
        public bool CanFlightProceed { get; set; }
    }
}
