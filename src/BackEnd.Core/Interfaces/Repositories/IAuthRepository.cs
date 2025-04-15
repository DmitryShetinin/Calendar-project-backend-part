

namespace BackEnd.Core.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        Task<Guid> LoginAsync(string email, string password);
        Task<Guid> RegisterAsync(string userName, string email, string password);


    }
}
