using Sistema_Inventario.Datos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Sistema_Inventario.Logica;

namespace Sistema_Inventario.Presentacion
{
    public partial class FrmUsuarios : Form
    {
        Conexion cn = new Conexion();
        PasswordService passwordService =
    new PasswordService();

        int idUsuario = 0;

        public FrmUsuarios()
        {
            InitializeComponent();

            ConfigurarGrid();

            CargarUsuarios();

            CargarRoles();

            Eventos();
        }

        // =========================================
        // EVENTOS
        // =========================================

        private void Eventos()
        {
            btnNuevo.Click += BtnNuevo_Click;

            btnGuardar.Click += BtnGuardar_Click;

            btnEditar.Click += BtnEditar_Click;

            btnEliminar.Click += BtnEliminar_Click;

            dgvUsuarios.CellDoubleClick +=
                DgvUsuarios_CellDoubleClick;

            txtBuscar.TextChanged +=
                TxtBuscar_TextChanged;
        }

        // =========================================
        // CONFIG GRID
        // =========================================

        private void ConfigurarGrid()
        {
            dgvUsuarios.EnableHeadersVisualStyles =
                false;

            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(11, 31, 58);

            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold);

            dgvUsuarios.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10);

            dgvUsuarios.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(59, 130, 246);

            dgvUsuarios.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvUsuarios.RowTemplate.Height = 35;
        }

        // =========================================
        // CARGAR USUARIOS
        // =========================================

        private void CargarUsuarios()
        {
            try
            {
                SqlConnection conexion =
                    cn.AbrirConexion();

                SqlDataAdapter da =
                    new SqlDataAdapter(
                        @"SELECT
                            U.IdUsuario,
                            U.Usuario,
                            R.Nombre AS Rol,
                            U.Estado,
                            U.FechaRegistro
                        FROM Usuarios U
                        INNER JOIN Roles R
                            ON U.IdRol = R.IdRol
                        ORDER BY U.IdUsuario DESC",
                        conexion);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                dgvUsuarios.DataSource = dt;

                cn.CerrarConexion();

                dgvUsuarios.Columns["IdUsuario"].Width = 80;

                dgvUsuarios.Columns["Usuario"].Width = 180;

                dgvUsuarios.Columns["Rol"].Width = 180;

                dgvUsuarios.Columns["Estado"].Width = 80;

                dgvUsuarios.Columns["FechaRegistro"].Width = 180;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }

        // =========================================
        // CARGAR ROLES
        // =========================================

        private void CargarRoles()
        {
            try
            {
                SqlConnection conexion =
                    cn.AbrirConexion();

                SqlDataAdapter da =
                    new SqlDataAdapter(
                        @"SELECT
                            IdRol,
                            Nombre
                        FROM Roles
                        WHERE Estado = 1",
                        conexion);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                cboRoles.DataSource = dt;

                cboRoles.DisplayMember =
                    "Nombre";

                cboRoles.ValueMember =
                    "IdRol";

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }

        // =========================================
        // NUEVO
        // =========================================

        private void BtnNuevo_Click(
            object sender,
            EventArgs e)
        {
            Limpiar();
        }

        // =========================================
        // GUARDAR
        // =========================================

        private void BtnGuardar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (txtUsuario.Text.Trim() == "")
                {
                    MessageBox.Show(
                        "Ingrese usuario");

                    return;
                }

                if (txtClave.Text.Trim() == "")
                {
                    MessageBox.Show(
                        "Ingrese contraseña");

                    return;
                }

                if (txtClave.Text !=
                    txtConfirmar.Text)
                {
                    MessageBox.Show(
                        "Las contraseñas no coinciden");

                    return;
                }

                SqlConnection conexion =
                    cn.AbrirConexion();

                SqlCommand cmd =
                    new SqlCommand(
                        @"INSERT INTO Usuarios
                        (
                            Usuario,
                            Clave,
                            Rol,
                            IdRol,
                            Estado
                        )
                        VALUES
                        (
                            @Usuario,
                            @Clave,
                            @Rol,
                            @IdRol,
                            @Estado
                        )",
                        conexion);

                cmd.Parameters.AddWithValue(
                    "@Usuario",
                    txtUsuario.Text);

                cmd.Parameters.AddWithValue(
    "@Clave",
    passwordService.GenerarHash(
        txtClave.Text));

                cmd.Parameters.AddWithValue(
                    "@Rol",
                    cboRoles.Text);

                cmd.Parameters.AddWithValue(
                    "@IdRol",
                    cboRoles.SelectedValue);

                cmd.Parameters.AddWithValue(
                    "@Estado",
                    chkEstado.Checked);

                cmd.ExecuteNonQuery();

                cn.CerrarConexion();

                MessageBox.Show(
                    "Usuario guardado correctamente");

                CargarUsuarios();

                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }

        // =========================================
        // EDITAR
        // =========================================

        private void BtnEditar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (idUsuario == 0)
                {
                    MessageBox.Show(
                        "Seleccione un usuario");

                    return;
                }

                SqlConnection conexion =
                    cn.AbrirConexion();

                SqlCommand cmd =
                    new SqlCommand(
                        @"UPDATE Usuarios
                        SET
                            Usuario = @Usuario,
                            Clave = @Clave,
                            Rol = @Rol,
                            IdRol = @IdRol,
                            Estado = @Estado
                        WHERE IdUsuario = @IdUsuario",
                        conexion);

                cmd.Parameters.AddWithValue(
                     "@Usuario",
                     txtUsuario.Text);

                cmd.Parameters.AddWithValue(
                    "@Clave",
                    passwordService.GenerarHash(
                        txtClave.Text));

                cmd.Parameters.AddWithValue(
                    "@Rol",
                    cboRoles.Text);

                cmd.Parameters.AddWithValue(
                    "@IdRol",
                    cboRoles.SelectedValue);

                cmd.Parameters.AddWithValue(
                    "@Estado",
                    chkEstado.Checked);

                cmd.Parameters.AddWithValue(
                    "@IdUsuario",
                    idUsuario);

                cmd.ExecuteNonQuery();

                cn.CerrarConexion();

                MessageBox.Show(
                    "Usuario actualizado");

                CargarUsuarios();

                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }

        // =========================================
        // ELIMINAR
        // =========================================

        private void BtnEliminar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (idUsuario == 0)
                {
                    MessageBox.Show(
                        "Seleccione un usuario");

                    return;
                }

                DialogResult resultado =
                    MessageBox.Show(
                        "¿Desea eliminar el usuario?",
                        "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (resultado ==
                    DialogResult.Yes)
                {
                    SqlConnection conexion =
                        cn.AbrirConexion();

                    SqlCommand cmd =
                        new SqlCommand(
                            @"DELETE FROM Usuarios
                            WHERE IdUsuario = @IdUsuario",
                            conexion);

                    cmd.Parameters.AddWithValue(
                        "@IdUsuario",
                        idUsuario);

                    cmd.ExecuteNonQuery();

                    cn.CerrarConexion();

                    MessageBox.Show(
                        "Usuario eliminado");

                    CargarUsuarios();

                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }

        // =========================================
        // DOBLE CLICK GRID
        // =========================================

        private void DgvUsuarios_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow fila =
                        dgvUsuarios.Rows[e.RowIndex];

                    idUsuario =
                        Convert.ToInt32(
                            fila.Cells["IdUsuario"].Value);

                    txtUsuario.Text =
                        fila.Cells["Usuario"].Value.ToString();

                    cboRoles.Text =
                        fila.Cells["Rol"].Value.ToString();

                    chkEstado.Checked =
                        Convert.ToBoolean(
                            fila.Cells["Estado"].Value);

                    txtClave.Text = "";

                    txtConfirmar.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }

        // =========================================
        // BUSCAR
        // =========================================

        private void TxtBuscar_TextChanged(
            object sender,
            EventArgs e)
        {
            try
            {
                SqlConnection conexion =
                    cn.AbrirConexion();

                SqlDataAdapter da =
                    new SqlDataAdapter(
                        @"SELECT
                            U.IdUsuario,
                            U.Usuario,
                            R.Nombre AS Rol,
                            U.Estado,
                            U.FechaRegistro
                        FROM Usuarios U
                        INNER JOIN Roles R
                            ON U.IdRol = R.IdRol
                        WHERE U.Usuario LIKE @Buscar",
                        conexion);

                da.SelectCommand.Parameters.AddWithValue(
                    "@Buscar",
                    "%" + txtBuscar.Text + "%");

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                dgvUsuarios.DataSource = dt;

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }

        // =========================================
        // LIMPIAR
        // =========================================

        private void Limpiar()
        {
            idUsuario = 0;

            txtUsuario.Clear();

            txtClave.Clear();

            txtConfirmar.Clear();

            txtBuscar.Clear();

            chkEstado.Checked = true;

            if (cboRoles.Items.Count > 0)
            {
                cboRoles.SelectedIndex = 0;
            }

            txtUsuario.Focus();
        }
    }
}