using URLShortener.Models;

namespace URLShortener.Test
{
  public class TestData
  {
    public UrlMapping GithubURLMapping()
    {
      return new UrlMapping()
      {
        Id = 1,
        KeyId = 1,
        Active = true,
        LastAccessed = DateTime.Now,
        CreatedBy = "mock",
        CreatedDate = DateTime.Now,
        HashValue = "abc123",
        LongUrl = "https://github.com/",
        UpdatedBy = "mock",
        UpdatedDate = DateTime.Now,
        UserId = 1
      };
    }
    public GeneratedKey GeneratedKey()
    {
      return new GeneratedKey()
      {
        
        Id = 1,
        UrlId = 1,
        Active = true,
        CreatedBy = "mock",
        CreatedDate = DateTime.Now,
        HashValue = "abc123",
        UpdatedBy = "mock",
        UpdatedDate = DateTime.Now
      };
    }
    public string InvalidURLFormatMessage()
    {
      return Globals.URLIsNotInCorrectFormatMessage;
    }

    public string GithubRedirectURL()
    {
      return "https://urlrdi.azurewebsites.net/api/rdi/abc123";
    }

    public string GitHubUrl()
    {
      return "https://github.com/";
    }

    public string InvalidUrlFormat()
    {
      return "github.com";
    }

    public string NotFoundURL()
    {
      return "https://www.playstation.com/en-us/ps5/";
    }

    public string NotFoundURLMessage()
    {
      return Globals.NoURLFound;
    }

    public string InvlidHashCode()
    {
      return "bad123";
    }

  }
}
