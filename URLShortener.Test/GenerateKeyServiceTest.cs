using KeyGenerationService.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using URLShortener.DAL;
using URLShortener.Models;

namespace URLShortener.Test
{
  [TestClass]
  public class GenerateKeyServiceTest
  {

    private Mock<IUnitOfWork> _MockUnitofWork;
    private TestData _TestData;
    private GenerateKeyService _service;
    private Mock<DbAll01ProdUswest001Context> _context;
    private Mock<DbSet<GeneratedKey>> _dbSet;

    [TestInitialize]
    public void Initialize()
    {
      _TestData = new TestData();
      _context = new Mock<DbAll01ProdUswest001Context>();
      _dbSet = new Mock<DbSet<GeneratedKey>>();
      _context.Setup(m => m.Set<GeneratedKey>()).Returns(_dbSet.Object);
      _MockUnitofWork.Setup(m => m.GeneratedKeyRepository).Returns(new Repository<GeneratedKey>(_context.Object));
      _MockUnitofWork = new Mock<IUnitOfWork>();
      _MockUnitofWork.Setup(m => m.Save()).Verifiable();
      _service = new GenerateKeyService(_MockUnitofWork.Object);
    }

    [TestMethod]
    public void GenerateKeysShouldSaveOnce()
    {
      Initialize();
      _service.Generate(10000);

      _MockUnitofWork.Verify(m => m.Save(), Times.Once());
    }
  }
}