// IMPORTACION DE LIBRERIAS NECESARIAS
using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Inventario.Presentacion
{
    // CLASE PARCIAL DEL FORMULARIO DE USUARIOS
    partial class FrmUsuarios
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
            this.lblTitulo      = new System.Windows.Forms.Label();
            this.lblSubtitulo   = new System.Windows.Forms.Label();
            this.pnlSep1        = new System.Windows.Forms.Panel();
            this.pnlCard1       = new System.Windows.Forms.Panel();
            this.lblCard1Titulo = new System.Windows.Forms.Label();
            this.lblCard1Valor  = new System.Windows.Forms.Label();
            this.pnlCard2       = new System.Windows.Forms.Panel();
            this.lblCard2Titulo = new System.Windows.Forms.Label();
            this.lblCard2Valor  = new System.Windows.Forms.Label();
            this.pnlCard3       = new System.Windows.Forms.Panel();
            this.lblCard3Titulo = new System.Windows.Forms.Label();
            this.lblCard3Valor  = new System.Windows.Forms.Label();
            this.pnlSep2        = new System.Windows.Forms.Panel();
            this.txtBuscar      = new System.Windows.Forms.TextBox();
            this.btnNuevo       = new FontAwesome.Sharp.IconButton();
            this.btnEditar      = new FontAwesome.Sharp.IconButton();
            this.btnEliminar    = new FontAwesome.Sharp.IconButton();
            this.btnActualizar  = new FontAwesome.Sharp.IconButton();
            this.dgvUsuarios    = new System.Windows.Forms.DataGridView();
            this.lblResumen     = new System.Windows.Forms.Label();
            this.pnlCard1.SuspendLayout();
            this.pnlCard2.SuspendLayout();
            this.pnlCard3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();

            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize  = true;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(35)))), ((int)(((byte)(66)))));
            this.lblTitulo.Location  = new System.Drawing.Point(50, 22);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.TabIndex  = 0;
            this.lblTitulo.Text      = "Usuarios";

            //
            // lblSubtitulo
            //
            this.lblSubtitulo.AutoSize  = true;
            this.lblSubtitulo.Font      = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblSubtitulo.Location  = new System.Drawing.Point(52, 70);
            this.lblSubtitulo.Name      = "lblSubtitulo";
            this.lblSubtitulo.TabIndex  = 1;
            this.lblSubtitulo.Text      = "Gestión de usuarios del sistema";

            //
            // pnlSep1
            //
            this.pnlSep1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(35)))), ((int)(((byte)(66)))));
            this.pnlSep1.Location  = new System.Drawing.Point(30, 100);
            this.pnlSep1.Name      = "pnlSep1";
            this.pnlSep1.Size      = new System.Drawing.Size(1290, 2);
            this.pnlSep1.TabIndex  = 2;

            //
            // pnlCard1  —  Usuarios Activos (azul)
            //
            this.pnlCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.pnlCard1.Controls.Add(this.lblCard1Titulo);
            this.pnlCard1.Controls.Add(this.lblCard1Valor);
            this.pnlCard1.Location  = new System.Drawing.Point(30, 112);
            this.pnlCard1.Name      = "pnlCard1";
            this.pnlCard1.Size      = new System.Drawing.Size(390, 68);
            this.pnlCard1.TabIndex  = 3;

            this.lblCard1Titulo.AutoSize  = true;
            this.lblCard1Titulo.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCard1Titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lblCard1Titulo.Location  = new System.Drawing.Point(14, 8);
            this.lblCard1Titulo.Name      = "lblCard1Titulo";
            this.lblCard1Titulo.TabIndex  = 0;
            this.lblCard1Titulo.Text      = "Usuarios Activos";

            this.lblCard1Valor.AutoSize  = true;
            this.lblCard1Valor.Font      = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblCard1Valor.ForeColor = System.Drawing.Color.White;
            this.lblCard1Valor.Location  = new System.Drawing.Point(12, 24);
            this.lblCard1Valor.Name      = "lblCard1Valor";
            this.lblCard1Valor.TabIndex  = 1;
            this.lblCard1Valor.Text      = "0";

            //
            // pnlCard2  —  Administradores (morado)
            //
            this.pnlCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.pnlCard2.Controls.Add(this.lblCard2Titulo);
            this.pnlCard2.Controls.Add(this.lblCard2Valor);
            this.pnlCard2.Location  = new System.Drawing.Point(440, 112);
            this.pnlCard2.Name      = "pnlCard2";
            this.pnlCard2.Size      = new System.Drawing.Size(390, 68);
            this.pnlCard2.TabIndex  = 4;

            this.lblCard2Titulo.AutoSize  = true;
            this.lblCard2Titulo.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCard2Titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.lblCard2Titulo.Location  = new System.Drawing.Point(14, 8);
            this.lblCard2Titulo.Name      = "lblCard2Titulo";
            this.lblCard2Titulo.TabIndex  = 0;
            this.lblCard2Titulo.Text      = "Administradores";

            this.lblCard2Valor.AutoSize  = true;
            this.lblCard2Valor.Font      = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblCard2Valor.ForeColor = System.Drawing.Color.White;
            this.lblCard2Valor.Location  = new System.Drawing.Point(12, 24);
            this.lblCard2Valor.Name      = "lblCard2Valor";
            this.lblCard2Valor.TabIndex  = 1;
            this.lblCard2Valor.Text      = "0";

            //
            // pnlCard3  —  Inactivos (rojo)
            //
            this.pnlCard3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.pnlCard3.Controls.Add(this.lblCard3Titulo);
            this.pnlCard3.Controls.Add(this.lblCard3Valor);
            this.pnlCard3.Location  = new System.Drawing.Point(850, 112);
            this.pnlCard3.Name      = "pnlCard3";
            this.pnlCard3.Size      = new System.Drawing.Size(470, 68);
            this.pnlCard3.TabIndex  = 5;

            this.lblCard3Titulo.AutoSize  = true;
            this.lblCard3Titulo.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCard3Titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblCard3Titulo.Location  = new System.Drawing.Point(14, 8);
            this.lblCard3Titulo.Name      = "lblCard3Titulo";
            this.lblCard3Titulo.TabIndex  = 0;
            this.lblCard3Titulo.Text      = "Inactivos / Bloqueados";

            this.lblCard3Valor.AutoSize  = true;
            this.lblCard3Valor.Font      = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblCard3Valor.ForeColor = System.Drawing.Color.White;
            this.lblCard3Valor.Location  = new System.Drawing.Point(12, 24);
            this.lblCard3Valor.Name      = "lblCard3Valor";
            this.lblCard3Valor.TabIndex  = 1;
            this.lblCard3Valor.Text      = "0";

            //
            // pnlSep2
            //
            this.pnlSep2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(215)))), ((int)(((byte)(220)))));
            this.pnlSep2.Location  = new System.Drawing.Point(30, 192);
            this.pnlSep2.Name      = "pnlSep2";
            this.pnlSep2.Size      = new System.Drawing.Size(1290, 1);
            this.pnlSep2.TabIndex  = 6;

            //
            // txtBuscar
            //
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtBuscar.Location    = new System.Drawing.Point(30, 206);
            this.txtBuscar.Name        = "txtBuscar";
            this.txtBuscar.Size        = new System.Drawing.Size(330, 32);
            this.txtBuscar.TabIndex    = 7;

            //
            // btnNuevo
            //
            this.btnNuevo.BackColor                 = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnNuevo.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font                      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor                 = System.Drawing.Color.White;
            this.btnNuevo.IconChar                  = FontAwesome.Sharp.IconChar.CirclePlus;
            this.btnNuevo.IconColor                 = System.Drawing.Color.White;
            this.btnNuevo.IconFont                  = FontAwesome.Sharp.IconFont.Auto;
            this.btnNuevo.IconSize                  = 22;
            this.btnNuevo.Location                  = new System.Drawing.Point(378, 200);
            this.btnNuevo.Name                      = "btnNuevo";
            this.btnNuevo.Size                      = new System.Drawing.Size(130, 44);
            this.btnNuevo.TabIndex                  = 8;
            this.btnNuevo.Text                      = " Nuevo";
            this.btnNuevo.TextImageRelation         = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNuevo.UseVisualStyleBackColor   = false;

            //
            // btnEditar
            //
            this.btnEditar.BackColor                 = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(179)))), ((int)(((byte)(8)))));
            this.btnEditar.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font                      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor                 = System.Drawing.Color.White;
            this.btnEditar.IconChar                  = FontAwesome.Sharp.IconChar.PenToSquare;
            this.btnEditar.IconColor                 = System.Drawing.Color.White;
            this.btnEditar.IconFont                  = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditar.IconSize                  = 22;
            this.btnEditar.Location                  = new System.Drawing.Point(516, 200);
            this.btnEditar.Name                      = "btnEditar";
            this.btnEditar.Size                      = new System.Drawing.Size(130, 44);
            this.btnEditar.TabIndex                  = 9;
            this.btnEditar.Text                      = " Editar";
            this.btnEditar.TextImageRelation         = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditar.UseVisualStyleBackColor   = false;

            //
            // btnEliminar
            //
            this.btnEliminar.BackColor                 = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnEliminar.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font                      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor                 = System.Drawing.Color.White;
            this.btnEliminar.IconChar                  = FontAwesome.Sharp.IconChar.Trash;
            this.btnEliminar.IconColor                 = System.Drawing.Color.White;
            this.btnEliminar.IconFont                  = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar.IconSize                  = 22;
            this.btnEliminar.Location                  = new System.Drawing.Point(654, 200);
            this.btnEliminar.Name                      = "btnEliminar";
            this.btnEliminar.Size                      = new System.Drawing.Size(145, 44);
            this.btnEliminar.TabIndex                  = 10;
            this.btnEliminar.Text                      = " Eliminar";
            this.btnEliminar.TextImageRelation         = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor   = false;

            //
            // btnActualizar
            //
            this.btnActualizar.BackColor                 = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnActualizar.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font                      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor                 = System.Drawing.Color.White;
            this.btnActualizar.IconChar                  = FontAwesome.Sharp.IconChar.SyncAlt;
            this.btnActualizar.IconColor                 = System.Drawing.Color.White;
            this.btnActualizar.IconFont                  = FontAwesome.Sharp.IconFont.Auto;
            this.btnActualizar.IconSize                  = 22;
            this.btnActualizar.Location                  = new System.Drawing.Point(807, 200);
            this.btnActualizar.Name                      = "btnActualizar";
            this.btnActualizar.Size                      = new System.Drawing.Size(175, 44);
            this.btnActualizar.TabIndex                  = 11;
            this.btnActualizar.Text                      = " Mostrar Todo";
            this.btnActualizar.TextImageRelation         = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor   = false;

            //
            // dgvUsuarios
            //
            this.dgvUsuarios.AllowUserToAddRows    = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AllowUserToResizeRows = false;
            this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)(
                (System.Windows.Forms.AnchorStyles.Top    |
                 System.Windows.Forms.AnchorStyles.Bottom |
                 System.Windows.Forms.AnchorStyles.Left   |
                 System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.BackgroundColor             = System.Drawing.Color.White;
            this.dgvUsuarios.BorderStyle                 = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.ColumnHeadersHeight         = 45;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUsuarios.Location                    = new System.Drawing.Point(30, 258);
            this.dgvUsuarios.MultiSelect                 = false;
            this.dgvUsuarios.Name                        = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly                    = true;
            this.dgvUsuarios.RowHeadersVisible           = false;
            this.dgvUsuarios.RowHeadersWidth             = 51;
            this.dgvUsuarios.RowTemplate.Height          = 38;
            this.dgvUsuarios.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size                        = new System.Drawing.Size(1290, 556);
            this.dgvUsuarios.TabIndex                    = 12;

            //
            // lblResumen
            //
            this.lblResumen.Anchor    = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResumen.AutoSize  = true;
            this.lblResumen.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblResumen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblResumen.Location  = new System.Drawing.Point(30, 824);
            this.lblResumen.Name      = "lblResumen";
            this.lblResumen.TabIndex  = 13;
            this.lblResumen.Text      = "Mostrando 0 registros";

            //
            // FrmUsuarios
            //
            this.BackColor       = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ClientSize      = new System.Drawing.Size(1350, 860);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.pnlSep1);
            this.Controls.Add(this.pnlCard1);
            this.Controls.Add(this.pnlCard2);
            this.Controls.Add(this.pnlCard3);
            this.Controls.Add(this.pnlSep2);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.lblResumen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name            = "FrmUsuarios";
            this.Text            = "FrmUsuarios";

            this.pnlCard1.ResumeLayout(false);
            this.pnlCard1.PerformLayout();
            this.pnlCard2.ResumeLayout(false);
            this.pnlCard2.PerformLayout();
            this.pnlCard3.ResumeLayout(false);
            this.pnlCard3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // TITULO Y SUBTITULO
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;

        // SEPARADORES
        private System.Windows.Forms.Panel pnlSep1;
        private System.Windows.Forms.Panel pnlSep2;

        // CARDS ESTADISTICAS
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Label lblCard1Titulo;
        private System.Windows.Forms.Label lblCard1Valor;
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Label lblCard2Titulo;
        private System.Windows.Forms.Label lblCard2Valor;
        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Label lblCard3Titulo;
        private System.Windows.Forms.Label lblCard3Valor;

        // BARRA DE ACCIONES
        private System.Windows.Forms.TextBox         txtBuscar;
        private FontAwesome.Sharp.IconButton         btnNuevo;
        private FontAwesome.Sharp.IconButton         btnEditar;
        private FontAwesome.Sharp.IconButton         btnEliminar;
        private FontAwesome.Sharp.IconButton         btnActualizar;

        // DATAGRIDVIEW
        private System.Windows.Forms.DataGridView dgvUsuarios;

        // RESUMEN
        private System.Windows.Forms.Label lblResumen;
    }
}
