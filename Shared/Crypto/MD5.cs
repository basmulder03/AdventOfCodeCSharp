namespace Shared.Crypto
{
    public static class MD5
    {
        public static string Encrypt(string input)
        {
            using System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            var inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "");
        }
    }
}
