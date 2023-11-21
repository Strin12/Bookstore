using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TiendaServicios.Api.Login.DTOS;
using TiendaServicios.Api.Login.Aplicacion;
using TiendaServicios.Api.Login.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace TiendaServicios.Api.Login.Aplicacion
{
    public class Query
    {
        public class ListaUsuarios : IRequest<List<UsuariosDTO>> { }

        public class Manejador : IRequestHandler<ListaUsuarios, List<UsuariosDTO>>
        {
            private readonly ContextoUsuario context;
            public List<UsuariosDTO> dto;
            public UsuariosDTO usuario;


            public Manejador(ContextoUsuario context)
            {
                this.context = context;
            }

            public async Task<List<UsuariosDTO>> Handle(ListaUsuarios request, CancellationToken cancellationToken)
            {
                var datos = await this.context.Usuarios.ToListAsync();
                dto = new List<UsuariosDTO>();
                foreach (var item in datos)
                {
                    usuario = new UsuariosDTO();
                    usuario.Id = item.UsuariosId;
                    usuario.user = item.username;
                    usuario.email = item.email;
                    usuario.password = item.password;
                    usuario.Guid = item.UsuarioGuid;
                    dto.Add(usuario);
                }
                
                return dto;
            }
        }
    }
}
