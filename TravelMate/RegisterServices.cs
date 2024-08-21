using Microsoft.EntityFrameworkCore;
using TravelMate.Services;

namespace TravelMate
{
	public static class RegisterServices
	{
		public static  void RegisterService(this WebApplicationBuilder builder)
		{
			builder.Services.AddTransient<IUserService, UserService>();
			builder.Services.AddTransient<ICabService, CabService>();
			builder.Services.AddTransient<IHotelService, HotelService>();
			builder.Services.AddTransient<IRoomService, RoomService>();

			builder.Services.AddDbContext<TravelMateDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("myConnection"));
			});
		}
	}
}
