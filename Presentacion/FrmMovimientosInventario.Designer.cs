using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Inventario.Presentacion
{
    partial class FrmMovimientosInventario
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
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

            this.lblTitulo =
                new Label();

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

            this.cboTipoMovimiento =
                new ComboBox();

            this.cboProducto =
                new ComboBox();

            this.cboBodega =
                new ComboBox();

            this.txtCantidad =
                new TextBox();

            this.txtObservacion =
                new TextBox();

            this.btnNuevo =
                new IconButton();

            this.btnGuardar =
                new IconButton();

            this.dgvMovimientos =
                new DataGridView();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvMovimientos))
                .BeginInit();

            this.SuspendLayout();

            // =====================================
            // FORM
            // =====================================

            this.BackColor =
                Color.FromArgb(236, 240, 245);

            this.ClientSize =
                new Size(1400, 900);

            this.FormBorderStyle =
                FormBorderStyle.None;

            this.Text =
                "FrmMovimientosInventario";

            this.Load +=
                new System.EventHandler(
                    this.FrmMovimientosInventario_Load);

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
                new Point(50, 30);

            lblTitulo.Text =
                "Movimientos de Inventario";

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
                "Tipo Movimiento",
                "Producto",
                "Bodega",
                "Cantidad",
                "Observación"
            };

            int[] posY =
            {
                130,
                230,
                330,
                430,
                530
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
                cboTipoMovimiento,
                cboProducto,
                cboBodega
            };

            int[] comboY =
            {
                165,
                265,
                365
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
                    new Size(400, 38);

                combos[i].DropDownStyle =
                    ComboBoxStyle.DropDownList;
            }

            // =====================================
            // TXT CANTIDAD
            // =====================================

            txtCantidad.Font =
                new Font(
                    "Segoe UI",
                    12F);

            txtCantidad.Location =
                new Point(60, 465);

            txtCantidad.Size =
                new Size(250, 38);

            txtCantidad.BorderStyle =
                BorderStyle.FixedSingle;

            // =====================================
            // TXT OBSERVACION
            // =====================================

            txtObservacion.Font =
                new Font(
                    "Segoe UI",
                    11F);

            txtObservacion.Location =
                new Point(60, 565);

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
            // BTN GUARDAR
            // =====================================

            ConfigurarBoton(
                btnGuardar,
                " Registrar",
                IconChar.FloppyDisk,
                Color.FromArgb(46, 204, 113),
                270);

            // =====================================
            // GRID
            // =====================================

            dgvMovimientos.AllowUserToAddRows = false;

            dgvMovimientos.AllowUserToDeleteRows = false;

            dgvMovimientos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvMovimientos.BackgroundColor =
                Color.White;

            dgvMovimientos.BorderStyle =
                BorderStyle.None;

            dgvMovimientos.Location =
                new Point(760, 140);

            dgvMovimientos.Size =
                new Size(820, 650);

            dgvMovimientos.ReadOnly = true;

            dgvMovimientos.RowHeadersVisible =
                false;

            dgvMovimientos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvMovimientos.EnableHeadersVisualStyles =
                false;

            dgvMovimientos.ColumnHeadersHeight = 45;

            headerStyle.BackColor =
                Color.FromArgb(10, 35, 66);

            headerStyle.ForeColor =
                Color.White;

            headerStyle.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            dgvMovimientos.ColumnHeadersDefaultCellStyle =
                headerStyle;

            rowsStyle.Font =
                new Font(
                    "Segoe UI",
                    10F);

            rowsStyle.SelectionBackColor =
                Color.FromArgb(52, 152, 219);

            rowsStyle.SelectionForeColor =
                Color.White;

            dgvMovimientos.RowsDefaultCellStyle =
                rowsStyle;

            // =====================================
            // EVENTOS
            // =====================================

            btnGuardar.Click +=
                new System.EventHandler(
                    this.btnGuardar_Click);

            btnNuevo.Click +=
                new System.EventHandler(
                    this.btnNuevo_Click);

            // =====================================
            // CONTROLES
            // =====================================

            this.Controls.Add(lblTitulo);

            this.Controls.Add(label1);
            this.Controls.Add(label2);
            this.Controls.Add(label3);
            this.Controls.Add(label4);
            this.Controls.Add(label5);

            this.Controls.Add(cboTipoMovimiento);
            this.Controls.Add(cboProducto);
            this.Controls.Add(cboBodega);

            this.Controls.Add(txtCantidad);
            this.Controls.Add(txtObservacion);

            this.Controls.Add(btnNuevo);
            this.Controls.Add(btnGuardar);

            this.Controls.Add(dgvMovimientos);

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvMovimientos))
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
                new Size(180, 58);

            boton.Location =
                new Point(x, 700);

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

        private ComboBox cboTipoMovimiento;
        private ComboBox cboProducto;
        private ComboBox cboBodega;

        private TextBox txtCantidad;
        private TextBox txtObservacion;

        private IconButton btnNuevo;
        private IconButton btnGuardar;

        private DataGridView dgvMovimientos;
    }
}