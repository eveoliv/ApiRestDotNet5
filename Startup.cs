using AppNetCore5.Domain;
using AppNetCore5.Repository;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppNetCore5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore();
            services.AddControllers();
            services.AddApiVersioning();
            services.AddSingleton<IRepository<Cliente>, RepositoryBase<Cliente>>();
            services.AddSingleton<IRepository<Funcionario>, RepositoryBase<Funcionario>>();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "AppNetCore5", Version = "v1" });});
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "1.0"));
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
