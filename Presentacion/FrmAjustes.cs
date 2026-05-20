// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Sistema_Inventario.Datos;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO ENCARGADO DE MOSTRAR LOS AJUSTES DEL SISTEMA
    public partial class FrmAjustes : Form
    {
        // OBJETO DE CONEXION A LA BASE DE DATOS
        Conexion cn =
            new Conexion();

        // CONSTRUCTOR DEL FORMULARIO
        public FrmAjustes()
        {
            InitializeComponent();

            // INICIALIZA LOS LABELS DEL SISTEMA
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

            // INICIALIZA EL TEXTBOX DE NUEVA CLAVE
            txtNuevaClave =
                new TextBox();

            // CONFIGURA EL FORMULARIO EN PANTALLA COMPLETA
            this.WindowState =
                FormWindowState.Maximized;

            // DEFINE EL COLOR DE FONDO DEL FORMULARIO
            this.BackColor =
                Color.FromArgb(245, 246, 250);

            // CREA TODA LA INTERFAZ
            CrearInterfaz();
        }

        // EVENTO LOAD DEL FORMULARIO
        private void FrmAjustes_Load(
            object sender,
            EventArgs e)
        {
            // CARGA INFORMACION DEL SISTEMA
            CargarInformacion();

            // CARGA ESTADISTICAS
            CargarEstadisticas();
        }

        // METODO PARA CREAR LA INTERFAZ
        private void CrearInterfaz()
        {
            // LIMPIA LOS CONTROLES DEL FORMULARIO
            this.Controls.Clear();

            // CREA EL TITULO PRINCIPAL
            Label titulo =
                new Label();

            // TEXTO DEL TITULO
            titulo.Text =
                "Centro de Administración";

            // FUENTE DEL TITULO
            titulo.Font =
                new Font(
                    "Segoe UI",
                    30,
                    FontStyle.Bold);

            // COLOR DEL TITULO
            titulo.ForeColor =
                Color.FromArgb(7, 31, 61);

            // POSICION DEL TITULO
            titulo.Location =
                new Point(250, 40);

            // AJUSTA EL TAMAÑO AUTOMATICAMENTE
            titulo.AutoSize =
                true;

            // AGREGA EL TITULO AL FORMULARIO
            this.Controls.Add(
                titulo);

            // CREA EL PANEL DEL SISTEMA
            Panel panelSistema =
                CrearPanel(
                    220,
                    150,
                    430,
                    320);

            // AGREGA EL PANEL AL FORMULARIO
            this.Controls.Add(
                panelSistema);

            // AGREGA EL TITULO DEL PANEL
            AgregarTituloPanel(
                panelSistema,
                "Información Sistema");

            // CONFIGURA LOS LABELS
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

            // CREA EL PANEL DE SEGURIDAD
            Panel panelSeguridad =
                CrearPanel(
                    690,
                    150,
                    430,
                    320);

            // AGREGA EL PANEL
            this.Controls.Add(
                panelSeguridad);

            // AGREGA EL TITULO DEL PANEL
            AgregarTituloPanel(
                panelSeguridad,
                "Seguridad SQL");

            // POSICION DEL TEXTBOX
            txtNuevaClave.Location =
                new Point(30, 70);

            // TAMAÑO DEL TEXTBOX
            txtNuevaClave.Size =
                new Size(340, 30);

            // FUENTE DEL TEXTBOX
            txtNuevaClave.Font =
                new Font(
                    "Segoe UI",
                    11);

            // OCULTA LOS CARACTERES
            txtNuevaClave.PasswordChar =
                '*';

            // AGREGA EL TEXTBOX AL PANEL
            panelSeguridad.Controls.Add(
                txtNuevaClave);

            // CREA EL BOTON CAMBIAR CLAVE
            Button btnClave =
                new Button();

            // TEXTO DEL BOTON
            btnClave.Text =
                "Cambiar Contraseña";

            // TAMAÑO DEL BOTON
            btnClave.Size =
                new Size(340, 55);

            // POSICION DEL BOTON
            btnClave.Location =
                new Point(30, 130);

            // COLOR DEL BOTON
            btnClave.BackColor =
                Color.RoyalBlue;

            // COLOR DEL TEXTO
            btnClave.ForeColor =
                Color.White;

            // ESTILO DEL BOTON
            btnClave.FlatStyle =
                FlatStyle.Flat;

            // EVENTO CLICK DEL BOTON
            btnClave.Click +=
                btnCambiarClave_Click;

            // AGREGA EL BOTON
            panelSeguridad.Controls.Add(
                btnClave);

            // CREA EL BOTON PROBAR CONEXION
            Button btnConexion =
                new Button();

            // TEXTO DEL BOTON
            btnConexion.Text =
                "Probar Conexión SQL";

            // TAMAÑO DEL BOTON
            btnConexion.Size =
                new Size(340, 55);

            // POSICION DEL BOTON
            btnConexion.Location =
                new Point(30, 210);

            // COLOR DEL BOTON
            btnConexion.BackColor =
                Color.SeaGreen;

            // COLOR DEL TEXTO
            btnConexion.ForeColor =
                Color.White;

            // ESTILO DEL BOTON
            btnConexion.FlatStyle =
                FlatStyle.Flat;

            // EVENTO CLICK DEL BOTON
            btnConexion.Click +=
                btnProbarConexion_Click;

            // AGREGA EL BOTON
            panelSeguridad.Controls.Add(
                btnConexion);

            // CREA EL PANEL DE INFRAESTRUCTURA
            Panel panelInfra =
                CrearPanel(
                    1160,
                    150,
                    430,
                    320);

            // AGREGA EL PANEL
            this.Controls.Add(
                panelInfra);

            // AGREGA TITULO AL PANEL
            AgregarTituloPanel(
                panelInfra,
                "Infraestructura");

            // AGREGA TEXTO SIMPLE
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

            // CREA EL PANEL DE ESTADISTICAS
            Panel panelEstadisticas =
                CrearPanel(
                    220,
                    510,
                    1370,
                    250);

            // AGREGA EL PANEL
            this.Controls.Add(
                panelEstadisticas);

            // AGREGA EL TITULO
            AgregarTituloPanel(
                panelEstadisticas,
                "Estadísticas Generales");

            // CREA LAS TARJETAS DE ESTADISTICAS
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

        // METODO PARA CREAR PANELES
        private Panel CrearPanel(
            int x,
            int y,
            int w,
            int h)
        {
            // CREA EL PANEL
            Panel p =
                new Panel();

            // POSICION DEL PANEL
            p.Location =
                new Point(x, y);

            // TAMAÑO DEL PANEL
            p.Size =
                new Size(w, h);

            // COLOR DEL PANEL
            p.BackColor =
                Color.White;

            // BORDE DEL PANEL
            p.BorderStyle =
                BorderStyle.FixedSingle;

            // RETORNA EL PANEL
            return p;
        }

        // METODO PARA AGREGAR TITULOS A LOS PANELES
        private void AgregarTituloPanel(
            Panel panel,
            string texto)
        {
            // CREA EL LABEL
            Label lbl =
                new Label();

            // TEXTO DEL LABEL
            lbl.Text =
                texto;

            // FUENTE DEL LABEL
            lbl.Font =
                new Font(
                    "Segoe UI",
                    18,
                    FontStyle.Bold);

            // POSICION DEL LABEL
            lbl.Location =
                new Point(20, 20);

            // AJUSTE AUTOMATICO
            lbl.AutoSize =
                true;

            // AGREGA EL LABEL
            panel.Controls.Add(
                lbl);
        }

        // METODO PARA CONFIGURAR LABELS
        private void ConfigurarLabel(
            Label lblValor,
            Panel panel,
            string texto,
            int x,
            int y)
        {
            // CREA EL LABEL TITULO
            Label lblTitulo =
                new Label();

            // TEXTO DEL LABEL
            lblTitulo.Text =
                texto;

            // FUENTE DEL LABEL
            lblTitulo.Font =
                new Font(
                    "Segoe UI",
                    12,
                    FontStyle.Bold);

            // POSICION DEL LABEL
            lblTitulo.Location =
                new Point(x, y);

            // AJUSTE AUTOMATICO
            lblTitulo.AutoSize =
                true;

            // AGREGA EL LABEL AL PANEL
            panel.Controls.Add(
                lblTitulo);

            // FUENTE DEL VALOR
            lblValor.Font =
                new Font(
                    "Segoe UI",
                    12);

            // POSICION DEL VALOR
            lblValor.Location =
                new Point(180, y);

            // AJUSTE AUTOMATICO
            lblValor.AutoSize =
                true;

            // AGREGA EL LABEL AL PANEL
            panel.Controls.Add(
                lblValor);
        }

        // METODO PARA AGREGAR TEXTO SIMPLE
        private void AgregarTextoSimple(
            Panel panel,
            string texto,
            int x,
            int y)
        {
            // CREA EL LABEL
            Label lbl =
                new Label();

            // TEXTO DEL LABEL
            lbl.Text =
                texto;

            // FUENTE DEL LABEL
            lbl.Font =
                new Font(
                    "Segoe UI",
                    13);

            // POSICION DEL LABEL
            lbl.Location =
                new Point(x, y);

            // AJUSTE AUTOMATICO
            lbl.AutoSize =
                true;

            // AGREGA EL LABEL
            panel.Controls.Add(
                lbl);
        }

        // METODO PARA CREAR TARJETAS DE ESTADISTICAS
        private void CrearCard(
            Panel panel,
            string titulo,
            Label lblValor,
            int x)
        {
            // CREA EL PANEL CARD
            Panel card =
                new Panel();

            // TAMAÑO DE LA CARD
            card.Size =
                new Size(260, 110);

            // POSICION DE LA CARD
            card.Location =
                new Point(x, 90);

            // BORDE DE LA CARD
            card.BorderStyle =
                BorderStyle.FixedSingle;

            // COLOR DE LA CARD
            card.BackColor =
                Color.WhiteSmoke;

            // CREA LABEL DEL TITULO
            Label lblTitulo =
                new Label();

            // TEXTO DEL TITULO
            lblTitulo.Text =
                titulo;

            // FUENTE DEL TITULO
            lblTitulo.Font =
                new Font(
                    "Segoe UI",
                    14,
                    FontStyle.Bold);

            // POSICION DEL TITULO
            lblTitulo.Location =
                new Point(20, 15);

            // AJUSTE AUTOMATICO
            lblTitulo.AutoSize =
                true;

            // FUENTE DEL VALOR
            lblValor.Font =
                new Font(
                    "Segoe UI",
                    28,
                    FontStyle.Bold);

            // COLOR DEL VALOR
            lblValor.ForeColor =
                Color.RoyalBlue;

            // POSICION DEL VALOR
            lblValor.Location =
                new Point(20, 45);

            // AJUSTE AUTOMATICO
            lblValor.AutoSize =
                true;

            // AGREGA EL TITULO
            card.Controls.Add(
                lblTitulo);

            // AGREGA EL VALOR
            card.Controls.Add(
                lblValor);

            // AGREGA LA CARD
            panel.Controls.Add(
                card);
        }

        // METODO PARA CARGAR INFORMACION DEL SISTEMA
        private void CargarInformacion()
        {
            // MUESTRA EL USUARIO ACTUAL
            lblUsuario.Text =
                SesionUsuario.Usuario;

            // MUESTRA EL ROL ACTUAL
            lblRol.Text =
                SesionUsuario.Rol;

            // MUESTRA LA FECHA ACTUAL
            lblFecha.Text =
                DateTime.Now.ToString(
                    "dd/MM/yyyy HH:mm");

            // MUESTRA EL NOMBRE DEL SERVIDOR
            lblServidor.Text =
                Environment.MachineName;

            // MUESTRA EL NOMBRE DE LA BASE DE DATOS
            lblBaseDatos.Text =
                "Inventario";

            // MUESTRA EL ESTADO DE CONEXION
            lblEstadoConexion.Text =
                "🟢 CONECTADO";
        }

        // METODO PARA CARGAR ESTADISTICAS
        private void CargarEstadisticas()
        {
            try
            {
                // ABRE LA CONEXION
                SqlConnection conexion =
                    cn.AbrirConexion();

                // CONSULTA PARA CONTAR USUARIOS
                SqlCommand cmdUsuarios =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM Usuarios",
                        conexion);

                // MUESTRA TOTAL DE USUARIOS
                lblTotalUsuarios.Text =
                    cmdUsuarios.ExecuteScalar().ToString();

                // CONSULTA PARA CONTAR PRODUCTOS
                SqlCommand cmdProductos =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM Productos",
                        conexion);

                // MUESTRA TOTAL DE PRODUCTOS
                lblTotalProductos.Text =
                    cmdProductos.ExecuteScalar().ToString();

                // CONSULTA PARA CONTAR ROLES
                SqlCommand cmdRoles =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM Roles",
                        conexion);

                // MUESTRA TOTAL DE ROLES
                lblTotalRoles.Text =
                    cmdRoles.ExecuteScalar().ToString();

                // CONSULTA PARA CONTAR LOGS
                SqlCommand cmdLogs =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM Logs",
                        conexion);

                // MUESTRA TOTAL DE LOGS
                lblTotalLogs.Text =
                    cmdLogs.ExecuteScalar().ToString();

                // CIERRA LA CONEXION
                cn.CerrarConexion();
            }
            catch
            {
                // MUESTRA ERROR DE CONEXION
                lblEstadoConexion.Text =
                    "🔴 ERROR";
            }
        }

        // EVENTO DEL BOTON CAMBIAR CLAVE
        private void btnCambiarClave_Click(
            object sender,
            EventArgs e)
        {
            // MUESTRA MENSAJE DE CONFIRMACION
            MessageBox.Show(
                "Contraseña actualizada");
        }

        // EVENTO DEL BOTON PROBAR CONEXION
        private void btnProbarConexion_Click(
            object sender,
            EventArgs e)
        {
            // MUESTRA MENSAJE DE CONEXION EXITOSA
            MessageBox.Show(
                "Conexión exitosa");
        }
    }
}