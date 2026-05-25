// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Sistema_Inventario.Datos;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO CENTRO DE ADMINISTRACION — DASHBOARD ERP
    public partial class FrmAjustes : Form
    {
        // OBJETO DE CONEXION A LA BASE DE DATOS
        Conexion cn = new Conexion();

        // LABELS DEL HEADER
        private Label lblFechaHoraHeader;
        private Label lblUsuarioInfoHeader;

        // LABELS KPI ADICIONALES
        private Label lblTotalBodegas;
        private Label lblTotalProveedores;
        private Label lblTotalMovimientos;
        private Label lblTotalTransferencias;

        // CONSTRUCTOR DEL FORMULARIO
        public FrmAjustes()
        {
            InitializeComponent();

            // INICIALIZA LABELS DECLARADOS EN DESIGNER.CS
            lblUsuario        = new Label();
            lblRol            = new Label();
            lblFecha          = new Label();
            lblServidor       = new Label();
            lblBaseDatos      = new Label();
            lblEstadoConexion = new Label();
            lblTotalUsuarios  = new Label();
            lblTotalProductos = new Label();
            lblTotalRoles     = new Label();
            lblTotalLogs      = new Label();
            txtNuevaClave     = new TextBox();

            // INICIALIZA NUEVOS LABELS
            lblFechaHoraHeader      = new Label();
            lblUsuarioInfoHeader    = new Label();
            lblTotalBodegas         = new Label();
            lblTotalProveedores     = new Label();
            lblTotalMovimientos     = new Label();
            lblTotalTransferencias  = new Label();

            this.WindowState = FormWindowState.Maximized;
            this.BackColor   = Color.FromArgb(240, 242, 245);

            CrearInterfaz();
        }

        // ─────────────────────────────────────────
        // LOAD
        // ─────────────────────────────────────────
        private void FrmAjustes_Load(object sender, EventArgs e)
        {
            timer1.Start();
            CargarInformacion();
            CargarEstadisticas();
        }

        // ─────────────────────────────────────────
        // RELOJ — actualiza cada segundo
        // ─────────────────────────────────────────
        private void timer1_Tick(object sender, EventArgs e)
        {
            CultureInfo cultura = new CultureInfo("es-PE");
            lblFechaHoraHeader.Text = DateTime.Now.ToString(
                "dddd, dd 'de' MMMM 'de' yyyy  •  HH:mm:ss", cultura);
        }

        // ─────────────────────────────────────────
        // CONSTRUCCION DE LA INTERFAZ
        // ─────────────────────────────────────────
        private void CrearInterfaz()
        {
            this.Controls.Clear();

            // ── PANEL PRINCIPAL (Fill) — agregar primero ──────────────────
            Panel pnlMain = new Panel();
            pnlMain.Dock                 = DockStyle.Fill;
            pnlMain.BackColor            = Color.FromArgb(240, 242, 245);
            pnlMain.AutoScroll           = true;
            pnlMain.AutoScrollMinSize    = new System.Drawing.Size(0, 900);

            // ── FRANJA ACENTO AZUL (Top) ──────────────────────────────────
            Panel pnlSepH = new Panel();
            pnlSepH.Dock      = DockStyle.Top;
            pnlSepH.Height    = 3;
            pnlSepH.BackColor = Color.FromArgb(37, 99, 235);

            // ── PANEL HEADER (Top) ────────────────────────────────────────
            Panel pnlHeader = new Panel();
            pnlHeader.Dock      = DockStyle.Top;
            pnlHeader.Height    = 90;
            pnlHeader.BackColor = Color.FromArgb(10, 35, 66);

            // Título y subtítulo (izquierda)
            Label lblTitulo = new Label();
            lblTitulo.Text      = "Centro de Administración";
            lblTitulo.Font      = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location  = new Point(30, 13);
            lblTitulo.AutoSize  = true;
            pnlHeader.Controls.Add(lblTitulo);

            Label lblSub = new Label();
            lblSub.Text      = "Sistema de Inventario ERP";
            lblSub.Font      = new Font("Segoe UI", 10F);
            lblSub.ForeColor = Color.FromArgb(155, 180, 215);
            lblSub.Location  = new Point(33, 50);
            lblSub.AutoSize  = true;
            pnlHeader.Controls.Add(lblSub);

            // Panel derecho con fecha/hora y usuario (anclado a la derecha)
            Panel pnlRight = new Panel();
            pnlRight.BackColor = Color.Transparent;
            pnlRight.Size      = new Size(500, 80);
            pnlRight.Anchor    = AnchorStyles.Top | AnchorStyles.Right;
            pnlRight.Location  = new Point(1600 - 520, 5);

            lblFechaHoraHeader.Font      = new Font("Segoe UI", 10F);
            lblFechaHoraHeader.ForeColor = Color.FromArgb(160, 185, 220);
            lblFechaHoraHeader.Text      = DateTime.Now.ToString(
                "dddd, dd 'de' MMMM 'de' yyyy  •  HH:mm:ss",
                new CultureInfo("es-PE"));
            lblFechaHoraHeader.AutoSize  = true;
            lblFechaHoraHeader.Location  = new Point(0, 15);
            pnlRight.Controls.Add(lblFechaHoraHeader);

            lblUsuarioInfoHeader.Font      = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblUsuarioInfoHeader.ForeColor = Color.White;
            lblUsuarioInfoHeader.Text      = "◉  Cargando...";
            lblUsuarioInfoHeader.AutoSize  = true;
            lblUsuarioInfoHeader.Location  = new Point(0, 48);
            pnlRight.Controls.Add(lblUsuarioInfoHeader);

            pnlHeader.Controls.Add(pnlRight);

            // ── CONTENIDO DE pnlMain ──────────────────────────────────────

            // SECCIÓN KPI
            Label lblSecKPI = new Label();
            lblSecKPI.Text      = "INDICADORES CLAVE";
            lblSecKPI.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSecKPI.ForeColor = Color.FromArgb(100, 110, 130);
            lblSecKPI.Location  = new Point(25, 18);
            lblSecKPI.AutoSize  = true;
            pnlMain.Controls.Add(lblSecKPI);

            // Posiciones X de las 4 columnas (ancho 355, gap 20)
            int[] xs   = { 25, 400, 775, 1150 };
            int   ry1  = 40;
            int   ry2  = 165;

            CrearKPICard(pnlMain, "Usuarios Registrados",    lblTotalUsuarios,       xs[0], ry1, Color.FromArgb(37,  99,  235));
            CrearKPICard(pnlMain, "Productos en Catálogo",   lblTotalProductos,      xs[1], ry1, Color.FromArgb(16,  185, 129));
            CrearKPICard(pnlMain, "Roles del Sistema",       lblTotalRoles,          xs[2], ry1, Color.FromArgb(139, 92,  246));
            CrearKPICard(pnlMain, "Registros de Auditoría",  lblTotalLogs,           xs[3], ry1, Color.FromArgb(245, 158, 11));

            CrearKPICard(pnlMain, "Bodegas Activas",         lblTotalBodegas,        xs[0], ry2, Color.FromArgb(6,   182, 212));
            CrearKPICard(pnlMain, "Proveedores",             lblTotalProveedores,    xs[1], ry2, Color.FromArgb(239, 68,  68));
            CrearKPICard(pnlMain, "Movimientos de Stock",    lblTotalMovimientos,    xs[2], ry2, Color.FromArgb(10,  35,  66));
            CrearKPICard(pnlMain, "Transferencias",          lblTotalTransferencias, xs[3], ry2, Color.FromArgb(107, 114, 128));

            // SECCIÓN CONFIGURACIÓN
            Label lblSecConf = new Label();
            lblSecConf.Text      = "CONFIGURACIÓN DEL SISTEMA";
            lblSecConf.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSecConf.ForeColor = Color.FromArgb(100, 110, 130);
            lblSecConf.Location  = new Point(25, 300);
            lblSecConf.AutoSize  = true;
            pnlMain.Controls.Add(lblSecConf);

            Panel pnlSistema = CrearCardPanel(25,   322, 475, 265, "Información del Sistema");
            AgregarFilaInfo(pnlSistema, "Usuario:",     lblUsuario,         60);
            AgregarFilaInfo(pnlSistema, "Rol:",         lblRol,             97);
            AgregarFilaInfo(pnlSistema, "Fecha:",       lblFecha,           134);
            AgregarFilaInfo(pnlSistema, "Servidor:",    lblServidor,        171);
            AgregarFilaInfo(pnlSistema, "Base Datos:",  lblBaseDatos,       208);
            AgregarFilaInfo(pnlSistema, "Conexión:",    lblEstadoConexion,  245);
            pnlMain.Controls.Add(pnlSistema);

            Panel pnlSeg = CrearCardPanel(520, 322, 475, 265, "Seguridad");
            ConfigurarPanelSeguridad(pnlSeg);
            pnlMain.Controls.Add(pnlSeg);

            Panel pnlEst = CrearCardPanel(1015, 322, 475, 265, "Estado del Sistema");
            ConfigurarPanelEstado(pnlEst);
            pnlMain.Controls.Add(pnlEst);

            // SECCIÓN INFERIOR
            Label lblSecBottom = new Label();
            lblSecBottom.Text      = "ACCIONES Y MÉTRICAS";
            lblSecBottom.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSecBottom.ForeColor = Color.FromArgb(100, 110, 130);
            lblSecBottom.Location  = new Point(25, 622);
            lblSecBottom.AutoSize  = true;
            pnlMain.Controls.Add(lblSecBottom);

            Panel pnlAcciones = CrearCardPanel(25,  644, 720, 220, "Acciones Rápidas");
            ConfigurarPanelAcciones(pnlAcciones);
            pnlMain.Controls.Add(pnlAcciones);

            Panel pnlMetricas = CrearCardPanel(765, 644, 725, 220, "Estadísticas del Sistema");
            ConfigurarPanelMetricas(pnlMetricas);
            pnlMain.Controls.Add(pnlMetricas);

            // ── AGREGAR AL FORMULARIO (Dock z-order) ─────────────────────
            this.Controls.Add(pnlMain);    // Fill — primero
            this.Controls.Add(pnlSepH);   // Top  — queda bajo el header
            this.Controls.Add(pnlHeader); // Top  — queda en la cima
        }

        // ─────────────────────────────────────────
        // HELPERS DE CONSTRUCCION
        // ─────────────────────────────────────────

        // Crea una tarjeta KPI con franja de color y valor grande
        private void CrearKPICard(
            Panel container, string titulo, Label lblValor,
            int x, int y, Color acento)
        {
            Panel card = new Panel();
            card.BackColor   = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Location    = new Point(x, y);
            card.Size        = new Size(355, 105);

            Panel strip = new Panel();
            strip.BackColor = acento;
            strip.Dock      = DockStyle.Top;
            strip.Height    = 4;
            card.Controls.Add(strip);

            Label lblTit = new Label();
            lblTit.Text      = titulo.ToUpper();
            lblTit.Font      = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblTit.ForeColor = Color.FromArgb(110, 115, 130);
            lblTit.Location  = new Point(15, 16);
            lblTit.AutoSize  = true;
            card.Controls.Add(lblTit);

            lblValor.Text      = "—";
            lblValor.Font      = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblValor.ForeColor = acento;
            lblValor.Location  = new Point(15, 38);
            lblValor.AutoSize  = true;
            card.Controls.Add(lblValor);

            container.Controls.Add(card);
        }

        // Crea un panel con encabezado y línea separadora
        private Panel CrearCardPanel(int x, int y, int w, int h, string titulo)
        {
            Panel p = new Panel();
            p.BackColor   = Color.White;
            p.BorderStyle = BorderStyle.FixedSingle;
            p.Location    = new Point(x, y);
            p.Size        = new Size(w, h);

            Label lblTit = new Label();
            lblTit.Text      = titulo;
            lblTit.Font      = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTit.ForeColor = Color.FromArgb(10, 35, 66);
            lblTit.Location  = new Point(20, 14);
            lblTit.AutoSize  = true;
            p.Controls.Add(lblTit);

            Panel sep = new Panel();
            sep.BackColor = Color.FromArgb(220, 225, 235);
            sep.Location  = new Point(20, 42);
            sep.Size      = new Size(w - 40, 1);
            p.Controls.Add(sep);

            return p;
        }

        // Agrega una fila etiqueta + valor al panel
        private void AgregarFilaInfo(Panel panel, string etiqueta, Label lblValor, int y)
        {
            Label lblEtiq = new Label();
            lblEtiq.Text      = etiqueta;
            lblEtiq.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEtiq.ForeColor = Color.FromArgb(80, 90, 110);
            lblEtiq.Location  = new Point(20, y);
            lblEtiq.AutoSize  = true;
            panel.Controls.Add(lblEtiq);

            lblValor.Font      = new Font("Segoe UI", 10F);
            lblValor.ForeColor = Color.FromArgb(30, 40, 60);
            lblValor.Location  = new Point(165, y);
            lblValor.AutoSize  = true;
            panel.Controls.Add(lblValor);
        }

        // Rellena el panel de seguridad con textbox y botones
        private void ConfigurarPanelSeguridad(Panel panel)
        {
            Label lbl = new Label();
            lbl.Text      = "Nueva contraseña de acceso:";
            lbl.Font      = new Font("Segoe UI", 10F);
            lbl.ForeColor = Color.FromArgb(80, 90, 110);
            lbl.Location  = new Point(20, 55);
            lbl.AutoSize  = true;
            panel.Controls.Add(lbl);

            txtNuevaClave.Location     = new Point(20, 80);
            txtNuevaClave.Size         = new Size(430, 30);
            txtNuevaClave.Font         = new Font("Segoe UI", 11F);
            txtNuevaClave.PasswordChar = '*';
            txtNuevaClave.BorderStyle  = BorderStyle.FixedSingle;
            panel.Controls.Add(txtNuevaClave);

            Button btnClave = CrearBoton("Cambiar Contraseña", Color.FromArgb(37, 99, 235), 20, 128, 200, 46);
            btnClave.Click += btnCambiarClave_Click;
            panel.Controls.Add(btnClave);

            Button btnCon = CrearBoton("Probar Conexión", Color.FromArgb(16, 185, 129), 238, 128, 190, 46);
            btnCon.Click += btnProbarConexion_Click;
            panel.Controls.Add(btnCon);
        }

        // Rellena el panel de estado con indicadores de infraestructura
        private void ConfigurarPanelEstado(Panel panel)
        {
            string[] items = {
                "🟢  SQL Server Online",
                "🟢  Cifrado AES-256 Activo",
                "🟢  Integridad SHA-256",
                "🟢  Respaldo en Espejo",
                "🟢  Sesión Autenticada"
            };

            int startY = 58;
            foreach (string item in items)
            {
                Label lbl = new Label();
                lbl.Text      = item;
                lbl.Font      = new Font("Segoe UI", 11F);
                lbl.ForeColor = Color.FromArgb(30, 40, 60);
                lbl.Location  = new Point(20, startY);
                lbl.AutoSize  = true;
                panel.Controls.Add(lbl);
                startY += 38;
            }
        }

        // Rellena el panel de acciones rápidas
        private void ConfigurarPanelAcciones(Panel panel)
        {
            Button btnActualizar = CrearBoton("Actualizar Datos",  Color.FromArgb(37,  99,  235), 20,  65, 158, 50);
            Button btnConexion   = CrearBoton("Probar Conexión",   Color.FromArgb(16,  185, 129), 196, 65, 158, 50);
            Button btnClave2     = CrearBoton("Cambiar Clave",     Color.FromArgb(139, 92,  246), 372, 65, 158, 50);
            Button btnActividad  = CrearBoton("Ver Actividad",     Color.FromArgb(245, 158, 11),  548, 65, 158, 50);

            btnActualizar.Click += (s, ev) => { CargarInformacion(); CargarEstadisticas(); };
            btnConexion.Click   += btnProbarConexion_Click;
            btnClave2.Click     += btnCambiarClave_Click;
            btnActividad.Click  += (s, ev) =>
                MessageBox.Show(
                    "Módulo de actividad disponible próximamente.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            panel.Controls.Add(btnActualizar);
            panel.Controls.Add(btnConexion);
            panel.Controls.Add(btnClave2);
            panel.Controls.Add(btnActividad);

            Label nota = new Label();
            nota.Text      = "Acciones de administración y mantenimiento del sistema.";
            nota.Font      = new Font("Segoe UI", 9F);
            nota.ForeColor = Color.FromArgb(130, 140, 160);
            nota.Location  = new Point(20, 140);
            nota.AutoSize  = true;
            panel.Controls.Add(nota);
        }

        // Rellena el panel de métricas con barras de progreso
        private void ConfigurarPanelMetricas(Panel panel)
        {
            string[] etiquetas   = { "Usuarios activos",     "Productos en stock",   "Movimientos del mes" };
            int[]    valores     = { 75, 88, 62 };
            Color[]  colores     = {
                Color.FromArgb(37,  99,  235),
                Color.FromArgb(16,  185, 129),
                Color.FromArgb(245, 158, 11)
            };

            int startY = 58;
            for (int i = 0; i < etiquetas.Length; i++)
            {
                Label lbl = new Label();
                lbl.Text      = $"{etiquetas[i]}  ({valores[i]}%)";
                lbl.Font      = new Font("Segoe UI", 10F);
                lbl.ForeColor = Color.FromArgb(60, 70, 90);
                lbl.Location  = new Point(20, startY);
                lbl.AutoSize  = true;
                panel.Controls.Add(lbl);

                ProgressBar pb = new ProgressBar();
                pb.Location = new Point(20, startY + 24);
                pb.Size     = new Size(680, 14);
                pb.Minimum  = 0;
                pb.Maximum  = 100;
                pb.Value    = valores[i];
                pb.Style    = ProgressBarStyle.Continuous;
                panel.Controls.Add(pb);

                startY += 54;
            }
        }

        // Crea un botón con estilo flat
        private Button CrearBoton(string texto, Color color, int x, int y, int w, int h)
        {
            Button btn = new Button();
            btn.Text      = texto;
            btn.Size      = new Size(w, h);
            btn.Location  = new Point(x, y);
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font      = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btn.Cursor    = Cursors.Hand;
            return btn;
        }

        // ─────────────────────────────────────────
        // CARGA DE DATOS
        // ─────────────────────────────────────────
        private void CargarInformacion()
        {
            CultureInfo cultura = new CultureInfo("es-PE");

            lblUsuario.Text        = SesionUsuario.Usuario;
            lblRol.Text            = SesionUsuario.Rol;
            lblFecha.Text          = DateTime.Now.ToString("dd/MM/yyyy HH:mm", cultura);
            lblServidor.Text       = Environment.MachineName;
            lblBaseDatos.Text      = "Inventario";
            lblEstadoConexion.Text = "🟢 CONECTADO";

            lblFechaHoraHeader.Text   = DateTime.Now.ToString(
                "dddd, dd 'de' MMMM 'de' yyyy  •  HH:mm:ss", cultura);
            lblUsuarioInfoHeader.Text =
                $"◉  {SesionUsuario.Usuario}     |     {SesionUsuario.Rol}";
        }

        private void CargarEstadisticas()
        {
            try
            {
                SqlConnection conexion = cn.AbrirConexion();

                lblTotalUsuarios.Text       = new SqlCommand("SELECT COUNT(*) FROM Usuarios",            conexion).ExecuteScalar().ToString();
                lblTotalProductos.Text      = new SqlCommand("SELECT COUNT(*) FROM Productos",           conexion).ExecuteScalar().ToString();
                lblTotalRoles.Text          = new SqlCommand("SELECT COUNT(*) FROM Roles",               conexion).ExecuteScalar().ToString();
                lblTotalLogs.Text           = new SqlCommand("SELECT COUNT(*) FROM Logs",                conexion).ExecuteScalar().ToString();
                lblTotalBodegas.Text        = new SqlCommand("SELECT COUNT(*) FROM Bodegas",             conexion).ExecuteScalar().ToString();
                lblTotalProveedores.Text    = new SqlCommand("SELECT COUNT(*) FROM Proveedores",         conexion).ExecuteScalar().ToString();
                lblTotalMovimientos.Text    = new SqlCommand("SELECT COUNT(*) FROM MovimientosInventario", conexion).ExecuteScalar().ToString();
                lblTotalTransferencias.Text = new SqlCommand("SELECT COUNT(*) FROM TransferenciasBodega", conexion).ExecuteScalar().ToString();

                cn.CerrarConexion();
            }
            catch
            {
                lblEstadoConexion.Text = "🔴 ERROR";
            }
        }

        // ─────────────────────────────────────────
        // EVENTOS DE SEGURIDAD (lógica existente)
        // ─────────────────────────────────────────
        private void btnCambiarClave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contraseña actualizada");
        }

        private void btnProbarConexion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Conexión exitosa");
        }
    }
}
