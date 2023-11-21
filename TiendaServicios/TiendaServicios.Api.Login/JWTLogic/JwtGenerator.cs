using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using TiendaServicios.Api.Login.Entities;
namespace TiendaServicios.Api.Login.JWTLogic
{
    public class JwtGenerator : IJwtGenerator
    {
        public string CreateToken(Usuarios usuario)
        {
            var claims = new List<Claim>
            {
                new Claim("username", usuario.username),
                new Claim("email", usuario.email),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1C1CEC42C4F47A9D1E26262C6B64C"));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(3),
                SigningCredentials = credential
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}
