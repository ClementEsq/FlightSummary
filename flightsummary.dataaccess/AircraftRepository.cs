using FlightSummary.Models;

namespace FlightSummary.DataAccess
{
    public class AircraftRepository : IRepository<Aircraft>
    {
        private Aircraft _aircraft;

        public void Set(Aircraft entity)
        {
            _aircraft = entity;
        }

        public Aircraft Get()
        {
            return _aircraft;
        }
    }
}
