// IMPORTACION DE LIBRERIAS NECESARIAS
using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Inventario.Presentacion
{
    // CLASE PARCIAL DEL FORMULARIO KARDEX
    partial class FrmKardex
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlSep1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboProducto = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.btnRecargar = new FontAwesome.Sharp.IconButton();
            this.btnExportar = new FontAwesome.Sharp.IconButton();
            this.pnlSep2 = new System.Windows.Forms.Panel();
            this.dgvKardex = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardex)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(35)))), ((int)(((byte)(66)))));
            this.lblTitulo.Location = new System.Drawing.Point(50, 22);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(461, 60);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Kardex de Inventario";
            // 
            // pnlSep1
            // 
            this.pnlSep1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(35)))), ((int)(((byte)(66)))));
            this.pnlSep1.Location = new System.Drawing.Point(50, 82);
            this.pnlSep1.Name = "pnlSep1";
            this.pnlSep1.Size = new System.Drawing.Size(1255, 2);
            this.pnlSep1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(50, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filtrar por Producto:";
            // 
            // cboProducto
            // 
            this.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProducto.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboProducto.Location = new System.Drawing.Point(258, 108);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(360, 33);
            this.cboProducto.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnBuscar.IconColor = System.Drawing.Color.White;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 24;
            this.btnBuscar.Location = new System.Drawing.Point(635, 101);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(155, 46);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = " Filtrar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnRecargar
            // 
            this.btnRecargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnRecargar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecargar.FlatAppearance.BorderSize = 0;
            this.btnRecargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecargar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnRecargar.ForeColor = System.Drawing.Color.White;
            this.btnRecargar.IconChar = FontAwesome.Sharp.IconChar.SyncAlt;
            this.btnRecargar.IconColor = System.Drawing.Color.White;
            this.btnRecargar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRecargar.IconSize = 24;
            this.btnRecargar.Location = new System.Drawing.Point(804, 101);
            this.btnRecargar.Name = "btnRecargar";
            this.btnRecargar.Size = new System.Drawing.Size(185, 46);
            this.btnRecargar.TabIndex = 5;
            this.btnRecargar.Text = " Mostrar Todo";
            this.btnRecargar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRecargar.UseVisualStyleBackColor = false;
            this.btnRecargar.Click += new System.EventHandler(this.btnRecargar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            this.btnExportar.IconColor = System.Drawing.Color.White;
            this.btnExportar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExportar.IconSize = 24;
            this.btnExportar.Location = new System.Drawing.Point(1003, 101);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(200, 46);
            this.btnExportar.TabIndex = 6;
            this.btnExportar.Text = " Exportar Excel";
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // pnlSep2
            // 
            this.pnlSep2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(215)))), ((int)(((byte)(220)))));
            this.pnlSep2.Location = new System.Drawing.Point(30, 162);
            this.pnlSep2.Name = "pnlSep2";
            this.pnlSep2.Size = new System.Drawing.Size(1290, 1);
            this.pnlSep2.TabIndex = 7;
            // 
            // dgvKardex
            // 
            this.dgvKardex.AllowUserToAddRows = false;
            this.dgvKardex.AllowUserToDeleteRows = false;
            this.dgvKardex.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.dgvKardex.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKardex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKardex.BackgroundColor = System.Drawing.Color.White;
            this.dgvKardex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKardex.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(35)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.dgvKardex.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKardex.ColumnHeadersHeight = 45;
            this.dgvKardex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(4);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKardex.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvKardex.EnableHeadersVisualStyles = false;
            this.dgvKardex.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.dgvKardex.Location = new System.Drawing.Point(30, 170);
            this.dgvKardex.MultiSelect = false;
            this.dgvKardex.Name = "dgvKardex";
            this.dgvKardex.ReadOnly = true;
            this.dgvKardex.RowHeadersVisible = false;
            this.dgvKardex.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgvKardex.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvKardex.RowTemplate.Height = 38;
            this.dgvKardex.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKardex.Size = new System.Drawing.Size(1290, 660);
            this.dgvKardex.TabIndex = 8;
            this.dgvKardex.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKardex_CellContentClick);
            // 
            // FrmKardex
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1350, 860);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlSep1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboProducto);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnRecargar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.pnlSep2);
            this.Controls.Add(this.dgvKardex);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmKardex";
            this.Text = "FrmKardex";
            this.Load += new System.EventHandler(this.FrmKardex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // TITULO
        private Label lblTitulo;

        // SEPARADORES
        private Panel pnlSep1;
        private Panel pnlSep2;

        // FILTROS
        private Label    label1;
        private ComboBox cboProducto;

        // BOTONES
        private IconButton btnBuscar;
        private IconButton btnRecargar;
        private IconButton btnExportar;

        // DATAGRIDVIEW
        private DataGridView dgvKardex;
    }
}
