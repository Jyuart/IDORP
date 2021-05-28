namespace IdorpDemo.Encryption
{
public interface IEncryptor
{
    public string Encrypt(object o);
    public object Decrypt(string o);
}
}