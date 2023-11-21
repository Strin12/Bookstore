using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TiendaServicios.Api.Libreria.DTOS;
using TiendaServicios.Api.Libreria.Context;
using System.Threading;
using FluentValidation;
using TiendaServicios.Api.Libreria.Entities;

namespace TiendaServicios.Api.Libreria.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : LibreriaDTOS, IRequest {}

        public class EjecutaValidation : AbstractValidator<Ejecuta>
        {
            public EjecutaValidation()
            {
                RuleFor(x => x.Titulo).NotEmpty();
                RuleFor(x => x.Autor).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            public readonly ContextoLibreria context;

            public Manejador(ContextoLibreria context)
            {
                this.context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var libreria = new Librerias()
                {
                    TituloLibro = request.Titulo,
                    FechaPublicacion = request.Fecha,
                    AutorLibro = request.Autor,
                    LibreriaGuid = Guid.NewGuid().ToString()
                };
                this.context.Librerias.Add(libreria);

                var response = await this.context.SaveChangesAsync();

                return response > 0 ? Unit.Value : throw new Exception("Error al insertar");
            }
        }
    }
}