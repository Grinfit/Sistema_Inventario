using System.IO;
using System.IO.Compression;

namespace Sistema_Inventario.Logica
{
    public class CompressionService
    {
        public string ComprimirBackup(
            string archivoBackup)
        {
            string zipPath =
                Path.ChangeExtension(
                    archivoBackup,
                    ".zip");

            if (File.Exists(zipPath))
            {
                File.Delete(zipPath);
            }

            using (ZipArchive archive =
                ZipFile.Open(
                    zipPath,
                    ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(
                    archivoBackup,
                    Path.GetFileName(
                        archivoBackup),
                    CompressionLevel.Optimal);
            }

            return zipPath;
        }
    }
}