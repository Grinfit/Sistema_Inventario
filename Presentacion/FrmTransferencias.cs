using System;
using System.Windows.Forms;
using Sistema_Inventario.Utilidades;
using Sistema_Inventario.Datos;
using Sistema_Inventario.Logica;

namespace Sistema_Inventario.Presentacion
{
    public partial class FrmTransferencias : Form
    {
        LTransferencias lTransferencias =
            new LTransferencias();

        public FrmTransferencias()
        {
            InitializeComponent();
        }

        // =====================================
        // LOAD
        // =====================================

        private void FrmTransferencias_Load(
            object sender,
            EventArgs e)
        {
            CargarProductos();

            CargarBodegas();

            MostrarTransferencias();
        }

        // =====================================
        // PRODUCTOS
        // =====================================

        private void CargarProductos()
        {
            cboProducto.DataSource =
                lTransferencias.MostrarProductos();

            cboProducto.DisplayMember =
                "Nombre";

            cboProducto.ValueMember =
                "IdProducto";
        }

        // =====================================
        // BODEGAS
        // =====================================

        private void CargarBodegas()
        {
            cboBodegaOrigen.DataSource =
                lTransferencias.MostrarBodegas();

            cboBodegaOrigen.DisplayMember =
                "Nombre";

            cboBodegaOrigen.ValueMember =
                "IdBodega";

            cboBodegaDestino.DataSource =
                lTransferencias.MostrarBodegas().Copy();

            cboBodegaDestino.DisplayMember =
                "Nombre";

            cboBodegaDestino.ValueMember =
                "IdBodega";
        }

        // =====================================
        // GRID
        // =====================================

        private void MostrarTransferencias()
        {
            dgvTransferencias.DataSource =
                lTransferencias.MostrarTransferencias();
        }

        // =====================================
        // LIMPIAR
        // =====================================

        private void LimpiarCampos()
        {
            txtCantidad.Clear();

            txtObservacion.Clear();

            cboProducto.SelectedIndex = 0;

            cboBodegaOrigen.SelectedIndex = 0;

            cboBodegaDestino.SelectedIndex = 0;
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

        // =====================================
        // TRANSFERIR
        // =====================================

        private void btnTransferir_Click(
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

                lTransferencias.TransferirProducto(
                    Convert.ToInt32(
                        cboProducto.SelectedValue),

                    Convert.ToInt32(
                        cboBodegaOrigen.SelectedValue),

                    Convert.ToInt32(
                        cboBodegaDestino.SelectedValue),

                    Convert.ToDecimal(
                        txtCantidad.Text),

                    txtObservacion.Text,

                    SesionUsuario.Usuario);

                MessageBox.Show(
                    "Transferencia realizada correctamente");

                MostrarTransferencias();

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }
        private void btnExportar_Click(
    object sender,
    EventArgs e)
        {
            ExportarExcel.Exportar(
                dgvTransferencias,
                "Reporte_Transferencias");
        }
    }
}