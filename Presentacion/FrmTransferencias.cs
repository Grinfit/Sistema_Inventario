// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Windows.Forms;
using Sistema_Inventario.Utilidades;
using Sistema_Inventario.Datos;
using Sistema_Inventario.Logica;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO ENCARGADO DE LAS TRANSFERENCIAS ENTRE BODEGAS
    public partial class FrmTransferencias : Form
    {
        // OBJETO DE LA CAPA LOGICA DE TRANSFERENCIAS
        LTransferencias lTransferencias =
            new LTransferencias();

        // CONSTRUCTOR DEL FORMULARIO
        public FrmTransferencias()
        {
            // INICIALIZA LOS COMPONENTES DEL FORMULARIO
            InitializeComponent();
        }

        // =====================================
        // LOAD
        // =====================================

        // EVENTO QUE SE EJECUTA AL CARGAR EL FORMULARIO
        private void FrmTransferencias_Load(
            object sender,
            EventArgs e)
        {
            // CARGA LOS PRODUCTOS
            CargarProductos();

            // CARGA LAS BODEGAS
            CargarBodegas();

            // MUESTRA LAS TRANSFERENCIAS
            MostrarTransferencias();
        }

        // =====================================
        // PRODUCTOS
        // =====================================

        // METODO PARA CARGAR LOS PRODUCTOS EN EL COMBOBOX
        private void CargarProductos()
        {
            // ASIGNA LOS DATOS AL COMBOBOX
            cboProducto.DataSource =
                lTransferencias.MostrarProductos();

            // CAMPO QUE SE MOSTRARA
            cboProducto.DisplayMember =
                "Nombre";

            // CAMPO QUE CONTENDRA EL VALOR
            cboProducto.ValueMember =
                "IdProducto";
        }

        // =====================================
        // BODEGAS
        // =====================================

        // METODO PARA CARGAR LAS BODEGAS
        private void CargarBodegas()
        {
            // ASIGNA LOS DATOS A LA BODEGA ORIGEN
            cboBodegaOrigen.DataSource =
                lTransferencias.MostrarBodegas();

            // CAMPO A MOSTRAR
            cboBodegaOrigen.DisplayMember =
                "Nombre";

            // CAMPO DEL VALOR
            cboBodegaOrigen.ValueMember =
                "IdBodega";

            // ASIGNA LOS DATOS A LA BODEGA DESTINO
            cboBodegaDestino.DataSource =
                lTransferencias.MostrarBodegas().Copy();

            // CAMPO A MOSTRAR
            cboBodegaDestino.DisplayMember =
                "Nombre";

            // CAMPO DEL VALOR
            cboBodegaDestino.ValueMember =
                "IdBodega";
        }

        // =====================================
        // GRID
        // =====================================

        // METODO PARA MOSTRAR LAS TRANSFERENCIAS
        private void MostrarTransferencias()
        {
            // ASIGNA LOS DATOS AL DATAGRIDVIEW
            dgvTransferencias.DataSource =
                lTransferencias.MostrarTransferencias();
        }

        // =====================================
        // LIMPIAR
        // =====================================

        // METODO PARA LIMPIAR LOS CAMPOS DEL FORMULARIO
        private void LimpiarCampos()
        {
            // LIMPIA EL CAMPO CANTIDAD
            txtCantidad.Clear();

            // LIMPIA EL CAMPO OBSERVACION
            txtObservacion.Clear();

            // RESETEA EL COMBOBOX DE PRODUCTOS
            cboProducto.SelectedIndex = 0;

            // RESETEA EL COMBOBOX DE BODEGA ORIGEN
            cboBodegaOrigen.SelectedIndex = 0;

            // RESETEA EL COMBOBOX DE BODEGA DESTINO
            cboBodegaDestino.SelectedIndex = 0;
        }

        // =====================================
        // NUEVO
        // =====================================

        // EVENTO DEL BOTON NUEVO
        private void btnNuevo_Click(
            object sender,
            EventArgs e)
        {
            // LIMPIA LOS CAMPOS
            LimpiarCampos();
        }

        // =====================================
        // TRANSFERIR
        // =====================================

        // EVENTO DEL BOTON TRANSFERIR
        private void btnTransferir_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                // VALIDA SI EL CAMPO CANTIDAD ESTA VACIO
                if (txtCantidad.Text == "")
                {
                    MessageBox.Show(
                        "Ingrese la cantidad");

                    return;
                }

                // EJECUTA LA TRANSFERENCIA DEL PRODUCTO
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

                // MENSAJE DE EXITO
                MessageBox.Show(
                    "Transferencia realizada correctamente");

                // ACTUALIZA EL GRID
                MostrarTransferencias();

                // LIMPIA LOS CAMPOS
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                // MUESTRA EL ERROR
                MessageBox.Show(
                    ex.Message);
            }
        }

        // EVENTO DEL BOTON EXPORTAR
        private void btnExportar_Click(
    object sender,
    EventArgs e)
        {
            // EXPORTA EL DATAGRIDVIEW A EXCEL
            ExportarExcel.Exportar(
                dgvTransferencias,
                "Reporte_Transferencias");
        }
    }
}