using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TacsofonObj.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
using TacsofonObj.ApplicationServices.GetPlatnostListUseCase;
using TacsofonObj.ApplicationServices.Ports.Gateways.Database;
using TacsofonObj.ApplicationServices.Repositories;
using TacsofonObj.DomainObjects.Ports;

namespace TacsofonObj.WebService
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
            services.AddDbContext<TacsofonObjContext>(opts => 
                opts.UseSqlite($"Filename={System.IO.Path.Combine(System.Environment.CurrentDirectory, "TacsofonObj.db")}")
            );

            services.AddScoped<ITacsofonObjDatabaseGateway, TacsofonObjEFSqliteGateway>();

            services.AddScoped<DbTacsofonObjRepository>();
            services.AddScoped<IReadOnlyTacsofonObjRepository>(x => x.GetRequiredService<DbTacsofonObjRepository>());
            services.AddScoped<ITacsofonObjRepository>(x => x.GetRequiredService<DbTacsofonObjRepository>());


            services.AddScoped<IGetTacsofonObjListUseCase, GetTacsofonObjListUseCase>();

            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}