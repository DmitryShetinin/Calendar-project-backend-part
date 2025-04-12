using BackEnd.Interfaces.Auth;
using BackEnd.Models;
using BackEnd.Core.Interfaces.Repositories;

namespace BackEnd.Services
{
    public class UserServices
    {
 
        private readonly IUserRepository _userRepository;
    
        public UserServices(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {
 
            _userRepository = userRepository;
    

        }
    

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }


 

    }
}
