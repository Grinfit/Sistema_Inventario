// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Sistema_Inventario.Logica;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Presentacion
{
    // MODAL PARA REGISTRAR UNA NUEVA TRANSFERENCIA ENTRE BODEGAS
    public partial class FrmTransferenciaModal : Form
    {
        // OBJETO DE LA CAPA LOGICA DE TRANSFERENCIAS
        private LTransferencias lTransferencias = new LTransferencias();

        // CONSTRUCTOR
        public FrmTransferenciaModal()
        {
            InitializeComponent();
            AplicarEstilos();
            CargarCombos();
        }

        // ─────────────────────────────────────────
        // ESTILOS
        // ─────────────────────────────────────────

        private void AplicarEstilos()
        {
            ConfigurarBoton(btnGuardar,  Color.FromArgb(46,  204, 113));
            ConfigurarBoton(btnCancelar, Color.FromArgb(149, 165, 166));
        }

        private void ConfigurarBoton(IconButton btn, Color color)
        {
            btn.BackColor                 = color;
            btn.ForeColor                 = Color.White;
            btn.FlatStyle                 = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font                      = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.IconColor                 = Color.White;
            btn.IconSize                  = 22;
            btn.TextImageRelation         = TextImageRelation.ImageBeforeText;
            btn.Cursor                    = Cursors.Hand;

            btn.MouseEnter += (s, e) => { btn.BackColor = ControlPaint.Dark(color); };
            btn.MouseLeave += (s, e) => { btn.BackColor = color; };
        }

        // ─────────────────────────────────────────
        // CARGAR COMBOS
        // ─────────────────────────────────────────

        private void CargarCombos()
        {
            cboProducto.DataSource    = lTransferencias.MostrarProductos();
            cboProducto.DisplayMember = "Nombre";
            cboProducto.ValueMember   = "IdProducto";

            cboBodegaOrigen.DataSource    = lTransferencias.MostrarBodegas();
            cboBodegaOrigen.DisplayMember = "Nombre";
            cboBodegaOrigen.ValueMember   = "IdBodega";

            cboBodegaDestino.DataSource    = lTransferencias.MostrarBodegas().Copy();
            cboBodegaDestino.DisplayMember = "Nombre";
            cboBodegaDestino.ValueMember   = "IdBodega";
        }

        // ─────────────────────────────────────────
        // BOTON GUARDAR
        // ─────────────────────────────────────────

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCantidad.Text))
                {
                    MessageBox.Show(
                        "Ingrese la cantidad.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtCantidad.Focus();
                    return;
                }

                lTransferencias.TransferirProducto(
                    Convert.ToInt32(cboProducto.SelectedValue),
                    Convert.ToInt32(cboBodegaOrigen.SelectedValue),
                    Convert.ToInt32(cboBodegaDestino.SelectedValue),
                    Convert.ToDecimal(txtCantidad.Text),
                    txtObservacion.Text,
                    SesionUsuario.Usuario);

                MessageBox.Show(
                    "Transferencia realizada correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // BOTON CANCELAR
        // ─────────────────────────────────────────

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
