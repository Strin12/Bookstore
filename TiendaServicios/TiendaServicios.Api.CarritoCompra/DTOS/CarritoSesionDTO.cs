using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.CarritoCompra.DTOS
{
    public class CarritoSesionDTO
    {
        public int id { get; set; }

        public DateTime? Fecha { get; set; }

        public string Guid { get; set; }

        public List<CarritoDetalleDTO> CarritoDetalle { get; set; }
    }
}
