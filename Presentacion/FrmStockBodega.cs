// IMPORTACION DE LA CAPA LOGICA DEL SISTEMA
using Sistema_Inventario.Logica;

// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO ENCARGADO DE MOSTRAR EL STOCK POR BODEGA
    public partial class FrmStockBodega : Form
    {
        // OBJETO DE LA CAPA LOGICA PARA EL MANEJO DEL STOCK
        LStockBodega lStock = new LStockBodega();

        // CONSTRUCTOR DEL FORMULARIO
        public FrmStockBodega()
        {
            InitializeComponent();
            AplicarEstilos();
            ConfigurarGrid();
        }

        // ─────────────────────────────────────────
        // ESTILOS
        // ─────────────────────────────────────────

        private void AplicarEstilos()
        {
            ConfigurarBoton(btnBuscar,    Color.FromArgb(52,  152, 219));
            ConfigurarBoton(btnRecargar,  Color.FromArgb(46,  204, 113));
            ConfigurarBoton(btnStockBajo, Color.FromArgb(231,  76,  60));
            ConfigurarBoton(btnExportar,  Color.FromArgb(39,  174,  96));
        }

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
            btn.Cursor                    = Cursors.Hand;

            btn.MouseEnter += (s, e) => { btn.BackColor = ControlPaint.Dark(color); };
            btn.MouseLeave += (s, e) => { btn.BackColor = color; };
        }

        // ─────────────────────────────────────────
        // CONFIGURAR GRID
        // ─────────────────────────────────────────

        private void ConfigurarGrid()
        {
            dgvStock.EnableHeadersVisualStyles = false;
            dgvStock.BorderStyle               = BorderStyle.None;
            dgvStock.CellBorderStyle           = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvStock.BackgroundColor           = Color.White;
            dgvStock.RowHeadersVisible         = false;
            dgvStock.SelectionMode             = DataGridViewSelectionMode.FullRowSelect;
            dgvStock.MultiSelect               = false;
            dgvStock.AllowUserToAddRows        = false;
            dgvStock.AllowUserToResizeRows     = false;
            dgvStock.AutoSizeColumnsMode       = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStock.GridColor                 = Color.LightGray;

            dgvStock.ColumnHeadersBorderStyle                = DataGridViewHeaderBorderStyle.None;
            dgvStock.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(11, 31, 58);
            dgvStock.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvStock.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvStock.ColumnHeadersHeight                     = 45;

            dgvStock.DefaultCellStyle.Font               = new Font("Segoe UI", 10);
            dgvStock.DefaultCellStyle.Padding            = new Padding(4);
            dgvStock.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvStock.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvStock.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
            dgvStock.RowTemplate.Height = 38;
        }

        // ─────────────────────────────────────────
        // CARGA INICIAL
        // ─────────────────────────────────────────

        private void FrmStockBodega_Load(object sender, EventArgs e)
        {
            CargarProductos();
            MostrarStock();
            PintarStockBajo();
        }

        // ─────────────────────────────────────────
        // CARGAR PRODUCTOS EN COMBOBOX
        // ─────────────────────────────────────────

        private void CargarProductos()
        {
            try
            {
                cboProducto.DataSource    = lStock.MostrarProductos();
                cboProducto.DisplayMember = "Nombre";
                cboProducto.ValueMember   = "IdProducto";
                cboProducto.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // MOSTRAR TODO EL STOCK
        // ─────────────────────────────────────────

        private void MostrarStock()
        {
            dgvStock.DataSource = lStock.MostrarStock();
        }

        // ─────────────────────────────────────────
        // PINTAR FILAS CON STOCK BAJO
        // ─────────────────────────────────────────

        private void PintarStockBajo()
        {
            foreach (DataGridViewRow fila in dgvStock.Rows)
            {
                decimal stock = Convert.ToDecimal(fila.Cells["StockActual"].Value);

                if (stock <= 5)
                {
                    fila.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 238);
                    fila.DefaultCellStyle.ForeColor = Color.DarkRed;
                }
            }
        }

        // ─────────────────────────────────────────
        // BOTON FILTRAR
        // ─────────────────────────────────────────

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboProducto.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "Seleccione un producto para filtrar.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                dgvStock.DataSource = lStock.FiltrarPorProducto(
                    Convert.ToInt32(cboProducto.SelectedValue));

                PintarStockBajo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // BOTON MOSTRAR TODO
        // ─────────────────────────────────────────

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            MostrarStock();
            PintarStockBajo();
            cboProducto.SelectedIndex = -1;
        }

        // ─────────────────────────────────────────
        // BOTON STOCK BAJO
        // ─────────────────────────────────────────

        private void btnStockBajo_Click(object sender, EventArgs e)
        {
            dgvStock.DataSource = lStock.MostrarStockBajo();
            PintarStockBajo();
        }

        // ─────────────────────────────────────────
        // BOTON EXPORTAR EXCEL
        // ─────────────────────────────────────────

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvStock.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No hay datos para exportar.",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                ExportarExcel.Exportar(dgvStock, "Reporte_Stock");

                MessageBox.Show(
                    "Reporte exportado correctamente.",
                    "Exportación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
