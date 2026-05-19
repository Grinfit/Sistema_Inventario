using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Sistema_Inventario.Datos;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Presentacion
{
    public partial class FrmAjustes : Form
    {
        Conexion cn = new Conexion();

        public FrmAjustes()
        {
            InitializeComponent();
        }

        private void FrmAjustes_Load(
            object sender,
            EventArgs e)
        {
            CargarInformacion();
            CargarEstadisticas();
        }

        private void CargarInformacion()
        {
            lblUsuario.Text =
                SesionUsuario.Usuario;

            lblRol.Text =
                SesionUsuario.Rol;

            lblFecha.Text =
                DateTime.Now.ToString(
                    "dd/MM/yyyy HH:mm");

            lblServidor.Text =
                Environment.MachineName;

            lblBaseDatos.Text =
                "Inventario";

            lblEstadoConexion.Text =
                "🟢 CONECTADO";
        }

        private void CargarEstadisticas()
        {
            try
            {
                SqlConnection conexion =
                    cn.AbrirConexion();

                SqlCommand cmdUsuarios =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM Usuarios",
                        conexion);

                lblTotalUsuarios.Text =
                    cmdUsuarios.ExecuteScalar().ToString();

                SqlCommand cmdProductos =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM Productos",
                        conexion);

                lblTotalProductos.Text =
                    cmdProductos.ExecuteScalar().ToString();

                SqlCommand cmdRoles =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM Roles",
                        conexion);

                lblTotalRoles.Text =
                    cmdRoles.ExecuteScalar().ToString();

                SqlCommand cmdLogs =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM Logs",
                        conexion);

                lblTotalLogs.Text =
                    cmdLogs.ExecuteScalar().ToString();

                cn.CerrarConexion();
            }
            catch
            {
                lblEstadoConexion.Text =
                    "🔴 ERROR";
            }
        }

        private void btnCambiarClave_Click(
            object sender,
            EventArgs e)
        {
            if (txtNuevaClave.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese nueva contraseña");

                return;
            }

            try
            {
                SqlCommand cmd =
                    new SqlCommand(
                        @"UPDATE Usuarios
                          SET Clave = @Clave
                          WHERE Usuario = @Usuario",
                        cn.AbrirConexion());

                cmd.Parameters.AddWithValue(
                    "@Clave",
                    txtNuevaClave.Text);

                cmd.Parameters.AddWithValue(
                    "@Usuario",
                    SesionUsuario.Usuario);

                cmd.ExecuteNonQuery();

                cn.CerrarConexion();

                MessageBox.Show(
                    "Contraseña actualizada",
                    "Correcto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtNuevaClave.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnProbarConexion_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                SqlConnection conexion =
                    cn.AbrirConexion();

                if (conexion.State ==
                    System.Data.ConnectionState.Open)
                {
                    MessageBox.Show(
                        "Conexión exitosa",
                        "SQL Server",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    cn.CerrarConexion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}