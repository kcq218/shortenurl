using System;
using System.Linq;
using URLShortener.DAL;
using URLShortener.Models;

namespace KeyGenerationService.Services
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
        Grab top 1 active key that are active 
        create url mapping
        associate it with key
        turn key inactive after association
       */

      if (url.Length > 0)
      {
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

        var createdurl = Constants.RedirectServiceEndpoint + urlMapping.HashValue;

        return createdurl;
      }
      return "length of url is 0";
    }
  }
}
