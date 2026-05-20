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
        // BODEGAS
        // =====================================

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

        // =====================================
        // TIPOS MOVIMIENTO
        // =====================================

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
                        ON MI.IdTipoMovimiento =
                           TM.IdTipoMovimiento
                    INNER JOIN DetalleMovimientoInventario DMI
                        ON MI.IdMovimiento =
                           DMI.IdMovimiento
                    INNER JOIN Productos P
                        ON DMI.IdProducto =
                           P.IdProducto
                    INNER JOIN Bodegas B
                        ON DMI.IdBodega =
                           B.IdBodega
                    ORDER BY MI.IdMovimiento DESC",
                    cn.AbrirConexion());

            da.Fill(tabla);

            cn.CerrarConexion();

            return tabla;
        }

        // =====================================
        // OBTENER STOCK ACTUAL
        // =====================================

        public decimal ObtenerStockActual(
            int idProducto,
            int idBodega)
        {
            decimal stock = 0;

            SqlCommand cmd =
                new SqlCommand(
                    @"SELECT ISNULL(StockActual,0)
                    FROM StockBodega
                    WHERE IdProducto=@IdProducto
                    AND IdBodega=@IdBodega",
                    cn.AbrirConexion());

            cmd.Parameters.AddWithValue(
                "@IdProducto",
                idProducto);

            cmd.Parameters.AddWithValue(
                "@IdBodega",
                idBodega);

            object resultado =
                cmd.ExecuteScalar();

            if (resultado != null)
            {
                stock =
                    Convert.ToDecimal(resultado);
            }

            cn.CerrarConexion();

            return stock;
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
                // VALIDAR STOCK EN SALIDAS
                // =================================

                if (idTipoMovimiento == 2)
                {
                    decimal stockActual =
                        ObtenerStockActual(
                            idProducto,
                            idBodega);

                    if (cantidad > stockActual)
                    {
                        throw new Exception(
                            $"Stock insuficiente.\n\n" +
                            $"Stock actual: {stockActual}");
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
                            Fecha,
                            Observacion,
                            UsuarioRegistro
                        )
                        VALUES
                        (
                            @IdTipoMovimiento,
                            GETDATE(),
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
                // DEFINIR OPERACION
                // =================================

                string operacion = "+";

                // SALIDA
                if (idTipoMovimiento == 2)
                {
                    operacion = "-";
                }

                // AJUSTE
                if (idTipoMovimiento == 3)
                {
                    operacion = "+";
                }

                // TRANSFERENCIA
                if (idTipoMovimiento == 4)
                {
                    operacion = "+";
                }

                // =================================
                // ACTUALIZAR STOCK PRODUCTOS
                // =================================

                SqlCommand cmdProducto =
                    new SqlCommand(
                        $@"UPDATE Productos
                        SET Stock =
                        ISNULL(Stock,0)
                        {operacion}
                        @Cantidad
                        WHERE IdProducto=@IdProducto",
                        conexion,
                        transaccion);

                cmdProducto.Parameters.AddWithValue(
                    "@Cantidad",
                    cantidad);

                cmdProducto.Parameters.AddWithValue(
                    "@IdProducto",
                    idProducto);

                cmdProducto.ExecuteNonQuery();

                // =================================
                // VALIDAR SI EXISTE STOCK BODEGA
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

                // =================================
                // INSERTAR STOCK BODEGA
                // =================================

                if (existe == 0)
                {
                    SqlCommand cmdInsert =
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

                    decimal stockInicial = 0;

                    if (idTipoMovimiento == 1)
                    {
                        stockInicial = cantidad;
                    }

                    if (idTipoMovimiento == 3)
                    {
                        stockInicial = cantidad;
                    }

                    if (idTipoMovimiento == 4)
                    {
                        stockInicial = cantidad;
                    }

                    cmdInsert.Parameters.AddWithValue(
                        "@IdProducto",
                        idProducto);

                    cmdInsert.Parameters.AddWithValue(
                        "@IdBodega",
                        idBodega);

                    cmdInsert.Parameters.AddWithValue(
                        "@StockActual",
                        stockInicial);

                    cmdInsert.ExecuteNonQuery();
                }
                else
                {
                    // =============================
                    // ACTUALIZAR STOCK BODEGA
                    // =============================

                    SqlCommand cmdUpdate =
                        new SqlCommand(
                            $@"UPDATE StockBodega
                            SET StockActual =
                            ISNULL(StockActual,0)
                            {operacion}
                            @Cantidad
                            WHERE IdProducto=@IdProducto
                            AND IdBodega=@IdBodega",
                            conexion,
                            transaccion);

                    cmdUpdate.Parameters.AddWithValue(
                        "@Cantidad",
                        cantidad);

                    cmdUpdate.Parameters.AddWithValue(
                        "@IdProducto",
                        idProducto);

                    cmdUpdate.Parameters.AddWithValue(
                        "@IdBodega",
                        idBodega);

                    cmdUpdate.ExecuteNonQuery();
                }

                // =================================
                // LOGS
                // =================================

                string tipoMovimientoLog =
                    "INVENTARIO";

                if (idTipoMovimiento == 1)
                {
                    tipoMovimientoLog =
                        "INVENTARIO_ENTRADA";
                }

                if (idTipoMovimiento == 2)
                {
                    tipoMovimientoLog =
                        "INVENTARIO_SALIDA";
                }

                if (idTipoMovimiento == 3)
                {
                    tipoMovimientoLog =
                        "INVENTARIO_AJUSTE";
                }

                if (idTipoMovimiento == 4)
                {
                    tipoMovimientoLog =
                        "INVENTARIO_TRANSFERENCIA";
                }

                log.RegistrarLog(
                    tipoMovimientoLog,
                    usuario,
                    "Movimiento inventario | Producto ID: " +
                    idProducto +
                    " | Bodega ID: " +
                    idBodega +
                    " | Cantidad: " +
                    cantidad);

                // =================================
                // COMMIT
                // =================================

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