namespace Infrastructure.Encryption
{
    public interface IEncryptor
    {
        string Encrypt(string text);
    }
}
