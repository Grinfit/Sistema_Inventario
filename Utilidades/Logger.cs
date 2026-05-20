// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Data;
using System.Data.SqlClient;

// IMPORTACION DE LA CAPA DE DATOS
using Sistema_Inventario.Datos;

// IMPORTACION DE LIBRERIA PARA MENSAJES
using System.Windows.Forms;

namespace Sistema_Inventario.Utilidades
{
    // CLASE ENCARGADA DE REGISTRAR LOS LOGS DEL SISTEMA
    internal class Logger
    {
        // OBJETO DE CONEXION A LA BASE DE DATOS
        Conexion cn = new Conexion();

        // METODO PARA REGISTRAR LOGS
        public void RegistrarLog(
            string evento,
            string usuario,
            string descripcion)
        {
            try
            {
                // CREACION DEL COMANDO SQL UTILIZANDO EL PROCEDIMIENTO ALMACENADO
                using (SqlCommand cmd =
                    new SqlCommand(
                        "sp_InsertarLog",
                        cn.AbrirConexion()))
                {
                    // INDICA QUE ES UN STORED PROCEDURE
                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    // PARAMETRO DEL EVENTO
                    cmd.Parameters.AddWithValue(
                        "@Evento",
                        evento);

                    // PARAMETRO DEL USUARIO
                    cmd.Parameters.AddWithValue(
                        "@Usuario",
                        usuario);

                    // PARAMETRO DE LA DESCRIPCION
                    cmd.Parameters.AddWithValue(
                        "@Descripcion",
                        descripcion);

                    // EJECUTA EL PROCEDIMIENTO
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // MUESTRA EL ERROR EN CASO DE FALLA
                MessageBox.Show(
                    "Error al registrar log: " + ex.Message,
                    "Logger",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            finally
            {
                // CIERRA LA CONEXION A LA BASE DE DATOS
                cn.CerrarConexion();
            }
        }
    }
}