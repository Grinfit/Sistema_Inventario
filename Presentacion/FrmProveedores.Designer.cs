using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Sistema_Inventario.Presentacion
{
    partial class FrmProveedores
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
            DataGridViewCellStyle headerStyle =
                new DataGridViewCellStyle();

            DataGridViewCellStyle rowsStyle =
                new DataGridViewCellStyle();

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

            this.SuspendLayout();

            // =====================================
            // FORM
            // =====================================

            this.ClientSize =
                new Size(1350, 860);

            this.BackColor =
                Color.FromArgb(236, 240, 245);

            this.FormBorderStyle =
                FormBorderStyle.None;

            this.Name =
                "FrmProveedores";

            this.Text =
                "FrmProveedores";

            this.Load +=
                new System.EventHandler(this.FrmProveedores_Load);

            // =====================================
            // TITULO
            // =====================================

            this.lblTitulo.AutoSize = true;

            this.lblTitulo.Font =
                new Font(
                    "Segoe UI",
                    30F,
                    FontStyle.Bold);

            this.lblTitulo.ForeColor =
                Color.FromArgb(10, 35, 66);

            this.lblTitulo.Location =
                new Point(50, 35);

            this.lblTitulo.Text =
                "Gestión de Proveedores";

            // =====================================
            // BUSCAR
            // =====================================

            this.label6.AutoSize = true;

            this.label6.Font =
                new Font(
                    "Segoe UI Semibold",
                    12F,
                    FontStyle.Bold);

            this.label6.Location =
                new Point(60, 115);

            this.label6.Text =
                "Buscar Proveedor";

            this.txtBuscar.Font =
                new Font(
                    "Segoe UI",
                    11F);

            this.txtBuscar.Location =
                new Point(60, 145);

            this.txtBuscar.Size =
                new Size(420, 38);

            this.txtBuscar.BorderStyle =
                BorderStyle.FixedSingle;

            // =====================================
            // BTN BUSCAR
            // =====================================

            this.btnBuscar.BackColor =
                Color.FromArgb(10, 35, 66);

            this.btnBuscar.FlatStyle =
                FlatStyle.Flat;

            this.btnBuscar.FlatAppearance.BorderSize = 0;

            this.btnBuscar.ForeColor =
                Color.White;

            this.btnBuscar.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            this.btnBuscar.IconChar =
                IconChar.Search;

            this.btnBuscar.IconColor =
                Color.White;

            this.btnBuscar.IconFont =
                IconFont.Auto;

            this.btnBuscar.IconSize = 24;

            this.btnBuscar.Text =
                " Buscar";

            this.btnBuscar.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            this.btnBuscar.Location =
                new Point(500, 142);

            this.btnBuscar.Size =
                new Size(160, 42);

            this.btnBuscar.Cursor =
                Cursors.Hand;

            this.btnBuscar.Click +=
                new System.EventHandler(this.btnBuscar_Click);

            // =====================================
            // LABELS
            // =====================================

            Label[] labels =
            {
                label1,
                label2,
                label3,
                label4,
                label5
            };

            string[] textos =
            {
                "Nombre",
                "Empresa",
                "Teléfono",
                "Correo",
                "Dirección"
            };

            int[] posicionesY =
            {
                230,
                330,
                430,
                230,
                330
            };

            int[] posicionesX =
            {
                60,
                60,
                60,
                520,
                520
            };

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

            // =====================================
            // TEXTBOX
            // =====================================

            TextBox[] txts =
            {
                txtNombre,
                txtEmpresa,
                txtTelefono,
                txtCorreo,
                txtDireccion
            };

            int[] txtX =
            {
                60,
                60,
                60,
                520,
                520
            };

            int[] txtY =
            {
                265,
                365,
                465,
                265,
                365
            };

            int[] txtW =
            {
                360,
                360,
                360,
                360,
                360
            };

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

            // =====================================
            // BOTONES
            // =====================================

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

            // =====================================
            // GRID
            // =====================================

            this.dgvProveedores.AllowUserToAddRows = false;

            this.dgvProveedores.AllowUserToDeleteRows = false;

            this.dgvProveedores.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvProveedores.BackgroundColor =
                Color.White;

            this.dgvProveedores.BorderStyle =
                BorderStyle.None;

            this.dgvProveedores.Location =
                new Point(60, 585);

            this.dgvProveedores.Size =
                new Size(1500, 400);

            this.dgvProveedores.ReadOnly = true;

            this.dgvProveedores.RowHeadersVisible = false;

            this.dgvProveedores.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            this.dgvProveedores.MultiSelect = false;

            this.dgvProveedores.EnableHeadersVisualStyles = false;

            this.dgvProveedores.ColumnHeadersHeight = 45;

            headerStyle.BackColor =
                Color.FromArgb(10, 35, 66);

            headerStyle.ForeColor =
                Color.White;

            headerStyle.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            this.dgvProveedores.ColumnHeadersDefaultCellStyle =
                headerStyle;

            rowsStyle.Font =
                new Font(
                    "Segoe UI",
                    10F);

            rowsStyle.SelectionBackColor =
                Color.FromArgb(52, 152, 219);

            rowsStyle.SelectionForeColor =
                Color.White;

            this.dgvProveedores.RowsDefaultCellStyle =
                rowsStyle;

            this.dgvProveedores.CellClick +=
                new DataGridViewCellEventHandler(
                    this.dgvProveedores_CellClick);

            // =====================================
            // EVENTOS
            // =====================================

            this.btnNuevo.Click +=
                new System.EventHandler(this.btnNuevo_Click);

            this.btnGuardar.Click +=
                new System.EventHandler(this.btnGuardar_Click);

            this.btnEditar.Click +=
                new System.EventHandler(this.btnEditar_Click);

            this.btnEliminar.Click +=
                new System.EventHandler(this.btnEliminar_Click);

            // =====================================
            // CONTROLES
            // =====================================

            this.Controls.Add(this.lblTitulo);

            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);

            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtEmpresa);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtBuscar);

            this.Controls.Add(this.btnBuscar);

            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);

            this.Controls.Add(this.dgvProveedores);

            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();

            this.ResumeLayout(false);

            this.PerformLayout();
        }

        // =====================================
        // CONFIG BOTONES
        // =====================================

        private void ConfigurarBoton(
            IconButton boton,
            string texto,
            IconChar icono,
            Color color,
            int x)
        {
            boton.BackColor = color;

            boton.FlatStyle =
                FlatStyle.Flat;

            boton.FlatAppearance.BorderSize = 0;

            boton.ForeColor =
                Color.White;

            boton.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            boton.IconChar =
                icono;

            boton.IconColor =
                Color.White;

            boton.IconFont =
                IconFont.Auto;

            boton.IconSize = 28;

            boton.Text = texto;

            boton.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            boton.Size =
                new Size(170, 58);

            boton.Location =
                new Point(x, 520);

            boton.Cursor =
                Cursors.Hand;
        }

        #endregion

        private Label lblTitulo;

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;

        private TextBox txtNombre;
        private TextBox txtEmpresa;
        private TextBox txtTelefono;
        private TextBox txtCorreo;
        private TextBox txtDireccion;
        private TextBox txtBuscar;

        private IconButton btnNuevo;
        private IconButton btnGuardar;
        private IconButton btnEditar;
        private IconButton btnEliminar;
        private IconButton btnBuscar;

        private DataGridView dgvProveedores;
    }
}