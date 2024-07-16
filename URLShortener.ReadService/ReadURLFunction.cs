using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace URLShortener.ReadService
{
  public class ReadURLFunction
  {
    private readonly ILogger<ReadURLFunction> _logger;

    public ReadURLFunction(ILogger<ReadURLFunction> logger)
    {
      _logger = logger;
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
        return new OkObjectResult("empty body request");
      }
      catch (Exception e)
      {
        return new OkObjectResult(e.Message);

      }
    }
  }
}
