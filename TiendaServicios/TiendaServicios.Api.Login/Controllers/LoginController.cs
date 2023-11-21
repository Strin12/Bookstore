using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Login.Aplicacion;
using TiendaServicios.Api.Login.DTOS;
using TiendaServicios.Api.Login.Entities;

namespace TiendaServicios.Api.Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IMediator mediator;

        public LoginController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await this.mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuariosDTO>>> GetUsuario()
        {
            return await this.mediator.Send(new Query.ListaUsuarios());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUsuarioId(string id)
        {
            return await this.mediator.Send(new QueryFilter.UsuarioUnico() { UsuarioGuid = id });
        }
        [HttpPost("logearse")]
        public async Task<ActionResult<UsuariosDTO>> logearse(Logeo.Logearse data)
        {
            return await this.mediator.Send(data);
        }
    }
}