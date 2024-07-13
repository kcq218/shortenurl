using KeyGenerationService.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using URLShortener.Models;
using URLShortener.DAL;

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
    })
    .Build();

host.Run();
