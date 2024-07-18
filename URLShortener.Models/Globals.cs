namespace URLShortener.Models
{
  public static class Globals
  {
    public static string RedirectServiceEndpoint = Environment.GetEnvironmentVariable("RedirectServiceEndpoint");
    public static int MaximumKeys = 1000;
  }
}
