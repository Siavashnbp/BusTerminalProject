using BusTerminalProject.Entities;
using Microsoft.EntityFrameworkCore;
namespace BusTerminalProject.Db
{
    public class BusTerminalDbContext : DbContext
    {
        public BusTerminalDbContext()
        {

        }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-J9VL7Q5\\SQLEXPRESS;Initial Catalog=TaavBusTerminal;" +
                "Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BusTerminalDbContext).Assembly);
        }
    }
}
