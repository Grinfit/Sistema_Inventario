using System;
using System.Windows.Forms;
using Sistema_Inventario.Datos;
using Sistema_Inventario.Logica;

namespace Sistema_Inventario.Presentacion
{
    public partial class FrmBodegas : Form
    {
        LBodegas lBodegas =
            new LBodegas();

        int idBodega = 0;

        public FrmBodegas()
        {
            InitializeComponent();
        }

        // =========================================
        // LOAD
        // =========================================

        private void FrmBodegas_Load(
            object sender,
            EventArgs e)
        {
            MostrarBodegas();
        }

        // =========================================
        // MOSTRAR
        // =========================================

        private void MostrarBodegas()
        {
            dgvBodegas.DataSource =
                lBodegas.MostrarBodegas();
        }

        // =========================================
        // LIMPIAR
        // =========================================

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDireccion.Clear();

            idBodega = 0;

            txtNombre.Focus();
        }

        // =========================================
        // NUEVO
        // =========================================

        private void btnNuevo_Click(
            object sender,
            EventArgs e)
        {
            LimpiarCampos();
        }

        // =========================================
        // GUARDAR
        // =========================================

        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show(
                    "Ingrese el nombre");

                return;
            }

            lBodegas.InsertarBodega(
                txtNombre.Text,
                txtDireccion.Text);

            MessageBox.Show(
                "Bodega registrada correctamente");

            MostrarBodegas();

            LimpiarCampos();
        }

        // =========================================
        // EDITAR
        // =========================================

        private void btnEditar_Click(
            object sender,
            EventArgs e)
        {
            if (idBodega == 0)
            {
                MessageBox.Show(
                    "Seleccione una bodega");

                return;
            }

            lBodegas.EditarBodega(
                idBodega,
                txtNombre.Text,
                txtDireccion.Text);

            MessageBox.Show(
                "Bodega actualizada");

            MostrarBodegas();

            LimpiarCampos();
        }

        // =========================================
        // ELIMINAR
        // =========================================

        private void btnEliminar_Click(
            object sender,
            EventArgs e)
        {
            if (idBodega == 0)
            {
                MessageBox.Show(
                    "Seleccione una bodega");

                return;
            }

            DialogResult resultado =
                MessageBox.Show(
                    "¿Desea eliminar la bodega?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                lBodegas.EliminarBodega(
                    idBodega);

                MessageBox.Show(
                    "Bodega eliminada");

                MostrarBodegas();

                LimpiarCampos();
            }
        }

        // =========================================
        // BUSCAR
        // =========================================

        private void btnBuscar_Click(
            object sender,
            EventArgs e)
        {
            dgvBodegas.DataSource =
                lBodegas.BuscarBodega(
                    txtBuscar.Text);
        }

        // =========================================
        // SELECCIONAR FILA
        // =========================================

        private void dgvBodegas_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila =
                    dgvBodegas.Rows[e.RowIndex];

                idBodega =
                    Convert.ToInt32(
                        fila.Cells["IdBodega"].Value);

                txtNombre.Text =
                    fila.Cells["Nombre"].Value.ToString();

                txtDireccion.Text =
                    fila.Cells["Direccion"].Value.ToString();
            }
        }
    }
}