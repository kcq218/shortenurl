using KeyGenerationService.Models;

namespace KeyGenerationService.DAL
{
  public class UnitOfWork : IUnitOfWork
  {
    private DbAll01ProdUswest001Context context = new DbAll01ProdUswest001Context();

    public IRepository<GeneratedKey> GeneratedKeyRepository => new Repository<GeneratedKey>(context);
    public IRepository<UrlMapping> UrlMappingRepository => new Repository<UrlMapping>(context);
    public IRepository<UserInfo> UserInfoRepository => new Repository<UserInfo>(context);

    public void Save()
    {
      context.SaveChanges();
    }

    private bool disposed = false;
    public void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
        {
          context.Dispose();
        }
      }
      this.disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
  }
}
