using Microsoft.EntityFrameworkCore;
using LaundryReservationAPI.Models;

namespace LaundryReservationAPI.Data
{
    public class LaundryDbContext: DbContext
    {
        public LaundryDbContext(DbContextOptions<LaundryDbContext> options) : base(options) { }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Machine> Machines { get; set; }
    }
}
