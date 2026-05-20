// IMPORTACION DE LIBRERIAS NECESARIAS PARA EL MANEJO DE DATOS Y SQL SERVER
using System.Data;
using System.Data.SqlClient;

namespace Sistema_Inventario.Datos
{
    // CLASE ENCARGADA DE MOSTRAR EL STOCK DE LAS BODEGAS
    public class DStockBodega
    {
        // OBJETO DE CONEXION A LA BASE DE DATOS
        Conexion cn =
            new Conexion();

        // METODO PARA MOSTRAR TODO EL STOCK
        public DataTable MostrarStock()
        {
            // CREACION DE TABLA TEMPORAL
            DataTable tabla =
                new DataTable();

            // CONSULTA SQL PARA MOSTRAR EL STOCK ACTUAL
            SqlDataAdapter da =
                new SqlDataAdapter(
                    @"SELECT
                        SB.IdStock,
                        P.Nombre AS Producto,
                        B.Nombre AS Bodega,
                        SB.StockActual
                    FROM StockBodega SB
                    INNER JOIN Productos P
                        ON SB.IdProducto = P.IdProducto
                    INNER JOIN Bodegas B
                        ON SB.IdBodega = B.IdBodega
                    ORDER BY P.Nombre",
                    cn.AbrirConexion());

            // LLENA LA TABLA CON LOS DATOS
            da.Fill(tabla);

            // CIERRA LA CONEXION
            cn.CerrarConexion();

            // RETORNA LOS DATOS
            return tabla;
        }

        // METODO PARA MOSTRAR PRODUCTOS CON STOCK BAJO
        public DataTable MostrarStockBajo()
        {
            // CREACION DE TABLA TEMPORAL
            DataTable tabla =
                new DataTable();

            // CONSULTA SQL PARA MOSTRAR PRODUCTOS CON STOCK MENOR O IGUAL A 5
            SqlDataAdapter da =
                new SqlDataAdapter(
                    @"SELECT
                        SB.IdStock,
                        P.Nombre AS Producto,
                        B.Nombre AS Bodega,
                        SB.StockActual
                    FROM StockBodega SB
                    INNER JOIN Productos P
                        ON SB.IdProducto = P.IdProducto
                    INNER JOIN Bodegas B
                        ON SB.IdBodega = B.IdBodega
                    WHERE SB.StockActual <= 5
                    ORDER BY SB.StockActual ASC",
                    cn.AbrirConexion());

            // LLENA LA TABLA CON LOS DATOS
            da.Fill(tabla);

            // CIERRA LA CONEXION
            cn.CerrarConexion();

            // RETORNA LOS DATOS
            return tabla;
        }
    }
}