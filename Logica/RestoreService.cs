// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;

namespace Sistema_Inventario.Logica
{
    // CLASE ENCARGADA DE RESTAURAR LOS BACKUPS DEL SISTEMA
    public class RestoreService
    {
        // METODO PARA RESTAURAR EL BACKUP
        public void RestaurarBackup(
            string servidor,
            string baseDatos,
            string archivoEnc,
            string password)
        {
            // RUTA DE LA CARPETA TEMPORAL
            string carpetaTemporal =
               @"C:\RestoreTemp_db_Final";

            // VERIFICA SI LA CARPETA TEMPORAL EXISTE
            if (Directory.Exists(carpetaTemporal))
            {
                // ELIMINA LA CARPETA TEMPORAL
                Directory.Delete(
                    carpetaTemporal,
                    true);
            }

            // CREA LA CARPETA TEMPORAL
            Directory.CreateDirectory(
                carpetaTemporal);

            // CREA LA RUTA DEL ARCHIVO ZIP
            string zipPath =
                Path.Combine(
                    carpetaTemporal,
                    "restore.zip");

            // DESENCRIPTA EL ARCHIVO
            DecryptFile(
                archivoEnc,
                zipPath,
                password);

            // EXTRAE EL CONTENIDO DEL ZIP
            ZipFile.ExtractToDirectory(
                zipPath,
                carpetaTemporal);

            // BUSCA LOS ARCHIVOS .BAK
            string[] archivosBak =
                Directory.GetFiles(
                    carpetaTemporal,
                    "*.bak");

            // VALIDA SI EXISTE EL ARCHIVO BAK
            if (archivosBak.Length == 0)
            {
                throw new Exception(
                    "No se encontró archivo BAK");
            }

            // OBTIENE EL PRIMER ARCHIVO BAK
            string archivoBak =
                archivosBak[0];

            // CREA LA CONEXION A SQL SERVER
            using (SqlConnection cn =
                new SqlConnection(
                    $@"Server={servidor};
                       Database=master;
                       Integrated Security=True;
                       TrustServerCertificate=True;"))
            {
                // ABRE LA CONEXION
                cn.Open();

                // CONSULTA SQL PARA RESTAURAR LA BASE DE DATOS
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

                // CREA EL COMANDO SQL
                SqlCommand cmd =
                    new SqlCommand(
                        query,
                        cn);

                // TIEMPO ILIMITADO PARA EL COMANDO
                cmd.CommandTimeout = 0;

                // EJECUTA LA CONSULTA
                cmd.ExecuteNonQuery();

                // CIERRA LA CONEXION
                cn.Close();
            }

            // INTENTA ELIMINAR LA CARPETA TEMPORAL
            try
            {
                // VERIFICA SI LA CARPETA EXISTE
                if (Directory.Exists(carpetaTemporal))
                {
                    // ELIMINA LA CARPETA TEMPORAL
                    Directory.Delete(
                        carpetaTemporal,
                        true);
                }
            }
            catch
            {

            }
        }

        // METODO PARA DESENCRIPTAR ARCHIVOS AES
        private void DecryptFile(
            string inputFile,
            string outputFile,
            string password)
        {
            // CREA EL ARRAY DEL SALT
            byte[] salt =
                new byte[32];

            // ABRE EL ARCHIVO ENCRIPTADO
            using (FileStream fsCrypt =
                new FileStream(
                    inputFile,
                    FileMode.Open))
            {
                // LEE EL SALT DEL ARCHIVO
                fsCrypt.Read(
                    salt,
                    0,
                    salt.Length);

                // GENERA LA CLAVE DESDE LA CONTRASEÑA
                using (Rfc2898DeriveBytes key =
                    new Rfc2898DeriveBytes(
                        password,
                        salt,
                        100000))
                {
                    // OBTIENE LA CLAVE AES
                    byte[] aesKey =
                        key.GetBytes(32);

                    // OBTIENE EL VECTOR IV
                    byte[] aesIV =
                        key.GetBytes(16);

                    // CREA EL OBJETO AES
                    using (Aes aes =
                        Aes.Create())
                    {
                        // ASIGNA LA CLAVE
                        aes.Key = aesKey;

                        // ASIGNA EL VECTOR IV
                        aes.IV = aesIV;

                        // DEFINE EL MODO DE ENCRIPTACION
                        aes.Mode =
                            CipherMode.CBC;

                        // DEFINE EL PADDING
                        aes.Padding =
                            PaddingMode.PKCS7;

                        // CREA EL FLUJO DE DESENCRIPTACION
                        using (CryptoStream cs =
                            new CryptoStream(
                                fsCrypt,
                                aes.CreateDecryptor(),
                                CryptoStreamMode.Read))
                        {
                            // CREA EL ARCHIVO DE SALIDA
                            using (FileStream fsOut =
                                new FileStream(
                                    outputFile,
                                    FileMode.Create))
                            {
                                // COPIA EL CONTENIDO DESENCRIPTADO
                                cs.CopyTo(fsOut);
                            }
                        }
                    }
                }
            }
        }
    }
}