// IMPORTACION DE LIBRERIAS NECESARIAS
using FontAwesome.Sharp;
using Sistema_Inventario.Datos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO DE ROLES
    public partial class FrmRoles : Form
    {
        // OBJETO DE CONEXION
        Conexion cn = new Conexion();

        // VARIABLE PARA ID DEL ROL
        int idRol = 0;

        // CONSTRUCTOR DEL FORMULARIO
        public FrmRoles()
        {
            InitializeComponent();
            AplicarEstilos();
            ConfigurarGrid();
            CargarRoles();
            CargarPermisos();
            Eventos();
        }

        // ─────────────────────────────────────────
        // ESTILOS Y BOTONES
        // ─────────────────────────────────────────

        private void AplicarEstilos()
        {
            ConfigurarBoton(btnNuevo,      Color.FromArgb(59,  130, 246));
            ConfigurarBoton(btnGuardar,    Color.FromArgb(34,  197,  94));
            ConfigurarBoton(btnEditar,     Color.FromArgb(234, 179,   8));
            ConfigurarBoton(btnEliminar,   Color.FromArgb(231,  76,  60));
            ConfigurarBoton(btnBuscar,     Color.FromArgb(52,  152, 219));
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
            btn.IconSize                  = 20;
            btn.TextImageRelation         = TextImageRelation.ImageBeforeText;
            btn.Cursor                    = Cursors.Hand;

            btn.MouseEnter += (s, e) => { btn.BackColor = ControlPaint.Dark(color); };
            btn.MouseLeave += (s, e) => { btn.BackColor = color; };
        }

        // ─────────────────────────────────────────
        // EVENTOS
        // ─────────────────────────────────────────

        private void Eventos()
        {
            btnNuevo.Click      += BtnNuevo_Click;
            btnGuardar.Click    += BtnGuardar_Click;
            btnEditar.Click     += BtnEditar_Click;
            btnEliminar.Click   += BtnEliminar_Click;
            btnBuscar.Click     += BtnBuscar_Click;
            btnActualizar.Click += BtnActualizar_Click;

            dgvRoles.CellDoubleClick   += DgvRoles_CellDoubleClick;
            dgvRoles.SelectionChanged  += DgvRoles_SelectionChanged;
        }

        // ─────────────────────────────────────────
        // CONFIG GRID
        // ─────────────────────────────────────────

        private void ConfigurarGrid()
        {
            dgvRoles.EnableHeadersVisualStyles = false;
            dgvRoles.BorderStyle               = BorderStyle.None;
            dgvRoles.CellBorderStyle           = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRoles.BackgroundColor           = Color.White;
            dgvRoles.RowHeadersVisible         = false;
            dgvRoles.SelectionMode             = DataGridViewSelectionMode.FullRowSelect;
            dgvRoles.MultiSelect               = false;
            dgvRoles.AllowUserToAddRows        = false;
            dgvRoles.AllowUserToResizeRows     = false;
            dgvRoles.AutoSizeColumnsMode       = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRoles.GridColor                 = Color.LightGray;

            dgvRoles.ColumnHeadersBorderStyle                = DataGridViewHeaderBorderStyle.None;
            dgvRoles.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(11, 31, 58);
            dgvRoles.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRoles.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvRoles.ColumnHeadersHeight                     = 45;

            dgvRoles.DefaultCellStyle.Font               = new Font("Segoe UI", 10);
            dgvRoles.DefaultCellStyle.Padding            = new Padding(5);
            dgvRoles.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvRoles.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvRoles.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
            dgvRoles.RowTemplate.Height = 38;
        }

        // ─────────────────────────────────────────
        // CARGAR ROLES
        // ─────────────────────────────────────────

        private void CargarRoles()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT IdRol, Nombre, Estado
                      FROM Roles
                      ORDER BY Nombre",
                    cn.AbrirConexion());

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvRoles.DataSource = dt;
                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // CARGAR PERMISOS
        // ─────────────────────────────────────────

        private void CargarPermisos()
        {
            try
            {
                clbPermisos.Items.Clear();

                SqlCommand cmd = new SqlCommand(
                    @"SELECT IdPermiso, Nombre
                      FROM Permisos
                      WHERE Estado = 1
                      ORDER BY Nombre",
                    cn.AbrirConexion());

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    clbPermisos.Items.Add(new ItemPermiso()
                    {
                        IdPermiso = Convert.ToInt32(dr["IdPermiso"]),
                        Nombre    = dr["Nombre"].ToString()
                    });
                }

                dr.Close();
                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // BOTON NUEVO
        // ─────────────────────────────────────────

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        // ─────────────────────────────────────────
        // BOTON GUARDAR (INSERT)
        // ─────────────────────────────────────────

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text.Trim() == "")
                {
                    MessageBox.Show(
                        "Ingrese el nombre del rol.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlConnection  conexion    = cn.AbrirConexion();
                SqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    SqlCommand cmd = new SqlCommand(
                        @"INSERT INTO Roles (Nombre, Estado)
                          VALUES (@Nombre, @Estado);
                          SELECT SCOPE_IDENTITY();",
                        conexion, transaccion);

                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@Estado", chkEstado.Checked);

                    idRol = Convert.ToInt32(cmd.ExecuteScalar());

                    foreach (var item in clbPermisos.CheckedItems)
                    {
                        ItemPermiso permiso = (ItemPermiso)item;

                        SqlCommand cmdPermiso = new SqlCommand(
                            @"INSERT INTO RolesPermisos (IdRol, IdPermiso)
                              VALUES (@IdRol, @IdPermiso)",
                            conexion, transaccion);

                        cmdPermiso.Parameters.AddWithValue("@IdRol",     idRol);
                        cmdPermiso.Parameters.AddWithValue("@IdPermiso", permiso.IdPermiso);
                        cmdPermiso.ExecuteNonQuery();
                    }

                    transaccion.Commit();

                    MessageBox.Show(
                        "Rol guardado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarRoles();
                    Limpiar();
                }
                catch
                {
                    transaccion.Rollback();
                    throw;
                }

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // BOTON EDITAR (UPDATE)
        // ─────────────────────────────────────────

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idRol == 0)
                {
                    MessageBox.Show(
                        "Seleccione un rol de la lista.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlConnection  conexion    = cn.AbrirConexion();
                SqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    SqlCommand cmd = new SqlCommand(
                        @"UPDATE Roles
                          SET Nombre = @Nombre, Estado = @Estado
                          WHERE IdRol = @IdRol",
                        conexion, transaccion);

                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@Estado", chkEstado.Checked);
                    cmd.Parameters.AddWithValue("@IdRol",  idRol);
                    cmd.ExecuteNonQuery();

                    SqlCommand eliminar = new SqlCommand(
                        "DELETE FROM RolesPermisos WHERE IdRol = @IdRol",
                        conexion, transaccion);
                    eliminar.Parameters.AddWithValue("@IdRol", idRol);
                    eliminar.ExecuteNonQuery();

                    foreach (var item in clbPermisos.CheckedItems)
                    {
                        ItemPermiso permiso = (ItemPermiso)item;

                        SqlCommand insertar = new SqlCommand(
                            @"INSERT INTO RolesPermisos (IdRol, IdPermiso)
                              VALUES (@IdRol, @IdPermiso)",
                            conexion, transaccion);

                        insertar.Parameters.AddWithValue("@IdRol",     idRol);
                        insertar.Parameters.AddWithValue("@IdPermiso", permiso.IdPermiso);
                        insertar.ExecuteNonQuery();
                    }

                    transaccion.Commit();

                    MessageBox.Show(
                        "Rol actualizado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarRoles();
                    Limpiar();
                }
                catch
                {
                    transaccion.Rollback();
                    throw;
                }

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // BOTON ELIMINAR (DELETE)
        // ─────────────────────────────────────────

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idRol == 0)
                {
                    MessageBox.Show(
                        "Seleccione un rol para eliminar.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show(
                        "¿Está seguro de eliminar este rol?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No)
                    return;

                SqlConnection  conexion    = cn.AbrirConexion();
                SqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    SqlCommand cmdPermisos = new SqlCommand(
                        "DELETE FROM RolesPermisos WHERE IdRol = @IdRol",
                        conexion, transaccion);
                    cmdPermisos.Parameters.AddWithValue("@IdRol", idRol);
                    cmdPermisos.ExecuteNonQuery();

                    SqlCommand cmdRol = new SqlCommand(
                        "DELETE FROM Roles WHERE IdRol = @IdRol",
                        conexion, transaccion);
                    cmdRol.Parameters.AddWithValue("@IdRol", idRol);
                    cmdRol.ExecuteNonQuery();

                    transaccion.Commit();

                    MessageBox.Show(
                        "Rol eliminado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarRoles();
                    Limpiar();
                }
                catch
                {
                    transaccion.Rollback();
                    throw;
                }

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // BOTON BUSCAR
        // ─────────────────────────────────────────

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT IdRol, Nombre, Estado
                      FROM Roles
                      WHERE Nombre LIKE @Filtro
                      ORDER BY Nombre",
                    cn.AbrirConexion());

                da.SelectCommand.Parameters.AddWithValue(
                    "@Filtro", "%" + txtBuscar.Text.Trim() + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvRoles.DataSource = dt;
                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // BOTON ACTUALIZAR (MOSTRAR TODO)
        // ─────────────────────────────────────────

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarRoles();
            txtBuscar.Clear();
            Limpiar();
        }

        // ─────────────────────────────────────────
        // DOBLE CLICK EN GRID
        // ─────────────────────────────────────────

        private void DgvRoles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                CargarDatosRol(dgvRoles.Rows[e.RowIndex]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // SELECCION EN GRID
        // ─────────────────────────────────────────

        private void DgvRoles_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvRoles.CurrentRow == null) return;
                CargarDatosRol(dgvRoles.CurrentRow);
            }
            catch { }
        }

        // ─────────────────────────────────────────
        // CARGA LOS DATOS DEL ROL SELECCIONADO
        // ─────────────────────────────────────────

        private void CargarDatosRol(DataGridViewRow fila)
        {
            // DESMARCA PERMISOS ACTUALES
            for (int i = 0; i < clbPermisos.Items.Count; i++)
                clbPermisos.SetItemChecked(i, false);

            idRol             = Convert.ToInt32(fila.Cells["IdRol"].Value);
            txtNombre.Text    = fila.Cells["Nombre"].Value.ToString();
            chkEstado.Checked = Convert.ToBoolean(fila.Cells["Estado"].Value);

            // MARCA LOS PERMISOS DEL ROL
            SqlCommand cmd = new SqlCommand(
                @"SELECT IdPermiso FROM RolesPermisos WHERE IdRol = @IdRol",
                cn.AbrirConexion());
            cmd.Parameters.AddWithValue("@IdRol", idRol);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int idPermiso = Convert.ToInt32(dr["IdPermiso"]);

                for (int i = 0; i < clbPermisos.Items.Count; i++)
                {
                    if (((ItemPermiso)clbPermisos.Items[i]).IdPermiso == idPermiso)
                        clbPermisos.SetItemChecked(i, true);
                }
            }

            dr.Close();
            cn.CerrarConexion();
        }

        // ─────────────────────────────────────────
        // LIMPIAR FORMULARIO
        // ─────────────────────────────────────────

        private void Limpiar()
        {
            idRol             = 0;
            txtNombre.Clear();
            chkEstado.Checked = true;

            for (int i = 0; i < clbPermisos.Items.Count; i++)
                clbPermisos.SetItemChecked(i, false);

            txtNombre.Focus();
        }

        private void dgvRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    // ITEM PERMISO
    public class ItemPermiso
    {
        public int    IdPermiso { get; set; }
        public string Nombre    { get; set; }

        public override string ToString() => Nombre;
    }
}
