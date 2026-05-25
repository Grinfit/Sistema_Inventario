// IMPORTACION DE LIBRERIAS NECESARIAS
using Sistema_Inventario.Logica;
using System;
using System.Drawing;
using System.Windows.Forms;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO DE MOVIMIENTOS DE INVENTARIO
    public partial class FrmMovimientosInventario : Form
    {
        // OBJETO DE LA CAPA LOGICA
        LMovimientosInventario lMovimientos =
            new LMovimientosInventario();

        // CONSTRUCTOR DEL FORMULARIO
        public FrmMovimientosInventario()
        {
            InitializeComponent();

            // CONFIGURA EL GRID
            ConfigurarGrid();
        }

        // LOAD

        private void FrmMovimientosInventario_Load(
            object sender,
            EventArgs e)
        {
            // CARGA TIPOS DE MOVIMIENTO
            CargarTiposMovimiento();

            // CARGA PRODUCTOS
            CargarProductos();

            // CARGA BODEGAS
            CargarBodegas();

            // MUESTRA LOS MOVIMIENTOS
            MostrarMovimientos();
        }

        // CONFIG GRID

        private void ConfigurarGrid()
        {
            // CONFIG GENERAL

            dgvMovimientos.EnableHeadersVisualStyles =
                false;

            dgvMovimientos.BorderStyle =
                BorderStyle.None;

            dgvMovimientos.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvMovimientos.BackgroundColor =
                Color.White;

            dgvMovimientos.RowHeadersVisible =
                false;

            dgvMovimientos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvMovimientos.MultiSelect =
                false;

            dgvMovimientos.AllowUserToAddRows =
                false;

            dgvMovimientos.AllowUserToResizeRows =
                false;

            dgvMovimientos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvMovimientos.GridColor =
                Color.LightGray;

            // HEADER

            dgvMovimientos.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvMovimientos.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(11, 31, 58);

            dgvMovimientos.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvMovimientos.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold);

            dgvMovimientos.ColumnHeadersHeight =
                45;

            // FILAS

            dgvMovimientos.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10);

            dgvMovimientos.DefaultCellStyle.Padding =
                new Padding(3);

            dgvMovimientos.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(52, 152, 219);

            dgvMovimientos.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvMovimientos.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 247, 250);

            dgvMovimientos.RowTemplate.Height =
                35;
        }

        // COMBOS

        private void CargarTiposMovimiento()
        {
            // ASIGNA DATOS AL COMBOBOX
            cboTipoMovimiento.DataSource =
                lMovimientos.MostrarTiposMovimiento();

            // MUESTRA EL NOMBRE
            cboTipoMovimiento.DisplayMember =
                "Nombre";

            // ASIGNA EL ID
            cboTipoMovimiento.ValueMember =
                "IdTipoMovimiento";

            // SELECCIONA EL PRIMER ITEM
            cboTipoMovimiento.SelectedIndex = 0;
        }

        private void CargarProductos()
        {
            // ASIGNA DATOS AL COMBOBOX
            cboProducto.DataSource =
                lMovimientos.MostrarProductos();

            // MUESTRA EL NOMBRE
            cboProducto.DisplayMember =
                "Nombre";

            // ASIGNA EL ID
            cboProducto.ValueMember =
                "IdProducto";

            // SELECCIONA EL PRIMER ITEM
            cboProducto.SelectedIndex = 0;
        }

        private void CargarBodegas()
        {
            // ASIGNA DATOS AL COMBOBOX
            cboBodega.DataSource =
                lMovimientos.MostrarBodegas();

            // MUESTRA EL NOMBRE
            cboBodega.DisplayMember =
                "Nombre";

            // ASIGNA EL ID
            cboBodega.ValueMember =
                "IdBodega";

            // SELECCIONA EL PRIMER ITEM
            cboBodega.SelectedIndex = 0;
        }

        // GRID

        private void MostrarMovimientos()
        {
            // MUESTRA LOS MOVIMIENTOS
            dgvMovimientos.DataSource =
                lMovimientos.MostrarMovimientos();

            // FORMATEA LAS COLUMNAS
            FormatearColumnas();
        }

        // FORMATEAR COLUMNAS

        private void FormatearColumnas()
        {
            // VALIDA SI EXISTEN COLUMNAS
            if (dgvMovimientos.Columns.Count == 0)
                return;

            try
            {
                // ANCHO DE COLUMNAS
                dgvMovimientos.Columns["IdMovimiento"].Width = 90;

                dgvMovimientos.Columns["TipoMovimiento"].Width = 150;

                dgvMovimientos.Columns["Producto"].Width = 220;

                dgvMovimientos.Columns["Bodega"].Width = 180;

                dgvMovimientos.Columns["Cantidad"].Width = 90;

                dgvMovimientos.Columns["Fecha"].Width = 170;

                dgvMovimientos.Columns["Observacion"].Width = 250;

                dgvMovimientos.Columns["UsuarioRegistro"].Width = 160;

                // HEADERS

                dgvMovimientos.Columns["IdMovimiento"].HeaderText =
                    "ID";

                dgvMovimientos.Columns["TipoMovimiento"].HeaderText =
                    "Tipo Movimiento";

                dgvMovimientos.Columns["UsuarioRegistro"].HeaderText =
                    "Usuario Registro";

                // ALIGNMENTS

                dgvMovimientos.Columns["IdMovimiento"]
                    .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvMovimientos.Columns["Cantidad"]
                    .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvMovimientos.Columns["Fecha"]
                    .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                // WRAP

                dgvMovimientos.Columns["Observacion"]
                    .DefaultCellStyle.WrapMode =
                    DataGridViewTriState.False;
            }
            catch
            {

            }
        }

        // LIMPIAR

        private void LimpiarCampos()
        {
            // LIMPIA LA CANTIDAD
            txtCantidad.Clear();

            // LIMPIA LA OBSERVACION
            txtObservacion.Clear();

            // RESETEA LOS COMBOS
            cboTipoMovimiento.SelectedIndex = 0;

            cboProducto.SelectedIndex = 0;

            cboBodega.SelectedIndex = 0;

            // ENVIA EL FOCO
            txtCantidad.Focus();
        }

        // VALIDAR

        private bool ValidarCampos()
        {
            // CANTIDAD VACIA

            if (txtCantidad.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese la cantidad",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCantidad.Focus();

                return false;
            }

            // NUMERO VALIDO

            if (!decimal.TryParse(
                txtCantidad.Text,
                out decimal cantidad))
            {
                MessageBox.Show(
                    "Ingrese una cantidad válida",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCantidad.Focus();

                return false;
            }

            // MAYOR A 0

            if (cantidad <= 0)
            {
                MessageBox.Show(
                    "La cantidad debe ser mayor a cero",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCantidad.Focus();

                return false;
            }

            // OBSERVACION

            if (txtObservacion.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese una observación",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtObservacion.Focus();

                return false;
            }

            // LONGITUD OBSERVACION

            if (txtObservacion.Text.Length < 5)
            {
                MessageBox.Show(
                    "La observación es demasiado corta",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtObservacion.Focus();

                return false;
            }

            return true;
        }

        // GUARDAR

        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                // VALIDACIONES

                if (!ValidarCampos())
                    return;

                decimal cantidad =
                    Convert.ToDecimal(
                        txtCantidad.Text);

                string tipoMovimiento =
                    cboTipoMovimiento.Text
                    .ToUpper()
                    .Trim();

                // VALIDAR SALIDAS

                if (tipoMovimiento == "SALIDA")
                {
                    decimal stockActual =
                        lMovimientos.ObtenerStockActual(
                            Convert.ToInt32(
                                cboProducto.SelectedValue),

                            Convert.ToInt32(
                                cboBodega.SelectedValue));

                    if (cantidad > stockActual)
                    {
                        MessageBox.Show(
                            $"Stock insuficiente.\n\nStock actual: {stockActual}",
                            "Validación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }
                }

                // REGISTRAR MOVIMIENTO

                lMovimientos.RegistrarMovimiento(
                    Convert.ToInt32(
                        cboTipoMovimiento.SelectedValue),

                    Convert.ToInt32(
                        cboProducto.SelectedValue),

                    Convert.ToInt32(
                        cboBodega.SelectedValue),

                    cantidad,

                    txtObservacion.Text.Trim(),

                    SesionUsuario.Usuario);

                MessageBox.Show(
                    "Movimiento registrado correctamente",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // ACTUALIZA EL GRID
                MostrarMovimientos();

                // LIMPIA LOS CAMPOS
                LimpiarCampos();
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

        // NUEVO

        private void btnNuevo_Click(
            object sender,
            EventArgs e)
        {
            // LIMPIA LOS CAMPOS
            LimpiarCampos();
        }

        // EXPORTAR

        private void btnExportar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                // VALIDA SI EXISTEN DATOS
                if (dgvMovimientos.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No hay datos para exportar",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                // EXPORTA EL REPORTE
                ExportarExcel.Exportar(
                    dgvMovimientos,
                    "Reporte_Movimientos");

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

        // SOLO NUMEROS

        private void txtCantidad_KeyPress(
            object sender,
            KeyPressEventArgs e)
        {
            // VALIDA SI ES NUMERO O PUNTO
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // EVITA DOS PUNTOS
            if (e.KeyChar == '.' &&
                txtCantidad.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}