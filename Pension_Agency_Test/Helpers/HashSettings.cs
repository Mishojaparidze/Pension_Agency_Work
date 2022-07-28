using System;
using System.Text;
using Tweetinvi.Security;

namespace Pension_Agency_Test.Helpers
{    public class HashSettings
    {
        public static string HashPassword(string password)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] passBytes = Encoding.ASCII.GetBytes(password);
            byte[] encryptBytes = sha1.ComputeHash(passBytes);
            return Convert.ToBase64String(encryptBytes);
        }
    }
}
