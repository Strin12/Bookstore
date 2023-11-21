using System.Collections.Generic;
using System.Linq;
using TiendaServicios.Api.Login.DTOS;
using FluentValidation;

using Microsoft.EntityFrameworkCore;
using MediatR;
using TiendaServicios.Api.Login.Entities;
using TiendaServicios.Api.Login.Context;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using TiendaServicios.Api.Login.JWTLogic;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace TiendaServicios.Api.Login.Aplicacion
{

    public class Logeo
    {
        public class Logearse : IRequest<UsuariosDTO>{

            public string Email { get; set; }
            public string Password { get; set; }
        }
        public class EjecutaValidation : AbstractValidator<Logearse>
        {
            public EjecutaValidation()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<Logearse, UsuariosDTO>
        {

            private readonly ContextoUsuario context;
            private readonly IJwtGenerator _jwtGenerator;
            public List<UsuariosDTO> dto;
            public UsuariosDTO usuariodto;

            public Manejador(ContextoUsuario context,IJwtGenerator jwtGenerator)
            {
                this.context = context;
                this._jwtGenerator = jwtGenerator;
            }
            public async Task<UsuariosDTO> Handle(Logearse request, CancellationToken cancellationToken)
            {
                var datos = await this.context.Usuarios.Where(x => x.email.Equals(request.Email)).Where(p => p.password.Equals(request.Password)).FirstOrDefaultAsync();

                if (datos == null)
                {
                    throw new Exception("El usuario no existe");
                }
                dto = new List<UsuariosDTO>();
                while (datos != null)
                {
                    usuariodto = new UsuariosDTO();
                    usuariodto.Id = datos.UsuariosId;
                    usuariodto.user = datos.username;
                    usuariodto.email = datos.email;
                    usuariodto.password = datos.password;
                    usuariodto.Guid = datos.UsuarioGuid;
                    usuariodto.token = this._jwtGenerator.CreateToken(datos);
                    dto.Add(usuariodto);
                    var logeo = dto.ToArray();
                    return logeo.FirstOrDefault();
                    break;
                }
                
                throw new Exception("Login incorrecto");

            }
        }



    }
}
