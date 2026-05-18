using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Sistema_Inventario.Presentacion
{
    partial class FrmProductos
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
            // =====================================================
            // ESTILOS DEL DATAGRIDVIEW
            // =====================================================

            DataGridViewCellStyle headerStyle =
                new DataGridViewCellStyle();

            DataGridViewCellStyle rowsStyle =
                new DataGridViewCellStyle();

            // =====================================================
            // CONTROLES
            // =====================================================

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
            this.btnBuscar = new IconButton();

            this.dgvProductos = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();

            this.SuspendLayout();

            // =====================================================
            // CONFIGURACION GENERAL DEL FORMULARIO
            // =====================================================

            // Tamaño general de la ventana
            this.ClientSize = new Size(1350, 860);

            // Color de fondo principal
            this.BackColor = Color.FromArgb(236, 240, 245);

            // Elimina bordes del formulario
            this.FormBorderStyle = FormBorderStyle.None;

            // Nombre del formulario
            this.Name = "FrmProductos";

            this.Text = "FrmProductos";

            // Evento Load
            this.Load += new System.EventHandler(this.FrmProductos_Load);

            // =====================================================
            // TITULO PRINCIPAL
            // =====================================================

            this.lblTitulo.AutoSize = true;

            // Fuente grande y moderna
            this.lblTitulo.Font =
                new Font(
                    "Segoe UI",
                    30F,
                    FontStyle.Bold);

            // Color azul oscuro elegante
            this.lblTitulo.ForeColor =
                Color.FromArgb(10, 35, 66);

            // Posición del título
            this.lblTitulo.Location =
                new Point(50, 35);

            // Texto
            this.lblTitulo.Text =
                "Gestión de Productos";

            // =====================================================
            // LABEL BUSCAR
            // =====================================================

            this.label5.AutoSize = true;

            this.label5.Font =
                new Font(
                    "Segoe UI Semibold",
                    12F,
                    FontStyle.Bold);

            this.label5.ForeColor =
                Color.FromArgb(45, 45, 45);

            // Posición
            this.label5.Location =
                new Point(60, 115);

            this.label5.Text =
                "Buscar Producto";

            // =====================================================
            // TEXTBOX BUSCAR
            // =====================================================

            this.txtBuscar.Font =
                new Font(
                    "Segoe UI",
                    11F);

            // Posición
            this.txtBuscar.Location =
                new Point(60, 145);

            // Tamaño
            this.txtBuscar.Size =
                new Size(420, 38);

            // Borde moderno
            this.txtBuscar.BorderStyle =
                BorderStyle.FixedSingle;

            // =====================================================
            // BOTON BUSCAR
            // =====================================================

            this.btnBuscar.BackColor =
                Color.FromArgb(10, 35, 66);

            this.btnBuscar.FlatStyle =
                FlatStyle.Flat;

            this.btnBuscar.FlatAppearance.BorderSize = 0;

            // Color hover
            this.btnBuscar.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(22, 52, 88);

            this.btnBuscar.ForeColor =
                Color.White;

            this.btnBuscar.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            // Icono de lupa
            this.btnBuscar.IconChar =
                IconChar.Search;

            this.btnBuscar.IconColor =
                Color.White;

            this.btnBuscar.IconFont =
                IconFont.Auto;

            this.btnBuscar.IconSize = 24;

            // Texto del botón
            this.btnBuscar.Text =
                " Buscar";

            // Coloca el icono antes del texto
            this.btnBuscar.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            // Posición
            this.btnBuscar.Location =
                new Point(500, 142);

            // Tamaño
            this.btnBuscar.Size =
                new Size(160, 42);

            this.btnBuscar.Cursor =
                Cursors.Hand;

            this.btnBuscar.UseVisualStyleBackColor = false;

            this.btnBuscar.Click +=
                new System.EventHandler(this.btnBuscar_Click);

            // =====================================================
            // LABEL NOMBRE
            // =====================================================

            this.label1.AutoSize = true;

            this.label1.Font =
                new Font(
                    "Segoe UI Semibold",
                    12F,
                    FontStyle.Bold);

            this.label1.Location =
                new Point(60, 220);

            this.label1.Text =
                "Nombre";

            // =====================================================
            // TEXTBOX NOMBRE
            // =====================================================

            this.txtNombre.Font =
                new Font(
                    "Segoe UI",
                    11F);

            this.txtNombre.Location =
                new Point(60, 250);

            this.txtNombre.Size =
                new Size(450, 38);

            this.txtNombre.BorderStyle =
                BorderStyle.FixedSingle;

            // =====================================================
            // LABEL CATEGORIA
            // =====================================================

            this.label2.AutoSize = true;

            this.label2.Font =
                new Font(
                    "Segoe UI Semibold",
                    12F,
                    FontStyle.Bold);

            this.label2.Location =
                new Point(60, 315);

            this.label2.Text =
                "Categoría";

            // =====================================================
            // TEXTBOX CATEGORIA
            // =====================================================

            this.txtCategoria.Font =
                new Font(
                    "Segoe UI",
                    11F);

            this.txtCategoria.Location =
                new Point(60, 345);

            this.txtCategoria.Size =
                new Size(450, 38);

            this.txtCategoria.BorderStyle =
                BorderStyle.FixedSingle;

            // =====================================================
            // LABEL PRECIO
            // =====================================================

            this.label3.AutoSize = true;

            this.label3.Font =
                new Font(
                    "Segoe UI Semibold",
                    12F,
                    FontStyle.Bold);

            this.label3.Location =
                new Point(600, 220);

            this.label3.Text =
                "Precio";

            // =====================================================
            // TEXTBOX PRECIO
            // =====================================================

            this.txtPrecio.Font =
                new Font(
                    "Segoe UI",
                    11F);

            this.txtPrecio.Location =
                new Point(600, 250);

            this.txtPrecio.Size =
                new Size(300, 38);

            this.txtPrecio.BorderStyle =
                BorderStyle.FixedSingle;

            // =====================================================
            // LABEL STOCK
            // =====================================================

            this.label4.AutoSize = true;

            this.label4.Font =
                new Font(
                    "Segoe UI Semibold",
                    12F,
                    FontStyle.Bold);

            this.label4.Location =
                new Point(600, 315);

            this.label4.Text =
                "Stock";

            // =====================================================
            // TEXTBOX STOCK
            // =====================================================

            this.txtStock.Font =
                new Font(
                    "Segoe UI",
                    11F);

            this.txtStock.Location =
                new Point(600, 345);

            this.txtStock.Size =
                new Size(300, 38);

            this.txtStock.BorderStyle =
                BorderStyle.FixedSingle;

            // =====================================================
            // BOTONES CRUD
            // =====================================================

            // Botón Nuevo
            ConfigurarBoton(
                this.btnNuevo,
                "Nuevo",
                IconChar.CirclePlus,
                Color.FromArgb(52, 152, 219),
                new Point(60, 450));

            // Botón Guardar
            ConfigurarBoton(
                this.btnGuardar,
                "Guardar",
                IconChar.FloppyDisk,
                Color.FromArgb(46, 204, 113),
                new Point(260, 450));

            // Botón Editar
            ConfigurarBoton(
                this.btnEditar,
                "Editar",
                IconChar.PenToSquare,
                Color.FromArgb(241, 196, 15),
                new Point(460, 450));

            // Botón Eliminar
            ConfigurarBoton(
                this.btnEliminar,
                "Eliminar",
                IconChar.Trash,
                Color.FromArgb(231, 76, 60),
                new Point(660, 450));

            // =====================================================
            // DATAGRIDVIEW
            // =====================================================

            this.dgvProductos.AllowUserToAddRows = false;

            this.dgvProductos.AllowUserToDeleteRows = false;

            // Ajusta columnas automáticamente
            this.dgvProductos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Fondo blanco
            this.dgvProductos.BackgroundColor =
                Color.White;

            this.dgvProductos.BorderStyle =
                BorderStyle.None;

            // Bordes horizontales suaves
            this.dgvProductos.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            // Posición de la tabla
            this.dgvProductos.Location =
                new Point(60, 585);

            // Tamaño de la tabla
            this.dgvProductos.Size =
                new Size(1500, 400);

            // Solo lectura
            this.dgvProductos.ReadOnly = true;

            // Oculta encabezados laterales
            this.dgvProductos.RowHeadersVisible = false;

            // Selección completa de filas
            this.dgvProductos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            this.dgvProductos.MultiSelect = false;

            // Permite estilos personalizados
            this.dgvProductos.EnableHeadersVisualStyles = false;

            // Altura del header
            this.dgvProductos.ColumnHeadersHeight = 45;

            this.dgvProductos.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Altura de filas
            this.dgvProductos.RowTemplate.Height = 42;

            // =====================================================
            // HEADER STYLE
            // =====================================================

            headerStyle.BackColor =
                Color.FromArgb(10, 35, 66);

            headerStyle.ForeColor =
                Color.White;

            headerStyle.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            this.dgvProductos.ColumnHeadersDefaultCellStyle =
                headerStyle;

            // =====================================================
            // ROWS STYLE
            // =====================================================

            rowsStyle.Font =
                new Font(
                    "Segoe UI",
                    10F);

            // Color selección
            rowsStyle.SelectionBackColor =
                Color.FromArgb(52, 152, 219);

            rowsStyle.SelectionForeColor =
                Color.White;

            this.dgvProductos.RowsDefaultCellStyle =
                rowsStyle;

            // Filas alternas
            this.dgvProductos.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 247, 250);

            // Espaciado interno
            this.dgvProductos.DefaultCellStyle.Padding =
                new Padding(5);

            // Color líneas
            this.dgvProductos.GridColor =
                Color.FromArgb(225, 225, 225);

            this.dgvProductos.CellClick +=
                new DataGridViewCellEventHandler(
                    this.dgvProductos_CellClick);

            // =====================================================
            // EVENTOS BOTONES
            // =====================================================

            this.btnNuevo.Click +=
                new System.EventHandler(this.btnNuevo_Click);

            this.btnGuardar.Click +=
                new System.EventHandler(this.btnGuardar_Click);

            this.btnEditar.Click +=
                new System.EventHandler(this.btnEditar_Click);

            this.btnEliminar.Click +=
                new System.EventHandler(this.btnEliminar_Click);

            // =====================================================
            // AGREGAR CONTROLES AL FORM
            // =====================================================

            this.Controls.Add(this.lblTitulo);

            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);

            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtBuscar);

            this.Controls.Add(this.btnBuscar);

            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);

            this.Controls.Add(this.dgvProductos);

            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();

            this.ResumeLayout(false);

            this.PerformLayout();
        }

        // =====================================================
        // METODO PARA CONFIGURAR BOTONES
        // =====================================================

        private void ConfigurarBoton(
            IconButton boton,
            string texto,
            IconChar icono,
            Color color,
            Point ubicacion)
        {
            // Color fondo
            boton.BackColor = color;

            // Estilo plano
            boton.FlatStyle = FlatStyle.Flat;

            boton.FlatAppearance.BorderSize = 0;

            // Hover
            boton.FlatAppearance.MouseOverBackColor =
                ControlPaint.Light(color);

            // Click
            boton.FlatAppearance.MouseDownBackColor =
                ControlPaint.Dark(color);

            // Texto blanco
            boton.ForeColor = Color.White;

            // Fuente moderna
            boton.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            // Icono
            boton.IconChar = icono;

            boton.IconColor = Color.White;

            boton.IconFont = IconFont.Auto;

            boton.IconSize = 28;

            // Texto
            boton.Text = " " + texto;

            // Icono antes del texto
            boton.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            // Tamaño botón
            boton.Size =
                new Size(170, 58);

            // Posición
            boton.Location = ubicacion;

            // Cursor mano
            boton.Cursor = Cursors.Hand;
        }

        #endregion

        // =====================================================
        // VARIABLES CONTROLES
        // =====================================================

        private Label lblTitulo;

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;

        private TextBox txtNombre;
        private TextBox txtCategoria;
        private TextBox txtPrecio;
        private TextBox txtStock;
        private TextBox txtBuscar;

        private IconButton btnNuevo;
        private IconButton btnGuardar;
        private IconButton btnEditar;
        private IconButton btnEliminar;
        private IconButton btnBuscar;

        private DataGridView dgvProductos;
    }
}