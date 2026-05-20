// IMPORTACION DE LIBRERIAS PARA EL MANEJO DE ARCHIVOS
using System.IO;

namespace Sistema_Inventario.Logica
{
    // CLASE ENCARGADA DE REALIZAR COPIAS DE SEGURIDAD ESPEJO
    public class DisasterRecoveryService
    {
        // METODO PARA COPIAR EL BACKUP A OTRA UBICACION
        public void CopiarBackupEspejo(
            string archivoOrigen,
            string rutaDestino)
        {
            // VERIFICA SI LA CARPETA DESTINO EXISTE
            if (!Directory.Exists(rutaDestino))
            {
                // CREA LA CARPETA DESTINO
                Directory.CreateDirectory(
                    rutaDestino);
            }

            // OBTIENE EL NOMBRE DEL ARCHIVO
            string archivo =
                Path.GetFileName(
                    archivoOrigen);

            // CREA LA RUTA COMPLETA DEL DESTINO
            string destinoCompleto =
                Path.Combine(
                    rutaDestino,
                    archivo);

            // COPIA EL ARCHIVO AL DESTINO
            File.Copy(
                archivoOrigen,
                destinoCompleto,
                true);
        }
    }
}