// IMPORTACION DE LIBRERIAS NECESARIAS
using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Inventario.Presentacion
{
    partial class FrmMovimientosInventario
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle rowsStyle   = new DataGridViewCellStyle();

            this.components = new System.ComponentModel.Container();
            this.timer1     = new System.Windows.Forms.Timer(this.components);

            // PANELES
            this.pnlHeader   = new System.Windows.Forms.Panel();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.pnlFiltros  = new System.Windows.Forms.Panel();
            this.pnlSepH     = new System.Windows.Forms.Panel();

            // LABELS HEADER
            this.lblTitulo      = new System.Windows.Forms.Label();
            this.lblFechaHora   = new System.Windows.Forms.Label();
            this.lblUsuarioInfo = new System.Windows.Forms.Label();

            // BÚSQUEDA
            this.lblBuscarIcon      = new System.Windows.Forms.Label();
            this.txtBuscar          = new System.Windows.Forms.TextBox();
            this.btnLimpiarBusqueda = new System.Windows.Forms.Button();

            // BOTONES DE ACCIÓN — posicionados en Load, no aquí
            this.btnExportar        = new FontAwesome.Sharp.IconButton();
            this.btnNuevoMovimiento = new FontAwesome.Sharp.IconButton();

            // BOTONES DE FILTRO RÁPIDO
            this.btnFiltroTodos          = new System.Windows.Forms.Button();
            this.btnFiltroHoy            = new System.Windows.Forms.Button();
            this.btnFiltroEntradas       = new System.Windows.Forms.Button();
            this.btnFiltroSalidas        = new System.Windows.Forms.Button();
            this.btnFiltroTransferencias = new System.Windows.Forms.Button();
            this.btnFiltroAjustes        = new System.Windows.Forms.Button();

            // MENÚ CONTEXTUAL
            this.cmsNuevoMovimiento = new System.Windows.Forms.ContextMenuStrip(this.components);

            // GRID
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            this.pnlBusqueda.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
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

            // TIMER
            this.timer1.Interval = 1000;
            this.timer1.Tick    += new System.EventHandler(this.timer1_Tick);

            // ─────────────────────────────────────────
            // PANEL HEADER (banda azul oscura)
            // ─────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(10, 35, 66);
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 84;
            this.pnlHeader.Name      = "pnlHeader";

            this.lblTitulo.AutoSize  = true;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location  = new System.Drawing.Point(30, 22);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.Text      = "Movimientos de Inventario";

            this.lblFechaHora.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblFechaHora.Font      = new System.Drawing.Font("Segoe UI", 11F);
            this.lblFechaHora.ForeColor = System.Drawing.Color.FromArgb(180, 200, 230);
            this.lblFechaHora.Location  = new System.Drawing.Point(500, 20);
            this.lblFechaHora.Name      = "lblFechaHora";
            this.lblFechaHora.Size      = new System.Drawing.Size(820, 26);
            this.lblFechaHora.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblUsuarioInfo.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblUsuarioInfo.Font      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsuarioInfo.ForeColor = System.Drawing.Color.White;
            this.lblUsuarioInfo.Location  = new System.Drawing.Point(500, 50);
            this.lblUsuarioInfo.Name      = "lblUsuarioInfo";
            this.lblUsuarioInfo.Size      = new System.Drawing.Size(820, 24);
            this.lblUsuarioInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblFechaHora);
            this.pnlHeader.Controls.Add(this.lblUsuarioInfo);

            // ─────────────────────────────────────────
            // PANEL ACCIONES (Dock=Top, altura 68px)
            // Los botones de acción se inyectan en Load()
            // ─────────────────────────────────────────
            this.pnlAcciones.BackColor = System.Drawing.Color.White;
            this.pnlAcciones.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlAcciones.Height    = 68;
            this.pnlAcciones.Name      = "pnlAcciones";

            // ÍCONO DE BÚSQUEDA
            this.lblBuscarIcon.Font      = new System.Drawing.Font("Segoe UI", 13F);
            this.lblBuscarIcon.ForeColor = System.Drawing.Color.FromArgb(130, 140, 160);
            this.lblBuscarIcon.Location  = new System.Drawing.Point(8, 6);
            this.lblBuscarIcon.Name      = "lblBuscarIcon";
            this.lblBuscarIcon.Size      = new System.Drawing.Size(26, 28);
            this.lblBuscarIcon.Text      = "🔍";
            this.lblBuscarIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // TEXTBOX DE BÚSQUEDA
            this.txtBuscar.BackColor    = System.Drawing.Color.FromArgb(241, 243, 246);
            this.txtBuscar.BorderStyle  = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font         = new System.Drawing.Font("Segoe UI", 11F);
            this.txtBuscar.ForeColor    = System.Drawing.Color.FromArgb(100, 100, 100);
            this.txtBuscar.Location     = new System.Drawing.Point(36, 10);
            this.txtBuscar.Name         = "txtBuscar";
            this.txtBuscar.Size         = new System.Drawing.Size(368, 24);
            this.txtBuscar.TabIndex     = 0;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.Enter       += new System.EventHandler(this.txtBuscar_Enter);
            this.txtBuscar.Leave       += new System.EventHandler(this.txtBuscar_Leave);

            // BOTÓN LIMPIAR BÚSQUEDA
            this.btnLimpiarBusqueda.BackColor                 = System.Drawing.Color.FromArgb(241, 243, 246);
            this.btnLimpiarBusqueda.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarBusqueda.FlatAppearance.BorderSize = 0;
            this.btnLimpiarBusqueda.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarBusqueda.Font                      = new System.Drawing.Font("Segoe UI", 13F);
            this.btnLimpiarBusqueda.ForeColor                 = System.Drawing.Color.FromArgb(140, 150, 165);
            this.btnLimpiarBusqueda.Location                  = new System.Drawing.Point(408, 5);
            this.btnLimpiarBusqueda.Name                      = "btnLimpiarBusqueda";
            this.btnLimpiarBusqueda.Size                      = new System.Drawing.Size(30, 30);
            this.btnLimpiarBusqueda.TabStop                   = false;
            this.btnLimpiarBusqueda.Text                      = "×";
            this.btnLimpiarBusqueda.Visible                   = false;
            this.btnLimpiarBusqueda.Click                    += new System.EventHandler(this.btnLimpiarBusqueda_Click);

            // PANEL BÚSQUEDA
            this.pnlBusqueda.BackColor   = System.Drawing.Color.FromArgb(241, 243, 246);
            this.pnlBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlBusqueda.Location    = new System.Drawing.Point(20, 14);
            this.pnlBusqueda.Name        = "pnlBusqueda";
            this.pnlBusqueda.Size        = new System.Drawing.Size(450, 40);

            this.pnlBusqueda.Controls.Add(this.lblBuscarIcon);
            this.pnlBusqueda.Controls.Add(this.txtBuscar);
            this.pnlBusqueda.Controls.Add(this.btnLimpiarBusqueda);

            // PROPIEDADES BASE DE btnEXPORTAR (posición se asigna en Load)
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
            this.btnExportar.Name                      = "btnExportar";
            this.btnExportar.Size                      = new System.Drawing.Size(180, 42);
            this.btnExportar.Text                      = "  Exportar Excel";
            this.btnExportar.TextImageRelation         = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.UseVisualStyleBackColor   = false;
            this.btnExportar.Visible                   = true;
            this.btnExportar.Click                    += new System.EventHandler(this.btnExportar_Click);

            // PROPIEDADES BASE DE btnNUEVOMOVIMIENTO (posición se asigna en Load)
            this.btnNuevoMovimiento.BackColor                 = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnNuevoMovimiento.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoMovimiento.FlatAppearance.BorderSize = 0;
            this.btnNuevoMovimiento.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoMovimiento.Font                      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnNuevoMovimiento.ForeColor                 = System.Drawing.Color.White;
            this.btnNuevoMovimiento.IconChar                  = FontAwesome.Sharp.IconChar.CirclePlus;
            this.btnNuevoMovimiento.IconColor                 = System.Drawing.Color.White;
            this.btnNuevoMovimiento.IconFont                  = FontAwesome.Sharp.IconFont.Auto;
            this.btnNuevoMovimiento.IconSize                  = 20;
            this.btnNuevoMovimiento.Name                      = "btnNuevoMovimiento";
            this.btnNuevoMovimiento.Size                      = new System.Drawing.Size(222, 42);
            this.btnNuevoMovimiento.Text                      = "  + Nuevo Movimiento";
            this.btnNuevoMovimiento.TextImageRelation         = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevoMovimiento.UseVisualStyleBackColor   = false;
            this.btnNuevoMovimiento.Enabled                   = true;
            this.btnNuevoMovimiento.Visible                   = true;
            this.btnNuevoMovimiento.Click                    += new System.EventHandler(this.btnNuevoMovimiento_Click);

            // Solo se agrega pnlBusqueda en Designer; los botones de acción
            // se inyectan en Load() con posición basada en el ancho real.
            this.pnlAcciones.Controls.Add(this.pnlBusqueda);

            // ─────────────────────────────────────────
            // PANEL FILTROS RÁPIDOS
            // ─────────────────────────────────────────
            this.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(250, 251, 253);
            this.pnlFiltros.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Height    = 52;
            this.pnlFiltros.Name      = "pnlFiltros";

            this.btnFiltroTodos.BackColor                  = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnFiltroTodos.Cursor                     = System.Windows.Forms.Cursors.Hand;
            this.btnFiltroTodos.FlatAppearance.BorderSize  = 1;
            this.btnFiltroTodos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnFiltroTodos.FlatStyle                  = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltroTodos.Font                       = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltroTodos.ForeColor                  = System.Drawing.Color.White;
            this.btnFiltroTodos.Location                   = new System.Drawing.Point(20, 11);
            this.btnFiltroTodos.Name                       = "btnFiltroTodos";
            this.btnFiltroTodos.Size                       = new System.Drawing.Size(100, 30);
            this.btnFiltroTodos.Text                       = "Todos";
            this.btnFiltroTodos.UseVisualStyleBackColor    = false;
            this.btnFiltroTodos.Click                     += new System.EventHandler(this.btnFiltroTodos_Click);

            this.btnFiltroHoy.BackColor                  = System.Drawing.Color.FromArgb(241, 243, 246);
            this.btnFiltroHoy.Cursor                     = System.Windows.Forms.Cursors.Hand;
            this.btnFiltroHoy.FlatAppearance.BorderSize  = 1;
            this.btnFiltroHoy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(210, 215, 225);
            this.btnFiltroHoy.FlatStyle                  = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltroHoy.Font                       = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltroHoy.ForeColor                  = System.Drawing.Color.FromArgb(55, 65, 81);
            this.btnFiltroHoy.Location                   = new System.Drawing.Point(128, 11);
            this.btnFiltroHoy.Name                       = "btnFiltroHoy";
            this.btnFiltroHoy.Size                       = new System.Drawing.Size(88, 30);
            this.btnFiltroHoy.Text                       = "Hoy";
            this.btnFiltroHoy.UseVisualStyleBackColor    = false;
            this.btnFiltroHoy.Click                     += new System.EventHandler(this.btnFiltroHoy_Click);

            this.btnFiltroEntradas.BackColor                  = System.Drawing.Color.FromArgb(240, 253, 244);
            this.btnFiltroEntradas.Cursor                     = System.Windows.Forms.Cursors.Hand;
            this.btnFiltroEntradas.FlatAppearance.BorderSize  = 1;
            this.btnFiltroEntradas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(167, 243, 208);
            this.btnFiltroEntradas.FlatStyle                  = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltroEntradas.Font                       = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltroEntradas.ForeColor                  = System.Drawing.Color.FromArgb(22, 101, 52);
            this.btnFiltroEntradas.Location                   = new System.Drawing.Point(224, 11);
            this.btnFiltroEntradas.Name                       = "btnFiltroEntradas";
            this.btnFiltroEntradas.Size                       = new System.Drawing.Size(110, 30);
            this.btnFiltroEntradas.Text                       = "▲  Entradas";
            this.btnFiltroEntradas.UseVisualStyleBackColor    = false;
            this.btnFiltroEntradas.Click                     += new System.EventHandler(this.btnFiltroEntradas_Click);

            this.btnFiltroSalidas.BackColor                  = System.Drawing.Color.FromArgb(254, 242, 242);
            this.btnFiltroSalidas.Cursor                     = System.Windows.Forms.Cursors.Hand;
            this.btnFiltroSalidas.FlatAppearance.BorderSize  = 1;
            this.btnFiltroSalidas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(254, 202, 202);
            this.btnFiltroSalidas.FlatStyle                  = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltroSalidas.Font                       = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltroSalidas.ForeColor                  = System.Drawing.Color.FromArgb(153, 27, 27);
            this.btnFiltroSalidas.Location                   = new System.Drawing.Point(342, 11);
            this.btnFiltroSalidas.Name                       = "btnFiltroSalidas";
            this.btnFiltroSalidas.Size                       = new System.Drawing.Size(105, 30);
            this.btnFiltroSalidas.Text                       = "▼  Salidas";
            this.btnFiltroSalidas.UseVisualStyleBackColor    = false;
            this.btnFiltroSalidas.Click                     += new System.EventHandler(this.btnFiltroSalidas_Click);

            this.btnFiltroTransferencias.BackColor                  = System.Drawing.Color.FromArgb(239, 246, 255);
            this.btnFiltroTransferencias.Cursor                     = System.Windows.Forms.Cursors.Hand;
            this.btnFiltroTransferencias.FlatAppearance.BorderSize  = 1;
            this.btnFiltroTransferencias.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(191, 219, 254);
            this.btnFiltroTransferencias.FlatStyle                  = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltroTransferencias.Font                       = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltroTransferencias.ForeColor                  = System.Drawing.Color.FromArgb(29, 78, 216);
            this.btnFiltroTransferencias.Location                   = new System.Drawing.Point(455, 11);
            this.btnFiltroTransferencias.Name                       = "btnFiltroTransferencias";
            this.btnFiltroTransferencias.Size                       = new System.Drawing.Size(140, 30);
            this.btnFiltroTransferencias.Text                       = "⇄  Transferencias";
            this.btnFiltroTransferencias.UseVisualStyleBackColor    = false;
            this.btnFiltroTransferencias.Click                     += new System.EventHandler(this.btnFiltroTransferencias_Click);

            this.btnFiltroAjustes.BackColor                  = System.Drawing.Color.FromArgb(255, 251, 235);
            this.btnFiltroAjustes.Cursor                     = System.Windows.Forms.Cursors.Hand;
            this.btnFiltroAjustes.FlatAppearance.BorderSize  = 1;
            this.btnFiltroAjustes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(253, 230, 138);
            this.btnFiltroAjustes.FlatStyle                  = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltroAjustes.Font                       = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnFiltroAjustes.ForeColor                  = System.Drawing.Color.FromArgb(146, 64, 14);
            this.btnFiltroAjustes.Location                   = new System.Drawing.Point(603, 11);
            this.btnFiltroAjustes.Name                       = "btnFiltroAjustes";
            this.btnFiltroAjustes.Size                       = new System.Drawing.Size(105, 30);
            this.btnFiltroAjustes.Text                       = "✏  Ajustes";
            this.btnFiltroAjustes.UseVisualStyleBackColor    = false;
            this.btnFiltroAjustes.Click                     += new System.EventHandler(this.btnFiltroAjustes_Click);

            this.pnlFiltros.Controls.Add(this.btnFiltroTodos);
            this.pnlFiltros.Controls.Add(this.btnFiltroHoy);
            this.pnlFiltros.Controls.Add(this.btnFiltroEntradas);
            this.pnlFiltros.Controls.Add(this.btnFiltroSalidas);
            this.pnlFiltros.Controls.Add(this.btnFiltroTransferencias);
            this.pnlFiltros.Controls.Add(this.btnFiltroAjustes);

            // ─────────────────────────────────────────
            // SEPARADOR HORIZONTAL
            // ─────────────────────────────────────────
            this.pnlSepH.BackColor = System.Drawing.Color.FromArgb(210, 215, 220);
            this.pnlSepH.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlSepH.Height    = 1;
            this.pnlSepH.Name      = "pnlSepH";

            // ─────────────────────────────────────────
            // DATAGRIDVIEW
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
            this.dgvMovimientos.CellFormatting             +=
                new System.Windows.Forms.DataGridViewCellFormattingEventHandler(
                    this.dgvMovimientos_CellFormatting);

            headerStyle.BackColor = System.Drawing.Color.FromArgb(10, 35, 66);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.dgvMovimientos.ColumnHeadersDefaultCellStyle = headerStyle;

            rowsStyle.Font               = new System.Drawing.Font("Segoe UI", 10F);
            rowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            rowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvMovimientos.RowsDefaultCellStyle = rowsStyle;

            this.dgvMovimientos.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(245, 247, 250);
            this.dgvMovimientos.DefaultCellStyle.Padding =
                new System.Windows.Forms.Padding(5, 0, 5, 0);

            // ─────────────────────────────────────────
            // AGREGAR AL FORMULARIO
            // Regla: Fill primero → Top de abajo hacia arriba
            // ─────────────────────────────────────────
            this.Controls.Add(this.dgvMovimientos);
            this.Controls.Add(this.pnlSepH);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlAcciones);
            this.Controls.Add(this.pnlHeader);

            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlAcciones.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        // TIMER
        private System.Windows.Forms.Timer timer1;

        // PANELES
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Panel pnlBusqueda;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Panel pnlSepH;

        // LABELS HEADER
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFechaHora;
        private System.Windows.Forms.Label lblUsuarioInfo;

        // BÚSQUEDA
        private System.Windows.Forms.Label   lblBuscarIcon;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button  btnLimpiarBusqueda;

        // BOTONES DE ACCIÓN
        private FontAwesome.Sharp.IconButton btnExportar;
        private FontAwesome.Sharp.IconButton btnNuevoMovimiento;

        // BOTONES FILTRO RÁPIDO
        private System.Windows.Forms.Button btnFiltroTodos;
        private System.Windows.Forms.Button btnFiltroHoy;
        private System.Windows.Forms.Button btnFiltroEntradas;
        private System.Windows.Forms.Button btnFiltroSalidas;
        private System.Windows.Forms.Button btnFiltroTransferencias;
        private System.Windows.Forms.Button btnFiltroAjustes;

        // MENÚ CONTEXTUAL
        private System.Windows.Forms.ContextMenuStrip cmsNuevoMovimiento;

        // GRID
        private System.Windows.Forms.DataGridView dgvMovimientos;
    }
}
