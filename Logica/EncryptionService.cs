// IMPORTACION DE LIBRERIAS PARA EL MANEJO DE ARCHIVOS Y ENCRIPTACION
using System.IO;
using System.Security.Cryptography;

namespace Sistema_Inventario.Logica
{
    // CLASE ENCARGADA DE ENCRIPTAR ARCHIVOS DEL SISTEMA
    public class EncryptionService
    {
        // TAMAÑO DE LA CLAVE AES
        private const int KeySize = 32;

        // TAMAÑO DEL VECTOR IV
        private const int IvSize = 16;

        // METODO PARA ENCRIPTAR UN ARCHIVO
        public string EncryptFile(
            string inputFile,
            string password)
        {
            // CREA EL NOMBRE DEL ARCHIVO ENCRIPTADO
            string outputFile =
                inputFile + ".enc";

            // CREA EL ARRAY PARA EL SALT
            byte[] salt =
                new byte[32];

            // GENERA BYTES ALEATORIOS PARA EL SALT
            using (RNGCryptoServiceProvider rng =
                new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // CREA EL ARCHIVO ENCRIPTADO
            using (FileStream fsCrypt =
                new FileStream(
                    outputFile,
                    FileMode.Create))
            {
                // ESCRIBE EL SALT EN EL ARCHIVO
                fsCrypt.Write(
                    salt,
                    0,
                    salt.Length);

                // GENERA LA CLAVE A PARTIR DE LA CONTRASEÑA
                using (Rfc2898DeriveBytes key =
                    new Rfc2898DeriveBytes(
                        password,
                        salt,
                        100000))
                {
                    // OBTIENE LA CLAVE AES
                    byte[] aesKey =
                        key.GetBytes(KeySize);

                    // OBTIENE EL VECTOR IV
                    byte[] aesIV =
                        key.GetBytes(IvSize);

                    // CREA EL OBJETO AES
                    using (Aes aes =
                        Aes.Create())
                    {
                        // DEFINE EL TAMAÑO DE LA CLAVE
                        aes.KeySize = 256;

                        // DEFINE EL TAMAÑO DEL BLOQUE
                        aes.BlockSize = 128;

                        // ASIGNA LA CLAVE AES
                        aes.Key = aesKey;

                        // ASIGNA EL VECTOR IV
                        aes.IV = aesIV;

                        // DEFINE EL MODO DE ENCRIPTACION
                        aes.Mode =
                            CipherMode.CBC;

                        // DEFINE EL TIPO DE PADDING
                        aes.Padding =
                            PaddingMode.PKCS7;

                        // CREA EL FLUJO DE ENCRIPTACION
                        using (CryptoStream cs =
                            new CryptoStream(
                                fsCrypt,
                                aes.CreateEncryptor(),
                                CryptoStreamMode.Write))
                        {
                            // ABRE EL ARCHIVO ORIGINAL
                            using (FileStream fsIn =
                                new FileStream(
                                    inputFile,
                                    FileMode.Open))
                            {
                                // COPIA EL CONTENIDO AL ARCHIVO ENCRIPTADO
                                fsIn.CopyTo(cs);
                            }
                        }
                    }
                }
            }

            // RETORNA EL ARCHIVO ENCRIPTADO
            return outputFile;
        }
    }
}