// IMPORTACION DE LIBRERIAS NECESARIAS
using Sistema_Inventario.Datos;
using Sistema_Inventario.Logica;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Sistema_Inventario.Presentacion
{
    // MODAL PARA CREAR O EDITAR UN USUARIO
    public partial class FrmUsuarioModal : Form
    {
        // CONEXION Y SERVICIO PROPIOS DEL MODAL
        private Conexion        cn              = new Conexion();
        private PasswordService passwordService = new PasswordService();

        // ID DEL USUARIO (0 = nuevo)
        private int _idUsuario = 0;

        // ─────────────────────────────────────────
        // CONSTRUCTOR — NUEVO USUARIO
        // ─────────────────────────────────────────

        public FrmUsuarioModal()
        {
            InitializeComponent();
            AplicarEstilos();
            _idUsuario = 0;
            CargarRoles();
        }

        // ─────────────────────────────────────────
        // CONSTRUCTOR — EDITAR USUARIO
        // ─────────────────────────────────────────

        public FrmUsuarioModal(int idUsuario, string usuario, string rol, bool estado)
        {
            InitializeComponent();
            AplicarEstilos();
            _idUsuario = idUsuario;
            CargarRoles();

            txtUsuario.Text   = usuario;
            cboRoles.Text     = rol;
            chkEstado.Checked = estado;

            lblTitulo.Text = "Editar Usuario";
            this.Text      = "Editar Usuario";
        }

        // ─────────────────────────────────────────
        // ESTILOS
        // ─────────────────────────────────────────

        private void AplicarEstilos()
        {
            ConfigurarBoton(btnGuardar,  Color.FromArgb(46,  204, 113));
            ConfigurarBoton(btnCancelar, Color.FromArgb(149, 165, 166));
        }

        private void ConfigurarBoton(IconButton btn, Color color)
        {
            btn.BackColor                 = color;
            btn.ForeColor                 = Color.White;
            btn.FlatStyle                 = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font                      = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.IconColor                 = Color.White;
            btn.IconSize                  = 22;
            btn.TextImageRelation         = TextImageRelation.ImageBeforeText;
            btn.Cursor                    = Cursors.Hand;

            btn.MouseEnter += (s, e) => { btn.BackColor = ControlPaint.Dark(color); };
            btn.MouseLeave += (s, e) => { btn.BackColor = color; };
        }

        // ─────────────────────────────────────────
        // CARGAR ROLES
        // ─────────────────────────────────────────

        private void CargarRoles()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT IdRol, Nombre FROM Roles WHERE Estado = 1",
                    cn.AbrirConexion());

                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.CerrarConexion();

                cboRoles.DataSource    = dt;
                cboRoles.DisplayMember = "Nombre";
                cboRoles.ValueMember   = "IdRol";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // BOTON GUARDAR
        // ─────────────────────────────────────────

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // VALIDACIONES
                if (txtUsuario.Text.Trim() == "")
                {
                    MessageBox.Show(
                        "Ingrese el usuario.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtUsuario.Focus();
                    return;
                }

                if (txtClave.Text.Trim() == "")
                {
                    MessageBox.Show(
                        "Ingrese la contraseña.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtClave.Focus();
                    return;
                }

                if (txtClave.Text != txtConfirmar.Text)
                {
                    MessageBox.Show(
                        "Las contraseñas no coinciden.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtConfirmar.Focus();
                    return;
                }

                SqlConnection conexion = cn.AbrirConexion();
                SqlCommand    cmd;

                if (_idUsuario == 0)
                {
                    // INSERT
                    cmd = new SqlCommand(
                        @"INSERT INTO Usuarios (Usuario, Clave, Rol, IdRol, Estado)
                          VALUES (@Usuario, @Clave, @Rol, @IdRol, @Estado)",
                        conexion);
                }
                else
                {
                    // UPDATE
                    cmd = new SqlCommand(
                        @"UPDATE Usuarios
                          SET Usuario = @Usuario,
                              Clave   = @Clave,
                              Rol     = @Rol,
                              IdRol   = @IdRol,
                              Estado  = @Estado
                          WHERE IdUsuario = @IdUsuario",
                        conexion);
                    cmd.Parameters.AddWithValue("@IdUsuario", _idUsuario);
                }

                cmd.Parameters.AddWithValue("@Usuario", txtUsuario.Text.Trim());
                cmd.Parameters.AddWithValue("@Clave",   passwordService.GenerarHash(txtClave.Text));
                cmd.Parameters.AddWithValue("@Rol",     cboRoles.Text);
                cmd.Parameters.AddWithValue("@IdRol",   cboRoles.SelectedValue);
                cmd.Parameters.AddWithValue("@Estado",  chkEstado.Checked);

                cmd.ExecuteNonQuery();
                cn.CerrarConexion();

                MessageBox.Show(
                    _idUsuario == 0
                        ? "Usuario guardado correctamente."
                        : "Usuario actualizado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // BOTON CANCELAR
        // ─────────────────────────────────────────

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
