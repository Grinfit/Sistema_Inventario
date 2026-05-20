namespace Sistema_Inventario.Presentacion
{
    // CLASE PARCIAL DEL FORMULARIO DE ROLES
    partial class FrmRoles
    {
        // CONTENEDOR DE COMPONENTES DEL FORMULARIO
        private System.ComponentModel.IContainer components = null;

        // METODO PARA LIBERAR RECURSOS UTILIZADOS
        protected override void Dispose(
            bool disposing)
        {
            // VERIFICA SI SE DEBEN LIBERAR LOS RECURSOS
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

        // METODO DONDE SE INICIALIZAN LOS COMPONENTES DEL FORMULARIO
        private void InitializeComponent()
        {
            // CREACION DEL LABEL DEL TITULO
            this.lblTitulo = new System.Windows.Forms.Label();

            // CREACION DEL LABEL DEL NOMBRE
            this.lblNombre = new System.Windows.Forms.Label();

            // CREACION DEL TEXTBOX DEL NOMBRE
            this.txtNombre = new System.Windows.Forms.TextBox();

            // CREACION DEL CHECKBOX DEL ESTADO
            this.chkEstado = new System.Windows.Forms.CheckBox();

            // CREACION DEL LABEL DE PERMISOS
            this.lblPermisos = new System.Windows.Forms.Label();

            // CREACION DEL CHECKEDLISTBOX DE PERMISOS
            this.clbPermisos = new System.Windows.Forms.CheckedListBox();

            // CREACION DEL DATAGRIDVIEW DE ROLES
            this.dgvRoles = new System.Windows.Forms.DataGridView();

            // CREACION DEL BOTON NUEVO
            this.btnNuevo = new FontAwesome.Sharp.IconButton();

            // CREACION DEL BOTON GUARDAR
            this.btnGuardar = new FontAwesome.Sharp.IconButton();

            // CREACION DEL BOTON EDITAR
            this.btnEditar = new FontAwesome.Sharp.IconButton();

            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.SuspendLayout();

            // 
            // lblTitulo
            // 

            // CONFIGURACION AUTOMATICA DEL TAMAÑO
            this.lblTitulo.AutoSize = true;

            // CONFIGURACION DE LA FUENTE
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);

            // CONFIGURACION DEL COLOR DEL TEXTO
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(31)))), ((int)(((byte)(58)))));

            // POSICION DEL LABEL
            this.lblTitulo.Location = new System.Drawing.Point(40, 25);

            // NOMBRE DEL CONTROL
            this.lblTitulo.Name = "lblTitulo";

            // TAMAÑO DEL CONTROL
            this.lblTitulo.Size = new System.Drawing.Size(392, 62);

            // TAB INDEX
            this.lblTitulo.TabIndex = 0;

            // TEXTO DEL LABEL
            this.lblTitulo.Text = "Gestión de Roles";

            // 
            // lblNombre
            // 

            // CONFIGURACION AUTOMATICA DEL TAMAÑO
            this.lblNombre.AutoSize = true;

            // CONFIGURACION DE LA FUENTE
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);

            // POSICION DEL LABEL
            this.lblNombre.Location = new System.Drawing.Point(50, 120);

            // NOMBRE DEL CONTROL
            this.lblNombre.Name = "lblNombre";

            // TAMAÑO DEL CONTROL
            this.lblNombre.Size = new System.Drawing.Size(161, 28);

            // TAB INDEX
            this.lblNombre.TabIndex = 1;

            // TEXTO DEL LABEL
            this.lblNombre.Text = "Nombre del Rol";

            // 
            // txtNombre
            // 

            // CONFIGURACION DE LA FUENTE
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 12F);

            // POSICION DEL TEXTBOX
            this.txtNombre.Location = new System.Drawing.Point(55, 155);

            // NOMBRE DEL CONTROL
            this.txtNombre.Name = "txtNombre";

            // TAMAÑO DEL CONTROL
            this.txtNombre.Size = new System.Drawing.Size(350, 34);

            // TAB INDEX
            this.txtNombre.TabIndex = 2;

            // 
            // chkEstado
            // 

            // ACTIVA EL CHECKBOX POR DEFECTO
            this.chkEstado.AutoSize = true;

            // ESTADO MARCADO
            this.chkEstado.Checked = true;

            // CONFIGURACION DEL CHECKSTATE
            this.chkEstado.CheckState = System.Windows.Forms.CheckState.Checked;

            // CONFIGURACION DE LA FUENTE
            this.chkEstado.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);

            // POSICION DEL CHECKBOX
            this.chkEstado.Location = new System.Drawing.Point(55, 215);

            // NOMBRE DEL CONTROL
            this.chkEstado.Name = "chkEstado";

            // TAMAÑO DEL CONTROL
            this.chkEstado.Size = new System.Drawing.Size(124, 29);

            // TAB INDEX
            this.chkEstado.TabIndex = 3;

            // TEXTO DEL CHECKBOX
            this.chkEstado.Text = "Rol Activo";

            // 
            // lblPermisos
            // 

            // CONFIGURACION AUTOMATICA DEL TAMAÑO
            this.lblPermisos.AutoSize = true;

            // CONFIGURACION DE LA FUENTE
            this.lblPermisos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);

            // POSICION DEL LABEL
            this.lblPermisos.Location = new System.Drawing.Point(50, 270);

            // NOMBRE DEL CONTROL
            this.lblPermisos.Name = "lblPermisos";

            // TAMAÑO DEL CONTROL
            this.lblPermisos.Size = new System.Drawing.Size(168, 28);

            // TAB INDEX
            this.lblPermisos.TabIndex = 4;

            // TEXTO DEL LABEL
            this.lblPermisos.Text = "Permisos del Rol";

            // 
            // clbPermisos
            // 

            // CONFIGURACION DE LA FUENTE
            this.clbPermisos.Font = new System.Drawing.Font("Segoe UI", 11F);

            // HABILITA EL FORMATO
            this.clbPermisos.FormattingEnabled = true;

            // POSICION DEL CONTROL
            this.clbPermisos.Location = new System.Drawing.Point(55, 305);

            // NOMBRE DEL CONTROL
            this.clbPermisos.Name = "clbPermisos";

            // TAMAÑO DEL CONTROL
            this.clbPermisos.Size = new System.Drawing.Size(420, 382);

            // TAB INDEX
            this.clbPermisos.TabIndex = 5;

            // 
            // dgvRoles
            // 

            // DESHABILITA AGREGAR FILAS
            this.dgvRoles.AllowUserToAddRows = false;

            // DESHABILITA ELIMINAR FILAS
            this.dgvRoles.AllowUserToDeleteRows = false;

            // AJUSTE AUTOMATICO DE COLUMNAS
            this.dgvRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // COLOR DE FONDO
            this.dgvRoles.BackgroundColor = System.Drawing.Color.White;

            // ESTILO DEL BORDE
            this.dgvRoles.BorderStyle = System.Windows.Forms.BorderStyle.None;

            // ALTURA DE CABECERAS
            this.dgvRoles.ColumnHeadersHeight = 40;

            // POSICION DEL DATAGRIDVIEW
            this.dgvRoles.Location = new System.Drawing.Point(550, 120);

            // DESHABILITA MULTISELECCION
            this.dgvRoles.MultiSelect = false;

            // NOMBRE DEL CONTROL
            this.dgvRoles.Name = "dgvRoles";

            // SOLO LECTURA
            this.dgvRoles.ReadOnly = true;

            // OCULTA LOS HEADERS DE FILAS
            this.dgvRoles.RowHeadersVisible = false;

            // ANCHO DE LOS HEADERS
            this.dgvRoles.RowHeadersWidth = 51;

            // MODO DE SELECCION
            this.dgvRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // TAMAÑO DEL CONTROL
            this.dgvRoles.Size = new System.Drawing.Size(840, 675);

            // TAB INDEX
            this.dgvRoles.TabIndex = 6;

            // EVENTO CLICK DEL DATAGRIDVIEW
            this.dgvRoles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoles_CellContentClick);

            // 
            // btnNuevo
            // 

            // COLOR DE FONDO DEL BOTON
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));

            // ELIMINA EL BORDE
            this.btnNuevo.FlatAppearance.BorderSize = 0;

            // ESTILO FLAT
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // CONFIGURACION DE LA FUENTE
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);

            // COLOR DEL TEXTO
            this.btnNuevo.ForeColor = System.Drawing.Color.White;

            // ICONO DEL BOTON
            this.btnNuevo.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;

            // COLOR DEL ICONO
            this.btnNuevo.IconColor = System.Drawing.Color.White;

            // FUENTE DEL ICONO
            this.btnNuevo.IconFont = FontAwesome.Sharp.IconFont.Auto;

            // POSICION DEL BOTON
            this.btnNuevo.Location = new System.Drawing.Point(55, 740);

            // NOMBRE DEL CONTROL
            this.btnNuevo.Name = "btnNuevo";

            // TAMAÑO DEL CONTROL
            this.btnNuevo.Size = new System.Drawing.Size(160, 55);

            // TAB INDEX
            this.btnNuevo.TabIndex = 7;

            // TEXTO DEL BOTON
            this.btnNuevo.Text = " Nuevo";

            // RELACION ENTRE TEXTO E IMAGEN
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;

            // CONFIGURACION VISUAL
            this.btnNuevo.UseVisualStyleBackColor = false;

            // 
            // btnGuardar
            // 

            // COLOR DE FONDO DEL BOTON
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));

            // ELIMINA EL BORDE
            this.btnGuardar.FlatAppearance.BorderSize = 0;

            // ESTILO FLAT
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // CONFIGURACION DE LA FUENTE
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);

            // COLOR DEL TEXTO
            this.btnGuardar.ForeColor = System.Drawing.Color.White;

            // ICONO DEL BOTON
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;

            // COLOR DEL ICONO
            this.btnGuardar.IconColor = System.Drawing.Color.White;

            // FUENTE DEL ICONO
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;

            // POSICION DEL BOTON
            this.btnGuardar.Location = new System.Drawing.Point(240, 740);

            // NOMBRE DEL CONTROL
            this.btnGuardar.Name = "btnGuardar";

            // TAMAÑO DEL CONTROL
            this.btnGuardar.Size = new System.Drawing.Size(160, 55);

            // TAB INDEX
            this.btnGuardar.TabIndex = 8;

            // TEXTO DEL BOTON
            this.btnGuardar.Text = " Guardar";

            // RELACION ENTRE TEXTO E IMAGEN
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;

            // CONFIGURACION VISUAL
            this.btnGuardar.UseVisualStyleBackColor = false;

            // 
            // btnEditar
            // 

            // COLOR DE FONDO DEL BOTON
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(179)))), ((int)(((byte)(8)))));

            // ELIMINA EL BORDE
            this.btnEditar.FlatAppearance.BorderSize = 0;

            // ESTILO FLAT
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // CONFIGURACION DE LA FUENTE
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);

            // COLOR DEL TEXTO
            this.btnEditar.ForeColor = System.Drawing.Color.White;

            // ICONO DEL BOTON
            this.btnEditar.IconChar = FontAwesome.Sharp.IconChar.Edit;

            // COLOR DEL ICONO
            this.btnEditar.IconColor = System.Drawing.Color.White;

            // FUENTE DEL ICONO
            this.btnEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;

            // POSICION DEL BOTON
            this.btnEditar.Location = new System.Drawing.Point(425, 740);

            // NOMBRE DEL CONTROL
            this.btnEditar.Name = "btnEditar";

            // TAMAÑO DEL CONTROL
            this.btnEditar.Size = new System.Drawing.Size(160, 55);

            // TAB INDEX
            this.btnEditar.TabIndex = 9;

            // TEXTO DEL BOTON
            this.btnEditar.Text = " Editar";

            // RELACION ENTRE TEXTO E IMAGEN
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;

            // CONFIGURACION VISUAL
            this.btnEditar.UseVisualStyleBackColor = false;

            // 
            // FrmRoles
            // 

            // COLOR DE FONDO DEL FORMULARIO
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));

            // TAMAÑO DEL FORMULARIO
            this.ClientSize = new System.Drawing.Size(1450, 850);

            // AGREGAR CONTROLES AL FORMULARIO
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

            // NOMBRE DEL FORMULARIO
            this.Name = "FrmRoles";

            // TITULO DEL FORMULARIO
            this.Text = "Roles";

            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // DECLARACION DEL LABEL TITULO
        private System.Windows.Forms.Label lblTitulo;

        // DECLARACION DEL LABEL NOMBRE
        private System.Windows.Forms.Label lblNombre;

        // DECLARACION DEL TEXTBOX NOMBRE
        private System.Windows.Forms.TextBox txtNombre;

        // DECLARACION DEL CHECKBOX ESTADO
        private System.Windows.Forms.CheckBox chkEstado;

        // DECLARACION DEL LABEL PERMISOS
        private System.Windows.Forms.Label lblPermisos;

        // DECLARACION DEL CHECKEDLISTBOX PERMISOS
        private System.Windows.Forms.CheckedListBox clbPermisos;

        // DECLARACION DEL DATAGRIDVIEW ROLES
        private System.Windows.Forms.DataGridView dgvRoles;

        // DECLARACION DEL BOTON NUEVO
        private FontAwesome.Sharp.IconButton btnNuevo;

        // DECLARACION DEL BOTON GUARDAR
        private FontAwesome.Sharp.IconButton btnGuardar;

        // DECLARACION DEL BOTON EDITAR
        private FontAwesome.Sharp.IconButton btnEditar;
    }
}