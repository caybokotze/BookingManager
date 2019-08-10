
using System.Collections.Generic;
using REM.Core.Domain;


namespace REM.Core.IRepositories
{
    public interface IVenueRepository : IRepository<Venue>
    {
        IEnumerable<Venue> GetTopSellingVenues(int pageIndex, int pageSize);
        IEnumerable<Venue> GetHighestRatedVenues(int pageIndex, int pageSize);
        IEnumerable<Venue> GetMostExpensiveVenues(int pageIndex, int pageSize);
        IEnumerable<Venue> GetCheapestVenues(int pageIndex, int pageSize);

        
    }
}
