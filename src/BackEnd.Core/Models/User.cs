﻿namespace BackEnd.Models
{
    public class User
    {
        private User(Guid id, string userName, string passwordHash, string email)
        {
            Id = id;
            UserName = userName;
            PasswordHash = passwordHash;
            Email = email;

        }

        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string PasswordHash { get; private set; }
        public string Email { get; private set; }

   

        public static User Create(Guid id, string username, string passwordHash, string email)
        {
            return new User(id, username, passwordHash, email);
        }
 
    }
}
