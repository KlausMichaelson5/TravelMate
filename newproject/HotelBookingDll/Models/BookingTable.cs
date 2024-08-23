using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingDll.Models
{
    [Table("tblHotelBooking")]
    public class HotelBookingTable
    {
        [Key]
        public int BookingId {  get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        [ForeignKey("Room")]
        public int RoomId {  get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get;set; }
        public string BookingStatus { get; set; }
        [Column(TypeName ="decimal(10,2)")]
        public decimal TotalAmount {  get; set; }

     
    }
    public class HotelBookingDbContext : DbContext
    {
        public HotelBookingDbContext() { }
        public HotelBookingDbContext(DbContextOptions<HotelBookingDbContext> options) : base(options)
        {

        }
        public DbSet<HotelBookingTable> HotelBookingTables { get; set; }

    }
}
