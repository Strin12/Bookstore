using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libreria.Context;
using TiendaServicios.Api.Libreria.Entities;

namespace TiendaServicios.Api.Libreria.Aplicacion
{
    public class QueryFilter
    {
        public class LibreriaUnica : IRequest<Librerias>
        {
            public string AutorGuid { get; set; }
        }

        public class Manejador : IRequestHandler<LibreriaUnica, Librerias>
        {

            private readonly ContextoLibreria context;

            public Manejador(ContextoLibreria context)
            {
                this.context = context;
            }
            public async Task<Librerias> Handle(LibreriaUnica request, CancellationToken cancellationToken)
            {
                var autor = await this.context.Librerias.Where(x => x.LibreriaGuid.Equals(request.AutorGuid)).FirstOrDefaultAsync();

                if (autor == null)
                    throw new Exception("No e encontró el autor");
                else
                    return autor;
            }
        }
    }
}
