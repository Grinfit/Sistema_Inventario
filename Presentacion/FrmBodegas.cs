// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Windows.Forms;
using Sistema_Inventario.Datos;
using Sistema_Inventario.Logica;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO ENCARGADO DE LA GESTION DE BODEGAS
    public partial class FrmBodegas : Form
    {
        // OBJETO DE LA CAPA LOGICA DE BODEGAS
        LBodegas lBodegas =
            new LBodegas();

        // VARIABLE PARA GUARDAR EL ID DE LA BODEGA
        int idBodega = 0;

        // CONSTRUCTOR DEL FORMULARIO
        public FrmBodegas()
        {
            // INICIALIZA LOS COMPONENTES
            InitializeComponent();
        }

        // EVENTO LOAD DEL FORMULARIO
        private void FrmBodegas_Load(
            object sender,
            EventArgs e)
        {
            // MUESTRA LAS BODEGAS REGISTRADAS
            MostrarBodegas();
        }

        // METODO PARA MOSTRAR LAS BODEGAS
        private void MostrarBodegas()
        {
            dgvBodegas.DataSource =
                lBodegas.MostrarBodegas();
        }

        // METODO PARA LIMPIAR LOS CAMPOS
        private void LimpiarCampos()
        {
            // LIMPIA EL TEXTBOX NOMBRE
            txtNombre.Clear();

            // LIMPIA EL TEXTBOX DIRECCION
            txtDireccion.Clear();

            // REINICIA EL ID
            idBodega = 0;

            // ENVIA EL FOCO AL TEXTBOX NOMBRE
            txtNombre.Focus();
        }

        // EVENTO NUEVO
        private void btnNuevo_Click(
            object sender,
            EventArgs e)
        {
            // LIMPIA LOS CAMPOS
            LimpiarCampos();
        }

        // EVENTO GUARDAR
        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            // VALIDA SI EL NOMBRE ESTA VACIO
            if (txtNombre.Text == "")
            {
                MessageBox.Show(
                    "Ingrese el nombre");

                return;
            }

            // INSERTA LA BODEGA
            lBodegas.InsertarBodega(
                txtNombre.Text,
                txtDireccion.Text);

            // MENSAJE DE CONFIRMACION
            MessageBox.Show(
                "Bodega registrada correctamente");

            // ACTUALIZA EL DATAGRIDVIEW
            MostrarBodegas();

            // LIMPIA LOS CAMPOS
            LimpiarCampos();
        }

        // EVENTO EDITAR
        private void btnEditar_Click(
            object sender,
            EventArgs e)
        {
            // VALIDA SI SELECCIONO UNA BODEGA
            if (idBodega == 0)
            {
                MessageBox.Show(
                    "Seleccione una bodega");

                return;
            }

            // ACTUALIZA LA BODEGA
            lBodegas.EditarBodega(
                idBodega,
                txtNombre.Text,
                txtDireccion.Text);

            // MENSAJE DE CONFIRMACION
            MessageBox.Show(
                "Bodega actualizada");

            // ACTUALIZA EL DATAGRIDVIEW
            MostrarBodegas();

            // LIMPIA LOS CAMPOS
            LimpiarCampos();
        }

        // EVENTO ELIMINAR
        private void btnEliminar_Click(
            object sender,
            EventArgs e)
        {
            // VALIDA SI SELECCIONO UNA BODEGA
            if (idBodega == 0)
            {
                MessageBox.Show(
                    "Seleccione una bodega");

                return;
            }

            // MENSAJE DE CONFIRMACION
            DialogResult resultado =
                MessageBox.Show(
                    "¿Desea eliminar la bodega?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            // VALIDA SI EL USUARIO CONFIRMO
            if (resultado == DialogResult.Yes)
            {
                // ELIMINA LA BODEGA
                lBodegas.EliminarBodega(
                    idBodega);

                // MENSAJE DE CONFIRMACION
                MessageBox.Show(
                    "Bodega eliminada");

                // ACTUALIZA EL DATAGRIDVIEW
                MostrarBodegas();

                // LIMPIA LOS CAMPOS
                LimpiarCampos();
            }
        }

        // EVENTO BUSCAR
        private void btnBuscar_Click(
            object sender,
            EventArgs e)
        {
            // BUSCA LA BODEGA
            dgvBodegas.DataSource =
                lBodegas.BuscarBodega(
                    txtBuscar.Text);
        }

        // EVENTO SELECCIONAR FILA DEL DATAGRIDVIEW
        private void dgvBodegas_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            // VALIDA SI LA FILA ES VALIDA
            if (e.RowIndex >= 0)
            {
                // OBTIENE LA FILA SELECCIONADA
                DataGridViewRow fila =
                    dgvBodegas.Rows[e.RowIndex];

                // OBTIENE EL ID DE LA BODEGA
                idBodega =
                    Convert.ToInt32(
                        fila.Cells["IdBodega"].Value);

                // MUESTRA EL NOMBRE
                txtNombre.Text =
                    fila.Cells["Nombre"].Value.ToString();

                // MUESTRA LA DIRECCION
                txtDireccion.Text =
                    fila.Cells["Direccion"].Value.ToString();
            }
        }
    }
}