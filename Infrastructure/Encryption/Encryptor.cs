using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Encryption
{
    public class Encryptor: IEncryptor
    {
        public string Encrypt(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            var md5 = MD5.Create();
            var md5Bytes = md5.ComputeHash(bytes);
            var shaMd5Bytes = new SHA384CryptoServiceProvider().ComputeHash(md5Bytes);

            var builder = new StringBuilder();
            foreach (var b in shaMd5Bytes)
            {
                builder.Append(b.ToString("x2").ToLower());
            }
            return builder.ToString();
        }
    }
}
