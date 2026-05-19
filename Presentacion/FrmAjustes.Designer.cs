namespace Sistema_Inventario.Presentacion
{
    partial class FrmAjustes
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

        #region Código generado

        private void InitializeComponent()
        {
            this.panelContenedor =
                new System.Windows.Forms.Panel();

            this.lblTitulo =
                new System.Windows.Forms.Label();

            this.cardSistema =
                new System.Windows.Forms.Panel();

            this.cardSeguridad =
                new System.Windows.Forms.Panel();

            this.cardEstadisticas =
                new System.Windows.Forms.Panel();

            this.lblUsuario =
                new System.Windows.Forms.Label();

            this.lblRol =
                new System.Windows.Forms.Label();

            this.lblFecha =
                new System.Windows.Forms.Label();

            this.lblServidor =
                new System.Windows.Forms.Label();

            this.lblBaseDatos =
                new System.Windows.Forms.Label();

            this.lblEstadoConexion =
                new System.Windows.Forms.Label();

            this.txtNuevaClave =
                new System.Windows.Forms.TextBox();

            this.btnCambiarClave =
                new FontAwesome.Sharp.IconButton();

            this.btnProbarConexion =
                new FontAwesome.Sharp.IconButton();

            this.lblTotalUsuarios =
                new System.Windows.Forms.Label();

            this.lblTotalProductos =
                new System.Windows.Forms.Label();

            this.lblTotalRoles =
                new System.Windows.Forms.Label();

            this.lblTotalLogs =
                new System.Windows.Forms.Label();

            this.SuspendLayout();

            // PANEL CONTENEDOR

            this.panelContenedor.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.panelContenedor.BackColor =
                System.Drawing.Color.FromArgb(
                    245,
                    246,
                    250);

            // TITULO

            this.lblTitulo.AutoSize = true;

            this.lblTitulo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    24F,
                    System.Drawing.FontStyle.Bold);

            this.lblTitulo.ForeColor =
                System.Drawing.Color.FromArgb(
                    7,
                    31,
                    61);

            this.lblTitulo.Location =
                new System.Drawing.Point(35, 25);

            this.lblTitulo.Text =
                "Configuración del Sistema";

            // ============================
            // CARD SISTEMA
            // ============================

            this.cardSistema.BackColor =
                System.Drawing.Color.White;

            this.cardSistema.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.cardSistema.Location =
                new System.Drawing.Point(40, 100);

            this.cardSistema.Size =
                new System.Drawing.Size(420, 320);

            System.Windows.Forms.Label tituloSistema =
                new System.Windows.Forms.Label();

            tituloSistema.Text =
                "Información del Sistema";

            tituloSistema.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    14F,
                    System.Drawing.FontStyle.Bold);

            tituloSistema.Location =
                new System.Drawing.Point(20, 20);

            tituloSistema.AutoSize = true;

            this.cardSistema.Controls.Add(
                tituloSistema);

            int top = 70;

            System.Windows.Forms.Label[] labels =
            {
                CrearLabel("Usuario:",20,top),
                CrearLabel("Rol:",20,top+=40),
                CrearLabel("Fecha:",20,top+=40),
                CrearLabel("Servidor:",20,top+=40),
                CrearLabel("Base Datos:",20,top+=40),
                CrearLabel("Estado:",20,top+=40)
            };

            foreach (System.Windows.Forms.Label lbl in labels)
            {
                this.cardSistema.Controls.Add(lbl);
            }

            ConfigurarValor(lblUsuario, 220, 70);
            ConfigurarValor(lblRol, 220, 110);
            ConfigurarValor(lblFecha, 220, 150);
            ConfigurarValor(lblServidor, 220, 190);
            ConfigurarValor(lblBaseDatos, 220, 230);
            ConfigurarValor(lblEstadoConexion, 220, 270);

            this.cardSistema.Controls.Add(lblUsuario);
            this.cardSistema.Controls.Add(lblRol);
            this.cardSistema.Controls.Add(lblFecha);
            this.cardSistema.Controls.Add(lblServidor);
            this.cardSistema.Controls.Add(lblBaseDatos);
            this.cardSistema.Controls.Add(lblEstadoConexion);

            // ============================
            // CARD SEGURIDAD
            // ============================

            this.cardSeguridad.BackColor =
                System.Drawing.Color.White;

            this.cardSeguridad.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.cardSeguridad.Location =
                new System.Drawing.Point(500, 100);

            this.cardSeguridad.Size =
                new System.Drawing.Size(420, 320);

            System.Windows.Forms.Label tituloSeguridad =
                new System.Windows.Forms.Label();

            tituloSeguridad.Text =
                "Seguridad y Base de Datos";

            tituloSeguridad.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    14F,
                    System.Drawing.FontStyle.Bold);

            tituloSeguridad.Location =
                new System.Drawing.Point(20, 20);

            tituloSeguridad.AutoSize = true;

            this.cardSeguridad.Controls.Add(
                tituloSeguridad);

            this.txtNuevaClave.Location =
                new System.Drawing.Point(30, 80);

            this.txtNuevaClave.Size =
                new System.Drawing.Size(340, 30);

            this.txtNuevaClave.PasswordChar = '*';

            // BOTON CAMBIAR CLAVE

            this.btnCambiarClave.Text =
                "Cambiar Contraseña";

            this.btnCambiarClave.Size =
                new System.Drawing.Size(340, 55);

            this.btnCambiarClave.Location =
                new System.Drawing.Point(30, 130);

            this.btnCambiarClave.BackColor =
                System.Drawing.Color.RoyalBlue;

            this.btnCambiarClave.ForeColor =
                System.Drawing.Color.White;

            this.btnCambiarClave.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnCambiarClave.FlatAppearance.BorderSize =
                0;

            this.btnCambiarClave.IconChar =
                FontAwesome.Sharp.IconChar.Key;

            this.btnCambiarClave.IconColor =
                System.Drawing.Color.White;

            this.btnCambiarClave.TextImageRelation =
                System.Windows.Forms.TextImageRelation.ImageBeforeText;

            this.btnCambiarClave.UseVisualStyleBackColor =
                false;

            this.btnCambiarClave.Click +=
                new System.EventHandler(
                    this.btnCambiarClave_Click);

            // BOTON SQL

            this.btnProbarConexion.Text =
                "Probar Conexión SQL";

            this.btnProbarConexion.Size =
                new System.Drawing.Size(340, 55);

            this.btnProbarConexion.Location =
                new System.Drawing.Point(30, 210);

            this.btnProbarConexion.BackColor =
                System.Drawing.Color.SeaGreen;

            this.btnProbarConexion.ForeColor =
                System.Drawing.Color.White;

            this.btnProbarConexion.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnProbarConexion.FlatAppearance.BorderSize =
                0;

            this.btnProbarConexion.IconChar =
                FontAwesome.Sharp.IconChar.Database;

            this.btnProbarConexion.IconColor =
                System.Drawing.Color.White;

            this.btnProbarConexion.TextImageRelation =
                System.Windows.Forms.TextImageRelation.ImageBeforeText;

            this.btnProbarConexion.UseVisualStyleBackColor =
                false;

            this.btnProbarConexion.Click +=
                new System.EventHandler(
                    this.btnProbarConexion_Click);

            this.cardSeguridad.Controls.Add(
                txtNuevaClave);

            this.cardSeguridad.Controls.Add(
                btnCambiarClave);

            this.cardSeguridad.Controls.Add(
                btnProbarConexion);

            // ============================
            // CARD ESTADISTICAS
            // ============================

            this.cardEstadisticas.BackColor =
                System.Drawing.Color.White;

            this.cardEstadisticas.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.cardEstadisticas.Location =
                new System.Drawing.Point(40, 460);

            this.cardEstadisticas.Size =
                new System.Drawing.Size(880, 180);

            System.Windows.Forms.Label tituloEstadisticas =
                new System.Windows.Forms.Label();

            tituloEstadisticas.Text =
                "Estadísticas del Sistema";

            tituloEstadisticas.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    14F,
                    System.Drawing.FontStyle.Bold);

            tituloEstadisticas.Location =
                new System.Drawing.Point(20, 20);

            tituloEstadisticas.AutoSize = true;

            this.cardEstadisticas.Controls.Add(
                tituloEstadisticas);

            ConfigurarCardNumero(
                this.cardEstadisticas,
                "Usuarios",
                lblTotalUsuarios,
                40);

            ConfigurarCardNumero(
                this.cardEstadisticas,
                "Productos",
                lblTotalProductos,
                240);

            ConfigurarCardNumero(
                this.cardEstadisticas,
                "Roles",
                lblTotalRoles,
                440);

            ConfigurarCardNumero(
                this.cardEstadisticas,
                "Logs",
                lblTotalLogs,
                640);

            // AGREGAR CONTROLES

            this.panelContenedor.Controls.Add(
                lblTitulo);

            this.panelContenedor.Controls.Add(
                cardSistema);

            this.panelContenedor.Controls.Add(
                cardSeguridad);

            this.panelContenedor.Controls.Add(
                cardEstadisticas);

            // FORM

            this.Controls.Add(
                panelContenedor);

            this.Name = "FrmAjustes";

            this.Size =
                new System.Drawing.Size(1200, 700);

            this.Load +=
                new System.EventHandler(
                    this.FrmAjustes_Load);

            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label CrearLabel(
            string texto,
            int x,
            int y)
        {
            System.Windows.Forms.Label lbl =
                new System.Windows.Forms.Label();

            lbl.Text = texto;

            lbl.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold);

            lbl.Location =
                new System.Drawing.Point(x, y);

            lbl.AutoSize = true;

            return lbl;
        }

        private void ConfigurarValor(
            System.Windows.Forms.Label lbl,
            int x,
            int y)
        {
            lbl.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F);

            lbl.Location =
                new System.Drawing.Point(x, y);

            lbl.AutoSize = true;
        }

        private void ConfigurarCardNumero(
            System.Windows.Forms.Panel panel,
            string titulo,
            System.Windows.Forms.Label valor,
            int left)
        {
            System.Windows.Forms.Panel card =
                new System.Windows.Forms.Panel();

            card.BackColor =
                System.Drawing.Color.FromArgb(
                    245,
                    246,
                    250);

            card.Size =
                new System.Drawing.Size(160, 90);

            card.Location =
                new System.Drawing.Point(left, 70);

            System.Windows.Forms.Label lblTitulo =
                new System.Windows.Forms.Label();

            lblTitulo.Text = titulo;

            lblTitulo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold);

            lblTitulo.Location =
                new System.Drawing.Point(15, 10);

            lblTitulo.AutoSize = true;

            valor.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    20F,
                    System.Drawing.FontStyle.Bold);

            valor.ForeColor =
                System.Drawing.Color.RoyalBlue;

            valor.Location =
                new System.Drawing.Point(15, 35);

            valor.AutoSize = true;

            card.Controls.Add(lblTitulo);

            card.Controls.Add(valor);

            panel.Controls.Add(card);
        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;

        private System.Windows.Forms.Label lblTitulo;

        private System.Windows.Forms.Panel cardSistema;

        private System.Windows.Forms.Panel cardSeguridad;

        private System.Windows.Forms.Panel cardEstadisticas;

        private System.Windows.Forms.Label lblUsuario;

        private System.Windows.Forms.Label lblRol;

        private System.Windows.Forms.Label lblFecha;

        private System.Windows.Forms.Label lblServidor;

        private System.Windows.Forms.Label lblBaseDatos;

        private System.Windows.Forms.Label lblEstadoConexion;

        private System.Windows.Forms.TextBox txtNuevaClave;

        private FontAwesome.Sharp.IconButton btnCambiarClave;

        private FontAwesome.Sharp.IconButton btnProbarConexion;

        private System.Windows.Forms.Label lblTotalUsuarios;

        private System.Windows.Forms.Label lblTotalProductos;

        private System.Windows.Forms.Label lblTotalRoles;

        private System.Windows.Forms.Label lblTotalLogs;
    }
}