using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_Inventario.Datos;
using Sistema_Inventario.Presentacion;
using Sistema_Inventario.Utilidades;
using FontAwesome.Sharp;

namespace Sistema_Inventario
{
    public partial class FrmLogin : Form
    {
        Conexion cn = new Conexion();

        Logger log = new Logger();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "sp_Login",
                    cn.AbrirConexion());

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@Usuario",
                    txtUsuario.Text);

                cmd.Parameters.AddWithValue(
                    "@Clave",
                    txtClave.Text);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    dr.Close();

                    log.RegistrarLog(
                        "LOGIN",
                        txtUsuario.Text,
                        "Inicio de sesión correcto");

                    MessageBox.Show(
                        "Bienvenido al sistema",
                        "Login Correcto",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    FrmDashboard frm =
                        new FrmDashboard();

                    frm.Show();

                    this.Hide();
                }
                else
                {
                    dr.Close();

                    MessageBox.Show(
                        "Usuario o contraseña incorrectos",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                log.RegistrarLog(
                    "ERROR LOGIN",
                    txtUsuario.Text,
                    ex.Message);
            }
        }

        private void FrmLogin_Load(
            object sender,
            EventArgs e)
        {

        }
    }
}