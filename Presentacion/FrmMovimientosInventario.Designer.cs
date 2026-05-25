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

            // CONTROLES
            this.lblTitulo         = new System.Windows.Forms.Label();
            this.pnlSep1           = new System.Windows.Forms.Panel();
            this.pnlFormulario     = new System.Windows.Forms.Panel();
            this.pnlSepV           = new System.Windows.Forms.Panel();
            this.label1            = new System.Windows.Forms.Label();
            this.label2            = new System.Windows.Forms.Label();
            this.label3            = new System.Windows.Forms.Label();
            this.label4            = new System.Windows.Forms.Label();
            this.label5            = new System.Windows.Forms.Label();
            this.cboTipoMovimiento = new System.Windows.Forms.ComboBox();
            this.cboProducto       = new System.Windows.Forms.ComboBox();
            this.cboBodega         = new System.Windows.Forms.ComboBox();
            this.txtCantidad       = new System.Windows.Forms.TextBox();
            this.txtObservacion    = new System.Windows.Forms.TextBox();
            this.btnNuevo          = new FontAwesome.Sharp.IconButton();
            this.btnGuardar        = new FontAwesome.Sharp.IconButton();
            this.btnExportar       = new FontAwesome.Sharp.IconButton();
            this.dgvMovimientos    = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.pnlFormulario.SuspendLayout();
            this.SuspendLayout();

            // ─────────────────────────────────────────
            // FORMULARIO
            // ─────────────────────────────────────────
            this.BackColor       = System.Drawing.Color.FromArgb(236, 240, 245);
            this.ClientSize      = new System.Drawing.Size(1350, 860);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name            = "FrmMovimientosInventario";
            this.Text            = "FrmMovimientosInventario";
            this.Load           += new System.EventHandler(this.FrmMovimientosInventario_Load);

            // ─────────────────────────────────────────
            // TITULO PRINCIPAL
            // ─────────────────────────────────────────
            this.lblTitulo.AutoSize  = true;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(10, 35, 66);
            this.lblTitulo.Location  = new System.Drawing.Point(50, 20);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.TabIndex  = 0;
            this.lblTitulo.Text      = "Movimientos de Inventario";

            // SEPARADOR HORIZONTAL SUPERIOR
            this.pnlSep1.BackColor = System.Drawing.Color.FromArgb(10, 35, 66);
            this.pnlSep1.Location  = new System.Drawing.Point(30, 78);
            this.pnlSep1.Name      = "pnlSep1";
            this.pnlSep1.Size      = new System.Drawing.Size(1290, 2);
            this.pnlSep1.TabIndex  = 1;

            // ─────────────────────────────────────────
            // PANEL IZQUIERDO — CARD DE CAPTURA
            // ─────────────────────────────────────────
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Location  = new System.Drawing.Point(30, 100);
            this.pnlFormulario.Name      = "pnlFormulario";
            this.pnlFormulario.Size      = new System.Drawing.Size(455, 700);
            this.pnlFormulario.TabIndex  = 2;

            // SEPARADOR VERTICAL
            this.pnlSepV.BackColor = System.Drawing.Color.FromArgb(210, 215, 220);
            this.pnlSepV.Location  = new System.Drawing.Point(492, 100);
            this.pnlSepV.Name      = "pnlSepV";
            this.pnlSepV.Size      = new System.Drawing.Size(2, 700);
            this.pnlSepV.TabIndex  = 3;

            // ─────────────────────────────────────────
            // LABELS (posición relativa al panel)
            // ─────────────────────────────────────────
            Label[]  labels  = { label1, label2, label3, label4, label5 };
            string[] textos  = { "Tipo Movimiento", "Producto", "Bodega", "Cantidad", "Observación" };
            int[]    labelY  = { 20, 104, 188, 272, 356 };

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].AutoSize  = true;
                labels[i].Font      = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
                labels[i].ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
                labels[i].Location  = new System.Drawing.Point(20, labelY[i]);
                labels[i].Name      = "label" + (i + 1);
                labels[i].TabIndex  = 10 + i;
                labels[i].Text      = textos[i];
            }

            // ─────────────────────────────────────────
            // COMBOBOXES (posición relativa al panel)
            // ─────────────────────────────────────────
            ComboBox[] combos     = { cboTipoMovimiento, cboProducto, cboBodega };
            int[]      comboY     = { 48, 132, 216 };
            string[]   comboNames = { "cboTipoMovimiento", "cboProducto", "cboBodega" };

            for (int i = 0; i < combos.Length; i++)
            {
                combos[i].DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                combos[i].Font          = new System.Drawing.Font("Segoe UI", 11F);
                combos[i].Location      = new System.Drawing.Point(20, comboY[i]);
                combos[i].Name          = comboNames[i];
                combos[i].Size          = new System.Drawing.Size(415, 32);
                combos[i].TabIndex      = 20 + i;
            }

            // ─────────────────────────────────────────
            // CANTIDAD
            // ─────────────────────────────────────────
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtCantidad.Location    = new System.Drawing.Point(20, 300);
            this.txtCantidad.Name        = "txtCantidad";
            this.txtCantidad.Size        = new System.Drawing.Size(200, 32);
            this.txtCantidad.TabIndex    = 30;
            this.txtCantidad.KeyPress   += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);

            // ─────────────────────────────────────────
            // OBSERVACION
            // ─────────────────────────────────────────
            this.txtObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservacion.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtObservacion.Location    = new System.Drawing.Point(20, 384);
            this.txtObservacion.Multiline   = true;
            this.txtObservacion.Name        = "txtObservacion";
            this.txtObservacion.ScrollBars  = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacion.Size        = new System.Drawing.Size(415, 110);
            this.txtObservacion.TabIndex    = 31;

            // ─────────────────────────────────────────
            // BTN NUEVO
            // ─────────────────────────────────────────
            this.btnNuevo.BackColor                 = System.Drawing.Color.FromArgb(59, 130, 246);
            this.btnNuevo.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font                      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor                 = System.Drawing.Color.White;
            this.btnNuevo.IconChar                  = FontAwesome.Sharp.IconChar.CirclePlus;
            this.btnNuevo.IconColor                 = System.Drawing.Color.White;
            this.btnNuevo.IconFont                  = FontAwesome.Sharp.IconFont.Auto;
            this.btnNuevo.IconSize                  = 20;
            this.btnNuevo.Location                  = new System.Drawing.Point(20, 530);
            this.btnNuevo.Name                      = "btnNuevo";
            this.btnNuevo.Size                      = new System.Drawing.Size(120, 46);
            this.btnNuevo.TabIndex                  = 40;
            this.btnNuevo.Text                      = " Nuevo";
            this.btnNuevo.TextImageRelation         = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor   = false;
            this.btnNuevo.Click                    += new System.EventHandler(this.btnNuevo_Click);

            // ─────────────────────────────────────────
            // BTN REGISTRAR
            // ─────────────────────────────────────────
            this.btnGuardar.BackColor                 = System.Drawing.Color.FromArgb(34, 197, 94);
            this.btnGuardar.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font                      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor                 = System.Drawing.Color.White;
            this.btnGuardar.IconChar                  = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnGuardar.IconColor                 = System.Drawing.Color.White;
            this.btnGuardar.IconFont                  = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize                  = 20;
            this.btnGuardar.Location                  = new System.Drawing.Point(148, 530);
            this.btnGuardar.Name                      = "btnGuardar";
            this.btnGuardar.Size                      = new System.Drawing.Size(140, 46);
            this.btnGuardar.TabIndex                  = 41;
            this.btnGuardar.Text                      = " Registrar";
            this.btnGuardar.TextImageRelation         = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor   = false;
            this.btnGuardar.Click                    += new System.EventHandler(this.btnGuardar_Click);

            // ─────────────────────────────────────────
            // BTN EXPORTAR
            // ─────────────────────────────────────────
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
            this.btnExportar.Location                  = new System.Drawing.Point(296, 530);
            this.btnExportar.Name                      = "btnExportar";
            this.btnExportar.Size                      = new System.Drawing.Size(175, 46);
            this.btnExportar.TabIndex                  = 42;
            this.btnExportar.Text                      = " Exportar Excel";
            this.btnExportar.TextImageRelation         = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.UseVisualStyleBackColor   = false;
            this.btnExportar.Click                    += new System.EventHandler(this.btnExportar_Click);

            // ─────────────────────────────────────────
            // DATAGRIDVIEW — protagonista visual derecho
            // ─────────────────────────────────────────
            this.dgvMovimientos.AllowUserToAddRows          = false;
            this.dgvMovimientos.AllowUserToDeleteRows       = false;
            this.dgvMovimientos.AllowUserToResizeRows       = false;
            this.dgvMovimientos.Anchor                      = (System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Top    |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left   |
                System.Windows.Forms.AnchorStyles.Right);
            this.dgvMovimientos.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovimientos.BackgroundColor             = System.Drawing.Color.White;
            this.dgvMovimientos.BorderStyle                 = System.Windows.Forms.BorderStyle.None;
            this.dgvMovimientos.CellBorderStyle             = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMovimientos.ColumnHeadersHeight         = 45;
            this.dgvMovimientos.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMovimientos.EnableHeadersVisualStyles   = false;
            this.dgvMovimientos.GridColor                   = System.Drawing.Color.FromArgb(225, 225, 225);
            this.dgvMovimientos.Location                    = new System.Drawing.Point(502, 100);
            this.dgvMovimientos.MultiSelect                 = false;
            this.dgvMovimientos.Name                        = "dgvMovimientos";
            this.dgvMovimientos.ReadOnly                    = true;
            this.dgvMovimientos.RowHeadersVisible           = false;
            this.dgvMovimientos.RowHeadersWidth             = 51;
            this.dgvMovimientos.RowTemplate.Height          = 38;
            this.dgvMovimientos.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovimientos.Size                        = new System.Drawing.Size(818, 700);
            this.dgvMovimientos.TabIndex                    = 50;

            // ESTILO CABECERA
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
                new System.Windows.Forms.Padding(5);

            // ─────────────────────────────────────────
            // AGREGAR CONTROLES AL CARD IZQUIERDO
            // ─────────────────────────────────────────
            this.pnlFormulario.Controls.Add(this.label1);
            this.pnlFormulario.Controls.Add(this.cboTipoMovimiento);
            this.pnlFormulario.Controls.Add(this.label2);
            this.pnlFormulario.Controls.Add(this.cboProducto);
            this.pnlFormulario.Controls.Add(this.label3);
            this.pnlFormulario.Controls.Add(this.cboBodega);
            this.pnlFormulario.Controls.Add(this.label4);
            this.pnlFormulario.Controls.Add(this.txtCantidad);
            this.pnlFormulario.Controls.Add(this.label5);
            this.pnlFormulario.Controls.Add(this.txtObservacion);
            this.pnlFormulario.Controls.Add(this.btnNuevo);
            this.pnlFormulario.Controls.Add(this.btnGuardar);
            this.pnlFormulario.Controls.Add(this.btnExportar);

            // ─────────────────────────────────────────
            // AGREGAR CONTROLES AL FORMULARIO
            // ─────────────────────────────────────────
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlSep1);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.pnlSepV);
            this.Controls.Add(this.dgvMovimientos);

            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // TITULO Y SEPARADORES
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlSep1;
        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Panel pnlSepV;

        // LABELS
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

        // COMBOBOXES
        private System.Windows.Forms.ComboBox cboTipoMovimiento;
        private System.Windows.Forms.ComboBox cboProducto;
        private System.Windows.Forms.ComboBox cboBodega;

        // TEXTBOXES
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtObservacion;

        // BOTONES
        private FontAwesome.Sharp.IconButton btnNuevo;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnExportar;

        // DATAGRIDVIEW
        private System.Windows.Forms.DataGridView dgvMovimientos;
    }
}
