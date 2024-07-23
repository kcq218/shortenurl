using Moq;
using URLShortener.CreateService.Services;
using URLShortener.DAL;
using URLShortener.Models;

namespace URLShortener.Test
{
  [TestClass]
  public class CreateURLServiceTest
  {

    private Mock<IUnitOfWork> _MockUnitofWork;
    private TestData _TestData;
    private CreateURLService _service;

    [TestInitialize]
    public void Initialize()
    {
      _TestData = new TestData();
      _MockUnitofWork = new Mock<IUnitOfWork>();

      _MockUnitofWork.Setup(m => m.UrlMappingRepository.GetAll()).Returns(new List<UrlMapping>() { _TestData.GithubURLMapping() });
      _MockUnitofWork.Setup(m => m.GeneratedKeyRepository.GetAll()).Returns(new List<GeneratedKey>() { _TestData.GeneratedKey() });
      _MockUnitofWork.Setup(m => m.Save()).Verifiable();
      _service = new CreateURLService(_MockUnitofWork.Object);
    }

    [TestMethod]
    public void CreateURLShouldSaveTwice()
    {
      Initialize();
      var result = _service.CreateURL(_TestData.GitHubUrl());

      _MockUnitofWork.Verify(m => m.Save(), Times.AtMost(2));
    }

    [TestMethod]
    public void CreateURLShouldReturnHash()
    {
      Initialize();
      var result = _service.CreateURL(_TestData.GitHubUrl());

      Assert.AreEqual(_TestData.GeneratedKey().HashValue, result);
    }

    [TestMethod]
    public void ReadServiceShouldReturnURLBadFormat()
    {
      Initialize();
      var result = _service.CreateURL(_TestData.InvalidUrlFormat());

      Assert.AreEqual(_TestData.InvalidURLFormatMessage(), result);
    }
  }
}