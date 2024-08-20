using System.ComponentModel.DataAnnotations;
using TravelMate.Models;

namespace TravelMate.DTO
{
	public class UserDto
	{
		public int UserId { get; set; }
		public string Username { get; set; } = string.Empty;
		public string PasswordHash { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public Nationality Nationality { get; set; }
		public string Email { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public AuthProvider AuthProvider { get; set; } = AuthProvider.Local;
		public UserType UserType { get; set; }
	}
}

