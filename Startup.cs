using ControlDeCitas.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlDeCitas
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ControlDeCitas", Version = "v1" });
            });

            services.AddDbContext<CitasContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            services.AddDbContext<ClientesContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            services.AddDbContext<DepartamentoResponsableContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            services.AddDbContext<EmpresaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            services.AddDbContext<EstatusDeLaAtencionContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            services.AddDbContext<ResponsableContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            services.AddDbContext<TipoDeCitaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ControlDeCitas v1"));
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
