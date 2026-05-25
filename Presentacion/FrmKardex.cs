// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Sistema_Inventario.Logica;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO DEL KARDEX DEL SISTEMA
    public partial class FrmKardex : Form
    {
        // OBJETO DE LA CAPA LOGICA KARDEX
        LKardex lKardex = new LKardex();

        // CONSTRUCTOR DEL FORMULARIO
        public FrmKardex()
        {
            InitializeComponent();
            AplicarEstilos();
        }

        // APLICA ESTILOS A BOTONES Y GRILLA
        private void AplicarEstilos()
        {
            ConfigurarBoton(btnBuscar,   Color.FromArgb(52,  152, 219));
            ConfigurarBoton(btnRecargar, Color.FromArgb(46,  204, 113));
            ConfigurarBoton(btnExportar, Color.FromArgb(39,  174,  96));
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
            btn.Padding                   = new Padding(10, 0, 0, 0);
            btn.Cursor                    = Cursors.Hand;

            btn.MouseEnter += (s, e) => { btn.BackColor = ControlPaint.Dark(color); };
            btn.MouseLeave += (s, e) => { btn.BackColor = color; };
        }

        // ─────────────────────────────────────────
        // CONFIGURA EL ESTILO DE LA GRILLA
        // ─────────────────────────────────────────
        private void ConfigurarGrid()
        {
            dgvKardex.EnableHeadersVisualStyles = false;
            dgvKardex.BorderStyle               = BorderStyle.None;
            dgvKardex.CellBorderStyle           = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvKardex.BackgroundColor           = Color.White;
            dgvKardex.RowHeadersVisible         = false;
            dgvKardex.SelectionMode             = DataGridViewSelectionMode.FullRowSelect;
            dgvKardex.MultiSelect               = false;
            dgvKardex.AllowUserToAddRows        = false;
            dgvKardex.AllowUserToResizeRows     = false;
            dgvKardex.AutoSizeColumnsMode       = DataGridViewAutoSizeColumnsMode.None;
            dgvKardex.GridColor                 = Color.LightGray;

            // CABECERA
            dgvKardex.ColumnHeadersBorderStyle                  = DataGridViewHeaderBorderStyle.None;
            dgvKardex.ColumnHeadersDefaultCellStyle.BackColor   = Color.FromArgb(11, 31, 58);
            dgvKardex.ColumnHeadersDefaultCellStyle.ForeColor   = Color.White;
            dgvKardex.ColumnHeadersDefaultCellStyle.Font        = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvKardex.ColumnHeadersHeight                       = 45;

            // FILAS
            dgvKardex.DefaultCellStyle.Font                 = new Font("Segoe UI", 10);
            dgvKardex.DefaultCellStyle.Padding              = new Padding(4);
            dgvKardex.DefaultCellStyle.SelectionBackColor   = Color.FromArgb(52, 152, 219);
            dgvKardex.DefaultCellStyle.SelectionForeColor   = Color.White;
            dgvKardex.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
            dgvKardex.RowTemplate.Height                    = 38;
        }

        // ─────────────────────────────────────────
        // CARGA INICIAL
        // ─────────────────────────────────────────

        private void FrmKardex_Load(object sender, EventArgs e)
        {
            CargarProductos();
            MostrarKardex();
        }

        // CARGA LOS PRODUCTOS EN EL COMBOBOX
        private void CargarProductos()
        {
            try
            {
                cboProducto.DataSource    = lKardex.MostrarProductos();
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
        // MOSTRAR KARDEX COMPLETO
        // ─────────────────────────────────────────

        private void MostrarKardex()
        {
            try
            {
                dgvKardex.DataSource = lKardex.MostrarKardex();
                FormatearColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // FORMATEAR COLUMNAS (anchos y alineaciones)
        // ─────────────────────────────────────────
        private void FormatearColumnas()
        {
            if (dgvKardex.Columns.Count == 0) return;

            // ANCHOS
            dgvKardex.Columns["IdMovimiento"].Width   = 80;
            dgvKardex.Columns["TipoMovimiento"].Width = 150;
            dgvKardex.Columns["Producto"].Width       = 230;
            dgvKardex.Columns["Bodega"].Width         = 200;
            dgvKardex.Columns["Cantidad"].Width       = 90;
            dgvKardex.Columns["Fecha"].Width          = 170;
            dgvKardex.Columns["Observacion"].Width    = 250;
            dgvKardex.Columns["UsuarioRegistro"].Width = 160;

            // ALINEACIONES
            dgvKardex.Columns["IdMovimiento"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dgvKardex.Columns["Cantidad"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dgvKardex.Columns["Fecha"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            // SIN WRAP EN OBSERVACION
            dgvKardex.Columns["Observacion"].DefaultCellStyle.WrapMode =
                DataGridViewTriState.False;

            // ENCABEZADOS PERSONALIZADOS
            dgvKardex.Columns["IdMovimiento"].HeaderText   = "ID";
            dgvKardex.Columns["TipoMovimiento"].HeaderText = "Tipo Movimiento";
            dgvKardex.Columns["UsuarioRegistro"].HeaderText = "Usuario Registro";
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

                dgvKardex.DataSource = lKardex.FiltrarProducto(
                    Convert.ToInt32(cboProducto.SelectedValue));

                FormatearColumnas();
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
            MostrarKardex();
            cboProducto.SelectedIndex = -1;
        }

        // ─────────────────────────────────────────
        // BOTON EXPORTAR EXCEL
        // ─────────────────────────────────────────

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvKardex.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No hay datos para exportar.",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                ExportarExcel.Exportar(dgvKardex, "Reporte_Kardex");

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

        private void dgvKardex_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
