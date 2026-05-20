// IMPORTACION DE LIBRERIAS NECESARIAS
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Sistema_Inventario.Presentacion
{
    // CLASE PARCIAL DEL FORMULARIO PRODUCTOS
    partial class FrmProductos
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
            // ESTILOS DEL DATAGRIDVIEW

            DataGridViewCellStyle headerStyle =
                new DataGridViewCellStyle();

            DataGridViewCellStyle rowsStyle =
                new DataGridViewCellStyle();

            // CONTROLES

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
            this.btnExportar = new IconButton();
            this.btnBuscar = new IconButton();

            this.dgvProductos = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();

            // SUSPENDE EL DISEÑO
            this.SuspendLayout();

            // FORMULARIO

            // TAMAÑO DEL FORMULARIO
            this.ClientSize =
                new Size(1350, 860);

            // COLOR DE FONDO
            this.BackColor =
                Color.FromArgb(236, 240, 245);

            // BORDE DEL FORMULARIO
            this.FormBorderStyle =
                FormBorderStyle.None;

            // NOMBRE DEL FORMULARIO
            this.Name =
                "FrmProductos";

            // TITULO DEL FORMULARIO
            this.Text =
                "FrmProductos";

            // EVENTO LOAD
            this.Load +=
                new System.EventHandler(this.FrmProductos_Load);

            // TITULO

            // AJUSTE AUTOMATICO
            this.lblTitulo.AutoSize = true;

            // FUENTE DEL TITULO
            this.lblTitulo.Font =
                new Font(
                    "Segoe UI",
                    30F,
                    FontStyle.Bold);

            // COLOR DEL TITULO
            this.lblTitulo.ForeColor =
                Color.FromArgb(10, 35, 66);

            // POSICION DEL TITULO
            this.lblTitulo.Location =
                new Point(50, 35);

            // TEXTO DEL TITULO
            this.lblTitulo.Text =
                "Gestión de Productos";

            // LABEL BUSCAR

            // AJUSTE AUTOMATICO
            this.label5.AutoSize = true;

            // FUENTE DEL LABEL
            this.label5.Font =
                new Font(
                    "Segoe UI Semibold",
                    12F,
                    FontStyle.Bold);

            // POSICION DEL LABEL
            this.label5.Location =
                new Point(60, 115);

            // TEXTO DEL LABEL
            this.label5.Text =
                "Buscar Producto";

            // TXT BUSCAR

            // FUENTE DEL TEXTBOX
            this.txtBuscar.Font =
                new Font(
                    "Segoe UI",
                    11F);

            // POSICION DEL TEXTBOX
            this.txtBuscar.Location =
                new Point(60, 145);

            // TAMAÑO DEL TEXTBOX
            this.txtBuscar.Size =
                new Size(420, 38);

            // BORDE DEL TEXTBOX
            this.txtBuscar.BorderStyle =
                BorderStyle.FixedSingle;

            // BTN BUSCAR

            // COLOR DEL BOTON
            this.btnBuscar.BackColor =
                Color.FromArgb(10, 35, 66);

            // ESTILO DEL BOTON
            this.btnBuscar.FlatStyle =
                FlatStyle.Flat;

            // BORDE DEL BOTON
            this.btnBuscar.FlatAppearance.BorderSize = 0;

            // COLOR DEL TEXTO
            this.btnBuscar.ForeColor =
                Color.White;

            // FUENTE DEL BOTON
            this.btnBuscar.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            // ICONO DEL BOTON
            this.btnBuscar.IconChar =
                IconChar.Search;

            // COLOR DEL ICONO
            this.btnBuscar.IconColor =
                Color.White;

            // FUENTE DEL ICONO
            this.btnBuscar.IconFont =
                IconFont.Auto;

            // TAMAÑO DEL ICONO
            this.btnBuscar.IconSize = 24;

            // TEXTO DEL BOTON
            this.btnBuscar.Text =
                " Buscar";

            // RELACION TEXTO E IMAGEN
            this.btnBuscar.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            // POSICION DEL BOTON
            this.btnBuscar.Location =
                new Point(500, 142);

            // TAMAÑO DEL BOTON
            this.btnBuscar.Size =
                new Size(160, 42);

            // CURSOR DEL BOTON
            this.btnBuscar.Cursor =
                Cursors.Hand;

            // EVENTO CLICK BOTON BUSCAR
            this.btnBuscar.Click +=
                new System.EventHandler(this.btnBuscar_Click);

            // LABEL NOMBRE

            // AJUSTE AUTOMATICO
            this.label1.AutoSize = true;

            // FUENTE DEL LABEL
            this.label1.Font =
                new Font(
                    "Segoe UI Semibold",
                    13F,
                    FontStyle.Bold);

            // POSICION DEL LABEL
            this.label1.Location =
                new Point(60, 220);

            // TEXTO DEL LABEL
            this.label1.Text =
                "Nombre";

            // TXT NOMBRE

            // FUENTE DEL TEXTBOX
            this.txtNombre.Font =
                new Font(
                    "Segoe UI",
                    12F);

            // POSICION DEL TEXTBOX
            this.txtNombre.Location =
                new Point(60, 255);

            // TAMAÑO DEL TEXTBOX
            this.txtNombre.Size =
                new Size(360, 38);

            // BORDE DEL TEXTBOX
            this.txtNombre.BorderStyle =
                BorderStyle.FixedSingle;

            // LABEL CATEGORIA

            // AJUSTE AUTOMATICO
            this.label2.AutoSize = true;

            // FUENTE DEL LABEL
            this.label2.Font =
                new Font(
                    "Segoe UI Semibold",
                    13F,
                    FontStyle.Bold);

            // POSICION DEL LABEL
            this.label2.Location =
                new Point(60, 320);

            // TEXTO DEL LABEL
            this.label2.Text =
                "Categoría";

            // TXT CATEGORIA

            // FUENTE DEL TEXTBOX
            this.txtCategoria.Font =
                new Font(
                    "Segoe UI",
                    12F);

            // POSICION DEL TEXTBOX
            this.txtCategoria.Location =
                new Point(60, 355);

            // TAMAÑO DEL TEXTBOX
            this.txtCategoria.Size =
                new Size(360, 38);

            // BORDE DEL TEXTBOX
            this.txtCategoria.BorderStyle =
                BorderStyle.FixedSingle;

            // LABEL PRECIO

            // AJUSTE AUTOMATICO
            this.label3.AutoSize = true;

            // FUENTE DEL LABEL
            this.label3.Font =
                new Font(
                    "Segoe UI Semibold",
                    13F,
                    FontStyle.Bold);

            // POSICION DEL LABEL
            this.label3.Location =
                new Point(520, 220);

            // TEXTO DEL LABEL
            this.label3.Text =
                "Precio";

            // TXT PRECIO

            // FUENTE DEL TEXTBOX
            this.txtPrecio.Font =
                new Font(
                    "Segoe UI",
                    12F);

            // POSICION DEL TEXTBOX
            this.txtPrecio.Location =
                new Point(520, 255);

            // TAMAÑO DEL TEXTBOX
            this.txtPrecio.Size =
                new Size(180, 38);

            // BORDE DEL TEXTBOX
            this.txtPrecio.BorderStyle =
                BorderStyle.FixedSingle;

            // LABEL STOCK

            // AJUSTE AUTOMATICO
            this.label4.AutoSize = true;

            // FUENTE DEL LABEL
            this.label4.Font =
                new Font(
                    "Segoe UI Semibold",
                    13F,
                    FontStyle.Bold);

            // POSICION DEL LABEL
            this.label4.Location =
                new Point(520, 320);

            // TEXTO DEL LABEL
            this.label4.Text =
                "Stock";

            // TXT STOCK

            // FUENTE DEL TEXTBOX
            this.txtStock.Font =
                new Font(
                    "Segoe UI",
                    12F);

            // POSICION DEL TEXTBOX
            this.txtStock.Location =
                new Point(520, 355);

            // TAMAÑO DEL TEXTBOX
            this.txtStock.Size =
                new Size(180, 38);

            // BORDE DEL TEXTBOX
            this.txtStock.BorderStyle =
                BorderStyle.FixedSingle;

            // BTN NUEVO

            // COLOR DEL BOTON
            this.btnNuevo.BackColor =
                Color.FromArgb(52, 152, 219);

            // ESTILO DEL BOTON
            this.btnNuevo.FlatStyle =
                FlatStyle.Flat;

            // BORDE DEL BOTON
            this.btnNuevo.FlatAppearance.BorderSize = 0;

            // COLOR DEL TEXTO
            this.btnNuevo.ForeColor =
                Color.White;

            // FUENTE DEL BOTON
            this.btnNuevo.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            // ICONO DEL BOTON
            this.btnNuevo.IconChar =
                IconChar.CirclePlus;

            // COLOR DEL ICONO
            this.btnNuevo.IconColor =
                Color.White;

            // FUENTE DEL ICONO
            this.btnNuevo.IconFont =
                IconFont.Auto;

            // TAMAÑO DEL ICONO
            this.btnNuevo.IconSize = 28;

            // TEXTO DEL BOTON
            this.btnNuevo.Text =
                " Nuevo";

            // RELACION TEXTO E IMAGEN
            this.btnNuevo.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            // TAMAÑO DEL BOTON
            this.btnNuevo.Size =
                new Size(170, 58);

            // POSICION DEL BOTON
            this.btnNuevo.Location =
                new Point(60, 450);

            // CURSOR DEL BOTON
            this.btnNuevo.Cursor =
                Cursors.Hand;

            // BTN GUARDAR

            // COLOR DEL BOTON
            this.btnGuardar.BackColor =
                Color.FromArgb(46, 204, 113);

            // ESTILO DEL BOTON
            this.btnGuardar.FlatStyle =
                FlatStyle.Flat;

            // BORDE DEL BOTON
            this.btnGuardar.FlatAppearance.BorderSize = 0;

            // COLOR DEL TEXTO
            this.btnGuardar.ForeColor =
                Color.White;

            // FUENTE DEL BOTON
            this.btnGuardar.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            // ICONO DEL BOTON
            this.btnGuardar.IconChar =
                IconChar.FloppyDisk;

            // COLOR DEL ICONO
            this.btnGuardar.IconColor =
                Color.White;

            // FUENTE DEL ICONO
            this.btnGuardar.IconFont =
                IconFont.Auto;

            // TAMAÑO DEL ICONO
            this.btnGuardar.IconSize = 28;

            // TEXTO DEL BOTON
            this.btnGuardar.Text =
                " Guardar";

            // RELACION TEXTO E IMAGEN
            this.btnGuardar.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            // TAMAÑO DEL BOTON
            this.btnGuardar.Size =
                new Size(170, 58);

            // POSICION DEL BOTON
            this.btnGuardar.Location =
                new Point(260, 450);

            // CURSOR DEL BOTON
            this.btnGuardar.Cursor =
                Cursors.Hand;

            // BTN EDITAR

            // COLOR DEL BOTON
            this.btnEditar.BackColor =
                Color.FromArgb(241, 196, 15);

            // ESTILO DEL BOTON
            this.btnEditar.FlatStyle =
                FlatStyle.Flat;

            // BORDE DEL BOTON
            this.btnEditar.FlatAppearance.BorderSize = 0;

            // COLOR DEL TEXTO
            this.btnEditar.ForeColor =
                Color.White;

            // FUENTE DEL BOTON
            this.btnEditar.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            // ICONO DEL BOTON
            this.btnEditar.IconChar =
                IconChar.PenToSquare;

            // COLOR DEL ICONO
            this.btnEditar.IconColor =
                Color.White;

            // FUENTE DEL ICONO
            this.btnEditar.IconFont =
                IconFont.Auto;

            // TAMAÑO DEL ICONO
            this.btnEditar.IconSize = 28;

            // TEXTO DEL BOTON
            this.btnEditar.Text =
                " Editar";

            // RELACION TEXTO E IMAGEN
            this.btnEditar.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            // TAMAÑO DEL BOTON
            this.btnEditar.Size =
                new Size(170, 58);

            // POSICION DEL BOTON
            this.btnEditar.Location =
                new Point(460, 450);

            // CURSOR DEL BOTON
            this.btnEditar.Cursor =
                Cursors.Hand;

            // BTN ELIMINAR

            // COLOR DEL BOTON
            this.btnEliminar.BackColor =
                Color.FromArgb(231, 76, 60);

            // ESTILO DEL BOTON
            this.btnEliminar.FlatStyle =
                FlatStyle.Flat;

            // BORDE DEL BOTON
            this.btnEliminar.FlatAppearance.BorderSize = 0;

            // COLOR DEL TEXTO
            this.btnEliminar.ForeColor =
                Color.White;

            // FUENTE DEL BOTON
            this.btnEliminar.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            // ICONO DEL BOTON
            this.btnEliminar.IconChar =
                IconChar.Trash;

            // COLOR DEL ICONO
            this.btnEliminar.IconColor =
                Color.White;

            // FUENTE DEL ICONO
            this.btnEliminar.IconFont =
                IconFont.Auto;

            // TAMAÑO DEL ICONO
            this.btnEliminar.IconSize = 28;

            // TEXTO DEL BOTON
            this.btnEliminar.Text =
                " Eliminar";

            // RELACION TEXTO E IMAGEN
            this.btnEliminar.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            // TAMAÑO DEL BOTON
            this.btnEliminar.Size =
                new Size(170, 58);

            // POSICION DEL BOTON
            this.btnEliminar.Location =
                new Point(660, 450);

            // CURSOR DEL BOTON
            this.btnEliminar.Cursor =
                Cursors.Hand;

            // BTN EXPORTAR

            // COLOR DEL BOTON
            this.btnExportar.BackColor =
                Color.FromArgb(39, 174, 96);

            // ESTILO DEL BOTON
            this.btnExportar.FlatStyle =
                FlatStyle.Flat;

            // BORDE DEL BOTON
            this.btnExportar.FlatAppearance.BorderSize = 0;

            // COLOR DEL TEXTO
            this.btnExportar.ForeColor =
                Color.White;

            // FUENTE DEL BOTON
            this.btnExportar.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            // ICONO DEL BOTON
            this.btnExportar.IconChar =
                IconChar.FileExcel;

            // COLOR DEL ICONO
            this.btnExportar.IconColor =
                Color.White;

            // FUENTE DEL ICONO
            this.btnExportar.IconFont =
                IconFont.Auto;

            // TAMAÑO DEL ICONO
            this.btnExportar.IconSize = 28;

            // TEXTO DEL BOTON
            this.btnExportar.Text =
                " Exportar Excel";

            // RELACION TEXTO E IMAGEN
            this.btnExportar.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            // TAMAÑO DEL BOTON
            this.btnExportar.Size =
                new Size(190, 58);

            // POSICION DEL BOTON
            this.btnExportar.Location =
                new Point(860, 450);

            // CURSOR DEL BOTON
            this.btnExportar.Cursor =
                Cursors.Hand;

            // DATAGRIDVIEW

            // DESHABILITA AGREGAR FILAS
            this.dgvProductos.AllowUserToAddRows = false;

            // DESHABILITA ELIMINAR FILAS
            this.dgvProductos.AllowUserToDeleteRows = false;

            // AJUSTE AUTOMATICO COLUMNAS
            this.dgvProductos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // COLOR DE FONDO
            this.dgvProductos.BackgroundColor =
                Color.White;

            // BORDE DEL GRID
            this.dgvProductos.BorderStyle =
                BorderStyle.None;

            // BORDE DE CELDAS
            this.dgvProductos.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            // POSICION DEL GRID
            this.dgvProductos.Location =
                new Point(60, 585);

            // TAMAÑO DEL GRID
            this.dgvProductos.Size =
                new Size(1500, 400);

            // SOLO LECTURA
            this.dgvProductos.ReadOnly = true;

            // OCULTA HEADERS DE FILAS
            this.dgvProductos.RowHeadersVisible = false;

            // SELECCION COMPLETA
            this.dgvProductos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // DESHABILITA MULTISELECT
            this.dgvProductos.MultiSelect = false;

            // DESHABILITA ESTILOS VISUALES
            this.dgvProductos.EnableHeadersVisualStyles = false;

            // ALTURA HEADER
            this.dgvProductos.ColumnHeadersHeight = 45;

            // DESHABILITA REDIMENSION HEADER
            this.dgvProductos.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // ALTURA FILAS
            this.dgvProductos.RowTemplate.Height = 42;

            // HEADER STYLE

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
            this.dgvProductos.ColumnHeadersDefaultCellStyle =
                headerStyle;

            // ROW STYLE

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
            this.dgvProductos.RowsDefaultCellStyle =
                rowsStyle;

            // COLOR FILAS ALTERNAS
            this.dgvProductos.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 247, 250);

            // PADDING CELDAS
            this.dgvProductos.DefaultCellStyle.Padding =
                new Padding(5);

            // COLOR GRID
            this.dgvProductos.GridColor =
                Color.FromArgb(225, 225, 225);

            // EVENTO CLICK GRID
            this.dgvProductos.CellClick +=
                new DataGridViewCellEventHandler(
                    this.dgvProductos_CellClick);

            // EVENTOS BOTONES

            // EVENTO BOTON NUEVO
            this.btnNuevo.Click +=
                new System.EventHandler(this.btnNuevo_Click);

            // EVENTO BOTON GUARDAR
            this.btnGuardar.Click +=
                new System.EventHandler(this.btnGuardar_Click);

            // EVENTO BOTON EDITAR
            this.btnEditar.Click +=
                new System.EventHandler(this.btnEditar_Click);

            // EVENTO BOTON ELIMINAR
            this.btnEliminar.Click +=
                new System.EventHandler(this.btnEliminar_Click);

            // EVENTO BOTON EXPORTAR
            this.btnExportar.Click +=
                new System.EventHandler(this.btnExportar_Click);

            // CONTROLES

            // AGREGA TITULO
            this.Controls.Add(this.lblTitulo);

            // AGREGA LABELS
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);

            // AGREGA TEXTBOX
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtBuscar);

            // AGREGA BOTON BUSCAR
            this.Controls.Add(this.btnBuscar);

            // AGREGA BOTONES
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnExportar);

            // AGREGA GRID
            this.Controls.Add(this.dgvProductos);

            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();

            // REANUDA EL DISEÑO
            this.ResumeLayout(false);

            this.PerformLayout();
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

        // TEXTBOX
        private TextBox txtNombre;
        private TextBox txtCategoria;
        private TextBox txtPrecio;
        private TextBox txtStock;
        private TextBox txtBuscar;

        // BOTONES
        private IconButton btnNuevo;
        private IconButton btnGuardar;
        private IconButton btnEditar;
        private IconButton btnEliminar;
        private IconButton btnExportar;
        private IconButton btnBuscar;

        // DATAGRIDVIEW
        private DataGridView dgvProductos;
    }
}