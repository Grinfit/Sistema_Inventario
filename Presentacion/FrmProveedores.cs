using System;
using System.Windows.Forms;
using Sistema_Inventario.Datos;
using Sistema_Inventario.Logica;

namespace Sistema_Inventario.Presentacion
{
    public partial class FrmProveedores : Form
    {
        LProveedores lProveedores =
            new LProveedores();

        int idProveedor = 0;

        public FrmProveedores()
        {
            InitializeComponent();
        }

        // =====================================
        // LOAD
        // =====================================

        private void FrmProveedores_Load(
            object sender,
            EventArgs e)
        {
            MostrarProveedores();
        }

        // =====================================
        // MOSTRAR
        // =====================================

        private void MostrarProveedores()
        {
            dgvProveedores.DataSource =
                lProveedores.MostrarProveedores();
        }

        // =====================================
        // LIMPIAR
        // =====================================

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtEmpresa.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();

            idProveedor = 0;

            txtNombre.Focus();
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
        // GUARDAR
        // =====================================

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

            lProveedores.InsertarProveedor(
                txtNombre.Text,
                txtEmpresa.Text,
                txtTelefono.Text,
                txtCorreo.Text,
                txtDireccion.Text);

            MessageBox.Show(
                "Proveedor registrado correctamente");

            MostrarProveedores();

            LimpiarCampos();
        }

        // =====================================
        // EDITAR
        // =====================================

        private void btnEditar_Click(
            object sender,
            EventArgs e)
        {
            if (idProveedor == 0)
            {
                MessageBox.Show(
                    "Seleccione un proveedor");

                return;
            }

            lProveedores.EditarProveedor(
                idProveedor,
                txtNombre.Text,
                txtEmpresa.Text,
                txtTelefono.Text,
                txtCorreo.Text,
                txtDireccion.Text);

            MessageBox.Show(
                "Proveedor actualizado");

            MostrarProveedores();

            LimpiarCampos();
        }

        // =====================================
        // ELIMINAR
        // =====================================

        private void btnEliminar_Click(
            object sender,
            EventArgs e)
        {
            if (idProveedor == 0)
            {
                MessageBox.Show(
                    "Seleccione un proveedor");

                return;
            }

            DialogResult resultado =
                MessageBox.Show(
                    "¿Desea eliminar el proveedor?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                lProveedores.EliminarProveedor(
                    idProveedor);

                MessageBox.Show(
                    "Proveedor eliminado");

                MostrarProveedores();

                LimpiarCampos();
            }
        }

        // =====================================
        // BUSCAR
        // =====================================

        private void btnBuscar_Click(
            object sender,
            EventArgs e)
        {
            dgvProveedores.DataSource =
                lProveedores.BuscarProveedor(
                    txtBuscar.Text);
        }

        // =====================================
        // SELECCIONAR FILA
        // =====================================

        private void dgvProveedores_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila =
                    dgvProveedores.Rows[e.RowIndex];

                idProveedor =
                    Convert.ToInt32(
                        fila.Cells["IdProveedor"].Value);

                txtNombre.Text =
                    fila.Cells["Nombre"].Value.ToString();

                txtEmpresa.Text =
                    fila.Cells["Empresa"].Value.ToString();

                txtTelefono.Text =
                    fila.Cells["Telefono"].Value.ToString();

                txtCorreo.Text =
                    fila.Cells["Correo"].Value.ToString();

                txtDireccion.Text =
                    fila.Cells["Direccion"].Value.ToString();
            }
        }
    }
}
