using System;
using System.IO;

namespace Sistema_Inventario.Logica
{
    public class ValidationService
    {
        public bool ExisteRuta(
            string ruta)
        {
            return Directory.Exists(ruta);
        }

        public bool TienePermisosEscritura(
            string ruta)
        {
            try
            {
                string testFile =
                    Path.Combine(
                        ruta,
                        "test.tmp");

                File.WriteAllText(
                    testFile,
                    "test");

                File.Delete(testFile);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool TieneEspacioDisponible(
            string ruta,
            long espacioNecesarioMB)
        {
            DriveInfo drive =
                new DriveInfo(
                    Path.GetPathRoot(ruta));

            long espacioLibreMB =
                drive.AvailableFreeSpace
                / 1024 / 1024;

            return espacioLibreMB >
                   espacioNecesarioMB;
        }
    }
}