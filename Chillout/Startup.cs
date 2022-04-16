using Chillout.BusinesLogic.Core.Interfaces;
using Chillout.BusinesLogic.Services;
using Chillout.DataAccess.Context;
using Chillout.DataAccess.Core.Interfaces.DbContext;
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
            services.AddDbContext<IDbContext, DbContext1>(b => b.UseSqlite("Data Sourse=userdata.db; Foreign Keys=True"));

            services.AddScoped<IUserService, UserService>();

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

            var dbContext = scope.ServiceProvider
                .GetRequiredService<DbContext1>();
            dbContext.Database.Migrate();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
