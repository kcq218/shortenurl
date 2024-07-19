using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using URLShortener.RedirectService.Services;

namespace URLShortener.RedirectService
{
  public class RedirectURLFunction
  {
    private readonly IRedirectService _redirectService;
    private readonly ILogger<RedirectURLFunction> _logger;
    public RedirectURLFunction(IRedirectService redirectService, ILogger<RedirectURLFunction> logger)
    {
      _redirectService = redirectService;
      _logger = logger;
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

          if (result.Length > 0)
          {
            return new RedirectResult(result);
          }
        }

        return new OkObjectResult("no url found");
      }
      catch (Exception e)
      {
        _logger.LogError(e.ToString());

        return new OkObjectResult(e.ToString());

      }
    }
  }
}
