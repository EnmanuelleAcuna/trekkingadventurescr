using System;

namespace trekkingadventurescr.Models
{
	public class Tour
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public decimal Precio { get; set; }
		public string DescripcionBreve { get; set; }
		public string DescripcionCompleta { get; set; }
		public DateTime FechaRegistro { get; set; }
		public bool EsTourDestacado { get; set; }
		public string URLImagenEncabezado { get; set; }
	}
}
