using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TravelMate.Models
{
	public enum RoomType
	{
		AC,
		Non_AC
	}
	public class Room
	{
		[Key]
		public int RoomId { get; set; }

		[ForeignKey("Hotel")]
		public int HotelId { get; set; }

		[Required]
		public RoomType RoomType { get; set; }

		public decimal Price { get; set; }

		public bool AvailabilityStatus { get; set; }

		public string RoomImage { get; set; } = string.Empty;
	}
}
