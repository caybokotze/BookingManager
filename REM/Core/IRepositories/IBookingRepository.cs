
using System.Collections.Generic;
using REM.Core.Domain;


namespace REM.Core.IRepositories
{
    public interface IBookingRepository : IRepository<Booking>
    {
        IEnumerable<Booking> GetCurrentBookings(int pageIndex, int pageSize);
        IEnumerable<Booking> GetBookingsForMonth(int month);
    }
}
