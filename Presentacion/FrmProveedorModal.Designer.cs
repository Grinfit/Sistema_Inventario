// IMPORTACION DE LIBRERIAS NECESARIAS
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Sistema_Inventario.Presentacion
{
    // CLASE PARCIAL DEL FORMULARIO MODAL DE PROVEEDOR
    partial class FrmProveedorModal
    {
        // CONTENEDOR DE COMPONENTES
        private System.ComponentModel.IContainer components = null;

        // METODO PARA LIBERAR RECURSOS
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        // METODO PARA INICIALIZAR COMPONENTES
        private void InitializeComponent()
        {
            // CONTROLES
            this.pnlHeader    = new Panel();
            this.lblTitulo    = new Label();
            this.lblNombre    = new Label();
            this.txtNombre    = new TextBox();
            this.lblEmpresa   = new Label();
            this.txtEmpresa   = new TextBox();
            this.lblTelefono  = new Label();
            this.txtTelefono  = new TextBox();
            this.lblCorreo    = new Label();
            this.txtCorreo    = new TextBox();
            this.lblDireccion = new Label();
            this.txtDireccion = new TextBox();
            this.btnGuardar   = new IconButton();
            this.btnCancelar  = new IconButton();

            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            // ─────────────────────────────────────────
            // FORMULARIO
            // ─────────────────────────────────────────
            this.ClientSize      = new System.Drawing.Size(520, 500);
            this.BackColor       = System.Drawing.Color.FromArgb(240, 242, 245);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.StartPosition   = FormStartPosition.CenterParent;
            this.ShowInTaskbar   = false;
            this.Name            = "FrmProveedorModal";
            this.Text            = "Proveedor";
            this.AcceptButton    = this.btnGuardar;
            this.CancelButton    = this.btnCancelar;

            // ─────────────────────────────────────────
            // PANEL CABECERA AZUL
            // ─────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(10, 35, 66);
            this.pnlHeader.Dock      = DockStyle.Top;
            this.pnlHeader.Height    = 65;
            this.pnlHeader.Controls.Add(this.lblTitulo);

            // LABEL TITULO (dentro del panel)
            this.lblTitulo.AutoSize  = true;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location  = new System.Drawing.Point(25, 17);
            this.lblTitulo.Text      = "Nuevo Proveedor";

            // ─────────────────────────────────────────
            // CAMPO NOMBRE  (ancho completo)
            // ─────────────────────────────────────────
            this.lblNombre.AutoSize  = true;
            this.lblNombre.Font      = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.lblNombre.Location  = new System.Drawing.Point(40, 84);
            this.lblNombre.Text      = "Nombre";

            this.txtNombre.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtNombre.Location    = new System.Drawing.Point(40, 107);
            this.txtNombre.Size        = new System.Drawing.Size(420, 38);
            this.txtNombre.BorderStyle = BorderStyle.FixedSingle;
            this.txtNombre.MaxLength   = 100;

            // ─────────────────────────────────────────
            // CAMPO EMPRESA  (ancho completo)
            // ─────────────────────────────────────────
            this.lblEmpresa.AutoSize  = true;
            this.lblEmpresa.Font      = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblEmpresa.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.lblEmpresa.Location  = new System.Drawing.Point(40, 163);
            this.lblEmpresa.Text      = "Empresa";

            this.txtEmpresa.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtEmpresa.Location    = new System.Drawing.Point(40, 186);
            this.txtEmpresa.Size        = new System.Drawing.Size(420, 38);
            this.txtEmpresa.BorderStyle = BorderStyle.FixedSingle;
            this.txtEmpresa.MaxLength   = 100;

            // ─────────────────────────────────────────
            // CAMPO TELEFONO  (mitad izquierda)
            // ─────────────────────────────────────────
            this.lblTelefono.AutoSize  = true;
            this.lblTelefono.Font      = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.lblTelefono.Location  = new System.Drawing.Point(40, 242);
            this.lblTelefono.Text      = "Teléfono";

            this.txtTelefono.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTelefono.Location    = new System.Drawing.Point(40, 265);
            this.txtTelefono.Size        = new System.Drawing.Size(195, 38);
            this.txtTelefono.BorderStyle = BorderStyle.FixedSingle;
            this.txtTelefono.MaxLength   = 20;

            // ─────────────────────────────────────────
            // CAMPO CORREO  (mitad derecha)
            // ─────────────────────────────────────────
            this.lblCorreo.AutoSize  = true;
            this.lblCorreo.Font      = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblCorreo.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.lblCorreo.Location  = new System.Drawing.Point(265, 242);
            this.lblCorreo.Text      = "Correo";

            this.txtCorreo.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtCorreo.Location    = new System.Drawing.Point(265, 265);
            this.txtCorreo.Size        = new System.Drawing.Size(195, 38);
            this.txtCorreo.BorderStyle = BorderStyle.FixedSingle;
            this.txtCorreo.MaxLength   = 100;

            // ─────────────────────────────────────────
            // CAMPO DIRECCION  (ancho completo)
            // ─────────────────────────────────────────
            this.lblDireccion.AutoSize  = true;
            this.lblDireccion.Font      = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.lblDireccion.Location  = new System.Drawing.Point(40, 321);
            this.lblDireccion.Text      = "Dirección";

            this.txtDireccion.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtDireccion.Location    = new System.Drawing.Point(40, 344);
            this.txtDireccion.Size        = new System.Drawing.Size(420, 38);
            this.txtDireccion.BorderStyle = BorderStyle.FixedSingle;
            this.txtDireccion.MaxLength   = 200;

            // ─────────────────────────────────────────
            // BOTON GUARDAR
            // ─────────────────────────────────────────
            this.btnGuardar.BackColor                  = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnGuardar.FlatStyle                  = FlatStyle.Flat;
            this.btnGuardar.FlatAppearance.BorderSize  = 0;
            this.btnGuardar.ForeColor                  = System.Drawing.Color.White;
            this.btnGuardar.Font                       = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.IconChar                   = IconChar.FloppyDisk;
            this.btnGuardar.IconColor                  = System.Drawing.Color.White;
            this.btnGuardar.IconFont                   = IconFont.Auto;
            this.btnGuardar.IconSize                   = 26;
            this.btnGuardar.Text                       = " Guardar";
            this.btnGuardar.TextImageRelation          = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.Location                   = new System.Drawing.Point(40, 408);
            this.btnGuardar.Size                       = new System.Drawing.Size(190, 52);
            this.btnGuardar.Cursor                     = Cursors.Hand;
            this.btnGuardar.Click                     += new System.EventHandler(this.btnGuardar_Click);

            // ─────────────────────────────────────────
            // BOTON CANCELAR
            // ─────────────────────────────────────────
            this.btnCancelar.BackColor                  = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnCancelar.FlatStyle                  = FlatStyle.Flat;
            this.btnCancelar.FlatAppearance.BorderSize  = 0;
            this.btnCancelar.ForeColor                  = System.Drawing.Color.White;
            this.btnCancelar.Font                       = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.IconChar                   = IconChar.Xmark;
            this.btnCancelar.IconColor                  = System.Drawing.Color.White;
            this.btnCancelar.IconFont                   = IconFont.Auto;
            this.btnCancelar.IconSize                   = 26;
            this.btnCancelar.Text                       = " Cancelar";
            this.btnCancelar.TextImageRelation          = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.Location                   = new System.Drawing.Point(262, 408);
            this.btnCancelar.Size                       = new System.Drawing.Size(190, 52);
            this.btnCancelar.Cursor                     = Cursors.Hand;
            this.btnCancelar.DialogResult               = DialogResult.Cancel;

            // ─────────────────────────────────────────
            // AGREGAR CONTROLES AL FORMULARIO
            // ─────────────────────────────────────────
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.txtEmpresa);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pnlHeader);   // último para z-order correcto

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // PANEL CABECERA
        private Panel pnlHeader;
        private Label lblTitulo;

        // CAMPOS
        private Label   lblNombre;
        private TextBox txtNombre;
        private Label   lblEmpresa;
        private TextBox txtEmpresa;
        private Label   lblTelefono;
        private TextBox txtTelefono;
        private Label   lblCorreo;
        private TextBox txtCorreo;
        private Label   lblDireccion;
        private TextBox txtDireccion;

        // BOTONES
        private IconButton btnGuardar;
        private IconButton btnCancelar;
    }
}
