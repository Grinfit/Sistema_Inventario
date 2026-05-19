using System.Collections.Generic;

namespace Sistema_Inventario.Utilidades
{
    public static class SesionUsuario
    {
        public static int IdUsuario { get; set; }

        public static string Usuario { get; set; }

        public static int IdRol { get; set; }

        public static string Rol { get; set; }

        public static List<string> Permisos =
            new List<string>();
    }
}