using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.CarritoCompra.Entities
{
    public class CarritoSesionDetalle
    {
        public int CarritoSesionDetalleId { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public string ProductoSelecionado { get; set; }

        public CarritoSesion CarritoSesion { get; set; }

        public string CarritoSesionDetalleGuid { get; set; }
    }
}
