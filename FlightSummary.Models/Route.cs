namespace FlightSummary.Models
{
    public class Route
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal CostToAirlinePerPassenger { get; set; }
        public decimal TicketPrice { get; set; }
    }
}
