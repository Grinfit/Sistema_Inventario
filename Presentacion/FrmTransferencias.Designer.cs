// IMPORTACION DE LIBRERIAS NECESARIAS
using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Inventario.Presentacion
{
    // CLASE PARCIAL DEL FORMULARIO DE TRANSFERENCIAS
    partial class FrmTransferencias
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
            this.lblTitulo         = new System.Windows.Forms.Label();
            this.pnlSep1           = new System.Windows.Forms.Panel();
            this.btnNuevo          = new FontAwesome.Sharp.IconButton();
            this.txtBuscar         = new System.Windows.Forms.TextBox();
            this.btnFiltrar        = new FontAwesome.Sharp.IconButton();
            this.btnRecargar       = new FontAwesome.Sharp.IconButton();
            this.btnExportar       = new FontAwesome.Sharp.IconButton();
            this.pnlSep2           = new System.Windows.Forms.Panel();
            this.dgvTransferencias = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferencias)).BeginInit();
            this.SuspendLayout();

            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize  = true;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(35)))), ((int)(((byte)(66)))));
            this.lblTitulo.Location  = new System.Drawing.Point(50, 22);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.Size      = new System.Drawing.Size(560, 57);
            this.lblTitulo.TabIndex  = 0;
            this.lblTitulo.Text      = "Transferencias de Inventario";

            //
            // pnlSep1
            //
            this.pnlSep1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(35)))), ((int)(((byte)(66)))));
            this.pnlSep1.Location  = new System.Drawing.Point(30, 90);
            this.pnlSep1.Name      = "pnlSep1";
            this.pnlSep1.Size      = new System.Drawing.Size(1290, 2);
            this.pnlSep1.TabIndex  = 1;

            //
            // btnNuevo  —  "Nueva Transferencia"
            //
            this.btnNuevo.BackColor                 = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnNuevo.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font                      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor                 = System.Drawing.Color.White;
            this.btnNuevo.IconChar                  = FontAwesome.Sharp.IconChar.CirclePlus;
            this.btnNuevo.IconColor                 = System.Drawing.Color.White;
            this.btnNuevo.IconFont                  = FontAwesome.Sharp.IconFont.Auto;
            this.btnNuevo.IconSize                  = 24;
            this.btnNuevo.Location                  = new System.Drawing.Point(50, 101);
            this.btnNuevo.Name                      = "btnNuevo";
            this.btnNuevo.Size                      = new System.Drawing.Size(220, 46);
            this.btnNuevo.TabIndex                  = 2;
            this.btnNuevo.Text                      = " Nueva Transferencia";
            this.btnNuevo.TextImageRelation         = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor   = false;
            this.btnNuevo.Click                    += new System.EventHandler(this.btnNuevo_Click);

            //
            // txtBuscar
            //
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtBuscar.Location    = new System.Drawing.Point(538, 107);
            this.txtBuscar.Name        = "txtBuscar";
            this.txtBuscar.Size        = new System.Drawing.Size(272, 32);
            this.txtBuscar.TabIndex    = 3;

            //
            // btnFiltrar
            //
            this.btnFiltrar.BackColor                 = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnFiltrar.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font                      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnFiltrar.ForeColor                 = System.Drawing.Color.White;
            this.btnFiltrar.IconChar                  = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnFiltrar.IconColor                 = System.Drawing.Color.White;
            this.btnFiltrar.IconFont                  = FontAwesome.Sharp.IconFont.Auto;
            this.btnFiltrar.IconSize                  = 24;
            this.btnFiltrar.Location                  = new System.Drawing.Point(818, 101);
            this.btnFiltrar.Name                      = "btnFiltrar";
            this.btnFiltrar.Size                      = new System.Drawing.Size(140, 46);
            this.btnFiltrar.TabIndex                  = 4;
            this.btnFiltrar.Text                      = " Filtrar";
            this.btnFiltrar.TextImageRelation         = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFiltrar.UseVisualStyleBackColor   = false;
            this.btnFiltrar.Click                    += new System.EventHandler(this.btnFiltrar_Click);

            //
            // btnRecargar
            //
            this.btnRecargar.BackColor                 = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnRecargar.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnRecargar.FlatAppearance.BorderSize = 0;
            this.btnRecargar.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecargar.Font                      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnRecargar.ForeColor                 = System.Drawing.Color.White;
            this.btnRecargar.IconChar                  = FontAwesome.Sharp.IconChar.SyncAlt;
            this.btnRecargar.IconColor                 = System.Drawing.Color.White;
            this.btnRecargar.IconFont                  = FontAwesome.Sharp.IconFont.Auto;
            this.btnRecargar.IconSize                  = 24;
            this.btnRecargar.Location                  = new System.Drawing.Point(966, 101);
            this.btnRecargar.Name                      = "btnRecargar";
            this.btnRecargar.Size                      = new System.Drawing.Size(160, 46);
            this.btnRecargar.TabIndex                  = 5;
            this.btnRecargar.Text                      = " Mostrar Todo";
            this.btnRecargar.TextImageRelation         = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRecargar.UseVisualStyleBackColor   = false;
            this.btnRecargar.Click                    += new System.EventHandler(this.btnRecargar_Click);

            //
            // btnExportar
            //
            this.btnExportar.BackColor                 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnExportar.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font                      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor                 = System.Drawing.Color.White;
            this.btnExportar.IconChar                  = FontAwesome.Sharp.IconChar.FileExcel;
            this.btnExportar.IconColor                 = System.Drawing.Color.White;
            this.btnExportar.IconFont                  = FontAwesome.Sharp.IconFont.Auto;
            this.btnExportar.IconSize                  = 24;
            this.btnExportar.Location                  = new System.Drawing.Point(1134, 101);
            this.btnExportar.Name                      = "btnExportar";
            this.btnExportar.Size                      = new System.Drawing.Size(186, 46);
            this.btnExportar.TabIndex                  = 6;
            this.btnExportar.Text                      = " Exportar Excel";
            this.btnExportar.TextImageRelation         = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.UseVisualStyleBackColor   = false;
            this.btnExportar.Click                    += new System.EventHandler(this.btnExportar_Click);

            //
            // pnlSep2
            //
            this.pnlSep2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(215)))), ((int)(((byte)(220)))));
            this.pnlSep2.Location  = new System.Drawing.Point(30, 160);
            this.pnlSep2.Name      = "pnlSep2";
            this.pnlSep2.Size      = new System.Drawing.Size(1290, 1);
            this.pnlSep2.TabIndex  = 7;

            //
            // dgvTransferencias
            //
            this.dgvTransferencias.AllowUserToAddRows    = false;
            this.dgvTransferencias.AllowUserToDeleteRows = false;
            this.dgvTransferencias.AllowUserToResizeRows = false;
            this.dgvTransferencias.Anchor = ((System.Windows.Forms.AnchorStyles)(
                (System.Windows.Forms.AnchorStyles.Top    |
                 System.Windows.Forms.AnchorStyles.Bottom |
                 System.Windows.Forms.AnchorStyles.Left   |
                 System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransferencias.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvTransferencias.BackgroundColor             = System.Drawing.Color.White;
            this.dgvTransferencias.BorderStyle                 = System.Windows.Forms.BorderStyle.None;
            this.dgvTransferencias.ColumnHeadersHeight         = 45;
            this.dgvTransferencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTransferencias.Location                    = new System.Drawing.Point(30, 170);
            this.dgvTransferencias.MultiSelect                 = false;
            this.dgvTransferencias.Name                        = "dgvTransferencias";
            this.dgvTransferencias.ReadOnly                    = true;
            this.dgvTransferencias.RowHeadersVisible           = false;
            this.dgvTransferencias.RowHeadersWidth             = 51;
            this.dgvTransferencias.RowTemplate.Height          = 38;
            this.dgvTransferencias.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransferencias.Size                        = new System.Drawing.Size(1290, 668);
            this.dgvTransferencias.TabIndex                    = 8;

            //
            // FrmTransferencias
            //
            this.BackColor       = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ClientSize      = new System.Drawing.Size(1350, 860);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlSep1);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.btnRecargar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.pnlSep2);
            this.Controls.Add(this.dgvTransferencias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name            = "FrmTransferencias";
            this.Text            = "FrmTransferencias";
            this.Load           += new System.EventHandler(this.FrmTransferencias_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferencias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // TITULO Y SEPARADORES
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlSep1;
        private System.Windows.Forms.Panel pnlSep2;

        // BARRA DE ACCIONES
        private FontAwesome.Sharp.IconButton btnNuevo;
        private System.Windows.Forms.TextBox txtBuscar;
        private FontAwesome.Sharp.IconButton btnFiltrar;
        private FontAwesome.Sharp.IconButton btnRecargar;
        private FontAwesome.Sharp.IconButton btnExportar;

        // DATAGRIDVIEW
        private System.Windows.Forms.DataGridView dgvTransferencias;
    }
}
