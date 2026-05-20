using System;
using System.Drawing;
using System.Windows.Forms;
using Sistema_Inventario.Utilidades;
using Sistema_Inventario.Datos;
using Sistema_Inventario.Logica;

namespace Sistema_Inventario.Presentacion
{
    public partial class FrmKardex : Form
    {
        LKardex lKardex =
            new LKardex();

        public FrmKardex()
        {
            InitializeComponent();

            ConfigurarGrid();
        }

        // =====================================
        // LOAD
        // =====================================

        private void FrmKardex_Load(
            object sender,
            EventArgs e)
        {
            CargarProductos();

            MostrarKardex();
        }

        // =====================================
        // CONFIGURAR GRID
        // =====================================

        private void ConfigurarGrid()
        {
            // ===============================
            // CONFIG GENERAL
            // ===============================

            dgvKardex.EnableHeadersVisualStyles =
                false;

            dgvKardex.BorderStyle =
                BorderStyle.None;

            dgvKardex.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvKardex.BackgroundColor =
                Color.White;

            dgvKardex.RowHeadersVisible =
                false;

            dgvKardex.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvKardex.MultiSelect =
                false;

            dgvKardex.AllowUserToAddRows =
                false;

            dgvKardex.AllowUserToResizeRows =
                false;

            dgvKardex.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.None;

            dgvKardex.GridColor =
                Color.LightGray;

            // ===============================
            // HEADER
            // ===============================

            dgvKardex.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvKardex.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(11, 31, 58);

            dgvKardex.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvKardex.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold);

            dgvKardex.ColumnHeadersHeight =
                45;

            // ===============================
            // FILAS
            // ===============================

            dgvKardex.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10);

            dgvKardex.DefaultCellStyle.Padding =
                new Padding(3);

            dgvKardex.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(52, 152, 219);

            dgvKardex.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvKardex.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 247, 250);

            dgvKardex.RowTemplate.Height =
                35;
        }

        // =====================================
        // PRODUCTOS
        // =====================================

        private void CargarProductos()
        {
            try
            {
                cboProducto.DataSource =
                    lKardex.MostrarProductos();

                cboProducto.DisplayMember =
                    "Nombre";

                cboProducto.ValueMember =
                    "IdProducto";

                cboProducto.SelectedIndex = -1;
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

        // =====================================
        // MOSTRAR
        // =====================================

        private void MostrarKardex()
        {
            try
            {
                dgvKardex.DataSource =
                    lKardex.MostrarKardex();

                FormatearColumnas();
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

        // =====================================
        // FORMATEAR COLUMNAS
        // =====================================

        private void FormatearColumnas()
        {
            if (dgvKardex.Columns.Count == 0)
                return;

            dgvKardex.Columns["IdMovimiento"].Width = 90;

            dgvKardex.Columns["TipoMovimiento"].Width = 150;

            dgvKardex.Columns["Producto"].Width = 230;

            dgvKardex.Columns["Bodega"].Width = 200;

            dgvKardex.Columns["Cantidad"].Width = 90;

            dgvKardex.Columns["Fecha"].Width = 170;

            dgvKardex.Columns["Observacion"].Width = 250;

            dgvKardex.Columns["UsuarioRegistro"].Width = 160;

            // ===============================
            // ALIGNMENTS
            // ===============================

            dgvKardex.Columns["IdMovimiento"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvKardex.Columns["Cantidad"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvKardex.Columns["Fecha"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            // ===============================
            // WRAP
            // ===============================

            dgvKardex.Columns["Observacion"]
                .DefaultCellStyle.WrapMode =
                DataGridViewTriState.False;

            // ===============================
            // HEADERS
            // ===============================

            dgvKardex.Columns["IdMovimiento"].HeaderText =
                "ID";

            dgvKardex.Columns["TipoMovimiento"].HeaderText =
                "Tipo Movimiento";

            dgvKardex.Columns["UsuarioRegistro"].HeaderText =
                "Usuario Registro";
        }

        // =====================================
        // FILTRAR
        // =====================================

        private void btnBuscar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (cboProducto.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "Seleccione un producto",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                dgvKardex.DataSource =
                    lKardex.FiltrarProducto(
                        Convert.ToInt32(
                            cboProducto.SelectedValue));

                FormatearColumnas();
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

        // =====================================
        // RECARGAR
        // =====================================

        private void btnRecargar_Click(
            object sender,
            EventArgs e)
        {
            MostrarKardex();

            cboProducto.SelectedIndex = -1;
        }

        // =====================================
        // EXPORTAR
        // =====================================

        private void btnExportar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (dgvKardex.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No hay datos para exportar",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                ExportarExcel.Exportar(
                    dgvKardex,
                    "Reporte_Kardex");

                MessageBox.Show(
                    "Reporte exportado correctamente",
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