using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using URLShortener.ReadService.Services;

namespace URLShortener.ReadService
{
  public class ReadURLFunction
  {
    private readonly ILogger<ReadURLFunction> _logger;
    private IReadURLService _readURLService;

    public ReadURLFunction(ILogger<ReadURLFunction> logger, IReadURLService readURLService)
    {
      _logger = logger;
      _readURLService = readURLService;
    }

    [Function("read")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
      try
      {

        string url = req.Query["url"];

        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        dynamic data = JsonConvert.DeserializeObject(requestBody);
        url = url ?? data?.url;

        if (!string.IsNullOrWhiteSpace(url))
        {
          return new OkObjectResult(_readURLService.GetURLHash(url));
        }

        return new OkObjectResult("empty body request");
      }
      catch (Exception e)
      {
        return new OkObjectResult(e.Message);

      }
    }
  }
}
