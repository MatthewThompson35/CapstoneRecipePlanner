using System;
using System.Text;

namespace RecipePlannerLibrary.Database
{
    /// <summary>
    /// The Utils class to be used throughout the project
    /// </summary>
    public class Util
    {

        /// <summary>
        /// Gets the hex string for password hashing.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <precondition>The input string must not be null.</precondition>
        /// <postcondition>none</postcondition>
        /// <returns>The hex string generated from the input string</returns>
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
        /// <precondition>none</precondition>
        /// <postcondition>none</postcondition>
        /// <returns>A string containing the hashed representation of the input string.</returns>
        public static string GetHash(string inputString)
        {
            using var provider = System.Security.Cryptography.MD5.Create();
            StringBuilder builder = new StringBuilder();

            foreach (byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(inputString)))
                builder.Append(b.ToString("x2").ToLower());

            return builder.ToString();
        }

        /// <summary>
        /// Gets the date of week day.
        /// </summary>
        /// <param name="dayOfWeek">The day of week.</param>
        /// <param name="week">The week.</param>
        /// <precondition>none</precondition>
        /// <postcondition>none</postcondition>
        /// <returns>The date time of the weekday given as input.</returns>
        public static DateTime GetDateOfWeekDay(DayOfWeek dayOfWeek, string week)
        {
            int daysUntilCurrentWeekDay;
            if (week.ToLower().Equals("next"))
            {
                daysUntilCurrentWeekDay = ((int) dayOfWeek - (int) DateTime.Today.DayOfWeek);
                daysUntilCurrentWeekDay += 7;
            }
            else
            {
                daysUntilCurrentWeekDay = ((int)dayOfWeek - (int)DateTime.Today.DayOfWeek);
            }

            return DateTime.Today.AddDays(daysUntilCurrentWeekDay);
        }

    }
}
