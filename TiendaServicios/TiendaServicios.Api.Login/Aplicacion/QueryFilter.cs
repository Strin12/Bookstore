using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Login.Context;
using TiendaServicios.Api.Login.Entities;

namespace TiendaServicios.Api.Login.Aplicacion
{
    public class QueryFilter
    {
        public class UsuarioUnico : IRequest<Usuarios>
        {
            public string UsuarioGuid { get; set; }
        }

        public class Manejador : IRequestHandler<UsuarioUnico, Usuarios>
        {

            private readonly ContextoUsuario context;

            public Manejador(ContextoUsuario context)
            {
                this.context = context;
            }
            public async Task<Usuarios> Handle(UsuarioUnico request, CancellationToken cancellationToken)
            {
                var autor = await this.context.Usuarios.Where(x => x.UsuarioGuid.Equals(request.UsuarioGuid)).FirstOrDefaultAsync();

                if (autor == null)
                    throw new Exception("No e encontró el autor");
                else
                    return autor;
            }
        }
    }
}
