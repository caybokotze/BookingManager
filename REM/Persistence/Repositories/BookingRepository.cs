
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
using REM.Connections;
using REM.Core.Domain;
using REM.Core.IRepositories;
using REM.Logic;

namespace REM.Persistence.Repositories
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ApplicationDbContext Db => Context as ApplicationDbContext;

        public IEnumerable<Booking> GetCurrentBookings(int pageIndex, int pageSize)
        {
            var newDateTime = new DateTime();
            newDateTime = DateTime.Now;

            try
            {
                return Db.Bookings.Where(d => d.BookingFrom <= newDateTime && d.BookingTo >= newDateTime);
            }
            catch (Exception e)
            {
                
                var assemblyQualifiedName = this.GetType().AssemblyQualifiedName;
                if (assemblyQualifiedName != null)
                    Log.Add(ErrorNames.EntityRuleBroken, assemblyQualifiedName.ToString(), e);
                throw;
            }
        }

        public IEnumerable<Booking> GetBookingsForMonth(int month)
        {
            throw new System.NotImplementedException();
        }
    }
}