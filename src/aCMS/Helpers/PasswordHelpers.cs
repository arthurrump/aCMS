using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.AspNet.Cryptography.KeyDerivation;
using System.Threading.Tasks;

namespace aCMS.Helpers
{
    public static class PasswordHelpers
    {
        public static byte[] CreateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                rng.GetBytes(salt);

            return salt;
        }

        public static byte[] HashPassword(string password, byte[] salt, KeyDerivationPrf prf = KeyDerivationPrf.HMACSHA256,
            int iterations = 1000, int requestedBytes = 256 / 8)
        {
            return KeyDerivation.Pbkdf2(password, salt, prf, iterations, requestedBytes);
        }

        public static bool VerifyHashedPassword(byte[] hash, byte[] salt, string password)
        {
            try
            {
                return ByteArraysEqual(hash, HashPassword(password, salt));
            }
            catch
            {
                return false;
            }
        }

        private static uint ReadNetworkByteOrder(byte[] buffer, int offset)
        {
            return ((uint)(buffer[offset + 0]) << 24)
                | ((uint)(buffer[offset + 1]) << 16)
                | ((uint)(buffer[offset + 2]) << 8)
                | ((uint)(buffer[offset + 3]));
        }

        private static bool ByteArraysEqual(byte[] a, byte[] b)
        { 
            if (a == null && b == null) 
            { 
                return true; 
            } 
            if (a == null || b == null || a.Length != b.Length) 
            { 
                return false; 
            } 
            var areSame = true; 
            for (var i = 0; i<a.Length; i++) 
            { 
                areSame &= (a[i] == b[i]); 
            } 
            return areSame; 
        }
    }
}
