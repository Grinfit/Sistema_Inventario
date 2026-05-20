using System;
using System.Data;
using System.Data.SqlClient;

using Sistema_Inventario.Datos;
using System.Windows.Forms;
namespace Sistema_Inventario.Utilidades
{
    internal class Logger
    {
        Conexion cn = new Conexion();

        public void RegistrarLog(
            string evento,
            string usuario,
            string descripcion)
        {
            try
            {
                using (SqlCommand cmd =
                    new SqlCommand(
                        "sp_InsertarLog",
                        cn.AbrirConexion()))
                {
                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "@Evento",
                        evento);

                    cmd.Parameters.AddWithValue(
                        "@Usuario",
                        usuario);

                    cmd.Parameters.AddWithValue(
                        "@Descripcion",
                        descripcion);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al registrar log: " + ex.Message,
                    "Logger",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            finally
            {
                cn.CerrarConexion();
            }
        }
    }
}