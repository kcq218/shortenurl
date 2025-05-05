namespace URLShortener.CreateService.Services
{
  public interface ICreateURLService
  {
    string CreateURL(string url, string clientId);
  }
}
