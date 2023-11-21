using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.Context;
using TiendaServicios.Api.CarritoCompra.Entities;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
    public class QueryFilter
    {
        public class SesionUnica : IRequest<CarritoSesion>
        {
            public string CarritoSesionDetalleGuid { get; set; }
        }

        public class Manejador : IRequestHandler<SesionUnica, CarritoSesion>
        {

            private readonly ContextoCarrito context;

            public Manejador(ContextoCarrito context)
            {
                this.context = context;
            }
            public async Task<CarritoSesion> Handle(SesionUnica request, CancellationToken cancellationToken)
            {
                var sesion = await this.context.CarritoSesion.Where(x => x.CarritoSesionGuid.Equals(request.CarritoSesionDetalleGuid)).FirstOrDefaultAsync();

                if (sesion == null)
                    throw new Exception("No e encontró el autor");
                else
                    return sesion;
            }
        }
    }
}