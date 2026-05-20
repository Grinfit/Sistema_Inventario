using Sistema_Inventario.Datos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Inventario.Presentacion
{
    public partial class FrmRoles : Form
    {
        Conexion cn = new Conexion();

        int idRol = 0;

        public FrmRoles()
        {
            InitializeComponent();

            ConfigurarGrid();

            CargarRoles();

            CargarPermisos();

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

            dgvRoles.CellDoubleClick +=
                DgvRoles_CellDoubleClick;
        }

        // =========================================
        // CONFIG GRID
        // =========================================

        private void ConfigurarGrid()
        {
            // =====================================
            // CONFIG GENERAL
            // =====================================

            dgvRoles.EnableHeadersVisualStyles =
                false;

            dgvRoles.BorderStyle =
                BorderStyle.None;

            dgvRoles.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvRoles.BackgroundColor =
                Color.White;

            dgvRoles.RowHeadersVisible =
                false;

            dgvRoles.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvRoles.MultiSelect =
                false;

            dgvRoles.AllowUserToAddRows =
                false;

            dgvRoles.AllowUserToResizeRows =
                false;

            dgvRoles.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // =====================================
            // HEADER
            // =====================================

            dgvRoles.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvRoles.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(11, 31, 58);

            dgvRoles.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvRoles.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold);

            dgvRoles.ColumnHeadersHeight =
                45;

            // =====================================
            // FILAS
            // =====================================

            dgvRoles.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10);

            dgvRoles.DefaultCellStyle.Padding =
                new Padding(5);

            dgvRoles.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(59, 130, 246);

            dgvRoles.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvRoles.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 247, 250);

            dgvRoles.RowTemplate.Height =
                38;

            // =====================================
            // GRID
            // =====================================

            dgvRoles.GridColor =
                Color.LightGray;
        }

        // =========================================
        // CARGAR ROLES
        // =========================================

        private void CargarRoles()
        {
            try
            {
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        @"SELECT
                            IdRol,
                            Nombre,
                            Estado
                        FROM Roles
                        ORDER BY Nombre",
                        cn.AbrirConexion());

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                dgvRoles.DataSource = dt;

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
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
                clbPermisos.Items.Clear();

                SqlCommand cmd =
                    new SqlCommand(
                        @"SELECT
                            IdPermiso,
                            Nombre
                        FROM Permisos
                        WHERE Estado = 1
                        ORDER BY Nombre",
                        cn.AbrirConexion());

                SqlDataReader dr =
                    cmd.ExecuteReader();

                while (dr.Read())
                {
                    clbPermisos.Items.Add(
                        new ItemPermiso()
                        {
                            IdPermiso =
                                Convert.ToInt32(
                                    dr["IdPermiso"]),

                            Nombre =
                                dr["Nombre"].ToString()
                        });
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
                if (txtNombre.Text.Trim() == "")
                {
                    MessageBox.Show(
                        "Ingrese el nombre del rol");

                    return;
                }

                SqlConnection conexion =
                    cn.AbrirConexion();

                SqlTransaction transaccion =
                    conexion.BeginTransaction();

                try
                {
                    SqlCommand cmd =
                        new SqlCommand(
                            @"INSERT INTO Roles
                            (
                                Nombre,
                                Estado
                            )
                            VALUES
                            (
                                @Nombre,
                                @Estado
                            );

                            SELECT SCOPE_IDENTITY();",
                            conexion,
                            transaccion);

                    cmd.Parameters.AddWithValue(
                        "@Nombre",
                        txtNombre.Text);

                    cmd.Parameters.AddWithValue(
                        "@Estado",
                        chkEstado.Checked);

                    idRol =
                        Convert.ToInt32(
                            cmd.ExecuteScalar());

                    foreach (var item
                        in clbPermisos.CheckedItems)
                    {
                        ItemPermiso permiso =
                            (ItemPermiso)item;

                        SqlCommand cmdPermiso =
                            new SqlCommand(
                                @"INSERT INTO RolesPermisos
                                (
                                    IdRol,
                                    IdPermiso
                                )
                                VALUES
                                (
                                    @IdRol,
                                    @IdPermiso
                                )",
                                conexion,
                                transaccion);

                        cmdPermiso.Parameters.AddWithValue(
                            "@IdRol",
                            idRol);

                        cmdPermiso.Parameters.AddWithValue(
                            "@IdPermiso",
                            permiso.IdPermiso);

                        cmdPermiso.ExecuteNonQuery();
                    }

                    transaccion.Commit();

                    MessageBox.Show(
                        "Rol guardado correctamente");

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
                if (idRol == 0)
                {
                    MessageBox.Show(
                        "Seleccione un rol");

                    return;
                }

                SqlConnection conexion =
                    cn.AbrirConexion();

                SqlTransaction transaccion =
                    conexion.BeginTransaction();

                try
                {
                    SqlCommand cmd =
                        new SqlCommand(
                            @"UPDATE Roles
                            SET
                                Nombre = @Nombre,
                                Estado = @Estado
                            WHERE IdRol = @IdRol",
                            conexion,
                            transaccion);

                    cmd.Parameters.AddWithValue(
                        "@Nombre",
                        txtNombre.Text);

                    cmd.Parameters.AddWithValue(
                        "@Estado",
                        chkEstado.Checked);

                    cmd.Parameters.AddWithValue(
                        "@IdRol",
                        idRol);

                    cmd.ExecuteNonQuery();

                    SqlCommand eliminar =
                        new SqlCommand(
                            @"DELETE FROM RolesPermisos
                            WHERE IdRol = @IdRol",
                            conexion,
                            transaccion);

                    eliminar.Parameters.AddWithValue(
                        "@IdRol",
                        idRol);

                    eliminar.ExecuteNonQuery();

                    foreach (var item
                        in clbPermisos.CheckedItems)
                    {
                        ItemPermiso permiso =
                            (ItemPermiso)item;

                        SqlCommand insertar =
                            new SqlCommand(
                                @"INSERT INTO RolesPermisos
                                (
                                    IdRol,
                                    IdPermiso
                                )
                                VALUES
                                (
                                    @IdRol,
                                    @IdPermiso
                                )",
                                conexion,
                                transaccion);

                        insertar.Parameters.AddWithValue(
                            "@IdRol",
                            idRol);

                        insertar.Parameters.AddWithValue(
                            "@IdPermiso",
                            permiso.IdPermiso);

                        insertar.ExecuteNonQuery();
                    }

                    transaccion.Commit();

                    MessageBox.Show(
                        "Rol actualizado");

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
                MessageBox.Show(
                    ex.Message);
            }
        }

        // =========================================
        // DOBLE CLICK GRID
        // =========================================

        private void DgvRoles_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    foreach (int i
                        in clbPermisos.CheckedIndices)
                    {
                        clbPermisos.SetItemChecked(
                            i,
                            false);
                    }

                    DataGridViewRow fila =
                        dgvRoles.Rows[e.RowIndex];

                    idRol =
                        Convert.ToInt32(
                            fila.Cells["IdRol"].Value);

                    txtNombre.Text =
                        fila.Cells["Nombre"].Value.ToString();

                    chkEstado.Checked =
                        Convert.ToBoolean(
                            fila.Cells["Estado"].Value);

                    SqlCommand cmd =
                        new SqlCommand(
                            @"SELECT IdPermiso
                            FROM RolesPermisos
                            WHERE IdRol = @IdRol",
                            cn.AbrirConexion());

                    cmd.Parameters.AddWithValue(
                        "@IdRol",
                        idRol);

                    SqlDataReader dr =
                        cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        int idPermiso =
                            Convert.ToInt32(
                                dr["IdPermiso"]);

                        for (int i = 0;
                            i < clbPermisos.Items.Count;
                            i++)
                        {
                            ItemPermiso item =
                                (ItemPermiso)
                                clbPermisos.Items[i];

                            if (item.IdPermiso ==
                                idPermiso)
                            {
                                clbPermisos.SetItemChecked(
                                    i,
                                    true);
                            }
                        }
                    }

                    dr.Close();

                    cn.CerrarConexion();
                }
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
            idRol = 0;

            txtNombre.Clear();

            chkEstado.Checked = true;

            for (int i = 0;
                i < clbPermisos.Items.Count;
                i++)
            {
                clbPermisos.SetItemChecked(
                    i,
                    false);
            }

            txtNombre.Focus();
        }

        private void dgvRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    // =============================================
    // ITEM PERMISO
    // =============================================

    public class ItemPermiso
    {
        public int IdPermiso { get; set; }

        public string Nombre { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}