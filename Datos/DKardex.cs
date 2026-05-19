using System.Data;
using System.Data.SqlClient;

namespace Sistema_Inventario.Datos
{
    public class DKardex
    {
        Conexion cn =
            new Conexion();

        // =====================================
        // PRODUCTOS
        // =====================================

        public DataTable MostrarProductos()
        {
            DataTable tabla =
                new DataTable();

            SqlDataAdapter da =
                new SqlDataAdapter(
                    "SELECT IdProducto, Nombre FROM Productos",
                    cn.AbrirConexion());

            da.Fill(tabla);

            cn.CerrarConexion();

            return tabla;
        }

        // =====================================
        // KARDEX GENERAL
        // =====================================

        public DataTable MostrarKardex()
        {
            DataTable tabla =
                new DataTable();

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

            da.Fill(tabla);

            cn.CerrarConexion();

            return tabla;
        }

        // =====================================
        // FILTRAR PRODUCTO
        // =====================================

        public DataTable FiltrarProducto(
            int idProducto)
        {
            DataTable tabla =
                new DataTable();

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

            cmd.Parameters.AddWithValue(
                "@IdProducto",
                idProducto);

            SqlDataAdapter da =
                new SqlDataAdapter(cmd);

            da.Fill(tabla);

            cn.CerrarConexion();

            return tabla;
        }
    }
}