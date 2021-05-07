using ArnabDeveloper.HttpHealthCheck;
using HealthChecks.UI.Client;
using HttpHealthCheckDashboard.HealthChecks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;

namespace HttpHealthCheckDashboard
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddHttpClient()
                .AddTransient(typeof(IHealthCheck), typeof(HealthCheck))
                .AddTransient(typeof(ICommonHealthCheck), typeof(CommonHealthCheck))
                .AddTransient(options =>
                {
                    IEnumerable<IConfigurationSection> sections = Configuration.GetSection("ApiDetails").GetChildren();
                    List<ApiDetail> urlDetails = new();
                    for (var counter = 0; counter < sections.Count(); counter++)
                    {
                        urlDetails.Add(new ApiDetail
                        (
                            Configuration.GetValue<string>($"ApiDetails:{counter}:Name"),
                            Configuration.GetValue<string>($"ApiDetails:{counter}:Url"),
                            new ApiCredential
                            (
                                Configuration.GetValue<string>($"ApiDetails:{counter}:Credential:UserName"),
                                Configuration.GetValue<string>($"ApiDetails:{counter}:Credential:Password")
                            ),
                            Configuration.GetValue<bool>($"ApiDetails:{counter}:IsEnable")
                        ));
                    }
                    return urlDetails.AsEnumerable();
                })
                .AddHealthChecks()
                .AddCheck<MicrosoftHealthCheck>("Microsoft")
                .AddCheck<GoogleHealthCheck>("Google");

            services
                .AddHealthChecksUI()
                .AddInMemoryStorage();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseHealthChecksUI(config => config.UIPath = "/hc-ui");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/microsoft-hc", new HealthCheckOptions()
                {
                    Predicate = r => r.Name.Contains("Microsoft"),
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                endpoints.MapHealthChecks("/google-hc", new HealthCheckOptions()
                {
                    Predicate = r => r.Name.Contains("Google"),
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
