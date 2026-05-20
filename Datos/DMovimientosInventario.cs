using System;
using System.Data;
using System.Data.SqlClient;

using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Datos
{
    public class DMovimientosInventario
    {
        Conexion cn =
            new Conexion();

        Logger log =
            new Logger();

        // =====================================
        // COMBOS
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

        public DataTable MostrarBodegas()
        {
            DataTable tabla =
                new DataTable();

            SqlDataAdapter da =
                new SqlDataAdapter(
                    "SELECT IdBodega, Nombre FROM Bodegas",
                    cn.AbrirConexion());

            da.Fill(tabla);

            cn.CerrarConexion();

            return tabla;
        }

        public DataTable MostrarTiposMovimiento()
        {
            DataTable tabla =
                new DataTable();

            SqlDataAdapter da =
                new SqlDataAdapter(
                    "SELECT IdTipoMovimiento, Nombre FROM TiposMovimiento",
                    cn.AbrirConexion());

            da.Fill(tabla);

            cn.CerrarConexion();

            return tabla;
        }

        // =====================================
        // MOSTRAR MOVIMIENTOS
        // =====================================

        public DataTable MostrarMovimientos()
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
                    ORDER BY MI.IdMovimiento DESC",
                    cn.AbrirConexion());

            da.Fill(tabla);

            cn.CerrarConexion();

            return tabla;
        }

        // =====================================
        // REGISTRAR MOVIMIENTO
        // =====================================

        public void RegistrarMovimiento(
            int idTipoMovimiento,
            int idProducto,
            int idBodega,
            decimal cantidad,
            string observacion,
            string usuario)
        {
            SqlConnection conexion =
                cn.AbrirConexion();

            SqlTransaction transaccion =
                conexion.BeginTransaction();

            try
            {
                // =================================
                // VALIDAR STOCK SI ES SALIDA
                // =================================

                if (idTipoMovimiento == 2)
                {
                    SqlCommand cmdValidar =
                        new SqlCommand(
                            @"SELECT ISNULL(StockActual,0)
                            FROM StockBodega
                            WHERE IdProducto=@IdProducto
                            AND IdBodega=@IdBodega",
                            conexion,
                            transaccion);

                    cmdValidar.Parameters.AddWithValue(
                        "@IdProducto",
                        idProducto);

                    cmdValidar.Parameters.AddWithValue(
                        "@IdBodega",
                        idBodega);

                    object resultado =
                        cmdValidar.ExecuteScalar();

                    decimal stockActual = 0;

                    if (resultado != null)
                    {
                        stockActual =
                            Convert.ToDecimal(resultado);
                    }

                    if (stockActual < cantidad)
                    {
                        throw new Exception(
                            "No hay stock suficiente en la bodega.");
                    }
                }

                // =================================
                // INSERTAR MOVIMIENTO
                // =================================

                SqlCommand cmdMovimiento =
                    new SqlCommand(
                        @"INSERT INTO MovimientosInventario
                        (
                            IdTipoMovimiento,
                            Observacion,
                            UsuarioRegistro
                        )
                        VALUES
                        (
                            @IdTipoMovimiento,
                            @Observacion,
                            @UsuarioRegistro
                        );

                        SELECT SCOPE_IDENTITY();",
                        conexion,
                        transaccion);

                cmdMovimiento.Parameters.AddWithValue(
                    "@IdTipoMovimiento",
                    idTipoMovimiento);

                cmdMovimiento.Parameters.AddWithValue(
                    "@Observacion",
                    observacion);

                cmdMovimiento.Parameters.AddWithValue(
                    "@UsuarioRegistro",
                    usuario);

                int idMovimiento =
                    Convert.ToInt32(
                        cmdMovimiento.ExecuteScalar());

                // =================================
                // INSERTAR DETALLE
                // =================================

                SqlCommand cmdDetalle =
                    new SqlCommand(
                        @"INSERT INTO
                        DetalleMovimientoInventario
                        (
                            IdMovimiento,
                            IdProducto,
                            IdBodega,
                            Cantidad
                        )
                        VALUES
                        (
                            @IdMovimiento,
                            @IdProducto,
                            @IdBodega,
                            @Cantidad
                        )",
                        conexion,
                        transaccion);

                cmdDetalle.Parameters.AddWithValue(
                    "@IdMovimiento",
                    idMovimiento);

                cmdDetalle.Parameters.AddWithValue(
                    "@IdProducto",
                    idProducto);

                cmdDetalle.Parameters.AddWithValue(
                    "@IdBodega",
                    idBodega);

                cmdDetalle.Parameters.AddWithValue(
                    "@Cantidad",
                    cantidad);

                cmdDetalle.ExecuteNonQuery();

                // =================================
                // OPERACION STOCK
                // =================================

                string operacion =
                    (idTipoMovimiento == 1)
                    ? "+"
                    : "-";

                // =================================
                // ACTUALIZAR PRODUCTOS
                // =================================

                SqlCommand cmdStockProducto =
                    new SqlCommand(
                        $@"UPDATE Productos
                        SET Stock = Stock {operacion} @Cantidad
                        WHERE IdProducto=@IdProducto",
                        conexion,
                        transaccion);

                cmdStockProducto.Parameters.AddWithValue(
                    "@Cantidad",
                    cantidad);

                cmdStockProducto.Parameters.AddWithValue(
                    "@IdProducto",
                    idProducto);

                cmdStockProducto.ExecuteNonQuery();

                // =================================
                // VALIDAR STOCK BODEGA
                // =================================

                SqlCommand cmdExiste =
                    new SqlCommand(
                        @"SELECT COUNT(*)
                        FROM StockBodega
                        WHERE IdProducto=@IdProducto
                        AND IdBodega=@IdBodega",
                        conexion,
                        transaccion);

                cmdExiste.Parameters.AddWithValue(
                    "@IdProducto",
                    idProducto);

                cmdExiste.Parameters.AddWithValue(
                    "@IdBodega",
                    idBodega);

                int existe =
                    Convert.ToInt32(
                        cmdExiste.ExecuteScalar());

                if (existe == 0)
                {
                    SqlCommand cmdInsertStock =
                        new SqlCommand(
                            @"INSERT INTO StockBodega
                            (
                                IdProducto,
                                IdBodega,
                                StockActual
                            )
                            VALUES
                            (
                                @IdProducto,
                                @IdBodega,
                                @StockActual
                            )",
                            conexion,
                            transaccion);

                    cmdInsertStock.Parameters.AddWithValue(
                        "@IdProducto",
                        idProducto);

                    cmdInsertStock.Parameters.AddWithValue(
                        "@IdBodega",
                        idBodega);

                    cmdInsertStock.Parameters.AddWithValue(
                        "@StockActual",
                        cantidad);

                    cmdInsertStock.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand cmdUpdateStock =
                        new SqlCommand(
                            $@"UPDATE StockBodega
                            SET StockActual =
                            StockActual {operacion} @Cantidad
                            WHERE IdProducto=@IdProducto
                            AND IdBodega=@IdBodega",
                            conexion,
                            transaccion);

                    cmdUpdateStock.Parameters.AddWithValue(
                        "@Cantidad",
                        cantidad);

                    cmdUpdateStock.Parameters.AddWithValue(
                        "@IdProducto",
                        idProducto);

                    cmdUpdateStock.Parameters.AddWithValue(
                        "@IdBodega",
                        idBodega);

                    cmdUpdateStock.ExecuteNonQuery();
                }

                // =================================
                // LOGS
                // =================================

                string tipoMovimiento =
                    (idTipoMovimiento == 1)
                    ? "INVENTARIO_ENTRADA"
                    : "INVENTARIO_SALIDA";

                log.RegistrarLog(
                    tipoMovimiento,
                    usuario,
                    "Movimiento inventario | Producto ID: " +
                    idProducto +
                    " | Bodega ID: " +
                    idBodega +
                    " | Cantidad: " +
                    cantidad);

                transaccion.Commit();

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                transaccion.Rollback();

                log.RegistrarLog(
                    "ERROR_INVENTARIO",
                    usuario,
                    ex.Message);

                cn.CerrarConexion();

                throw;
            }
        }
    }
}