using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libreria.Entities;

namespace TiendaServicios.Api.Libreria.Context
{
    public class ContextoLibreria: DbContext
    {
        //para crear un contexto autor 1 se crea db context y manda a llamar el contructor db context y lo pasa algo de opsion que toma de la configuracion Entity de la conexion 
        public ContextoLibreria(DbContextOptions<ContextoLibreria> options) : base(options) { }
        //convertir entidades a tablas 
        public DbSet<Librerias> Librerias { get; set; }
    }
}
