using Microsoft.EntityFrameworkCore;
using TravelMate.DTO;
using TravelMate.Models;

namespace TravelMate.Services
{
	public interface IUserService
	{
		Task Register(UserDto user);
		Task<UserDto> Login(UserDto user);
		Task<UserDto> Logout(UserDto user);
		Task Update(UserDto user);
	}

	public class UserService : IUserService
	{
		private readonly TravelMateDbContext _context;

		public UserService(TravelMateDbContext context)
		{
			_context = context;
		}

		//public async Task<UserDto> Get(int id)
		//{
		//	try
		//	{
		//		var user = await _context.Users.FindAsync(id);
		//		if (user == null)
		//		{
		//			throw new Exception($"User with id {id} not found.");
		//		}
		//		return new UserDto()
		//		{
		//			UserId = user.UserId,
		//			Username = user.Username,
		//			PasswordHash = user.PasswordHash,
		//			Name = user.Name,
		//			Address = user.Address,
		//			Nationality = user.Nationality,
		//			Email = user.Email,
		//			PhoneNumber = user.PhoneNumber,
		//			AuthProvider = user.AuthProvider,
		//			UserType = user.UserType
		//		};
		//	}
		//	catch (Exception ex)
		//	{
		//		throw ex;
		//	}
		//}

		public async Task Update(UserDto user)
		{
			try
			{
				var existingUser = await _context.Users.FindAsync(user.UserId);
				if (existingUser != null)
				{
					existingUser.Username = user.Username;
					existingUser.PasswordHash = user.PasswordHash;
					existingUser.Name = user.Name;
					existingUser.Address = user.Address;
					existingUser.Nationality = user.Nationality;
					existingUser.Email = user.Email;
					existingUser.PhoneNumber = user.PhoneNumber;
					existingUser.AuthProvider = user.AuthProvider;
					existingUser.UserType = user.UserType;

					_context.SaveChanges();
				}
				else
				{
					throw new Exception("User not found to update.");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task Register(UserDto user)
		{
			try
			{
				await _context.Users.AddAsync(new User()
				{
					Username = user.Username,
					PasswordHash = user.PasswordHash,
					Name = user.Name,
					Address = user.Address,
					Nationality = user.Nationality,
					Email = user.Email,
					PhoneNumber = user.PhoneNumber,
					AuthProvider = user.AuthProvider,
					UserType = user.UserType
				});

				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<UserDto> Login(UserDto userDto)
		{
			var user = await _context.Users
				.Where(u => u.Username == userDto.Username)
				.FirstOrDefaultAsync();

			if (user == null || userDto.PasswordHash!= user.PasswordHash)
			{
				throw new Exception("Invalid username or password.");
			}

			return new UserDto
			{
				UserId = user.UserId,
				Username = user.Username,
				Name = user.Name,
				Email = user.Email,
				PhoneNumber = user.PhoneNumber,
				UserType = user.UserType
			};
		}

		public Task<UserDto> Logout(UserDto user)
		{
			throw new NotImplementedException();
		}
	}
}
