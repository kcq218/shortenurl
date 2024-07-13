using URLShortener.Models;
namespace URLShortener.DAL
{
  public interface IUnitOfWork : IDisposable
  {
    public IRepository<GeneratedKey> GeneratedKeyRepository { get; }
    public IRepository<UrlMapping> UrlMappingRepository { get; }
    public IRepository<UserInfo> UserInfoRepository { get; }
    public void Save();
    public void Dispose(bool disposing);
  }
}
