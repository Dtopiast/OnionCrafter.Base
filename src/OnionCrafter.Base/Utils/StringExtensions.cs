namespace OnionCrafter.Base.Utils
{
    /// <summary>
    /// This static class provides extension methods for strings.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Generates a random string of the specified length using only lowercase and uppercase letters.
        /// </summary>
        /// <param name="length">The length of the random string to generate.</param>
        /// <returns>A random string of the specified length.</returns>
        public static string GenerateRandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return GenerateRandomString(length, chars);
        }

        /// <summary>
        /// Generates a random string of the specified length using the specified characters.
        /// </summary>
        /// <param name="length">The length of the random string to generate.</param>
        /// <param name="letters">The characters to use for generating the random string.</param>
        /// <returns>A random string of the specified length.</returns>
        public static string GenerateRandomString(int length, string letters)
        {
            Random random = new Random();

            string randomString = new string(Enumerable.Repeat(letters, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }
    }
}