using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.Context;
using TiendaServicios.Api.CarritoCompra.DTOS;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
    public class Query
    {
        public class ListaSesion : IRequest<List<CarritoSesionDTO>> { }

        public class Manejador : IRequestHandler<ListaSesion, List<CarritoSesionDTO>>
        {
            private readonly ContextoCarrito context;
            public List<CarritoSesionDTO> dto;
            public CarritoSesionDTO sesion;
            public CarritoDetalleDTO dtoDetalle = null;
            public List<CarritoDetalleDTO> DetalleList;

            public Manejador(ContextoCarrito context)
            {
                this.context = context;
            }

            public async Task<List<CarritoSesionDTO>> Handle(ListaSesion request, CancellationToken cancellationToken)
            {
                var carrito = await this.context.CarritoSesion.Include(d => d.ListaCarritoSesionDetalle).ToListAsync();
                dto = new List<CarritoSesionDTO>();
                DetalleList = new List<CarritoDetalleDTO>();
                foreach (var item in carrito)
                {
                    if (item.ListaCarritoSesionDetalle != null)
                    {
                        foreach (var G in item.ListaCarritoSesionDetalle)
                        {
                            dtoDetalle = new CarritoDetalleDTO();
                            dtoDetalle.Id = G.CarritoSesionDetalleId;
                            dtoDetalle.Fecha = G.FechaCreacion;
                            dtoDetalle.Productos = G.ProductoSelecionado;
                            dtoDetalle.Guid = G.CarritoSesionDetalleGuid;
                            DetalleList.Add(dtoDetalle);
                        }
                    }
                    sesion = new CarritoSesionDTO();
                    sesion.id = item.CarritoSesionId;
                    sesion.Fecha = item.FechaCreacion;
                    sesion.CarritoDetalle = DetalleList;
                    sesion.Guid = item.CarritoSesionGuid;
                    dto.Add(sesion);
                  
                }
                return dto;
            }
        }
    }
}