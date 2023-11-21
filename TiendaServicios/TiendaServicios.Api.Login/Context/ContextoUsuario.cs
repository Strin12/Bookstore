using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Login.Entities;

namespace TiendaServicios.Api.Login.Context
{
    public class ContextoUsuario: DbContext
    {
        public ContextoUsuario(DbContextOptions<ContextoUsuario> options) : base(options) { }
        //convertir entidades a tablas 
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
