using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static aCMS.Helpers.PasswordHelpers;

namespace aCMS.Models
{
    public class User
    {
        public User() { }

        public User(string username, string password)
        {
            Username = username;
            PasswordSalt = CreateSalt();
            PasswordHash = HashPassword(password, PasswordSalt);

            if (!VerifyHashedPassword(PasswordHash, PasswordSalt, password))
                throw new Exception("Error in User creation.");
        }

        public User(string username, string password, Author author)
            : this(username, password)
        {
            Author = author;
            AuthorId = author.Id;
        }

        public User(string username, byte[] hash, byte[] salt)
        {
            Username = username;
            PasswordSalt = salt;
            PasswordHash = hash;
        }

        public User(string username, byte[] hash, byte[] salt, Author author)
            : this(username, hash, salt)
        {
            Author = author;
            AuthorId = author.Id;
        }

        public int Id { get; set; }
        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public Author Author { get; set; }
        public int AuthorId { get; set; }

        public void UpdatePassword(string password)
        {
            PasswordSalt = CreateSalt();
            PasswordHash = HashPassword(password, PasswordSalt);

            if (!VerifyHashedPassword(PasswordHash, PasswordSalt, password))
                throw new Exception("Error in UpdatePassword().");
        }
    }

    public struct UsernamePasswordPair
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
