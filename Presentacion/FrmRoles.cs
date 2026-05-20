// IMPORTACION DE LIBRERIAS NECESARIAS
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

            // CONFIGURA EL GRID
            ConfigurarGrid();

            // CARGA LOS ROLES
            CargarRoles();

            // CARGA LOS PERMISOS
            CargarPermisos();

            // CARGA LOS EVENTOS
            Eventos();
        }

        // EVENTOS

        private void Eventos()
        {
            // EVENTO BOTON NUEVO
            btnNuevo.Click += BtnNuevo_Click;

            // EVENTO BOTON GUARDAR
            btnGuardar.Click += BtnGuardar_Click;

            // EVENTO BOTON EDITAR
            btnEditar.Click += BtnEditar_Click;

            // EVENTO DOBLE CLICK GRID
            dgvRoles.CellDoubleClick +=
                DgvRoles_CellDoubleClick;
        }

        // CONFIG GRID

        private void ConfigurarGrid()
        {
            // CONFIG GENERAL

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

            // HEADER

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

            // FILAS

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

            // GRID

            dgvRoles.GridColor =
                Color.LightGray;
        }

        // CARGAR ROLES

        private void CargarRoles()
        {
            try
            {
                // ADAPTADOR DE DATOS
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        @"SELECT
                            IdRol,
                            Nombre,
                            Estado
                        FROM Roles
                        ORDER BY Nombre",
                        cn.AbrirConexion());

                // TABLA TEMPORAL
                DataTable dt =
                    new DataTable();

                // LLENA LA TABLA
                da.Fill(dt);

                // MUESTRA LOS DATOS EN EL GRID
                dgvRoles.DataSource = dt;

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

        // CARGAR PERMISOS

        private void CargarPermisos()
        {
            try
            {
                // LIMPIA LOS ITEMS
                clbPermisos.Items.Clear();

                // COMANDO SQL
                SqlCommand cmd =
                    new SqlCommand(
                        @"SELECT
                            IdPermiso,
                            Nombre
                        FROM Permisos
                        WHERE Estado = 1
                        ORDER BY Nombre",
                        cn.AbrirConexion());

                // LECTOR DE DATOS
                SqlDataReader dr =
                    cmd.ExecuteReader();

                // RECORRE LOS DATOS
                while (dr.Read())
                {
                    // AGREGA EL ITEM
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

                // CIERRA EL LECTOR
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

        // NUEVO

        private void BtnNuevo_Click(
            object sender,
            EventArgs e)
        {
            // LIMPIA LOS CAMPOS
            Limpiar();
        }

        // GUARDAR

        private void BtnGuardar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                // VALIDA EL NOMBRE
                if (txtNombre.Text.Trim() == "")
                {
                    MessageBox.Show(
                        "Ingrese el nombre del rol");

                    return;
                }

                // ABRE LA CONEXION
                SqlConnection conexion =
                    cn.AbrirConexion();

                // INICIA TRANSACCION
                SqlTransaction transaccion =
                    conexion.BeginTransaction();

                try
                {
                    // COMANDO SQL
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

                    // PARAMETRO NOMBRE
                    cmd.Parameters.AddWithValue(
                        "@Nombre",
                        txtNombre.Text);

                    // PARAMETRO ESTADO
                    cmd.Parameters.AddWithValue(
                        "@Estado",
                        chkEstado.Checked);

                    // OBTIENE EL ID
                    idRol =
                        Convert.ToInt32(
                            cmd.ExecuteScalar());

                    // RECORRE LOS PERMISOS
                    foreach (var item
                        in clbPermisos.CheckedItems)
                    {
                        // OBJETO PERMISO
                        ItemPermiso permiso =
                            (ItemPermiso)item;

                        // COMANDO SQL
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

                        // PARAMETRO ID ROL
                        cmdPermiso.Parameters.AddWithValue(
                            "@IdRol",
                            idRol);

                        // PARAMETRO ID PERMISO
                        cmdPermiso.Parameters.AddWithValue(
                            "@IdPermiso",
                            permiso.IdPermiso);

                        // EJECUTA EL COMANDO
                        cmdPermiso.ExecuteNonQuery();
                    }

                    // CONFIRMA LA TRANSACCION
                    transaccion.Commit();

                    // MENSAJE DE CONFIRMACION
                    MessageBox.Show(
                        "Rol guardado correctamente");

                    // RECARGA LOS ROLES
                    CargarRoles();

                    // LIMPIA LOS CAMPOS
                    Limpiar();
                }
                catch
                {
                    // CANCELA LA TRANSACCION
                    transaccion.Rollback();

                    throw;
                }

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

        // EDITAR

        private void BtnEditar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                // VALIDA EL ID
                if (idRol == 0)
                {
                    MessageBox.Show(
                        "Seleccione un rol");

                    return;
                }

                // ABRE LA CONEXION
                SqlConnection conexion =
                    cn.AbrirConexion();

                // INICIA TRANSACCION
                SqlTransaction transaccion =
                    conexion.BeginTransaction();

                try
                {
                    // COMANDO SQL
                    SqlCommand cmd =
                        new SqlCommand(
                            @"UPDATE Roles
                            SET
                                Nombre = @Nombre,
                                Estado = @Estado
                            WHERE IdRol = @IdRol",
                            conexion,
                            transaccion);

                    // PARAMETRO NOMBRE
                    cmd.Parameters.AddWithValue(
                        "@Nombre",
                        txtNombre.Text);

                    // PARAMETRO ESTADO
                    cmd.Parameters.AddWithValue(
                        "@Estado",
                        chkEstado.Checked);

                    // PARAMETRO ID ROL
                    cmd.Parameters.AddWithValue(
                        "@IdRol",
                        idRol);

                    // EJECUTA EL COMANDO
                    cmd.ExecuteNonQuery();

                    // COMANDO ELIMINAR PERMISOS
                    SqlCommand eliminar =
                        new SqlCommand(
                            @"DELETE FROM RolesPermisos
                            WHERE IdRol = @IdRol",
                            conexion,
                            transaccion);

                    // PARAMETRO ID ROL
                    eliminar.Parameters.AddWithValue(
                        "@IdRol",
                        idRol);

                    // EJECUTA EL COMANDO
                    eliminar.ExecuteNonQuery();

                    // RECORRE LOS PERMISOS
                    foreach (var item
                        in clbPermisos.CheckedItems)
                    {
                        // OBJETO PERMISO
                        ItemPermiso permiso =
                            (ItemPermiso)item;

                        // COMANDO SQL
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

                        // PARAMETRO ID ROL
                        insertar.Parameters.AddWithValue(
                            "@IdRol",
                            idRol);

                        // PARAMETRO ID PERMISO
                        insertar.Parameters.AddWithValue(
                            "@IdPermiso",
                            permiso.IdPermiso);

                        // EJECUTA EL COMANDO
                        insertar.ExecuteNonQuery();
                    }

                    // CONFIRMA LA TRANSACCION
                    transaccion.Commit();

                    // MENSAJE DE CONFIRMACION
                    MessageBox.Show(
                        "Rol actualizado");

                    // RECARGA LOS ROLES
                    CargarRoles();

                    // LIMPIA LOS CAMPOS
                    Limpiar();
                }
                catch
                {
                    // CANCELA LA TRANSACCION
                    transaccion.Rollback();

                    throw;
                }

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

        // DOBLE CLICK GRID

        private void DgvRoles_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            try
            {
                // VALIDA LA FILA
                if (e.RowIndex >= 0)
                {
                    // DESMARCA LOS PERMISOS
                    foreach (int i
                        in clbPermisos.CheckedIndices)
                    {
                        clbPermisos.SetItemChecked(
                            i,
                            false);
                    }

                    // OBTIENE LA FILA
                    DataGridViewRow fila =
                        dgvRoles.Rows[e.RowIndex];

                    // OBTIENE EL ID
                    idRol =
                        Convert.ToInt32(
                            fila.Cells["IdRol"].Value);

                    // ASIGNA EL NOMBRE
                    txtNombre.Text =
                        fila.Cells["Nombre"].Value.ToString();

                    // ASIGNA EL ESTADO
                    chkEstado.Checked =
                        Convert.ToBoolean(
                            fila.Cells["Estado"].Value);

                    // COMANDO SQL
                    SqlCommand cmd =
                        new SqlCommand(
                            @"SELECT IdPermiso
                            FROM RolesPermisos
                            WHERE IdRol = @IdRol",
                            cn.AbrirConexion());

                    // PARAMETRO ID ROL
                    cmd.Parameters.AddWithValue(
                        "@IdRol",
                        idRol);

                    // LECTOR DE DATOS
                    SqlDataReader dr =
                        cmd.ExecuteReader();

                    // RECORRE LOS DATOS
                    while (dr.Read())
                    {
                        // OBTIENE EL ID PERMISO
                        int idPermiso =
                            Convert.ToInt32(
                                dr["IdPermiso"]);

                        // RECORRE LOS ITEMS
                        for (int i = 0;
                            i < clbPermisos.Items.Count;
                            i++)
                        {
                            // OBJETO ITEM
                            ItemPermiso item =
                                (ItemPermiso)
                                clbPermisos.Items[i];

                            // VALIDA EL ID
                            if (item.IdPermiso ==
                                idPermiso)
                            {
                                // MARCA EL ITEM
                                clbPermisos.SetItemChecked(
                                    i,
                                    true);
                            }
                        }
                    }

                    // CIERRA EL LECTOR
                    dr.Close();

                    // CIERRA LA CONEXION
                    cn.CerrarConexion();
                }
            }
            catch (Exception ex)
            {
                // MUESTRA EL ERROR
                MessageBox.Show(
                    ex.Message);
            }
        }

        private void DgvRoles_SelectionChanged(
            object sender,
            EventArgs e)
        {
            try
            {
                // VALIDA SI EXISTE FILA
                if (dgvRoles.CurrentRow == null)
                    return;

                // DESMARCA LOS PERMISOS
                foreach (int i
                    in clbPermisos.CheckedIndices)
                {
                    clbPermisos.SetItemChecked(
                        i,
                        false);
                }

                // OBTIENE LA FILA
                DataGridViewRow fila =
                    dgvRoles.CurrentRow;

                // OBTIENE EL ID
                idRol =
                    Convert.ToInt32(
                        fila.Cells["IdRol"].Value);

                // ASIGNA EL NOMBRE
                txtNombre.Text =
                    fila.Cells["Nombre"].Value.ToString();

                // ASIGNA EL ESTADO
                chkEstado.Checked =
                    Convert.ToBoolean(
                        fila.Cells["Estado"].Value);

                // COMANDO SQL
                SqlCommand cmd =
                    new SqlCommand(
                        @"SELECT IdPermiso
                FROM RolesPermisos
                WHERE IdRol = @IdRol",
                        cn.AbrirConexion());

                // PARAMETRO ID ROL
                cmd.Parameters.AddWithValue(
                    "@IdRol",
                    idRol);

                // LECTOR DE DATOS
                SqlDataReader dr =
                    cmd.ExecuteReader();

                // RECORRE LOS DATOS
                while (dr.Read())
                {
                    // OBTIENE EL ID PERMISO
                    int idPermiso =
                        Convert.ToInt32(
                            dr["IdPermiso"]);

                    // RECORRE LOS ITEMS
                    for (int i = 0;
                        i < clbPermisos.Items.Count;
                        i++)
                    {
                        // OBJETO ITEM
                        ItemPermiso item =
                            (ItemPermiso)
                            clbPermisos.Items[i];

                        // VALIDA EL ID
                        if (item.IdPermiso ==
                            idPermiso)
                        {
                            // MARCA EL ITEM
                            clbPermisos.SetItemChecked(
                                i,
                                true);
                        }
                    }
                }

                // CIERRA EL LECTOR
                dr.Close();

                // CIERRA LA CONEXION
                cn.CerrarConexion();
            }
            catch
            {

            }
        }

        // LIMPIAR

        private void Limpiar()
        {
            // RESETEA EL ID
            idRol = 0;

            // LIMPIA EL NOMBRE
            txtNombre.Clear();

            // ACTIVA EL ESTADO
            chkEstado.Checked = true;

            // DESMARCA LOS PERMISOS
            for (int i = 0;
                i < clbPermisos.Items.Count;
                i++)
            {
                clbPermisos.SetItemChecked(
                    i,
                    false);
            }

            // ENVIA EL FOCO
            txtNombre.Focus();
        }

        private void dgvRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    // ITEM PERMISO

    public class ItemPermiso
    {
        // ID DEL PERMISO
        public int IdPermiso { get; set; }

        // NOMBRE DEL PERMISO
        public string Nombre { get; set; }

        // RETORNA EL NOMBRE
        public override string ToString()
        {
            return Nombre;
        }
    }
}