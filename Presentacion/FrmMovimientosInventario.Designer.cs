// IMPORTACION DE LIBRERIAS NECESARIAS
using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Inventario.Presentacion
{
    // CLASE PARCIAL DEL FORMULARIO MOVIMIENTOS INVENTARIO
    partial class FrmMovimientosInventario
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
            // ESTILOS DEL GRID
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle rowsStyle   = new DataGridViewCellStyle();

            // COMPONENTES
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);

            // PANELES
            this.pnlHeader   = new System.Windows.Forms.Panel();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.pnlSepH     = new System.Windows.Forms.Panel();

            // LABELS DEL HEADER
            this.lblTitulo      = new System.Windows.Forms.Label();
            this.lblFechaHora   = new System.Windows.Forms.Label();
            this.lblUsuarioInfo = new System.Windows.Forms.Label();

            // BUSQUEDA Y BOTONES
            this.txtBuscar           = new System.Windows.Forms.TextBox();
            this.btnExportar         = new FontAwesome.Sharp.IconButton();
            this.btnNuevoMovimiento  = new FontAwesome.Sharp.IconButton();

            // GRID
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            this.pnlBusqueda.SuspendLayout();
            this.SuspendLayout();

            // ─────────────────────────────────────────
            // FORMULARIO
            // ─────────────────────────────────────────
            this.BackColor       = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize      = new System.Drawing.Size(1350, 860);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name            = "FrmMovimientosInventario";
            this.Text            = "FrmMovimientosInventario";
            this.Load           += new System.EventHandler(this.FrmMovimientosInventario_Load);

            // ─────────────────────────────────────────
            // TIMER — actualiza reloj cada segundo
            // ─────────────────────────────────────────
            this.timer1.Interval = 1000;
            this.timer1.Tick    += new System.EventHandler(this.timer1_Tick);

            // ─────────────────────────────────────────
            // PANEL HEADER (banda azul oscura)
            // ─────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(10, 35, 66);
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 84;
            this.pnlHeader.Name      = "pnlHeader";
            this.pnlHeader.TabIndex  = 0;

            // TITULO
            this.lblTitulo.AutoSize  = true;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location  = new System.Drawing.Point(30, 22);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.Text      = "Movimientos de Inventario";

            // FECHA Y HORA (derecha)
            this.lblFechaHora.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblFechaHora.Font      = new System.Drawing.Font("Segoe UI", 11F);
            this.lblFechaHora.ForeColor = System.Drawing.Color.FromArgb(180, 200, 230);
            this.lblFechaHora.Location  = new System.Drawing.Point(680, 20);
            this.lblFechaHora.Name      = "lblFechaHora";
            this.lblFechaHora.Size      = new System.Drawing.Size(640, 26);
            this.lblFechaHora.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // USUARIO Y ROL (derecha-abajo)
            this.lblUsuarioInfo.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblUsuarioInfo.Font      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsuarioInfo.ForeColor = System.Drawing.Color.White;
            this.lblUsuarioInfo.Location  = new System.Drawing.Point(680, 50);
            this.lblUsuarioInfo.Name      = "lblUsuarioInfo";
            this.lblUsuarioInfo.Size      = new System.Drawing.Size(640, 24);
            this.lblUsuarioInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblFechaHora);
            this.pnlHeader.Controls.Add(this.lblUsuarioInfo);

            // ─────────────────────────────────────────
            // PANEL ACCIONES (barra de búsqueda + botones)
            // ─────────────────────────────────────────
            this.pnlAcciones.BackColor = System.Drawing.Color.White;
            this.pnlAcciones.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlAcciones.Height    = 68;
            this.pnlAcciones.Name      = "pnlAcciones";
            this.pnlAcciones.TabIndex  = 1;

            // CAJA DE BÚSQUEDA (panel contenedor)
            this.pnlBusqueda.BackColor   = System.Drawing.Color.FromArgb(241, 243, 246);
            this.pnlBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlBusqueda.Location    = new System.Drawing.Point(20, 14);
            this.pnlBusqueda.Name        = "pnlBusqueda";
            this.pnlBusqueda.Size        = new System.Drawing.Size(360, 40);
            this.pnlBusqueda.TabIndex    = 0;

            // TEXTBOX DE BÚSQUEDA (sin borde, dentro del panel)
            this.txtBuscar.BackColor    = System.Drawing.Color.FromArgb(241, 243, 246);
            this.txtBuscar.BorderStyle  = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font         = new System.Drawing.Font("Segoe UI", 11F);
            this.txtBuscar.ForeColor    = System.Drawing.Color.FromArgb(100, 100, 100);
            this.txtBuscar.Location     = new System.Drawing.Point(10, 10);
            this.txtBuscar.Name         = "txtBuscar";
            this.txtBuscar.Size         = new System.Drawing.Size(340, 24);
            this.txtBuscar.TabIndex     = 0;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.Enter       += new System.EventHandler(this.txtBuscar_Enter);
            this.txtBuscar.Leave       += new System.EventHandler(this.txtBuscar_Leave);

            this.pnlBusqueda.Controls.Add(this.txtBuscar);

            // BTN EXPORTAR EXCEL (anclado derecha)
            this.btnExportar.Anchor                    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnExportar.BackColor                 = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnExportar.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font                      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor                 = System.Drawing.Color.White;
            this.btnExportar.IconChar                  = FontAwesome.Sharp.IconChar.FileExcel;
            this.btnExportar.IconColor                 = System.Drawing.Color.White;
            this.btnExportar.IconFont                  = FontAwesome.Sharp.IconFont.Auto;
            this.btnExportar.IconSize                  = 20;
            this.btnExportar.Location                  = new System.Drawing.Point(942, 13);
            this.btnExportar.Name                      = "btnExportar";
            this.btnExportar.Size                      = new System.Drawing.Size(170, 42);
            this.btnExportar.TabIndex                  = 1;
            this.btnExportar.Text                      = " Exportar Excel";
            this.btnExportar.TextImageRelation         = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.UseVisualStyleBackColor   = false;
            this.btnExportar.Click                    += new System.EventHandler(this.btnExportar_Click);

            // BTN NUEVO MOVIMIENTO (anclado derecha)
            this.btnNuevoMovimiento.Anchor                    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnNuevoMovimiento.BackColor                 = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnNuevoMovimiento.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoMovimiento.FlatAppearance.BorderSize = 0;
            this.btnNuevoMovimiento.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoMovimiento.Font                      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnNuevoMovimiento.ForeColor                 = System.Drawing.Color.White;
            this.btnNuevoMovimiento.IconChar                  = FontAwesome.Sharp.IconChar.CirclePlus;
            this.btnNuevoMovimiento.IconColor                 = System.Drawing.Color.White;
            this.btnNuevoMovimiento.IconFont                  = FontAwesome.Sharp.IconFont.Auto;
            this.btnNuevoMovimiento.IconSize                  = 22;
            this.btnNuevoMovimiento.Location                  = new System.Drawing.Point(1120, 13);
            this.btnNuevoMovimiento.Name                      = "btnNuevoMovimiento";
            this.btnNuevoMovimiento.Size                      = new System.Drawing.Size(210, 42);
            this.btnNuevoMovimiento.TabIndex                  = 2;
            this.btnNuevoMovimiento.Text                      = " Nuevo Movimiento";
            this.btnNuevoMovimiento.TextImageRelation         = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevoMovimiento.UseVisualStyleBackColor   = false;
            this.btnNuevoMovimiento.Click                    += new System.EventHandler(this.btnNuevoMovimiento_Click);

            this.pnlAcciones.Controls.Add(this.pnlBusqueda);
            this.pnlAcciones.Controls.Add(this.btnExportar);
            this.pnlAcciones.Controls.Add(this.btnNuevoMovimiento);

            // ─────────────────────────────────────────
            // SEPARADOR HORIZONTAL
            // ─────────────────────────────────────────
            this.pnlSepH.BackColor = System.Drawing.Color.FromArgb(210, 215, 220);
            this.pnlSepH.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlSepH.Height    = 1;
            this.pnlSepH.Name      = "pnlSepH";
            this.pnlSepH.TabIndex  = 2;

            // ─────────────────────────────────────────
            // DATAGRIDVIEW — elemento principal
            // ─────────────────────────────────────────
            this.dgvMovimientos.AllowUserToAddRows          = false;
            this.dgvMovimientos.AllowUserToDeleteRows       = false;
            this.dgvMovimientos.AllowUserToResizeRows       = false;
            this.dgvMovimientos.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovimientos.BackgroundColor             = System.Drawing.Color.White;
            this.dgvMovimientos.BorderStyle                 = System.Windows.Forms.BorderStyle.None;
            this.dgvMovimientos.CellBorderStyle             = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMovimientos.ColumnHeadersHeight         = 48;
            this.dgvMovimientos.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMovimientos.Dock                        = System.Windows.Forms.DockStyle.Fill;
            this.dgvMovimientos.EnableHeadersVisualStyles   = false;
            this.dgvMovimientos.GridColor                   = System.Drawing.Color.FromArgb(225, 225, 225);
            this.dgvMovimientos.MultiSelect                 = false;
            this.dgvMovimientos.Name                        = "dgvMovimientos";
            this.dgvMovimientos.ReadOnly                    = true;
            this.dgvMovimientos.RowHeadersVisible           = false;
            this.dgvMovimientos.RowHeadersWidth             = 51;
            this.dgvMovimientos.RowTemplate.Height          = 40;
            this.dgvMovimientos.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovimientos.TabIndex                    = 3;

            // ESTILO CABECERA (azul oscuro ERP)
            headerStyle.BackColor = System.Drawing.Color.FromArgb(10, 35, 66);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.dgvMovimientos.ColumnHeadersDefaultCellStyle = headerStyle;

            // ESTILO FILAS
            rowsStyle.Font               = new System.Drawing.Font("Segoe UI", 10F);
            rowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            rowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvMovimientos.RowsDefaultCellStyle = rowsStyle;

            this.dgvMovimientos.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(245, 247, 250);
            this.dgvMovimientos.DefaultCellStyle.Padding =
                new System.Windows.Forms.Padding(5, 0, 5, 0);

            // ─────────────────────────────────────────
            // AGREGAR CONTROLES AL FORMULARIO
            // (orden: primero = procesado primero por dock engine)
            // ─────────────────────────────────────────
            this.Controls.Add(this.dgvMovimientos);  // Fill — debe ir al final del z-order
            this.Controls.Add(this.pnlSepH);
            this.Controls.Add(this.pnlAcciones);
            this.Controls.Add(this.pnlHeader);

            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            this.pnlAcciones.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        // COMPONENTES
        private System.Windows.Forms.Timer timer1;

        // PANELES
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Panel pnlBusqueda;
        private System.Windows.Forms.Panel pnlSepH;

        // LABELS HEADER
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFechaHora;
        private System.Windows.Forms.Label lblUsuarioInfo;

        // BUSQUEDA Y BOTONES
        private System.Windows.Forms.TextBox     txtBuscar;
        private FontAwesome.Sharp.IconButton     btnExportar;
        private FontAwesome.Sharp.IconButton     btnNuevoMovimiento;

        // GRID PRINCIPAL
        private System.Windows.Forms.DataGridView dgvMovimientos;
    }
}
