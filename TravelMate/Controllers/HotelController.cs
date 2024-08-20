using Microsoft.AspNetCore.Mvc;

namespace TravelMate.Controllers
{
	public class HotelController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
