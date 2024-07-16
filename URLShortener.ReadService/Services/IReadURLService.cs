namespace URLShortener.ReadService.Services
{
  public interface IReadURLService
  {
    string GetURLHash(string url);
  }
}
