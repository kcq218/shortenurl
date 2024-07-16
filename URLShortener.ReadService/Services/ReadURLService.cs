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
      /*
        Grab top 1 active key that are active 
        create url mapping
        associate it with key
        turn key inactive after association
       */

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
        return Constants.RedirectServiceEndpoint + _unitOfWork.UrlMappingRepository.GetAll().Where(m => m.LongUrl == url).First().HashValue;
      }

      return "url is not in correct format, please try again";
    }
  }
}
