// IMPORTACION DE LIBRERIAS NECESARIAS
using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Inventario.Presentacion
{
    // CLASE PARCIAL DEL MODAL DE NUEVA TRANSFERENCIA
    partial class FrmTransferenciaModal
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
            this.pnlHeader        = new System.Windows.Forms.Panel();
            this.lblTitulo        = new System.Windows.Forms.Label();
            this.lblProducto      = new System.Windows.Forms.Label();
            this.cboProducto      = new System.Windows.Forms.ComboBox();
            this.lblBodegaOrigen  = new System.Windows.Forms.Label();
            this.cboBodegaOrigen  = new System.Windows.Forms.ComboBox();
            this.lblBodegaDestino = new System.Windows.Forms.Label();
            this.cboBodegaDestino = new System.Windows.Forms.ComboBox();
            this.lblCantidad      = new System.Windows.Forms.Label();
            this.txtCantidad      = new System.Windows.Forms.TextBox();
            this.lblObservacion   = new System.Windows.Forms.Label();
            this.txtObservacion   = new System.Windows.Forms.TextBox();
            this.btnGuardar       = new FontAwesome.Sharp.IconButton();
            this.btnCancelar      = new FontAwesome.Sharp.IconButton();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(35)))), ((int)(((byte)(66)))));
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock     = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Name     = "pnlHeader";
            this.pnlHeader.Size     = new System.Drawing.Size(560, 65);
            this.pnlHeader.TabIndex = 0;

            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize  = true;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location  = new System.Drawing.Point(20, 18);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.TabIndex  = 0;
            this.lblTitulo.Text      = "Nueva Transferencia";

            //
            // lblProducto
            //
            this.lblProducto.AutoSize  = true;
            this.lblProducto.Font      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblProducto.Location  = new System.Drawing.Point(30, 85);
            this.lblProducto.Name      = "lblProducto";
            this.lblProducto.TabIndex  = 1;
            this.lblProducto.Text      = "Producto:";

            //
            // cboProducto
            //
            this.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto.Font          = new System.Drawing.Font("Segoe UI", 11F);
            this.cboProducto.Location      = new System.Drawing.Point(30, 110);
            this.cboProducto.Name          = "cboProducto";
            this.cboProducto.Size          = new System.Drawing.Size(500, 33);
            this.cboProducto.TabIndex      = 2;

            //
            // lblBodegaOrigen
            //
            this.lblBodegaOrigen.AutoSize  = true;
            this.lblBodegaOrigen.Font      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblBodegaOrigen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblBodegaOrigen.Location  = new System.Drawing.Point(30, 163);
            this.lblBodegaOrigen.Name      = "lblBodegaOrigen";
            this.lblBodegaOrigen.TabIndex  = 3;
            this.lblBodegaOrigen.Text      = "Bodega Origen:";

            //
            // cboBodegaOrigen
            //
            this.cboBodegaOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBodegaOrigen.Font          = new System.Drawing.Font("Segoe UI", 11F);
            this.cboBodegaOrigen.Location      = new System.Drawing.Point(30, 188);
            this.cboBodegaOrigen.Name          = "cboBodegaOrigen";
            this.cboBodegaOrigen.Size          = new System.Drawing.Size(235, 33);
            this.cboBodegaOrigen.TabIndex      = 4;

            //
            // lblBodegaDestino
            //
            this.lblBodegaDestino.AutoSize  = true;
            this.lblBodegaDestino.Font      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblBodegaDestino.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblBodegaDestino.Location  = new System.Drawing.Point(295, 163);
            this.lblBodegaDestino.Name      = "lblBodegaDestino";
            this.lblBodegaDestino.TabIndex  = 5;
            this.lblBodegaDestino.Text      = "Bodega Destino:";

            //
            // cboBodegaDestino
            //
            this.cboBodegaDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBodegaDestino.Font          = new System.Drawing.Font("Segoe UI", 11F);
            this.cboBodegaDestino.Location      = new System.Drawing.Point(295, 188);
            this.cboBodegaDestino.Name          = "cboBodegaDestino";
            this.cboBodegaDestino.Size          = new System.Drawing.Size(235, 33);
            this.cboBodegaDestino.TabIndex      = 6;

            //
            // lblCantidad
            //
            this.lblCantidad.AutoSize  = true;
            this.lblCantidad.Font      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblCantidad.Location  = new System.Drawing.Point(30, 241);
            this.lblCantidad.Name      = "lblCantidad";
            this.lblCantidad.TabIndex  = 7;
            this.lblCantidad.Text      = "Cantidad:";

            //
            // txtCantidad
            //
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtCantidad.Location    = new System.Drawing.Point(30, 266);
            this.txtCantidad.Name        = "txtCantidad";
            this.txtCantidad.Size        = new System.Drawing.Size(235, 32);
            this.txtCantidad.TabIndex    = 8;

            //
            // lblObservacion
            //
            this.lblObservacion.AutoSize  = true;
            this.lblObservacion.Font      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblObservacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblObservacion.Location  = new System.Drawing.Point(30, 318);
            this.lblObservacion.Name      = "lblObservacion";
            this.lblObservacion.TabIndex  = 9;
            this.lblObservacion.Text      = "Observación:";

            //
            // txtObservacion
            //
            this.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacion.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtObservacion.Location    = new System.Drawing.Point(30, 343);
            this.txtObservacion.Multiline   = true;
            this.txtObservacion.Name        = "txtObservacion";
            this.txtObservacion.ScrollBars  = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacion.Size        = new System.Drawing.Size(500, 90);
            this.txtObservacion.TabIndex    = 10;

            //
            // btnGuardar
            //
            this.btnGuardar.BackColor                 = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnGuardar.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font                      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor                 = System.Drawing.Color.White;
            this.btnGuardar.IconChar                  = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnGuardar.IconColor                 = System.Drawing.Color.White;
            this.btnGuardar.IconFont                  = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize                  = 22;
            this.btnGuardar.Location                  = new System.Drawing.Point(30, 455);
            this.btnGuardar.Name                      = "btnGuardar";
            this.btnGuardar.Size                      = new System.Drawing.Size(235, 46);
            this.btnGuardar.TabIndex                  = 11;
            this.btnGuardar.Text                      = " Guardar";
            this.btnGuardar.TextImageRelation         = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor   = false;
            this.btnGuardar.Click                    += new System.EventHandler(this.btnGuardar_Click);

            //
            // btnCancelar
            //
            this.btnCancelar.BackColor                 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancelar.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font                      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor                 = System.Drawing.Color.White;
            this.btnCancelar.IconChar                  = FontAwesome.Sharp.IconChar.Xmark;
            this.btnCancelar.IconColor                 = System.Drawing.Color.White;
            this.btnCancelar.IconFont                  = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar.IconSize                  = 22;
            this.btnCancelar.Location                  = new System.Drawing.Point(295, 455);
            this.btnCancelar.Name                      = "btnCancelar";
            this.btnCancelar.Size                      = new System.Drawing.Size(235, 46);
            this.btnCancelar.TabIndex                  = 12;
            this.btnCancelar.Text                      = " Cancelar";
            this.btnCancelar.TextImageRelation         = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor   = false;
            this.btnCancelar.Click                    += new System.EventHandler(this.btnCancelar_Click);

            //
            // FrmTransferenciaModal
            //
            this.BackColor       = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ClientSize      = new System.Drawing.Size(560, 530);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.cboProducto);
            this.Controls.Add(this.lblBodegaOrigen);
            this.Controls.Add(this.cboBodegaOrigen);
            this.Controls.Add(this.lblBodegaDestino);
            this.Controls.Add(this.cboBodegaDestino);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblObservacion);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.Name            = "FrmTransferenciaModal";
            this.ShowInTaskbar   = false;
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "Nueva Transferencia";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // HEADER
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;

        // CAMPOS
        private System.Windows.Forms.Label    lblProducto;
        private System.Windows.Forms.ComboBox cboProducto;
        private System.Windows.Forms.Label    lblBodegaOrigen;
        private System.Windows.Forms.ComboBox cboBodegaOrigen;
        private System.Windows.Forms.Label    lblBodegaDestino;
        private System.Windows.Forms.ComboBox cboBodegaDestino;
        private System.Windows.Forms.Label    lblCantidad;
        private System.Windows.Forms.TextBox  txtCantidad;
        private System.Windows.Forms.Label    lblObservacion;
        private System.Windows.Forms.TextBox  txtObservacion;

        // BOTONES
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnCancelar;
    }
}
