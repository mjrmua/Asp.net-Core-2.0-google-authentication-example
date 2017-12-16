using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;

namespace GoogleAuthExample
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
            services.AddIdentity<IdentityUser, IdentityRole>();

            services.AddAuthentication(
                    v =>
                    {
                        v.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
                        v.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
                    }).AddGoogle(googleOptions =>
                    {
                        // TODO: fill in your client id and secret
                        googleOptions.ClientId = "CLIENT ID";
                        googleOptions.ClientSecret = "CLIENT SECRET";
                    });
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication()
               .UseMvc();
        }
    }
}
