using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TiendaServicios.Api.Autor.DTOS;
using TiendaServicios.Api.Autor.Context;
using System.Threading;
using FluentValidation;
using TiendaServicios.Api.Autor.Entities;

namespace TiendaServicios.Api.Autor.Aplicaciones
{
    public class Nuevo
    {
        public class Ejecuta : AutoresDto, IRequest {}

        public class EjecutaValidation : AbstractValidator<Ejecuta>
        {
            public EjecutaValidation()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Apellido).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            public readonly ContextoAutor context;

            public Manejador(ContextoAutor context)
            {
                this.context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var autor = new AutorLibro()
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    FechadeNacimiento = request.FechadeNacimiento,
                    AutorLibroGuid = Guid.NewGuid().ToString()
                };
                this.context.AutorLibro.Add(autor);
                foreach (var grados in request.Grado)
                {
                    var gradoAcademico = new GradoAcademico()
                    {
                        Nombre = grados.Nombre,
                        CentroAcademico = grados.CentroAcademico,
                        FechaGrado = grados.FechaGrado,
                        AutorLibro = autor,
                        GradoAcademicoGuid = Guid.NewGuid().ToString()

                    };
                    this.context.GradoAcademico.Add(gradoAcademico);

                }



                var response = await this.context.SaveChangesAsync();

                return response > 0 ? Unit.Value : throw new Exception("Error al insertar");
            }
        }
    }
}