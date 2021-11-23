using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using trekkingadventurescr.Models.Data.EntityFramework;

// Data access
namespace trekkingadventurescr.Models.Data
{
	public class Tours
	{
		private readonly trekkingadventurescr_DB_Context _dbContext;

		public Tours()
		{
			_dbContext = new trekkingadventurescr_DB_Context();
		}

		public IEnumerable<Tour> GetAll()
		{
			List<Tour> tours = _dbContext.Tours.Select(t => t.Model()).ToList();
			return tours;
		}

		public Tour GetById(int id)
		{
			Tour tour = _dbContext.Tours.Find(id).Model();
			return tour;
		}

		public bool Add(Tour model)
		{
			if (model is null)
			{
				throw new ArgumentNullException(paramName: nameof(model), message: "Invalid model.");
			}

			EntityFramework.Tours dbModel = new EntityFramework.Tours(model);
			_dbContext.Tours.Add(dbModel);
			_dbContext.Entry(dbModel).State = EntityState.Added;
			int affectedRecords = _dbContext.SaveChanges();

			return affectedRecords >= 1;
		}

		public bool Update(Tour model)
		{
			if (model is null)
			{
				throw new ArgumentNullException(paramName: nameof(model), message: "Invalid model.");
			}

			EntityFramework.Tours dbModel = _dbContext.Tours.Find(model.Id);

			// Change values of updatable/editable fields
			dbModel.Nombre = model.Nombre;
			dbModel.Precio = model.Precio;
			dbModel.DescripcionBreve = model.DescripcionBreve;
			dbModel.DescripcionCompleta = model.DescripcionCompleta;
			dbModel.FechaRegistro = model.FechaRegistro;
			dbModel.TourDestacado = model.EsTourDestacado;

			_dbContext.Tours.Update(dbModel);
			_dbContext.Entry(dbModel).State = EntityState.Modified;
			int affectedRecords = _dbContext.SaveChanges();

			return affectedRecords >= 1;
		}

		public bool Delete(int id)
		{
			if (id <= 0)
			{
				throw new ArgumentNullException(paramName: nameof(id), message: "Invalid id.");
			}

			EntityFramework.Tours dbModel = _dbContext.Tours.Find(id);
			_dbContext.Tours.Remove(dbModel);
			_dbContext.Entry(dbModel).State = EntityState.Deleted;
			int affectedRecords = _dbContext.SaveChanges();

			return affectedRecords >= 1;
		}
	}
}

// Data transfer
namespace trekkingadventurescr.Models.Data.EntityFramework
{
	public partial class Tours
	{
		public Tours() { }

		public Tours(Tour model)
		{
			Id = model.Id;
			Nombre = model.Nombre;
			Precio = model.Precio;
			DescripcionBreve = model.DescripcionBreve;
			DescripcionCompleta = model.DescripcionCompleta;
			FechaRegistro = model.FechaRegistro;
			TourDestacado = model.EsTourDestacado;
		}

		public Tour Model()
		{
			Tour model = new Tour
			{
				Id = this.Id,
				Nombre = this.Nombre,
				Precio = this.Precio,
				DescripcionBreve = this.DescripcionBreve,
				DescripcionCompleta = this.DescripcionCompleta,
				FechaRegistro = this.FechaRegistro,
				EsTourDestacado = TourDestacado
			};

			return model;
		}
	}
}
