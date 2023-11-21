using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.Libreria.Entities
{
    public class Librerias
    {
        public int LibreriasId { get; set; }

        public string TituloLibro { get; set; }

        public DateTime? FechaPublicacion { get; set; }

        public string AutorLibro { get; set; }

        public string LibreriaGuid { get; set; }


    }
}
