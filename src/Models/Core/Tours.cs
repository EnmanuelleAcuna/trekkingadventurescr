using System;
using System.Collections.Generic;

namespace trekkingadventurescr.Models.Core
{
	public class Tours
	{
		private readonly Data.Tours _tours;

		public Tours()
		{
			_tours = new Data.Tours();
		}

		public IEnumerable<Tour> GetAll()
		{
			IEnumerable<Tour> tours = _tours.GetAll();
			return tours;
		}

		public Tour GetById(int id)
		{
			Tour tour = _tours.GetById(id);
			return tour;
		}

		public bool Add(Tour model, string filePath)
		{
			bool added = _tours.Add(model);
			return added;
		}

		public bool Update(Tour model)
		{
			Tour toBeUpdatedModel = GetById(model.Id);

			if (toBeUpdatedModel is null) throw new Exception("Tour not found with specified id.");

			// Change values of updatable/editable fields
			toBeUpdatedModel.Nombre = model.Nombre;
			toBeUpdatedModel.Precio = model.Precio;
			toBeUpdatedModel.DescripcionBreve = model.DescripcionBreve;
			toBeUpdatedModel.DescripcionCompleta = model.DescripcionCompleta;
			toBeUpdatedModel.EsTourDestacado = model.EsTourDestacado;

			bool updated = _tours.Update(toBeUpdatedModel);
			return updated;
		}

		public bool Delete(int id)
		{
			Tour toBeDeletedModel = GetById(id);

			if (toBeDeletedModel is null) throw new Exception("Tour not found with specified id.");

			bool deleted = _tours.Delete(id);
			return deleted;
		}
	}
}
