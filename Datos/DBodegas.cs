using System.Data;
using System.Data.SqlClient;

namespace Sistema_Inventario.Datos
{
    public class DBodegas
    {
        Conexion cn = new Conexion();

        // =========================================
        // MOSTRAR
        // =========================================

        public DataTable MostrarBodegas()
        {
            DataTable tabla = new DataTable();

            SqlCommand cmd = new SqlCommand(
                "SELECT * FROM Bodegas",
                cn.AbrirConexion());

            SqlDataAdapter da =
                new SqlDataAdapter(cmd);

            da.Fill(tabla);

            cn.CerrarConexion();

            return tabla;
        }

        // =========================================
        // INSERTAR
        // =========================================

        public void InsertarBodega(
            string nombre,
            string direccion)
        {
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO Bodegas(Nombre,Direccion) VALUES(@Nombre,@Direccion)",
                cn.AbrirConexion());

            cmd.Parameters.AddWithValue(
                "@Nombre",
                nombre);

            cmd.Parameters.AddWithValue(
                "@Direccion",
                direccion);

            cmd.ExecuteNonQuery();

            cn.CerrarConexion();
        }

        // =========================================
        // EDITAR
        // =========================================

        public void EditarBodega(
            int idBodega,
            string nombre,
            string direccion)
        {
            SqlCommand cmd = new SqlCommand(
                "UPDATE Bodegas SET Nombre=@Nombre, Direccion=@Direccion WHERE IdBodega=@IdBodega",
                cn.AbrirConexion());

            cmd.Parameters.AddWithValue(
                "@IdBodega",
                idBodega);

            cmd.Parameters.AddWithValue(
                "@Nombre",
                nombre);

            cmd.Parameters.AddWithValue(
                "@Direccion",
                direccion);

            cmd.ExecuteNonQuery();

            cn.CerrarConexion();
        }

        // =========================================
        // ELIMINAR
        // =========================================

        public void EliminarBodega(int idBodega)
        {
            SqlCommand cmd = new SqlCommand(
                "DELETE FROM Bodegas WHERE IdBodega=@IdBodega",
                cn.AbrirConexion());

            cmd.Parameters.AddWithValue(
                "@IdBodega",
                idBodega);

            cmd.ExecuteNonQuery();

            cn.CerrarConexion();
        }

        // =========================================
        // BUSCAR
        // =========================================

        public DataTable BuscarBodega(string buscar)
        {
            DataTable tabla = new DataTable();

            SqlCommand cmd = new SqlCommand(
                "SELECT * FROM Bodegas WHERE Nombre LIKE @Buscar",
                cn.AbrirConexion());

            cmd.Parameters.AddWithValue(
                "@Buscar",
                "%" + buscar + "%");

            SqlDataAdapter da =
                new SqlDataAdapter(cmd);

            da.Fill(tabla);

            cn.CerrarConexion();

            return tabla;
        }
    }
}