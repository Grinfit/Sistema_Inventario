// IMPORTACION DE LIBRERIA PARA EL USO DE LISTAS
using System.Collections.Generic;

namespace Sistema_Inventario.Utilidades
{
    // CLASE ESTATICA ENCARGADA DE GUARDAR LOS DATOS DE LA SESION DEL USUARIO
    public static class SesionUsuario
    {
        // VARIABLE PARA GUARDAR EL ID DEL USUARIO
        public static int IdUsuario { get; set; }

        // VARIABLE PARA GUARDAR EL NOMBRE DEL USUARIO
        public static string Usuario { get; set; }

        // VARIABLE PARA GUARDAR EL ID DEL ROL
        public static int IdRol { get; set; }

        // VARIABLE PARA GUARDAR EL NOMBRE DEL ROL
        public static string Rol { get; set; }

        // LISTA PARA GUARDAR LOS PERMISOS DEL USUARIO
        public static List<string> Permisos =
            new List<string>();
    }
}