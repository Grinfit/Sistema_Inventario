namespace Sistema_Inventario.Presentacion
{
    partial class FrmUsuarios
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

            this.lblBuscar =
                new System.Windows.Forms.Label();

            this.txtBuscar =
                new System.Windows.Forms.TextBox();

            this.lblUsuario =
                new System.Windows.Forms.Label();

            this.txtUsuario =
                new System.Windows.Forms.TextBox();

            this.lblClave =
                new System.Windows.Forms.Label();

            this.txtClave =
                new System.Windows.Forms.TextBox();

            this.lblConfirmar =
                new System.Windows.Forms.Label();

            this.txtConfirmar =
                new System.Windows.Forms.TextBox();

            this.lblRol =
                new System.Windows.Forms.Label();

            this.cboRoles =
                new System.Windows.Forms.ComboBox();

            this.chkEstado =
                new System.Windows.Forms.CheckBox();

            this.dgvUsuarios =
                new System.Windows.Forms.DataGridView();

            this.btnNuevo =
                new FontAwesome.Sharp.IconButton();

            this.btnGuardar =
                new FontAwesome.Sharp.IconButton();

            this.btnEditar =
                new FontAwesome.Sharp.IconButton();

            this.btnEliminar =
                new FontAwesome.Sharp.IconButton();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvUsuarios)).BeginInit();

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
                new System.Drawing.Size(1400, 850);

            this.Text =
                "Usuarios";

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
                new System.Drawing.Point(45, 25);

            this.lblTitulo.Text =
                "Gestión de Usuarios";

            // =====================================
            // BUSCAR
            // =====================================

            this.lblBuscar.AutoSize = true;

            this.lblBuscar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold);

            this.lblBuscar.Location =
                new System.Drawing.Point(55, 110);

            this.lblBuscar.Text =
                "Buscar Usuario";

            this.txtBuscar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F);

            this.txtBuscar.Location =
                new System.Drawing.Point(60, 145);

            this.txtBuscar.Size =
                new System.Drawing.Size(350, 34);

            // =====================================
            // USUARIO
            // =====================================

            this.lblUsuario.AutoSize = true;

            this.lblUsuario.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold);

            this.lblUsuario.Location =
                new System.Drawing.Point(55, 220);

            this.lblUsuario.Text =
                "Usuario";

            this.txtUsuario.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F);

            this.txtUsuario.Location =
                new System.Drawing.Point(60, 255);

            this.txtUsuario.Size =
                new System.Drawing.Size(350, 34);

            // =====================================
            // CLAVE
            // =====================================

            this.lblClave.AutoSize = true;

            this.lblClave.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold);

            this.lblClave.Location =
                new System.Drawing.Point(55, 320);

            this.lblClave.Text =
                "Contraseña";

            this.txtClave.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F);

            this.txtClave.Location =
                new System.Drawing.Point(60, 355);

            this.txtClave.Size =
                new System.Drawing.Size(350, 34);

            this.txtClave.UseSystemPasswordChar =
                true;

            // =====================================
            // CONFIRMAR
            // =====================================

            this.lblConfirmar.AutoSize = true;

            this.lblConfirmar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold);

            this.lblConfirmar.Location =
                new System.Drawing.Point(55, 420);

            this.lblConfirmar.Text =
                "Confirmar Contraseña";

            this.txtConfirmar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F);

            this.txtConfirmar.Location =
                new System.Drawing.Point(60, 455);

            this.txtConfirmar.Size =
                new System.Drawing.Size(350, 34);

            this.txtConfirmar.UseSystemPasswordChar =
                true;

            // =====================================
            // ROLES
            // =====================================

            this.lblRol.AutoSize = true;

            this.lblRol.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold);

            this.lblRol.Location =
                new System.Drawing.Point(55, 520);

            this.lblRol.Text =
                "Rol";

            this.cboRoles.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F);

            this.cboRoles.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cboRoles.Location =
                new System.Drawing.Point(60, 555);

            this.cboRoles.Size =
                new System.Drawing.Size(350, 36);

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
                new System.Drawing.Point(60, 620);

            this.chkEstado.Text =
                "Usuario Activo";

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
                new System.Drawing.Point(60, 690);

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
                new System.Drawing.Point(250, 690);

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
                new System.Drawing.Point(60, 765);

            this.btnEditar.Size =
                new System.Drawing.Size(160, 55);

            this.btnEditar.Text =
                " Editar";

            this.btnEditar.TextImageRelation =
                System.Windows.Forms.TextImageRelation.ImageBeforeText;

            // =====================================

            this.btnEliminar.BackColor =
                System.Drawing.Color.FromArgb(
                    239,
                    68,
                    68);

            this.btnEliminar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnEliminar.FlatAppearance.BorderSize = 0;

            this.btnEliminar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold);

            this.btnEliminar.ForeColor =
                System.Drawing.Color.White;

            this.btnEliminar.IconChar =
                FontAwesome.Sharp.IconChar.Trash;

            this.btnEliminar.IconColor =
                System.Drawing.Color.White;

            this.btnEliminar.IconFont =
                FontAwesome.Sharp.IconFont.Auto;

            this.btnEliminar.Location =
                new System.Drawing.Point(250, 765);

            this.btnEliminar.Size =
                new System.Drawing.Size(160, 55);

            this.btnEliminar.Text =
                " Eliminar";

            this.btnEliminar.TextImageRelation =
                System.Windows.Forms.TextImageRelation.ImageBeforeText;

            // =====================================
            // DATAGRID
            // =====================================

            this.dgvUsuarios.AllowUserToAddRows =
                false;

            this.dgvUsuarios.AllowUserToDeleteRows =
                false;

            this.dgvUsuarios.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvUsuarios.BackgroundColor =
                System.Drawing.Color.White;

            this.dgvUsuarios.BorderStyle =
                System.Windows.Forms.BorderStyle.None;

            this.dgvUsuarios.ColumnHeadersHeight = 40;

            this.dgvUsuarios.Location =
                new System.Drawing.Point(500, 110);

            this.dgvUsuarios.MultiSelect = false;

            this.dgvUsuarios.ReadOnly = true;

            this.dgvUsuarios.RowHeadersVisible = false;

            this.dgvUsuarios.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvUsuarios.Size =
                new System.Drawing.Size(850, 710);

            // =====================================
            // ADD CONTROLS
            // =====================================

            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblClave);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.lblConfirmar);
            this.Controls.Add(this.txtConfirmar);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.cboRoles);
            this.Controls.Add(this.chkEstado);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvUsuarios);

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvUsuarios)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label lblConfirmar;
        private System.Windows.Forms.TextBox txtConfirmar;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.ComboBox cboRoles;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.DataGridView dgvUsuarios;

        private FontAwesome.Sharp.IconButton btnNuevo;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnEditar;
        private FontAwesome.Sharp.IconButton btnEliminar;
    }
}