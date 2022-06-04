using System;

namespace Common.Utils
{
    public static class StringUtils
    {
        private static readonly char[] Chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

        public static string RandomString(int length)
        {
            var random = new Random();
            var chars = new char[length];

            for (var i = 0; i < length; i++)
            {
                chars[i] = Chars[random.Next(Chars.Length)];
            }

            return new string(chars);
        }
    }
}