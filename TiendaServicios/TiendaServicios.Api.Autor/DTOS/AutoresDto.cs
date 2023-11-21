using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Entities;

namespace TiendaServicios.Api.Autor.DTOS
{
    public class AutoresDto
    {
        public int AutorLibroId { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime? FechadeNacimiento { get; set; }


        public string AutorLibroGuid { get; set; }

        public List<DTOgrados> Grado { get; set; }

    }
}
