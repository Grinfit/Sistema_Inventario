// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Windows.Forms;
using Sistema_Inventario.Datos;
using Sistema_Inventario.Logica;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO DE PROVEEDORES
    public partial class FrmProveedores : Form
    {
        // OBJETO DE LA CAPA LOGICA
        LProveedores lProveedores =
            new LProveedores();

        // VARIABLE PARA ID DEL PROVEEDOR
        int idProveedor = 0;

        // CONSTRUCTOR DEL FORMULARIO
        public FrmProveedores()
        {
            InitializeComponent();
        }

        // LOAD

        private void FrmProveedores_Load(
            object sender,
            EventArgs e)
        {
            // MUESTRA LOS PROVEEDORES
            MostrarProveedores();
        }

        // MOSTRAR

        private void MostrarProveedores()
        {
            // ASIGNA LOS DATOS AL GRID
            dgvProveedores.DataSource =
                lProveedores.MostrarProveedores();
        }

        // LIMPIAR

        private void LimpiarCampos()
        {
            // LIMPIA LOS CAMPOS
            txtNombre.Clear();
            txtEmpresa.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();

            // RESETEA EL ID
            idProveedor = 0;

            // ENVIA EL FOCO
            txtNombre.Focus();
        }

        // NUEVO

        private void btnNuevo_Click(
            object sender,
            EventArgs e)
        {
            // LIMPIA LOS CAMPOS
            LimpiarCampos();
        }

        // GUARDAR

        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            // VALIDA EL NOMBRE
            if (txtNombre.Text == "")
            {
                MessageBox.Show(
                    "Ingrese el nombre");

                return;
            }

            // INSERTA EL PROVEEDOR
            lProveedores.InsertarProveedor(
                txtNombre.Text,
                txtEmpresa.Text,
                txtTelefono.Text,
                txtCorreo.Text,
                txtDireccion.Text);

            // MENSAJE DE CONFIRMACION
            MessageBox.Show(
                "Proveedor registrado correctamente");

            // ACTUALIZA EL GRID
            MostrarProveedores();

            // LIMPIA LOS CAMPOS
            LimpiarCampos();
        }

        // EDITAR

        private void btnEditar_Click(
            object sender,
            EventArgs e)
        {
            // VALIDA SI EXISTE UN ID
            if (idProveedor == 0)
            {
                MessageBox.Show(
                    "Seleccione un proveedor");

                return;
            }

            // ACTUALIZA EL PROVEEDOR
            lProveedores.EditarProveedor(
                idProveedor,
                txtNombre.Text,
                txtEmpresa.Text,
                txtTelefono.Text,
                txtCorreo.Text,
                txtDireccion.Text);

            // MENSAJE DE CONFIRMACION
            MessageBox.Show(
                "Proveedor actualizado");

            // ACTUALIZA EL GRID
            MostrarProveedores();

            // LIMPIA LOS CAMPOS
            LimpiarCampos();
        }

        // ELIMINAR

        private void btnEliminar_Click(
            object sender,
            EventArgs e)
        {
            // VALIDA SI EXISTE UN ID
            if (idProveedor == 0)
            {
                MessageBox.Show(
                    "Seleccione un proveedor");

                return;
            }

            // MENSAJE DE CONFIRMACION
            DialogResult resultado =
                MessageBox.Show(
                    "¿Desea eliminar el proveedor?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            // VALIDA LA RESPUESTA
            if (resultado == DialogResult.Yes)
            {
                // ELIMINA EL PROVEEDOR
                lProveedores.EliminarProveedor(
                    idProveedor);

                // MENSAJE DE CONFIRMACION
                MessageBox.Show(
                    "Proveedor eliminado");

                // ACTUALIZA EL GRID
                MostrarProveedores();

                // LIMPIA LOS CAMPOS
                LimpiarCampos();
            }
        }

        // BUSCAR

        private void btnBuscar_Click(
            object sender,
            EventArgs e)
        {
            // BUSCA EL PROVEEDOR
            dgvProveedores.DataSource =
                lProveedores.BuscarProveedor(
                    txtBuscar.Text);
        }

        // SELECCIONAR FILA

        private void dgvProveedores_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            // VALIDA LA FILA
            if (e.RowIndex >= 0)
            {
                // OBTIENE LA FILA
                DataGridViewRow fila =
                    dgvProveedores.Rows[e.RowIndex];

                // OBTIENE EL ID
                idProveedor =
                    Convert.ToInt32(
                        fila.Cells["IdProveedor"].Value);

                // ASIGNA EL NOMBRE
                txtNombre.Text =
                    fila.Cells["Nombre"].Value.ToString();

                // ASIGNA LA EMPRESA
                txtEmpresa.Text =
                    fila.Cells["Empresa"].Value.ToString();

                // ASIGNA EL TELEFONO
                txtTelefono.Text =
                    fila.Cells["Telefono"].Value.ToString();

                // ASIGNA EL CORREO
                txtCorreo.Text =
                    fila.Cells["Correo"].Value.ToString();

                // ASIGNA LA DIRECCION
                txtDireccion.Text =
                    fila.Cells["Direccion"].Value.ToString();
            }
        }
    }
}