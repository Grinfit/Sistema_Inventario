// IMPORTACION DE LIBRERIAS NECESARIAS PARA EL MANEJO DE DATOS Y SQL SERVER
using System;
using System.Data;
using System.Data.SqlClient;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Datos
{
    // CLASE ENCARGADA DE GESTIONAR LOS MOVIMIENTOS DEL INVENTARIO
    public class DMovimientosInventario
    {
        // OBJETO DE CONEXION A LA BASE DE DATOS
        Conexion cn =
            new Conexion();

        // OBJETO PARA EL REGISTRO DE LOGS DEL SISTEMA
        Logger log =
            new Logger();

        // METODO PARA MOSTRAR LOS PRODUCTOS
        public DataTable MostrarProductos()
        {
            // CREACION DE TABLA TEMPORAL
            DataTable tabla =
                new DataTable();

            // CONSULTA SQL PARA OBTENER PRODUCTOS
            SqlDataAdapter da =
                new SqlDataAdapter(
                    "SELECT IdProducto, Nombre FROM Productos",
                    cn.AbrirConexion());

            // LLENA LA TABLA CON LOS DATOS
            da.Fill(tabla);

            // CIERRA LA CONEXION
            cn.CerrarConexion();

            // RETORNA LA TABLA
            return tabla;
        }

        // METODO PARA MOSTRAR LAS BODEGAS
        public DataTable MostrarBodegas()
        {
            // CREACION DE TABLA TEMPORAL
            DataTable tabla =
                new DataTable();

            // CONSULTA SQL PARA OBTENER BODEGAS
            SqlDataAdapter da =
                new SqlDataAdapter(
                    "SELECT IdBodega, Nombre FROM Bodegas",
                    cn.AbrirConexion());

            // LLENA LA TABLA
            da.Fill(tabla);

            // CIERRA LA CONEXION
            cn.CerrarConexion();

            // RETORNA LOS DATOS
            return tabla;
        }

        // METODO PARA MOSTRAR LOS TIPOS DE MOVIMIENTO
        public DataTable MostrarTiposMovimiento()
        {
            // CREACION DE TABLA TEMPORAL
            DataTable tabla =
                new DataTable();

            // CONSULTA SQL PARA OBTENER TIPOS DE MOVIMIENTO
            SqlDataAdapter da =
                new SqlDataAdapter(
                    "SELECT IdTipoMovimiento, Nombre FROM TiposMovimiento",
                    cn.AbrirConexion());

            // LLENA LA TABLA
            da.Fill(tabla);

            // CIERRA LA CONEXION
            cn.CerrarConexion();

            // RETORNA LOS DATOS
            return tabla;
        }

        // METODO PARA MOSTRAR TODOS LOS MOVIMIENTOS DEL INVENTARIO
        public DataTable MostrarMovimientos()
        {
            // CREACION DE TABLA TEMPORAL
            DataTable tabla =
                new DataTable();

            // CONSULTA SQL PARA MOSTRAR LOS MOVIMIENTOS
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

            // LLENA LA TABLA CON LOS DATOS
            da.Fill(tabla);

            // CIERRA LA CONEXION
            cn.CerrarConexion();

            // RETORNA LOS DATOS
            return tabla;
        }

        // METODO PARA OBTENER EL STOCK ACTUAL DE UN PRODUCTO EN UNA BODEGA
        public decimal ObtenerStockActual(
            int idProducto,
            int idBodega)
        {
            // VARIABLE PARA GUARDAR EL STOCK
            decimal stock = 0;

            // CONSULTA SQL PARA OBTENER EL STOCK ACTUAL
            SqlCommand cmd =
                new SqlCommand(
                    @"SELECT ISNULL(StockActual,0)
                    FROM StockBodega
                    WHERE IdProducto=@IdProducto
                    AND IdBodega=@IdBodega",
                    cn.AbrirConexion());

            // PARAMETRO DEL PRODUCTO
            cmd.Parameters.AddWithValue(
                "@IdProducto",
                idProducto);

            // PARAMETRO DE LA BODEGA
            cmd.Parameters.AddWithValue(
                "@IdBodega",
                idBodega);

            // EJECUTA LA CONSULTA Y OBTIENE EL RESULTADO
            object resultado =
                cmd.ExecuteScalar();

            // VERIFICA SI EXISTE RESULTADO
            if (resultado != null)
            {
                // CONVIERTE EL RESULTADO A DECIMAL
                stock =
                    Convert.ToDecimal(resultado);
            }

            // CIERRA LA CONEXION
            cn.CerrarConexion();

            // RETORNA EL STOCK
            return stock;
        }

        // METODO PARA REGISTRAR MOVIMIENTOS DE INVENTARIO
        public void RegistrarMovimiento(
            int idTipoMovimiento,
            int idProducto,
            int idBodega,
            decimal cantidad,
            string observacion,
            string usuario)
        {
            // ABRE LA CONEXION
            SqlConnection conexion =
                cn.AbrirConexion();

            // INICIA UNA TRANSACCION
            SqlTransaction transaccion =
                conexion.BeginTransaction();

            try
            {
                // VERIFICA STOCK PARA SALIDA — usa la misma conexión y
                // transacción activa para no cerrar la conexión compartida
                if (idTipoMovimiento == 2)
                {
                    SqlCommand cmdStock =
                        new SqlCommand(
                            @"SELECT ISNULL(StockActual, 0)
                              FROM StockBodega
                              WHERE IdProducto = @IdProducto
                              AND   IdBodega   = @IdBodega",
                            conexion,
                            transaccion);

                    cmdStock.Parameters.AddWithValue(
                        "@IdProducto", idProducto);
                    cmdStock.Parameters.AddWithValue(
                        "@IdBodega", idBodega);

                    object res = cmdStock.ExecuteScalar();
                    decimal stockActual =
                        res != null ? Convert.ToDecimal(res) : 0m;

                    if (cantidad > stockActual)
                        throw new Exception(
                            $"Stock insuficiente.\n\n" +
                            $"Stock actual en bodega: {stockActual}");
                }

                // CONSULTA SQL PARA INSERTAR EL MOVIMIENTO
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

                // PARAMETRO DEL TIPO DE MOVIMIENTO
                cmdMovimiento.Parameters.AddWithValue(
                    "@IdTipoMovimiento",
                    idTipoMovimiento);

                // PARAMETRO DE OBSERVACION
                cmdMovimiento.Parameters.AddWithValue(
                    "@Observacion",
                    observacion);

                // PARAMETRO DEL USUARIO
                cmdMovimiento.Parameters.AddWithValue(
                    "@UsuarioRegistro",
                    usuario);

                // OBTIENE EL ID DEL MOVIMIENTO INSERTADO
                int idMovimiento =
                    Convert.ToInt32(
                        cmdMovimiento.ExecuteScalar());

                // CONSULTA SQL PARA INSERTAR EL DETALLE DEL MOVIMIENTO
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

                // PARAMETRO DEL MOVIMIENTO
                cmdDetalle.Parameters.AddWithValue(
                    "@IdMovimiento",
                    idMovimiento);

                // PARAMETRO DEL PRODUCTO
                cmdDetalle.Parameters.AddWithValue(
                    "@IdProducto",
                    idProducto);

                // PARAMETRO DE LA BODEGA
                cmdDetalle.Parameters.AddWithValue(
                    "@IdBodega",
                    idBodega);

                // PARAMETRO DE LA CANTIDAD
                cmdDetalle.Parameters.AddWithValue(
                    "@Cantidad",
                    cantidad);

                // EJECUTA LA CONSULTA
                cmdDetalle.ExecuteNonQuery();

                // OBTIENE EL NOMBRE DEL TIPO PARA NO DEPENDER DE IDS HARDCODEADOS
                SqlCommand cmdNombreTipo =
                    new SqlCommand(
                        @"SELECT UPPER(LTRIM(RTRIM(Nombre)))
                          FROM TiposMovimiento
                          WHERE IdTipoMovimiento = @Id",
                        conexion,
                        transaccion);

                cmdNombreTipo.Parameters.AddWithValue(
                    "@Id", idTipoMovimiento);

                string nombreTipo =
                    cmdNombreTipo.ExecuteScalar()?.ToString() ?? "";

                // SALIDAS Y DEVOLUCIONES RESTAN STOCK; EL RESTO SUMA
                string operacion =
                    nombreTipo.Contains("SALIDA") ? "-" : "+";

                // CONSULTA SQL PARA ACTUALIZAR EL STOCK DEL PRODUCTO
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

                // PARAMETRO DE CANTIDAD
                cmdProducto.Parameters.AddWithValue(
                    "@Cantidad",
                    cantidad);

                // PARAMETRO DEL PRODUCTO
                cmdProducto.Parameters.AddWithValue(
                    "@IdProducto",
                    idProducto);

                // EJECUTA LA CONSULTA
                cmdProducto.ExecuteNonQuery();

                // CONSULTA PARA VALIDAR EXISTENCIA DEL STOCK
                SqlCommand cmdExiste =
                    new SqlCommand(
                        @"SELECT COUNT(*)
                        FROM StockBodega
                        WHERE IdProducto=@IdProducto
                        AND IdBodega=@IdBodega",
                        conexion,
                        transaccion);

                // PARAMETRO DEL PRODUCTO
                cmdExiste.Parameters.AddWithValue(
                    "@IdProducto",
                    idProducto);

                // PARAMETRO DE LA BODEGA
                cmdExiste.Parameters.AddWithValue(
                    "@IdBodega",
                    idBodega);

                // OBTIENE LA CANTIDAD DE REGISTROS
                int existe =
                    Convert.ToInt32(
                        cmdExiste.ExecuteScalar());

                // VERIFICA SI NO EXISTE EL REGISTRO
                if (existe == 0)
                {
                    // CONSULTA PARA INSERTAR STOCK EN BODEGA
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

                    // STOCK INICIAL: si la operación es suma usa la cantidad,
                    // si es resta (SALIDA) el registro de bodega aún no existe
                    // por lo que el stock inicial queda en 0
                    decimal stockInicial = operacion == "+" ? cantidad : 0m;

                    // PARAMETRO DEL PRODUCTO
                    cmdInsert.Parameters.AddWithValue(
                        "@IdProducto",
                        idProducto);

                    // PARAMETRO DE LA BODEGA
                    cmdInsert.Parameters.AddWithValue(
                        "@IdBodega",
                        idBodega);

                    // PARAMETRO DEL STOCK
                    cmdInsert.Parameters.AddWithValue(
                        "@StockActual",
                        stockInicial);

                    // EJECUTA LA CONSULTA
                    cmdInsert.ExecuteNonQuery();
                }
                else
                {
                    // CONSULTA PARA ACTUALIZAR EL STOCK DE BODEGA
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

                    // PARAMETRO DE CANTIDAD
                    cmdUpdate.Parameters.AddWithValue(
                        "@Cantidad",
                        cantidad);

                    // PARAMETRO DEL PRODUCTO
                    cmdUpdate.Parameters.AddWithValue(
                        "@IdProducto",
                        idProducto);

                    // PARAMETRO DE LA BODEGA
                    cmdUpdate.Parameters.AddWithValue(
                        "@IdBodega",
                        idBodega);

                    // EJECUTA LA CONSULTA
                    cmdUpdate.ExecuteNonQuery();
                }

                // TIPO DE LOG DERIVADO DEL NOMBRE REAL DEL TIPO (sin IDs fijos)
                string tipoMovimientoLog = string.IsNullOrEmpty(nombreTipo)
                    ? "INVENTARIO"
                    : "INVENTARIO_" + nombreTipo.Replace(" ", "_");

                // REGISTRA EL LOG DEL MOVIMIENTO
                log.RegistrarLog(
                    tipoMovimientoLog,
                    usuario,
                    "Movimiento inventario | Producto ID: " +
                    idProducto +
                    " | Bodega ID: " +
                    idBodega +
                    " | Cantidad: " +
                    cantidad);

                // CONFIRMA LA TRANSACCION
                transaccion.Commit();

                // CIERRA LA CONEXION
                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                // REVIERTE LA TRANSACCION EN CASO DE ERROR
                transaccion.Rollback();

                // REGISTRA EL ERROR EN LOS LOGS
                log.RegistrarLog(
                    "ERROR_INVENTARIO",
                    usuario,
                    ex.Message);

                // CIERRA LA CONEXION
                cn.CerrarConexion();

                // LANZA NUEVAMENTE EL ERROR
                throw;
            }
        }
    }
}