using System.Data.SqlClient;

namespace Sistema_Inventario.Datos
{
    internal class Conexion
    {
        SqlConnection cn = new SqlConnection(
            "Server=HENRYOCHOA\\SQLEXPRESS;Database=Inventario;Integrated Security=true");

        public SqlConnection AbrirConexion()
        {
            if (cn.State == System.Data.ConnectionState.Closed)
            {
                cn.Open();
            }

            return cn;
        }

        public SqlConnection CerrarConexion()
        {
            if (cn.State == System.Data.ConnectionState.Open)
            {
                cn.Close();
            }

            return cn;
        }
    }
}