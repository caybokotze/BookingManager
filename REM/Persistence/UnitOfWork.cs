using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using REM.Connections;
using REM.Core;
using REM.Core.IRepositories;
using REM.Persistence.Repositories;

namespace REM.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Bookings = new BookingRepository(_context);
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IBookingRepository Bookings { get; }
        public IVenueRepository Venues { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}