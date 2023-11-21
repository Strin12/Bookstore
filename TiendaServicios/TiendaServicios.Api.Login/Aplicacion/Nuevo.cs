using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TiendaServicios.Api.Login.DTOS;
using TiendaServicios.Api.Login.Context;
using System.Threading;
using FluentValidation;
using TiendaServicios.Api.Login.Entities;
using TiendaServicios.Api.Login.JWTLogic;
using Microsoft.EntityFrameworkCore;

namespace TiendaServicios.Api.Login.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : UsuariosDTO, IRequest { }

        public class EjecutaValidation : AbstractValidator<Ejecuta>
        {
            public EjecutaValidation()
            {
                RuleFor(x => x.user).NotEmpty();
                RuleFor(x => x.email).NotEmpty();
                RuleFor(x => x.password).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            public readonly ContextoUsuario context;
            private readonly IJwtGenerator _JwGenerator;

            public Manejador(ContextoUsuario context, IJwtGenerator _JwGenerator)
            {
                this.context = context;
                this._JwGenerator = _JwGenerator;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var usuario = new Usuarios()
                {
                    username = request.user,
                    email = request.email,
                    password = request.password,
                    UsuarioGuid = Guid.NewGuid().ToString()
                };
                
                this.context.Usuarios.Add(usuario);
                var token = _JwGenerator.CreateToken(usuario);

                var response = await this.context.SaveChangesAsync();

                return response > 0 ? Unit.Value : throw new Exception("Error al insertar");
            }
        }
    }
}