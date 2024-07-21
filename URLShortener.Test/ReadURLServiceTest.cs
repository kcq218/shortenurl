using Moq;
using URLShortener.DAL;
using URLShortener.Models;
using URLShortener.ReadService.Services;
using URLShortener.Test;

namespace URLShortener.KeyGenerationServiceTest
{
  [TestClass]
  public class ReadURLServiceTest
  {

    private Mock<IUnitOfWork> _MockUnitofWork;
    private TestData _TestData;

    [TestInitialize]
    public void Initialize()
    {
      _TestData = new TestData();
      _MockUnitofWork = new Mock<IUnitOfWork>();

      _MockUnitofWork.Setup(m => m.UrlMappingRepository.GetAll()).Returns(new List<UrlMapping>() { _TestData.githubURLMapping() });
    }

    [TestMethod]
    public void ReadServiceShouldReturnURLBadFormat()
    {
      Initialize();
      var readURLService = new ReadURLService(_MockUnitofWork.Object);
      var result = readURLService.GetURLHash(_TestData.InvalidUrlFormat());

      Assert.AreEqual(_TestData.InvalidURLFormatMessage(), result);
    }

    [TestMethod]
    public void ReadServiceShouldReturnGitHub()
    {
      Initialize();
      var readURLService = new ReadURLService(_MockUnitofWork.Object);
      var result = readURLService.GetURLHash(_TestData.GitHubUrl());

      Assert.AreEqual(_TestData.githubURLMapping().HashValue, result);
    }

    [TestMethod]
    public void ReadServiceShouldReturnNoURLFound()
    {
      Initialize();
      var readURLService = new ReadURLService(_MockUnitofWork.Object);
      var result = readURLService.GetURLHash(_TestData.NotFoundURL());

      Assert.AreEqual(_TestData.NotFoundURLMessage(), result);
    }
  }
}