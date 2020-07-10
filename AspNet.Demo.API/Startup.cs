using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNet.Demo.API.Authentication;
using AspNet.Demo.API.EF;
using iCubed.AspNetCore.BasicAuthentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNet.Demo.API
{

    // TODO: add Basic Authentication 
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

            services.AddSingleton<IAuthenticationService, AuthenticationService>();

            services
                .AddAuthentication(o => o.DefaultScheme = BasicAuthenticationOptions.Scheme)
                .AddBasicAuthentication();

            services.AddDbContext<TicketContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TicketingDb")));
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

            // ASP.NET CORE 3 requires BOTH the following lines in order to support the [Authorize] attribute
            // [AllowAnonymous] is not required for Controllers that do not require authentication / Authorization
            //              use it only for forcing anonymous access to specific action inside a COntroller marked with [Authorize]

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
