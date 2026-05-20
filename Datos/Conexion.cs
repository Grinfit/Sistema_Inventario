// IMPORTACION DE LA LIBRERIA PARA REALIZAR LA CONEXION A SQL SERVER
using System.Data.SqlClient;

namespace Sistema_Inventario.Datos
{
    // CLASE ENCARGADA DE MANEJAR LA CONEXION A LA BASE DE DATOS
    internal class Conexion
    {
        // CREACION DE LA CONEXION CON EL SERVIDOR SQL SERVER Y LA BASE DE DATOS INVENTARIO
        //DESKTOP

        //SqlConnection cn = new SqlConnection(
        //   "Server=DESKTOP-PGNRJ9E\\SQLEXPRESS;Database=Inventario;Integrated Security=true");

        //LAPTOP

        SqlConnection cn = new SqlConnection(
             "Server=HENRYOCHOA\\SQLEXPRESS;Database=Inventario;Integrated Security=true");


        // METODO PARA ABRIR LA CONEXION A LA BASE DE DATOS
        public SqlConnection AbrirConexion()
        {
            // VERIFICA SI LA CONEXION ESTA CERRADA
            if (cn.State == System.Data.ConnectionState.Closed)
            {
                // ABRE LA CONEXION
                cn.Open();
            }

            // RETORNA LA CONEXION ABIERTA
            return cn;
        }

        // METODO PARA CERRAR LA CONEXION A LA BASE DE DATOS
        public SqlConnection CerrarConexion()
        {
            // VERIFICA SI LA CONEXION ESTA ABIERTA
            if (cn.State == System.Data.ConnectionState.Open)
            {
                // CIERRA LA CONEXION
                cn.Close();
            }

            // RETORNA LA CONEXION CERRADA
            return cn;
        }
    }
}