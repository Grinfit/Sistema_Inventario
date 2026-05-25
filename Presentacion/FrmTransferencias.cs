// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Sistema_Inventario.Utilidades;
using Sistema_Inventario.Logica;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO ENCARGADO DE LAS TRANSFERENCIAS ENTRE BODEGAS
    public partial class FrmTransferencias : Form
    {
        // OBJETO DE LA CAPA LOGICA DE TRANSFERENCIAS
        LTransferencias lTransferencias = new LTransferencias();

        // TABLA COMPLETA PARA FILTRADO EN CLIENTE
        private DataTable _tablaCompleta;

        // CONSTRUCTOR DEL FORMULARIO
        public FrmTransferencias()
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
            ConfigurarBoton(btnNuevo,    Color.FromArgb(52,  152, 219));
            ConfigurarBoton(btnFiltrar,  Color.FromArgb(52,  152, 219));
            ConfigurarBoton(btnRecargar, Color.FromArgb(46,  204, 113));
            ConfigurarBoton(btnExportar, Color.FromArgb(39,  174,  96));
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
            dgvTransferencias.EnableHeadersVisualStyles = false;
            dgvTransferencias.BorderStyle               = BorderStyle.None;
            dgvTransferencias.CellBorderStyle           = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTransferencias.BackgroundColor           = Color.White;
            dgvTransferencias.RowHeadersVisible         = false;
            dgvTransferencias.SelectionMode             = DataGridViewSelectionMode.FullRowSelect;
            dgvTransferencias.MultiSelect               = false;
            dgvTransferencias.AllowUserToAddRows        = false;
            dgvTransferencias.AllowUserToResizeRows     = false;
            dgvTransferencias.AutoSizeColumnsMode       = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransferencias.GridColor                 = Color.LightGray;

            dgvTransferencias.ColumnHeadersBorderStyle                = DataGridViewHeaderBorderStyle.None;
            dgvTransferencias.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(11, 31, 58);
            dgvTransferencias.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTransferencias.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvTransferencias.ColumnHeadersHeight                     = 45;

            dgvTransferencias.DefaultCellStyle.Font               = new Font("Segoe UI", 10);
            dgvTransferencias.DefaultCellStyle.Padding            = new Padding(4);
            dgvTransferencias.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvTransferencias.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvTransferencias.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
            dgvTransferencias.RowTemplate.Height = 38;
        }

        // ─────────────────────────────────────────
        // CARGA INICIAL
        // ─────────────────────────────────────────

        private void FrmTransferencias_Load(object sender, EventArgs e)
        {
            MostrarTransferencias();
        }

        // ─────────────────────────────────────────
        // MOSTRAR TRANSFERENCIAS
        // ─────────────────────────────────────────

        private void MostrarTransferencias()
        {
            _tablaCompleta                = lTransferencias.MostrarTransferencias();
            dgvTransferencias.DataSource  = _tablaCompleta;
            txtBuscar.Clear();
        }

        // ─────────────────────────────────────────
        // BOTON NUEVA TRANSFERENCIA
        // ─────────────────────────────────────────

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (var modal = new FrmTransferenciaModal())
            {
                if (modal.ShowDialog(this) == DialogResult.OK)
                    MostrarTransferencias();
            }
        }

        // ─────────────────────────────────────────
        // BOTON FILTRAR
        // ─────────────────────────────────────────

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(texto))
            {
                dgvTransferencias.DataSource = _tablaCompleta;
                return;
            }

            if (_tablaCompleta == null) return;

            var filas = _tablaCompleta.AsEnumerable().Where(r =>
                (r["Producto"]        .ToString().ToLower().Contains(texto)) ||
                (r["BodegaOrigen"]    .ToString().ToLower().Contains(texto)) ||
                (r["BodegaDestino"]   .ToString().ToLower().Contains(texto)) ||
                (r["Observacion"]     .ToString().ToLower().Contains(texto))
            );

            dgvTransferencias.DataSource = filas.Any()
                ? filas.CopyToDataTable()
                : _tablaCompleta.Clone();
        }

        // ─────────────────────────────────────────
        // BOTON RECARGAR
        // ─────────────────────────────────────────

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            MostrarTransferencias();
        }

        // ─────────────────────────────────────────
        // BOTON EXPORTAR EXCEL
        // ─────────────────────────────────────────

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTransferencias.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No hay datos para exportar.",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                ExportarExcel.Exportar(
                    dgvTransferencias,
                    "Reporte_Transferencias");

                MessageBox.Show(
                    "Reporte exportado correctamente.",
                    "Exportación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
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
    }
}
