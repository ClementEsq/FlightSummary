namespace FlightSummary.Models
{
    public class LoyaltyPassenger : Passenger
    {
        private readonly int _currentLoyaltyPoints;
        private readonly bool _isUsingLoyaltyPoints;
        private readonly bool _hasExtraBag;

        public LoyaltyPassenger(int currentLoyaltyPoints, bool isUsingLoyaltyPoints, bool hasExtraBag) : base(true)
        {
            _currentLoyaltyPoints = currentLoyaltyPoints;
            _isUsingLoyaltyPoints = isUsingLoyaltyPoints;
            _hasExtraBag = hasExtraBag;
        }

        public override bool? GetExtraBagUsageStatus()
        {
            return _hasExtraBag;
        }

        public override int GetLoyaltyPoints()
        {
            return _currentLoyaltyPoints;
        }

        public override bool? GetLoyaltyPointUsageStatus()
        {
            return _isUsingLoyaltyPoints;
        }
    }
}
