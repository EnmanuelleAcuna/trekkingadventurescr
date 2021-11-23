using System.Collections.Specialized;
using System.Text;
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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace trekkingadventurescr.Controllers
{
	public class ToursController : Controller
	{
		private readonly ILogger<ToursController> _logger;
		private readonly IWebHostEnvironment _environment;
		private readonly Tours _tours;

		public ToursController(ILogger<ToursController> logger, IWebHostEnvironment environment)
		{
			_logger = logger;
			_environment = environment;
			_tours = new Tours();
		}

		public IActionResult Index()
		{
			IEnumerable<Tour> tourList = _tours.GetAll();
			IEnumerable<IndexTourViewModel> viewModelData = tourList.Select(t => new IndexTourViewModel(t)).ToList();
			return View(viewModelData);
		}

		[HttpGet]
		public IActionResult New()
		{
			return View();
		}

		[HttpPost]
		public IActionResult New(NewTourViewModel viewModelData)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Invalid data.");
				return View(viewModelData);
			}

			try
			{
				Tour model = viewModelData.Model();

                string filePath = uploadFile(viewModelData.imagen);

				bool added = _tours.Add(model, filePath);

				if (added)
				{
					ViewData["Info"] = "Tour added succesfully.";
					return RedirectToAction("Index");
				}
				else
				{
					throw new Exception("The new method returned false.");
				}
			}
			catch
			{
				ModelState.AddModelError("", "An error occured while saving the data.");
				return View(viewModelData);
			}
		}

		[HttpGet]
		public IActionResult Edit(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				ViewData["Info"] = "Invalid data.";
				return RedirectToAction("Index");
			}

			try
			{
				Tour model = _tours.GetById(Convert.ToInt32(id));

				if (model is null) throw new Exception("Tour not found with specified id.");

				EditDeleteTourViewModel viewModel = new EditDeleteTourViewModel(model);

				return View(viewModel);
			}
			catch
			{
				ModelState.AddModelError("", "An error occured while getting the data.");
				return RedirectToAction("Index");
			}
		}

		[HttpPost]
		public IActionResult Edit(EditDeleteTourViewModel viewModelData)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Invalid data.");
				return View(viewModelData);
			}

			try
			{
				Tour model = viewModelData.Model();

				bool updated = _tours.Update(model);

				if (updated)
				{
					ViewData["Info"] = "Tour updated succesfully.";
					return RedirectToAction("Index");
				}
				else
				{
					throw new Exception("The updated method returned false.");
				}
			}
			catch
			{
				ModelState.AddModelError("", "An error occured while updating the data.");
				return View(viewModelData);
			}
		}

		[HttpGet]
		public IActionResult Delete(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				ViewData["Info"] = "Invalid data.";
				return RedirectToAction("Index");
			}

			try
			{
				Tour model = _tours.GetById(Convert.ToInt32(id));

				if (model is null) throw new Exception("Tour not found with specified id.");

				EditDeleteTourViewModel viewModel = new EditDeleteTourViewModel(model);

				return View(viewModel);
			}
			catch
			{
				ModelState.AddModelError("", "An error occured while getting the data.");
				return RedirectToAction("Index");
			}
		}

		[HttpPost]
		public IActionResult Delete(EditDeleteTourViewModel viewModelData)
		{
			if (viewModelData is null || viewModelData.id == 0)
			{
				ModelState.AddModelError("", "Invalid data.");
				return View(viewModelData);
			}

			try
			{
				bool deleted = _tours.Delete(viewModelData.id);

				if (deleted)
				{
					ViewData["Info"] = "Tour deleted succesfully.";
					return RedirectToAction("Index");
				}
				else
				{
					throw new Exception("The deleted method returned false.");
				}
			}
			catch
			{
				ModelState.AddModelError("", "An error occured while deleting the data.");
				return View(viewModelData);
			}
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		private string uploadFile(IFormFile file)
		{
            try
            {
				string fullFileNamePath = System.IO.Path.Combine(_environment.ContentRootPath, "uploads", file.FileName);

				file.CopyTo(new System.IO.FileStream(fullFileNamePath, System.IO.FileMode.Create));

                return fullFileNamePath;
			}
            catch (System.Exception)
            {
                throw new Exception("Error while saving the file.");;
            }
		}
	}
}
