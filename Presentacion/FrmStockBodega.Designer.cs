// IMPORTACION DE LIBRERIAS NECESARIAS
using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Inventario.Presentacion
{
    // CLASE PARCIAL DEL FORMULARIO STOCK POR BODEGA
    partial class FrmStockBodega
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
            this.lblTitulo    = new System.Windows.Forms.Label();
            this.pnlSep1      = new System.Windows.Forms.Panel();
            this.label1       = new System.Windows.Forms.Label();
            this.cboProducto  = new System.Windows.Forms.ComboBox();
            this.btnBuscar    = new FontAwesome.Sharp.IconButton();
            this.btnRecargar  = new FontAwesome.Sharp.IconButton();
            this.btnStockBajo = new FontAwesome.Sharp.IconButton();
            this.btnExportar  = new FontAwesome.Sharp.IconButton();
            this.pnlSep2      = new System.Windows.Forms.Panel();
            this.dgvStock     = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.SuspendLayout();

            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize  = true;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(35)))), ((int)(((byte)(66)))));
            this.lblTitulo.Location  = new System.Drawing.Point(50, 22);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.Size      = new System.Drawing.Size(380, 57);
            this.lblTitulo.TabIndex  = 0;
            this.lblTitulo.Text      = "Stock por Bodega";

            //
            // pnlSep1
            //
            this.pnlSep1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(35)))), ((int)(((byte)(66)))));
            this.pnlSep1.Location  = new System.Drawing.Point(30, 90);
            this.pnlSep1.Name      = "pnlSep1";
            this.pnlSep1.Size      = new System.Drawing.Size(1290, 2);
            this.pnlSep1.TabIndex  = 1;

            //
            // label1
            //
            this.label1.AutoSize  = true;
            this.label1.Font      = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label1.Location  = new System.Drawing.Point(50, 113);
            this.label1.Name      = "label1";
            this.label1.Size      = new System.Drawing.Size(185, 25);
            this.label1.TabIndex  = 2;
            this.label1.Text      = "Filtrar por Producto:";

            //
            // cboProducto
            //
            this.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto.Font          = new System.Drawing.Font("Segoe UI", 11F);
            this.cboProducto.Location      = new System.Drawing.Point(252, 108);
            this.cboProducto.Name          = "cboProducto";
            this.cboProducto.Size          = new System.Drawing.Size(310, 33);
            this.cboProducto.TabIndex      = 3;

            //
            // btnBuscar
            //
            this.btnBuscar.BackColor                 = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnBuscar.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font                      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor                 = System.Drawing.Color.White;
            this.btnBuscar.IconChar                  = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscar.IconColor                 = System.Drawing.Color.White;
            this.btnBuscar.IconFont                  = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize                  = 24;
            this.btnBuscar.Location                  = new System.Drawing.Point(570, 101);
            this.btnBuscar.Name                      = "btnBuscar";
            this.btnBuscar.Size                      = new System.Drawing.Size(140, 46);
            this.btnBuscar.TabIndex                  = 4;
            this.btnBuscar.Text                      = " Filtrar";
            this.btnBuscar.TextImageRelation         = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor   = false;
            this.btnBuscar.Click                    += new System.EventHandler(this.btnBuscar_Click);

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
            this.btnRecargar.Location                  = new System.Drawing.Point(718, 101);
            this.btnRecargar.Name                      = "btnRecargar";
            this.btnRecargar.Size                      = new System.Drawing.Size(175, 46);
            this.btnRecargar.TabIndex                  = 5;
            this.btnRecargar.Text                      = " Mostrar Todo";
            this.btnRecargar.TextImageRelation         = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRecargar.UseVisualStyleBackColor   = false;
            this.btnRecargar.Click                    += new System.EventHandler(this.btnRecargar_Click);

            //
            // btnStockBajo
            //
            this.btnStockBajo.BackColor                 = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnStockBajo.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnStockBajo.FlatAppearance.BorderSize = 0;
            this.btnStockBajo.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockBajo.Font                      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnStockBajo.ForeColor                 = System.Drawing.Color.White;
            this.btnStockBajo.IconChar                  = FontAwesome.Sharp.IconChar.TriangleExclamation;
            this.btnStockBajo.IconColor                 = System.Drawing.Color.White;
            this.btnStockBajo.IconFont                  = FontAwesome.Sharp.IconFont.Auto;
            this.btnStockBajo.IconSize                  = 24;
            this.btnStockBajo.Location                  = new System.Drawing.Point(901, 101);
            this.btnStockBajo.Name                      = "btnStockBajo";
            this.btnStockBajo.Size                      = new System.Drawing.Size(175, 46);
            this.btnStockBajo.TabIndex                  = 6;
            this.btnStockBajo.Text                      = " Stock Bajo";
            this.btnStockBajo.TextImageRelation         = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStockBajo.UseVisualStyleBackColor   = false;
            this.btnStockBajo.Click                    += new System.EventHandler(this.btnStockBajo_Click);

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
            this.btnExportar.Location                  = new System.Drawing.Point(1084, 101);
            this.btnExportar.Name                      = "btnExportar";
            this.btnExportar.Size                      = new System.Drawing.Size(200, 46);
            this.btnExportar.TabIndex                  = 7;
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
            this.pnlSep2.TabIndex  = 8;

            //
            // dgvStock
            //
            this.dgvStock.AllowUserToAddRows    = false;
            this.dgvStock.AllowUserToDeleteRows = false;
            this.dgvStock.AllowUserToResizeRows = false;
            this.dgvStock.Anchor = ((System.Windows.Forms.AnchorStyles)(
                (System.Windows.Forms.AnchorStyles.Top    |
                 System.Windows.Forms.AnchorStyles.Bottom |
                 System.Windows.Forms.AnchorStyles.Left   |
                 System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStock.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStock.BackgroundColor             = System.Drawing.Color.White;
            this.dgvStock.BorderStyle                 = System.Windows.Forms.BorderStyle.None;
            this.dgvStock.ColumnHeadersHeight         = 45;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStock.Location                    = new System.Drawing.Point(30, 170);
            this.dgvStock.MultiSelect                 = false;
            this.dgvStock.Name                        = "dgvStock";
            this.dgvStock.ReadOnly                    = true;
            this.dgvStock.RowHeadersVisible           = false;
            this.dgvStock.RowHeadersWidth             = 51;
            this.dgvStock.RowTemplate.Height          = 38;
            this.dgvStock.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size                        = new System.Drawing.Size(1290, 668);
            this.dgvStock.TabIndex                    = 9;

            //
            // FrmStockBodega
            //
            this.BackColor       = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ClientSize      = new System.Drawing.Size(1350, 860);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlSep1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboProducto);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnRecargar);
            this.Controls.Add(this.btnStockBajo);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.pnlSep2);
            this.Controls.Add(this.dgvStock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name            = "FrmStockBodega";
            this.Text            = "FrmStockBodega";
            this.Load           += new System.EventHandler(this.FrmStockBodega_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // TITULO Y SEPARADORES
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlSep1;
        private System.Windows.Forms.Panel pnlSep2;

        // FILTROS
        private System.Windows.Forms.Label    label1;
        private System.Windows.Forms.ComboBox cboProducto;

        // BOTONES
        private FontAwesome.Sharp.IconButton btnBuscar;
        private FontAwesome.Sharp.IconButton btnRecargar;
        private FontAwesome.Sharp.IconButton btnStockBajo;
        private FontAwesome.Sharp.IconButton btnExportar;

        // DATAGRIDVIEW
        private System.Windows.Forms.DataGridView dgvStock;
    }
}
