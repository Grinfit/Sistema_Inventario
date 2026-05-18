using System.Drawing;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 =
                new System.Windows.Forms.DataGridViewCellStyle();

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 =
                new System.Windows.Forms.DataGridViewCellStyle();

            this.lblTitulo = new System.Windows.Forms.Label();

            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();

            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();

            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();

            this.dgvProductos = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();

            this.SuspendLayout();

            // =====================================================
            // FORMULARIO
            // =====================================================

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                Color.FromArgb(245, 245, 245);

            this.ClientSize =
                new System.Drawing.Size(1100, 720);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.None;

            this.Name = "FrmProductos";

            this.Text = "FrmProductos";

            this.Load +=
                new System.EventHandler(this.FrmProductos_Load);

            // =====================================================
            // TITULO
            // =====================================================

            this.lblTitulo.AutoSize = true;

            this.lblTitulo.Font =
                new Font(
                    "Segoe UI",
                    20F,
                    FontStyle.Bold);

            this.lblTitulo.ForeColor =
                Color.FromArgb(11, 31, 58);

            this.lblTitulo.Location =
                new Point(40, 25);

            this.lblTitulo.Name = "lblTitulo";

            this.lblTitulo.Size =
                new Size(350, 46);

            this.lblTitulo.Text =
                "Gestión de Productos";

            // =====================================================
            // LABEL BUSCAR
            // =====================================================

            this.label5.AutoSize = true;

            this.label5.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Regular);

            this.label5.Location =
                new Point(50, 110);

            this.label5.Text =
                "Buscar";

            // =====================================================
            // TXT BUSCAR
            // =====================================================

            this.txtBuscar.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.txtBuscar.Location =
                new Point(170, 108);

            this.txtBuscar.Size =
                new Size(300, 30);

            // =====================================================
            // BOTON BUSCAR
            // =====================================================

            this.btnBuscar.BackColor =
                Color.FromArgb(11, 31, 58);

            this.btnBuscar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnBuscar.FlatAppearance.BorderSize = 0;

            this.btnBuscar.ForeColor =
                Color.White;

            this.btnBuscar.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            this.btnBuscar.Cursor =
                System.Windows.Forms.Cursors.Hand;

            this.btnBuscar.Location =
                new Point(500, 105);

            this.btnBuscar.Size =
                new Size(130, 38);

            this.btnBuscar.Text =
                "Buscar";

            this.btnBuscar.UseVisualStyleBackColor = false;

            this.btnBuscar.Click +=
                new System.EventHandler(this.btnBuscar_Click);

            // =====================================================
            // LABEL NOMBRE
            // =====================================================

            this.label1.AutoSize = true;

            this.label1.Font =
                new Font(
                    "Segoe UI",
                    11F);

            this.label1.Location =
                new Point(50, 180);

            this.label1.Text =
                "Nombre";

            // =====================================================
            // TXT NOMBRE
            // =====================================================

            this.txtNombre.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.txtNombre.Location =
                new Point(170, 178);

            this.txtNombre.Size =
                new Size(320, 30);

            // =====================================================
            // LABEL CATEGORIA
            // =====================================================

            this.label2.AutoSize = true;

            this.label2.Font =
                new Font(
                    "Segoe UI",
                    11F);

            this.label2.Location =
                new Point(50, 240);

            this.label2.Text =
                "Categoría";

            // =====================================================
            // TXT CATEGORIA
            // =====================================================

            this.txtCategoria.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.txtCategoria.Location =
                new Point(170, 238);

            this.txtCategoria.Size =
                new Size(320, 30);

            // =====================================================
            // LABEL PRECIO
            // =====================================================

            this.label3.AutoSize = true;

            this.label3.Font =
                new Font(
                    "Segoe UI",
                    11F);

            this.label3.Location =
                new Point(50, 300);

            this.label3.Text =
                "Precio";

            // =====================================================
            // TXT PRECIO
            // =====================================================

            this.txtPrecio.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.txtPrecio.Location =
                new Point(170, 298);

            this.txtPrecio.Size =
                new Size(320, 30);

            // =====================================================
            // LABEL STOCK
            // =====================================================

            this.label4.AutoSize = true;

            this.label4.Font =
                new Font(
                    "Segoe UI",
                    11F);

            this.label4.Location =
                new Point(50, 360);

            this.label4.Text =
                "Stock";

            // =====================================================
            // TXT STOCK
            // =====================================================

            this.txtStock.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.txtStock.Location =
                new Point(170, 358);

            this.txtStock.Size =
                new Size(320, 30);

            // =====================================================
            // BOTON NUEVO
            // =====================================================

            this.btnNuevo.BackColor =
                Color.FromArgb(11, 31, 58);

            this.btnNuevo.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnNuevo.FlatAppearance.BorderSize = 0;

            this.btnNuevo.ForeColor =
                Color.White;

            this.btnNuevo.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            this.btnNuevo.Cursor =
                System.Windows.Forms.Cursors.Hand;

            this.btnNuevo.Location =
                new Point(55, 430);

            this.btnNuevo.Size =
                new Size(130, 42);

            this.btnNuevo.Text =
                "Nuevo";

            this.btnNuevo.UseVisualStyleBackColor = false;

            this.btnNuevo.Click +=
                new System.EventHandler(this.btnNuevo_Click);

            // =====================================================
            // BOTON GUARDAR
            // =====================================================

            this.btnGuardar.BackColor =
                Color.FromArgb(11, 31, 58);

            this.btnGuardar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnGuardar.FlatAppearance.BorderSize = 0;

            this.btnGuardar.ForeColor =
                Color.White;

            this.btnGuardar.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            this.btnGuardar.Cursor =
                System.Windows.Forms.Cursors.Hand;

            this.btnGuardar.Location =
                new Point(205, 430);

            this.btnGuardar.Size =
                new Size(130, 42);

            this.btnGuardar.Text =
                "Guardar";

            this.btnGuardar.UseVisualStyleBackColor = false;

            this.btnGuardar.Click +=
                new System.EventHandler(this.btnGuardar_Click);

            // =====================================================
            // BOTON EDITAR
            // =====================================================

            this.btnEditar.BackColor =
                Color.FromArgb(11, 31, 58);

            this.btnEditar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnEditar.FlatAppearance.BorderSize = 0;

            this.btnEditar.ForeColor =
                Color.White;

            this.btnEditar.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            this.btnEditar.Cursor =
                System.Windows.Forms.Cursors.Hand;

            this.btnEditar.Location =
                new Point(355, 430);

            this.btnEditar.Size =
                new Size(130, 42);

            this.btnEditar.Text =
                "Editar";

            this.btnEditar.UseVisualStyleBackColor = false;

            this.btnEditar.Click +=
                new System.EventHandler(this.btnEditar_Click);

            // =====================================================
            // BOTON ELIMINAR
            // =====================================================

            this.btnEliminar.BackColor =
                Color.FromArgb(11, 31, 58);

            this.btnEliminar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnEliminar.FlatAppearance.BorderSize = 0;

            this.btnEliminar.ForeColor =
                Color.White;

            this.btnEliminar.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            this.btnEliminar.Cursor =
                System.Windows.Forms.Cursors.Hand;

            this.btnEliminar.Location =
                new Point(505, 430);

            this.btnEliminar.Size =
                new Size(130, 42);

            this.btnEliminar.Text =
                "Eliminar";

            this.btnEliminar.UseVisualStyleBackColor = false;

            this.btnEliminar.Click +=
                new System.EventHandler(this.btnEliminar_Click);

            // =====================================================
            // DATAGRIDVIEW
            // =====================================================

            this.dgvProductos.AllowUserToAddRows = false;

            this.dgvProductos.AllowUserToDeleteRows = false;

            this.dgvProductos.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvProductos.BackgroundColor =
                Color.White;

            this.dgvProductos.BorderStyle =
                System.Windows.Forms.BorderStyle.None;

            this.dgvProductos.CellBorderStyle =
                System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;

            this.dgvProductos.ColumnHeadersBorderStyle =
                System.Windows.Forms.DataGridViewHeaderBorderStyle.None;

            dataGridViewCellStyle1.Alignment =
                System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;

            dataGridViewCellStyle1.BackColor =
                Color.FromArgb(11, 31, 58);

            dataGridViewCellStyle1.ForeColor =
                Color.White;

            dataGridViewCellStyle1.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            dataGridViewCellStyle1.SelectionBackColor =
                Color.FromArgb(11, 31, 58);

            dataGridViewCellStyle1.WrapMode =
                System.Windows.Forms.DataGridViewTriState.True;

            this.dgvProductos.ColumnHeadersDefaultCellStyle =
                dataGridViewCellStyle1;

            this.dgvProductos.ColumnHeadersHeight = 40;

            this.dgvProductos.EnableHeadersVisualStyles = false;

            this.dgvProductos.GridColor =
                Color.LightGray;

            this.dgvProductos.Location =
                new Point(20, 510);

            this.dgvProductos.MultiSelect = false;

            this.dgvProductos.Name =
                "dgvProductos";

            this.dgvProductos.ReadOnly = true;

            this.dgvProductos.RowHeadersVisible = false;

            dataGridViewCellStyle2.Font =
                new Font(
                    "Segoe UI",
                    10F);

            this.dgvProductos.RowsDefaultCellStyle =
                dataGridViewCellStyle2;

            this.dgvProductos.RowTemplate.Height = 35;

            this.dgvProductos.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvProductos.Size =
                new Size(1050, 180);

            this.dgvProductos.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvProductos_CellClick);

            // =====================================================
            // CONTROLES
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

            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnBuscar);

            this.Controls.Add(this.dgvProductos);

            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();

            this.ResumeLayout(false);

            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtBuscar;

        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnBuscar;

        private System.Windows.Forms.DataGridView dgvProductos;
    }

}
