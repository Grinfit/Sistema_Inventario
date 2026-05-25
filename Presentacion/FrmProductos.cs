// IMPORTACION DE LIBRERIAS NECESARIAS
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
    // FORMULARIO PRINCIPAL DE GESTION DE PRODUCTOS
    public partial class FrmProductos : Form
    {
        // OBJETO DE CONEXION
        Conexion cn = new Conexion();

        // OBJETO LOGGER
        Logger log = new Logger();

        // ID DEL PRODUCTO SELECCIONADO EN LA GRILLA
        int IdProducto = 0;

        // CONSTRUCTOR
        public FrmProductos()
        {
            InitializeComponent();
            AplicarEstilos();
        }

        // APLICA ESTILOS A BOTONES Y GRILLA
        private void AplicarEstilos()
        {
            ConfigurarBoton(btnNuevo,    Color.FromArgb(52,  152, 219));
            ConfigurarBoton(btnEditar,   Color.FromArgb(241, 196,  15));
            ConfigurarBoton(btnEliminar, Color.FromArgb(231,  76,  60));
            ConfigurarBoton(btnBuscar,   Color.FromArgb( 10,  31,  58));
            ConfigurarBoton(btnExportar, Color.FromArgb( 39, 174,  96));
            ConfigurarGrid();
        }

        // CONFIGURA ESTILO UNIFICADO DE BOTON
        private void ConfigurarBoton(IconButton btn, Color color)
        {
            btn.BackColor                 = color;
            btn.ForeColor                 = Color.White;
            btn.FlatStyle                 = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font                      = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.IconColor                 = Color.White;
            btn.IconSize                  = 24;
            btn.TextImageRelation         = TextImageRelation.ImageBeforeText;
            btn.ImageAlign                = ContentAlignment.MiddleLeft;
            btn.Padding                   = new Padding(12, 0, 0, 0);
            btn.Cursor                    = Cursors.Hand;

            btn.MouseEnter += (s, e) => { btn.BackColor = ControlPaint.Dark(color); };
            btn.MouseLeave += (s, e) => { btn.BackColor = color; };
        }

        // CONFIGURA ESTILO DE LA GRILLA
        private void ConfigurarGrid()
        {
            dgvProductos.BorderStyle                              = BorderStyle.None;
            dgvProductos.BackgroundColor                          = Color.White;
            dgvProductos.EnableHeadersVisualStyles                = false;
            dgvProductos.ColumnHeadersBorderStyle                 = DataGridViewHeaderBorderStyle.None;
            dgvProductos.ColumnHeadersDefaultCellStyle.BackColor  = Color.FromArgb(11, 31, 58);
            dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor  = Color.White;
            dgvProductos.ColumnHeadersDefaultCellStyle.Font       = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvProductos.ColumnHeadersHeight                      = 45;
            dgvProductos.DefaultCellStyle.Font                    = new Font("Segoe UI", 10F);
            dgvProductos.DefaultCellStyle.SelectionBackColor      = Color.FromArgb(52, 152, 219);
            dgvProductos.DefaultCellStyle.SelectionForeColor      = Color.White;
            dgvProductos.RowsDefaultCellStyle.BackColor           = Color.White;
            dgvProductos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
            dgvProductos.RowTemplate.Height                       = 38;
            dgvProductos.AutoSizeColumnsMode                      = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.SelectionMode                            = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect                              = false;
            dgvProductos.RowHeadersVisible                        = false;
            dgvProductos.GridColor                                = Color.LightGray;
        }

        // ─────────────────────────────────────────
        // CARGA INICIAL
        // ─────────────────────────────────────────

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        // CARGA TODOS LOS PRODUCTOS EN LA GRILLA
        private void MostrarProductos()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_MostrarProductos", cn.AbrirConexion());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProductos.DataSource = dt;
                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.RegistrarLog("ERROR PRODUCTOS", SesionUsuario.Usuario, ex.Message);
            }
        }

        // ─────────────────────────────────────────
        // SELECCION EN LA GRILLA
        // ─────────────────────────────────────────

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                    IdProducto = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells[0].Value);
            }
            catch { }
        }

        // ─────────────────────────────────────────
        // BOTON NUEVO — abre modal en modo creación
        // ─────────────────────────────────────────

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmProductoModal modal = new FrmProductoModal())
            {
                if (modal.ShowDialog(this) == DialogResult.OK)
                {
                    MostrarProductos();
                    IdProducto = 0;
                }
            }
        }

        // ─────────────────────────────────────────
        // BOTON EDITAR — abre modal en modo edición
        // ─────────────────────────────────────────

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (IdProducto == 0 || dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Seleccione un producto de la lista antes de editar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow fila = dgvProductos.SelectedRows[0];

            using (FrmProductoModal modal = new FrmProductoModal(
                IdProducto,
                fila.Cells[1].Value?.ToString() ?? "",
                fila.Cells[2].Value?.ToString() ?? "",
                fila.Cells[3].Value?.ToString() ?? "",
                fila.Cells[4].Value?.ToString() ?? ""))
            {
                if (modal.ShowDialog(this) == DialogResult.OK)
                    MostrarProductos();
            }
        }

        // ─────────────────────────────────────────
        // BOTON ELIMINAR
        // ─────────────────────────────────────────

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (IdProducto == 0 || dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Seleccione un producto de la lista antes de eliminar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string nombreProducto = dgvProductos.SelectedRows[0].Cells[1].Value?.ToString() ?? "";

                DialogResult resultado = MessageBox.Show(
                    "¿Desea eliminar el producto: " + nombreProducto + "?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarProducto", cn.AbrirConexion());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", IdProducto);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Producto eliminado correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    log.RegistrarLog(
                        "PRODUCTO_DELETE",
                        SesionUsuario.Usuario,
                        "Producto eliminado: " + nombreProducto);

                    MostrarProductos();
                    IdProducto = 0;
                    cn.CerrarConexion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // BOTON BUSCAR
        // ─────────────────────────────────────────

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_BuscarProducto", cn.AbrirConexion());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Texto", txtBuscar.Text);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProductos.DataSource = dt;
                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // BOTON EXPORTAR EXCEL
        // ─────────────────────────────────────────

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarExcel.Exportar(dgvProductos, "Reporte_Productos");
        }
    }
}
