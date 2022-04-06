using System;
using System.Security;
using System.Security.Cryptography;
using System.Text;
namespace Task3
{
    class Cryptography
    {
        public string Key()
        {
            var buff = RandomNumberGenerator.Create();
            byte[] bytes = new byte[16];
            buff.GetBytes(bytes);
            string turn = BitConverter.ToString(bytes).Replace("-", "");
            return turn;
        }

        public string HMAC(string key, string step)
        {
            var hmac256 = new HMACSHA256(Encoding.UTF8.GetBytes(key));
            var hash = hmac256.ComputeHash(Encoding.UTF8.GetBytes(step));
            string answer = BitConverter.ToString(hash).Replace("-", "");
            return answer;
        }
    }

}
