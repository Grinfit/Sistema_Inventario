// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

// IMPORTACION DE CAPAS DEL SISTEMA
using Sistema_Inventario.Datos;
using Sistema_Inventario.Logica;
using Sistema_Inventario.Presentacion;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario
{
    // FORMULARIO PRINCIPAL DE LOGIN
    public partial class FrmLogin : Form
    {
        // OBJETO DE CONEXION A LA BASE DE DATOS
        Conexion cn =
            new Conexion();

        // OBJETO PARA REGISTRO DE LOGS
        Logger log =
            new Logger();

        // OBJETO PARA MANEJO DE HASH DE CONTRASEÑAS
        PasswordService passwordService =
            new PasswordService();

        // CONSTRUCTOR DEL FORMULARIO
        public FrmLogin()
        {
            // INICIALIZA LOS COMPONENTES
            InitializeComponent();
        }

        // EVENTO DEL BOTON INGRESAR
        private void btnIngresar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                // VALIDA SI EL USUARIO ESTA VACIO
                if (txtUsuario.Text.Trim() == "")
                {
                    MessageBox.Show(
                        "Ingrese el usuario",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    // ENVIA EL FOCO AL TEXTBOX
                    txtUsuario.Focus();

                    return;
                }

                // VALIDA SI LA CONTRASEÑA ESTA VACIA
                if (txtClave.Text.Trim() == "")
                {
                    MessageBox.Show(
                        "Ingrese la contraseña",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    // ENVIA EL FOCO AL TEXTBOX
                    txtClave.Focus();

                    return;
                }

                // ABRE LA CONEXION
                SqlConnection conexion =
                    cn.AbrirConexion();

                // CONSULTA SQL PARA VALIDAR EL LOGIN
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

                // PARAMETRO DEL USUARIO
                cmd.Parameters.AddWithValue(
                    "@Usuario",
                    txtUsuario.Text.Trim());

                // EJECUTA EL READER
                SqlDataReader dr =
                    cmd.ExecuteReader();

                // VERIFICA SI EXISTE EL USUARIO
                if (dr.Read())
                {
                    // OBTIENE EL HASH GUARDADO
                    string hashGuardado =
                        dr["Clave"].ToString();

                    // VERIFICA SI LA CONTRASEÑA ES CORRECTA
                    bool passwordCorrecto =
                        passwordService.VerificarHash(
                            txtClave.Text.Trim(),
                            hashGuardado);

                    // VALIDA SI LA CONTRASEÑA ES VALIDA
                    if (passwordCorrecto)
                    {

                        // GUARDA EL ID DEL USUARIO
                        SesionUsuario.IdUsuario =
                            Convert.ToInt32(
                                dr["IdUsuario"]);

                        // GUARDA EL NOMBRE DEL USUARIO
                        SesionUsuario.Usuario =
                            dr["Usuario"].ToString();

                        // GUARDA EL ID DEL ROL
                        SesionUsuario.IdRol =
                            Convert.ToInt32(
                                dr["IdRol"]);

                        // GUARDA EL NOMBRE DEL ROL
                        SesionUsuario.Rol =
                            dr["Rol"].ToString();

                        // CIERRA EL READER
                        dr.Close();

                        // CARGA LOS PERMISOS DEL USUARIO
                        CargarPermisos();

                        // REGISTRA EL LOGIN EXITOSO
                        log.RegistrarLog(
                            "LOGIN",
                            txtUsuario.Text,
                            "Inicio de sesión correcto");

                        // MENSAJE DE BIENVENIDA
                        MessageBox.Show(
                            "Bienvenido al sistema",
                            "Login Correcto",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        // CREA EL DASHBOARD
                        FrmDashboard frm =
                            new FrmDashboard();

                        // MUESTRA EL DASHBOARD
                        frm.Show();

                        // OCULTA EL LOGIN
                        this.Hide();
                    }
                    else
                    {
                        // CIERRA EL READER
                        dr.Close();

                        // MENSAJE DE ERROR
                        MessageBox.Show(
                            "Usuario o contraseña incorrectos",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        // REGISTRA EL ERROR EN LOGS
                        log.RegistrarLog(
                            "ERROR_LOGIN",
                            txtUsuario.Text,
                            "Contraseña incorrecta");
                    }
                }
                else
                {
                    // CIERRA EL READER
                    dr.Close();

                    // MENSAJE DE ERROR
                    MessageBox.Show(
                        "Usuario o contraseña incorrectos",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    // REGISTRA EL ERROR EN LOGS
                    log.RegistrarLog(
                        "ERROR_LOGIN",
                        txtUsuario.Text,
                        "Usuario no encontrado");
                }

                // CIERRA LA CONEXION
                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                // MUESTRA EL ERROR
                MessageBox.Show(
                    ex.Message);

                // REGISTRA EL ERROR EN LOGS
                log.RegistrarLog(
                    "ERROR_LOGIN",
                    txtUsuario.Text,
                    ex.Message);
            }
        }

        // METODO PARA CARGAR LOS PERMISOS DEL USUARIO
        private void CargarPermisos()
        {
            try
            {
                // LIMPIA LA LISTA DE PERMISOS
                SesionUsuario.Permisos.Clear();

                // CONSULTA SQL PARA OBTENER LOS PERMISOS
                SqlCommand cmd =
                    new SqlCommand(
                        @"SELECT P.Nombre
                        FROM RolesPermisos RP
                        INNER JOIN Permisos P
                            ON RP.IdPermiso = P.IdPermiso
                        WHERE RP.IdRol = @IdRol",
                        cn.AbrirConexion());

                // PARAMETRO DEL ID DEL ROL
                cmd.Parameters.AddWithValue(
                    "@IdRol",
                    SesionUsuario.IdRol);

                // EJECUTA EL READER
                SqlDataReader dr =
                    cmd.ExecuteReader();

                // RECORRE LOS PERMISOS
                while (dr.Read())
                {
                    // AGREGA EL PERMISO A LA LISTA
                    SesionUsuario.Permisos.Add(
                        dr["Nombre"].ToString());
                }

                // CIERRA EL READER
                dr.Close();

                // CIERRA LA CONEXION
                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                // MUESTRA EL ERROR
                MessageBox.Show(
                    ex.Message);
            }
        }
        
        // MOSTRAR CONTRASEÑA
      
        // EVENTO DEL CHECKBOX MOSTRAR CONTRASEÑA
        private void chkMostrarClave_CheckedChanged(
            object sender,
            EventArgs e)
        {
            // MUESTRA U OCULTA LA CONTRASEÑA
            txtClave.UseSystemPasswordChar =
                !chkMostrarClave.Checked;
        }

        // EVENTO LOAD DEL FORMULARIO
        private void FrmLogin_Load(
            object sender,
            EventArgs e)
        {
            // OCULTA LA CONTRASEÑA AL INICIAR
            txtClave.UseSystemPasswordChar = true;
        }
    }
}