using System.Data;
using System.Data.SqlClient;

namespace Sistema_Inventario.Datos
{
    public class DStockBodega
    {
        Conexion cn =
            new Conexion();

        // =====================================
        // MOSTRAR STOCK
        // =====================================

        public DataTable MostrarStock()
        {
            DataTable tabla =
                new DataTable();

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

            da.Fill(tabla);

            cn.CerrarConexion();

            return tabla;
        }

        // =====================================
        // STOCK BAJO
        // =====================================

        public DataTable MostrarStockBajo()
        {
            DataTable tabla =
                new DataTable();

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

            da.Fill(tabla);

            cn.CerrarConexion();

            return tabla;
        }
    }
}