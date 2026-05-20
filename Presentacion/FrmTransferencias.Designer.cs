// IMPORTACION DE LIBRERIAS NECESARIAS
using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Inventario.Presentacion
{
    // CLASE PARCIAL DEL FORMULARIO DE TRANSFERENCIAS
    partial class FrmTransferencias
    {
        // CONTENEDOR DE COMPONENTES DEL FORMULARIO
        private System.ComponentModel.IContainer components = null;

        // METODO PARA LIBERAR LOS RECURSOS UTILIZADOS
        protected override void Dispose(
            bool disposing)
        {
            // VERIFICA SI LOS COMPONENTES DEBEN LIBERARSE
            if (disposing &&
                (components != null))
            {
                // LIBERA LOS COMPONENTES
                components.Dispose();
            }

            // EJECUTA EL METODO BASE
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        // METODO DONDE SE INICIALIZAN LOS COMPONENTES
        private void InitializeComponent()
        {
            // ESTILO PARA EL HEADER DEL DATAGRIDVIEW
            DataGridViewCellStyle headerStyle =
                new DataGridViewCellStyle();

            // ESTILO PARA LAS FILAS DEL DATAGRIDVIEW
            DataGridViewCellStyle rowsStyle =
                new DataGridViewCellStyle();

            // CREACION DEL LABEL TITULO
            this.lblTitulo = new Label();

            // CREACION DE LABELS
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();

            // CREACION DE COMBOBOX
            this.cboProducto = new ComboBox();
            this.cboBodegaOrigen = new ComboBox();
            this.cboBodegaDestino = new ComboBox();

            // CREACION DE TEXTBOX
            this.txtCantidad = new TextBox();
            this.txtObservacion = new TextBox();

            // CREACION DE BOTONES
            this.btnNuevo = new IconButton();
            this.btnTransferir = new IconButton();
            this.btnExportar = new IconButton();

            // CREACION DEL DATAGRIDVIEW
            this.dgvTransferencias = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvTransferencias))
                .BeginInit();

            this.SuspendLayout();

            // =====================================
            // FORM
            // =====================================

            // COLOR DE FONDO DEL FORMULARIO
            this.BackColor =
                Color.FromArgb(236, 240, 245);

            // TAMAÑO DEL FORMULARIO
            this.ClientSize =
                new Size(1450, 900);

            // ELIMINA EL BORDE DEL FORMULARIO
            this.FormBorderStyle =
                FormBorderStyle.None;

            // NOMBRE DEL FORMULARIO
            this.Text =
                "FrmTransferencias";

            // EVENTO LOAD DEL FORMULARIO
            this.Load +=
                new System.EventHandler(
                    this.FrmTransferencias_Load);

            // =====================================
            // TITULO
            // =====================================

            // AJUSTE AUTOMATICO DEL LABEL
            lblTitulo.AutoSize = true;

            // CONFIGURACION DE FUENTE
            lblTitulo.Font =
                new Font(
                    "Segoe UI",
                    30F,
                    FontStyle.Bold);

            // COLOR DEL TEXTO
            lblTitulo.ForeColor =
                Color.FromArgb(10, 35, 66);

            // POSICION DEL LABEL
            lblTitulo.Location =
                new Point(50, 35);

            // TEXTO DEL LABEL
            lblTitulo.Text =
                "Transferencias entre Bodegas";

            // =====================================
            // LABELS
            // =====================================

            // ARREGLO DE LABELS
            Label[] labels =
            {
                label1,
                label2,
                label3,
                label4,
                label5
            };

            // TEXTOS DE LOS LABELS
            string[] textos =
            {
                "Producto",
                "Bodega Origen",
                "Bodega Destino",
                "Cantidad",
                "Observación"
            };

            // POSICIONES Y
            int[] posY =
            {
                140,
                240,
                340,
                440,
                540
            };

            // RECORRIDO PARA CONFIGURAR LOS LABELS
            for (int i = 0; i < labels.Length; i++)
            {
                // AJUSTE AUTOMATICO
                labels[i].AutoSize = true;

                // CONFIGURACION DE FUENTE
                labels[i].Font =
                    new Font(
                        "Segoe UI Semibold",
                        13F,
                        FontStyle.Bold);

                // POSICION DEL LABEL
                labels[i].Location =
                    new Point(60, posY[i]);

                // TEXTO DEL LABEL
                labels[i].Text =
                    textos[i];
            }

            // =====================================
            // COMBOS
            // =====================================

            // ARREGLO DE COMBOBOX
            ComboBox[] combos =
            {
                cboProducto,
                cboBodegaOrigen,
                cboBodegaDestino
            };

            // POSICIONES Y DE LOS COMBOS
            int[] comboY =
            {
                175,
                275,
                375
            };

            // RECORRIDO PARA CONFIGURAR LOS COMBOBOX
            for (int i = 0; i < combos.Length; i++)
            {
                // CONFIGURACION DE FUENTE
                combos[i].Font =
                    new Font(
                        "Segoe UI",
                        12F);

                // POSICION DEL COMBOBOX
                combos[i].Location =
                    new Point(60, comboY[i]);

                // TAMAÑO DEL COMBOBOX
                combos[i].Size =
                    new Size(420, 38);

                // ESTILO DEL COMBOBOX
                combos[i].DropDownStyle =
                    ComboBoxStyle.DropDownList;
            }

            // =====================================
            // CANTIDAD
            // =====================================

            // CONFIGURACION DE FUENTE
            txtCantidad.Font =
                new Font(
                    "Segoe UI",
                    12F);

            // POSICION DEL TEXTBOX
            txtCantidad.Location =
                new Point(60, 475);

            // TAMAÑO DEL TEXTBOX
            txtCantidad.Size =
                new Size(220, 38);

            // ESTILO DEL BORDE
            txtCantidad.BorderStyle =
                BorderStyle.FixedSingle;

            // =====================================
            // OBSERVACION
            // =====================================

            // CONFIGURACION DE FUENTE
            txtObservacion.Font =
                new Font(
                    "Segoe UI",
                    11F);

            // POSICION DEL TEXTBOX
            txtObservacion.Location =
                new Point(60, 575);

            // TAMAÑO DEL TEXTBOX
            txtObservacion.Size =
                new Size(650, 90);

            // PERMITE MULTILINEA
            txtObservacion.Multiline =
                true;

            // ESTILO DEL BORDE
            txtObservacion.BorderStyle =
                BorderStyle.FixedSingle;

            // =====================================
            // BTN NUEVO
            // =====================================

            // CONFIGURA EL BOTON NUEVO
            ConfigurarBoton(
                btnNuevo,
                " Nuevo",
                IconChar.CirclePlus,
                Color.FromArgb(52, 152, 219),
                60);

            // =====================================
            // BTN TRANSFERIR
            // =====================================

            // CONFIGURA EL BOTON TRANSFERIR
            ConfigurarBoton(
                btnTransferir,
                " Transferir",
                IconChar.RightLeft,
                Color.FromArgb(46, 204, 113),
                280);

            // CONFIGURA EL BOTON EXPORTAR
            ConfigurarBoton(
    btnExportar,
    " Exportar Excel",
    IconChar.FileExcel,
    Color.FromArgb(39, 174, 96),
    500);

            // =====================================
            // GRID
            // =====================================

            // DESHABILITA AGREGAR FILAS
            dgvTransferencias.AllowUserToAddRows =
                false;

            // DESHABILITA ELIMINAR FILAS
            dgvTransferencias.AllowUserToDeleteRows =
                false;

            // AJUSTE AUTOMATICO DE COLUMNAS
            dgvTransferencias.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // COLOR DE FONDO
            dgvTransferencias.BackgroundColor =
                Color.White;

            // ESTILO DEL BORDE
            dgvTransferencias.BorderStyle =
                BorderStyle.None;

            // POSICION DEL GRID
            dgvTransferencias.Location =
                new Point(760, 150);

            // TAMAÑO DEL GRID
            dgvTransferencias.Size =
                new Size(850, 620);

            // SOLO LECTURA
            dgvTransferencias.ReadOnly = true;

            // OCULTA HEADERS DE FILAS
            dgvTransferencias.RowHeadersVisible =
                false;

            // SELECCION COMPLETA DE FILA
            dgvTransferencias.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // DESHABILITA ESTILOS VISUALES
            dgvTransferencias.EnableHeadersVisualStyles =
                false;

            // ALTURA DEL HEADER
            dgvTransferencias.ColumnHeadersHeight = 45;

            // COLOR DEL HEADER
            headerStyle.BackColor =
                Color.FromArgb(10, 35, 66);

            // COLOR DEL TEXTO DEL HEADER
            headerStyle.ForeColor =
                Color.White;

            // FUENTE DEL HEADER
            headerStyle.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            // APLICA EL ESTILO AL HEADER
            dgvTransferencias.ColumnHeadersDefaultCellStyle =
                headerStyle;

            // FUENTE DE LAS FILAS
            rowsStyle.Font =
                new Font(
                    "Segoe UI",
                    10F);

            // COLOR DE SELECCION
            rowsStyle.SelectionBackColor =
                Color.FromArgb(52, 152, 219);

            // COLOR DEL TEXTO SELECCIONADO
            rowsStyle.SelectionForeColor =
                Color.White;

            // APLICA EL ESTILO A LAS FILAS
            dgvTransferencias.RowsDefaultCellStyle =
                rowsStyle;

            // =====================================
            // EVENTOS
            // =====================================

            // EVENTO CLICK DEL BOTON NUEVO
            btnNuevo.Click +=
                new System.EventHandler(
                    this.btnNuevo_Click);

            // EVENTO CLICK DEL BOTON TRANSFERIR
            btnTransferir.Click +=
                new System.EventHandler(
                    this.btnTransferir_Click);

            // EVENTO CLICK DEL BOTON EXPORTAR
            btnExportar.Click +=
    new System.EventHandler(
        this.btnExportar_Click);

            // =====================================
            // CONTROLES
            // =====================================

            // AGREGA EL LABEL TITULO
            this.Controls.Add(lblTitulo);

            // AGREGA LOS LABELS
            this.Controls.Add(label1);
            this.Controls.Add(label2);
            this.Controls.Add(label3);
            this.Controls.Add(label4);
            this.Controls.Add(label5);

            // AGREGA LOS COMBOBOX
            this.Controls.Add(cboProducto);
            this.Controls.Add(cboBodegaOrigen);
            this.Controls.Add(cboBodegaDestino);

            // AGREGA LOS TEXTBOX
            this.Controls.Add(txtCantidad);
            this.Controls.Add(txtObservacion);

            // AGREGA LOS BOTONES
            this.Controls.Add(btnNuevo);
            this.Controls.Add(btnTransferir);
            this.Controls.Add(btnExportar);

            // AGREGA EL DATAGRIDVIEW
            this.Controls.Add(dgvTransferencias);

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvTransferencias))
                .EndInit();

            this.ResumeLayout(false);

            this.PerformLayout();
        }

        // =====================================
        // BOTONES
        // =====================================

        // METODO PARA CONFIGURAR LOS BOTONES
        private void ConfigurarBoton(
            IconButton boton,
            string texto,
            IconChar icono,
            Color color,
            int x)
        {
            // COLOR DE FONDO DEL BOTON
            boton.BackColor =
                color;

            // ESTILO FLAT
            boton.FlatStyle =
                FlatStyle.Flat;

            // ELIMINA EL BORDE
            boton.FlatAppearance.BorderSize = 0;

            // COLOR DEL TEXTO
            boton.ForeColor =
                Color.White;

            // CONFIGURACION DE FUENTE
            boton.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            // CONFIGURACION DEL ICONO
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

            // RELACION ENTRE TEXTO E IMAGEN
            boton.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            // TAMAÑO DEL BOTON
            boton.Size =
                new Size(190, 58);

            // POSICION DEL BOTON
            boton.Location =
                new Point(x, 720);

            // CAMBIA EL CURSOR A MANO
            boton.Cursor =
                Cursors.Hand;
        }

        #endregion

        // DECLARACION DEL LABEL TITULO
        private Label lblTitulo;

        // DECLARACION DE LABELS
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;

        // DECLARACION DE COMBOBOX
        private ComboBox cboProducto;
        private ComboBox cboBodegaOrigen;
        private ComboBox cboBodegaDestino;

        // DECLARACION DE TEXTBOX
        private TextBox txtCantidad;
        private TextBox txtObservacion;

        // DECLARACION DE BOTONES
        private IconButton btnNuevo;
        private IconButton btnTransferir;
        private IconButton btnExportar;

        // DECLARACION DEL DATAGRIDVIEW
        private DataGridView dgvTransferencias;
    }
}