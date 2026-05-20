// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.IO;

namespace Sistema_Inventario.Logica
{
    // CLASE ENCARGADA DE VALIDAR RUTAS Y ESPACIO EN DISCO
    public class ValidationService
    {
        // METODO PARA VALIDAR SI LA RUTA EXISTE
        public bool ExisteRuta(
            string ruta)
        {
            return Directory.Exists(ruta);
        }

        // METODO PARA VALIDAR SI LA RUTA TIENE PERMISOS DE ESCRITURA
        public bool TienePermisosEscritura(
            string ruta)
        {
            try
            {
                // CREA LA RUTA DEL ARCHIVO TEMPORAL
                string testFile =
                    Path.Combine(
                        ruta,
                        "test.tmp");

                // CREA EL ARCHIVO TEMPORAL
                File.WriteAllText(
                    testFile,
                    "test");

                // ELIMINA EL ARCHIVO TEMPORAL
                File.Delete(testFile);

                // RETORNA TRUE SI TODO FUNCIONA
                return true;
            }
            catch
            {
                // RETORNA FALSE SI OCURRE UN ERROR
                return false;
            }
        }

        // METODO PARA VALIDAR EL ESPACIO DISPONIBLE EN DISCO
        public bool TieneEspacioDisponible(
            string ruta,
            long espacioNecesarioMB)
        {
            // OBTIENE INFORMACION DEL DISCO
            DriveInfo drive =
                new DriveInfo(
                    Path.GetPathRoot(ruta));

            // OBTIENE EL ESPACIO LIBRE EN MEGABYTES
            long espacioLibreMB =
                drive.AvailableFreeSpace
                / 1024 / 1024;

            // RETORNA TRUE SI HAY ESPACIO DISPONIBLE
            return espacioLibreMB >
                   espacioNecesarioMB;
        }
    }
}