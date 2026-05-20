// IMPORTACION DE LIBRERIAS NECESARIAS
using FontAwesome.Sharp;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Inventario
{
    // CLASE PARCIAL DEL FORMULARIO LOGIN
    partial class FrmLogin
    {
        // CONTENEDOR DE COMPONENTES DEL FORMULARIO
        private System.ComponentModel.IContainer components = null;

        // METODO PARA LIBERAR RECURSOS
        protected override void Dispose(
            bool disposing)
        {
            // VERIFICA SI LOS COMPONENTES EXISTEN
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
            // PANEL IZQUIERDO DEL LOGIN
            this.panelLeft =
                new System.Windows.Forms.Panel();

            // LABEL DEL NOMBRE DEL SISTEMA
            this.lblSistema =
                new System.Windows.Forms.Label();

            // LABEL DEL SUBTITULO
            this.lblSubtitulo =
                new System.Windows.Forms.Label();

            // ICONO PRINCIPAL DEL SISTEMA
            this.iconSistema =
                new FontAwesome.Sharp.IconPictureBox();

            // PANEL DEL LOGIN
            this.panelLogin =
                new System.Windows.Forms.Panel();

            // LABEL TITULO LOGIN
            this.lblLogin =
                new System.Windows.Forms.Label();

            // LABEL USUARIO
            this.Label1 =
                new System.Windows.Forms.Label();

            // LABEL CONTRASEÑA
            this.label2 =
                new System.Windows.Forms.Label();

            // TEXTBOX USUARIO
            this.txtUsuario =
                new System.Windows.Forms.TextBox();

            // TEXTBOX CONTRASEÑA
            this.txtClave =
                new System.Windows.Forms.TextBox();

            // BOTON INGRESAR
            this.btnIngresar =
                new FontAwesome.Sharp.IconButton();

            // ICONO USUARIO
            this.iconUsuario =
                new FontAwesome.Sharp.IconPictureBox();

            // ICONO CONTRASEÑA
            this.iconClave =
                new FontAwesome.Sharp.IconPictureBox();

            // CHECKBOX MOSTRAR CONTRASEÑA
            this.chkMostrarClave =
                new System.Windows.Forms.CheckBox();

            this.panelLeft.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.iconSistema)).BeginInit();

            this.panelLogin.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.iconUsuario)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.iconClave)).BeginInit();

            this.SuspendLayout();

            // CONFIGURACION GENERAL DEL FORMULARIO

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.FromArgb(
                    18,
                    18,
                    32);

            this.ClientSize =
                new System.Drawing.Size(1000, 550);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Sistema Inventario";

            // CONFIGURACION DEL PANEL IZQUIERDO

            this.panelLeft.BackColor =
                System.Drawing.Color.FromArgb(
                    11,
                    31,
                    58);

            this.panelLeft.Dock =
                System.Windows.Forms.DockStyle.Left;

            this.panelLeft.Width = 400;

            // CONFIGURACION DEL ICONO PRINCIPAL

            this.iconSistema.BackColor =
                System.Drawing.Color.Transparent;

            this.iconSistema.IconChar =
                FontAwesome.Sharp.IconChar.BoxesStacked;

            this.iconSistema.IconColor =
                System.Drawing.Color.White;

            this.iconSistema.IconFont =
                FontAwesome.Sharp.IconFont.Auto;

            this.iconSistema.IconSize = 110;

            this.iconSistema.Location =
                new System.Drawing.Point(115, 120);

            this.iconSistema.Size =
                new System.Drawing.Size(110, 110);

            // CONFIGURACION DEL LABEL SISTEMA

            this.lblSistema.AutoSize = true;

            this.lblSistema.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    22F,
                    System.Drawing.FontStyle.Bold);

            this.lblSistema.ForeColor =
                System.Drawing.Color.White;

            this.lblSistema.Location =
                new System.Drawing.Point(28, 260);

            this.lblSistema.Text =
                "Sistema Inventario";

            // CONFIGURACION DEL SUBTITULO

            this.lblSubtitulo.AutoSize = true;

            this.lblSubtitulo.Font =
                new System.Drawing.Font(
                 "Segoe UI",
                     12F,
                 System.Drawing.FontStyle.Regular);

            this.lblSubtitulo.ForeColor =
                System.Drawing.Color.Silver;

            this.lblSubtitulo.Location =
                new System.Drawing.Point(70, 320);

            this.lblSubtitulo.Text =
                "Control y gestión de inventario";

            // CONFIGURACION DEL PANEL LOGIN

            this.panelLogin.BackColor =
                System.Drawing.Color.FromArgb(
                    30,
                    30,
                    45);

            this.panelLogin.Size =
                new System.Drawing.Size(500, 420);

            this.panelLogin.Location =
                new System.Drawing.Point(420, 65);

            // CONFIGURACION DEL TITULO LOGIN

            this.lblLogin.AutoSize = true;

            this.lblLogin.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    24F,
                    System.Drawing.FontStyle.Bold);

            this.lblLogin.ForeColor =
                System.Drawing.Color.White;

            this.lblLogin.Location =
                new System.Drawing.Point(145, 35);

            this.lblLogin.Text =
                "Iniciar Sesión";

            // CONFIGURACION DEL LABEL USUARIO

            this.Label1.AutoSize = true;

            this.Label1.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F);

            this.Label1.ForeColor =
                System.Drawing.Color.White;

            this.Label1.Location =
                new System.Drawing.Point(90, 125);

            this.Label1.Text =
                "Usuario";

            // CONFIGURACION DEL TEXTBOX USUARIO

            this.txtUsuario.BackColor =
                System.Drawing.Color.FromArgb(
                    45,
                    45,
                    65);

            this.txtUsuario.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtUsuario.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    13F);

            this.txtUsuario.ForeColor =
                System.Drawing.Color.White;

            this.txtUsuario.Location =
                new System.Drawing.Point(95, 160);

            this.txtUsuario.Size =
                new System.Drawing.Size(310, 42);

            // CONFIGURACION DEL ICONO USUARIO

            this.iconUsuario.BackColor =
                System.Drawing.Color.Transparent;

            this.iconUsuario.IconChar =
                FontAwesome.Sharp.IconChar.User;

            this.iconUsuario.IconColor =
                System.Drawing.Color.Silver;

            this.iconUsuario.IconFont =
                FontAwesome.Sharp.IconFont.Auto;

            this.iconUsuario.IconSize = 24;

            this.iconUsuario.Location =
                new System.Drawing.Point(60, 171);

            this.iconUsuario.Size =
                new System.Drawing.Size(24, 24);

            // CONFIGURACION DEL LABEL CONTRASEÑA

            this.label2.AutoSize = true;

            this.label2.Font =
                new System.Drawing.Font(
        "Segoe UI",
        12F,
        System.Drawing.FontStyle.Regular);

            this.label2.ForeColor =
                System.Drawing.Color.White;

            this.label2.Location =
                new System.Drawing.Point(90, 225);

            this.label2.Text =
                "Contraseña";

            // CONFIGURACION DEL TEXTBOX CONTRASEÑA

            this.txtClave.BackColor =
                System.Drawing.Color.FromArgb(
                    45,
                    45,
                    65);

            this.txtClave.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtClave.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    13F);

            this.txtClave.ForeColor =
                System.Drawing.Color.White;

            this.txtClave.TextAlign =
    System.Windows.Forms.HorizontalAlignment.Center;

            this.txtClave.Location =
                new System.Drawing.Point(95, 260);

            this.txtClave.Size =
                new System.Drawing.Size(310, 42);

            this.txtClave.UseSystemPasswordChar =
                true;

            // CONFIGURACION DEL ICONO CONTRASEÑA

            this.iconClave.BackColor =
                System.Drawing.Color.Transparent;

            this.iconClave.IconChar =
                FontAwesome.Sharp.IconChar.Lock;

            this.iconClave.IconColor =
                System.Drawing.Color.Silver;

            this.iconClave.IconFont =
                FontAwesome.Sharp.IconFont.Auto;

            this.iconClave.IconSize = 24;

            this.iconClave.Location =
                new System.Drawing.Point(60, 271);

            this.iconClave.Size =
                new System.Drawing.Size(24, 24);

            // CONFIGURACION DEL CHECKBOX

            this.chkMostrarClave.AutoSize = true;

            this.chkMostrarClave.ForeColor =
                System.Drawing.Color.Silver;

            this.chkMostrarClave.Location =
                new System.Drawing.Point(95, 315);

            this.chkMostrarClave.Text =
                "Mostrar contraseña";

            this.chkMostrarClave.CheckedChanged +=
                new System.EventHandler(
                    this.chkMostrarClave_CheckedChanged);

            // CONFIGURACION DEL BOTON LOGIN

            this.btnIngresar.BackColor =
                System.Drawing.Color.FromArgb(
                    37,
                    99,
                    235);

            this.btnIngresar.FlatAppearance.BorderSize = 0;

            this.btnIngresar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnIngresar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    13F,
                    System.Drawing.FontStyle.Bold);

            this.btnIngresar.ForeColor =
                System.Drawing.Color.White;

            this.txtUsuario.TextAlign =
    System.Windows.Forms.HorizontalAlignment.Center;

            this.btnIngresar.IconChar =
                FontAwesome.Sharp.IconChar.RightToBracket;

            this.btnIngresar.IconColor =
                System.Drawing.Color.White;

            this.btnIngresar.IconFont =
                FontAwesome.Sharp.IconFont.Auto;

            this.btnIngresar.IconSize = 30;

            this.btnIngresar.Location =
                new System.Drawing.Point(95, 355);

            this.btnIngresar.Size =
                new System.Drawing.Size(310, 50);

            this.btnIngresar.Text =
                " INGRESAR";

            this.btnIngresar.TextImageRelation =
                System.Windows.Forms.TextImageRelation.ImageBeforeText;

            this.btnIngresar.UseVisualStyleBackColor =
                false;

            this.btnIngresar.Click +=
                new System.EventHandler(
                    this.btnIngresar_Click);

            // AGREGAR CONTROLES AL PANEL IZQUIERDO

            this.panelLeft.Controls.Add(
                this.iconSistema);

            this.panelLeft.Controls.Add(
                this.lblSistema);

            this.panelLeft.Controls.Add(
                this.lblSubtitulo);

            // AGREGAR CONTROLES AL PANEL LOGIN

            this.panelLogin.Controls.Add(
                this.lblLogin);

            this.panelLogin.Controls.Add(
                this.Label1);

            this.panelLogin.Controls.Add(
                this.txtUsuario);

            this.panelLogin.Controls.Add(
                this.iconUsuario);

            this.panelLogin.Controls.Add(
                this.label2);

            this.panelLogin.Controls.Add(
                this.txtClave);

            this.panelLogin.Controls.Add(
                this.iconClave);

            this.panelLogin.Controls.Add(
                this.chkMostrarClave);

            this.panelLogin.Controls.Add(
                this.btnIngresar);

            // AGREGAR PANELES AL FORMULARIO

            this.Controls.Add(
                this.panelLeft);

            this.Controls.Add(
                this.panelLogin);

            this.panelLeft.ResumeLayout(false);

            this.panelLeft.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.iconSistema)).EndInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.iconUsuario)).EndInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.iconClave)).EndInit();

            this.panelLogin.ResumeLayout(false);

            this.panelLogin.PerformLayout();

            this.ResumeLayout(false);
        }

        #endregion

        // DECLARACION DEL PANEL IZQUIERDO
        private System.Windows.Forms.Panel panelLeft;

        // DECLARACION DEL PANEL LOGIN
        private System.Windows.Forms.Panel panelLogin;

        // DECLARACION DEL LABEL SISTEMA
        private System.Windows.Forms.Label lblSistema;

        // DECLARACION DEL LABEL SUBTITULO
        private System.Windows.Forms.Label lblSubtitulo;

        // DECLARACION DEL LABEL LOGIN
        private System.Windows.Forms.Label lblLogin;

        // DECLARACION DEL LABEL USUARIO
        private System.Windows.Forms.Label Label1;

        // DECLARACION DEL LABEL CONTRASEÑA
        private System.Windows.Forms.Label label2;

        // DECLARACION DEL TEXTBOX USUARIO
        private System.Windows.Forms.TextBox txtUsuario;

        // DECLARACION DEL TEXTBOX CONTRASEÑA
        private System.Windows.Forms.TextBox txtClave;

        // DECLARACION DEL BOTON INGRESAR
        private FontAwesome.Sharp.IconButton btnIngresar;

        // DECLARACION DEL ICONO PRINCIPAL
        private FontAwesome.Sharp.IconPictureBox iconSistema;

        // DECLARACION DEL ICONO USUARIO
        private FontAwesome.Sharp.IconPictureBox iconUsuario;

        // DECLARACION DEL ICONO CONTRASEÑA
        private FontAwesome.Sharp.IconPictureBox iconClave;

        // DECLARACION DEL CHECKBOX MOSTRAR CONTRASEÑA
        private System.Windows.Forms.CheckBox chkMostrarClave;
    }
}