namespace FlightSummary.Models
{

    public abstract class Passenger
    {
        public Passenger(bool isPayingPassenger)
        {
            this.IsPayingPassenger = isPayingPassenger;
        }

        public string PassengerName { get; set; }
        public bool IsPayingPassenger { get; }
        public abstract int GetLoyaltyPoints();
        public abstract bool? GetLoyaltyPointUsageStatus();
        public abstract bool? GetExtraBagUsageStatus();
    }
}
