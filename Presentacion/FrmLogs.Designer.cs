namespace Sistema_Inventario.Presentacion
{
    partial class FrmLogs
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblEvento = new System.Windows.Forms.Label();
            this.cboEvento = new System.Windows.Forms.ComboBox();

            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.btnRefrescar = new FontAwesome.Sharp.IconButton();
            this.btnExportar = new FontAwesome.Sharp.IconButton();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();

            this.dgvLogs = new System.Windows.Forms.DataGridView();

            this.lblTotalLogs = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();

            this.SuspendLayout();

            // =====================================================
            // FORM
            // =====================================================

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.FromArgb(240, 242, 245);

            this.ClientSize =
                new System.Drawing.Size(1600, 860);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.None;

            this.Name = "FrmLogs";

            this.Text = "FrmLogs";

            this.Load +=
                new System.EventHandler(this.FrmLogs_Load);

            // =====================================================
            // TITULO
            // =====================================================

            this.lblTitulo.AutoSize = true;

            this.lblTitulo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    26F,
                    System.Drawing.FontStyle.Bold);

            this.lblTitulo.ForeColor =
                System.Drawing.Color.FromArgb(5, 35, 85);

            this.lblTitulo.Location =
                new System.Drawing.Point(40, 30);

            this.lblTitulo.Text =
                "Gestión de Logs";

            // =====================================================
            // LABEL BUSCAR
            // =====================================================

            this.lblBuscar.AutoSize = true;

            this.lblBuscar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold);

            this.lblBuscar.Location =
                new System.Drawing.Point(50, 130);

            this.lblBuscar.Text =
                "Buscar";

            // =====================================================
            // TXT BUSCAR
            // =====================================================

            this.txtBuscar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F);

            this.txtBuscar.Location =
                new System.Drawing.Point(50, 165);

            this.txtBuscar.Size =
                new System.Drawing.Size(300, 32);

            // =====================================================
            // LABEL EVENTO
            // =====================================================

            this.lblEvento.AutoSize = true;

            this.lblEvento.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold);

            this.lblEvento.Location =
                new System.Drawing.Point(390, 130);

            this.lblEvento.Text =
                "Evento";

            // =====================================================
            // COMBO EVENTO
            // =====================================================

            this.cboEvento.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F);

            this.cboEvento.Location =
                new System.Drawing.Point(390, 165);

            this.cboEvento.Size =
                new System.Drawing.Size(240, 33);

            this.cboEvento.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            // =====================================================
            // BOTON BUSCAR
            // =====================================================

            this.btnBuscar.BackColor =
                System.Drawing.Color.FromArgb(52, 152, 219);

            this.btnBuscar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnBuscar.FlatAppearance.BorderSize = 0;

            this.btnBuscar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold);

            this.btnBuscar.ForeColor =
                System.Drawing.Color.White;

            this.btnBuscar.IconChar =
                FontAwesome.Sharp.IconChar.MagnifyingGlass;

            this.btnBuscar.IconColor =
                System.Drawing.Color.White;

            this.btnBuscar.IconFont =
                FontAwesome.Sharp.IconFont.Auto;

            this.btnBuscar.IconSize = 28;

            this.btnBuscar.ImageAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            this.btnBuscar.Location =
                new System.Drawing.Point(700, 150);

            this.btnBuscar.Size =
                new System.Drawing.Size(150, 50);

            this.btnBuscar.Text =
                "Buscar";

            this.btnBuscar.TextImageRelation =
                System.Windows.Forms.TextImageRelation.ImageBeforeText;

            // =====================================================
            // BOTON REFRESCAR
            // =====================================================

            this.btnRefrescar.BackColor =
                System.Drawing.Color.FromArgb(46, 204, 113);

            this.btnRefrescar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnRefrescar.FlatAppearance.BorderSize = 0;

            this.btnRefrescar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold);

            this.btnRefrescar.ForeColor =
                System.Drawing.Color.White;

            this.btnRefrescar.IconChar =
                FontAwesome.Sharp.IconChar.Rotate;

            this.btnRefrescar.IconColor =
                System.Drawing.Color.White;

            this.btnRefrescar.IconFont =
                FontAwesome.Sharp.IconFont.Auto;

            this.btnRefrescar.IconSize = 28;

            this.btnRefrescar.ImageAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            this.btnRefrescar.Location =
                new System.Drawing.Point(870, 150);

            this.btnRefrescar.Size =
                new System.Drawing.Size(160, 50);

            this.btnRefrescar.Text =
                "Refrescar";

            this.btnRefrescar.TextImageRelation =
                System.Windows.Forms.TextImageRelation.ImageBeforeText;

            // =====================================================
            // BOTON EXPORTAR
            // =====================================================

            this.btnExportar.BackColor =
                System.Drawing.Color.FromArgb(155, 89, 182);

            this.btnExportar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnExportar.FlatAppearance.BorderSize = 0;

            this.btnExportar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold);

            this.btnExportar.ForeColor =
                System.Drawing.Color.White;

            this.btnExportar.IconChar =
                FontAwesome.Sharp.IconChar.FileExport;

            this.btnExportar.IconColor =
                System.Drawing.Color.White;

            this.btnExportar.IconFont =
                FontAwesome.Sharp.IconFont.Auto;

            this.btnExportar.IconSize = 28;

            this.btnExportar.ImageAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            this.btnExportar.Location =
                new System.Drawing.Point(1050, 150);

            this.btnExportar.Size =
                new System.Drawing.Size(160, 50);

            this.btnExportar.Text =
                "Exportar";

            this.btnExportar.TextImageRelation =
                System.Windows.Forms.TextImageRelation.ImageBeforeText;

            // =====================================================
            // BOTON LIMPIAR
            // =====================================================

            this.btnLimpiar.BackColor =
                System.Drawing.Color.FromArgb(231, 76, 60);

            this.btnLimpiar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnLimpiar.FlatAppearance.BorderSize = 0;

            this.btnLimpiar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold);

            this.btnLimpiar.ForeColor =
                System.Drawing.Color.White;

            this.btnLimpiar.IconChar =
                FontAwesome.Sharp.IconChar.Trash;

            this.btnLimpiar.IconColor =
                System.Drawing.Color.White;

            this.btnLimpiar.IconFont =
                FontAwesome.Sharp.IconFont.Auto;

            this.btnLimpiar.IconSize = 28;

            this.btnLimpiar.ImageAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            this.btnLimpiar.Location =
                new System.Drawing.Point(1225, 150);

            this.btnLimpiar.Size =
                new System.Drawing.Size(160, 50);

            this.btnLimpiar.Text =
                "Limpiar";

            this.btnLimpiar.TextImageRelation =
                System.Windows.Forms.TextImageRelation.ImageBeforeText;

            // =====================================================
            // TOTAL LOGS
            // =====================================================

            this.lblTotalLogs.AutoSize = true;

            this.lblTotalLogs.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    13F,
                    System.Drawing.FontStyle.Bold);

            this.lblTotalLogs.ForeColor =
                System.Drawing.Color.FromArgb(5, 35, 85);

            this.lblTotalLogs.Location =
                new System.Drawing.Point(50, 230);

            this.lblTotalLogs.Text =
                "Total Logs: 0";

            // =====================================================
            // DATAGRIDVIEW
            // =====================================================

            this.dgvLogs.AllowUserToAddRows = false;

            this.dgvLogs.AllowUserToDeleteRows = false;

            this.dgvLogs.AllowUserToResizeRows = false;

            this.dgvLogs.Anchor =
                ((System.Windows.Forms.AnchorStyles)(
                ((System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right));

            this.dgvLogs.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvLogs.BackgroundColor =
                System.Drawing.Color.White;

            this.dgvLogs.BorderStyle =
                System.Windows.Forms.BorderStyle.None;

            this.dgvLogs.CellBorderStyle =
                System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;

            this.dgvLogs.ColumnHeadersBorderStyle =
                System.Windows.Forms.DataGridViewHeaderBorderStyle.None;

            this.dgvLogs.ColumnHeadersHeight = 48;

            this.dgvLogs.EnableHeadersVisualStyles = false;

            this.dgvLogs.GridColor =
                System.Drawing.Color.FromArgb(230, 230, 230);

            this.dgvLogs.Location =
                new System.Drawing.Point(40, 280);

            this.dgvLogs.MultiSelect = false;

            this.dgvLogs.Name = "dgvLogs";

            this.dgvLogs.ReadOnly = true;

            this.dgvLogs.RowHeadersVisible = false;

            this.dgvLogs.RowTemplate.Height = 42;

            this.dgvLogs.ScrollBars =
                System.Windows.Forms.ScrollBars.Vertical;

            this.dgvLogs.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvLogs.Size =
                new System.Drawing.Size(1520, 540);

            this.dgvLogs.TabIndex = 0;

            // =====================================================
            // HEADER STYLE
            // =====================================================

            this.dgvLogs.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(5, 35, 85);

            this.dgvLogs.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;

            this.dgvLogs.ColumnHeadersDefaultCellStyle.Alignment =
                System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;

            this.dgvLogs.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold);

            // =====================================================
            // FILAS
            // =====================================================

            this.dgvLogs.DefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10.5F);

            this.dgvLogs.DefaultCellStyle.SelectionBackColor =
                System.Drawing.Color.FromArgb(52, 152, 219);

            this.dgvLogs.DefaultCellStyle.SelectionForeColor =
                System.Drawing.Color.White;

            this.dgvLogs.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(245, 245, 245);

            // =====================================================
            // CONTROLES
            // =====================================================

            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblEvento);
            this.Controls.Add(this.cboEvento);

            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnLimpiar);

            this.Controls.Add(this.lblTotalLogs);

            this.Controls.Add(this.dgvLogs);

            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();

            this.ResumeLayout(false);

            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLogs;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblEvento;
        private System.Windows.Forms.ComboBox cboEvento;

        private FontAwesome.Sharp.IconButton btnBuscar;
        private FontAwesome.Sharp.IconButton btnRefrescar;
        private FontAwesome.Sharp.IconButton btnExportar;
        private FontAwesome.Sharp.IconButton btnLimpiar;

        private System.Windows.Forms.Label lblTotalLogs;
    }
}