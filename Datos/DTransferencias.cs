using System;
using System.Data;
using System.Data.SqlClient;

namespace Sistema_Inventario.Datos
{
    public class DTransferencias
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
        // HISTORIAL
        // =====================================

        public DataTable MostrarTransferencias()
        {
            DataTable tabla =
                new DataTable();

            SqlDataAdapter da =
                new SqlDataAdapter(
                    @"SELECT
                        TB.IdTransferencia,
                        P.Nombre AS Producto,
                        BO.Nombre AS BodegaOrigen,
                        BD.Nombre AS BodegaDestino,
                        TB.Cantidad,
                        TB.Fecha,
                        TB.Observacion,
                        TB.UsuarioRegistro
                    FROM TransferenciasBodega TB
                    INNER JOIN Productos P
                        ON TB.IdProducto = P.IdProducto
                    INNER JOIN Bodegas BO
                        ON TB.IdBodegaOrigen = BO.IdBodega
                    INNER JOIN Bodegas BD
                        ON TB.IdBodegaDestino = BD.IdBodega
                    ORDER BY TB.IdTransferencia DESC",
                    cn.AbrirConexion());

            da.Fill(tabla);

            cn.CerrarConexion();

            return tabla;
        }

        // =====================================
        // TRANSFERIR
        // =====================================

        public void TransferirProducto(
            int idProducto,
            int idBodegaOrigen,
            int idBodegaDestino,
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
                // VALIDAR BODEGAS
                // =================================

                if (idBodegaOrigen ==
                    idBodegaDestino)
                {
                    throw new Exception(
                        "La bodega origen y destino no pueden ser iguales.");
                }

                // =================================
                // VALIDAR STOCK
                // =================================

                SqlCommand cmdStock =
                    new SqlCommand(
                        @"SELECT ISNULL(StockActual,0)
                        FROM StockBodega
                        WHERE IdProducto=@IdProducto
                        AND IdBodega=@IdBodega",
                        conexion,
                        transaccion);

                cmdStock.Parameters.AddWithValue(
                    "@IdProducto",
                    idProducto);

                cmdStock.Parameters.AddWithValue(
                    "@IdBodega",
                    idBodegaOrigen);

                decimal stockActual =
                    Convert.ToDecimal(
                        cmdStock.ExecuteScalar());

                if (stockActual < cantidad)
                {
                    throw new Exception(
                        "No hay stock suficiente en la bodega origen.");
                }

                // =================================
                // DESCONTAR ORIGEN
                // =================================

                SqlCommand cmdDescontar =
                    new SqlCommand(
                        @"UPDATE StockBodega
                        SET StockActual =
                        StockActual - @Cantidad
                        WHERE IdProducto=@IdProducto
                        AND IdBodega=@IdBodega",
                        conexion,
                        transaccion);

                cmdDescontar.Parameters.AddWithValue(
                    "@Cantidad",
                    cantidad);

                cmdDescontar.Parameters.AddWithValue(
                    "@IdProducto",
                    idProducto);

                cmdDescontar.Parameters.AddWithValue(
                    "@IdBodega",
                    idBodegaOrigen);

                cmdDescontar.ExecuteNonQuery();

                // =================================
                // VALIDAR DESTINO
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
                    idBodegaDestino);

                int existe =
                    Convert.ToInt32(
                        cmdExiste.ExecuteScalar());

                // =================================
                // INSERTAR O ACTUALIZAR DESTINO
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
                                @Cantidad
                            )",
                            conexion,
                            transaccion);

                    cmdInsert.Parameters.AddWithValue(
                        "@IdProducto",
                        idProducto);

                    cmdInsert.Parameters.AddWithValue(
                        "@IdBodega",
                        idBodegaDestino);

                    cmdInsert.Parameters.AddWithValue(
                        "@Cantidad",
                        cantidad);

                    cmdInsert.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand cmdSumar =
                        new SqlCommand(
                            @"UPDATE StockBodega
                            SET StockActual =
                            StockActual + @Cantidad
                            WHERE IdProducto=@IdProducto
                            AND IdBodega=@IdBodega",
                            conexion,
                            transaccion);

                    cmdSumar.Parameters.AddWithValue(
                        "@Cantidad",
                        cantidad);

                    cmdSumar.Parameters.AddWithValue(
                        "@IdProducto",
                        idProducto);

                    cmdSumar.Parameters.AddWithValue(
                        "@IdBodega",
                        idBodegaDestino);

                    cmdSumar.ExecuteNonQuery();
                }

                // =================================
                // REGISTRAR TRANSFERENCIA
                // =================================

                SqlCommand cmdTransferencia =
                    new SqlCommand(
                        @"INSERT INTO TransferenciasBodega
                        (
                            IdProducto,
                            IdBodegaOrigen,
                            IdBodegaDestino,
                            Cantidad,
                            Observacion,
                            UsuarioRegistro
                        )
                        VALUES
                        (
                            @IdProducto,
                            @IdBodegaOrigen,
                            @IdBodegaDestino,
                            @Cantidad,
                            @Observacion,
                            @UsuarioRegistro
                        )",
                        conexion,
                        transaccion);

                cmdTransferencia.Parameters.AddWithValue(
                    "@IdProducto",
                    idProducto);

                cmdTransferencia.Parameters.AddWithValue(
                    "@IdBodegaOrigen",
                    idBodegaOrigen);

                cmdTransferencia.Parameters.AddWithValue(
                    "@IdBodegaDestino",
                    idBodegaDestino);

                cmdTransferencia.Parameters.AddWithValue(
                    "@Cantidad",
                    cantidad);

                cmdTransferencia.Parameters.AddWithValue(
                    "@Observacion",
                    observacion);

                cmdTransferencia.Parameters.AddWithValue(
                    "@UsuarioRegistro",
                    usuario);

                cmdTransferencia.ExecuteNonQuery();

                transaccion.Commit();

                cn.CerrarConexion();
            }
            catch
            {
                transaccion.Rollback();

                cn.CerrarConexion();

                throw;
            }
        }
    }
}