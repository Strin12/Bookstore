using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.Login.Entities
{
    public class Usuarios
    {
        public int UsuariosId { get; set; }

        public string username { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string UsuarioGuid { get; set; }

    }
}
