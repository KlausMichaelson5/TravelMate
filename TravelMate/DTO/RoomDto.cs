using TravelMate.Models;

namespace TravelMate.DTO
{
	public class RoomDto
	{
		public int RoomId { get; set; }
		public int HotelId { get; set; }
		public RoomType RoomType { get; set; }
		public decimal Price { get; set; }
		public bool AvailabilityStatus { get; set; }
		public string RoomImage { get; set; } = string.Empty;
	}
}
