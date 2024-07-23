using URLShortener.DAL;
using URLShortener.Models;

namespace KeyGenerationService.Services
{
  public class GenerateKeyService : IGenerateKeyService
  {
    private IUnitOfWork _unitOfWork;
    public GenerateKeyService(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }
    public void Generate(int numberOfKeys)
    {
      var GeneratedKeysRepository = _unitOfWork.GeneratedKeyRepository;

      var seen = new HashSet<string>();

      for (int i = 0; i < numberOfKeys; i++)
      {
        var uniqueKey = Guid.NewGuid().ToByteArray();
        var result = Convert.ToBase64String(uniqueKey).Substring(0, 9)
            .Replace("/", "_")
            .Replace("+", "-");

        if (!seen.Contains(result))
        {
          var key = new GeneratedKey();
          key.Active = true;

          key.HashValue = result;

          key.CreatedBy = "droopy";
          key.CreatedDate = DateTime.Now;
          key.UpdatedBy = "droopy";
          key.UpdatedDate = DateTime.Now;

          GeneratedKeysRepository.Add(key);
        }
        else
        {
          seen.Add(result);
        }
      }

      _unitOfWork.Save();
    }
  }
}
