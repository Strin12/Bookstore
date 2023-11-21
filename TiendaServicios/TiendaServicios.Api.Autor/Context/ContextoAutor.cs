using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Entities;

namespace TiendaServicios.Api.Autor.Context
{
    public class ContextoAutor: DbContext
    {
        //para crear un contexto autor 1 se crea db context y manda a llamar el contructor db context y lo pasa algo de opsion que toma de la configuracion Entity de la conexion 
        public ContextoAutor(DbContextOptions<ContextoAutor> options) : base(options) { }
        //convertir entidades a tablas 
        public DbSet<AutorLibro> AutorLibro { get; set; }
        public DbSet<GradoAcademico> GradoAcademico { get; set; }
    }
}
