using Meteoro.API.Core.Interfaces;
using Meteoro.API.Infrastructure.Data;
using Meteoro.API.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Meteoro.API
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
            services.AddDbContext<db_meteorocosechaContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("SqlConnectionPublicTest")));

            services.AddTransient<IAdminRepository,AdminRepository>();
            services.AddTransient<IAreaRepository,AreaRepository>();
            services.AddTransient<IAseguradorEmpleadoRepository,AseguradorEmpleadoRepository>();
            services.AddTransient<ICosechaRepository,CosechaRepository>();
            services.AddTransient<IEmpleadoRepository,EmpleadoRepository>();
            services.AddTransient<IEmpresaRepository,EmpresaRepository>();
            services.AddTransient<IModalidadRepository,ModalidadRepository>();
            services.AddTransient<IRegistroRepository,RegistroRepository>();
            services.AddTransient<ISemanaRepository,SemanaRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
