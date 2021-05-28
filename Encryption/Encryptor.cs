using Microsoft.Extensions.Configuration;
using NETCore.Encrypt;

namespace IdorpDemo.Encryption
{
    public class Encryptor : IEncryptor
    {
        private readonly string _iv;
        private readonly string _key;

        public Encryptor(IConfiguration configuration)
        {
            IConfigurationSection section = configuration.GetSection("Encryption");
            _key = section.GetValue<string>("Key");
            _iv = section.GetValue<string>("IV");
        }

        public string Encrypt(object data) => EncryptProvider.AESEncrypt(data.ToString(), _key, _iv);

        public object Decrypt(string data) => EncryptProvider.AESDecrypt(data, _key, _iv);
    }
}