using Microsoft.EntityFrameworkCore;
using TravelMate.DTO;
using TravelMate.Models;

namespace TravelMate.Services
{
	public interface IUserService
	{
		Task Add(UserDto user);
		Task Delete(int id);
		Task<UserDto> Get(int id);
		Task<List<UserDto>> GetAll();
		Task Update(UserDto user);
	}

	public class UserService : IUserService
	{
		private readonly TravelMateDbContext _context;

		public UserService(TravelMateDbContext context)
		{
			_context = context;
		}

		public async Task<List<UserDto>> GetAll()
		{
			var users = new List<UserDto>();
			var userEntities = await _context.Users.ToListAsync();

			foreach (var userEntity in userEntities)
			{
				var user = new UserDto()
				{
					UserId = userEntity.UserId,
					Username = userEntity.Username,
					PasswordHash = userEntity.PasswordHash,
					Name = userEntity.Name,
					Address = userEntity.Address,
					Nationality = userEntity.Nationality,
					Email = userEntity.Email,
					PhoneNumber = userEntity.PhoneNumber,
					AuthProvider = userEntity.AuthProvider,
					UserType = userEntity.UserType
				};

				users.Add(user);
			}

			return users;
		}

		public async Task<UserDto> Get(int id)
		{
			try
			{
				var user = await _context.Users.FindAsync(id);
				if (user == null)
				{
					throw new Exception($"User with id {id} not found.");
				}
				return new UserDto()
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
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

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

		public async Task Add(UserDto user)
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

		public async Task Delete(int id)
		{
			try
			{
				var user = await _context.Users.FindAsync(id);
				if (user != null)
				{
					_context.Users.Remove(user);
					_context.SaveChanges();
				}
				else
				{
					throw new Exception("User not found to delete.");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
