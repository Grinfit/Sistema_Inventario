// IMPORTACION DE LIBRERIAS NECESARIAS
using Sistema_Inventario.Logica;
using Sistema_Inventario.Utilidades;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO PRINCIPAL DE MOVIMIENTOS DE INVENTARIO
    public partial class FrmMovimientosInventario : Form
    {
        // CAPA LOGICA
        LMovimientosInventario lMovimientos = new LMovimientosInventario();

        // TABLA PARA FILTRADO LOCAL
        DataTable tablaMovimientos;

        // TEXTO PLACEHOLDER DE BUSQUEDA
        const string PLACEHOLDER = "  🔍  Buscar movimiento...";

        // CONSTRUCTOR
        public FrmMovimientosInventario()
        {
            InitializeComponent();
        }

        // ─────────────────────────────────────────
        // LOAD
        // ─────────────────────────────────────────
        private void FrmMovimientosInventario_Load(object sender, EventArgs e)
        {
            ActualizarInfoHeader();
            MostrarMovimientos();
            IniciarPlaceholder();
            timer1.Start();
        }

        // ─────────────────────────────────────────
        // HEADER — fecha/hora y usuario
        // ─────────────────────────────────────────
        private void ActualizarInfoHeader()
        {
            CultureInfo cultura = new CultureInfo("es-PE");

            lblFechaHora.Text = DateTime.Now.ToString(
                "dddd, dd 'de' MMMM 'de' yyyy  •  HH:mm:ss",
                cultura);

            lblUsuarioInfo.Text =
                $"◉  {SesionUsuario.Usuario}     |     {SesionUsuario.Rol}";
        }

        // TICK DEL RELOJ — actualiza cada segundo
        private void timer1_Tick(object sender, EventArgs e)
        {
            CultureInfo cultura = new CultureInfo("es-PE");
            lblFechaHora.Text = DateTime.Now.ToString(
                "dddd, dd 'de' MMMM 'de' yyyy  •  HH:mm:ss",
                cultura);
        }

        // ─────────────────────────────────────────
        // GRID — carga y formato
        // ─────────────────────────────────────────
        private void MostrarMovimientos()
        {
            tablaMovimientos = lMovimientos.MostrarMovimientos();

            dgvMovimientos.DataSource = tablaMovimientos;

            FormatearColumnas();
        }

        private void FormatearColumnas()
        {
            if (dgvMovimientos.Columns.Count == 0)
                return;

            try
            {
                // HEADERS LEGIBLES
                dgvMovimientos.Columns["IdMovimiento"].HeaderText    = "ID";
                dgvMovimientos.Columns["TipoMovimiento"].HeaderText  = "Tipo Movimiento";
                dgvMovimientos.Columns["UsuarioRegistro"].HeaderText = "Usuario Registro";

                // PESOS PROPORCIONALES DE COLUMNAS (Fill mode)
                dgvMovimientos.Columns["IdMovimiento"].FillWeight    = 50;
                dgvMovimientos.Columns["TipoMovimiento"].FillWeight  = 110;
                dgvMovimientos.Columns["Producto"].FillWeight        = 200;
                dgvMovimientos.Columns["Bodega"].FillWeight          = 130;
                dgvMovimientos.Columns["Cantidad"].FillWeight        = 70;
                dgvMovimientos.Columns["Fecha"].FillWeight           = 140;
                dgvMovimientos.Columns["Observacion"].FillWeight     = 190;
                dgvMovimientos.Columns["UsuarioRegistro"].FillWeight = 110;

                // ALINEACIONES
                dgvMovimientos.Columns["IdMovimiento"]
                    .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvMovimientos.Columns["Cantidad"]
                    .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvMovimientos.Columns["Fecha"]
                    .DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvMovimientos.Columns["Observacion"]
                    .DefaultCellStyle.WrapMode =
                    DataGridViewTriState.False;
            }
            catch { }
        }

        // ─────────────────────────────────────────
        // BÚSQUEDA Y FILTRADO
        // ─────────────────────────────────────────
        private void IniciarPlaceholder()
        {
            txtBuscar.Text      = PLACEHOLDER;
            txtBuscar.ForeColor = Color.FromArgb(150, 150, 160);
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == PLACEHOLDER)
            {
                txtBuscar.Text      = "";
                txtBuscar.ForeColor = Color.FromArgb(30, 30, 40);
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                FiltrarMovimientos("");
                IniciarPlaceholder();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // IGNORA CAMBIOS CAUSADOS POR EL PLACEHOLDER
            if (txtBuscar.Text == PLACEHOLDER)
                return;

            FiltrarMovimientos(txtBuscar.Text.Trim());
        }

        private void FiltrarMovimientos(string texto)
        {
            if (tablaMovimientos == null)
                return;

            if (string.IsNullOrWhiteSpace(texto))
            {
                tablaMovimientos.DefaultView.RowFilter = "";
                return;
            }

            // ESCAPA COMILLAS SIMPLES PARA EVITAR INYECCION
            string filtro = texto.Replace("'", "''");

            tablaMovimientos.DefaultView.RowFilter =
                $"TipoMovimiento LIKE '%{filtro}%' OR " +
                $"Producto LIKE '%{filtro}%' OR " +
                $"Bodega LIKE '%{filtro}%' OR " +
                $"Observacion LIKE '%{filtro}%' OR " +
                $"UsuarioRegistro LIKE '%{filtro}%'";
        }

        // ─────────────────────────────────────────
        // NUEVO MOVIMIENTO — abre modal
        // ─────────────────────────────────────────
        private void btnNuevoMovimiento_Click(object sender, EventArgs e)
        {
            using (var modal = new FrmMovimientoModal())
            {
                if (modal.ShowDialog(this) == DialogResult.OK)
                {
                    // REFRESCA EL GRID TRAS REGISTRO EXITOSO
                    MostrarMovimientos();
                }
            }
        }

        // ─────────────────────────────────────────
        // EXPORTAR EXCEL
        // ─────────────────────────────────────────
        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMovimientos.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No hay datos para exportar.",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                ExportarExcel.Exportar(
                    dgvMovimientos,
                    "Reporte_Movimientos");

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
