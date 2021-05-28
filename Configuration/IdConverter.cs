using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using IdorpDemo.BL;
using IdorpDemo.Encryption;

namespace IdorpDemo.Configuration
{
    public class IdConverter : JsonConverter<Id<Guid>>
    {
        private readonly IEncryptor _encryptor;

        public IdConverter(IEncryptor encryptor)
        {
            _encryptor = encryptor;
        }

        public override Id<Guid> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            object decryptedGuid = _encryptor.Decrypt(reader.GetString());
            Guid.TryParse(decryptedGuid.ToString(), out Guid value);
            return new Id<Guid>(value);
        }

        public override void Write(Utf8JsonWriter writer, Id<Guid> value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(_encryptor.Encrypt(value.Value));
        }
    }
}