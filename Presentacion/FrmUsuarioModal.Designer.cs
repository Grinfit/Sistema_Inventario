// IMPORTACION DE LIBRERIAS NECESARIAS
using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Inventario.Presentacion
{
    // CLASE PARCIAL DEL MODAL DE USUARIO
    partial class FrmUsuarioModal
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
            this.pnlHeader      = new System.Windows.Forms.Panel();
            this.lblTitulo      = new System.Windows.Forms.Label();
            this.lblUsuario     = new System.Windows.Forms.Label();
            this.txtUsuario     = new System.Windows.Forms.TextBox();
            this.lblClave       = new System.Windows.Forms.Label();
            this.txtClave       = new System.Windows.Forms.TextBox();
            this.lblConfirmar   = new System.Windows.Forms.Label();
            this.txtConfirmar   = new System.Windows.Forms.TextBox();
            this.lblNota        = new System.Windows.Forms.Label();
            this.lblRol         = new System.Windows.Forms.Label();
            this.cboRoles       = new System.Windows.Forms.ComboBox();
            this.chkEstado      = new System.Windows.Forms.CheckBox();
            this.btnGuardar     = new FontAwesome.Sharp.IconButton();
            this.btnCancelar    = new FontAwesome.Sharp.IconButton();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(35)))), ((int)(((byte)(66)))));
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock     = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Name     = "pnlHeader";
            this.pnlHeader.Size     = new System.Drawing.Size(560, 65);
            this.pnlHeader.TabIndex = 0;

            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize  = true;
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location  = new System.Drawing.Point(20, 18);
            this.lblTitulo.Name      = "lblTitulo";
            this.lblTitulo.TabIndex  = 0;
            this.lblTitulo.Text      = "Nuevo Usuario";

            //
            // lblUsuario
            //
            this.lblUsuario.AutoSize  = true;
            this.lblUsuario.Font      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblUsuario.Location  = new System.Drawing.Point(30, 85);
            this.lblUsuario.Name      = "lblUsuario";
            this.lblUsuario.TabIndex  = 1;
            this.lblUsuario.Text      = "Usuario:";

            //
            // txtUsuario
            //
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsuario.Location    = new System.Drawing.Point(30, 110);
            this.txtUsuario.Name        = "txtUsuario";
            this.txtUsuario.Size        = new System.Drawing.Size(500, 32);
            this.txtUsuario.TabIndex    = 2;

            //
            // lblClave
            //
            this.lblClave.AutoSize  = true;
            this.lblClave.Font      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblClave.Location  = new System.Drawing.Point(30, 158);
            this.lblClave.Name      = "lblClave";
            this.lblClave.TabIndex  = 3;
            this.lblClave.Text      = "Contraseña:";

            //
            // txtClave
            //
            this.txtClave.BorderStyle            = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClave.Font                   = new System.Drawing.Font("Segoe UI", 11F);
            this.txtClave.Location               = new System.Drawing.Point(30, 183);
            this.txtClave.Name                   = "txtClave";
            this.txtClave.Size                   = new System.Drawing.Size(232, 32);
            this.txtClave.TabIndex               = 4;
            this.txtClave.UseSystemPasswordChar  = true;

            //
            // lblConfirmar
            //
            this.lblConfirmar.AutoSize  = true;
            this.lblConfirmar.Font      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblConfirmar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblConfirmar.Location  = new System.Drawing.Point(298, 158);
            this.lblConfirmar.Name      = "lblConfirmar";
            this.lblConfirmar.TabIndex  = 5;
            this.lblConfirmar.Text      = "Confirmar:";

            //
            // txtConfirmar
            //
            this.txtConfirmar.BorderStyle            = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmar.Font                   = new System.Drawing.Font("Segoe UI", 11F);
            this.txtConfirmar.Location               = new System.Drawing.Point(298, 183);
            this.txtConfirmar.Name                   = "txtConfirmar";
            this.txtConfirmar.Size                   = new System.Drawing.Size(232, 32);
            this.txtConfirmar.TabIndex               = 6;
            this.txtConfirmar.UseSystemPasswordChar  = true;

            //
            // lblNota
            //
            this.lblNota.AutoSize  = true;
            this.lblNota.Font      = new System.Drawing.Font("Segoe UI", 8F);
            this.lblNota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblNota.Location  = new System.Drawing.Point(30, 225);
            this.lblNota.Name      = "lblNota";
            this.lblNota.TabIndex  = 7;
            this.lblNota.Text      = "* Al editar un usuario debe ingresar la contraseña para guardar cambios.";

            //
            // lblRol
            //
            this.lblRol.AutoSize  = true;
            this.lblRol.Font      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblRol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblRol.Location  = new System.Drawing.Point(30, 248);
            this.lblRol.Name      = "lblRol";
            this.lblRol.TabIndex  = 8;
            this.lblRol.Text      = "Rol:";

            //
            // cboRoles
            //
            this.cboRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoles.Font          = new System.Drawing.Font("Segoe UI", 11F);
            this.cboRoles.Location      = new System.Drawing.Point(30, 273);
            this.cboRoles.Name          = "cboRoles";
            this.cboRoles.Size          = new System.Drawing.Size(500, 33);
            this.cboRoles.TabIndex      = 9;

            //
            // chkEstado
            //
            this.chkEstado.AutoSize   = true;
            this.chkEstado.Checked    = true;
            this.chkEstado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstado.Font       = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.chkEstado.ForeColor  = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.chkEstado.Location   = new System.Drawing.Point(30, 326);
            this.chkEstado.Name       = "chkEstado";
            this.chkEstado.TabIndex   = 10;
            this.chkEstado.Text       = "Usuario Activo";

            //
            // btnGuardar
            //
            this.btnGuardar.BackColor                 = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnGuardar.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font                      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor                 = System.Drawing.Color.White;
            this.btnGuardar.IconChar                  = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnGuardar.IconColor                 = System.Drawing.Color.White;
            this.btnGuardar.IconFont                  = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize                  = 22;
            this.btnGuardar.Location                  = new System.Drawing.Point(30, 380);
            this.btnGuardar.Name                      = "btnGuardar";
            this.btnGuardar.Size                      = new System.Drawing.Size(232, 46);
            this.btnGuardar.TabIndex                  = 11;
            this.btnGuardar.Text                      = " Guardar";
            this.btnGuardar.TextImageRelation         = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor   = false;
            this.btnGuardar.Click                    += new System.EventHandler(this.btnGuardar_Click);

            //
            // btnCancelar
            //
            this.btnCancelar.BackColor                 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancelar.Cursor                    = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle                 = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font                      = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor                 = System.Drawing.Color.White;
            this.btnCancelar.IconChar                  = FontAwesome.Sharp.IconChar.Xmark;
            this.btnCancelar.IconColor                 = System.Drawing.Color.White;
            this.btnCancelar.IconFont                  = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar.IconSize                  = 22;
            this.btnCancelar.Location                  = new System.Drawing.Point(298, 380);
            this.btnCancelar.Name                      = "btnCancelar";
            this.btnCancelar.Size                      = new System.Drawing.Size(232, 46);
            this.btnCancelar.TabIndex                  = 12;
            this.btnCancelar.Text                      = " Cancelar";
            this.btnCancelar.TextImageRelation         = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor   = false;
            this.btnCancelar.Click                    += new System.EventHandler(this.btnCancelar_Click);

            //
            // FrmUsuarioModal
            //
            this.BackColor       = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ClientSize      = new System.Drawing.Size(560, 450);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblClave);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.lblConfirmar);
            this.Controls.Add(this.txtConfirmar);
            this.Controls.Add(this.lblNota);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.cboRoles);
            this.Controls.Add(this.chkEstado);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.Name            = "FrmUsuarioModal";
            this.ShowInTaskbar   = false;
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "Nuevo Usuario";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // HEADER
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;

        // CAMPOS
        private System.Windows.Forms.Label    lblUsuario;
        private System.Windows.Forms.TextBox  txtUsuario;
        private System.Windows.Forms.Label    lblClave;
        private System.Windows.Forms.TextBox  txtClave;
        private System.Windows.Forms.Label    lblConfirmar;
        private System.Windows.Forms.TextBox  txtConfirmar;
        private System.Windows.Forms.Label    lblNota;
        private System.Windows.Forms.Label    lblRol;
        private System.Windows.Forms.ComboBox cboRoles;
        private System.Windows.Forms.CheckBox chkEstado;

        // BOTONES
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnCancelar;
    }
}
