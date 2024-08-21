using Microsoft.EntityFrameworkCore;
using TravelMate.DTO;

namespace TravelMate.Services
{
	public interface IAdminService
	{
		Task<List<UserDto>> GetAll();
		Task Delete(int id);
	}
	public class AdminService : IAdminService
	{
		private readonly TravelMateDbContext _context;

		public AdminService(TravelMateDbContext context)
		{
			_context = context;
		}

		public async Task Delete(int id)
		{
			var user = await _context.Users.FindAsync(id);
			if (user == null)
			{
				throw new Exception("Cab not found to delete.");
			}

			_context.Users.Remove(user);
			await _context.SaveChangesAsync();
		}
		

		public async Task<List<UserDto>> GetAll()
		{
			var usersDto = new List<UserDto>();
			var users = await _context.Users.ToListAsync();

			foreach (var user in users)
			{
				var tempUser = new UserDto()
				{
					UserId = user.UserId,
					Username = user.Username,
					PasswordHash = user.PasswordHash,
					Name = user.Name,
					Address = user.Address,
					Nationality = user.Nationality,
					Email = user.Email,
					PhoneNumber = user.PhoneNumber,
					AuthProvider = user.AuthProvider,
					UserType = user.UserType

				};

				usersDto.Add(tempUser);
			}

			return usersDto;
		}
		
		}
}
