// IMPORTACION DE LIBRERIAS NECESARIAS
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Sistema_Inventario.Presentacion
{
    // CLASE PARCIAL DEL FORMULARIO MODAL DE PRODUCTO
    partial class FrmProductoModal
    {
        // CONTENEDOR DE COMPONENTES
        private System.ComponentModel.IContainer components = null;

        // METODO PARA LIBERAR RECURSOS
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        // METODO PARA INICIALIZAR COMPONENTES
        private void InitializeComponent()
        {
            // CONTROLES
            this.pnlHeader    = new Panel();
            this.lblTitulo    = new Label();
            this.lblNombre    = new Label();
            this.txtNombre    = new TextBox();
            this.lblCategoria = new Label();
            this.txtCategoria = new TextBox();
            this.lblPrecio    = new Label();
            this.txtPrecio    = new TextBox();
            this.lblStock     = new Label();
            this.txtStock     = new TextBox();
            this.btnGuardar   = new IconButton();
            this.btnCancelar  = new IconButton();

            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            // ─────────────────────────────────────────
            // FORMULARIO
            // ─────────────────────────────────────────
            this.ClientSize       = new System.Drawing.Size(520, 430);
            this.BackColor        = System.Drawing.Color.FromArgb(240, 242, 245);
            this.FormBorderStyle  = FormBorderStyle.FixedDialog;
            this.MaximizeBox      = false;
            this.MinimizeBox      = false;
            this.StartPosition    = FormStartPosition.CenterParent;
            this.ShowInTaskbar    = false;
            this.Name             = "FrmProductoModal";
            this.Text             = "Producto";
            this.AcceptButton     = this.btnGuardar;
            this.CancelButton     = this.btnCancelar;

            // ─────────────────────────────────────────
            // PANEL CABECERA AZUL
            // ─────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(10, 35, 66);
            this.pnlHeader.Dock      = DockStyle.Top;
            this.pnlHeader.Height    = 65;
            this.pnlHeader.Controls.Add(this.lblTitulo);

            // LABEL TITULO (dentro del panel)
            this.lblTitulo.AutoSize  = true;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location  = new System.Drawing.Point(25, 17);
            this.lblTitulo.Text      = "Nuevo Producto";

            // ─────────────────────────────────────────
            // CAMPO NOMBRE
            // ─────────────────────────────────────────
            this.lblNombre.AutoSize  = true;
            this.lblNombre.Font      = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.lblNombre.Location  = new System.Drawing.Point(40, 85);
            this.lblNombre.Text      = "Nombre";

            this.txtNombre.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtNombre.Location    = new System.Drawing.Point(40, 108);
            this.txtNombre.Size        = new System.Drawing.Size(420, 38);
            this.txtNombre.BorderStyle = BorderStyle.FixedSingle;
            this.txtNombre.MaxLength   = 100;

            // ─────────────────────────────────────────
            // CAMPO CATEGORIA
            // ─────────────────────────────────────────
            this.lblCategoria.AutoSize  = true;
            this.lblCategoria.Font      = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.lblCategoria.Location  = new System.Drawing.Point(40, 166);
            this.lblCategoria.Text      = "Categoría";

            this.txtCategoria.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtCategoria.Location    = new System.Drawing.Point(40, 189);
            this.txtCategoria.Size        = new System.Drawing.Size(420, 38);
            this.txtCategoria.BorderStyle = BorderStyle.FixedSingle;
            this.txtCategoria.MaxLength   = 100;

            // ─────────────────────────────────────────
            // CAMPO PRECIO  (mitad izquierda)
            // ─────────────────────────────────────────
            this.lblPrecio.AutoSize  = true;
            this.lblPrecio.Font      = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblPrecio.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.lblPrecio.Location  = new System.Drawing.Point(40, 247);
            this.lblPrecio.Text      = "Precio";

            this.txtPrecio.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPrecio.Location    = new System.Drawing.Point(40, 270);
            this.txtPrecio.Size        = new System.Drawing.Size(195, 38);
            this.txtPrecio.BorderStyle = BorderStyle.FixedSingle;
            this.txtPrecio.MaxLength   = 18;

            // ─────────────────────────────────────────
            // CAMPO STOCK  (mitad derecha)
            // ─────────────────────────────────────────
            this.lblStock.AutoSize  = true;
            this.lblStock.Font      = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblStock.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.lblStock.Location  = new System.Drawing.Point(265, 247);
            this.lblStock.Text      = "Stock";

            this.txtStock.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtStock.Location    = new System.Drawing.Point(265, 270);
            this.txtStock.Size        = new System.Drawing.Size(195, 38);
            this.txtStock.BorderStyle = BorderStyle.FixedSingle;
            this.txtStock.MaxLength   = 10;

            // ─────────────────────────────────────────
            // BOTON GUARDAR
            // ─────────────────────────────────────────
            this.btnGuardar.BackColor                  = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnGuardar.FlatStyle                  = FlatStyle.Flat;
            this.btnGuardar.FlatAppearance.BorderSize  = 0;
            this.btnGuardar.ForeColor                  = System.Drawing.Color.White;
            this.btnGuardar.Font                       = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.IconChar                   = IconChar.FloppyDisk;
            this.btnGuardar.IconColor                  = System.Drawing.Color.White;
            this.btnGuardar.IconFont                   = IconFont.Auto;
            this.btnGuardar.IconSize                   = 26;
            this.btnGuardar.Text                       = " Guardar";
            this.btnGuardar.TextImageRelation          = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.Location                   = new System.Drawing.Point(40, 340);
            this.btnGuardar.Size                       = new System.Drawing.Size(190, 52);
            this.btnGuardar.Cursor                     = Cursors.Hand;
            this.btnGuardar.Click                     += new System.EventHandler(this.btnGuardar_Click);

            // ─────────────────────────────────────────
            // BOTON CANCELAR
            // ─────────────────────────────────────────
            this.btnCancelar.BackColor                  = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnCancelar.FlatStyle                  = FlatStyle.Flat;
            this.btnCancelar.FlatAppearance.BorderSize  = 0;
            this.btnCancelar.ForeColor                  = System.Drawing.Color.White;
            this.btnCancelar.Font                       = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.IconChar                   = IconChar.Xmark;
            this.btnCancelar.IconColor                  = System.Drawing.Color.White;
            this.btnCancelar.IconFont                   = IconFont.Auto;
            this.btnCancelar.IconSize                   = 26;
            this.btnCancelar.Text                       = " Cancelar";
            this.btnCancelar.TextImageRelation          = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.Location                   = new System.Drawing.Point(262, 340);
            this.btnCancelar.Size                       = new System.Drawing.Size(190, 52);
            this.btnCancelar.Cursor                     = Cursors.Hand;
            this.btnCancelar.DialogResult               = DialogResult.Cancel;

            // ─────────────────────────────────────────
            // AGREGAR CONTROLES AL FORMULARIO
            // ─────────────────────────────────────────
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pnlHeader);   // agregado al final para z-order correcto

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // PANEL CABECERA
        private Panel pnlHeader;
        private Label lblTitulo;

        // CAMPOS
        private Label   lblNombre;
        private TextBox txtNombre;
        private Label   lblCategoria;
        private TextBox txtCategoria;
        private Label   lblPrecio;
        private TextBox txtPrecio;
        private Label   lblStock;
        private TextBox txtStock;

        // BOTONES
        private IconButton btnGuardar;
        private IconButton btnCancelar;
    }
}
