using HotelBookingDll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingDll.Services
{
    public interface IHotelBookingService
    {
        void AddNewBooking(HotelBookingTable booking, int currentUserId);
        void DeleteBooking(int id, int currentUserId);
        HotelBookingTable GetBookingById(int id, int currentUserId);
        List<HotelBookingTable> GetAllBookings(int currentUserId);
    }
    public class HotelBookingServices : IHotelBookingService
    {
        private readonly HotelBookingDbContext _context;

        public HotelBookingServices(HotelBookingDbContext context)
        {
            _context = context;
        }
        public void AddNewBooking(HotelBookingTable booking, int currentUserId)
        {
            var newBooking = new HotelBookingTable
            {
                UserId = currentUserId,
                HotelId = booking.HotelId,
                RoomId = booking.RoomId,
                CheckInDate = booking.CheckInDate,
                CheckOutDate = booking.CheckOutDate,
                BookingStatus = booking.BookingStatus,
                TotalAmount = booking.TotalAmount
            };
            _context.HotelBookingTables.Add(newBooking);
            
            _context.SaveChanges();
        }

        public void DeleteBooking(int id, int currentUserId)
        {
            var booking = _context.HotelBookingTables.Find(id);

            if (booking == null || booking.UserId != currentUserId)
            {
                throw new Exception("Booking not found or you do not have access to delete.");
            }

            _context.HotelBookingTables.Remove(booking);
            _context.SaveChanges();
        }

        public List<HotelBookingTable> GetAllBookings(int currentUserId)
        {
            return _context.HotelBookingTables
                .Where(b => b.UserId == currentUserId)
                .Select(b => new HotelBookingTable
                {
                    BookingId = b.BookingId,
                    UserId = b.UserId,
                    HotelId = b.HotelId,
                    RoomId = b.RoomId,
                    CheckInDate = b.CheckInDate,
                    CheckOutDate = b.CheckOutDate,
                    BookingStatus = b.BookingStatus,
                    TotalAmount = b.TotalAmount
                })
                .ToList();
        }

        public HotelBookingTable GetBookingById(int id, int currentUserId)
        {
            var booking = _context.HotelBookingTables.Find(id);

            if (booking == null || booking.UserId != currentUserId)
            {
                throw new Exception($"Booking with id {id} not found or you do not have access.");
            }

            return new HotelBookingTable
            {
                BookingId = booking.BookingId,
                UserId = booking.UserId,
                HotelId = booking.HotelId,
                RoomId = booking.RoomId,
                CheckInDate = booking.CheckInDate,
                CheckOutDate = booking.CheckOutDate,
                BookingStatus = booking.BookingStatus,
                TotalAmount = booking.TotalAmount
            };
        }
    }
}
