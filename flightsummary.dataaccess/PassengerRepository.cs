using FlightSummary.Models;
using System.Collections.Generic;

namespace FlightSummary.DataAccess
{
    public class PassengerRepository : IRepository<IList<Passenger>>
    {
        private IList<Passenger> _passengers;

        public void Set(IList<Passenger> passengers)
        {
            _passengers = passengers;
        }

        public IList<Passenger> Get()
        {
       
            return _passengers;
        }
    }
}
