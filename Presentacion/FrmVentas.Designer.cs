using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Sistema_Inventario.Presentacion
{
    partial class FrmVentas
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
            DataGridViewCellStyle headerStyle =
                new DataGridViewCellStyle();

            DataGridViewCellStyle rowsStyle =
                new DataGridViewCellStyle();

            this.lblTitulo = new Label();

            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label6 = new Label();
            this.label7 = new Label();

            this.cbClientes = new ComboBox();
            this.cbProductos = new ComboBox();

            this.txtCantidad = new TextBox();
            this.txtPrecio = new TextBox();
            this.txtTotal = new TextBox();

            this.btnNuevo = new IconButton();
            this.btnRegistrarVenta = new IconButton();

            this.dgvVentas = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();

            this.SuspendLayout();

            // =====================================================
            // FORMULARIO
            // =====================================================

            this.ClientSize =
                new Size(1350, 860);

            this.BackColor =
                Color.FromArgb(236, 240, 245);

            this.FormBorderStyle =
                FormBorderStyle.None;

            this.Name =
                "FrmVentas";

            this.Text =
                "FrmVentas";

            this.Load +=
                new System.EventHandler(this.FrmVentas_Load);

            // =====================================================
            // TITULO
            // =====================================================

            this.lblTitulo.AutoSize = true;

            this.lblTitulo.Font =
                new Font(
                    "Segoe UI",
                    30F,
                    FontStyle.Bold);

            this.lblTitulo.ForeColor =
                Color.FromArgb(10, 35, 66);

            this.lblTitulo.Location =
                new Point(50, 25);

            this.lblTitulo.Text =
                "Gestión de Ventas";

            // =====================================================
            // LABEL CLIENTE
            // =====================================================

            this.label2.AutoSize = true;

            this.label2.Font =
                new Font(
                    "Segoe UI Semibold",
                    13F,
                    FontStyle.Bold);

            this.label2.Location =
                new Point(60, 115);

            this.label2.Text =
                "Cliente";

            // =====================================================
            // COMBO CLIENTES
            // =====================================================

            this.cbClientes.Font =
                new Font(
                    "Segoe UI",
                    12F);

            this.cbClientes.Location =
                new Point(220, 110);

            this.cbClientes.Size =
                new Size(420, 36);

            this.cbClientes.DropDownStyle =
                ComboBoxStyle.DropDownList;

            // =====================================================
            // LABEL PRODUCTO
            // =====================================================

            this.label3.AutoSize = true;

            this.label3.Font =
                new Font(
                    "Segoe UI Semibold",
                    13F,
                    FontStyle.Bold);

            this.label3.Location =
                new Point(60, 185);

            this.label3.Text =
                "Producto";

            // =====================================================
            // COMBO PRODUCTOS
            // =====================================================

            this.cbProductos.Font =
                new Font(
                    "Segoe UI",
                    12F);

            this.cbProductos.Location =
                new Point(220, 180);

            this.cbProductos.Size =
                new Size(420, 36);

            this.cbProductos.DropDownStyle =
                ComboBoxStyle.DropDownList;

            this.cbProductos.SelectedIndexChanged +=
                new System.EventHandler(this.cbProductos_SelectedIndexChanged);

            // =====================================================
            // LABEL CANTIDAD
            // =====================================================

            this.label4.AutoSize = true;

            this.label4.Font =
                new Font(
                    "Segoe UI Semibold",
                    13F,
                    FontStyle.Bold);

            this.label4.Location =
                new Point(60, 260);

            this.label4.Text =
                "Cantidad";

            // =====================================================
            // TXT CANTIDAD
            // =====================================================

            this.txtCantidad.Font =
                new Font(
                    "Segoe UI",
                    12F);

            this.txtCantidad.Location =
                new Point(220, 255);

            this.txtCantidad.Size =
                new Size(160, 34);

            this.txtCantidad.BorderStyle =
                BorderStyle.FixedSingle;

            this.txtCantidad.TextAlign =
                HorizontalAlignment.Center;

            this.txtCantidad.TextChanged +=
                new System.EventHandler(this.txtCantidad_TextChanged);

            // =====================================================
            // LABEL PRECIO
            // =====================================================

            this.label7.AutoSize = true;

            this.label7.Font =
                new Font(
                    "Segoe UI Semibold",
                    13F,
                    FontStyle.Bold);

            this.label7.Location =
                new Point(470, 260);

            this.label7.Text =
                "Precio";

            // =====================================================
            // TXT PRECIO
            // =====================================================

            this.txtPrecio.Font =
                new Font(
                    "Segoe UI",
                    12F);

            this.txtPrecio.Location =
                new Point(580, 255);

            this.txtPrecio.Size =
                new Size(170, 34);

            this.txtPrecio.BorderStyle =
                BorderStyle.FixedSingle;

            this.txtPrecio.ReadOnly = true;

            this.txtPrecio.TextAlign =
                HorizontalAlignment.Center;

            // =====================================================
            // LABEL TOTAL
            // =====================================================

            this.label6.AutoSize = true;

            this.label6.Font =
                new Font(
                    "Segoe UI Semibold",
                    13F,
                    FontStyle.Bold);

            this.label6.Location =
                new Point(470, 330);

            this.label6.Text =
                "Total";

            // =====================================================
            // TXT TOTAL
            // =====================================================

            this.txtTotal.Font =
                new Font(
                    "Segoe UI",
                    12F);

            this.txtTotal.Location =
                new Point(580, 325);

            this.txtTotal.Size =
                new Size(170, 34);

            this.txtTotal.BorderStyle =
                BorderStyle.FixedSingle;

            this.txtTotal.ReadOnly = true;

            this.txtTotal.TextAlign =
                HorizontalAlignment.Center;

            // =====================================================
            // BTN NUEVO
            // =====================================================

            this.btnNuevo.BackColor =
                Color.FromArgb(52, 152, 219);

            this.btnNuevo.FlatStyle =
                FlatStyle.Flat;

            this.btnNuevo.FlatAppearance.BorderSize = 0;

            this.btnNuevo.ForeColor =
                Color.White;

            this.btnNuevo.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            this.btnNuevo.IconChar =
                IconChar.CirclePlus;

            this.btnNuevo.IconColor =
                Color.White;

            this.btnNuevo.IconFont =
                IconFont.Auto;

            this.btnNuevo.IconSize = 28;

            this.btnNuevo.Text =
                " Nuevo";

            this.btnNuevo.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            this.btnNuevo.Size =
                new Size(170, 58);

            this.btnNuevo.Location =
                new Point(260, 420);

            this.btnNuevo.Cursor =
                Cursors.Hand;

            this.btnNuevo.Click +=
                new System.EventHandler(this.btnNuevo_Click);

            // =====================================================
            // BTN REGISTRAR
            // =====================================================

            this.btnRegistrarVenta.BackColor =
                Color.FromArgb(46, 204, 113);

            this.btnRegistrarVenta.FlatStyle =
                FlatStyle.Flat;

            this.btnRegistrarVenta.FlatAppearance.BorderSize = 0;

            this.btnRegistrarVenta.ForeColor =
                Color.White;

            this.btnRegistrarVenta.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            this.btnRegistrarVenta.IconChar =
                IconChar.CartShopping;

            this.btnRegistrarVenta.IconColor =
                Color.White;

            this.btnRegistrarVenta.IconFont =
                IconFont.Auto;

            this.btnRegistrarVenta.IconSize = 28;

            this.btnRegistrarVenta.Text =
                " Registrar";

            this.btnRegistrarVenta.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            this.btnRegistrarVenta.Size =
                new Size(190, 58);

            this.btnRegistrarVenta.Location =
                new Point(470, 420);

            this.btnRegistrarVenta.Cursor =
                Cursors.Hand;

            this.btnRegistrarVenta.Click +=
                new System.EventHandler(this.btnRegistrarVenta_Click);

            // =====================================================
            // DATAGRIDVIEW
            // =====================================================

            this.dgvVentas.AllowUserToAddRows = false;

            this.dgvVentas.AllowUserToDeleteRows = false;

            this.dgvVentas.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvVentas.BackgroundColor =
                Color.White;

            this.dgvVentas.BorderStyle =
                BorderStyle.None;

            this.dgvVentas.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            this.dgvVentas.Location =
                new Point(40, 520);

            this.dgvVentas.Size =
                new Size(1500, 300);

            this.dgvVentas.ReadOnly = true;

            this.dgvVentas.RowHeadersVisible = false;

            this.dgvVentas.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            this.dgvVentas.MultiSelect = false;

            this.dgvVentas.EnableHeadersVisualStyles = false;

            this.dgvVentas.ColumnHeadersHeight = 45;

            this.dgvVentas.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            this.dgvVentas.RowTemplate.Height = 42;

            // =====================================================
            // HEADER STYLE
            // =====================================================

            headerStyle.BackColor =
                Color.FromArgb(10, 35, 66);

            headerStyle.ForeColor =
                Color.White;

            headerStyle.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            this.dgvVentas.ColumnHeadersDefaultCellStyle =
                headerStyle;

            // =====================================================
            // ROW STYLE
            // =====================================================

            rowsStyle.Font =
                new Font(
                    "Segoe UI",
                    10F);

            rowsStyle.SelectionBackColor =
                Color.FromArgb(52, 152, 219);

            rowsStyle.SelectionForeColor =
                Color.White;

            this.dgvVentas.RowsDefaultCellStyle =
                rowsStyle;

            this.dgvVentas.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 247, 250);

            this.dgvVentas.DefaultCellStyle.Padding =
                new Padding(5);

            this.dgvVentas.GridColor =
                Color.FromArgb(225, 225, 225);

            // =====================================================
            // CONTROLES
            // =====================================================

            this.Controls.Add(this.lblTitulo);

            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);

            this.Controls.Add(this.cbClientes);
            this.Controls.Add(this.cbProductos);

            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtTotal);

            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnRegistrarVenta);

            this.Controls.Add(this.dgvVentas);

            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();

            this.ResumeLayout(false);

            this.PerformLayout();
        }

        #endregion

        private Label lblTitulo;

        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label7;

        private ComboBox cbClientes;
        private ComboBox cbProductos;

        private TextBox txtCantidad;
        private TextBox txtPrecio;
        private TextBox txtTotal;

        private IconButton btnNuevo;
        private IconButton btnRegistrarVenta;

        private DataGridView dgvVentas;
    }
}