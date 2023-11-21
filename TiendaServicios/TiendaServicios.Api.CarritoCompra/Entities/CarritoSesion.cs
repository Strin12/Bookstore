using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.CarritoCompra.Entities
{
    public class CarritoSesion
    {
        public int CarritoSesionId { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public string CarritoSesionGuid { get; set; }

        public ICollection<CarritoSesionDetalle> ListaCarritoSesionDetalle { get; set; }


    }
}
