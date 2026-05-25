// IMPORTACION DE LIBRERIAS NECESARIAS
using Sistema_Inventario.Datos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Sistema_Inventario.Logica;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO ENCARGADO DE LA GESTION DE USUARIOS
    public partial class FrmUsuarios : Form
    {
        // OBJETO DE CONEXION A LA BASE DE DATOS
        Conexion cn = new Conexion();

        // OBJETO PARA EL MANEJO DE CONTRASEÑAS
        PasswordService passwordService = new PasswordService();

        // VARIABLE PARA GUARDAR EL ID DEL USUARIO SELECCIONADO
        int idUsuario = 0;

        // CONSTRUCTOR DEL FORMULARIO
        public FrmUsuarios()
        {
            InitializeComponent();
            AplicarEstilos();
            ConfigurarGrid();
            Eventos();
            CargarUsuarios();
            ActualizarCards();
        }

        // ─────────────────────────────────────────
        // ESTILOS
        // ─────────────────────────────────────────

        private void AplicarEstilos()
        {
            ConfigurarBoton(btnNuevo,      Color.FromArgb(59,  130, 246));
            ConfigurarBoton(btnEditar,     Color.FromArgb(234, 179,   8));
            ConfigurarBoton(btnEliminar,   Color.FromArgb(239,  68,  68));
            ConfigurarBoton(btnActualizar, Color.FromArgb(46,  204, 113));
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
        // CONFIGURAR GRID
        // ─────────────────────────────────────────

        private void ConfigurarGrid()
        {
            dgvUsuarios.EnableHeadersVisualStyles = false;
            dgvUsuarios.BorderStyle               = BorderStyle.None;
            dgvUsuarios.CellBorderStyle           = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsuarios.BackgroundColor           = Color.White;
            dgvUsuarios.RowHeadersVisible         = false;
            dgvUsuarios.SelectionMode             = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect               = false;
            dgvUsuarios.AllowUserToAddRows        = false;
            dgvUsuarios.AllowUserToResizeRows     = false;
            dgvUsuarios.AutoSizeColumnsMode       = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.GridColor                 = Color.LightGray;

            dgvUsuarios.ColumnHeadersBorderStyle                = DataGridViewHeaderBorderStyle.None;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(11, 31, 58);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvUsuarios.ColumnHeadersHeight                     = 45;

            dgvUsuarios.DefaultCellStyle.Font               = new Font("Segoe UI", 10);
            dgvUsuarios.DefaultCellStyle.Padding            = new Padding(4);
            dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.FromArgb(59, 130, 246);
            dgvUsuarios.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
            dgvUsuarios.RowTemplate.Height = 38;

            // BADGE DE ESTADO EN CELDA
            dgvUsuarios.CellFormatting += DgvUsuarios_CellFormatting;
        }

        // ─────────────────────────────────────────
        // EVENTOS
        // ─────────────────────────────────────────

        private void Eventos()
        {
            btnNuevo.Click      += BtnNuevo_Click;
            btnEditar.Click     += BtnEditar_Click;
            btnEliminar.Click   += BtnEliminar_Click;
            btnActualizar.Click += BtnActualizar_Click;

            dgvUsuarios.SelectionChanged += DgvUsuarios_SelectionChanged;
            dgvUsuarios.CellDoubleClick  += DgvUsuarios_CellDoubleClick;
            txtBuscar.TextChanged        += TxtBuscar_TextChanged;
        }

        // ─────────────────────────────────────────
        // CARGAR USUARIOS
        // ─────────────────────────────────────────

        private void CargarUsuarios()
        {
            try
            {
                SqlConnection conexion = cn.AbrirConexion();

                SqlDataAdapter da = new SqlDataAdapter(
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

                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.CerrarConexion();
                ConvertirEstado(dt);
                dgvUsuarios.DataSource = dt;

                if (dgvUsuarios.Columns.Contains("IdUsuario"))
                    dgvUsuarios.Columns["IdUsuario"].Width = 80;
                if (dgvUsuarios.Columns.Contains("Usuario"))
                    dgvUsuarios.Columns["Usuario"].Width = 200;
                if (dgvUsuarios.Columns.Contains("Rol"))
                    dgvUsuarios.Columns["Rol"].Width = 200;
                if (dgvUsuarios.Columns.Contains("Estado"))
                    dgvUsuarios.Columns["Estado"].Width = 110;
                if (dgvUsuarios.Columns.Contains("FechaRegistro"))
                    dgvUsuarios.Columns["FechaRegistro"].Width = 180;

                idUsuario = 0;
                lblResumen.Text = $"Mostrando {dgvUsuarios.Rows.Count} registro(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ─────────────────────────────────────────
        // ACTUALIZAR CARDS
        // ─────────────────────────────────────────

        private void ActualizarCards()
        {
            try
            {
                SqlCommand cmd;

                cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Usuarios WHERE Estado = 1",
                    cn.AbrirConexion());
                lblCard1Valor.Text = cmd.ExecuteScalar().ToString();
                cn.CerrarConexion();

                cmd = new SqlCommand(
                    @"SELECT COUNT(*) FROM Usuarios U
                      INNER JOIN Roles R ON U.IdRol = R.IdRol
                      WHERE R.Nombre LIKE '%Admin%'",
                    cn.AbrirConexion());
                lblCard2Valor.Text = cmd.ExecuteScalar().ToString();
                cn.CerrarConexion();

                cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Usuarios WHERE Estado = 0",
                    cn.AbrirConexion());
                lblCard3Valor.Text = cmd.ExecuteScalar().ToString();
                cn.CerrarConexion();
            }
            catch { }
        }

        // ─────────────────────────────────────────
        // CONVERTIR COLUMNA ESTADO: bool → string
        // Evita que el grid cree DataGridViewCheckBoxColumn
        // ─────────────────────────────────────────

        private void ConvertirEstado(DataTable dt)
        {
            if (!dt.Columns.Contains("Estado")) return;

            dt.Columns.Add("_EstadoTexto", typeof(string));
            foreach (DataRow row in dt.Rows)
                row["_EstadoTexto"] = Convert.ToBoolean(row["Estado"]) ? "Activo" : "Inactivo";

            dt.Columns.Remove("Estado");
            dt.Columns["_EstadoTexto"].ColumnName = "Estado";
        }

        // ─────────────────────────────────────────
        // BADGE DE ESTADO (CellFormatting)
        // ─────────────────────────────────────────

        private void DgvUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.Value == null) return;
            if (dgvUsuarios.Columns[e.ColumnIndex].Name != "Estado") return;

            // El valor ya es string ("Activo"/"Inactivo") — solo aplicar color
            e.CellStyle.ForeColor = e.Value.ToString() == "Activo"
                ? Color.FromArgb(22, 163, 74)
                : Color.FromArgb(220, 38, 38);
            e.CellStyle.Font    = new Font("Segoe UI", 9, FontStyle.Bold);
            e.FormattingApplied = true;
        }

        // ─────────────────────────────────────────
        // SELECCION DEL GRID
        // ─────────────────────────────────────────

        private void DgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                var cel = dgvUsuarios.SelectedRows[0].Cells["IdUsuario"].Value;
                if (cel != null)
                    idUsuario = Convert.ToInt32(cel);
            }
        }

        // ─────────────────────────────────────────
        // DOBLE CLICK GRID → ABRE EDICION
        // ─────────────────────────────────────────

        private void DgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var cel = dgvUsuarios.Rows[e.RowIndex].Cells["IdUsuario"].Value;
            if (cel == null) return;

            idUsuario = Convert.ToInt32(cel);
            AbrirModalEdicion();
        }

        // ─────────────────────────────────────────
        // BOTON NUEVO
        // ─────────────────────────────────────────

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            using (var modal = new FrmUsuarioModal())
            {
                if (modal.ShowDialog(this) == DialogResult.OK)
                {
                    CargarUsuarios();
                    ActualizarCards();
                }
            }
        }

        // ─────────────────────────────────────────
        // BOTON EDITAR
        // ─────────────────────────────────────────

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (idUsuario == 0)
            {
                MessageBox.Show(
                    "Seleccione un usuario",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            AbrirModalEdicion();
        }

        // ABRE EL MODAL EN MODO EDICION CON DATOS DE LA FILA SELECCIONADA
        private void AbrirModalEdicion()
        {
            if (dgvUsuarios.SelectedRows.Count == 0) return;

            var fila    = dgvUsuarios.SelectedRows[0];
            string user = fila.Cells["Usuario"].Value?.ToString() ?? "";
            string rol  = fila.Cells["Rol"].Value?.ToString() ?? "";

            // Obtiene el estado real desde la BD (la celda fue formateada como texto)
            bool estado = false;
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT Estado FROM Usuarios WHERE IdUsuario = @Id",
                    cn.AbrirConexion());
                cmd.Parameters.AddWithValue("@Id", idUsuario);
                estado = Convert.ToBoolean(cmd.ExecuteScalar());
                cn.CerrarConexion();
            }
            catch { cn.CerrarConexion(); }

            using (var modal = new FrmUsuarioModal(idUsuario, user, rol, estado))
            {
                if (modal.ShowDialog(this) == DialogResult.OK)
                {
                    CargarUsuarios();
                    ActualizarCards();
                }
            }
        }

        // ─────────────────────────────────────────
        // BOTON ELIMINAR
        // ─────────────────────────────────────────

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idUsuario == 0)
                {
                    MessageBox.Show("Seleccione un usuario");
                    return;
                }

                DialogResult resultado = MessageBox.Show(
                    "¿Desea eliminar el usuario?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    SqlConnection conexion = cn.AbrirConexion();

                    SqlCommand cmd = new SqlCommand(
                        @"DELETE FROM Usuarios WHERE IdUsuario = @IdUsuario",
                        conexion);
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    cmd.ExecuteNonQuery();

                    cn.CerrarConexion();
                    MessageBox.Show("Usuario eliminado");

                    idUsuario = 0;
                    CargarUsuarios();
                    ActualizarCards();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ─────────────────────────────────────────
        // BOTON ACTUALIZAR
        // ─────────────────────────────────────────

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarUsuarios();
            ActualizarCards();
        }

        // ─────────────────────────────────────────
        // BUSCAR (TextChanged)
        // ─────────────────────────────────────────

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = cn.AbrirConexion();

                SqlDataAdapter da = new SqlDataAdapter(
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

                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.CerrarConexion();
                ConvertirEstado(dt);
                dgvUsuarios.DataSource = dt;

                lblResumen.Text = $"Mostrando {dgvUsuarios.Rows.Count} registro(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
