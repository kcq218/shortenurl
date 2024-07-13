using System;
using URLShortener.DAL;

namespace KeyGenerationService.Services
{
  public class CreateURLService : ICreateURLService
  {
    private IUnitOfWork _unitOfWork;
    public CreateURLService(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public void CreateURL(string url)
    {
      throw new NotImplementedException();
    }
  }
}
