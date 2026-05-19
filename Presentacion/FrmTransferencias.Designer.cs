using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Inventario.Presentacion
{
    partial class FrmTransferencias
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(
            bool disposing)
        {
            if (disposing &&
                (components != null))
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

            this.cboProducto = new ComboBox();
            this.cboBodegaOrigen = new ComboBox();
            this.cboBodegaDestino = new ComboBox();

            this.txtCantidad = new TextBox();
            this.txtObservacion = new TextBox();

            this.btnNuevo = new IconButton();
            this.btnTransferir = new IconButton();
            this.btnExportar = new IconButton();
            this.dgvTransferencias = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvTransferencias))
                .BeginInit();

            this.SuspendLayout();

            // =====================================
            // FORM
            // =====================================

            this.BackColor =
                Color.FromArgb(236, 240, 245);

            this.ClientSize =
                new Size(1450, 900);

            this.FormBorderStyle =
                FormBorderStyle.None;

            this.Text =
                "FrmTransferencias";

            this.Load +=
                new System.EventHandler(
                    this.FrmTransferencias_Load);

            // =====================================
            // TITULO
            // =====================================

            lblTitulo.AutoSize = true;

            lblTitulo.Font =
                new Font(
                    "Segoe UI",
                    30F,
                    FontStyle.Bold);

            lblTitulo.ForeColor =
                Color.FromArgb(10, 35, 66);

            lblTitulo.Location =
                new Point(50, 35);

            lblTitulo.Text =
                "Transferencias entre Bodegas";

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
                "Producto",
                "Bodega Origen",
                "Bodega Destino",
                "Cantidad",
                "Observación"
            };

            int[] posY =
            {
                140,
                240,
                340,
                440,
                540
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
                    new Point(60, posY[i]);

                labels[i].Text =
                    textos[i];
            }

            // =====================================
            // COMBOS
            // =====================================

            ComboBox[] combos =
            {
                cboProducto,
                cboBodegaOrigen,
                cboBodegaDestino
            };

            int[] comboY =
            {
                175,
                275,
                375
            };

            for (int i = 0; i < combos.Length; i++)
            {
                combos[i].Font =
                    new Font(
                        "Segoe UI",
                        12F);

                combos[i].Location =
                    new Point(60, comboY[i]);

                combos[i].Size =
                    new Size(420, 38);

                combos[i].DropDownStyle =
                    ComboBoxStyle.DropDownList;
            }

            // =====================================
            // CANTIDAD
            // =====================================

            txtCantidad.Font =
                new Font(
                    "Segoe UI",
                    12F);

            txtCantidad.Location =
                new Point(60, 475);

            txtCantidad.Size =
                new Size(220, 38);

            txtCantidad.BorderStyle =
                BorderStyle.FixedSingle;

            // =====================================
            // OBSERVACION
            // =====================================

            txtObservacion.Font =
                new Font(
                    "Segoe UI",
                    11F);

            txtObservacion.Location =
                new Point(60, 575);

            txtObservacion.Size =
                new Size(650, 90);

            txtObservacion.Multiline =
                true;

            txtObservacion.BorderStyle =
                BorderStyle.FixedSingle;

            // =====================================
            // BTN NUEVO
            // =====================================

            ConfigurarBoton(
                btnNuevo,
                " Nuevo",
                IconChar.CirclePlus,
                Color.FromArgb(52, 152, 219),
                60);

            // =====================================
            // BTN TRANSFERIR
            // =====================================

            ConfigurarBoton(
                btnTransferir,
                " Transferir",
                IconChar.RightLeft,
                Color.FromArgb(46, 204, 113),
                280);
            ConfigurarBoton(
    btnExportar,
    " Exportar Excel",
    IconChar.FileExcel,
    Color.FromArgb(39, 174, 96),
    500);
            // =====================================
            // GRID
            // =====================================

            dgvTransferencias.AllowUserToAddRows =
                false;

            dgvTransferencias.AllowUserToDeleteRows =
                false;

            dgvTransferencias.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvTransferencias.BackgroundColor =
                Color.White;

            dgvTransferencias.BorderStyle =
                BorderStyle.None;

            dgvTransferencias.Location =
                new Point(760, 150);

            dgvTransferencias.Size =
                new Size(850, 620);

            dgvTransferencias.ReadOnly = true;

            dgvTransferencias.RowHeadersVisible =
                false;

            dgvTransferencias.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvTransferencias.EnableHeadersVisualStyles =
                false;

            dgvTransferencias.ColumnHeadersHeight = 45;

            headerStyle.BackColor =
                Color.FromArgb(10, 35, 66);

            headerStyle.ForeColor =
                Color.White;

            headerStyle.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            dgvTransferencias.ColumnHeadersDefaultCellStyle =
                headerStyle;

            rowsStyle.Font =
                new Font(
                    "Segoe UI",
                    10F);

            rowsStyle.SelectionBackColor =
                Color.FromArgb(52, 152, 219);

            rowsStyle.SelectionForeColor =
                Color.White;

            dgvTransferencias.RowsDefaultCellStyle =
                rowsStyle;

            // =====================================
            // EVENTOS
            // =====================================

            btnNuevo.Click +=
                new System.EventHandler(
                    this.btnNuevo_Click);

            btnTransferir.Click +=
                new System.EventHandler(
                    this.btnTransferir_Click);
            btnExportar.Click +=
    new System.EventHandler(
        this.btnExportar_Click);
            // =====================================
            // CONTROLES
            // =====================================

            this.Controls.Add(lblTitulo);

            this.Controls.Add(label1);
            this.Controls.Add(label2);
            this.Controls.Add(label3);
            this.Controls.Add(label4);
            this.Controls.Add(label5);

            this.Controls.Add(cboProducto);
            this.Controls.Add(cboBodegaOrigen);
            this.Controls.Add(cboBodegaDestino);

            this.Controls.Add(txtCantidad);
            this.Controls.Add(txtObservacion);

            this.Controls.Add(btnNuevo);
            this.Controls.Add(btnTransferir);
            this.Controls.Add(btnExportar);
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

        private void ConfigurarBoton(
            IconButton boton,
            string texto,
            IconChar icono,
            Color color,
            int x)
        {
            boton.BackColor =
                color;

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

            boton.Text =
                texto;

            boton.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            boton.Size =
                new Size(190, 58);

            boton.Location =
                new Point(x, 720);

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

        private ComboBox cboProducto;
        private ComboBox cboBodegaOrigen;
        private ComboBox cboBodegaDestino;

        private TextBox txtCantidad;
        private TextBox txtObservacion;

        private IconButton btnNuevo;
        private IconButton btnTransferir;
        private IconButton btnExportar;
        private DataGridView dgvTransferencias;
    }
}