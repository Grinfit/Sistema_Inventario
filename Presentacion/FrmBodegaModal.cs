// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Drawing;
using System.Windows.Forms;
using Sistema_Inventario.Logica;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO MODAL PARA CREAR Y EDITAR BODEGAS
    public partial class FrmBodegaModal : Form
    {
        // CAPA LOGICA DE BODEGAS
        LBodegas lBodegas = new LBodegas();

        // ESTADO DEL MODAL
        bool _modoEdicion;
        int  _idBodega;

        // ─────────────────────────────────────────
        // CONSTRUCTOR PARA NUEVA BODEGA
        // ─────────────────────────────────────────
        public FrmBodegaModal()
        {
            InitializeComponent();
            _modoEdicion = false;
            _idBodega    = 0;
            AplicarHovers();
        }

        // ─────────────────────────────────────────
        // CONSTRUCTOR PARA EDITAR BODEGA
        // ─────────────────────────────────────────
        public FrmBodegaModal(
            int    idBodega,
            string nombre,
            string direccion)
        {
            InitializeComponent();
            _modoEdicion = true;
            _idBodega    = idBodega;
            AplicarHovers();

            // CAMBIA EL TITULO AL MODO EDICION
            lblTitulo.Text = "Editar Bodega";
            this.Text      = "Editar Bodega";

            // PRE-CARGA LOS DATOS
            txtNombre.Text    = nombre;
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
                    "El nombre de la bodega es obligatorio.",
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
                    // INSERTAR NUEVA BODEGA
                    lBodegas.InsertarBodega(
                        txtNombre.Text.Trim(),
                        txtDireccion.Text.Trim());

                    MessageBox.Show(
                        "Bodega registrada correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // ACTUALIZAR BODEGA EXISTENTE
                    lBodegas.EditarBodega(
                        _idBodega,
                        txtNombre.Text.Trim(),
                        txtDireccion.Text.Trim());

                    MessageBox.Show(
                        "Bodega actualizada correctamente.",
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
