using KeyGenerationService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using URLShortener.Models;

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

      try
      {
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

        _generateKeyService.Generate(Globals.MaximumKeys);
        string responseMessage = "Successfully Triggered Function";

        return new OkObjectResult(responseMessage);
      }
      catch (Exception e)
      {
        return new OkObjectResult(e.ToString());
      }
    }
  }
}