using System.IO;
using System.Security.Cryptography;

namespace Sistema_Inventario.Logica
{
    public class EncryptionService
    {
        private const int KeySize = 32;

        private const int IvSize = 16;

        public string EncryptFile(
            string inputFile,
            string password)
        {
            string outputFile =
                inputFile + ".enc";

            byte[] salt =
                new byte[32];

            using (RNGCryptoServiceProvider rng =
                new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            using (FileStream fsCrypt =
                new FileStream(
                    outputFile,
                    FileMode.Create))
            {
                fsCrypt.Write(
                    salt,
                    0,
                    salt.Length);

                using (Rfc2898DeriveBytes key =
                    new Rfc2898DeriveBytes(
                        password,
                        salt,
                        100000))
                {
                    byte[] aesKey =
                        key.GetBytes(KeySize);

                    byte[] aesIV =
                        key.GetBytes(IvSize);

                    using (Aes aes =
                        Aes.Create())
                    {
                        aes.KeySize = 256;

                        aes.BlockSize = 128;

                        aes.Key = aesKey;

                        aes.IV = aesIV;

                        aes.Mode =
                            CipherMode.CBC;

                        aes.Padding =
                            PaddingMode.PKCS7;

                        using (CryptoStream cs =
                            new CryptoStream(
                                fsCrypt,
                                aes.CreateEncryptor(),
                                CryptoStreamMode.Write))
                        {
                            using (FileStream fsIn =
                                new FileStream(
                                    inputFile,
                                    FileMode.Open))
                            {
                                fsIn.CopyTo(cs);
                            }
                        }
                    }
                }
            }

            return outputFile;
        }
    }
}