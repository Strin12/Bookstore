using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Context;
using TiendaServicios.Api.Autor.DTOS;
using TiendaServicios.Api.Autor.Entities;

namespace TiendaServicios.Api.Autor.Aplicaciones
{
    public class Query
    {
        public class ListaAutor : IRequest<List<AutoresDto>> { }

        public class Manejador : IRequestHandler<ListaAutor, List<AutoresDto>>
        {
            private readonly ContextoAutor context;
            public List<AutoresDto> dto;
            public AutoresDto autor;
            public DTOgrados dtogrados = null;
            public List<DTOgrados> grados;

            public Manejador(ContextoAutor context)
            {
                this.context = context;
            }

            public async Task<List<AutoresDto>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                var autores = await this.context.AutorLibro.Include(d => d.ListaGradoAcademico).ToListAsync();
                dto = new List<AutoresDto>();
                grados = new List<DTOgrados>();
                foreach (var item in autores)
                {
                    if (item.ListaGradoAcademico != null)
                    {
                        foreach (var G in item.ListaGradoAcademico)
                        {
                            dtogrados = new DTOgrados();
                            dtogrados.GradoAcademicoId = G.GradoAcademicoId;
                            dtogrados.Nombre = G.Nombre;
                            dtogrados.CentroAcademico = G.CentroAcademico;
                            dtogrados.FechaGrado = G.FechaGrado;
                            dtogrados.GradoAcademicoGuid = G.GradoAcademicoGuid;
                            grados.Add(dtogrados);
                        }
                    }
                    autor = new AutoresDto();
                    autor.AutorLibroId = item.AutorLibroId;
                    autor.Nombre = item.Nombre;
                    autor.Apellido = item.Apellido;
                    autor.FechadeNacimiento = item.FechadeNacimiento;
                    autor.AutorLibroGuid = item.AutorLibroGuid;
                    autor.Grado = grados;
                    dto.Add(autor);
                  
                }
                return dto;
            }
        }
    }
}