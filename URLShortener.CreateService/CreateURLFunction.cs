using KeyGenerationService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace URLShortener.CreateService
{
  public class CreateURLFunction
  {
    private ICreateURLService _createURLService;
    public CreateURLFunction(ICreateURLService createURLService)
    {
      _createURLService = createURLService;
    }

    [Function("CreateURLFunction")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req)
    {
      //log.LogInformation("C# HTTP trigger function processed a request.");

      string url = req.Query["url"];

      string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
      dynamic data = JsonConvert.DeserializeObject(requestBody);
      url = url ?? data?.url;

      var redirectUrl = _createURLService.CreateURL(url);

      return new OkObjectResult(redirectUrl);
    }
  }
}