using System.Data;
using System.Data.SqlClient;

namespace Sistema_Inventario.Datos
{
    public class DProveedores
    {
        Conexion cn = new Conexion();

        // =====================================
        // MOSTRAR
        // =====================================

        public DataTable MostrarProveedores()
        {
            DataTable tabla =
                new DataTable();

            SqlCommand cmd =
                new SqlCommand(
                    "SELECT * FROM Proveedores",
                    cn.AbrirConexion());

            SqlDataAdapter da =
                new SqlDataAdapter(cmd);

            da.Fill(tabla);

            cn.CerrarConexion();

            return tabla;
        }

        // =====================================
        // INSERTAR
        // =====================================

        public void InsertarProveedor(
            string nombre,
            string empresa,
            string telefono,
            string correo,
            string direccion)
        {
            SqlCommand cmd =
                new SqlCommand(
                    @"INSERT INTO Proveedores
                    (
                        Nombre,
                        Empresa,
                        Telefono,
                        Correo,
                        Direccion
                    )
                    VALUES
                    (
                        @Nombre,
                        @Empresa,
                        @Telefono,
                        @Correo,
                        @Direccion
                    )",
                    cn.AbrirConexion());

            cmd.Parameters.AddWithValue(
                "@Nombre",
                nombre);

            cmd.Parameters.AddWithValue(
                "@Empresa",
                empresa);

            cmd.Parameters.AddWithValue(
                "@Telefono",
                telefono);

            cmd.Parameters.AddWithValue(
                "@Correo",
                correo);

            cmd.Parameters.AddWithValue(
                "@Direccion",
                direccion);

            cmd.ExecuteNonQuery();

            cn.CerrarConexion();
        }

        // =====================================
        // EDITAR
        // =====================================

        public void EditarProveedor(
            int idProveedor,
            string nombre,
            string empresa,
            string telefono,
            string correo,
            string direccion)
        {
            SqlCommand cmd =
                new SqlCommand(
                    @"UPDATE Proveedores
                    SET
                        Nombre=@Nombre,
                        Empresa=@Empresa,
                        Telefono=@Telefono,
                        Correo=@Correo,
                        Direccion=@Direccion
                    WHERE IdProveedor=@IdProveedor",
                    cn.AbrirConexion());

            cmd.Parameters.AddWithValue(
                "@IdProveedor",
                idProveedor);

            cmd.Parameters.AddWithValue(
                "@Nombre",
                nombre);

            cmd.Parameters.AddWithValue(
                "@Empresa",
                empresa);

            cmd.Parameters.AddWithValue(
                "@Telefono",
                telefono);

            cmd.Parameters.AddWithValue(
                "@Correo",
                correo);

            cmd.Parameters.AddWithValue(
                "@Direccion",
                direccion);

            cmd.ExecuteNonQuery();

            cn.CerrarConexion();
        }

        // =====================================
        // ELIMINAR
        // =====================================

        public void EliminarProveedor(
            int idProveedor)
        {
            SqlCommand cmd =
                new SqlCommand(
                    "DELETE FROM Proveedores WHERE IdProveedor=@IdProveedor",
                    cn.AbrirConexion());

            cmd.Parameters.AddWithValue(
                "@IdProveedor",
                idProveedor);

            cmd.ExecuteNonQuery();

            cn.CerrarConexion();
        }

        // =====================================
        // BUSCAR
        // =====================================

        public DataTable BuscarProveedor(
            string buscar)
        {
            DataTable tabla =
                new DataTable();

            SqlCommand cmd =
                new SqlCommand(
                    @"SELECT * FROM Proveedores
                    WHERE Nombre LIKE @Buscar
                    OR Empresa LIKE @Buscar",
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