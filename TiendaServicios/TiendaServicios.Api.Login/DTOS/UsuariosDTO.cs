using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.Login.DTOS
{
    public class UsuariosDTO
    {
        public int Id { get; set; }

        public string user { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string Guid { get; set; }

        public string token { get; set; }
    }
}
