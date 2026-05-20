// IMPORTACION DE LIBRERIAS NECESARIAS
using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Inventario.Presentacion
{
    // CLASE PARCIAL DEL FORMULARIO KARDEX
    partial class FrmKardex
    {
        // CONTENEDOR DE COMPONENTES
        private System.ComponentModel.IContainer components = null;

        // METODO PARA LIBERAR RECURSOS
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

            // LABEL PRODUCTO
            this.label1 =
                new Label();

            // COMBOBOX PRODUCTOS
            this.cboProducto =
                new ComboBox();

            // BOTON BUSCAR
            this.btnBuscar =
                new IconButton();

            // BOTON RECARGAR
            this.btnRecargar =
                new IconButton();

            // BOTON EXPORTAR
            this.btnExportar =
                new IconButton();

            // GRID KARDEX
            this.dgvKardex =
                new DataGridView();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvKardex))
                .BeginInit();

            // SUSPENDE EL DISEÑO
            this.SuspendLayout();

            // FORM

            // COLOR DE FONDO
            this.BackColor =
                Color.FromArgb(236, 240, 245);

            // TAMAÑO DEL FORMULARIO
            this.ClientSize =
                new Size(1450, 900);

            // BORDE DEL FORMULARIO
            this.FormBorderStyle =
                FormBorderStyle.None;

            // TITULO DEL FORMULARIO
            this.Text =
                "FrmKardex";

            // EVENTO LOAD
            this.Load +=
                new System.EventHandler(
                    this.FrmKardex_Load);

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
                new Point(50, 35);

            // TEXTO DEL TITULO
            lblTitulo.Text =
                "Kardex de Inventario";

            // LABEL PRODUCTO

            // AJUSTE AUTOMATICO
            label1.AutoSize = true;

            // FUENTE DEL LABEL
            label1.Font =
                new Font(
                    "Segoe UI Semibold",
                    13F,
                    FontStyle.Bold);

            // POSICION DEL LABEL
            label1.Location =
                new Point(60, 145);

            // TEXTO DEL LABEL
            label1.Text =
                "Producto";

            // COMBO PRODUCTO

            // FUENTE DEL COMBOBOX
            cboProducto.Font =
                new Font(
                    "Segoe UI",
                    12F);

            // POSICION DEL COMBOBOX
            cboProducto.Location =
                new Point(60, 185);

            // TAMAÑO DEL COMBOBOX
            cboProducto.Size =
                new Size(420, 38);

            // ESTILO DEL COMBOBOX
            cboProducto.DropDownStyle =
                ComboBoxStyle.DropDownList;

            // BTN BUSCAR

            ConfigurarBoton(
                btnBuscar,
                " Filtrar",
                IconChar.Search,
                Color.FromArgb(52, 152, 219),
                520);

            // BTN RECARGAR

            ConfigurarBoton(
                btnRecargar,
                " Mostrar Todo",
                IconChar.Rotate,
                Color.FromArgb(46, 204, 113),
                730);

            // BTN EXPORTAR

            ConfigurarBoton(
                btnExportar,
                " Exportar Excel",
                IconChar.FileExcel,
                Color.FromArgb(39, 174, 96),
                950);

            // GRID

            // DESHABILITA AGREGAR FILAS
            dgvKardex.AllowUserToAddRows =
                false;

            // DESHABILITA ELIMINAR FILAS
            dgvKardex.AllowUserToDeleteRows =
                false;

            // AJUSTE AUTOMATICO DE COLUMNAS
            dgvKardex.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // COLOR DE FONDO DEL GRID
            dgvKardex.BackgroundColor =
                Color.White;

            // BORDE DEL GRID
            dgvKardex.BorderStyle =
                BorderStyle.None;

            // POSICION DEL GRID
            dgvKardex.Location =
                new Point(60, 290);

            // TAMAÑO DEL GRID
            dgvKardex.Size =
                new Size(1320, 520);

            // SOLO LECTURA
            dgvKardex.ReadOnly = true;

            // OCULTA HEADERS DE FILAS
            dgvKardex.RowHeadersVisible =
                false;

            // SELECCION COMPLETA
            dgvKardex.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // DESHABILITA ESTILOS VISUALES
            dgvKardex.EnableHeadersVisualStyles =
                false;

            // ALTURA HEADER
            dgvKardex.ColumnHeadersHeight = 45;

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
            dgvKardex.ColumnHeadersDefaultCellStyle =
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
            dgvKardex.RowsDefaultCellStyle =
                rowsStyle;

            // EVENTOS

            // EVENTO BOTON BUSCAR
            btnBuscar.Click +=
                new System.EventHandler(
                    this.btnBuscar_Click);

            // EVENTO BOTON RECARGAR
            btnRecargar.Click +=
                new System.EventHandler(
                    this.btnRecargar_Click);

            // EVENTO BOTON EXPORTAR
            btnExportar.Click +=
                new System.EventHandler(
                    this.btnExportar_Click);

            // CONTROLES

            // AGREGA TITULO
            this.Controls.Add(lblTitulo);

            // AGREGA LABEL PRODUCTO
            this.Controls.Add(label1);

            // AGREGA COMBOBOX
            this.Controls.Add(cboProducto);

            // AGREGA BOTON BUSCAR
            this.Controls.Add(btnBuscar);

            // AGREGA BOTON RECARGAR
            this.Controls.Add(btnRecargar);

            // AGREGA BOTON EXPORTAR
            this.Controls.Add(btnExportar);

            // AGREGA GRID
            this.Controls.Add(dgvKardex);

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvKardex))
                .EndInit();

            // REANUDA EL DISEÑO
            this.ResumeLayout(false);

            this.PerformLayout();
        }

        // CONFIG BOTONES

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
                new Point(x, 175);

            // CURSOR DEL BOTON
            boton.Cursor =
                Cursors.Hand;
        }

        #endregion

        // LABEL TITULO
        private Label lblTitulo;

        // LABEL PRODUCTO
        private Label label1;

        // COMBOBOX PRODUCTO
        private ComboBox cboProducto;

        // BOTON BUSCAR
        private IconButton btnBuscar;

        // BOTON RECARGAR
        private IconButton btnRecargar;

        // BOTON EXPORTAR
        private IconButton btnExportar;

        // GRID KARDEX
        private DataGridView dgvKardex;
    }
}