// IMPORTACION DE LIBRERIAS NECESARIAS
using Sistema_Inventario.Logica;
using Sistema_Inventario.Utilidades;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO MODAL PARA REGISTRAR MOVIMIENTOS DE INVENTARIO
    public partial class FrmMovimientoModal : Form
    {
        // CAPA LOGICA
        LMovimientosInventario lMovimientos = new LMovimientosInventario();

        // CONSTRUCTOR
        public FrmMovimientoModal()
        {
            InitializeComponent();
            AplicarHovers();
        }

        // ─────────────────────────────────────────
        // LOAD — carga los combos
        // ─────────────────────────────────────────
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarTiposMovimiento();
            CargarProductos();
            CargarBodegas();
        }

        // ─────────────────────────────────────────
        // EFECTOS HOVER EN BOTONES
        // ─────────────────────────────────────────
        private void AplicarHovers()
        {
            Color cRegistrar = Color.FromArgb(34, 197, 94);
            Color cCancelar  = Color.FromArgb(149, 165, 166);

            btnRegistrar.MouseEnter += (s, ev) => btnRegistrar.BackColor = ControlPaint.Dark(cRegistrar);
            btnRegistrar.MouseLeave += (s, ev) => btnRegistrar.BackColor = cRegistrar;
            btnCancelar.MouseEnter  += (s, ev) => btnCancelar.BackColor  = ControlPaint.Dark(cCancelar);
            btnCancelar.MouseLeave  += (s, ev) => btnCancelar.BackColor  = cCancelar;
        }

        // ─────────────────────────────────────────
        // CARGA DE COMBOS
        // ─────────────────────────────────────────
        private void CargarTiposMovimiento()
        {
            cboTipoMovimiento.DataSource    = lMovimientos.MostrarTiposMovimiento();
            cboTipoMovimiento.DisplayMember = "Nombre";
            cboTipoMovimiento.ValueMember   = "IdTipoMovimiento";

            if (cboTipoMovimiento.Items.Count > 0)
                cboTipoMovimiento.SelectedIndex = 0;
        }

        private void CargarProductos()
        {
            cboProducto.DataSource    = lMovimientos.MostrarProductos();
            cboProducto.DisplayMember = "Nombre";
            cboProducto.ValueMember   = "IdProducto";

            if (cboProducto.Items.Count > 0)
                cboProducto.SelectedIndex = 0;
        }

        private void CargarBodegas()
        {
            cboBodega.DataSource    = lMovimientos.MostrarBodegas();
            cboBodega.DisplayMember = "Nombre";
            cboBodega.ValueMember   = "IdBodega";

            if (cboBodega.Items.Count > 0)
                cboBodega.SelectedIndex = 0;
        }

        // ─────────────────────────────────────────
        // VALIDACION
        // ─────────────────────────────────────────
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show(
                    "Ingrese la cantidad.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return false;
            }

            if (!decimal.TryParse(txtCantidad.Text, out decimal cantidad))
            {
                MessageBox.Show(
                    "Ingrese una cantidad válida.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return false;
            }

            if (cantidad <= 0)
            {
                MessageBox.Show(
                    "La cantidad debe ser mayor a cero.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtObservacion.Text))
            {
                MessageBox.Show(
                    "Ingrese una observación.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtObservacion.Focus();
                return false;
            }

            if (txtObservacion.Text.Trim().Length < 5)
            {
                MessageBox.Show(
                    "La observación es demasiado corta.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtObservacion.Focus();
                return false;
            }

            return true;
        }

        // ─────────────────────────────────────────
        // BTN REGISTRAR
        // ─────────────────────────────────────────
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                decimal cantidad = Convert.ToDecimal(txtCantidad.Text);

                string tipoMovimiento =
                    cboTipoMovimiento.Text.ToUpper().Trim();

                // VALIDA STOCK PARA SALIDAS
                if (tipoMovimiento == "SALIDA")
                {
                    int idProducto = Convert.ToInt32(cboProducto.SelectedValue);
                    int idBodega   = Convert.ToInt32(cboBodega.SelectedValue);

                    decimal stockActual =
                        lMovimientos.ObtenerStockActual(idProducto, idBodega);

                    if (cantidad > stockActual)
                    {
                        MessageBox.Show(
                            $"Stock insuficiente.\n\nStock actual: {stockActual}",
                            "Validación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                }

                // REGISTRA EL MOVIMIENTO
                lMovimientos.RegistrarMovimiento(
                    Convert.ToInt32(cboTipoMovimiento.SelectedValue),
                    Convert.ToInt32(cboProducto.SelectedValue),
                    Convert.ToInt32(cboBodega.SelectedValue),
                    cantidad,
                    txtObservacion.Text.Trim(),
                    SesionUsuario.Usuario);

                MessageBox.Show(
                    "Movimiento registrado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // CIERRA EL MODAL CON RESULTADO OK
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al registrar: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // SOLO NUMEROS EN CANTIDAD
        // ─────────────────────────────────────────
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' &&
                txtCantidad.Text.Contains("."))
            {
                e.Handled = true;
            }
        }
    }
}
