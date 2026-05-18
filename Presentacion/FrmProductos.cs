using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Sistema_Inventario.Datos;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Presentacion
{
    public partial class FrmProductos : Form
    {
        Conexion cn = new Conexion();

    Logger log = new Logger();

        int IdProducto = 0;

        public FrmProductos()
        {
            InitializeComponent();

            AplicarEstilos();
        }

        private void AplicarEstilos()
        {
            ConfigurarBoton(btnNuevo,
                Color.FromArgb(52, 152, 219));

            ConfigurarBoton(btnGuardar,
                Color.FromArgb(46, 204, 113));

            ConfigurarBoton(btnEditar,
                Color.FromArgb(241, 196, 15));

            ConfigurarBoton(btnEliminar,
                Color.FromArgb(231, 76, 60));

            ConfigurarBoton(btnBuscar,
                Color.FromArgb(11, 31, 58));

            ConfigurarGrid();
        }

        private void ConfigurarBoton(
            IconButton btn,
            Color color)
        {
            btn.BackColor = color;

            btn.ForeColor = Color.White;

            btn.FlatStyle = FlatStyle.Flat;

            btn.FlatAppearance.BorderSize = 0;

            btn.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            btn.IconColor = Color.White;

            btn.IconSize = 24;

            btn.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            btn.ImageAlign =
                ContentAlignment.MiddleLeft;

            btn.Padding =
                new Padding(12, 0, 0, 0);

            btn.Cursor =
                Cursors.Hand;

            btn.MouseEnter +=
                (s, e) =>
                {
                    btn.BackColor =
                        ControlPaint.Dark(color);
                };

            btn.MouseLeave +=
                (s, e) =>
                {
                    btn.BackColor = color;
                };
        }

        private void ConfigurarGrid()
        {
            dgvProductos.BorderStyle =
                BorderStyle.None;

            dgvProductos.BackgroundColor =
                Color.White;

            dgvProductos.EnableHeadersVisualStyles =
                false;

            dgvProductos.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvProductos.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(11, 31, 58);

            dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvProductos.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            dgvProductos.ColumnHeadersHeight = 45;

            dgvProductos.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10F);

            dgvProductos.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(52, 152, 219);

            dgvProductos.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvProductos.RowsDefaultCellStyle.BackColor =
                Color.White;

            dgvProductos.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 247, 250);

            dgvProductos.RowTemplate.Height = 38;

            dgvProductos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvProductos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvProductos.MultiSelect = false;

            dgvProductos.RowHeadersVisible = false;

            dgvProductos.GridColor =
                Color.LightGray;
        }

        private void FrmProductos_Load(
            object sender,
            EventArgs e)
        {
            MostrarProductos();
        }

        private void MostrarProductos()
        {
            try
            {
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        "sp_MostrarProductos",
                        cn.AbrirConexion());

                da.SelectCommand.CommandType =
                    CommandType.StoredProcedure;

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                dgvProductos.DataSource = dt;

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                log.RegistrarLog(
                    "ERROR PRODUCTOS",
                    "admin",
                    ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();

            txtCategoria.Clear();

            txtPrecio.Clear();

            txtStock.Clear();

            txtNombre.Focus();
        }

        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                SqlCommand cmd =
                    new SqlCommand(
                        "sp_InsertarProducto",
                        cn.AbrirConexion());

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@Nombre",
                    txtNombre.Text);

                cmd.Parameters.AddWithValue(
                    "@Categoria",
                    txtCategoria.Text);

                cmd.Parameters.AddWithValue(
                    "@Precio",
                    txtPrecio.Text);

                cmd.Parameters.AddWithValue(
                    "@Stock",
                    txtStock.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "Producto guardado correctamente");

                MostrarProductos();

                LimpiarCampos();

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvProductos_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    IdProducto =
                        Convert.ToInt32(
                            dgvProductos.Rows[e.RowIndex]
                            .Cells[0].Value);

                    txtNombre.Text =
                        dgvProductos.Rows[e.RowIndex]
                        .Cells[1].Value.ToString();

                    txtCategoria.Text =
                        dgvProductos.Rows[e.RowIndex]
                        .Cells[2].Value.ToString();

                    txtPrecio.Text =
                        dgvProductos.Rows[e.RowIndex]
                        .Cells[3].Value.ToString();

                    txtStock.Text =
                        dgvProductos.Rows[e.RowIndex]
                        .Cells[4].Value.ToString();
                }
            }
            catch
            {

            }
        }

        private void btnEditar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                SqlCommand cmd =
                    new SqlCommand(
                        "sp_EditarProducto",
                        cn.AbrirConexion());

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@IdProducto",
                    IdProducto);

                cmd.Parameters.AddWithValue(
                    "@Nombre",
                    txtNombre.Text);

                cmd.Parameters.AddWithValue(
                    "@Categoria",
                    txtCategoria.Text);

                cmd.Parameters.AddWithValue(
                    "@Precio",
                    txtPrecio.Text);

                cmd.Parameters.AddWithValue(
                    "@Stock",
                    txtStock.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "Producto actualizado");

                MostrarProductos();

                LimpiarCampos();

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                DialogResult resultado;

                resultado =
                    MessageBox.Show(
                        "¿Desea eliminar este producto?",
                        "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (resultado ==
                    DialogResult.Yes)
                {
                    SqlCommand cmd =
                        new SqlCommand(
                            "sp_EliminarProducto",
                            cn.AbrirConexion());

                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "@IdProducto",
                        IdProducto);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Producto eliminado");

                    MostrarProductos();

                    LimpiarCampos();

                    cn.CerrarConexion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        "sp_BuscarProducto",
                        cn.AbrirConexion());

                da.SelectCommand.CommandType =
                    CommandType.StoredProcedure;

                da.SelectCommand.Parameters.AddWithValue(
                    "@Texto",
                    txtBuscar.Text);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                dgvProductos.DataSource = dt;

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNuevo_Click(
            object sender,
            EventArgs e)
        {
            LimpiarCampos();

            MostrarProductos();

            IdProducto = 0;
        }
    }

}
