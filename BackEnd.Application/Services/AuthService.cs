using BackEnd.Core.Interfaces.Repositories;
using BackEnd.Interfaces.Auth;
using BackEnd.Models;

namespace BackEnd.Application.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher
        ) {
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
      
        }
        public async Task<Guid> RegisterAsync(string userName, string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            var user = User.Create(new Guid(), userName, hashedPassword, email);
            await _userRepository.AddAsync(user);

            return user.Id;
          
        }



        public async Task<Guid> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmail(email);
            if (user == null)
            {
                throw new Exception("Object reference not set to an instance of an object");
            }


            var result = _passwordHasher.Verify(password, user.PasswordHash);

            if (result == false)
            {
                throw new Exception("Failed to login");
            }

            //var token = _jwtProvider.GenerateToken(user);

            return user.Id;
        }
    }
}
