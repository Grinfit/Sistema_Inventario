// CLASE PARCIAL DEL FORMULARIO LOGS
namespace Sistema_Inventario.Presentacion
{
    partial class FrmLogs
    {
        // CONTENEDOR DE COMPONENTES
        private System.ComponentModel.IContainer components = null;

        // METODO PARA LIBERAR RECURSOS
        protected override void Dispose(bool disposing)
        {
            // VERIFICA SI LOS COMPONENTES DEBEN LIBERARSE
            if (disposing && (components != null))
            {
                // LIBERA LOS COMPONENTES
                components.Dispose();
            }

            // LLAMA AL METODO BASE
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        // METODO PARA INICIALIZAR COMPONENTES
        private void InitializeComponent()
        {
            // LABEL TITULO
            this.lblTitulo = new System.Windows.Forms.Label();

            // LABEL BUSCAR
            this.lblBuscar = new System.Windows.Forms.Label();

            // TEXTBOX BUSCAR
            this.txtBuscar = new System.Windows.Forms.TextBox();

            // LABEL EVENTO
            this.lblEvento = new System.Windows.Forms.Label();

            // COMBOBOX EVENTOS
            this.cboEvento = new System.Windows.Forms.ComboBox();

            // BOTONES
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.btnRefrescar = new FontAwesome.Sharp.IconButton();
            this.btnExportar = new FontAwesome.Sharp.IconButton();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();

            // DATAGRIDVIEW LOGS
            this.dgvLogs = new System.Windows.Forms.DataGridView();

            // LABEL TOTAL LOGS
            this.lblTotalLogs = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();

            // SUSPENDE EL DISEÑO
            this.SuspendLayout();

            // FORM

            // CONFIGURA EL ESCALADO
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);

            // CONFIGURA EL MODO DE ESCALADO
            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            // COLOR DE FONDO
            this.BackColor =
                System.Drawing.Color.FromArgb(240, 242, 245);

            // TAMAÑO DEL FORMULARIO
            this.ClientSize =
                new System.Drawing.Size(1600, 860);

            // BORDE DEL FORMULARIO
            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.None;

            // NOMBRE DEL FORMULARIO
            this.Name = "FrmLogs";

            // TITULO DEL FORMULARIO
            this.Text = "FrmLogs";

            // EVENTO LOAD
            this.Load +=
                new System.EventHandler(this.FrmLogs_Load);

            // TITULO

            // AJUSTE AUTOMATICO
            this.lblTitulo.AutoSize = true;

            // FUENTE DEL TITULO
            this.lblTitulo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    28F,
                    System.Drawing.FontStyle.Bold);

            // COLOR DEL TITULO
            this.lblTitulo.ForeColor =
                System.Drawing.Color.FromArgb(5, 35, 85);

            // POSICION DEL TITULO
            this.lblTitulo.Location =
                new System.Drawing.Point(40, 30);

            // TEXTO DEL TITULO
            this.lblTitulo.Text =
                "Gestión de Logs";

            // LABEL BUSCAR

            // AJUSTE AUTOMATICO
            this.lblBuscar.AutoSize = true;

            // FUENTE DEL LABEL
            this.lblBuscar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    13F,
                    System.Drawing.FontStyle.Bold);

            // POSICION DEL LABEL
            this.lblBuscar.Location =
                new System.Drawing.Point(50, 145);

            // TEXTO DEL LABEL
            this.lblBuscar.Text =
                "Buscar";

            // TXT BUSCAR

            // FUENTE DEL TEXTBOX
            this.txtBuscar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F);

            // POSICION DEL TEXTBOX
            this.txtBuscar.Location =
                new System.Drawing.Point(50, 185);

            // TAMAÑO DEL TEXTBOX
            this.txtBuscar.Size =
                new System.Drawing.Size(330, 34);

            // LABEL EVENTO

            // AJUSTE AUTOMATICO
            this.lblEvento.AutoSize = true;

            // FUENTE DEL LABEL
            this.lblEvento.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    13F,
                    System.Drawing.FontStyle.Bold);

            // POSICION DEL LABEL
            this.lblEvento.Location =
                new System.Drawing.Point(430, 145);

            // TEXTO DEL LABEL
            this.lblEvento.Text =
                "Evento";

            // COMBO EVENTO

            // FUENTE DEL COMBOBOX
            this.cboEvento.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F);

            // POSICION DEL COMBOBOX
            this.cboEvento.Location =
                new System.Drawing.Point(430, 185);

            // TAMAÑO DEL COMBOBOX
            this.cboEvento.Size =
                new System.Drawing.Size(260, 36);

            // ESTILO DEL COMBOBOX
            this.cboEvento.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            // BOTON BUSCAR

            // COLOR DEL BOTON
            this.btnBuscar.BackColor =
                System.Drawing.Color.FromArgb(52, 152, 219);

            // ESTILO DEL BOTON
            this.btnBuscar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            // BORDE DEL BOTON
            this.btnBuscar.FlatAppearance.BorderSize = 0;

            // FUENTE DEL BOTON
            this.btnBuscar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold);

            // COLOR DEL TEXTO
            this.btnBuscar.ForeColor =
                System.Drawing.Color.White;

            // ICONO DEL BOTON
            this.btnBuscar.IconChar =
                FontAwesome.Sharp.IconChar.MagnifyingGlass;

            // COLOR DEL ICONO
            this.btnBuscar.IconColor =
                System.Drawing.Color.White;

            // FUENTE DEL ICONO
            this.btnBuscar.IconFont =
                FontAwesome.Sharp.IconFont.Auto;

            // TAMAÑO DEL ICONO
            this.btnBuscar.IconSize = 32;

            // ALINEACION DE IMAGEN
            this.btnBuscar.ImageAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            // POSICION DEL BOTON
            this.btnBuscar.Location =
                new System.Drawing.Point(760, 170);

            // TAMAÑO DEL BOTON
            this.btnBuscar.Size =
                new System.Drawing.Size(190, 65);

            // TEXTO DEL BOTON
            this.btnBuscar.Text =
                " Buscar";

            // RELACION TEXTO E IMAGEN
            this.btnBuscar.TextImageRelation =
                System.Windows.Forms.TextImageRelation.ImageBeforeText;

            // CURSOR DEL BOTON
            this.btnBuscar.Cursor =
                System.Windows.Forms.Cursors.Hand;

            // BOTON REFRESCAR

            // COLOR DEL BOTON
            this.btnRefrescar.BackColor =
                System.Drawing.Color.FromArgb(46, 204, 113);

            // ESTILO DEL BOTON
            this.btnRefrescar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            // BORDE DEL BOTON
            this.btnRefrescar.FlatAppearance.BorderSize = 0;

            // FUENTE DEL BOTON
            this.btnRefrescar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold);

            // COLOR DEL TEXTO
            this.btnRefrescar.ForeColor =
                System.Drawing.Color.White;

            // ICONO DEL BOTON
            this.btnRefrescar.IconChar =
                FontAwesome.Sharp.IconChar.Rotate;

            // COLOR DEL ICONO
            this.btnRefrescar.IconColor =
                System.Drawing.Color.White;

            // FUENTE DEL ICONO
            this.btnRefrescar.IconFont =
                FontAwesome.Sharp.IconFont.Auto;

            // TAMAÑO DEL ICONO
            this.btnRefrescar.IconSize = 24;

            // TEXTO DEL BOTON
            this.btnRefrescar.Text = "Refrescar";

            // RELACION ICONO Y TEXTO
            this.btnRefrescar.TextImageRelation =
                System.Windows.Forms.TextImageRelation.ImageBeforeText;

            // ALINEACION DE IMAGEN
            this.btnRefrescar.ImageAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            // ALINEACION DEL TEXTO
            this.btnRefrescar.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // TAMAÑO DEL BOTON
            this.btnRefrescar.Size =
                new System.Drawing.Size(190, 65);

            // POSICION DEL BOTON
            this.btnRefrescar.Location =
                new System.Drawing.Point(980, 170);

            // CURSOR DEL BOTON
            this.btnRefrescar.Cursor =
                System.Windows.Forms.Cursors.Hand;

            // CONFIGURA VISUAL STYLE
            this.btnRefrescar.UseVisualStyleBackColor = false;

            // BOTON EXPORTAR

            // COLOR DEL BOTON
            this.btnExportar.BackColor =
                System.Drawing.Color.FromArgb(155, 89, 182);

            // ESTILO DEL BOTON
            this.btnExportar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            // BORDE DEL BOTON
            this.btnExportar.FlatAppearance.BorderSize = 0;

            // FUENTE DEL BOTON
            this.btnExportar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold);

            // COLOR DEL TEXTO
            this.btnExportar.ForeColor =
                System.Drawing.Color.White;

            // ICONO DEL BOTON
            this.btnExportar.IconChar =
                FontAwesome.Sharp.IconChar.FileExport;

            // COLOR DEL ICONO
            this.btnExportar.IconColor =
                System.Drawing.Color.White;

            // FUENTE DEL ICONO
            this.btnExportar.IconFont =
                FontAwesome.Sharp.IconFont.Auto;

            // TAMAÑO DEL ICONO
            this.btnExportar.IconSize = 32;

            // ALINEACION DE IMAGEN
            this.btnExportar.ImageAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            // POSICION DEL BOTON
            this.btnExportar.Location =
                new System.Drawing.Point(1200, 170);

            // TAMAÑO DEL BOTON
            this.btnExportar.Size =
                new System.Drawing.Size(190, 65);

            // TEXTO DEL BOTON
            this.btnExportar.Text =
                " Exportar";

            // RELACION TEXTO E IMAGEN
            this.btnExportar.TextImageRelation =
                System.Windows.Forms.TextImageRelation.ImageBeforeText;

            // CURSOR DEL BOTON
            this.btnExportar.Cursor =
                System.Windows.Forms.Cursors.Hand;

            // BOTON LIMPIAR

            // COLOR DEL BOTON
            this.btnLimpiar.BackColor =
                System.Drawing.Color.FromArgb(231, 76, 60);

            // ESTILO DEL BOTON
            this.btnLimpiar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            // BORDE DEL BOTON
            this.btnLimpiar.FlatAppearance.BorderSize = 0;

            // FUENTE DEL BOTON
            this.btnLimpiar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold);

            // COLOR DEL TEXTO
            this.btnLimpiar.ForeColor =
                System.Drawing.Color.White;

            // ICONO DEL BOTON
            this.btnLimpiar.IconChar =
                FontAwesome.Sharp.IconChar.Trash;

            // COLOR DEL ICONO
            this.btnLimpiar.IconColor =
                System.Drawing.Color.White;

            // FUENTE DEL ICONO
            this.btnLimpiar.IconFont =
                FontAwesome.Sharp.IconFont.Auto;

            // TAMAÑO DEL ICONO
            this.btnLimpiar.IconSize = 32;

            // ALINEACION DE IMAGEN
            this.btnLimpiar.ImageAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            // POSICION DEL BOTON
            this.btnLimpiar.Location =
                new System.Drawing.Point(1420, 170);

            // TAMAÑO DEL BOTON
            this.btnLimpiar.Size =
                new System.Drawing.Size(190, 65);

            // TEXTO DEL BOTON
            this.btnLimpiar.Text =
                " Limpiar";

            // RELACION TEXTO E IMAGEN
            this.btnLimpiar.TextImageRelation =
                System.Windows.Forms.TextImageRelation.ImageBeforeText;

            // CURSOR DEL BOTON
            this.btnLimpiar.Cursor =
                System.Windows.Forms.Cursors.Hand;

            // TOTAL LOGS

            // AJUSTE AUTOMATICO
            this.lblTotalLogs.AutoSize = true;

            // FUENTE DEL LABEL
            this.lblTotalLogs.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    14F,
                    System.Drawing.FontStyle.Bold);

            // COLOR DEL LABEL
            this.lblTotalLogs.ForeColor =
                System.Drawing.Color.FromArgb(5, 35, 85);

            // POSICION DEL LABEL
            this.lblTotalLogs.Location =
                new System.Drawing.Point(50, 255);

            // TEXTO DEL LABEL
            this.lblTotalLogs.Text =
                "Total Logs: 0";

            // DATAGRIDVIEW

            // DESHABILITA AGREGAR FILAS
            this.dgvLogs.AllowUserToAddRows = false;

            // DESHABILITA ELIMINAR FILAS
            this.dgvLogs.AllowUserToDeleteRows = false;

            // DESHABILITA REDIMENSIONAR FILAS
            this.dgvLogs.AllowUserToResizeRows = false;

            // ANCHOR DEL GRID
            this.dgvLogs.Anchor =
                ((System.Windows.Forms.AnchorStyles)(
                ((System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right));

            // AJUSTE AUTOMATICO DE COLUMNAS
            this.dgvLogs.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // COLOR DE FONDO
            this.dgvLogs.BackgroundColor =
                System.Drawing.Color.White;

            // BORDE DEL GRID
            this.dgvLogs.BorderStyle =
                System.Windows.Forms.BorderStyle.None;

            // BORDE DE CELDAS
            this.dgvLogs.CellBorderStyle =
                System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;

            // BORDE DE HEADER
            this.dgvLogs.ColumnHeadersBorderStyle =
                System.Windows.Forms.DataGridViewHeaderBorderStyle.None;

            // ALTURA HEADER
            this.dgvLogs.ColumnHeadersHeight = 55;

            // DESHABILITA ESTILOS VISUALES
            this.dgvLogs.EnableHeadersVisualStyles = false;

            // COLOR GRID
            this.dgvLogs.GridColor =
                System.Drawing.Color.FromArgb(230, 230, 230);

            // POSICION DEL GRID
            this.dgvLogs.Location =
                new System.Drawing.Point(40, 310);

            // DESHABILITA MULTISELECT
            this.dgvLogs.MultiSelect = false;

            // NOMBRE DEL GRID
            this.dgvLogs.Name = "dgvLogs";

            // SOLO LECTURA
            this.dgvLogs.ReadOnly = true;

            // OCULTA HEADERS DE FILAS
            this.dgvLogs.RowHeadersVisible = false;

            // ALTURA DE FILAS
            this.dgvLogs.RowTemplate.Height = 45;

            // SCROLL VERTICAL
            this.dgvLogs.ScrollBars =
                System.Windows.Forms.ScrollBars.Vertical;

            // SELECCION COMPLETA
            this.dgvLogs.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // TAMAÑO DEL GRID
            this.dgvLogs.Size =
                new System.Drawing.Size(1520, 500);

            // TABINDEX
            this.dgvLogs.TabIndex = 0;

            // HEADER STYLE

            // COLOR HEADER
            this.dgvLogs.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(5, 35, 85);

            // COLOR TEXTO HEADER
            this.dgvLogs.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;

            // ALINEACION HEADER
            this.dgvLogs.ColumnHeadersDefaultCellStyle.Alignment =
                System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;

            // FUENTE HEADER
            this.dgvLogs.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold);

            // FILAS

            // FUENTE FILAS
            this.dgvLogs.DefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F);

            // COLOR SELECCION
            this.dgvLogs.DefaultCellStyle.SelectionBackColor =
                System.Drawing.Color.FromArgb(52, 152, 219);

            // COLOR TEXTO SELECCION
            this.dgvLogs.DefaultCellStyle.SelectionForeColor =
                System.Drawing.Color.White;

            // COLOR FILAS ALTERNAS
            this.dgvLogs.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(245, 245, 245);

            // CONTROLES

            // AGREGA CONTROLES AL FORMULARIO
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

            // REANUDA EL DISEÑO
            this.ResumeLayout(false);

            this.PerformLayout();
        }

        #endregion

        // DATAGRIDVIEW LOGS
        private System.Windows.Forms.DataGridView dgvLogs;

        // LABELS
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblEvento;
        private System.Windows.Forms.ComboBox cboEvento;

        // BOTONES
        private FontAwesome.Sharp.IconButton btnBuscar;
        private FontAwesome.Sharp.IconButton btnRefrescar;
        private FontAwesome.Sharp.IconButton btnExportar;
        private FontAwesome.Sharp.IconButton btnLimpiar;

        // LABEL TOTAL LOGS
        private System.Windows.Forms.Label lblTotalLogs;
    }
}