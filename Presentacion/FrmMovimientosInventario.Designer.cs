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
            // VERIFICA SI LOS COMPONENTES DEBEN LIBERARSE
            if (disposing &&
                (components != null))
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
            // ESTILOS DEL GRID
            DataGridViewCellStyle headerStyle =
                new DataGridViewCellStyle();

            DataGridViewCellStyle rowsStyle =
                new DataGridViewCellStyle();

            // LABEL TITULO
            this.lblTitulo =
                new Label();

            // LABELS DEL FORMULARIO
            this.label1 =
                new Label();

            this.label2 =
                new Label();

            this.label3 =
                new Label();

            this.label4 =
                new Label();

            this.label5 =
                new Label();

            // COMBOBOX
            this.cboTipoMovimiento =
                new ComboBox();

            this.cboProducto =
                new ComboBox();

            this.cboBodega =
                new ComboBox();

            // TEXTBOX
            this.txtCantidad =
                new TextBox();

            this.txtObservacion =
                new TextBox();

            // BOTONES
            this.btnNuevo =
                new IconButton();

            this.btnGuardar =
                new IconButton();

            this.btnExportar =
                new IconButton();

            // GRID MOVIMIENTOS
            this.dgvMovimientos =
                new DataGridView();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvMovimientos))
                .BeginInit();

            // SUSPENDE EL DISEÑO
            this.SuspendLayout();

            // FORM

            // COLOR DE FONDO
            this.BackColor =
                Color.FromArgb(236, 240, 245);

            // TAMAÑO DEL FORMULARIO
            this.ClientSize =
                new Size(1400, 900);

            // BORDE DEL FORMULARIO
            this.FormBorderStyle =
                FormBorderStyle.None;

            // TITULO DEL FORMULARIO
            this.Text =
                "FrmMovimientosInventario";

            // EVENTO LOAD
            this.Load +=
                new System.EventHandler(
                    this.FrmMovimientosInventario_Load);

            // TITULO

            // AJUSTE AUTOMATICO
            lblTitulo.AutoSize = true;

            // FUENTE DEL TITULO
            lblTitulo.Font =
                new Font(
                    "Segoe UI",
                    30F,
                    FontStyle.Bold);

            // COLOR DEL TITULO
            lblTitulo.ForeColor =
                Color.FromArgb(10, 35, 66);

            // POSICION DEL TITULO
            lblTitulo.Location =
                new Point(50, 30);

            // TEXTO DEL TITULO
            lblTitulo.Text =
                "Movimientos de Inventario";

            // LABELS

            // ARREGLO DE LABELS
            Label[] labels =
            {
                label1,
                label2,
                label3,
                label4,
                label5
            };

            // TEXTOS DE LABELS
            string[] textos =
            {
                "Tipo Movimiento",
                "Producto",
                "Bodega",
                "Cantidad",
                "Observación"
            };

            // POSICIONES Y
            int[] posY =
            {
                130,
                230,
                330,
                430,
                530
            };

            // CONFIGURA LABELS
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].AutoSize = true;

                labels[i].Font =
                    new Font(
                        "Segoe UI Semibold",
                        13F,
                        FontStyle.Bold);

                labels[i].Location =
                    new Point(60, posY[i]);

                labels[i].Text =
                    textos[i];
            }

            // COMBOS

            // ARREGLO DE COMBOBOX
            ComboBox[] combos =
            {
                cboTipoMovimiento,
                cboProducto,
                cboBodega
            };

            // POSICIONES Y DE COMBOBOX
            int[] comboY =
            {
                165,
                265,
                365
            };

            // CONFIGURA COMBOBOX
            for (int i = 0; i < combos.Length; i++)
            {
                combos[i].Font =
                    new Font(
                        "Segoe UI",
                        12F);

                combos[i].Location =
                    new Point(60, comboY[i]);

                combos[i].Size =
                    new Size(400, 38);

                combos[i].DropDownStyle =
                    ComboBoxStyle.DropDownList;
            }

            // TXT CANTIDAD

            // FUENTE DEL TEXTBOX
            txtCantidad.Font =
                new Font(
                    "Segoe UI",
                    12F);

            // POSICION DEL TEXTBOX
            txtCantidad.Location =
                new Point(60, 465);

            // TAMAÑO DEL TEXTBOX
            txtCantidad.Size =
                new Size(250, 38);

            // BORDE DEL TEXTBOX
            txtCantidad.BorderStyle =
                BorderStyle.FixedSingle;

            // TXT OBSERVACION

            // FUENTE DEL TEXTBOX
            txtObservacion.Font =
                new Font(
                    "Segoe UI",
                    11F);

            // POSICION DEL TEXTBOX
            txtObservacion.Location =
                new Point(60, 565);

            // TAMAÑO DEL TEXTBOX
            txtObservacion.Size =
                new Size(650, 90);

            // MULTILINEA
            txtObservacion.Multiline =
                true;

            // BORDE DEL TEXTBOX
            txtObservacion.BorderStyle =
                BorderStyle.FixedSingle;

            // BTN NUEVO

            ConfigurarBoton(
                btnNuevo,
                " Nuevo",
                IconChar.CirclePlus,
                Color.FromArgb(52, 152, 219),
                60);

            // BTN GUARDAR

            ConfigurarBoton(
                btnGuardar,
                " Registrar",
                IconChar.FloppyDisk,
                Color.FromArgb(46, 204, 113),
                270);

            // BTN EXPORTAR

            ConfigurarBoton(
                btnExportar,
                " Exportar Excel",
                IconChar.FileExcel,
                Color.FromArgb(39, 174, 96),
                480);

            // GRID

            // DESHABILITA AGREGAR FILAS
            dgvMovimientos.AllowUserToAddRows = false;

            // DESHABILITA ELIMINAR FILAS
            dgvMovimientos.AllowUserToDeleteRows = false;

            // AJUSTE AUTOMATICO DE COLUMNAS
            dgvMovimientos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // COLOR DE FONDO
            dgvMovimientos.BackgroundColor =
                Color.White;

            // BORDE DEL GRID
            dgvMovimientos.BorderStyle =
                BorderStyle.None;

            // POSICION DEL GRID
            dgvMovimientos.Location =
                new Point(760, 140);

            // TAMAÑO DEL GRID
            dgvMovimientos.Size =
                new Size(820, 650);

            // SOLO LECTURA
            dgvMovimientos.ReadOnly = true;

            // OCULTA HEADERS DE FILAS
            dgvMovimientos.RowHeadersVisible =
                false;

            // SELECCION COMPLETA
            dgvMovimientos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // DESHABILITA ESTILOS VISUALES
            dgvMovimientos.EnableHeadersVisualStyles =
                false;

            // ALTURA HEADER
            dgvMovimientos.ColumnHeadersHeight = 45;

            // ESTILO HEADER

            // COLOR HEADER
            headerStyle.BackColor =
                Color.FromArgb(10, 35, 66);

            // COLOR TEXTO HEADER
            headerStyle.ForeColor =
                Color.White;

            // FUENTE HEADER
            headerStyle.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            // ASIGNA ESTILO HEADER
            dgvMovimientos.ColumnHeadersDefaultCellStyle =
                headerStyle;

            // ESTILO FILAS

            // FUENTE FILAS
            rowsStyle.Font =
                new Font(
                    "Segoe UI",
                    10F);

            // COLOR SELECCION
            rowsStyle.SelectionBackColor =
                Color.FromArgb(52, 152, 219);

            // COLOR TEXTO SELECCION
            rowsStyle.SelectionForeColor =
                Color.White;

            // ASIGNA ESTILO FILAS
            dgvMovimientos.RowsDefaultCellStyle =
                rowsStyle;

            // EVENTOS

            // EVENTO BOTON GUARDAR
            btnGuardar.Click +=
                new System.EventHandler(
                    this.btnGuardar_Click);

            // EVENTO BOTON EXPORTAR
            btnExportar.Click +=
                new System.EventHandler(
                    this.btnExportar_Click);

            // EVENTO BOTON NUEVO
            btnNuevo.Click +=
                new System.EventHandler(
                    this.btnNuevo_Click);

            // CONTROLES

            // AGREGA TITULO
            this.Controls.Add(lblTitulo);

            // AGREGA LABELS
            this.Controls.Add(label1);
            this.Controls.Add(label2);
            this.Controls.Add(label3);
            this.Controls.Add(label4);
            this.Controls.Add(label5);

            // AGREGA COMBOBOX
            this.Controls.Add(cboTipoMovimiento);
            this.Controls.Add(cboProducto);
            this.Controls.Add(cboBodega);

            // AGREGA TEXTBOX
            this.Controls.Add(txtCantidad);
            this.Controls.Add(txtObservacion);

            // AGREGA BOTONES
            this.Controls.Add(btnNuevo);
            this.Controls.Add(btnGuardar);
            this.Controls.Add(btnExportar);

            // AGREGA GRID
            this.Controls.Add(dgvMovimientos);

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvMovimientos))
                .EndInit();

            // REANUDA EL DISEÑO
            this.ResumeLayout(false);

            this.PerformLayout();
        }

        // BOTONES

        private void ConfigurarBoton(
            IconButton boton,
            string texto,
            IconChar icono,
            Color color,
            int x)
        {
            // COLOR DEL BOTON
            boton.BackColor =
                color;

            // ESTILO DEL BOTON
            boton.FlatStyle =
                FlatStyle.Flat;

            // BORDE DEL BOTON
            boton.FlatAppearance.BorderSize = 0;

            // COLOR DEL TEXTO
            boton.ForeColor =
                Color.White;

            // FUENTE DEL BOTON
            boton.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            // ICONO DEL BOTON
            boton.IconChar =
                icono;

            // COLOR DEL ICONO
            boton.IconColor =
                Color.White;

            // FUENTE DEL ICONO
            boton.IconFont =
                IconFont.Auto;

            // TAMAÑO DEL ICONO
            boton.IconSize = 28;

            // TEXTO DEL BOTON
            boton.Text =
                texto;

            // RELACION TEXTO E IMAGEN
            boton.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            // TAMAÑO DEL BOTON
            boton.Size =
                new Size(180, 58);

            // POSICION DEL BOTON
            boton.Location =
                new Point(x, 700);

            // CURSOR DEL BOTON
            boton.Cursor =
                Cursors.Hand;
        }

        #endregion

        // LABEL TITULO
        private Label lblTitulo;

        // LABELS
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;

        // COMBOBOX
        private ComboBox cboTipoMovimiento;
        private ComboBox cboProducto;
        private ComboBox cboBodega;

        // TEXTBOX
        private TextBox txtCantidad;
        private TextBox txtObservacion;

        // BOTONES
        private IconButton btnNuevo;
        private IconButton btnGuardar;
        private IconButton btnExportar;

        // GRID
        private DataGridView dgvMovimientos;
    }
}