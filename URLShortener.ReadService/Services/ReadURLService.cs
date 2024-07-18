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

    public string GetRedirectURL(string hash)
    {

      if (hash.Length > 0)
      {
        var urlMapping = _unitOfWork.UrlMappingRepository.GetAll().Where(m => m.HashValue == hash).First();
        urlMapping.LastAccessed = DateTime.Now;
        _unitOfWork.Save();

        return urlMapping.LongUrl;
      }
      return "length of input is 0";
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

        return "no url found";
      }

      return "url is not in correct format, please try again";
    }
  }
}
