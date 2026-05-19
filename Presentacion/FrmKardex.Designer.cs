using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Inventario.Presentacion
{
    partial class FrmKardex
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

            this.label1 =
                new Label();

            this.cboProducto =
                new ComboBox();

            this.btnBuscar =
                new IconButton();

            this.btnRecargar =
                new IconButton();

            this.dgvKardex =
                new DataGridView();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvKardex))
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
                "FrmKardex";

            this.Load +=
                new System.EventHandler(
                    this.FrmKardex_Load);

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
                "Kardex de Inventario";

            // =====================================
            // LABEL PRODUCTO
            // =====================================

            label1.AutoSize = true;

            label1.Font =
                new Font(
                    "Segoe UI Semibold",
                    13F,
                    FontStyle.Bold);

            label1.Location =
                new Point(60, 145);

            label1.Text =
                "Producto";

            // =====================================
            // COMBO PRODUCTO
            // =====================================

            cboProducto.Font =
                new Font(
                    "Segoe UI",
                    12F);

            cboProducto.Location =
                new Point(60, 185);

            cboProducto.Size =
                new Size(420, 38);

            cboProducto.DropDownStyle =
                ComboBoxStyle.DropDownList;

            // =====================================
            // BTN BUSCAR
            // =====================================

            ConfigurarBoton(
                btnBuscar,
                " Filtrar",
                IconChar.Search,
                Color.FromArgb(52, 152, 219),
                520);

            // =====================================
            // BTN RECARGAR
            // =====================================

            ConfigurarBoton(
                btnRecargar,
                " Mostrar Todo",
                IconChar.Rotate,
                Color.FromArgb(46, 204, 113),
                730);

            // =====================================
            // GRID
            // =====================================

            dgvKardex.AllowUserToAddRows =
                false;

            dgvKardex.AllowUserToDeleteRows =
                false;

            dgvKardex.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvKardex.BackgroundColor =
                Color.White;

            dgvKardex.BorderStyle =
                BorderStyle.None;

            dgvKardex.Location =
                new Point(60, 290);

            dgvKardex.Size =
                new Size(1320, 520);

            dgvKardex.ReadOnly = true;

            dgvKardex.RowHeadersVisible =
                false;

            dgvKardex.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvKardex.EnableHeadersVisualStyles =
                false;

            dgvKardex.ColumnHeadersHeight = 45;

            headerStyle.BackColor =
                Color.FromArgb(10, 35, 66);

            headerStyle.ForeColor =
                Color.White;

            headerStyle.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            dgvKardex.ColumnHeadersDefaultCellStyle =
                headerStyle;

            rowsStyle.Font =
                new Font(
                    "Segoe UI",
                    10F);

            rowsStyle.SelectionBackColor =
                Color.FromArgb(52, 152, 219);

            rowsStyle.SelectionForeColor =
                Color.White;

            dgvKardex.RowsDefaultCellStyle =
                rowsStyle;

            // =====================================
            // EVENTOS
            // =====================================

            btnBuscar.Click +=
                new System.EventHandler(
                    this.btnBuscar_Click);

            btnRecargar.Click +=
                new System.EventHandler(
                    this.btnRecargar_Click);

            // =====================================
            // CONTROLES
            // =====================================

            this.Controls.Add(lblTitulo);

            this.Controls.Add(label1);

            this.Controls.Add(cboProducto);

            this.Controls.Add(btnBuscar);

            this.Controls.Add(btnRecargar);

            this.Controls.Add(dgvKardex);

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvKardex))
                .EndInit();

            this.ResumeLayout(false);

            this.PerformLayout();
        }

        // =====================================
        // CONFIG BOTONES
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
                new Size(180, 58);

            boton.Location =
                new Point(x, 175);

            boton.Cursor =
                Cursors.Hand;
        }

        #endregion

        private Label lblTitulo;

        private Label label1;

        private ComboBox cboProducto;

        private IconButton btnBuscar;

        private IconButton btnRecargar;

        private DataGridView dgvKardex;
    }
}