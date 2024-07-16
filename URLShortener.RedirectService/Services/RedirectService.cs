using System;
using System.Linq;
using URLShortener.DAL;

namespace URLShortener.RedirectService.Services
{
  public class RedirectService : IRedirectService
  {
    private IUnitOfWork _unitOfWork;
    public RedirectService(IUnitOfWork unitOfWork)
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
  }
}
