using KeyGenerationService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using URLShortener.Models;

namespace URLShortener.KeyGenerationService
{
  public class KGSFunction
  {
    private readonly IGenerateKeyService _generateKeyService;
    private readonly ILogger<KGSFunction> _logger;
    public KGSFunction(IGenerateKeyService generateKeyService, ILogger<KGSFunction> logger)
    {
      _generateKeyService = generateKeyService;
      _logger = logger;
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
        _logger.LogError(e.ToString());

        return new OkObjectResult(e.ToString());
      }
    }
  }
}