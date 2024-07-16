namespace URLShortener.RedirectService.Services
{
  public interface IRedirectService
  {
    string GetRedirectURL(string url);
  }
}
