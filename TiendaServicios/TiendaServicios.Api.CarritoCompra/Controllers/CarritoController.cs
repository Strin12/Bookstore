using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.CarritoCompra.Aplicacion;
using TiendaServicios.Api.CarritoCompra.DTOS;
using TiendaServicios.Api.CarritoCompra.Entities;

namespace TiendaServicios.Api.CarritoCompra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : Controller
    {

        private readonly IMediator mediator;

        public CarritoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await this.mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<CarritoSesionDTO>>> GetCarrito()
        {
            return await this.mediator.Send(new Query.ListaSesion());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarritoSesion>> GetSesion(string id)
        {
            return await this.mediator.Send(new QueryFilter.SesionUnica() { CarritoSesionDetalleGuid = id });
        }

    }
}
