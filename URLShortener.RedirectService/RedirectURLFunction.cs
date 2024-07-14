using KeyGenerationService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace URLShortener.RedirectService
{
  public class RedirectURLFunction
  {
    private readonly IRedirectService _redirectService;
    public RedirectURLFunction(IRedirectService redirectService)
    {
      _redirectService = redirectService;
    }

    [Function("rdi")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "rdi/{hash}")] HttpRequest req, string hash)
    {
      try
      {
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        dynamic data = JsonConvert.DeserializeObject(requestBody);

        var hashOfUrl = hash;

        if (hashOfUrl != null)
        {
          var result = _redirectService.GetRedirectURL(hashOfUrl);
          return new RedirectResult(result);
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
