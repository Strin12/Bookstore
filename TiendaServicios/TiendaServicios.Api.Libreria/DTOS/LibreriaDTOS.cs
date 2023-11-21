using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.Libreria.DTOS
{
    public class LibreriaDTOS
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public DateTime? Fecha { get; set; }

        public string Autor { get; set; }

        public string Guid { get; set; }
    }
}
