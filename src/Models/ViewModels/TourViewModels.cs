using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace trekkingadventurescr.Models.ViewModels
{
	public class IndexTourViewModel
	{
		public IndexTourViewModel(Tour model)
		{
			id = model.Id;
			nombre = model.Nombre;
			precio = model.Precio.ToString("C");
			descripcionBreve = model.DescripcionBreve;
			tourDestacado = model.EsTourDestacado ? "Yes" : "No";
		}

		public int id { get; set; }

		[Display(Name = "Name")]
		public string nombre { get; set; }

		[Display(Name = "Price")]
		public string precio { get; set; }

		[Display(Name = "Description")]
		public string descripcionBreve { get; set; }

		[Display(Name = "Featured")]
		public string tourDestacado { get; set; }
	}

	public class NewTourViewModel
	{
		[Display(Name = "Tour name")]
		[Required]
		public string nombre { get; set; }

		[Display(Name = "Price")]
		[Required]
		public decimal precio { get; set; }

		[Display(Name = "Short description")]
		[Required]
		public string descripcionBreve { get; set; }

		[Display(Name = "Full description")]
		[Required]
		public string descripcionCompleta { get; set; }

		[Display(Name = "Featured tour")]
		public bool esTourDestacado { get; set; }

		[Display(Name = "Header picture")]
		[Required]
		public IFormFile imagen { get; set; }

		public Tour Model()
		{
			Tour model = new Tour
			{
				Nombre = nombre,
				Precio = precio,
				DescripcionBreve = descripcionBreve,
				DescripcionCompleta = descripcionCompleta,
				FechaRegistro = DateTime.Now,
				EsTourDestacado = esTourDestacado
			};

			return model;
		}
	}

	public class EditDeleteTourViewModel
	{
		public EditDeleteTourViewModel() { }

		public EditDeleteTourViewModel(Tour model)
		{
			id = model.Id;
			nombre = model.Nombre;
			precio = model.Precio;
			descripcionBreve = model.DescripcionBreve;
			descripcionCompleta = model.DescripcionCompleta;
			esTourDestacado = model.EsTourDestacado;
			rutaImagen = model.URLImagenEncabezado;
		}

		public int id { get; set; }

		[Display(Name = "Tour name")]
		[Required]
		public string nombre { get; set; }

		[Display(Name = "Price")]
		[Required]
		public decimal precio { get; set; }

		[Display(Name = "Short description")]
		[Required]
		public string descripcionBreve { get; set; }

		[Display(Name = "Full description")]
		[Required]
		public string descripcionCompleta { get; set; }

		[Display(Name = "Featured tour")]
		public bool esTourDestacado { get; set; }

		[Display(Name = "New header picture")]
		public IFormFile imagen { get; set; }

		public string rutaImagen { get; set; }

		public Tour Model()
		{
			Tour model = new Tour
			{
				Id = id,
				Nombre = nombre,
				Precio = precio,
				DescripcionBreve = descripcionBreve,
				DescripcionCompleta = descripcionCompleta,
				FechaRegistro = DateTime.Now,
				EsTourDestacado = esTourDestacado,
				URLImagenEncabezado = rutaImagen
			};

			return model;
		}
	}

	public class TourViewModel
	{
		public TourViewModel(Tour model)
		{
			id = model.Id;
			nombre = model.Nombre;
			precio = model.Precio.ToString("C");
			descripcionBreve = model.DescripcionBreve;
			descripcionCompleta = model.DescripcionCompleta;
			rutaImagen = model.URLImagenEncabezado;
		}

		public int id { get; set; }

		[Display(Name = "Name")]
		public string nombre { get; set; }

		[Display(Name = "Price")]
		public string precio { get; set; }

		[Display(Name = "Description")]
		public string descripcionBreve { get; set; }

		[Display(Name = "Description")]
		public string descripcionCompleta { get; set; }

		public string rutaImagen { get; set; }
	}
}
