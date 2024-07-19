using KeyGenerationService.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using URLShortener.DAL;
using URLShortener.KeyGenerationService;
using URLShortener.Models;

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
      services.AddScoped<IGenerateKeyService, GenerateKeyService>();
      services.AddScoped<ILogger<KGSFunction>, Logger<KGSFunction>>();
    })
    .Build();

host.Run();
