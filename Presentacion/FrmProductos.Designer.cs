using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Sistema_Inventario.Presentacion
{
    partial class FrmProductos
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
            // =====================================================
            // ESTILOS DATAGRIDVIEW
            // =====================================================

            DataGridViewCellStyle headerStyle =
                new DataGridViewCellStyle();

            DataGridViewCellStyle rowsStyle =
                new DataGridViewCellStyle();

            // =====================================================
            // CONTROLES
            // =====================================================

            this.lblTitulo = new Label();

            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();

            this.txtNombre = new TextBox();
            this.txtCategoria = new TextBox();
            this.txtPrecio = new TextBox();
            this.txtStock = new TextBox();
            this.txtBuscar = new TextBox();

            this.btnNuevo = new IconButton();
            this.btnGuardar = new IconButton();
            this.btnEditar = new IconButton();
            this.btnEliminar = new IconButton();
            this.btnExportar =new IconButton();
            this.btnBuscar = new IconButton();

            this.dgvProductos = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();

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
                "FrmProductos";

            this.Text =
                "FrmProductos";

            this.Load +=
                new System.EventHandler(this.FrmProductos_Load);

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
                new Point(50, 35);

            this.lblTitulo.Text =
                "Gestión de Productos";

            // =====================================================
            // LABEL BUSCAR
            // =====================================================

            this.label5.AutoSize = true;

            this.label5.Font =
                new Font(
                    "Segoe UI Semibold",
                    12F,
                    FontStyle.Bold);

            this.label5.Location =
                new Point(60, 115);

            this.label5.Text =
                "Buscar Producto";

            // =====================================================
            // TXT BUSCAR
            // =====================================================

            this.txtBuscar.Font =
                new Font(
                    "Segoe UI",
                    11F);

            this.txtBuscar.Location =
                new Point(60, 145);

            this.txtBuscar.Size =
                new Size(420, 38);

            this.txtBuscar.BorderStyle =
                BorderStyle.FixedSingle;

            // =====================================================
            // BTN BUSCAR
            // =====================================================

            this.btnBuscar.BackColor =
                Color.FromArgb(10, 35, 66);

            this.btnBuscar.FlatStyle =
                FlatStyle.Flat;

            this.btnBuscar.FlatAppearance.BorderSize = 0;

            this.btnBuscar.ForeColor =
                Color.White;

            this.btnBuscar.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            this.btnBuscar.IconChar =
                IconChar.Search;

            this.btnBuscar.IconColor =
                Color.White;

            this.btnBuscar.IconFont =
                IconFont.Auto;

            this.btnBuscar.IconSize = 24;

            this.btnBuscar.Text =
                " Buscar";

            this.btnBuscar.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            this.btnBuscar.Location =
                new Point(500, 142);

            this.btnBuscar.Size =
                new Size(160, 42);

            this.btnBuscar.Cursor =
                Cursors.Hand;

            this.btnBuscar.Click +=
                new System.EventHandler(this.btnBuscar_Click);

            // =====================================================
            // LABEL NOMBRE
            // =====================================================

            this.label1.AutoSize = true;

            // Fuente más grande
            this.label1.Font =
                new Font(
                    "Segoe UI Semibold",
                    13F,
                    FontStyle.Bold);

            this.label1.Location =
                new Point(60, 220);

            this.label1.Text =
                "Nombre";

            // =====================================================
            // TXT NOMBRE
            // =====================================================

            this.txtNombre.Font =
                new Font(
                    "Segoe UI",
                    12F);

            this.txtNombre.Location =
                new Point(60, 255);

            this.txtNombre.Size =
                new Size(360, 38);

            this.txtNombre.BorderStyle =
                BorderStyle.FixedSingle;

            // =====================================================
            // LABEL CATEGORIA
            // =====================================================

            this.label2.AutoSize = true;

            this.label2.Font =
                new Font(
                    "Segoe UI Semibold",
                    13F,
                    FontStyle.Bold);

            this.label2.Location =
                new Point(60, 320);

            this.label2.Text =
                "Categoría";

            // =====================================================
            // TXT CATEGORIA
            // =====================================================

            this.txtCategoria.Font =
                new Font(
                    "Segoe UI",
                    12F);

            this.txtCategoria.Location =
                new Point(60, 355);

            this.txtCategoria.Size =
                new Size(360, 38);

            this.txtCategoria.BorderStyle =
                BorderStyle.FixedSingle;

            // =====================================================
            // LABEL PRECIO
            // =====================================================

            this.label3.AutoSize = true;

            this.label3.Font =
                new Font(
                    "Segoe UI Semibold",
                    13F,
                    FontStyle.Bold);

            this.label3.Location =
                new Point(520, 220);

            this.label3.Text =
                "Precio";

            // =====================================================
            // TXT PRECIO
            // =====================================================

            this.txtPrecio.Font =
                new Font(
                    "Segoe UI",
                    12F);

            this.txtPrecio.Location =
                new Point(520, 255);

            this.txtPrecio.Size =
                new Size(180, 38);

            this.txtPrecio.BorderStyle =
                BorderStyle.FixedSingle;

            // =====================================================
            // LABEL STOCK
            // =====================================================

            this.label4.AutoSize = true;

            this.label4.Font =
                new Font(
                    "Segoe UI Semibold",
                    13F,
                    FontStyle.Bold);

            this.label4.Location =
                new Point(520, 320);

            this.label4.Text =
                "Stock";

            // =====================================================
            // TXT STOCK
            // =====================================================

            this.txtStock.Font =
                new Font(
                    "Segoe UI",
                    12F);

            this.txtStock.Location =
                new Point(520, 355);

            this.txtStock.Size =
                new Size(180, 38);

            this.txtStock.BorderStyle =
                BorderStyle.FixedSingle;

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
                new Point(60, 450);

            this.btnNuevo.Cursor =
                Cursors.Hand;

            // =====================================================
            // BTN GUARDAR
            // =====================================================

            this.btnGuardar.BackColor =
                Color.FromArgb(46, 204, 113);

            this.btnGuardar.FlatStyle =
                FlatStyle.Flat;

            this.btnGuardar.FlatAppearance.BorderSize = 0;

            this.btnGuardar.ForeColor =
                Color.White;

            this.btnGuardar.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            this.btnGuardar.IconChar =
                IconChar.FloppyDisk;

            this.btnGuardar.IconColor =
                Color.White;

            this.btnGuardar.IconFont =
                IconFont.Auto;

            this.btnGuardar.IconSize = 28;

            this.btnGuardar.Text =
                " Guardar";

            this.btnGuardar.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            this.btnGuardar.Size =
                new Size(170, 58);

            this.btnGuardar.Location =
                new Point(260, 450);

            this.btnGuardar.Cursor =
                Cursors.Hand;

            // =====================================================
            // BTN EDITAR
            // =====================================================

            this.btnEditar.BackColor =
                Color.FromArgb(241, 196, 15);

            this.btnEditar.FlatStyle =
                FlatStyle.Flat;

            this.btnEditar.FlatAppearance.BorderSize = 0;

            this.btnEditar.ForeColor =
                Color.White;

            this.btnEditar.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            this.btnEditar.IconChar =
                IconChar.PenToSquare;

            this.btnEditar.IconColor =
                Color.White;

            this.btnEditar.IconFont =
                IconFont.Auto;

            this.btnEditar.IconSize = 28;

            this.btnEditar.Text =
                " Editar";

            this.btnEditar.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            this.btnEditar.Size =
                new Size(170, 58);

            this.btnEditar.Location =
                new Point(460, 450);

            this.btnEditar.Cursor =
                Cursors.Hand;

            // =====================================================
            // BTN ELIMINAR
            // =====================================================

            this.btnEliminar.BackColor =
                Color.FromArgb(231, 76, 60);

            this.btnEliminar.FlatStyle =
                FlatStyle.Flat;

            this.btnEliminar.FlatAppearance.BorderSize = 0;

            this.btnEliminar.ForeColor =
                Color.White;

            this.btnEliminar.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            this.btnEliminar.IconChar =
                IconChar.Trash;

            this.btnEliminar.IconColor =
                Color.White;

            this.btnEliminar.IconFont =
                IconFont.Auto;

            this.btnEliminar.IconSize = 28;

            this.btnEliminar.Text =
                " Eliminar";

            this.btnEliminar.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            this.btnEliminar.Size =
                new Size(170, 58);

            this.btnEliminar.Location =
                new Point(660, 450);

            this.btnEliminar.Cursor =
                Cursors.Hand;

            // =====================================================
            // BTN EXPORTAR
            // =====================================================

            this.btnExportar.BackColor =
                Color.FromArgb(39, 174, 96);

            this.btnExportar.FlatStyle =
                FlatStyle.Flat;

            this.btnExportar.FlatAppearance.BorderSize = 0;

            this.btnExportar.ForeColor =
                Color.White;

            this.btnExportar.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            this.btnExportar.IconChar =
                IconChar.FileExcel;

            this.btnExportar.IconColor =
                Color.White;

            this.btnExportar.IconFont =
                IconFont.Auto;

            this.btnExportar.IconSize = 28;

            this.btnExportar.Text =
                " Exportar Excel";

            this.btnExportar.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            this.btnExportar.Size =
                new Size(190, 58);

            this.btnExportar.Location =
                new Point(860, 450);

            this.btnExportar.Cursor =
                Cursors.Hand;

            // =====================================================
            // DATAGRIDVIEW
            // =====================================================

            this.dgvProductos.AllowUserToAddRows = false;

            this.dgvProductos.AllowUserToDeleteRows = false;

            this.dgvProductos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvProductos.BackgroundColor =
                Color.White;

            this.dgvProductos.BorderStyle =
                BorderStyle.None;

            this.dgvProductos.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            this.dgvProductos.Location =
                new Point(60, 585);

            this.dgvProductos.Size =
                new Size(1500, 400);

            this.dgvProductos.ReadOnly = true;

            this.dgvProductos.RowHeadersVisible = false;

            this.dgvProductos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            this.dgvProductos.MultiSelect = false;

            this.dgvProductos.EnableHeadersVisualStyles = false;

            this.dgvProductos.ColumnHeadersHeight = 45;

            this.dgvProductos.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            this.dgvProductos.RowTemplate.Height = 42;

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

            this.dgvProductos.ColumnHeadersDefaultCellStyle =
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

            this.dgvProductos.RowsDefaultCellStyle =
                rowsStyle;

            this.dgvProductos.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 247, 250);

            this.dgvProductos.DefaultCellStyle.Padding =
                new Padding(5);

            this.dgvProductos.GridColor =
                Color.FromArgb(225, 225, 225);

            this.dgvProductos.CellClick +=
                new DataGridViewCellEventHandler(
                    this.dgvProductos_CellClick);

            // =====================================================
            // EVENTOS BOTONES
            // =====================================================

            this.btnNuevo.Click +=
                new System.EventHandler(this.btnNuevo_Click);

            this.btnGuardar.Click +=
                new System.EventHandler(this.btnGuardar_Click);

            this.btnEditar.Click +=
                new System.EventHandler(this.btnEditar_Click);

            this.btnEliminar.Click +=
                new System.EventHandler(this.btnEliminar_Click);

            this.btnExportar.Click +=
                new System.EventHandler(this.btnExportar_Click);

            // =====================================================
            // CONTROLES
            // =====================================================

            this.Controls.Add(this.lblTitulo);

            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);

            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtBuscar);

            this.Controls.Add(this.btnBuscar);

            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dgvProductos);

            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();

            this.ResumeLayout(false);

            this.PerformLayout();
        }

        #endregion

        private Label lblTitulo;

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;

        private TextBox txtNombre;
        private TextBox txtCategoria;
        private TextBox txtPrecio;
        private TextBox txtStock;
        private TextBox txtBuscar;

        private IconButton btnNuevo;
        private IconButton btnGuardar;
        private IconButton btnEditar;
        private IconButton btnEliminar;
        private IconButton btnExportar;
        private IconButton btnBuscar;

        private DataGridView dgvProductos;
    }
}