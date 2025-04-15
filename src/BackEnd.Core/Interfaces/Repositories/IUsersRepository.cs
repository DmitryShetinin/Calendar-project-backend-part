
using BackEnd.Models;

namespace BackEnd.Core.Interfaces.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user);

    Task<User> GetByEmail(string email);
    Task<List<User>> GetAllUsers();

}

