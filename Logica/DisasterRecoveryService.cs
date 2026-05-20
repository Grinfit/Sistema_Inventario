using System.IO;

namespace Sistema_Inventario.Logica
{
    public class DisasterRecoveryService
    {
        public void CopiarBackupEspejo(
            string archivoOrigen,
            string rutaDestino)
        {
            if (!Directory.Exists(rutaDestino))
            {
                Directory.CreateDirectory(
                    rutaDestino);
            }

            string archivo =
                Path.GetFileName(
                    archivoOrigen);

            string destinoCompleto =
                Path.Combine(
                    rutaDestino,
                    archivo);

            File.Copy(
                archivoOrigen,
                destinoCompleto,
                true);
        }
    }
}