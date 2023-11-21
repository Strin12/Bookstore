using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Libreria.Aplicacion;
using TiendaServicios.Api.Libreria.DTOS;
using TiendaServicios.Api.Libreria.Entities;

namespace TiendaServicios.Api.Libreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibreriaController : Controller
    {
        private readonly IMediator mediator;

        public LibreriaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await this.mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<LibreriaDTOS>>> GetAutores()
        {
            return await this.mediator.Send(new Query.ListaLibreria());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Librerias>> GetAutorLibro(string id)
        {
            return await this.mediator.Send(new QueryFilter.LibreriaUnica() { AutorGuid = id });
        }

    }
}