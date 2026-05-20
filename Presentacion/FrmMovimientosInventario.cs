using Sistema_Inventario.Logica;
using System;
using System.Windows.Forms;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Presentacion
{
    public partial class FrmMovimientosInventario : Form
    {
        LMovimientosInventario lMovimientos =
            new LMovimientosInventario();

        public FrmMovimientosInventario()
        {
            InitializeComponent();
        }

        // =====================================
        // LOAD
        // =====================================

        private void FrmMovimientosInventario_Load(
            object sender,
            EventArgs e)
        {
            CargarTiposMovimiento();

            CargarProductos();

            CargarBodegas();

            MostrarMovimientos();
        }

        // =====================================
        // COMBOS
        // =====================================

        private void CargarTiposMovimiento()
        {
            cboTipoMovimiento.DataSource =
                lMovimientos.MostrarTiposMovimiento();

            cboTipoMovimiento.DisplayMember =
                "Nombre";

            cboTipoMovimiento.ValueMember =
                "IdTipoMovimiento";
        }

        private void CargarProductos()
        {
            cboProducto.DataSource =
                lMovimientos.MostrarProductos();

            cboProducto.DisplayMember =
                "Nombre";

            cboProducto.ValueMember =
                "IdProducto";
        }

        private void CargarBodegas()
        {
            cboBodega.DataSource =
                lMovimientos.MostrarBodegas();

            cboBodega.DisplayMember =
                "Nombre";

            cboBodega.ValueMember =
                "IdBodega";
        }

        // =====================================
        // GRID
        // =====================================

        private void MostrarMovimientos()
        {
            dgvMovimientos.DataSource =
                lMovimientos.MostrarMovimientos();
        }

        // =====================================
        // LIMPIAR
        // =====================================

        private void LimpiarCampos()
        {
            txtCantidad.Clear();

            txtObservacion.Clear();

            cboTipoMovimiento.SelectedIndex = 0;

            cboProducto.SelectedIndex = 0;

            cboBodega.SelectedIndex = 0;
        }

        // =====================================
        // GUARDAR
        // =====================================

        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (txtCantidad.Text == "")
                {
                    MessageBox.Show(
                        "Ingrese la cantidad");

                    return;
                }

                lMovimientos.RegistrarMovimiento(
                    Convert.ToInt32(
                        cboTipoMovimiento.SelectedValue),

                    Convert.ToInt32(
                        cboProducto.SelectedValue),

                    Convert.ToInt32(
                        cboBodega.SelectedValue),

                    Convert.ToDecimal(
                        txtCantidad.Text),

                    txtObservacion.Text,

                    SesionUsuario.Usuario);

                MessageBox.Show(
                    "Movimiento registrado correctamente");

                MostrarMovimientos();

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }

        // =====================================
        // NUEVO
        // =====================================

        private void btnNuevo_Click(
            object sender,
            EventArgs e)
        {
            LimpiarCampos();
        }
        private void btnExportar_Click(
    object sender,
    EventArgs e)
        {
            ExportarExcel.Exportar(
                dgvMovimientos,
                "Reporte_Movimientos");
        }
    }

}