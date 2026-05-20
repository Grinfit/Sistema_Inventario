// IMPORTACION DE LIBRERIAS NECESARIAS PARA EL MANEJO DE DATOS Y SQL SERVER
using System.Data;
using System.Data.SqlClient;

namespace Sistema_Inventario.Datos
{
    // CLASE ENCARGADA DE REALIZAR LAS OPERACIONES CRUD DE LA TABLA BODEGAS
    public class DBodegas
    {
        // CREACION DEL OBJETO DE CONEXION A LA BASE DE DATOS
        Conexion cn = new Conexion();

        // METODO PARA MOSTRAR TODOS LOS REGISTROS DE LA TABLA BODEGAS
        public DataTable MostrarBodegas()
        {
            // CREACION DE UNA TABLA TEMPORAL PARA GUARDAR LOS DATOS
            DataTable tabla = new DataTable();

            // CONSULTA SQL PARA OBTENER TODOS LOS REGISTROS
            SqlCommand cmd = new SqlCommand(
                "SELECT * FROM Bodegas",
                cn.AbrirConexion());

            // ADAPTADOR PARA LLENAR LA TABLA CON LOS DATOS OBTENIDOS
            SqlDataAdapter da =
                new SqlDataAdapter(cmd);

            // LLENA LA TABLA CON LOS DATOS DE LA CONSULTA
            da.Fill(tabla);

            // CIERRA LA CONEXION A LA BASE DE DATOS
            cn.CerrarConexion();

            // RETORNA LA TABLA CON LOS DATOS
            return tabla;
        }

        // METODO PARA INSERTAR UNA NUEVA BODEGA
        public void InsertarBodega(
            string nombre,
            string direccion)
        {
            // CONSULTA SQL PARA INSERTAR DATOS EN LA TABLA BODEGAS
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO Bodegas(Nombre,Direccion) VALUES(@Nombre,@Direccion)",
                cn.AbrirConexion());

            // PARAMETRO PARA EL NOMBRE DE LA BODEGA
            cmd.Parameters.AddWithValue(
                "@Nombre",
                nombre);

            // PARAMETRO PARA LA DIRECCION DE LA BODEGA
            cmd.Parameters.AddWithValue(
                "@Direccion",
                direccion);

            // EJECUTA LA CONSULTA
            cmd.ExecuteNonQuery();

            // CIERRA LA CONEXION
            cn.CerrarConexion();
        }

        // METODO PARA EDITAR UNA BODEGA EXISTENTE
        public void EditarBodega(
            int idBodega,
            string nombre,
            string direccion)
        {
            // CONSULTA SQL PARA ACTUALIZAR LOS DATOS DE UNA BODEGA
            SqlCommand cmd = new SqlCommand(
                "UPDATE Bodegas SET Nombre=@Nombre, Direccion=@Direccion WHERE IdBodega=@IdBodega",
                cn.AbrirConexion());

            // PARAMETRO PARA IDENTIFICAR LA BODEGA
            cmd.Parameters.AddWithValue(
                "@IdBodega",
                idBodega);

            // PARAMETRO PARA EL NUEVO NOMBRE
            cmd.Parameters.AddWithValue(
                "@Nombre",
                nombre);

            // PARAMETRO PARA LA NUEVA DIRECCION
            cmd.Parameters.AddWithValue(
                "@Direccion",
                direccion);

            // EJECUTA LA CONSULTA
            cmd.ExecuteNonQuery();

            // CIERRA LA CONEXION
            cn.CerrarConexion();
        }

        // METODO PARA ELIMINAR UNA BODEGA
        public void EliminarBodega(int idBodega)
        {
            // CONSULTA SQL PARA ELIMINAR EL REGISTRO
            SqlCommand cmd = new SqlCommand(
                "DELETE FROM Bodegas WHERE IdBodega=@IdBodega",
                cn.AbrirConexion());

            // PARAMETRO PARA IDENTIFICAR LA BODEGA A ELIMINAR
            cmd.Parameters.AddWithValue(
                "@IdBodega",
                idBodega);

            // EJECUTA LA CONSULTA
            cmd.ExecuteNonQuery();

            // CIERRA LA CONEXION
            cn.CerrarConexion();
        }

        // METODO PARA BUSCAR BODEGAS POR NOMBRE
        public DataTable BuscarBodega(string buscar)
        {
            // CREACION DE LA TABLA TEMPORAL
            DataTable tabla = new DataTable();

            // CONSULTA SQL PARA BUSCAR REGISTROS POR NOMBRE
            SqlCommand cmd = new SqlCommand(
                "SELECT * FROM Bodegas WHERE Nombre LIKE @Buscar",
                cn.AbrirConexion());

            // PARAMETRO DE BUSQUEDA UTILIZANDO LIKE
            cmd.Parameters.AddWithValue(
                "@Buscar",
                "%" + buscar + "%");

            // ADAPTADOR PARA LLENAR LA TABLA
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