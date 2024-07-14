using KeyGenerationService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;

namespace URLShortener.KeyGenerationService
{
  public class KGSFunction
  {
    private readonly IGenerateKeyService _generateKeyService;
    public KGSFunction(IGenerateKeyService generateKeyService)
    {
      _generateKeyService = generateKeyService;
    }

    [Function("KGSFunction")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req)
    {
      //log.LogInformation("C# HTTP trigger function processed a request.");

      //string name = req.Query["name"];

      string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
      //dynamic data = JsonConvert.DeserializeObject(requestBody);
      //name = name ?? data?.name;

      _generateKeyService.Generate(10000);
      string responseMessage = "Successfully Triggered Function";

      return new OkObjectResult(responseMessage);
    }
  }
}