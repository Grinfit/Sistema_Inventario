// IMPORTACION DE LIBRERIAS NECESARIAS
using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Inventario.Presentacion
{
    // CLASE PARCIAL DEL FORMULARIO STOCK POR BODEGA
    partial class FrmStockBodega
    {
        // CONTENEDOR DE COMPONENTES DEL FORMULARIO
        private System.ComponentModel.IContainer components = null;

        // METODO PARA LIBERAR LOS RECURSOS UTILIZADOS
        protected override void Dispose(
            bool disposing)
        {
            // VERIFICA SI SE DEBEN LIBERAR LOS COMPONENTES
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
            // ESTILO PARA LOS HEADERS DEL DATAGRIDVIEW
            DataGridViewCellStyle headerStyle =
                new DataGridViewCellStyle();

            // ESTILO PARA LAS FILAS DEL DATAGRIDVIEW
            DataGridViewCellStyle rowsStyle =
                new DataGridViewCellStyle();

            // CREACION DEL LABEL TITULO
            this.lblTitulo =
                new Label();

            // CREACION DEL BOTON RECARGAR
            this.btnRecargar =
                new IconButton();

            // CREACION DEL BOTON STOCK BAJO
            this.btnStockBajo =
                new IconButton();

            // CREACION DEL BOTON EXPORTAR
            this.btnExportar =
                new IconButton();

            // CREACION DEL DATAGRIDVIEW
            this.dgvStock =
                new DataGridView();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvStock))
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

            // TITULO DEL FORMULARIO
            this.Text =
                "FrmStockBodega";

            // EVENTO LOAD DEL FORMULARIO
            this.Load +=
                new System.EventHandler(
                    this.FrmStockBodega_Load);

            // =====================================
            // TITULO
            // =====================================

            // AJUSTA EL TAMAÑO AUTOMATICAMENTE
            lblTitulo.AutoSize = true;

            // CONFIGURACION DE LA FUENTE
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
                "Stock por Bodega";

            // =====================================
            // BTN RECARGAR
            // =====================================

            // CONFIGURA EL BOTON RECARGAR
            ConfigurarBoton(
                btnRecargar,
                " Recargar",
                IconChar.Rotate,
                Color.FromArgb(52, 152, 219),
                60);

            // =====================================
            // BTN STOCK BAJO
            // =====================================

            // CONFIGURA EL BOTON STOCK BAJO
            ConfigurarBoton(
                btnStockBajo,
                " Stock Bajo",
                IconChar.TriangleExclamation,
                Color.FromArgb(231, 76, 60),
                290);

            // CONFIGURA EL BOTON EXPORTAR
            ConfigurarBoton(
    btnExportar,
    " Exportar Excel",
    IconChar.FileExcel,
    Color.FromArgb(39, 174, 96),
    520);

            // =====================================
            // GRID
            // =====================================

            // DESHABILITA AGREGAR FILAS
            dgvStock.AllowUserToAddRows =
                false;

            // DESHABILITA ELIMINAR FILAS
            dgvStock.AllowUserToDeleteRows =
                false;

            // AJUSTA LAS COLUMNAS AUTOMATICAMENTE
            dgvStock.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // COLOR DE FONDO DEL GRID
            dgvStock.BackgroundColor =
                Color.White;

            // ESTILO DEL BORDE
            dgvStock.BorderStyle =
                BorderStyle.None;

            // POSICION DEL GRID
            dgvStock.Location =
                new Point(60, 180);

            // TAMAÑO DEL GRID
            dgvStock.Size =
                new Size(1320, 620);

            // SOLO LECTURA
            dgvStock.ReadOnly = true;

            // OCULTA HEADERS DE FILAS
            dgvStock.RowHeadersVisible =
                false;

            // SELECCION COMPLETA DE FILA
            dgvStock.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // DESHABILITA ESTILOS VISUALES DEL HEADER
            dgvStock.EnableHeadersVisualStyles =
                false;

            // ALTURA DE LOS HEADERS
            dgvStock.ColumnHeadersHeight = 45;

            // COLOR DE FONDO DEL HEADER
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
            dgvStock.ColumnHeadersDefaultCellStyle =
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
            dgvStock.RowsDefaultCellStyle =
                rowsStyle;

            // =====================================
            // EVENTOS
            // =====================================

            // EVENTO CLICK DEL BOTON RECARGAR
            btnRecargar.Click +=
                new System.EventHandler(
                    this.btnRecargar_Click);

            // EVENTO CLICK DEL BOTON STOCK BAJO
            btnStockBajo.Click +=
                new System.EventHandler(
                    this.btnStockBajo_Click);

            // EVENTO CLICK DEL BOTON EXPORTAR
            btnExportar.Click +=
    new System.EventHandler(
        this.btnExportar_Click);

            // =====================================
            // CONTROLES
            // =====================================

            // AGREGA EL LABEL TITULO AL FORMULARIO
            this.Controls.Add(lblTitulo);

            // AGREGA EL BOTON RECARGAR
            this.Controls.Add(btnRecargar);

            // AGREGA EL BOTON STOCK BAJO
            this.Controls.Add(btnStockBajo);

            // AGREGA EL BOTON EXPORTAR
            this.Controls.Add(btnExportar);

            // AGREGA EL DATAGRIDVIEW
            this.Controls.Add(dgvStock);

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvStock))
                .EndInit();

            this.ResumeLayout(false);

            this.PerformLayout();
        }

        // =====================================
        // BOTONES
        // =====================================

        // METODO PARA CONFIGURAR LOS BOTONES DEL FORMULARIO
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

            // ESTILO FLAT DEL BOTON
            boton.FlatStyle =
                FlatStyle.Flat;

            // ELIMINA EL BORDE DEL BOTON
            boton.FlatAppearance.BorderSize = 0;

            // COLOR DEL TEXTO
            boton.ForeColor =
                Color.White;

            // CONFIGURACION DE LA FUENTE
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
                new Point(x, 100);

            // CAMBIA EL CURSOR A MANO
            boton.Cursor =
                Cursors.Hand;
        }

        #endregion

        // DECLARACION DEL LABEL TITULO
        private Label lblTitulo;

        // DECLARACION DEL BOTON RECARGAR
        private IconButton btnRecargar;

        // DECLARACION DEL BOTON STOCK BAJO
        private IconButton btnStockBajo;

        // DECLARACION DEL BOTON EXPORTAR
        private IconButton btnExportar;

        // DECLARACION DEL DATAGRIDVIEW
        private DataGridView dgvStock;
    }
}