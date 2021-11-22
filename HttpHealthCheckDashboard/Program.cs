using Arc.HttpHealthCheckDashboard.DI;
using HttpHealthCheckDashboard;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpHealthCheckDashboard(builder.Configuration);
builder.Services.AddHealthChecksUrls();
builder.Services.AddHealthChecksUI().AddInMemoryStorage();

WebApplication app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseRouting();
app.UseHealthChecksUI(config => config.UIPath = "/hc-ui");
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecksUrls();
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Hello World!");
    });
});

app.Run();