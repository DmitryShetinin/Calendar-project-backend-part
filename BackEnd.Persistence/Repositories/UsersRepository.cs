using AutoMapper;
using BackEnd.Models;
using BackEnd.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using BackEnd.Core.Interfaces.Repositories;

namespace BackEnd.Persistence.Repositories
{

    public class UsersRepository : IUserRepository
    {
        private readonly UwrmdxbzContext _context;
        private readonly IMapper _mapper;
        public UsersRepository(UwrmdxbzContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddAsync(User user)
        {

            var userEntity = new UserEntity()
            {
                Id = Guid.NewGuid(),
                Username = user.UserName,
                Passwordhash = user.PasswordHash,
                Email = user.Email
            };
            try
            {
                await _context.Users.AddAsync(userEntity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }


        }

       
     
        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.Select(user => _mapper.Map<User>(user)).ToListAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            return _mapper.Map<User>(userEntity);
        }






   




    }
}
