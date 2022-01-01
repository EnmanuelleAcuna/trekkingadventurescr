using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace trekkingadventurescr.Models.Data.EntityFramework
{
    public partial class Tours
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string DescripcionBreve { get; set; }
        public string DescripcionCompleta { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool TourDestacado { get; set; }
        public string UrlImagenEncabezado { get; set; }
    }
}
