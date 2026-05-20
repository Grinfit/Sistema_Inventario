// IMPORTACION DE LIBRERIAS NECESARIAS
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Sistema_Inventario.Presentacion
{
    // CLASE PARCIAL DEL FORMULARIO PROVEEDORES
    partial class FrmProveedores
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
            // ESTILOS DEL GRID
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
            this.label6 = new Label();

            this.txtNombre = new TextBox();
            this.txtEmpresa = new TextBox();
            this.txtTelefono = new TextBox();
            this.txtCorreo = new TextBox();
            this.txtDireccion = new TextBox();
            this.txtBuscar = new TextBox();

            this.btnNuevo = new IconButton();
            this.btnGuardar = new IconButton();
            this.btnEditar = new IconButton();
            this.btnEliminar = new IconButton();
            this.btnBuscar = new IconButton();

            this.dgvProveedores = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();

            // SUSPENDE EL DISEÑO
            this.SuspendLayout();

            // FORM

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
                "FrmProveedores";

            // TITULO DEL FORMULARIO
            this.Text =
                "FrmProveedores";

            // EVENTO LOAD
            this.Load +=
                new System.EventHandler(this.FrmProveedores_Load);

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
                "Gestión de Proveedores";

            // BUSCAR

            // AJUSTE AUTOMATICO
            this.label6.AutoSize = true;

            // FUENTE DEL LABEL
            this.label6.Font =
                new Font(
                    "Segoe UI Semibold",
                    12F,
                    FontStyle.Bold);

            // POSICION DEL LABEL
            this.label6.Location =
                new Point(60, 115);

            // TEXTO DEL LABEL
            this.label6.Text =
                "Buscar Proveedor";

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
                "Nombre",
                "Empresa",
                "Teléfono",
                "Correo",
                "Dirección"
            };

            // POSICIONES Y
            int[] posicionesY =
            {
                230,
                330,
                430,
                230,
                330
            };

            // POSICIONES X
            int[] posicionesX =
            {
                60,
                60,
                60,
                520,
                520
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
                    new Point(
                        posicionesX[i],
                        posicionesY[i]);

                labels[i].Text =
                    textos[i];
            }

            // TEXTBOX

            // ARREGLO DE TEXTBOX
            TextBox[] txts =
            {
                txtNombre,
                txtEmpresa,
                txtTelefono,
                txtCorreo,
                txtDireccion
            };

            // POSICIONES X
            int[] txtX =
            {
                60,
                60,
                60,
                520,
                520
            };

            // POSICIONES Y
            int[] txtY =
            {
                265,
                365,
                465,
                265,
                365
            };

            // ANCHOS
            int[] txtW =
            {
                360,
                360,
                360,
                360,
                360
            };

            // CONFIGURA TEXTBOX
            for (int i = 0; i < txts.Length; i++)
            {
                txts[i].Font =
                    new Font(
                        "Segoe UI",
                        12F);

                txts[i].Location =
                    new Point(
                        txtX[i],
                        txtY[i]);

                txts[i].Size =
                    new Size(
                        txtW[i],
                        38);

                txts[i].BorderStyle =
                    BorderStyle.FixedSingle;
            }

            // BOTONES

            ConfigurarBoton(
                btnNuevo,
                " Nuevo",
                IconChar.CirclePlus,
                Color.FromArgb(52, 152, 219),
                60);

            ConfigurarBoton(
                btnGuardar,
                " Guardar",
                IconChar.FloppyDisk,
                Color.FromArgb(46, 204, 113),
                260);

            ConfigurarBoton(
                btnEditar,
                " Editar",
                IconChar.PenToSquare,
                Color.FromArgb(241, 196, 15),
                460);

            ConfigurarBoton(
                btnEliminar,
                " Eliminar",
                IconChar.Trash,
                Color.FromArgb(231, 76, 60),
                660);

            // GRID

            // DESHABILITA AGREGAR FILAS
            this.dgvProveedores.AllowUserToAddRows = false;

            // DESHABILITA ELIMINAR FILAS
            this.dgvProveedores.AllowUserToDeleteRows = false;

            // AJUSTE AUTOMATICO DE COLUMNAS
            this.dgvProveedores.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // COLOR DE FONDO
            this.dgvProveedores.BackgroundColor =
                Color.White;

            // BORDE DEL GRID
            this.dgvProveedores.BorderStyle =
                BorderStyle.None;

            // POSICION DEL GRID
            this.dgvProveedores.Location =
                new Point(60, 585);

            // TAMAÑO DEL GRID
            this.dgvProveedores.Size =
                new Size(1500, 400);

            // SOLO LECTURA
            this.dgvProveedores.ReadOnly = true;

            // OCULTA HEADERS DE FILAS
            this.dgvProveedores.RowHeadersVisible = false;

            // SELECCION COMPLETA
            this.dgvProveedores.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // DESHABILITA MULTISELECT
            this.dgvProveedores.MultiSelect = false;

            // DESHABILITA ESTILOS VISUALES
            this.dgvProveedores.EnableHeadersVisualStyles = false;

            // ALTURA HEADER
            this.dgvProveedores.ColumnHeadersHeight = 45;

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
            this.dgvProveedores.ColumnHeadersDefaultCellStyle =
                headerStyle;

            // ROWS STYLE

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
            this.dgvProveedores.RowsDefaultCellStyle =
                rowsStyle;

            // EVENTO CLICK GRID
            this.dgvProveedores.CellClick +=
                new DataGridViewCellEventHandler(
                    this.dgvProveedores_CellClick);

            // EVENTOS

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

            // CONTROLES

            // AGREGA TITULO
            this.Controls.Add(this.lblTitulo);

            // AGREGA LABELS
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);

            // AGREGA TEXTBOX
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtEmpresa);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtBuscar);

            // AGREGA BOTON BUSCAR
            this.Controls.Add(this.btnBuscar);

            // AGREGA BOTONES
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);

            // AGREGA GRID
            this.Controls.Add(this.dgvProveedores);

            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();

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
            boton.BackColor = color;

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
            boton.Text = texto;

            // RELACION TEXTO E IMAGEN
            boton.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            // TAMAÑO DEL BOTON
            boton.Size =
                new Size(170, 58);

            // POSICION DEL BOTON
            boton.Location =
                new Point(x, 520);

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
        private Label label6;

        // TEXTBOX
        private TextBox txtNombre;
        private TextBox txtEmpresa;
        private TextBox txtTelefono;
        private TextBox txtCorreo;
        private TextBox txtDireccion;
        private TextBox txtBuscar;

        // BOTONES
        private IconButton btnNuevo;
        private IconButton btnGuardar;
        private IconButton btnEditar;
        private IconButton btnEliminar;
        private IconButton btnBuscar;

        // DATAGRIDVIEW
        private DataGridView dgvProveedores;
    }
}