// IMPORTACION DE LIBRERIAS PARA EL MANEJO DE ARCHIVOS Y COMPRESION
using System.IO;
using System.IO.Compression;

namespace Sistema_Inventario.Logica
{
    // CLASE ENCARGADA DE COMPRIMIR LOS BACKUPS DEL SISTEMA
    public class CompressionService
    {
        // METODO PARA COMPRIMIR EL ARCHIVO BACKUP
        public string ComprimirBackup(
            string archivoBackup)
        {
            // CAMBIA LA EXTENSION DEL ARCHIVO A .ZIP
            string zipPath =
                Path.ChangeExtension(
                    archivoBackup,
                    ".zip");

            // VERIFICA SI EL ARCHIVO ZIP YA EXISTE
            if (File.Exists(zipPath))
            {
                // ELIMINA EL ARCHIVO ZIP EXISTENTE
                File.Delete(zipPath);
            }

            // CREA EL ARCHIVO ZIP
            using (ZipArchive archive =
                ZipFile.Open(
                    zipPath,
                    ZipArchiveMode.Create))
            {
                // AGREGA EL ARCHIVO BACKUP AL ZIP
                archive.CreateEntryFromFile(
                    archivoBackup,
                    Path.GetFileName(
                        archivoBackup),
                    CompressionLevel.Optimal);
            }

            // RETORNA LA RUTA DEL ARCHIVO ZIP
            return zipPath;
        }
    }
}