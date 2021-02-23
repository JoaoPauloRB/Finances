using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Service.Utils
{
  public static class Hashs
  {
    public static string HashPassword(string password)
    {
      var sha1 = new SHA1CryptoServiceProvider();
      byte[] data = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
      var sBuilder = new StringBuilder();
      for (int i = 0; i < data.Length; i++)
      {
          sBuilder.Append(data[i].ToString("x2"));
      }

      // Return the hexadecimal string.
      return sBuilder.ToString();
    }
  }
}