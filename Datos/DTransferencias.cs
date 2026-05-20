// IMPORTACION DE LIBRERIAS NECESARIAS PARA EL MANEJO DE DATOS Y SQL SERVER
using System;
using System.Data;
using System.Data.SqlClient;

namespace Sistema_Inventario.Datos
{
    // CLASE ENCARGADA DE GESTIONAR LAS TRANSFERENCIAS ENTRE BODEGAS
    public class DTransferencias
    {
        // OBJETO DE CONEXION A LA BASE DE DATOS
        Conexion cn =
            new Conexion();

        // METODO PARA MOSTRAR LOS PRODUCTOS
        public DataTable MostrarProductos()
        {
            // CREACION DE TABLA TEMPORAL
            DataTable tabla =
                new DataTable();

            // CONSULTA SQL PARA OBTENER LOS PRODUCTOS
            SqlDataAdapter da =
                new SqlDataAdapter(
                    "SELECT IdProducto, Nombre FROM Productos",
                    cn.AbrirConexion());

            // LLENA LA TABLA CON LOS DATOS
            da.Fill(tabla);

            // CIERRA LA CONEXION
            cn.CerrarConexion();

            // RETORNA LOS DATOS
            return tabla;
        }

        // METODO PARA MOSTRAR LAS BODEGAS
        public DataTable MostrarBodegas()
        {
            // CREACION DE TABLA TEMPORAL
            DataTable tabla =
                new DataTable();

            // CONSULTA SQL PARA OBTENER LAS BODEGAS
            SqlDataAdapter da =
                new SqlDataAdapter(
                    "SELECT IdBodega, Nombre FROM Bodegas",
                    cn.AbrirConexion());

            // LLENA LA TABLA CON LOS DATOS
            da.Fill(tabla);

            // CIERRA LA CONEXION
            cn.CerrarConexion();

            // RETORNA LOS DATOS
            return tabla;
        }

        // METODO PARA MOSTRAR EL HISTORIAL DE TRANSFERENCIAS
        public DataTable MostrarTransferencias()
        {
            // CREACION DE TABLA TEMPORAL
            DataTable tabla =
                new DataTable();

            // CONSULTA SQL PARA MOSTRAR LAS TRANSFERENCIAS
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

            // LLENA LA TABLA CON LOS DATOS
            da.Fill(tabla);

            // CIERRA LA CONEXION
            cn.CerrarConexion();

            // RETORNA LOS DATOS
            return tabla;
        }

        // METODO PARA TRANSFERIR PRODUCTOS ENTRE BODEGAS
        public void TransferirProducto(
            int idProducto,
            int idBodegaOrigen,
            int idBodegaDestino,
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
                // VALIDA QUE LAS BODEGAS NO SEAN IGUALES
                if (idBodegaOrigen ==
                    idBodegaDestino)
                {
                    throw new Exception(
                        "La bodega origen y destino no pueden ser iguales.");
                }

                // CONSULTA SQL PARA OBTENER EL STOCK ACTUAL
                SqlCommand cmdStock =
                    new SqlCommand(
                        @"SELECT ISNULL(StockActual,0)
                        FROM StockBodega
                        WHERE IdProducto=@IdProducto
                        AND IdBodega=@IdBodega",
                        conexion,
                        transaccion);

                // PARAMETRO DEL PRODUCTO
                cmdStock.Parameters.AddWithValue(
                    "@IdProducto",
                    idProducto);

                // PARAMETRO DE LA BODEGA ORIGEN
                cmdStock.Parameters.AddWithValue(
                    "@IdBodega",
                    idBodegaOrigen);

                // OBTIENE EL STOCK ACTUAL
                decimal stockActual =
                    Convert.ToDecimal(
                        cmdStock.ExecuteScalar());

                // VALIDA SI EXISTE STOCK SUFICIENTE
                if (stockActual < cantidad)
                {
                    throw new Exception(
                        "No hay stock suficiente en la bodega origen.");
                }

                // CONSULTA SQL PARA DESCONTAR STOCK DE LA BODEGA ORIGEN
                SqlCommand cmdDescontar =
                    new SqlCommand(
                        @"UPDATE StockBodega
                        SET StockActual =
                        StockActual - @Cantidad
                        WHERE IdProducto=@IdProducto
                        AND IdBodega=@IdBodega",
                        conexion,
                        transaccion);

                // PARAMETRO DE LA CANTIDAD
                cmdDescontar.Parameters.AddWithValue(
                    "@Cantidad",
                    cantidad);

                // PARAMETRO DEL PRODUCTO
                cmdDescontar.Parameters.AddWithValue(
                    "@IdProducto",
                    idProducto);

                // PARAMETRO DE LA BODEGA ORIGEN
                cmdDescontar.Parameters.AddWithValue(
                    "@IdBodega",
                    idBodegaOrigen);

                // EJECUTA LA CONSULTA
                cmdDescontar.ExecuteNonQuery();

                // CONSULTA SQL PARA VALIDAR SI EXISTE EL PRODUCTO EN LA BODEGA DESTINO
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

                // PARAMETRO DE LA BODEGA DESTINO
                cmdExiste.Parameters.AddWithValue(
                    "@IdBodega",
                    idBodegaDestino);

                // OBTIENE LA CANTIDAD DE REGISTROS
                int existe =
                    Convert.ToInt32(
                        cmdExiste.ExecuteScalar());

                // VALIDA SI EL PRODUCTO NO EXISTE EN LA BODEGA DESTINO
                if (existe == 0)
                {
                    // CONSULTA SQL PARA INSERTAR EL STOCK EN LA BODEGA DESTINO
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

                    // PARAMETRO DEL PRODUCTO
                    cmdInsert.Parameters.AddWithValue(
                        "@IdProducto",
                        idProducto);

                    // PARAMETRO DE LA BODEGA DESTINO
                    cmdInsert.Parameters.AddWithValue(
                        "@IdBodega",
                        idBodegaDestino);

                    // PARAMETRO DE LA CANTIDAD
                    cmdInsert.Parameters.AddWithValue(
                        "@Cantidad",
                        cantidad);

                    // EJECUTA LA CONSULTA
                    cmdInsert.ExecuteNonQuery();
                }
                else
                {
                    // CONSULTA SQL PARA SUMAR EL STOCK EN LA BODEGA DESTINO
                    SqlCommand cmdSumar =
                        new SqlCommand(
                            @"UPDATE StockBodega
                            SET StockActual =
                            StockActual + @Cantidad
                            WHERE IdProducto=@IdProducto
                            AND IdBodega=@IdBodega",
                            conexion,
                            transaccion);

                    // PARAMETRO DE LA CANTIDAD
                    cmdSumar.Parameters.AddWithValue(
                        "@Cantidad",
                        cantidad);

                    // PARAMETRO DEL PRODUCTO
                    cmdSumar.Parameters.AddWithValue(
                        "@IdProducto",
                        idProducto);

                    // PARAMETRO DE LA BODEGA DESTINO
                    cmdSumar.Parameters.AddWithValue(
                        "@IdBodega",
                        idBodegaDestino);

                    // EJECUTA LA CONSULTA
                    cmdSumar.ExecuteNonQuery();
                }

                // CONSULTA SQL PARA REGISTRAR LA TRANSFERENCIA
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

                // PARAMETRO DEL PRODUCTO
                cmdTransferencia.Parameters.AddWithValue(
                    "@IdProducto",
                    idProducto);

                // PARAMETRO DE LA BODEGA ORIGEN
                cmdTransferencia.Parameters.AddWithValue(
                    "@IdBodegaOrigen",
                    idBodegaOrigen);

                // PARAMETRO DE LA BODEGA DESTINO
                cmdTransferencia.Parameters.AddWithValue(
                    "@IdBodegaDestino",
                    idBodegaDestino);

                // PARAMETRO DE LA CANTIDAD
                cmdTransferencia.Parameters.AddWithValue(
                    "@Cantidad",
                    cantidad);

                // PARAMETRO DE LA OBSERVACION
                cmdTransferencia.Parameters.AddWithValue(
                    "@Observacion",
                    observacion);

                // PARAMETRO DEL USUARIO
                cmdTransferencia.Parameters.AddWithValue(
                    "@UsuarioRegistro",
                    usuario);

                // EJECUTA LA CONSULTA
                cmdTransferencia.ExecuteNonQuery();

                // CONFIRMA LA TRANSACCION
                transaccion.Commit();

                // CIERRA LA CONEXION
                cn.CerrarConexion();
            }
            catch
            {
                // REVIERTE LA TRANSACCION EN CASO DE ERROR
                transaccion.Rollback();

                // CIERRA LA CONEXION
                cn.CerrarConexion();

                // LANZA NUEVAMENTE EL ERROR
                throw;
            }
        }
    }
}