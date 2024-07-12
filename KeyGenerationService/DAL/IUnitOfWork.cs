using KeyGenerationService.Models;
namespace KeyGenerationService.DAL
{
  public interface IUnitOfWork : IDisposable
  {
    public IRepository<GeneratedKey> GeneratedKeyRepository { get; }
    public IRepository<UrlMapping> UrlMappingRepository { get; }
    public IRepository<UserInfo> UserInfoRepository { get; }
  }
}
