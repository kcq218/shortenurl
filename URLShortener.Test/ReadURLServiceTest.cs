using Moq;
using URLShortener.DAL;
using URLShortener.Models;
using URLShortener.ReadService.Services;

namespace URLShortener.Test
{
  [TestClass]
  public class ReadURLServiceTest
  {

    private Mock<IUnitOfWork> _MockUnitofWork;
    private TestData _TestData;
    private ReadURLService _service;

    [TestInitialize]
    public void Initialize()
    {
      _TestData = new TestData();
      _MockUnitofWork = new Mock<IUnitOfWork>();

      _MockUnitofWork.Setup(m => m.UrlMappingRepository.GetAll()).Returns(new List<UrlMapping>() { _TestData.GithubURLMapping() });
      _MockUnitofWork.Setup(m => m.Save()).Verifiable();
      _service = new ReadURLService(_MockUnitofWork.Object);
    }

    [TestMethod]
    public void ReadServiceShouldReturnURLBadFormat()
    {
      Initialize();
      var result = _service.GetURLHash(_TestData.InvalidUrlFormat());

      Assert.AreEqual(_TestData.InvalidURLFormatMessage(), result);
    }

    [TestMethod]
    public void ReadServiceShouldReturnGitHub()
    {
      Initialize();
      var result = _service.GetURLHash(_TestData.GitHubUrl());

      Assert.AreEqual(_TestData.GithubURLMapping().HashValue, result);
    }

    [TestMethod]
    public void ReadServiceShouldReturnNoURLFound()
    {
      Initialize();
      var result = _service.GetURLHash(_TestData.NotFoundURL());

      Assert.AreEqual(_TestData.NotFoundURLMessage(), result);
    }
  }
}