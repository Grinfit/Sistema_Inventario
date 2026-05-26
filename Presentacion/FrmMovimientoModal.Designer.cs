// IMPORTACION DE LIBRERIAS NECESARIAS
using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Inventario.Presentacion
{
    // CLASE PARCIAL DEL MODAL DE MOVIMIENTO
    partial class FrmMovimientoModal
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
            // PANELES Y CONTROLES
            this.pnlHeader       = new System.Windows.Forms.Panel();
            this.lblTitulo       = new System.Windows.Forms.Label();
            this.lblTipoMov      = new System.Windows.Forms.Label();
            this.cboTipoMovimiento = new System.Windows.Forms.ComboBox();
            this.lblProducto     = new System.Windows.Forms.Label();
            this.cboProducto     = new System.Windows.Forms.ComboBox();
            this.lblBodega       = new System.Windows.Forms.Label();
            this.cboBodega       = new System.Windows.Forms.ComboBox();
            this.lblCantidad     = new System.Windows.Forms.Label();
            this.txtCantidad     = new System.Windows.Forms.TextBox();
            this.lblObservacion  = new System.Windows.Forms.Label();
            this.txtObservacion  = new System.Windows.Forms.TextBox();
            this.pnlFooter       = new System.Windows.Forms.Panel();
            this.btnRegistrar    = new FontAwesome.Sharp.IconButton();
            this.btnCancelar     = new FontAwesome.Sharp.IconButton();

            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // ─────────────────────────────────────────
            // FORMULARIO MODAL
            // ─────────────────────────────────────────
            this.BackColor       = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize      = new System.Drawing.Size(560, 640);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ShowInTaskbar   = false;
            this.Name            = "FrmMovimientoModal";
            this.Text            = "Nuevo Movimiento";
            this.AcceptButton    = this.btnRegistrar;
            this.CancelButton    = this.btnCancelar;

            // ─────────────────────────────────────────
            // PANEL HEADER (azul oscuro)
            // ─────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(10, 35, 66);
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 72;
            this.pnlHeader.Name      = "pnlHeader";
            this.pnlHeader.TabIndex  = 0;

            // FRANJA DE COLOR POR TIPO (bottom del header)
            this.pnlTipoStrip = new System.Windows.Forms.Panel();
            this.pnlTipoStrip.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTipoStrip.Height    = 5;
            this.pnlTipoStrip.BackColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.pnlTipoStrip.Name      = "pnlTipoStrip";

            this.lblTitulo.AutoSize  = true;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location  = new System.Drawing.Point(25, 13);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.Text      = "Registrar Movimiento";

            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo.AutoSize  = true;
            this.lblSubtitulo.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(150, 190, 235);
            this.lblSubtitulo.Location  = new System.Drawing.Point(27, 44);
            this.lblSubtitulo.Name      = "lblSubtitulo";
            this.lblSubtitulo.Text      = "Seleccione el tipo de movimiento";

            this.pnlHeader.Controls.Add(this.pnlTipoStrip);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);

            // ─────────────────────────────────────────
            // CAMPO: TIPO DE MOVIMIENTO
            // ─────────────────────────────────────────
            this.lblTipoMov.AutoSize  = true;
            this.lblTipoMov.Font      = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblTipoMov.ForeColor = System.Drawing.Color.FromArgb(50, 50, 60);
            this.lblTipoMov.Location  = new System.Drawing.Point(40, 84);
            this.lblTipoMov.Name      = "lblTipoMov";
            this.lblTipoMov.Text      = "Tipo de Movimiento";

            this.cboTipoMovimiento.DropDownStyle        = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoMovimiento.Font                 = new System.Drawing.Font("Segoe UI", 11F);
            this.cboTipoMovimiento.Location             = new System.Drawing.Point(40, 108);
            this.cboTipoMovimiento.Name                 = "cboTipoMovimiento";
            this.cboTipoMovimiento.Size                 = new System.Drawing.Size(470, 32);
            this.cboTipoMovimiento.TabIndex             = 1;
            this.cboTipoMovimiento.SelectedIndexChanged += new System.EventHandler(this.cboTipoMovimiento_SelectedIndexChanged);

            // ─────────────────────────────────────────
            // CAMPO: PRODUCTO
            // ─────────────────────────────────────────
            this.lblProducto.AutoSize  = true;
            this.lblProducto.Font      = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblProducto.ForeColor = System.Drawing.Color.FromArgb(50, 50, 60);
            this.lblProducto.Location  = new System.Drawing.Point(40, 160);
            this.lblProducto.Name      = "lblProducto";
            this.lblProducto.Text      = "Producto";

            this.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto.Font          = new System.Drawing.Font("Segoe UI", 11F);
            this.cboProducto.Location      = new System.Drawing.Point(40, 184);
            this.cboProducto.Name          = "cboProducto";
            this.cboProducto.Size          = new System.Drawing.Size(470, 32);
            this.cboProducto.TabIndex      = 2;

            // ─────────────────────────────────────────
            // CAMPO: BODEGA
            // ─────────────────────────────────────────
            this.lblBodega.AutoSize  = true;
            this.lblBodega.Font      = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblBodega.ForeColor = System.Drawing.Color.FromArgb(50, 50, 60);
            this.lblBodega.Location  = new System.Drawing.Point(40, 236);
            this.lblBodega.Name      = "lblBodega";
            this.lblBodega.Text      = "Bodega";

            this.cboBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBodega.Font          = new System.Drawing.Font("Segoe UI", 11F);
            this.cboBodega.Location      = new System.Drawing.Point(40, 260);
            this.cboBodega.Name          = "cboBodega";
            this.cboBodega.Size          = new System.Drawing.Size(470, 32);
            this.cboBodega.TabIndex      = 3;

            // ─────────────────────────────────────────
            // CAMPO: CANTIDAD
            // ─────────────────────────────────────────
            this.lblCantidad.AutoSize  = true;
            this.lblCantidad.Font      = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblCantidad.ForeColor = System.Drawing.Color.FromArgb(50, 50, 60);
            this.lblCantidad.Location  = new System.Drawing.Point(40, 312);
            this.lblCantidad.Name      = "lblCantidad";
            this.lblCantidad.Text      = "Cantidad";

            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtCantidad.Location    = new System.Drawing.Point(40, 336);
            this.txtCantidad.Name        = "txtCantidad";
            this.txtCantidad.Size        = new System.Drawing.Size(220, 32);
            this.txtCantidad.TabIndex    = 4;
            this.txtCantidad.KeyPress   += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);

            // ─────────────────────────────────────────
            // CAMPO: OBSERVACION
            // ─────────────────────────────────────────
            this.lblObservacion.AutoSize  = true;
            this.lblObservacion.Font      = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblObservacion.ForeColor = System.Drawing.Color.FromArgb(50, 50, 60);
            this.lblObservacion.Location  = new System.Drawing.Point(40, 388);
            this.lblObservacion.Name      = "lblObservacion";
            this.lblObservacion.Text      = "Observación";

            this.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacion.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtObservacion.Location    = new System.Drawing.Point(40, 412);
            this.txtObservacion.Multiline   = true;
            this.txtObservacion.Name        = "txtObservacion";
            this.txtObservacion.ScrollBars  = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacion.Size        = new System.Drawing.Size(470, 90);
            this.txtObservacion.TabIndex    = 5;

            // ─────────────────────────────────────────
            // PANEL FOOTER (botones)
            // ─────────────────────────────────────────
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height    = 76;
            this.pnlFooter.Name      = "pnlFooter";
            this.pnlFooter.TabIndex  = 20;

            // BTN REGISTRAR
            this.btnRegistrar.BackColor                 = System.Drawing.Color.FromArgb(34, 197, 94);
            this.btnRegistrar.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font                      = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnRegistrar.ForeColor                 = System.Drawing.Color.White;
            this.btnRegistrar.IconChar                  = FontAwesome.Sharp.IconChar.CircleCheck;
            this.btnRegistrar.IconColor                 = System.Drawing.Color.White;
            this.btnRegistrar.IconFont                  = FontAwesome.Sharp.IconFont.Auto;
            this.btnRegistrar.IconSize                  = 24;
            this.btnRegistrar.Location                  = new System.Drawing.Point(40, 14);
            this.btnRegistrar.Name                      = "btnRegistrar";
            this.btnRegistrar.Size                      = new System.Drawing.Size(210, 50);
            this.btnRegistrar.TabIndex                  = 6;
            this.btnRegistrar.Text                      = " Registrar";
            this.btnRegistrar.TextImageRelation         = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegistrar.UseVisualStyleBackColor   = false;
            this.btnRegistrar.Click                    += new System.EventHandler(this.btnRegistrar_Click);

            // BTN CANCELAR
            this.btnCancelar.BackColor                 = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnCancelar.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font                      = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor                 = System.Drawing.Color.White;
            this.btnCancelar.IconChar                  = FontAwesome.Sharp.IconChar.Xmark;
            this.btnCancelar.IconColor                 = System.Drawing.Color.White;
            this.btnCancelar.IconFont                  = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar.IconSize                  = 24;
            this.btnCancelar.Location                  = new System.Drawing.Point(268, 14);
            this.btnCancelar.Name                      = "btnCancelar";
            this.btnCancelar.Size                      = new System.Drawing.Size(210, 50);
            this.btnCancelar.TabIndex                  = 7;
            this.btnCancelar.Text                      = " Cancelar";
            this.btnCancelar.TextImageRelation         = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor   = false;
            this.btnCancelar.DialogResult              = System.Windows.Forms.DialogResult.Cancel;

            this.pnlFooter.Controls.Add(this.btnRegistrar);
            this.pnlFooter.Controls.Add(this.btnCancelar);

            // ─────────────────────────────────────────
            // AGREGAR CONTROLES AL FORMULARIO
            // ─────────────────────────────────────────
            this.Controls.Add(this.lblTipoMov);
            this.Controls.Add(this.cboTipoMovimiento);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.cboProducto);
            this.Controls.Add(this.lblBodega);
            this.Controls.Add(this.cboBodega);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblObservacion);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);   // último para z-order correcto

            this.pnlFooter.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // PANEL CABECERA Y FOOTER
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlTipoStrip;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;

        // LABELS
        private System.Windows.Forms.Label lblTipoMov;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblBodega;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblObservacion;

        // COMBOS
        private System.Windows.Forms.ComboBox cboTipoMovimiento;
        private System.Windows.Forms.ComboBox cboProducto;
        private System.Windows.Forms.ComboBox cboBodega;

        // TEXTBOXES
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtObservacion;

        // BOTONES
        private FontAwesome.Sharp.IconButton btnRegistrar;
        private FontAwesome.Sharp.IconButton btnCancelar;
    }
}
