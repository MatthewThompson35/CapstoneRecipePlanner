using System;
using System.Text;

namespace RecipePlannerLibrary.Database
{
    /// <summary>
    /// Utils Class
    /// </summary>
    public class Util
    {

        /// <summary>
        /// Gets the hex for password hashing.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <returns>Hex</returns>
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

        /// <summary>
        /// Gets the hash for password hashing.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <returns>Hash String</returns>
        public static string GetHash(string inputString)
        {
            using var provider = System.Security.Cryptography.MD5.Create();
            StringBuilder builder = new StringBuilder();

            foreach (byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(inputString)))
                builder.Append(b.ToString("x2").ToLower());

            return builder.ToString();
        }

        public static DateTime GetDateOfWeekDay(DayOfWeek dayOfWeek, string week)
        {
            int daysUntilCurrentWeekDay;
            if (week.ToLower().Equals("next"))
            {
                daysUntilCurrentWeekDay = ((int) dayOfWeek - (int) DateTime.Today.AddDays(7).DayOfWeek);
            }
            else
            {
                daysUntilCurrentWeekDay = ((int)dayOfWeek - (int)DateTime.Today.DayOfWeek);
            }

            return DateTime.Today.AddDays(daysUntilCurrentWeekDay);
        }

    }
}
