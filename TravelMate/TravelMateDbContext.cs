using Microsoft.EntityFrameworkCore;
using TravelMate.Models;

namespace TravelMate
{
	public class TravelMateDbContext:DbContext
	{
		public TravelMateDbContext(DbContextOptions<TravelMateDbContext> options) : base(options)
		{

		}

		public DbSet<User> Users { get; set; }
		public DbSet<Hotel> Hotels { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<Cab> Cabs { get; set; }

	}

}
