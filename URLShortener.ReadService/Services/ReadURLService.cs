using URLShortener.DAL;
using URLShortener.Models;

namespace URLShortener.ReadService.Services
{
  public class ReadURLService : IReadURLService
  {
    private IUnitOfWork _unitOfWork;
    public ReadURLService(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public string GetURLHash(string url)
    {
      Uri uriResult;
      bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
          && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

      if (result)
      {
        var urlMapping = _unitOfWork.UrlMappingRepository.GetAll().Where(m => m.LongUrl == url).FirstOrDefault();

        if (urlMapping != null)
        {
          return Globals.RedirectServiceEndpoint + urlMapping.HashValue;
        }

        return Globals.NoURLFound;
      }

      return Globals.URLIsNotInCorrectFormatMessage;
    }
  }
}
