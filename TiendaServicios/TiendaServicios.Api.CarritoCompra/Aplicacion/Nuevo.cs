using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using TiendaServicios.Api.CarritoCompra.Context;
using TiendaServicios.Api.CarritoCompra.DTOS;
using TiendaServicios.Api.CarritoCompra.Entities;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : CarritoSesionDTO, IRequest { }

        public class EjecutaValidation : AbstractValidator<Ejecuta>
        {
            public EjecutaValidation()
            {
                RuleFor(x => x.Fecha).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            public readonly ContextoCarrito context;

            public Manejador(ContextoCarrito context)
            {
                this.context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carrito = new CarritoSesion()
                {
                    FechaCreacion = request.Fecha,
                    CarritoSesionGuid = Guid.NewGuid().ToString(),
                };
                this.context.CarritoSesion.Add(carrito);
                foreach (var detalles in request.CarritoDetalle)
                {
                    var detalle = new CarritoSesionDetalle()
                    {
                        FechaCreacion = detalles.Fecha,
                        ProductoSelecionado = detalles.Productos,
                        CarritoSesion = carrito,
                        CarritoSesionDetalleGuid = Guid.NewGuid().ToString()

                    };
                    this.context.CarritoSesionDetalle.Add(detalle);

                }



                var response = await this.context.SaveChangesAsync();

                return response > 0 ? Unit.Value : throw new Exception("Error al insertar");
            }
        }
    }
}