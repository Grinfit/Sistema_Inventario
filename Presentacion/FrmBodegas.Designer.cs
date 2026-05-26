// IMPORTACION DE LIBRERIAS NECESARIAS
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Sistema_Inventario.Presentacion
{
    // CLASE PARCIAL DEL FORMULARIO BODEGAS
    partial class FrmBodegas
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
            // ESTILOS DEL DATAGRIDVIEW
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle rowsStyle   = new DataGridViewCellStyle();

            // CONTROLES
            this.lblTitulo   = new Label();
            this.pnlSep1     = new Panel();
            this.label3      = new Label();
            this.txtBuscar   = new TextBox();
            this.btnBuscar   = new IconButton();
            this.btnNuevo    = new IconButton();
            this.btnEditar   = new IconButton();
            this.btnEliminar = new IconButton();
            this.btnExportar = new IconButton();
            this.pnlSep2     = new Panel();
            this.dgvBodegas  = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvBodegas)).BeginInit();
            this.SuspendLayout();

            // ─────────────────────────────────────────
            // FORMULARIO
            // ─────────────────────────────────────────
            this.ClientSize      = new System.Drawing.Size(1350, 860);
            this.BackColor       = System.Drawing.Color.FromArgb(236, 240, 245);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name            = "FrmBodegas";
            this.Text            = "FrmBodegas";
            this.Load           += new System.EventHandler(this.FrmBodegas_Load);

            // ─────────────────────────────────────────
            // TITULO PRINCIPAL
            // ─────────────────────────────────────────
            this.lblTitulo.AutoSize  = true;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(10, 35, 66);
            this.lblTitulo.Location  = new System.Drawing.Point(50, 22);
            this.lblTitulo.Text      = "Gestión de Bodegas";

            // SEPARADOR SUPERIOR
            this.pnlSep1.BackColor = System.Drawing.Color.FromArgb(10, 35, 66);
            this.pnlSep1.Location  = new System.Drawing.Point(50, 82);
            this.pnlSep1.Size      = new System.Drawing.Size(1255, 2);

            // ─────────────────────────────────────────
            // FILA DE BUSQUEDA
            // ─────────────────────────────────────────

            // LABEL BUSCAR
            this.label3.AutoSize  = true;
            this.label3.Font      = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.label3.Location  = new System.Drawing.Point(50, 108);
            this.label3.Text      = "Buscar Bodega:";

            // TXT BUSCAR
            this.txtBuscar.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtBuscar.Location    = new System.Drawing.Point(205, 104);
            this.txtBuscar.Size        = new System.Drawing.Size(435, 38);
            this.txtBuscar.BorderStyle = BorderStyle.FixedSingle;

            // BTN BUSCAR
            this.btnBuscar.BackColor                 = System.Drawing.Color.FromArgb(10, 35, 66);
            this.btnBuscar.FlatStyle                 = FlatStyle.Flat;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.ForeColor                 = System.Drawing.Color.White;
            this.btnBuscar.Font                      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.IconChar                  = IconChar.Search;
            this.btnBuscar.IconColor                 = System.Drawing.Color.White;
            this.btnBuscar.IconFont                  = IconFont.Auto;
            this.btnBuscar.IconSize                  = 22;
            this.btnBuscar.Text                      = " Buscar";
            this.btnBuscar.TextImageRelation         = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.Location                  = new System.Drawing.Point(655, 101);
            this.btnBuscar.Size                      = new System.Drawing.Size(155, 44);
            this.btnBuscar.Cursor                    = Cursors.Hand;
            this.btnBuscar.Click                    += new System.EventHandler(this.btnBuscar_Click);

            // ─────────────────────────────────────────
            // FILA DE BOTONES CRUD
            // ─────────────────────────────────────────

            // BTN NUEVO
            this.btnNuevo.BackColor                  = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnNuevo.FlatStyle                  = FlatStyle.Flat;
            this.btnNuevo.FlatAppearance.BorderSize  = 0;
            this.btnNuevo.ForeColor                  = System.Drawing.Color.White;
            this.btnNuevo.Font                       = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.IconChar                   = IconChar.CirclePlus;
            this.btnNuevo.IconColor                  = System.Drawing.Color.White;
            this.btnNuevo.IconFont                   = IconFont.Auto;
            this.btnNuevo.IconSize                   = 26;
            this.btnNuevo.Text                       = " Nuevo";
            this.btnNuevo.TextImageRelation          = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.Location                   = new System.Drawing.Point(50, 162);
            this.btnNuevo.Size                       = new System.Drawing.Size(160, 50);
            this.btnNuevo.Cursor                     = Cursors.Hand;
            this.btnNuevo.Click                     += new System.EventHandler(this.btnNuevo_Click);

            // BTN EDITAR
            this.btnEditar.BackColor                  = System.Drawing.Color.FromArgb(241, 196, 15);
            this.btnEditar.FlatStyle                  = FlatStyle.Flat;
            this.btnEditar.FlatAppearance.BorderSize  = 0;
            this.btnEditar.ForeColor                  = System.Drawing.Color.White;
            this.btnEditar.Font                       = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditar.IconChar                   = IconChar.PenToSquare;
            this.btnEditar.IconColor                  = System.Drawing.Color.White;
            this.btnEditar.IconFont                   = IconFont.Auto;
            this.btnEditar.IconSize                   = 26;
            this.btnEditar.Text                       = " Editar";
            this.btnEditar.TextImageRelation          = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditar.Location                   = new System.Drawing.Point(225, 162);
            this.btnEditar.Size                       = new System.Drawing.Size(160, 50);
            this.btnEditar.Cursor                     = Cursors.Hand;
            this.btnEditar.Click                     += new System.EventHandler(this.btnEditar_Click);

            // BTN ELIMINAR
            this.btnEliminar.BackColor                  = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnEliminar.FlatStyle                  = FlatStyle.Flat;
            this.btnEliminar.FlatAppearance.BorderSize  = 0;
            this.btnEliminar.ForeColor                  = System.Drawing.Color.White;
            this.btnEliminar.Font                       = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.IconChar                   = IconChar.Trash;
            this.btnEliminar.IconColor                  = System.Drawing.Color.White;
            this.btnEliminar.IconFont                   = IconFont.Auto;
            this.btnEliminar.IconSize                   = 26;
            this.btnEliminar.Text                       = " Eliminar";
            this.btnEliminar.TextImageRelation          = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.Location                   = new System.Drawing.Point(400, 162);
            this.btnEliminar.Size                       = new System.Drawing.Size(160, 50);
            this.btnEliminar.Cursor                     = Cursors.Hand;
            this.btnEliminar.Click                     += new System.EventHandler(this.btnEliminar_Click);

            // BTN EXPORTAR EXCEL
            this.btnExportar.BackColor                  = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnExportar.FlatStyle                  = FlatStyle.Flat;
            this.btnExportar.FlatAppearance.BorderSize  = 0;
            this.btnExportar.ForeColor                  = System.Drawing.Color.White;
            this.btnExportar.Font                       = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportar.IconChar                   = IconChar.FileExcel;
            this.btnExportar.IconColor                  = System.Drawing.Color.White;
            this.btnExportar.IconFont                   = IconFont.Auto;
            this.btnExportar.IconSize                   = 26;
            this.btnExportar.Text                       = " Exportar Excel";
            this.btnExportar.TextImageRelation          = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.Location                   = new System.Drawing.Point(575, 162);
            this.btnExportar.Size                       = new System.Drawing.Size(200, 50);
            this.btnExportar.Cursor                     = Cursors.Hand;
            this.btnExportar.Click                     += new System.EventHandler(this.btnExportar_Click);

            // SEPARADOR INFERIOR
            this.pnlSep2.BackColor = System.Drawing.Color.FromArgb(210, 215, 220);
            this.pnlSep2.Location  = new System.Drawing.Point(30, 228);
            this.pnlSep2.Size      = new System.Drawing.Size(1290, 1);

            // ─────────────────────────────────────────
            // DATAGRIDVIEW
            // ─────────────────────────────────────────
            this.dgvBodegas.AllowUserToAddRows    = false;
            this.dgvBodegas.AllowUserToDeleteRows = false;
            this.dgvBodegas.AutoSizeColumnsMode   = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBodegas.BackgroundColor       = System.Drawing.Color.White;
            this.dgvBodegas.BorderStyle           = BorderStyle.None;
            this.dgvBodegas.CellBorderStyle       = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBodegas.Location              = new System.Drawing.Point(30, 236);
            this.dgvBodegas.Size                  = new System.Drawing.Size(1290, 594);
            this.dgvBodegas.Anchor                = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            this.dgvBodegas.ReadOnly              = true;
            this.dgvBodegas.RowHeadersVisible     = false;
            this.dgvBodegas.SelectionMode         = DataGridViewSelectionMode.FullRowSelect;
            this.dgvBodegas.MultiSelect           = false;
            this.dgvBodegas.EnableHeadersVisualStyles       = false;
            this.dgvBodegas.ColumnHeadersHeight             = 45;
            this.dgvBodegas.ColumnHeadersHeightSizeMode     = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBodegas.RowTemplate.Height   = 42;

            // ESTILO CABECERA
            headerStyle.BackColor = System.Drawing.Color.FromArgb(10, 35, 66);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.dgvBodegas.ColumnHeadersDefaultCellStyle = headerStyle;

            // ESTILO FILAS
            rowsStyle.Font               = new System.Drawing.Font("Segoe UI", 10F);
            rowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            rowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvBodegas.RowsDefaultCellStyle = rowsStyle;

            this.dgvBodegas.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.dgvBodegas.DefaultCellStyle.Padding = new Padding(5);
            this.dgvBodegas.GridColor = System.Drawing.Color.FromArgb(225, 225, 225);

            this.dgvBodegas.CellClick += new DataGridViewCellEventHandler(this.dgvBodegas_CellClick);

            // ─────────────────────────────────────────
            // AGREGAR CONTROLES AL FORMULARIO
            // ─────────────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlSep1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.pnlSep2);
            this.Controls.Add(this.dgvBodegas);

            ((System.ComponentModel.ISupportInitialize)(this.dgvBodegas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // TITULO
        private Label lblTitulo;

        // SEPARADORES
        private Panel pnlSep1;
        private Panel pnlSep2;

        // BUSQUEDA
        private Label   label3;
        private TextBox txtBuscar;

        // BOTONES
        private IconButton btnBuscar;
        private IconButton btnNuevo;
        private IconButton btnEditar;
        private IconButton btnEliminar;
        private IconButton btnExportar;

        // DATAGRIDVIEW
        private DataGridView dgvBodegas;
    }
}
