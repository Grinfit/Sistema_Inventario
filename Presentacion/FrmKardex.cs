// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Drawing;
using System.Windows.Forms;
using Sistema_Inventario.Utilidades;
using Sistema_Inventario.Datos;
using Sistema_Inventario.Logica;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO DEL KARDEX DEL SISTEMA
    public partial class FrmKardex : Form
    {
        // OBJETO DE LA CAPA LOGICA KARDEX
        LKardex lKardex =
            new LKardex();

        // CONSTRUCTOR DEL FORMULARIO
        public FrmKardex()
        {
            InitializeComponent();

            // CONFIGURA EL GRID
            ConfigurarGrid();
        }

        // LOAD

        private void FrmKardex_Load(
            object sender,
            EventArgs e)
        {
            // CARGA LOS PRODUCTOS
            CargarProductos();

            // MUESTRA EL KARDEX
            MostrarKardex();
        }

        // CONFIGURAR GRID

        private void ConfigurarGrid()
        {
            // CONFIG GENERAL

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

            // HEADER

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

            // FILAS

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

        // PRODUCTOS

        private void CargarProductos()
        {
            try
            {
                // ASIGNA LOS PRODUCTOS AL COMBOBOX
                cboProducto.DataSource =
                    lKardex.MostrarProductos();

                // MUESTRA EL NOMBRE DEL PRODUCTO
                cboProducto.DisplayMember =
                    "Nombre";

                // ASIGNA EL ID DEL PRODUCTO
                cboProducto.ValueMember =
                    "IdProducto";

                // DEJA EL COMBOBOX VACIO
                cboProducto.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                // MUESTRA EL ERROR
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // MOSTRAR

        private void MostrarKardex()
        {
            try
            {
                // MUESTRA LOS DATOS DEL KARDEX
                dgvKardex.DataSource =
                    lKardex.MostrarKardex();

                // FORMATEA LAS COLUMNAS
                FormatearColumnas();
            }
            catch (Exception ex)
            {
                // MUESTRA EL ERROR
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // FORMATEAR COLUMNAS

        private void FormatearColumnas()
        {
            // VALIDA SI EXISTEN COLUMNAS
            if (dgvKardex.Columns.Count == 0)
                return;

            // ANCHO DE COLUMNAS
            dgvKardex.Columns["IdMovimiento"].Width = 90;

            dgvKardex.Columns["TipoMovimiento"].Width = 150;

            dgvKardex.Columns["Producto"].Width = 230;

            dgvKardex.Columns["Bodega"].Width = 200;

            dgvKardex.Columns["Cantidad"].Width = 90;

            dgvKardex.Columns["Fecha"].Width = 170;

            dgvKardex.Columns["Observacion"].Width = 250;

            dgvKardex.Columns["UsuarioRegistro"].Width = 160;

            // ALIGNMENTS

            dgvKardex.Columns["IdMovimiento"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvKardex.Columns["Cantidad"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvKardex.Columns["Fecha"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            // WRAP

            dgvKardex.Columns["Observacion"]
                .DefaultCellStyle.WrapMode =
                DataGridViewTriState.False;

            // HEADERS

            dgvKardex.Columns["IdMovimiento"].HeaderText =
                "ID";

            dgvKardex.Columns["TipoMovimiento"].HeaderText =
                "Tipo Movimiento";

            dgvKardex.Columns["UsuarioRegistro"].HeaderText =
                "Usuario Registro";
        }

        // FILTRAR

        private void btnBuscar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                // VALIDA SI SELECCIONO UN PRODUCTO
                if (cboProducto.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "Seleccione un producto",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // FILTRA EL KARDEX
                dgvKardex.DataSource =
                    lKardex.FiltrarProducto(
                        Convert.ToInt32(
                            cboProducto.SelectedValue));

                // FORMATEA LAS COLUMNAS
                FormatearColumnas();
            }
            catch (Exception ex)
            {
                // MUESTRA EL ERROR
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // RECARGAR

        private void btnRecargar_Click(
            object sender,
            EventArgs e)
        {
            // MUESTRA EL KARDEX COMPLETO
            MostrarKardex();

            // LIMPIA EL COMBOBOX
            cboProducto.SelectedIndex = -1;
        }

        // EXPORTAR

        private void btnExportar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                // VALIDA SI HAY DATOS
                if (dgvKardex.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No hay datos para exportar",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                // EXPORTA EL REPORTE A EXCEL
                ExportarExcel.Exportar(
                    dgvKardex,
                    "Reporte_Kardex");

                // MENSAJE DE CONFIRMACION
                MessageBox.Show(
                    "Reporte exportado correctamente",
                    "Exportación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // MUESTRA EL ERROR
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}