using System;
using System.Data.SqlClient;
using System.Windows.Forms;

using Sistema_Inventario.Datos;
using Sistema_Inventario.Logica;
using Sistema_Inventario.Presentacion;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario
{
    public partial class FrmLogin : Form
    {
        Conexion cn =
            new Conexion();

        Logger log =
            new Logger();

        PasswordService passwordService =
            new PasswordService();

        public FrmLogin()
        {
            InitializeComponent();
        }

        // =========================================
        // LOGIN
        // =========================================

        private void btnIngresar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (txtUsuario.Text.Trim() == "")
                {
                    MessageBox.Show(
                        "Ingrese el usuario",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtUsuario.Focus();

                    return;
                }

                if (txtClave.Text.Trim() == "")
                {
                    MessageBox.Show(
                        "Ingrese la contraseña",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtClave.Focus();

                    return;
                }

                SqlConnection conexion =
                    cn.AbrirConexion();

                SqlCommand cmd =
                    new SqlCommand(
                        @"SELECT
                            U.IdUsuario,
                            U.Usuario,
                            U.Clave,
                            U.IdRol,
                            R.Nombre AS Rol
                        FROM Usuarios U
                        INNER JOIN Roles R
                            ON U.IdRol = R.IdRol
                        WHERE
                            U.Usuario = @Usuario
                            AND U.Estado = 1",
                        conexion);

                cmd.Parameters.AddWithValue(
                    "@Usuario",
                    txtUsuario.Text.Trim());

                SqlDataReader dr =
                    cmd.ExecuteReader();

                if (dr.Read())
                {
                    string hashGuardado =
                        dr["Clave"].ToString();

                    bool passwordCorrecto =
                        passwordService.VerificarHash(
                            txtClave.Text.Trim(),
                            hashGuardado);

                    if (passwordCorrecto)
                    {
                        // =====================================
                        // SESIÓN
                        // =====================================

                        SesionUsuario.IdUsuario =
                            Convert.ToInt32(
                                dr["IdUsuario"]);

                        SesionUsuario.Usuario =
                            dr["Usuario"].ToString();

                        SesionUsuario.IdRol =
                            Convert.ToInt32(
                                dr["IdRol"]);

                        SesionUsuario.Rol =
                            dr["Rol"].ToString();

                        dr.Close();

                        // =====================================
                        // PERMISOS
                        // =====================================

                        CargarPermisos();

                        // =====================================
                        // LOG
                        // =====================================

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

                        log.RegistrarLog(
                            "ERROR_LOGIN",
                            txtUsuario.Text,
                            "Contraseña incorrecta");
                    }
                }
                else
                {
                    dr.Close();

                    MessageBox.Show(
                        "Usuario o contraseña incorrectos",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    log.RegistrarLog(
                        "ERROR_LOGIN",
                        txtUsuario.Text,
                        "Usuario no encontrado");
                }

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);

                log.RegistrarLog(
                    "ERROR_LOGIN",
                    txtUsuario.Text,
                    ex.Message);
            }
        }

        // =========================================
        // CARGAR PERMISOS
        // =========================================

        private void CargarPermisos()
        {
            try
            {
                SesionUsuario.Permisos.Clear();

                SqlCommand cmd =
                    new SqlCommand(
                        @"SELECT P.Nombre
                        FROM RolesPermisos RP
                        INNER JOIN Permisos P
                            ON RP.IdPermiso = P.IdPermiso
                        WHERE RP.IdRol = @IdRol",
                        cn.AbrirConexion());

                cmd.Parameters.AddWithValue(
                    "@IdRol",
                    SesionUsuario.IdRol);

                SqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    SesionUsuario.Permisos.Add(
                        dr["Nombre"].ToString());
                }

                dr.Close();

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }

        // =========================================
        // MOSTRAR CONTRASEÑA
        // =========================================

        private void chkMostrarClave_CheckedChanged(
            object sender,
            EventArgs e)
        {
            txtClave.UseSystemPasswordChar =
                !chkMostrarClave.Checked;
        }

        // =========================================
        // LOAD
        // =========================================

        private void FrmLogin_Load(
            object sender,
            EventArgs e)
        {
            txtClave.UseSystemPasswordChar = true;
        }
    }
}