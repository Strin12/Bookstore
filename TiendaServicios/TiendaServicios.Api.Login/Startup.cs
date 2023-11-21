using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TiendaServicios.Api.Login.Aplicacion;
using TiendaServicios.Api.Login.Context;
using TiendaServicios.Api.Login.JWTLogic;

namespace TiendaServicios.Api.Login
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Nuevo>());
           // services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Logeo>());

            services.AddDbContext<ContextoUsuario>(options =>
            {
                //va al json y buscara el conexionDatabase
                options.UseNpgsql(Configuration.GetConnectionString("ConexionDatabase"));
            });

            services.AddMediatR(typeof(Nuevo.Manejador).Assembly);
            //services.AddMediatR(typeof(Logeo.UsuarioLoginCommand).Assembly);

            services.AddScoped<IJwtGenerator, JwtGenerator>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
