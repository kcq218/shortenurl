namespace URLShortener.Models
{
  public static class Globals
  {
    public static string RedirectServiceEndpoint = Environment.GetEnvironmentVariable("RedirectServiceEndpoint");
    public static int MaximumKeys = 1000;
    public static string MaximumURLsCreated = "Maximum urls created";
    public static string URLIsNotInCorrectFormatMessage = "url is not in correct format, please try again";
    public static string LengthOfInputIs0 = "length of input is 0";
    public static string NoURLFound = "length of input is 0";
  }
}
