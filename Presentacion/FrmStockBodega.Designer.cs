using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Inventario.Presentacion
{
    partial class FrmStockBodega
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(
            bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle headerStyle =
                new DataGridViewCellStyle();

            DataGridViewCellStyle rowsStyle =
                new DataGridViewCellStyle();

            this.lblTitulo =
                new Label();

            this.btnRecargar =
                new IconButton();

            this.btnStockBajo =
                new IconButton();

            this.btnExportar =
                new IconButton();

            this.dgvStock =
                new DataGridView();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvStock))
                .BeginInit();

            this.SuspendLayout();

            // =====================================
            // FORM
            // =====================================

            this.BackColor =
                Color.FromArgb(236, 240, 245);

            this.ClientSize =
                new Size(1450, 900);

            this.FormBorderStyle =
                FormBorderStyle.None;

            this.Text =
                "FrmStockBodega";

            this.Load +=
                new System.EventHandler(
                    this.FrmStockBodega_Load);

            // =====================================
            // TITULO
            // =====================================

            lblTitulo.AutoSize = true;

            lblTitulo.Font =
                new Font(
                    "Segoe UI",
                    30F,
                    FontStyle.Bold);

            lblTitulo.ForeColor =
                Color.FromArgb(10, 35, 66);

            lblTitulo.Location =
                new Point(50, 35);

            lblTitulo.Text =
                "Stock por Bodega";

            // =====================================
            // BTN RECARGAR
            // =====================================

            ConfigurarBoton(
                btnRecargar,
                " Recargar",
                IconChar.Rotate,
                Color.FromArgb(52, 152, 219),
                60);

            // =====================================
            // BTN STOCK BAJO
            // =====================================

            ConfigurarBoton(
                btnStockBajo,
                " Stock Bajo",
                IconChar.TriangleExclamation,
                Color.FromArgb(231, 76, 60),
                290);
            ConfigurarBoton(
    btnExportar,
    " Exportar Excel",
    IconChar.FileExcel,
    Color.FromArgb(39, 174, 96),
    520);
            // =====================================
            // GRID
            // =====================================

            dgvStock.AllowUserToAddRows =
                false;

            dgvStock.AllowUserToDeleteRows =
                false;

            dgvStock.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvStock.BackgroundColor =
                Color.White;

            dgvStock.BorderStyle =
                BorderStyle.None;

            dgvStock.Location =
                new Point(60, 180);

            dgvStock.Size =
                new Size(1320, 620);

            dgvStock.ReadOnly = true;

            dgvStock.RowHeadersVisible =
                false;

            dgvStock.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvStock.EnableHeadersVisualStyles =
                false;

            dgvStock.ColumnHeadersHeight = 45;

            headerStyle.BackColor =
                Color.FromArgb(10, 35, 66);

            headerStyle.ForeColor =
                Color.White;

            headerStyle.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            dgvStock.ColumnHeadersDefaultCellStyle =
                headerStyle;

            rowsStyle.Font =
                new Font(
                    "Segoe UI",
                    10F);

            rowsStyle.SelectionBackColor =
                Color.FromArgb(52, 152, 219);

            rowsStyle.SelectionForeColor =
                Color.White;

            dgvStock.RowsDefaultCellStyle =
                rowsStyle;

            // =====================================
            // EVENTOS
            // =====================================

            btnRecargar.Click +=
                new System.EventHandler(
                    this.btnRecargar_Click);

            btnStockBajo.Click +=
                new System.EventHandler(
                    this.btnStockBajo_Click);

            btnExportar.Click +=
    new System.EventHandler(
        this.btnExportar_Click);
            // =====================================
            // CONTROLES
            // =====================================

            this.Controls.Add(lblTitulo);

            this.Controls.Add(btnRecargar);

            this.Controls.Add(btnStockBajo);

            this.Controls.Add(btnExportar);

            this.Controls.Add(dgvStock);

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvStock))
                .EndInit();

            this.ResumeLayout(false);

            this.PerformLayout();
        }

        // =====================================
        // BOTONES
        // =====================================

        private void ConfigurarBoton(
            IconButton boton,
            string texto,
            IconChar icono,
            Color color,
            int x)
        {
            boton.BackColor =
                color;

            boton.FlatStyle =
                FlatStyle.Flat;

            boton.FlatAppearance.BorderSize = 0;

            boton.ForeColor =
                Color.White;

            boton.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            boton.IconChar =
                icono;

            boton.IconColor =
                Color.White;

            boton.IconFont =
                IconFont.Auto;

            boton.IconSize = 28;

            boton.Text =
                texto;

            boton.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            boton.Size =
                new Size(190, 58);

            boton.Location =
                new Point(x, 100);

            boton.Cursor =
                Cursors.Hand;
        }

        #endregion

        private Label lblTitulo;

        private IconButton btnRecargar;

        private IconButton btnStockBajo;

        private IconButton btnExportar;

        private DataGridView dgvStock;
    }
}