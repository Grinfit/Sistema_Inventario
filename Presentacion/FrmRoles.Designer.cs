namespace Sistema_Inventario.Presentacion
{
    partial class FrmRoles
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

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            this.lblTitulo =
                new System.Windows.Forms.Label();

            this.lblNombre =
                new System.Windows.Forms.Label();

            this.txtNombre =
                new System.Windows.Forms.TextBox();

            this.chkEstado =
                new System.Windows.Forms.CheckBox();

            this.lblPermisos =
                new System.Windows.Forms.Label();

            this.clbPermisos =
                new System.Windows.Forms.CheckedListBox();

            this.dgvRoles =
                new System.Windows.Forms.DataGridView();

            this.btnNuevo =
                new FontAwesome.Sharp.IconButton();

            this.btnGuardar =
                new FontAwesome.Sharp.IconButton();

            this.btnEditar =
                new FontAwesome.Sharp.IconButton();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvRoles)).BeginInit();

            this.SuspendLayout();

            // =====================================
            // FORM
            // =====================================

            this.BackColor =
                System.Drawing.Color.FromArgb(
                    243,
                    244,
                    246);

            this.ClientSize =
                new System.Drawing.Size(1450, 850);

            this.Text =
                "Roles";

            // =====================================
            // TITULO
            // =====================================

            this.lblTitulo.AutoSize = true;

            this.lblTitulo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    28F,
                    System.Drawing.FontStyle.Bold);

            this.lblTitulo.ForeColor =
                System.Drawing.Color.FromArgb(
                    11,
                    31,
                    58);

            this.lblTitulo.Location =
                new System.Drawing.Point(40, 25);

            this.lblTitulo.Text =
                "Gestión de Roles";

            // =====================================
            // NOMBRE
            // =====================================

            this.lblNombre.AutoSize = true;

            this.lblNombre.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold);

            this.lblNombre.Location =
                new System.Drawing.Point(50, 120);

            this.lblNombre.Text =
                "Nombre del Rol";

            this.txtNombre.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F);

            this.txtNombre.Location =
                new System.Drawing.Point(55, 155);

            this.txtNombre.Size =
                new System.Drawing.Size(350, 34);

            // =====================================
            // ESTADO
            // =====================================

            this.chkEstado.AutoSize = true;

            this.chkEstado.Checked = true;

            this.chkEstado.CheckState =
                System.Windows.Forms.CheckState.Checked;

            this.chkEstado.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold);

            this.chkEstado.Location =
                new System.Drawing.Point(55, 215);

            this.chkEstado.Text =
                "Rol Activo";

            // =====================================
            // PERMISOS
            // =====================================

            this.lblPermisos.AutoSize = true;

            this.lblPermisos.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold);

            this.lblPermisos.Location =
                new System.Drawing.Point(50, 270);

            this.lblPermisos.Text =
                "Permisos del Rol";

            this.clbPermisos.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F);

            this.clbPermisos.FormattingEnabled = true;

            this.clbPermisos.Location =
                new System.Drawing.Point(55, 305);

            this.clbPermisos.Size =
                new System.Drawing.Size(420, 400);

            // =====================================
            // BOTONES
            // =====================================

            this.btnNuevo.BackColor =
                System.Drawing.Color.FromArgb(
                    59,
                    130,
                    246);

            this.btnNuevo.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnNuevo.FlatAppearance.BorderSize = 0;

            this.btnNuevo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold);

            this.btnNuevo.ForeColor =
                System.Drawing.Color.White;

            this.btnNuevo.IconChar =
                FontAwesome.Sharp.IconChar.PlusCircle;

            this.btnNuevo.IconColor =
                System.Drawing.Color.White;

            this.btnNuevo.IconFont =
                FontAwesome.Sharp.IconFont.Auto;

            this.btnNuevo.Location =
                new System.Drawing.Point(55, 740);

            this.btnNuevo.Size =
                new System.Drawing.Size(160, 55);

            this.btnNuevo.Text =
                " Nuevo";

            this.btnNuevo.TextImageRelation =
                System.Windows.Forms.TextImageRelation.ImageBeforeText;

            // =====================================

            this.btnGuardar.BackColor =
                System.Drawing.Color.FromArgb(
                    34,
                    197,
                    94);

            this.btnGuardar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnGuardar.FlatAppearance.BorderSize = 0;

            this.btnGuardar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold);

            this.btnGuardar.ForeColor =
                System.Drawing.Color.White;

            this.btnGuardar.IconChar =
                FontAwesome.Sharp.IconChar.FloppyDisk;

            this.btnGuardar.IconColor =
                System.Drawing.Color.White;

            this.btnGuardar.IconFont =
                FontAwesome.Sharp.IconFont.Auto;

            this.btnGuardar.Location =
                new System.Drawing.Point(240, 740);

            this.btnGuardar.Size =
                new System.Drawing.Size(160, 55);

            this.btnGuardar.Text =
                " Guardar";

            this.btnGuardar.TextImageRelation =
                System.Windows.Forms.TextImageRelation.ImageBeforeText;

            // =====================================

            this.btnEditar.BackColor =
                System.Drawing.Color.FromArgb(
                    234,
                    179,
                    8);

            this.btnEditar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnEditar.FlatAppearance.BorderSize = 0;

            this.btnEditar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold);

            this.btnEditar.ForeColor =
                System.Drawing.Color.White;

            this.btnEditar.IconChar =
                FontAwesome.Sharp.IconChar.PenToSquare;

            this.btnEditar.IconColor =
                System.Drawing.Color.White;

            this.btnEditar.IconFont =
                FontAwesome.Sharp.IconFont.Auto;

            this.btnEditar.Location =
                new System.Drawing.Point(425, 740);

            this.btnEditar.Size =
                new System.Drawing.Size(160, 55);

            this.btnEditar.Text =
                " Editar";

            this.btnEditar.TextImageRelation =
                System.Windows.Forms.TextImageRelation.ImageBeforeText;

            // =====================================
            // GRID
            // =====================================

            this.dgvRoles.AllowUserToAddRows =
                false;

            this.dgvRoles.AllowUserToDeleteRows =
                false;

            this.dgvRoles.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvRoles.BackgroundColor =
                System.Drawing.Color.White;

            this.dgvRoles.BorderStyle =
                System.Windows.Forms.BorderStyle.None;

            this.dgvRoles.ColumnHeadersHeight = 40;

            this.dgvRoles.Location =
                new System.Drawing.Point(550, 120);

            this.dgvRoles.MultiSelect = false;

            this.dgvRoles.ReadOnly = true;

            this.dgvRoles.RowHeadersVisible = false;

            this.dgvRoles.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvRoles.Size =
                new System.Drawing.Size(840, 675);

            // =====================================
            // ADD CONTROLS
            // =====================================

            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.chkEstado);
            this.Controls.Add(this.lblPermisos);
            this.Controls.Add(this.clbPermisos);
            this.Controls.Add(this.dgvRoles);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvRoles)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.Label lblPermisos;
        private System.Windows.Forms.CheckedListBox clbPermisos;
        private System.Windows.Forms.DataGridView dgvRoles;

        private FontAwesome.Sharp.IconButton btnNuevo;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnEditar;
    }
}