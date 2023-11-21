using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.CarritoCompra.DTOS
{
    public class CarritoDetalleDTO
    {
        public int Id { get; set; }

        public DateTime? Fecha { get; set; }

        public string Productos { get; set; }

       // public CarritoSesion CarritoSesion { get; set; }

        public string Guid { get; set; }
    }
}
