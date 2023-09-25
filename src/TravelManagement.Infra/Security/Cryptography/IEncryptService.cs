using System.Security.Cryptography;

namespace TravelManagement.Infra.Security.Cryptography;
public interface IEncryptService
{
    string Encrypt(string phrase);
}

public class MD5EncryptService : IEncryptService
{
    public string Encrypt(string phrase)
    {
        using MD5 md5 = MD5.Create();

        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(phrase);
        byte[] hashBytes = md5.ComputeHash(inputBytes);

        return Convert.ToHexString(hashBytes);
    }
}
