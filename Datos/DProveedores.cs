// IMPORTACION DE LIBRERIAS NECESARIAS PARA EL MANEJO DE DATOS Y SQL SERVER
using System.Data;
using System.Data.SqlClient;

namespace Sistema_Inventario.Datos
{
    // CLASE ENCARGADA DE REALIZAR LAS OPERACIONES CRUD DE LOS PROVEEDORES
    public class DProveedores
    {
        // OBJETO DE CONEXION A LA BASE DE DATOS
        Conexion cn = new Conexion();

        // METODO PARA MOSTRAR TODOS LOS PROVEEDORES
        public DataTable MostrarProveedores()
        {
            // CREACION DE TABLA TEMPORAL
            DataTable tabla =
                new DataTable();

            // CONSULTA SQL PARA OBTENER LOS PROVEEDORES
            SqlCommand cmd =
                new SqlCommand(
                    "SELECT * FROM Proveedores",
                    cn.AbrirConexion());

            // ADAPTADOR PARA EJECUTAR LA CONSULTA
            SqlDataAdapter da =
                new SqlDataAdapter(cmd);

            // LLENA LA TABLA CON LOS DATOS
            da.Fill(tabla);

            // CIERRA LA CONEXION
            cn.CerrarConexion();

            // RETORNA LOS DATOS
            return tabla;
        }

        // METODO PARA INSERTAR UN NUEVO PROVEEDOR
        public void InsertarProveedor(
            string nombre,
            string empresa,
            string telefono,
            string correo,
            string direccion)
        {
            // CONSULTA SQL PARA INSERTAR EL PROVEEDOR
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

            // PARAMETRO DEL NOMBRE
            cmd.Parameters.AddWithValue(
                "@Nombre",
                nombre);

            // PARAMETRO DE LA EMPRESA
            cmd.Parameters.AddWithValue(
                "@Empresa",
                empresa);

            // PARAMETRO DEL TELEFONO
            cmd.Parameters.AddWithValue(
                "@Telefono",
                telefono);

            // PARAMETRO DEL CORREO
            cmd.Parameters.AddWithValue(
                "@Correo",
                correo);

            // PARAMETRO DE LA DIRECCION
            cmd.Parameters.AddWithValue(
                "@Direccion",
                direccion);

            // EJECUTA LA CONSULTA
            cmd.ExecuteNonQuery();

            // CIERRA LA CONEXION
            cn.CerrarConexion();
        }

        // METODO PARA EDITAR UN PROVEEDOR
        public void EditarProveedor(
            int idProveedor,
            string nombre,
            string empresa,
            string telefono,
            string correo,
            string direccion)
        {
            // CONSULTA SQL PARA ACTUALIZAR LOS DATOS DEL PROVEEDOR
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

            // PARAMETRO DEL ID DEL PROVEEDOR
            cmd.Parameters.AddWithValue(
                "@IdProveedor",
                idProveedor);

            // PARAMETRO DEL NOMBRE
            cmd.Parameters.AddWithValue(
                "@Nombre",
                nombre);

            // PARAMETRO DE LA EMPRESA
            cmd.Parameters.AddWithValue(
                "@Empresa",
                empresa);

            // PARAMETRO DEL TELEFONO
            cmd.Parameters.AddWithValue(
                "@Telefono",
                telefono);

            // PARAMETRO DEL CORREO
            cmd.Parameters.AddWithValue(
                "@Correo",
                correo);

            // PARAMETRO DE LA DIRECCION
            cmd.Parameters.AddWithValue(
                "@Direccion",
                direccion);

            // EJECUTA LA CONSULTA
            cmd.ExecuteNonQuery();

            // CIERRA LA CONEXION
            cn.CerrarConexion();
        }

        // METODO PARA ELIMINAR UN PROVEEDOR
        public void EliminarProveedor(
            int idProveedor)
        {
            // CONSULTA SQL PARA ELIMINAR EL PROVEEDOR
            SqlCommand cmd =
                new SqlCommand(
                    "DELETE FROM Proveedores WHERE IdProveedor=@IdProveedor",
                    cn.AbrirConexion());

            // PARAMETRO DEL ID DEL PROVEEDOR
            cmd.Parameters.AddWithValue(
                "@IdProveedor",
                idProveedor);

            // EJECUTA LA CONSULTA
            cmd.ExecuteNonQuery();

            // CIERRA LA CONEXION
            cn.CerrarConexion();
        }

        // METODO PARA BUSCAR PROVEEDORES
        public DataTable BuscarProveedor(
            string buscar)
        {
            // CREACION DE TABLA TEMPORAL
            DataTable tabla =
                new DataTable();

            // CONSULTA SQL PARA BUSCAR POR NOMBRE O EMPRESA
            SqlCommand cmd =
                new SqlCommand(
                    @"SELECT * FROM Proveedores
                    WHERE Nombre LIKE @Buscar
                    OR Empresa LIKE @Buscar",
                    cn.AbrirConexion());

            // PARAMETRO DE BUSQUEDA
            cmd.Parameters.AddWithValue(
                "@Buscar",
                "%" + buscar + "%");

            // ADAPTADOR PARA EJECUTAR LA CONSULTA
            SqlDataAdapter da =
                new SqlDataAdapter(cmd);

            // LLENA LA TABLA CON LOS RESULTADOS
            da.Fill(tabla);

            // CIERRA LA CONEXION
            cn.CerrarConexion();

            // RETORNA LOS DATOS ENCONTRADOS
            return tabla;
        }
    }
}