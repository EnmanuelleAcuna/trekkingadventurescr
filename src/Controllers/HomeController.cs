using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using trekkingadventurescr.Models;
using trekkingadventurescr.Models.Core;
using trekkingadventurescr.Models.ViewModels;

namespace trekkingadventurescr.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly Tours _tours;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
			_tours = new Tours();
		}

		public IActionResult Index()
		{
			IEnumerable<TourViewModel> featuredTours = _tours.GetAllFeatured(3).Select(t => new TourViewModel(t)).ToList();
			return View(featuredTours);
		}

		public IActionResult Tours()
		{
			IEnumerable<TourViewModel> tours = _tours.GetAll().Select(t => new TourViewModel(t)).ToList();
			return View(tours);
		}

		public IActionResult About()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
