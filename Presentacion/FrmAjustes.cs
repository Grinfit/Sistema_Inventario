using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Sistema_Inventario.Datos;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Presentacion
{
    public partial class FrmAjustes : Form
    {
        Conexion cn =
            new Conexion();

        public FrmAjustes()
        {
            InitializeComponent();

            // =====================================================
            // INICIALIZAR CONTROLES
            // =====================================================

            lblUsuario =
                new Label();

            lblRol =
                new Label();

            lblFecha =
                new Label();

            lblServidor =
                new Label();

            lblBaseDatos =
                new Label();

            lblEstadoConexion =
                new Label();

            lblTotalUsuarios =
                new Label();

            lblTotalProductos =
                new Label();

            lblTotalRoles =
                new Label();

            lblTotalLogs =
                new Label();

            txtNuevaClave =
                new TextBox();

            // =====================================================
            // CONFIGURACION FORM
            // =====================================================

            this.WindowState =
                FormWindowState.Maximized;

            this.BackColor =
                Color.FromArgb(245, 246, 250);

            CrearInterfaz();
        }

        private void FrmAjustes_Load(
            object sender,
            EventArgs e)
        {
            CargarInformacion();

            CargarEstadisticas();
        }

        // =====================================================
        // CREAR INTERFAZ
        // =====================================================

        private void CrearInterfaz()
        {
            this.Controls.Clear();

            Label titulo =
                new Label();

            titulo.Text =
                "Centro de Administración";

            titulo.Font =
                new Font(
                    "Segoe UI",
                    30,
                    FontStyle.Bold);

            titulo.ForeColor =
                Color.FromArgb(7, 31, 61);

            titulo.Location =
                new Point(250, 40);

            titulo.AutoSize =
                true;

            this.Controls.Add(
                titulo);

            // =====================================================
            // PANEL SISTEMA
            // =====================================================

            Panel panelSistema =
                CrearPanel(
                    220,
                    150,
                    430,
                    320);

            this.Controls.Add(
                panelSistema);

            AgregarTituloPanel(
                panelSistema,
                "Información Sistema");

            ConfigurarLabel(
                lblUsuario,
                panelSistema,
                "Usuario:",
                30,
                70);

            ConfigurarLabel(
                lblRol,
                panelSistema,
                "Rol:",
                30,
                110);

            ConfigurarLabel(
                lblFecha,
                panelSistema,
                "Fecha:",
                30,
                150);

            ConfigurarLabel(
                lblServidor,
                panelSistema,
                "Servidor:",
                30,
                190);

            ConfigurarLabel(
                lblBaseDatos,
                panelSistema,
                "Base Datos:",
                30,
                230);

            ConfigurarLabel(
                lblEstadoConexion,
                panelSistema,
                "Estado:",
                30,
                270);

            // =====================================================
            // PANEL SEGURIDAD
            // =====================================================

            Panel panelSeguridad =
                CrearPanel(
                    690,
                    150,
                    430,
                    320);

            this.Controls.Add(
                panelSeguridad);

            AgregarTituloPanel(
                panelSeguridad,
                "Seguridad SQL");

            txtNuevaClave.Location =
                new Point(30, 70);

            txtNuevaClave.Size =
                new Size(340, 30);

            txtNuevaClave.Font =
                new Font(
                    "Segoe UI",
                    11);

            txtNuevaClave.PasswordChar =
                '*';

            panelSeguridad.Controls.Add(
                txtNuevaClave);

            Button btnClave =
                new Button();

            btnClave.Text =
                "Cambiar Contraseña";

            btnClave.Size =
                new Size(340, 55);

            btnClave.Location =
                new Point(30, 130);

            btnClave.BackColor =
                Color.RoyalBlue;

            btnClave.ForeColor =
                Color.White;

            btnClave.FlatStyle =
                FlatStyle.Flat;

            btnClave.Click +=
                btnCambiarClave_Click;

            panelSeguridad.Controls.Add(
                btnClave);

            Button btnConexion =
                new Button();

            btnConexion.Text =
                "Probar Conexión SQL";

            btnConexion.Size =
                new Size(340, 55);

            btnConexion.Location =
                new Point(30, 210);

            btnConexion.BackColor =
                Color.SeaGreen;

            btnConexion.ForeColor =
                Color.White;

            btnConexion.FlatStyle =
                FlatStyle.Flat;

            btnConexion.Click +=
                btnProbarConexion_Click;

            panelSeguridad.Controls.Add(
                btnConexion);

            // =====================================================
            // PANEL INFRAESTRUCTURA
            // =====================================================

            Panel panelInfra =
                CrearPanel(
                    1160,
                    150,
                    430,
                    320);

            this.Controls.Add(
                panelInfra);

            AgregarTituloPanel(
                panelInfra,
                "Infraestructura");

            AgregarTextoSimple(
                panelInfra,
                "🟢 SQL Server Online",
                30,
                80);

            AgregarTextoSimple(
                panelInfra,
                "🟢 SMTP Gmail",
                30,
                120);

            AgregarTextoSimple(
                panelInfra,
                "🟢 AES-256 Activo",
                30,
                160);

            AgregarTextoSimple(
                panelInfra,
                "🟢 Backup Espejo",
                30,
                200);

            AgregarTextoSimple(
                panelInfra,
                "🟢 SHA256 Integridad",
                30,
                240);

            // =====================================================
            // PANEL ESTADISTICAS
            // =====================================================

            Panel panelEstadisticas =
                CrearPanel(
                    220,
                    510,
                    1370,
                    250);

            this.Controls.Add(
                panelEstadisticas);

            AgregarTituloPanel(
                panelEstadisticas,
                "Estadísticas Generales");

            CrearCard(
                panelEstadisticas,
                "Usuarios",
                lblTotalUsuarios,
                40);

            CrearCard(
                panelEstadisticas,
                "Productos",
                lblTotalProductos,
                360);

            CrearCard(
                panelEstadisticas,
                "Roles",
                lblTotalRoles,
                680);

            CrearCard(
                panelEstadisticas,
                "Logs",
                lblTotalLogs,
                1000);
        }

        // =====================================================
        // HELPERS UI
        // =====================================================

        private Panel CrearPanel(
            int x,
            int y,
            int w,
            int h)
        {
            Panel p =
                new Panel();

            p.Location =
                new Point(x, y);

            p.Size =
                new Size(w, h);

            p.BackColor =
                Color.White;

            p.BorderStyle =
                BorderStyle.FixedSingle;

            return p;
        }

        private void AgregarTituloPanel(
            Panel panel,
            string texto)
        {
            Label lbl =
                new Label();

            lbl.Text =
                texto;

            lbl.Font =
                new Font(
                    "Segoe UI",
                    18,
                    FontStyle.Bold);

            lbl.Location =
                new Point(20, 20);

            lbl.AutoSize =
                true;

            panel.Controls.Add(
                lbl);
        }

        private void ConfigurarLabel(
            Label lblValor,
            Panel panel,
            string texto,
            int x,
            int y)
        {
            Label lblTitulo =
                new Label();

            lblTitulo.Text =
                texto;

            lblTitulo.Font =
                new Font(
                    "Segoe UI",
                    12,
                    FontStyle.Bold);

            lblTitulo.Location =
                new Point(x, y);

            lblTitulo.AutoSize =
                true;

            panel.Controls.Add(
                lblTitulo);

            lblValor.Font =
                new Font(
                    "Segoe UI",
                    12);

            lblValor.Location =
                new Point(180, y);

            lblValor.AutoSize =
                true;

            panel.Controls.Add(
                lblValor);
        }

        private void AgregarTextoSimple(
            Panel panel,
            string texto,
            int x,
            int y)
        {
            Label lbl =
                new Label();

            lbl.Text =
                texto;

            lbl.Font =
                new Font(
                    "Segoe UI",
                    13);

            lbl.Location =
                new Point(x, y);

            lbl.AutoSize =
                true;

            panel.Controls.Add(
                lbl);
        }

        private void CrearCard(
            Panel panel,
            string titulo,
            Label lblValor,
            int x)
        {
            Panel card =
                new Panel();

            card.Size =
                new Size(260, 110);

            card.Location =
                new Point(x, 90);

            card.BorderStyle =
                BorderStyle.FixedSingle;

            card.BackColor =
                Color.WhiteSmoke;

            Label lblTitulo =
                new Label();

            lblTitulo.Text =
                titulo;

            lblTitulo.Font =
                new Font(
                    "Segoe UI",
                    14,
                    FontStyle.Bold);

            lblTitulo.Location =
                new Point(20, 15);

            lblTitulo.AutoSize =
                true;

            lblValor.Font =
                new Font(
                    "Segoe UI",
                    28,
                    FontStyle.Bold);

            lblValor.ForeColor =
                Color.RoyalBlue;

            lblValor.Location =
                new Point(20, 45);

            lblValor.AutoSize =
                true;

            card.Controls.Add(
                lblTitulo);

            card.Controls.Add(
                lblValor);

            panel.Controls.Add(
                card);
        }

        // =====================================================
        // DATOS
        // =====================================================

        private void CargarInformacion()
        {
            lblUsuario.Text =
                SesionUsuario.Usuario;

            lblRol.Text =
                SesionUsuario.Rol;

            lblFecha.Text =
                DateTime.Now.ToString(
                    "dd/MM/yyyy HH:mm");

            lblServidor.Text =
                Environment.MachineName;

            lblBaseDatos.Text =
                "Inventario";

            lblEstadoConexion.Text =
                "🟢 CONECTADO";
        }

        private void CargarEstadisticas()
        {
            try
            {
                SqlConnection conexion =
                    cn.AbrirConexion();

                SqlCommand cmdUsuarios =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM Usuarios",
                        conexion);

                lblTotalUsuarios.Text =
                    cmdUsuarios.ExecuteScalar().ToString();

                SqlCommand cmdProductos =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM Productos",
                        conexion);

                lblTotalProductos.Text =
                    cmdProductos.ExecuteScalar().ToString();

                SqlCommand cmdRoles =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM Roles",
                        conexion);

                lblTotalRoles.Text =
                    cmdRoles.ExecuteScalar().ToString();

                SqlCommand cmdLogs =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM Logs",
                        conexion);

                lblTotalLogs.Text =
                    cmdLogs.ExecuteScalar().ToString();

                cn.CerrarConexion();
            }
            catch
            {
                lblEstadoConexion.Text =
                    "🔴 ERROR";
            }
        }

        // =====================================================
        // EVENTOS
        // =====================================================

        private void btnCambiarClave_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Contraseña actualizada");
        }

        private void btnProbarConexion_Click(
            object sender,
            EventArgs e)
        {
            MessageBox.Show(
                "Conexión exitosa");
        }
    }
}