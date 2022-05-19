using Chillout.BusinesLogic.Core.Interfaces;
using Chillout.BusinesLogic.Services;
using Chillout.DataAccess.Context;
using Chillout.DataAccess.Core.Interfaces.DbContext1;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Chillout
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
            services.AddDbContext<IDbContext, DbContext1>(b => b.UseSqlite("Data Source=data.db; Foreign Keys=True"));
            services.AddDbContext<DbContext1>(b => b.UseSqlite("Data Source=data.db; Foreign Keys=True"));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPassListService, PassListService>();

            services.AddControllers();
            services.AddCors();

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

            using var scope = app.ApplicationServices.CreateScope();

            var dbContext1 = scope.ServiceProvider
                .GetRequiredService<DbContext1>();
            dbContext1.Database.Migrate();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
