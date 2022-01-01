using System.Collections.Specialized;
using System.IO;
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
using Microsoft.AspNetCore.Authorization;

namespace trekkingadventurescr.Controllers
{
	[Authorize]
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

		public async Task<IActionResult> Index()
		{
			IEnumerable<Tour> tourList = _tours.GetAll();
			IEnumerable<IndexTourViewModel> viewModelData = tourList.Select(t => new IndexTourViewModel(t)).ToList();
			return View(viewModelData);
		}

		[HttpGet]
		public async Task<IActionResult> New()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> New(NewTourViewModel viewModelData)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Invalid data.");
				return View(viewModelData);
			}

			try
			{
				Tour model = viewModelData.Model();

                await uploadFile(model, viewModelData.imagen);

				bool added = _tours.Add(model);

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
		public async Task<IActionResult> Edit(string id)
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
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(EditDeleteTourViewModel viewModelData)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Invalid data.");
				return View(viewModelData);
			}

			try
			{
				Tour model = viewModelData.Model();

				await uploadFile(model, viewModelData.imagen);

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
			catch (Exception ex)
			{
				ModelState.AddModelError("", "An error occured while updating the data.");
				ModelState.AddModelError("", ex.Message);
				return View(viewModelData);
			}
		}

		[HttpGet]
		public async Task<IActionResult> Delete(string id)
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
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(EditDeleteTourViewModel viewModelData)
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

		private async Task uploadFile(Tour model, IFormFile file)
		{
            try
            {
				if (file != null) {
					string extension = Path.GetExtension(file.FileName);
					string name = Guid.NewGuid().ToString();
					string fileName = string.Format("{0}{1}", name, extension);

					string absoluteFolderPath = "wwwroot/images/uploads";
					string absoluteFileNamePath = Path.Combine(_environment.ContentRootPath, absoluteFolderPath, fileName);
					await file.CopyToAsync(new FileStream(absoluteFileNamePath, FileMode.Create));

					string relativeFolderPath = "images/uploads";
					string relativeFileNamePath = Path.Combine(relativeFolderPath, fileName);
					model.URLImagenEncabezado = relativeFileNamePath;
				}
			}
            catch (Exception ex)
            {
                throw ex;
                // throw new Exception("Error while saving the file.");
            }
		}
	}
}
