using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Sistema_Inventario.Presentacion
{
    partial class FrmBodegas
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

            // =========================================
            // CONTROLES
            // =========================================

            this.lblTitulo = new Label();

            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();

            this.txtNombre = new TextBox();
            this.txtDireccion = new TextBox();
            this.txtBuscar = new TextBox();

            this.btnNuevo = new IconButton();
            this.btnGuardar = new IconButton();
            this.btnEditar = new IconButton();
            this.btnEliminar = new IconButton();
            this.btnBuscar = new IconButton();

            this.dgvBodegas = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvBodegas)).BeginInit();

            this.SuspendLayout();

            // =========================================
            // FORMULARIO
            // =========================================

            this.ClientSize =
                new Size(1350, 860);

            this.BackColor =
                Color.FromArgb(236, 240, 245);

            this.FormBorderStyle =
                FormBorderStyle.None;

            this.Name =
                "FrmBodegas";

            this.Text =
                "FrmBodegas";

            this.Load +=
                new System.EventHandler(this.FrmBodegas_Load);

            // =========================================
            // TITULO
            // =========================================

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
                "Gestión de Bodegas";

            // =========================================
            // LABEL BUSCAR
            // =========================================

            this.label3.AutoSize = true;

            this.label3.Font =
                new Font(
                    "Segoe UI Semibold",
                    12F,
                    FontStyle.Bold);

            this.label3.Location =
                new Point(60, 115);

            this.label3.Text =
                "Buscar Bodega";

            // =========================================
            // TXT BUSCAR
            // =========================================

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

            // =========================================
            // BTN BUSCAR
            // =========================================

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

            // =========================================
            // LABEL NOMBRE
            // =========================================

            this.label1.AutoSize = true;

            this.label1.Font =
                new Font(
                    "Segoe UI Semibold",
                    13F,
                    FontStyle.Bold);

            this.label1.Location =
                new Point(60, 230);

            this.label1.Text =
                "Nombre";

            // =========================================
            // TXT NOMBRE
            // =========================================

            this.txtNombre.Font =
                new Font(
                    "Segoe UI",
                    12F);

            this.txtNombre.Location =
                new Point(60, 265);

            this.txtNombre.Size =
                new Size(360, 38);

            this.txtNombre.BorderStyle =
                BorderStyle.FixedSingle;

            // =========================================
            // LABEL DIRECCION
            // =========================================

            this.label2.AutoSize = true;

            this.label2.Font =
                new Font(
                    "Segoe UI Semibold",
                    13F,
                    FontStyle.Bold);

            this.label2.Location =
                new Point(60, 340);

            this.label2.Text =
                "Dirección";

            // =========================================
            // TXT DIRECCION
            // =========================================

            this.txtDireccion.Font =
                new Font(
                    "Segoe UI",
                    12F);

            this.txtDireccion.Location =
                new Point(60, 375);

            this.txtDireccion.Size =
                new Size(640, 38);

            this.txtDireccion.BorderStyle =
                BorderStyle.FixedSingle;

            // =========================================
            // BTN NUEVO
            // =========================================

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
                new Point(60, 470);

            this.btnNuevo.Cursor =
                Cursors.Hand;

            // =========================================
            // BTN GUARDAR
            // =========================================

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
                new Point(260, 470);

            this.btnGuardar.Cursor =
                Cursors.Hand;

            // =========================================
            // BTN EDITAR
            // =========================================

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
                new Point(460, 470);

            this.btnEditar.Cursor =
                Cursors.Hand;

            // =========================================
            // BTN ELIMINAR
            // =========================================

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
                new Point(660, 470);

            this.btnEliminar.Cursor =
                Cursors.Hand;

            // =========================================
            // DATAGRIDVIEW
            // =========================================

            this.dgvBodegas.AllowUserToAddRows = false;

            this.dgvBodegas.AllowUserToDeleteRows = false;

            this.dgvBodegas.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvBodegas.BackgroundColor =
                Color.White;

            this.dgvBodegas.BorderStyle =
                BorderStyle.None;

            this.dgvBodegas.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            this.dgvBodegas.Location =
                new Point(60, 585);

            this.dgvBodegas.Size =
                new Size(1500, 400);

            this.dgvBodegas.ReadOnly = true;

            this.dgvBodegas.RowHeadersVisible = false;

            this.dgvBodegas.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            this.dgvBodegas.MultiSelect = false;

            this.dgvBodegas.EnableHeadersVisualStyles = false;

            this.dgvBodegas.ColumnHeadersHeight = 45;

            this.dgvBodegas.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            this.dgvBodegas.RowTemplate.Height = 42;

            // =========================================
            // HEADER STYLE
            // =========================================

            headerStyle.BackColor =
                Color.FromArgb(10, 35, 66);

            headerStyle.ForeColor =
                Color.White;

            headerStyle.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            this.dgvBodegas.ColumnHeadersDefaultCellStyle =
                headerStyle;

            // =========================================
            // ROW STYLE
            // =========================================

            rowsStyle.Font =
                new Font(
                    "Segoe UI",
                    10F);

            rowsStyle.SelectionBackColor =
                Color.FromArgb(52, 152, 219);

            rowsStyle.SelectionForeColor =
                Color.White;

            this.dgvBodegas.RowsDefaultCellStyle =
                rowsStyle;

            this.dgvBodegas.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 247, 250);

            this.dgvBodegas.DefaultCellStyle.Padding =
                new Padding(5);

            this.dgvBodegas.GridColor =
                Color.FromArgb(225, 225, 225);

            this.dgvBodegas.CellClick +=
                new DataGridViewCellEventHandler(
                    this.dgvBodegas_CellClick);

            // =========================================
            // EVENTOS BOTONES
            // =========================================

            this.btnNuevo.Click +=
                new System.EventHandler(this.btnNuevo_Click);

            this.btnGuardar.Click +=
                new System.EventHandler(this.btnGuardar_Click);

            this.btnEditar.Click +=
                new System.EventHandler(this.btnEditar_Click);

            this.btnEliminar.Click +=
                new System.EventHandler(this.btnEliminar_Click);

            // =========================================
            // CONTROLES
            // =========================================

            this.Controls.Add(this.lblTitulo);

            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);

            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtBuscar);

            this.Controls.Add(this.btnBuscar);

            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);

            this.Controls.Add(this.dgvBodegas);

            ((System.ComponentModel.ISupportInitialize)(this.dgvBodegas)).EndInit();

            this.ResumeLayout(false);

            this.PerformLayout();
        }

        #endregion

        private Label lblTitulo;

        private Label label1;
        private Label label2;
        private Label label3;

        private TextBox txtNombre;
        private TextBox txtDireccion;
        private TextBox txtBuscar;

        private IconButton btnNuevo;
        private IconButton btnGuardar;
        private IconButton btnEditar;
        private IconButton btnEliminar;
        private IconButton btnBuscar;

        private DataGridView dgvBodegas;
    }
}