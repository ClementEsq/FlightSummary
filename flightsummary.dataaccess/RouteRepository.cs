using FlightSummary.Models;

namespace FlightSummary.DataAccess
{
    public class RouteRepository : IRepository<Route>
    {
        private Route _route;

        public void Set(Route entity)
        {
            _route = entity;
        }

        public Route Get()
        {
            return _route;
        }
    }
}
