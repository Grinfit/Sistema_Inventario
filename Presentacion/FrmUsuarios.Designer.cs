namespace Sistema_Inventario.Presentacion
{
    // CLASE PARCIAL DEL FORMULARIO DE USUARIOS
    partial class FrmUsuarios
    {
        // CONTENEDOR DE COMPONENTES DEL FORMULARIO
        private System.ComponentModel.IContainer components = null;

        // METODO PARA LIBERAR RECURSOS
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

        #region Código generado por el Diseñador

        // METODO DONDE SE INICIALIZAN LOS COMPONENTES
        private void InitializeComponent()
        {
            // CREACION DEL LABEL TITULO
            this.lblTitulo =
                new System.Windows.Forms.Label();

            // CREACION DEL LABEL BUSCAR
            this.lblBuscar =
                new System.Windows.Forms.Label();

            // CREACION DEL TEXTBOX BUSCAR
            this.txtBuscar =
                new System.Windows.Forms.TextBox();

            // CREACION DEL LABEL USUARIO
            this.lblUsuario =
                new System.Windows.Forms.Label();

            // CREACION DEL TEXTBOX USUARIO
            this.txtUsuario =
                new System.Windows.Forms.TextBox();

            // CREACION DEL LABEL CLAVE
            this.lblClave =
                new System.Windows.Forms.Label();

            // CREACION DEL TEXTBOX CLAVE
            this.txtClave =
                new System.Windows.Forms.TextBox();

            // CREACION DEL LABEL CONFIRMAR
            this.lblConfirmar =
                new System.Windows.Forms.Label();

            // CREACION DEL TEXTBOX CONFIRMAR
            this.txtConfirmar =
                new System.Windows.Forms.TextBox();

            // CREACION DEL LABEL ROL
            this.lblRol =
                new System.Windows.Forms.Label();

            // CREACION DEL COMBOBOX ROLES
            this.cboRoles =
                new System.Windows.Forms.ComboBox();

            // CREACION DEL CHECKBOX ESTADO
            this.chkEstado =
                new System.Windows.Forms.CheckBox();

            // CREACION DEL DATAGRIDVIEW
            this.dgvUsuarios =
                new System.Windows.Forms.DataGridView();

            // CREACION DEL BOTON NUEVO
            this.btnNuevo =
                new FontAwesome.Sharp.IconButton();

            // CREACION DEL BOTON GUARDAR
            this.btnGuardar =
                new FontAwesome.Sharp.IconButton();

            // CREACION DEL BOTON EDITAR
            this.btnEditar =
                new FontAwesome.Sharp.IconButton();

            // CREACION DEL BOTON ELIMINAR
            this.btnEliminar =
                new FontAwesome.Sharp.IconButton();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvUsuarios)).BeginInit();

            this.SuspendLayout();

            // =====================================
            // FORM
            // =====================================

            // COLOR DE FONDO DEL FORMULARIO
            this.BackColor =
                System.Drawing.Color.FromArgb(
                    243,
                    244,
                    246);

            // TAMAÑO DEL FORMULARIO
            this.ClientSize =
                new System.Drawing.Size(1400, 850);

            // TITULO DEL FORMULARIO
            this.Text =
                "Usuarios";

            // =====================================
            // TITULO
            // =====================================

            // AJUSTE AUTOMATICO DEL LABEL
            this.lblTitulo.AutoSize = true;

            // CONFIGURACION DE FUENTE
            this.lblTitulo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    28F,
                    System.Drawing.FontStyle.Bold);

            // COLOR DEL TEXTO
            this.lblTitulo.ForeColor =
                System.Drawing.Color.FromArgb(
                    11,
                    31,
                    58);

            // POSICION DEL LABEL
            this.lblTitulo.Location =
                new System.Drawing.Point(45, 25);

            // TEXTO DEL LABEL
            this.lblTitulo.Text =
                "Gestión de Usuarios";

            // =====================================
            // BUSCAR
            // =====================================

            // AJUSTE AUTOMATICO DEL LABEL
            this.lblBuscar.AutoSize = true;

            // CONFIGURACION DE FUENTE
            this.lblBuscar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold);

            // POSICION DEL LABEL
            this.lblBuscar.Location =
                new System.Drawing.Point(55, 110);

            // TEXTO DEL LABEL
            this.lblBuscar.Text =
                "Buscar Usuario";

            // CONFIGURACION DE FUENTE
            this.txtBuscar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F);

            // POSICION DEL TEXTBOX
            this.txtBuscar.Location =
                new System.Drawing.Point(60, 145);

            // TAMAÑO DEL TEXTBOX
            this.txtBuscar.Size =
                new System.Drawing.Size(350, 34);

            // =====================================
            // USUARIO
            // =====================================

            // AJUSTE AUTOMATICO DEL LABEL
            this.lblUsuario.AutoSize = true;

            // CONFIGURACION DE FUENTE
            this.lblUsuario.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold);

            // POSICION DEL LABEL
            this.lblUsuario.Location =
                new System.Drawing.Point(55, 220);

            // TEXTO DEL LABEL
            this.lblUsuario.Text =
                "Usuario";

            // CONFIGURACION DE FUENTE
            this.txtUsuario.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F);

            // POSICION DEL TEXTBOX
            this.txtUsuario.Location =
                new System.Drawing.Point(60, 255);

            // TAMAÑO DEL TEXTBOX
            this.txtUsuario.Size =
                new System.Drawing.Size(350, 34);

            // =====================================
            // CLAVE
            // =====================================

            // AJUSTE AUTOMATICO DEL LABEL
            this.lblClave.AutoSize = true;

            // CONFIGURACION DE FUENTE
            this.lblClave.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold);

            // POSICION DEL LABEL
            this.lblClave.Location =
                new System.Drawing.Point(55, 320);

            // TEXTO DEL LABEL
            this.lblClave.Text =
                "Contraseña";

            // CONFIGURACION DE FUENTE
            this.txtClave.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F);

            // POSICION DEL TEXTBOX
            this.txtClave.Location =
                new System.Drawing.Point(60, 355);

            // TAMAÑO DEL TEXTBOX
            this.txtClave.Size =
                new System.Drawing.Size(350, 34);

            // OCULTA LA CONTRASEÑA
            this.txtClave.UseSystemPasswordChar =
                true;

            // =====================================
            // CONFIRMAR
            // =====================================

            // AJUSTE AUTOMATICO DEL LABEL
            this.lblConfirmar.AutoSize = true;

            // CONFIGURACION DE FUENTE
            this.lblConfirmar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold);

            // POSICION DEL LABEL
            this.lblConfirmar.Location =
                new System.Drawing.Point(55, 420);

            // TEXTO DEL LABEL
            this.lblConfirmar.Text =
                "Confirmar Contraseña";

            // CONFIGURACION DE FUENTE
            this.txtConfirmar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F);

            // POSICION DEL TEXTBOX
            this.txtConfirmar.Location =
                new System.Drawing.Point(60, 455);

            // TAMAÑO DEL TEXTBOX
            this.txtConfirmar.Size =
                new System.Drawing.Size(350, 34);

            // OCULTA LA CONTRASEÑA
            this.txtConfirmar.UseSystemPasswordChar =
                true;

            // =====================================
            // ROLES
            // =====================================

            // AJUSTE AUTOMATICO DEL LABEL
            this.lblRol.AutoSize = true;

            // CONFIGURACION DE FUENTE
            this.lblRol.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold);

            // POSICION DEL LABEL
            this.lblRol.Location =
                new System.Drawing.Point(55, 520);

            // TEXTO DEL LABEL
            this.lblRol.Text =
                "Rol";

            // CONFIGURACION DE FUENTE
            this.cboRoles.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F);

            // CONFIGURA EL ESTILO DEL COMBOBOX
            this.cboRoles.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            // POSICION DEL COMBOBOX
            this.cboRoles.Location =
                new System.Drawing.Point(60, 555);

            // TAMAÑO DEL COMBOBOX
            this.cboRoles.Size =
                new System.Drawing.Size(350, 36);

            // =====================================
            // ESTADO
            // =====================================

            // AJUSTE AUTOMATICO DEL CHECKBOX
            this.chkEstado.AutoSize = true;

            // ACTIVA EL CHECKBOX
            this.chkEstado.Checked = true;

            // ESTADO MARCADO
            this.chkEstado.CheckState =
                System.Windows.Forms.CheckState.Checked;

            // CONFIGURACION DE FUENTE
            this.chkEstado.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold);

            // POSICION DEL CHECKBOX
            this.chkEstado.Location =
                new System.Drawing.Point(60, 620);

            // TEXTO DEL CHECKBOX
            this.chkEstado.Text =
                "Usuario Activo";

            // =====================================
            // BOTONES
            // =====================================

            // COLOR DE FONDO DEL BOTON NUEVO
            this.btnNuevo.BackColor =
                System.Drawing.Color.FromArgb(
                    59,
                    130,
                    246);

            // ESTILO FLAT
            this.btnNuevo.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            // ELIMINA EL BORDE
            this.btnNuevo.FlatAppearance.BorderSize = 0;

            // CONFIGURACION DE FUENTE
            this.btnNuevo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold);

            // COLOR DEL TEXTO
            this.btnNuevo.ForeColor =
                System.Drawing.Color.White;

            // CONFIGURACION DEL ICONO
            this.btnNuevo.IconChar =
                FontAwesome.Sharp.IconChar.PlusCircle;

            // COLOR DEL ICONO
            this.btnNuevo.IconColor =
                System.Drawing.Color.White;

            // FUENTE DEL ICONO
            this.btnNuevo.IconFont =
                FontAwesome.Sharp.IconFont.Auto;

            // POSICION DEL BOTON
            this.btnNuevo.Location =
                new System.Drawing.Point(60, 690);

            // TAMAÑO DEL BOTON
            this.btnNuevo.Size =
                new System.Drawing.Size(160, 55);

            // TEXTO DEL BOTON
            this.btnNuevo.Text =
                " Nuevo";

            // RELACION ENTRE TEXTO E IMAGEN
            this.btnNuevo.TextImageRelation =
                System.Windows.Forms.TextImageRelation.ImageBeforeText;

            // =====================================

            // COLOR DE FONDO DEL BOTON GUARDAR
            this.btnGuardar.BackColor =
                System.Drawing.Color.FromArgb(
                    34,
                    197,
                    94);

            // ESTILO FLAT
            this.btnGuardar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            // ELIMINA EL BORDE
            this.btnGuardar.FlatAppearance.BorderSize = 0;

            // CONFIGURACION DE FUENTE
            this.btnGuardar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold);

            // COLOR DEL TEXTO
            this.btnGuardar.ForeColor =
                System.Drawing.Color.White;

            // CONFIGURACION DEL ICONO
            this.btnGuardar.IconChar =
                FontAwesome.Sharp.IconChar.FloppyDisk;

            // COLOR DEL ICONO
            this.btnGuardar.IconColor =
                System.Drawing.Color.White;

            // FUENTE DEL ICONO
            this.btnGuardar.IconFont =
                FontAwesome.Sharp.IconFont.Auto;

            // POSICION DEL BOTON
            this.btnGuardar.Location =
                new System.Drawing.Point(250, 690);

            // TAMAÑO DEL BOTON
            this.btnGuardar.Size =
                new System.Drawing.Size(160, 55);

            // TEXTO DEL BOTON
            this.btnGuardar.Text =
                " Guardar";

            // RELACION ENTRE TEXTO E IMAGEN
            this.btnGuardar.TextImageRelation =
                System.Windows.Forms.TextImageRelation.ImageBeforeText;

            // =====================================

            // COLOR DE FONDO DEL BOTON EDITAR
            this.btnEditar.BackColor =
                System.Drawing.Color.FromArgb(
                    234,
                    179,
                    8);

            // ESTILO FLAT
            this.btnEditar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            // ELIMINA EL BORDE
            this.btnEditar.FlatAppearance.BorderSize = 0;

            // CONFIGURACION DE FUENTE
            this.btnEditar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold);

            // COLOR DEL TEXTO
            this.btnEditar.ForeColor =
                System.Drawing.Color.White;

            // CONFIGURACION DEL ICONO
            this.btnEditar.IconChar =
                FontAwesome.Sharp.IconChar.PenToSquare;

            // COLOR DEL ICONO
            this.btnEditar.IconColor =
                System.Drawing.Color.White;

            // FUENTE DEL ICONO
            this.btnEditar.IconFont =
                FontAwesome.Sharp.IconFont.Auto;

            // POSICION DEL BOTON
            this.btnEditar.Location =
                new System.Drawing.Point(60, 765);

            // TAMAÑO DEL BOTON
            this.btnEditar.Size =
                new System.Drawing.Size(160, 55);

            // TEXTO DEL BOTON
            this.btnEditar.Text =
                " Editar";

            // RELACION ENTRE TEXTO E IMAGEN
            this.btnEditar.TextImageRelation =
                System.Windows.Forms.TextImageRelation.ImageBeforeText;

            // =====================================

            // COLOR DE FONDO DEL BOTON ELIMINAR
            this.btnEliminar.BackColor =
                System.Drawing.Color.FromArgb(
                    239,
                    68,
                    68);

            // ESTILO FLAT
            this.btnEliminar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            // ELIMINA EL BORDE
            this.btnEliminar.FlatAppearance.BorderSize = 0;

            // CONFIGURACION DE FUENTE
            this.btnEliminar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold);

            // COLOR DEL TEXTO
            this.btnEliminar.ForeColor =
                System.Drawing.Color.White;

            // CONFIGURACION DEL ICONO
            this.btnEliminar.IconChar =
                FontAwesome.Sharp.IconChar.Trash;

            // COLOR DEL ICONO
            this.btnEliminar.IconColor =
                System.Drawing.Color.White;

            // FUENTE DEL ICONO
            this.btnEliminar.IconFont =
                FontAwesome.Sharp.IconFont.Auto;

            // POSICION DEL BOTON
            this.btnEliminar.Location =
                new System.Drawing.Point(250, 765);

            // TAMAÑO DEL BOTON
            this.btnEliminar.Size =
                new System.Drawing.Size(160, 55);

            // TEXTO DEL BOTON
            this.btnEliminar.Text =
                " Eliminar";

            // RELACION ENTRE TEXTO E IMAGEN
            this.btnEliminar.TextImageRelation =
                System.Windows.Forms.TextImageRelation.ImageBeforeText;

            // =====================================
            // DATAGRID
            // =====================================

            // DESHABILITA AGREGAR FILAS
            this.dgvUsuarios.AllowUserToAddRows =
                false;

            // DESHABILITA ELIMINAR FILAS
            this.dgvUsuarios.AllowUserToDeleteRows =
                false;

            // AJUSTE AUTOMATICO DE COLUMNAS
            this.dgvUsuarios.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // COLOR DE FONDO DEL GRID
            this.dgvUsuarios.BackgroundColor =
                System.Drawing.Color.White;

            // ESTILO DEL BORDE
            this.dgvUsuarios.BorderStyle =
                System.Windows.Forms.BorderStyle.None;

            // ALTURA DEL HEADER
            this.dgvUsuarios.ColumnHeadersHeight = 40;

            // POSICION DEL GRID
            this.dgvUsuarios.Location =
                new System.Drawing.Point(500, 110);

            // DESHABILITA MULTISELECCION
            this.dgvUsuarios.MultiSelect = false;

            // SOLO LECTURA
            this.dgvUsuarios.ReadOnly = true;

            // OCULTA HEADERS DE FILAS
            this.dgvUsuarios.RowHeadersVisible = false;

            // SELECCION COMPLETA DE FILA
            this.dgvUsuarios.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // TAMAÑO DEL GRID
            this.dgvUsuarios.Size =
                new System.Drawing.Size(850, 710);

            // =====================================
            // ADD CONTROLS
            // =====================================

            // AGREGA CONTROLES AL FORMULARIO
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

        // DECLARACION DE CONTROLES
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

        // DECLARACION DE BOTONES
        private FontAwesome.Sharp.IconButton btnNuevo;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnEditar;
        private FontAwesome.Sharp.IconButton btnEliminar;
    }
}