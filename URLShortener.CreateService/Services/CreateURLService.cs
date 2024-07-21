using System;
using System.Linq;
using URLShortener.DAL;
using URLShortener.Models;

namespace URLShortener.CreateService.Services
{
  public class CreateURLService : ICreateURLService
  {
    private IUnitOfWork _unitOfWork;
    public CreateURLService(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public string CreateURL(string url)
    {
      /*
        check if url is in correct format
        check for existing url if so return url
        check if maximum keys have been used
        if not continue
        grab top 1 active key that are active 
        create url mapping
        associate it with key
        turn key inactive after association
       */

      Uri uriResult;
      bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
          && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

      if (result)
      {

        var exists = _unitOfWork.UrlMappingRepository.GetAll().Where(m => m.LongUrl == url).FirstOrDefault();

        if (exists != null)
        {
          return Globals.RedirectServiceEndpoint + exists.HashValue;
        }


        var usedkeys = _unitOfWork.GeneratedKeyRepository
          .GetAll().Where(m => m.UrlId is not null
          && m.Active == false).Count();

        if (usedkeys >= Globals.MaximumKeys)
        {
          return Globals.MaximumURLsCreated;
        }

        var availableKey = _unitOfWork.GeneratedKeyRepository
        .GetAll().Where(m => m.UrlId is null
        && m.Active == true).First();

        var urlMapping = new UrlMapping();
        urlMapping.UserId = 1;
        urlMapping.KeyId = availableKey.Id;
        urlMapping.HashValue = availableKey.HashValue;
        urlMapping.LongUrl = url;
        urlMapping.CreatedBy = "droopy";
        urlMapping.CreatedDate = DateTime.Now;
        urlMapping.UpdatedBy = "droopy";
        urlMapping.UpdatedDate = DateTime.Now;
        urlMapping.Active = true;
        _unitOfWork.UrlMappingRepository.Add(urlMapping);
        _unitOfWork.Save();

        availableKey.UrlId = urlMapping.Id;
        availableKey.Active = false;
        availableKey.UpdatedBy = "droopy";
        availableKey.UpdatedDate = DateTime.Now;
        _unitOfWork.GeneratedKeyRepository.Update(availableKey);
        _unitOfWork.Save();

        var createdurl = Globals.RedirectServiceEndpoint + urlMapping.HashValue;

        return createdurl;
      }
      return Globals.URLIsNotInCorrectFormatMessage;
    }
  }
}
