using System;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;

namespace Sistema_Inventario.Logica
{
    public class RestoreService
    {
        public void RestaurarBackup(
            string servidor,
            string baseDatos,
            string archivoEnc,
            string password)
        {
            string carpetaTemporal =
               @"C:\RestoreTemp_db_Final";

            // ============================================
            // LIMPIAR CARPETA TEMPORAL
            // ============================================

            if (Directory.Exists(carpetaTemporal))
            {
                Directory.Delete(
                    carpetaTemporal,
                    true);
            }

            Directory.CreateDirectory(
                carpetaTemporal);

            // ============================================
            // DESENCRIPTAR
            // ============================================

            string zipPath =
                Path.Combine(
                    carpetaTemporal,
                    "restore.zip");

            DecryptFile(
                archivoEnc,
                zipPath,
                password);

            // ============================================
            // EXTRAER ZIP
            // ============================================

            ZipFile.ExtractToDirectory(
                zipPath,
                carpetaTemporal);

            // ============================================
            // BUSCAR BAK
            // ============================================

            string[] archivosBak =
                Directory.GetFiles(
                    carpetaTemporal,
                    "*.bak");

            if (archivosBak.Length == 0)
            {
                throw new Exception(
                    "No se encontró archivo BAK");
            }

            string archivoBak =
                archivosBak[0];

            // ============================================
            // RESTORE SQL
            // ============================================

            using (SqlConnection cn =
                new SqlConnection(
                    $@"Server={servidor};
                       Database=master;
                       Integrated Security=True;
                       TrustServerCertificate=True;"))
            {
                cn.Open();

                string query =
                    $@"
                    ALTER DATABASE [{baseDatos}]
                    SET SINGLE_USER
                    WITH ROLLBACK IMMEDIATE;

                    RESTORE DATABASE [{baseDatos}]
                    FROM DISK='{archivoBak}'
                    WITH REPLACE;

                    ALTER DATABASE [{baseDatos}]
                    SET MULTI_USER;";

                SqlCommand cmd =
                    new SqlCommand(
                        query,
                        cn);

                cmd.CommandTimeout = 0;

                cmd.ExecuteNonQuery();

                cn.Close();
            }

            // ============================================
            // LIMPIEZA FINAL
            // ============================================

            try
            {
                if (Directory.Exists(carpetaTemporal))
                {
                    Directory.Delete(
                        carpetaTemporal,
                        true);
                }
            }
            catch
            {

            }
        }

        // ============================================
        // AES DECRYPT
        // ============================================

        private void DecryptFile(
            string inputFile,
            string outputFile,
            string password)
        {
            byte[] salt =
                new byte[32];

            using (FileStream fsCrypt =
                new FileStream(
                    inputFile,
                    FileMode.Open))
            {
                fsCrypt.Read(
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
                        key.GetBytes(32);

                    byte[] aesIV =
                        key.GetBytes(16);

                    using (Aes aes =
                        Aes.Create())
                    {
                        aes.Key = aesKey;

                        aes.IV = aesIV;

                        aes.Mode =
                            CipherMode.CBC;

                        aes.Padding =
                            PaddingMode.PKCS7;

                        using (CryptoStream cs =
                            new CryptoStream(
                                fsCrypt,
                                aes.CreateDecryptor(),
                                CryptoStreamMode.Read))
                        {
                            using (FileStream fsOut =
                                new FileStream(
                                    outputFile,
                                    FileMode.Create))
                            {
                                cs.CopyTo(fsOut);
                            }
                        }
                    }
                }
            }
        }
    }
}