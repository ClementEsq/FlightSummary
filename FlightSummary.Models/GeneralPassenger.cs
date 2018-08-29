namespace FlightSummary.Models
{
    public class GeneralPassenger : Passenger
    {
        public GeneralPassenger() : base(true)
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
