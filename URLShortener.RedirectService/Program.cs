using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using URLShortener.DAL;
using URLShortener.Models;
using URLShortener.RedirectService;
using URLShortener.RedirectService.Services;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
      services.AddApplicationInsightsTelemetryWorkerService();
      services.ConfigureFunctionsApplicationInsights();
      services.AddScoped<IUnitOfWork, UnitOfWork>();
      services.AddScoped<IRepository<GeneratedKey>, Repository<GeneratedKey>>();
      services.AddScoped<IRepository<UrlMapping>, Repository<UrlMapping>>();
      services.AddScoped<IRepository<UserInfo>, Repository<UserInfo>>();
      services.AddScoped<IRedirectService, RedirectService>();
      services.AddScoped<ILogger<RedirectURLFunction>, Logger<RedirectURLFunction>>();
    })
    .Build();

host.Run();
