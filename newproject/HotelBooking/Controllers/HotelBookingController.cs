using HotelBookingDll.Models;
using HotelBookingDll.Services;
using HotelBookingWebApi.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBookingWebApi.Controllers
{
    [Route("api/bookings/hotel")]
    [ApiController]
    [EnableCors("cors")]
    public class HotelBookingController : ControllerBase
    {
        private readonly IHotelBookingDataService _hotelBookingDataService;

        public HotelBookingController(IHotelBookingDataService hotelBookingDataService)
        {
            _hotelBookingDataService = hotelBookingDataService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<HotelBookingTable>>> GetAllBookings(int currentUserId)
        {
            try
            {
                var bookings = await _hotelBookingDataService.GetAllBookingsAsync(currentUserId);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HotelBookingTable>> GetBookingById(int id, int currentUserId)
        {
            try
            {
                var booking = await _hotelBookingDataService.GetBookingByIdAsync(id, currentUserId);
                return Ok(booking);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBooking([FromBody] HotelBookingTable booking, int currentUserId)
        {
            try
            {
                await _hotelBookingDataService.AddBookingAsync(booking, currentUserId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id, int currentUserId)
        {
            try
            {
                await _hotelBookingDataService.DeleteBookingByIdAsync(id, currentUserId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
