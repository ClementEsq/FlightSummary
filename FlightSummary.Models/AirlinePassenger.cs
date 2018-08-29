namespace FlightSummary.Models
{
    public class AirlinePassenger : Passenger
    {
        public AirlinePassenger():base(false)
        {
        }

        public override bool? GetExtraBagUsageStatus()
        {
            return null;
        }

        public override int GetLoyaltyPoints()
        {
            return 0;
        }

        public override bool? GetLoyaltyPointUsageStatus()
        {
            return null;
        }
    }
}
