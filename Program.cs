// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Inventario
{
    // CLASE PRINCIPAL DEL SISTEMA
    internal static class Program
    {
        // PUNTO DE ENTRADA PRINCIPAL DE LA APLICACION
        [STAThread]

        // METODO PRINCIPAL DEL SISTEMA
        static void Main()
        {
            // HABILITA LOS ESTILOS VISUALES DE WINDOWS
            Application.EnableVisualStyles();

            // CONFIGURA EL RENDERIZADO DE TEXTO
            Application.SetCompatibleTextRenderingDefault(false);

            // EJECUTA EL FORMULARIO LOGIN
            Application.Run(new FrmLogin());
        }
    }
}