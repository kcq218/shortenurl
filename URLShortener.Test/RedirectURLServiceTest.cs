using Moq;
using URLShortener.DAL;
using URLShortener.Models;

namespace URLShortener.Test
{
  [TestClass]
  public class RedirectURLServiceTest
  {

    private Mock<IUnitOfWork> _MockUnitofWork;
    private TestData _TestData;
    private URLShortener.RedirectService.Services.RedirectService _service;

    [TestInitialize]
    public void Initialize()
    {
      _TestData = new TestData();
      _MockUnitofWork = new Mock<IUnitOfWork>();

      _MockUnitofWork.Setup(m => m.UrlMappingRepository.GetAll()).Returns(new List<UrlMapping>() { _TestData.GithubURLMapping() });
      _MockUnitofWork.Setup(m => m.Save()).Verifiable();
      _service = new RedirectService.Services.RedirectService(_MockUnitofWork.Object);
    }

    [TestMethod]
    public void GetRedirectURLShouldReturnEmptyURLForEmptyString()
    {
      Initialize();
      var result = _service.GetRedirectURL(string.Empty);

      Assert.AreEqual(string.Empty, result);
      _MockUnitofWork.Verify(m => m.Save(), Times.Never);

    }

    [TestMethod]
    public void GetRedirectURLShouldSaveOnce()
    {
      Initialize();
      var result = _service.GetRedirectURL(_TestData.GithubURLMapping().HashValue);

      _MockUnitofWork.Verify(m => m.Save(), Times.Once);
    }

    [TestMethod]
    public void GetRedirectURLShouldRedirectURL()
    {
      Initialize();
      var result = _service.GetRedirectURL(_TestData.GithubURLMapping().HashValue);

      Assert.AreEqual(_TestData.GitHubUrl(), result);
    }

    [TestMethod]
    public void GetRedirectURLShouldReturnEmptyURLForUnfoundHash()
    {
      Initialize();
      var result = _service.GetRedirectURL(_TestData.InvlidHashCode());

      Assert.AreEqual(string.Empty, result);
      _MockUnitofWork.Verify(m => m.Save(), Times.Never);
    }
  }
}