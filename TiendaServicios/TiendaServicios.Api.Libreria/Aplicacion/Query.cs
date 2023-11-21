using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TiendaServicios.Api.Libreria.DTOS;
using TiendaServicios.Api.Libreria.Aplicacion;
using TiendaServicios.Api.Libreria.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace TiendaServicios.Api.Libreria.Aplicacion
{
    public class Query
    {
        public class ListaLibreria : IRequest<List<LibreriaDTOS>> { }

        public class Manejador : IRequestHandler<ListaLibreria, List<LibreriaDTOS>>
        {
            private readonly ContextoLibreria context;
            public List<LibreriaDTOS> dto;
            public LibreriaDTOS Libreria;


            public Manejador(ContextoLibreria context)
            {
                this.context = context;
            }

            public async Task<List<LibreriaDTOS>> Handle(ListaLibreria request, CancellationToken cancellationToken)
            {
                var librerias = await this.context.Librerias.ToListAsync();
                dto = new List<LibreriaDTOS>();
                foreach (var item in librerias)
                {
                    Libreria = new LibreriaDTOS();
                    Libreria.Id = item.LibreriasId;
                    Libreria.Titulo = item.TituloLibro;
                    Libreria.Fecha = item.FechaPublicacion;
                    Libreria.Autor = item.AutorLibro;
                    Libreria.Guid = item.LibreriaGuid;
                    dto.Add(Libreria);

                }
                return dto;
            }
        }
    }
}