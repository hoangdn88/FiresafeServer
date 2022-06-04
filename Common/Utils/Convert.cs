using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Utils
{
    public class Convert
    {
        public static string GetMD5Hash(string input)
        {
            try
            {
                System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] bs = Encoding.UTF8.GetBytes(input);
                bs = x.ComputeHash(bs);

                var s = new StringBuilder();
                foreach (byte b in bs)
                {
                    s.Append(b.ToString("x2"));
                }

                string password = s.ToString();
                return password;
            }
            catch (Exception ex)
            {
            }

            return string.Empty;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

        public static double DateTimeToUnixTime(DateTime time)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return (time - dateTime).TotalSeconds;
        }

        public static string ToUnSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

    }
}
