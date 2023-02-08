using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RecipePlannerLibrary.Database
{
    public class Util
    {

        /// <summary>
        /// Gets the hash.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <returns>Hash</returns>
        public static string GetHex(string inputString)
        {
            var sb = new StringBuilder();

            var bytes = Encoding.Unicode.GetBytes(inputString);
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }

        public static string GetHash(string inputString)
        {
            using var provider = System.Security.Cryptography.MD5.Create();
            StringBuilder builder = new StringBuilder();

            foreach (byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(inputString)))
                builder.Append(b.ToString("x2").ToLower());

            return builder.ToString();
        }

    }
}
