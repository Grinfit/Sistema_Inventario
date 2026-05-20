// IMPORTACION DE LIBRERIAS NECESARIAS PARA EL MANEJO DE DATOS Y SQL SERVER
using System.Data;
using System.Data.SqlClient;

namespace Sistema_Inventario.Datos
{
    // CLASE ENCARGADA DE MOSTRAR Y FILTRAR LOS MOVIMIENTOS DEL KARDEX
    public class DKardex
    {
        // CREACION DEL OBJETO DE CONEXION
        Conexion cn =
            new Conexion();

        // METODO PARA MOSTRAR LOS PRODUCTOS REGISTRADOS
        public DataTable MostrarProductos()
        {
            // CREACION DE UNA TABLA TEMPORAL
            DataTable tabla =
                new DataTable();

            // CONSULTA SQL PARA OBTENER EL ID Y NOMBRE DE LOS PRODUCTOS
            SqlDataAdapter da =
                new SqlDataAdapter(
                    "SELECT IdProducto, Nombre FROM Productos",
                    cn.AbrirConexion());

            // LLENA LA TABLA CON LOS DATOS OBTENIDOS
            da.Fill(tabla);

            // CIERRA LA CONEXION
            cn.CerrarConexion();

            // RETORNA LA TABLA CON LOS PRODUCTOS
            return tabla;
        }

        // METODO PARA MOSTRAR TODOS LOS MOVIMIENTOS DEL KARDEX
        public DataTable MostrarKardex()
        {
            // CREACION DE UNA TABLA TEMPORAL
            DataTable tabla =
                new DataTable();

            // CONSULTA SQL PARA MOSTRAR LOS MOVIMIENTOS DEL INVENTARIO
            SqlDataAdapter da =
                new SqlDataAdapter(
                    @"SELECT
                        MI.IdMovimiento,
                        TM.Nombre AS TipoMovimiento,
                        P.Nombre AS Producto,
                        B.Nombre AS Bodega,
                        DMI.Cantidad,
                        MI.Fecha,
                        MI.Observacion,
                        MI.UsuarioRegistro
                    FROM MovimientosInventario MI
                    INNER JOIN TiposMovimiento TM
                        ON MI.IdTipoMovimiento = TM.IdTipoMovimiento
                    INNER JOIN DetalleMovimientoInventario DMI
                        ON MI.IdMovimiento = DMI.IdMovimiento
                    INNER JOIN Productos P
                        ON DMI.IdProducto = P.IdProducto
                    INNER JOIN Bodegas B
                        ON DMI.IdBodega = B.IdBodega
                    ORDER BY MI.Fecha DESC",
                    cn.AbrirConexion());

            // LLENA LA TABLA CON LOS DATOS DEL KARDEX
            da.Fill(tabla);

            // CIERRA LA CONEXION
            cn.CerrarConexion();

            // RETORNA LOS DATOS OBTENIDOS
            return tabla;
        }

        // METODO PARA FILTRAR LOS MOVIMIENTOS POR PRODUCTO
        public DataTable FiltrarProducto(
            int idProducto)
        {
            // CREACION DE UNA TABLA TEMPORAL
            DataTable tabla =
                new DataTable();

            // CONSULTA SQL PARA MOSTRAR LOS MOVIMIENTOS DE UN PRODUCTO ESPECIFICO
            SqlCommand cmd =
                new SqlCommand(
                    @"SELECT
                        MI.IdMovimiento,
                        TM.Nombre AS TipoMovimiento,
                        P.Nombre AS Producto,
                        B.Nombre AS Bodega,
                        DMI.Cantidad,
                        MI.Fecha,
                        MI.Observacion,
                        MI.UsuarioRegistro
                    FROM MovimientosInventario MI
                    INNER JOIN TiposMovimiento TM
                        ON MI.IdTipoMovimiento = TM.IdTipoMovimiento
                    INNER JOIN DetalleMovimientoInventario DMI
                        ON MI.IdMovimiento = DMI.IdMovimiento
                    INNER JOIN Productos P
                        ON DMI.IdProducto = P.IdProducto
                    INNER JOIN Bodegas B
                        ON DMI.IdBodega = B.IdBodega
                    WHERE P.IdProducto=@IdProducto
                    ORDER BY MI.Fecha DESC",
                    cn.AbrirConexion());

            // PARAMETRO PARA FILTRAR POR EL ID DEL PRODUCTO
            cmd.Parameters.AddWithValue(
                "@IdProducto",
                idProducto);

            // ADAPTADOR PARA EJECUTAR LA CONSULTA
            SqlDataAdapter da =
                new SqlDataAdapter(cmd);

            // LLENA LA TABLA CON LOS RESULTADOS
            da.Fill(tabla);

            // CIERRA LA CONEXION
            cn.CerrarConexion();

            // RETORNA LOS DATOS FILTRADOS
            return tabla;
        }
    }
}