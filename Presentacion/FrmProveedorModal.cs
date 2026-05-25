// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Drawing;
using System.Windows.Forms;
using Sistema_Inventario.Logica;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO MODAL PARA CREAR Y EDITAR PROVEEDORES
    public partial class FrmProveedorModal : Form
    {
        // CAPA LOGICA DE PROVEEDORES
        LProveedores lProveedores = new LProveedores();

        // ESTADO DEL MODAL
        bool _modoEdicion;
        int  _idProveedor;

        // ─────────────────────────────────────────
        // CONSTRUCTOR PARA NUEVO PROVEEDOR
        // ─────────────────────────────────────────
        public FrmProveedorModal()
        {
            InitializeComponent();
            _modoEdicion = false;
            _idProveedor = 0;
            AplicarHovers();
        }

        // ─────────────────────────────────────────
        // CONSTRUCTOR PARA EDITAR PROVEEDOR
        // ─────────────────────────────────────────
        public FrmProveedorModal(
            int    idProveedor,
            string nombre,
            string empresa,
            string telefono,
            string correo,
            string direccion)
        {
            InitializeComponent();
            _modoEdicion = true;
            _idProveedor = idProveedor;
            AplicarHovers();

            // CAMBIA EL TITULO AL MODO EDICION
            lblTitulo.Text = "Editar Proveedor";
            this.Text      = "Editar Proveedor";

            // PRE-CARGA LOS DATOS
            txtNombre.Text    = nombre;
            txtEmpresa.Text   = empresa;
            txtTelefono.Text  = telefono;
            txtCorreo.Text    = correo;
            txtDireccion.Text = direccion;
        }

        // EFECTO HOVER EN BOTONES
        private void AplicarHovers()
        {
            Color cGuardar  = Color.FromArgb(46,  204, 113);
            Color cCancelar = Color.FromArgb(149, 165, 166);

            btnGuardar.MouseEnter  += (s, e) => { btnGuardar.BackColor  = ControlPaint.Dark(cGuardar);  };
            btnGuardar.MouseLeave  += (s, e) => { btnGuardar.BackColor  = cGuardar;  };
            btnCancelar.MouseEnter += (s, e) => { btnCancelar.BackColor = ControlPaint.Dark(cCancelar); };
            btnCancelar.MouseLeave += (s, e) => { btnCancelar.BackColor = cCancelar; };
        }

        // ─────────────────────────────────────────
        // VALIDACION DE CAMPOS
        // ─────────────────────────────────────────
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "El nombre del proveedor es obligatorio.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            return true;
        }

        // ─────────────────────────────────────────
        // BOTON GUARDAR — INSERT o UPDATE
        // ─────────────────────────────────────────
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                if (!_modoEdicion)
                {
                    // INSERTAR NUEVO PROVEEDOR
                    lProveedores.InsertarProveedor(
                        txtNombre.Text.Trim(),
                        txtEmpresa.Text.Trim(),
                        txtTelefono.Text.Trim(),
                        txtCorreo.Text.Trim(),
                        txtDireccion.Text.Trim());

                    MessageBox.Show(
                        "Proveedor registrado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // ACTUALIZAR PROVEEDOR EXISTENTE
                    lProveedores.EditarProveedor(
                        _idProveedor,
                        txtNombre.Text.Trim(),
                        txtEmpresa.Text.Trim(),
                        txtTelefono.Text.Trim(),
                        txtCorreo.Text.Trim(),
                        txtDireccion.Text.Trim());

                    MessageBox.Show(
                        "Proveedor actualizado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // CIERRA EL MODAL CON RESULTADO OK
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al guardar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
