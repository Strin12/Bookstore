using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.CarritoCompra.Entities;

namespace TiendaServicios.Api.CarritoCompra.Context
{
    public class ContextoCarrito: DbContext
    {
        //para crear un contexto autor 1 se crea db context y manda a llamar el contructor db context y lo pasa algo de opsion que toma de la configuracion Entity de la conexion 
        public ContextoCarrito(DbContextOptions<ContextoCarrito> options) : base(options) { }
        //convertir entidades a tablas 
        public DbSet<CarritoSesion> CarritoSesion { get; set; }
        public DbSet<CarritoSesionDetalle> CarritoSesionDetalle { get; set; }
    }
}