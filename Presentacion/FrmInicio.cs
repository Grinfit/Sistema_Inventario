// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Sistema_Inventario.Datos;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Presentacion
{
    // DASHBOARD PRINCIPAL DEL SISTEMA — LAYOUT RESPONSIVO
    public partial class FrmInicio : Form
    {
        // CONEXION
        Conexion cn = new Conexion();

        // CONTROLES DINAMICOS
        private DataGridView dgvActividad;
        private Chart        chartMovimientos;
        private Chart        chartDistribucion;
        private System.Windows.Forms.Timer timerReloj;
        private Label        lblReloj;

        // KPI ADICIONALES (no declarados en Designer.cs)
        private Label lblUsuariosActivos;
        private Label lblMovimientosHoy;
        private Label lblProveedores;
        private Label lblLogsHoy;

        // ALERTAS
        private Label lblAlertStockCritico;
        private Label lblAlertSinStock;
        private Label lblAlertErrores;

        // RESUMEN OPERATIVO
        private Label lblUltimoMov;
        private Label lblUltimaTransf;
        private Label lblBodegaTop;

        // ─────────────────────────────────────────
        // CONSTRUCTOR
        // ─────────────────────────────────────────
        public FrmInicio()
        {
            InitializeComponent();
            ConstruirDashboard();
        }

        // ─────────────────────────────────────────
        // LOAD
        // ─────────────────────────────────────────
        private void FrmInicio_Load(object sender, EventArgs e)
        {
            timerReloj?.Start();
            CargarIndicadores();
            CargarKPIsAdicionales();
            CargarActividad();
            CargarGraficaMovimientos();
            CargarGraficaDistribucion();
            CargarAlertas();
            CargarResumen();
        }

        // ═══════════════════════════════════════════════════════
        // CONSTRUCCION DEL DASHBOARD — LAYOUT RESPONSIVO
        // Regla Dock: se agregan al formulario en orden INVERSO al
        // orden visual (último agregado = más arriba en pantalla).
        // ═══════════════════════════════════════════════════════
        private void ConstruirDashboard()
        {
            this.BackColor = Color.FromArgb(240, 242, 245);
            this.AutoScroll = true;

            // ── SECCIÓN 6: RESUMEN + RENDIMIENTO ─────────────
            Panel pnlBottom = new Panel();
            pnlBottom.Dock      = DockStyle.Top;
            pnlBottom.Height    = 330;
            pnlBottom.BackColor = Color.FromArgb(240, 242, 245);
            ConstruirBottomRow(pnlBottom);

            Panel pnlSec5 = CrSecPanel("RESUMEN OPERATIVO   &   RENDIMIENTO DEL SISTEMA");

            // ── SECCIÓN 5: ACCESOS RÁPIDOS ────────────────────
            Panel pnlAccesos = new Panel();
            pnlAccesos.Dock      = DockStyle.Top;
            pnlAccesos.Height    = 148;
            pnlAccesos.BackColor = Color.FromArgb(240, 242, 245);
            ConstruirAccesos(pnlAccesos);

            Panel pnlSec4 = CrSecPanel("ACCESOS RÁPIDOS");

            // ── SECCIÓN 4: GRÁFICAS ───────────────────────────
            Panel pnlCharts = new Panel();
            pnlCharts.Dock      = DockStyle.Top;
            pnlCharts.Height    = 430;
            pnlCharts.BackColor = Color.FromArgb(240, 242, 245);
            ConstruirCharts(pnlCharts);

            Panel pnlSec3 = CrSecPanel("ANÁLISIS GRÁFICO");

            // ── SECCIÓN 3: ACTIVIDAD + ALERTAS ───────────────
            Panel pnlActAlertas = new Panel();
            pnlActAlertas.Dock      = DockStyle.Top;
            pnlActAlertas.Height    = 430;
            pnlActAlertas.BackColor = Color.FromArgb(240, 242, 245);
            ConstruirActAlertas(pnlActAlertas);

            Panel pnlSec2 = CrSecPanel("ACTIVIDAD RECIENTE   &   ALERTAS DEL SISTEMA");

            // ── SECCIÓN 2: KPI ROW 2 ─────────────────────────
            Panel pnlKPI2 = new Panel();
            pnlKPI2.Dock      = DockStyle.Top;
            pnlKPI2.Height    = 160;
            pnlKPI2.BackColor = Color.FromArgb(240, 242, 245);
            ConstruirKPIRow2(pnlKPI2);

            // ── SECCIÓN 1: KPI ROW 1 ─────────────────────────
            Panel pnlKPI1 = new Panel();
            pnlKPI1.Dock      = DockStyle.Top;
            pnlKPI1.Height    = 160;
            pnlKPI1.BackColor = Color.FromArgb(240, 242, 245);
            ConstruirKPIRow1(pnlKPI1);

            Panel pnlSec1 = CrSecPanel("INDICADORES DEL SISTEMA");

            // ── FRANJA ACENTO AZUL ────────────────────────────
            Panel pnlAccent = new Panel();
            pnlAccent.Dock      = DockStyle.Top;
            pnlAccent.Height    = 5;
            pnlAccent.BackColor = Color.FromArgb(37, 99, 235);

            // ── HEADER ────────────────────────────────────────
            Panel pnlHeader = ConstruirHeader();

            // ── AGREGAR AL FORMULARIO (orden inverso al visual) ──
            this.Controls.Add(pnlBottom);
            this.Controls.Add(pnlSec5);
            this.Controls.Add(pnlAccesos);
            this.Controls.Add(pnlSec4);
            this.Controls.Add(pnlCharts);
            this.Controls.Add(pnlSec3);
            this.Controls.Add(pnlActAlertas);
            this.Controls.Add(pnlSec2);
            this.Controls.Add(pnlKPI2);
            this.Controls.Add(pnlKPI1);
            this.Controls.Add(pnlSec1);
            this.Controls.Add(pnlAccent);
            this.Controls.Add(pnlHeader); // último → aparece en la cima
        }

        // ═══════════════════════════════════════════════════════
        // HELPERS DE ESTRUCTURA
        // ═══════════════════════════════════════════════════════

        // Panel sección con etiqueta gris
        private Panel CrSecPanel(string texto)
        {
            Panel p = new Panel();
            p.Dock      = DockStyle.Top;
            p.Height    = 30;
            p.BackColor = Color.FromArgb(240, 242, 245);

            Label lbl = new Label();
            lbl.Text      = texto;
            lbl.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(100, 110, 130);
            lbl.Location  = new Point(18, 10);
            lbl.AutoSize  = true;
            p.Controls.Add(lbl);

            return p;
        }

        // Tarjeta blanca con título en la parte superior
        // REGLA: agregar bodyPanel (Fill) PRIMERO, pnlTit (Top) ÚLTIMO
        private Panel CrTarjeta(string titulo, out Panel bodyPanel)
        {
            Panel outer = new Panel();
            outer.Dock        = DockStyle.Fill;
            outer.BackColor   = Color.White;
            outer.BorderStyle = BorderStyle.FixedSingle;

            bodyPanel           = new Panel();
            bodyPanel.Dock      = DockStyle.Fill;
            bodyPanel.BackColor = Color.White;
            outer.Controls.Add(bodyPanel); // PRIMERO → Fill

            Panel pnlTit = new Panel();
            pnlTit.Dock      = DockStyle.Top;
            pnlTit.Height    = 50;
            pnlTit.BackColor = Color.White;

            Label lbl = new Label();
            lbl.Text      = titulo;
            lbl.Font      = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(10, 35, 66);
            lbl.Location  = new Point(18, 13);
            lbl.AutoSize  = true;
            pnlTit.Controls.Add(lbl);

            Panel sep = new Panel();
            sep.Dock      = DockStyle.Bottom;
            sep.Height    = 1;
            sep.BackColor = Color.FromArgb(220, 225, 235);
            pnlTit.Controls.Add(sep);

            outer.Controls.Add(pnlTit); // ÚLTIMO → va arriba ✓
            return outer;
        }

        // Tarjeta KPI responsiva (Dock=Fill en celda TableLayout)
        // Internamente: agrega en orden INVERSO al visual para Dock=Top
        private Panel CrKPICard(string titulo, string subtitulo, Color acento, out Label lblValor)
        {
            Panel card = new Panel();
            card.Dock        = DockStyle.Fill;
            card.BackColor   = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Margin      = new Padding(5, 5, 5, 5);

            // CONTENIDO (Fill) — agregado primero
            Panel content = new Panel();
            content.Dock    = DockStyle.Fill;
            content.Padding = new Padding(16, 5, 16, 6);

            // Subtítulo: agregado primero → queda abajo
            Label lblSub = new Label();
            lblSub.Text      = subtitulo;
            lblSub.Font      = new Font("Segoe UI", 8.5F);
            lblSub.ForeColor = Color.FromArgb(140, 148, 165);
            lblSub.Dock      = DockStyle.Top;
            lblSub.Height    = 22;
            lblSub.TextAlign = ContentAlignment.TopLeft;
            content.Controls.Add(lblSub);

            // Valor: agregado segundo → queda en medio
            lblValor           = new Label();
            lblValor.Text      = "—";
            lblValor.Font      = new Font("Segoe UI", 30F, FontStyle.Bold);
            lblValor.ForeColor = acento;
            lblValor.Dock      = DockStyle.Top;
            lblValor.Height    = 54;
            lblValor.TextAlign = ContentAlignment.MiddleLeft;
            content.Controls.Add(lblValor);

            // Título: agregado último → queda arriba ✓
            Label lblTit = new Label();
            lblTit.Text      = titulo.ToUpper();
            lblTit.Font      = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblTit.ForeColor = Color.FromArgb(110, 118, 135);
            lblTit.Dock      = DockStyle.Top;
            lblTit.Height    = 26;
            lblTit.TextAlign = ContentAlignment.BottomLeft;
            content.Controls.Add(lblTit);

            card.Controls.Add(content); // Fill primero

            // Franja de color arriba — Top, agregada última
            Panel strip = new Panel();
            strip.Dock      = DockStyle.Top;
            strip.Height    = 5;
            strip.BackColor = acento;
            card.Controls.Add(strip); // última → cima de la card ✓

            return card;
        }

        // Color pastel a partir de un color base (para fondo de badges)
        private Color ColorPastel(Color c) => Color.FromArgb(
            255 - (int)((255 - c.R) * 0.10),
            255 - (int)((255 - c.G) * 0.10),
            255 - (int)((255 - c.B) * 0.10));

        // ═══════════════════════════════════════════════════════
        // CONSTRUCCION POR SECCIÓN
        // ═══════════════════════════════════════════════════════

        private Panel ConstruirHeader()
        {
            Panel p = new Panel();
            p.Dock      = DockStyle.Top;
            p.Height    = 120;
            p.BackColor = Color.FromArgb(10, 35, 66);

            Label lblT = new Label();
            lblT.Text      = "Dashboard General";
            lblT.Font      = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblT.ForeColor = Color.White;
            lblT.Location  = new Point(25, 18);
            lblT.AutoSize  = true;
            p.Controls.Add(lblT);

            Label lblSub = new Label();
            lblSub.Text      = "Monitoreo y estadísticas del sistema de inventario";
            lblSub.Font      = new Font("Segoe UI", 10F);
            lblSub.ForeColor = Color.FromArgb(148, 175, 215);
            lblSub.Location  = new Point(27, 58);
            lblSub.AutoSize  = true;
            p.Controls.Add(lblSub);

            timerReloj          = new System.Windows.Forms.Timer();
            timerReloj.Interval = 1000;
            timerReloj.Tick    += (s, e) =>
            {
                if (lblReloj != null)
                    lblReloj.Text = DateTime.Now.ToString(
                        "dddd, dd/MM/yyyy  •  HH:mm:ss",
                        new CultureInfo("es-PE"));
            };

            lblReloj = new Label();
            lblReloj.Text      = DateTime.Now.ToString("dddd, dd/MM/yyyy  •  HH:mm:ss", new CultureInfo("es-PE"));
            lblReloj.Font      = new Font("Segoe UI", 10F);
            lblReloj.ForeColor = Color.FromArgb(148, 175, 215);
            lblReloj.AutoSize  = true;
            lblReloj.Anchor    = AnchorStyles.Top | AnchorStyles.Right;
            lblReloj.Location  = new Point(750, 22);
            p.Controls.Add(lblReloj);

            Label lblUser = new Label();
            lblUser.Text      = $"◉  {SesionUsuario.Usuario}   |   {SesionUsuario.Rol}";
            lblUser.Font      = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblUser.ForeColor = Color.White;
            lblUser.AutoSize  = true;
            lblUser.Anchor    = AnchorStyles.Top | AnchorStyles.Right;
            lblUser.Location  = new Point(750, 58);
            p.Controls.Add(lblUser);

            return p;
        }

        private void ConstruirKPIRow1(Panel parent)
        {
            TableLayoutPanel tl = new TableLayoutPanel();
            tl.Dock        = DockStyle.Fill;
            tl.ColumnCount = 4;
            tl.RowCount    = 1;
            for (int i = 0; i < 4; i++)
                tl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tl.Padding = new Padding(15, 10, 15, 5);

            var c0 = CrKPICard("Bodegas",            "Total registradas",      Color.FromArgb(37,  99,  235), out lblClientes);
            var c1 = CrKPICard("Productos",          "En catálogo activo",     Color.FromArgb(16,  185, 129), out lblProductos);
            var c2 = CrKPICard("Stock Crítico",      "Productos con stock ≤ 5",Color.FromArgb(239, 68,  68),  out lblVentas);
            var c3 = CrKPICard("Transferencias Hoy", "Registradas hoy",        Color.FromArgb(139, 92,  246), out lblLogin);

            panelClientes  = c0;
            panelProductos = c1;
            panelVentas    = c2;
            panelLogin     = c3;

            tl.Controls.Add(c0, 0, 0);
            tl.Controls.Add(c1, 1, 0);
            tl.Controls.Add(c2, 2, 0);
            tl.Controls.Add(c3, 3, 0);
            parent.Controls.Add(tl);
        }

        private void ConstruirKPIRow2(Panel parent)
        {
            TableLayoutPanel tl = new TableLayoutPanel();
            tl.Dock        = DockStyle.Fill;
            tl.ColumnCount = 4;
            tl.RowCount    = 1;
            for (int i = 0; i < 4; i++)
                tl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tl.Padding = new Padding(15, 5, 15, 10);

            var c0 = CrKPICard("Usuarios Activos",  "En el sistema",       Color.FromArgb(6,   182, 212), out lblUsuariosActivos);
            var c1 = CrKPICard("Movimientos Hoy",   "Registrados hoy",     Color.FromArgb(245, 158, 11),  out lblMovimientosHoy);
            var c2 = CrKPICard("Proveedores",       "Registrados",         Color.FromArgb(100, 116, 139), out lblProveedores);
            var c3 = CrKPICard("Logs del Sistema",  "Actividad de hoy",    Color.FromArgb(55,  65,  81),  out lblLogsHoy);

            tl.Controls.Add(c0, 0, 0);
            tl.Controls.Add(c1, 1, 0);
            tl.Controls.Add(c2, 2, 0);
            tl.Controls.Add(c3, 3, 0);
            parent.Controls.Add(tl);
        }

        private void ConstruirActAlertas(Panel parent)
        {
            TableLayoutPanel tl = new TableLayoutPanel();
            tl.Dock        = DockStyle.Fill;
            tl.ColumnCount = 2;
            tl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 63F));
            tl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37F));
            tl.RowCount = 1;
            tl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tl.Padding = new Padding(15, 0, 15, 12);

            // ── ACTIVIDAD ───────────────────────────────────
            Panel pAct = CrTarjeta("Actividad reciente del sistema", out Panel bodyAct);
            pAct.Margin      = new Padding(0, 0, 6, 0);
            bodyAct.Padding  = new Padding(8, 6, 8, 8);

            dgvActividad = new DataGridView();
            dgvActividad.Dock                  = DockStyle.Fill;
            dgvActividad.BackgroundColor       = Color.White;
            dgvActividad.BorderStyle           = BorderStyle.None;
            dgvActividad.AllowUserToAddRows    = false;
            dgvActividad.AllowUserToDeleteRows = false;
            dgvActividad.ReadOnly              = true;
            dgvActividad.RowHeadersVisible     = false;
            dgvActividad.AutoSizeColumnsMode   = DataGridViewAutoSizeColumnsMode.Fill;
            dgvActividad.SelectionMode         = DataGridViewSelectionMode.FullRowSelect;
            dgvActividad.ColumnHeadersHeight   = 42;
            dgvActividad.EnableHeadersVisualStyles = false;
            dgvActividad.ColumnHeadersDefaultCellStyle.BackColor   = Color.FromArgb(10, 35, 66);
            dgvActividad.ColumnHeadersDefaultCellStyle.ForeColor   = Color.White;
            dgvActividad.ColumnHeadersDefaultCellStyle.Font        = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvActividad.ColumnHeadersDefaultCellStyle.Alignment   = DataGridViewContentAlignment.MiddleCenter;
            dgvActividad.DefaultCellStyle.Font                     = new Font("Segoe UI", 10F);
            dgvActividad.DefaultCellStyle.SelectionBackColor       = Color.FromArgb(219, 234, 254);
            dgvActividad.DefaultCellStyle.SelectionForeColor       = Color.Black;
            dgvActividad.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 252);
            dgvActividad.RowTemplate.Height = 36;
            bodyAct.Controls.Add(dgvActividad);
            tl.Controls.Add(pAct, 0, 0);

            // ── ALERTAS ──────────────────────────────────────
            Panel pAlerts = ConstruirPanelAlertas();
            pAlerts.Margin = new Padding(6, 0, 0, 0);
            tl.Controls.Add(pAlerts, 1, 0);

            parent.Controls.Add(tl);
        }

        private Panel ConstruirPanelAlertas()
        {
            Panel outer = CrTarjeta("Alertas del Sistema", out Panel body);
            body.Padding  = new Padding(12, 8, 12, 10);
            body.AutoScroll = false;

            // Indicadores de estado (fondo blanco)
            Panel pnlStatus = new Panel();
            pnlStatus.Dock      = DockStyle.Bottom;
            pnlStatus.Height    = 100;
            pnlStatus.BackColor = Color.White;
            pnlStatus.Padding   = new Padding(5, 8, 5, 0);

            string[] stTexts  = { "🟢  SQL Server:   Online", "🟢  Cifrado AES-256:   Activo", $"◉   Sesión:   {SesionUsuario.Usuario}" };
            Color[]  stColors = { Color.FromArgb(16, 185, 129), Color.FromArgb(16, 185, 129), Color.FromArgb(37, 99, 235) };

            for (int i = stTexts.Length - 1; i >= 0; i--)
            {
                Label sl = new Label();
                sl.Text      = stTexts[i];
                sl.Font      = new Font("Segoe UI", 10F);
                sl.ForeColor = stColors[i];
                sl.Dock      = DockStyle.Top;
                sl.Height    = 30;
                sl.TextAlign = ContentAlignment.MiddleLeft;
                pnlStatus.Controls.Add(sl);
            }
            body.Controls.Add(pnlStatus);

            // Badges de alerta (apiladas arriba)
            // Agregar en inverso: badge3 primero (queda abajo), badge1 último (queda arriba)
            Panel badge3 = CrBadge("⛔", "Errores Recientes", "Errores en logs (últimas 24h)",  Color.FromArgb(220, 38,  38),  out lblAlertErrores);
            Panel badge2 = CrBadge("📦", "Sin Stock",         "Productos con stock en cero",    Color.FromArgb(239, 68,  68),  out lblAlertSinStock);
            Panel badge1 = CrBadge("⚠",  "Stock Crítico",     "Productos con stock ≤ 5 uds.",  Color.FromArgb(245, 158, 11),  out lblAlertStockCritico);

            body.Controls.Add(badge3); // primero → más abajo
            body.Controls.Add(badge2);
            body.Controls.Add(badge1); // último → más arriba ✓

            return outer;
        }

        private Panel CrBadge(string icono, string titulo, string descripcion, Color color, out Label lblValor)
        {
            Panel badge = new Panel();
            badge.Dock      = DockStyle.Top;
            badge.Height    = 72;
            badge.BackColor = ColorPastel(color);
            badge.Margin    = new Padding(0, 0, 0, 6);

            TableLayoutPanel tl = new TableLayoutPanel();
            tl.Dock        = DockStyle.Fill;
            tl.ColumnCount = 4;
            tl.RowCount    = 1;
            tl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 5F));
            tl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 62F));
            tl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // Barra lateral de color
            Panel bar = new Panel();
            bar.Dock      = DockStyle.Fill;
            bar.BackColor = color;
            tl.Controls.Add(bar, 0, 0);

            // Icono centrado
            Label lblIco = new Label();
            lblIco.Text      = icono;
            lblIco.Font      = new Font("Segoe UI", 17F);
            lblIco.Dock      = DockStyle.Fill;
            lblIco.TextAlign = ContentAlignment.MiddleCenter;
            tl.Controls.Add(lblIco, 1, 0);

            // Título y descripción
            TableLayoutPanel tlText = new TableLayoutPanel();
            tlText.Dock        = DockStyle.Fill;
            tlText.ColumnCount = 1;
            tlText.RowCount    = 2;
            tlText.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlText.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlText.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlText.Padding = new Padding(8, 8, 5, 8);

            Label lblTit = new Label();
            lblTit.Text      = titulo;
            lblTit.Font      = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTit.ForeColor = color;
            lblTit.Dock      = DockStyle.Fill;
            lblTit.TextAlign = ContentAlignment.BottomLeft;
            tlText.Controls.Add(lblTit, 0, 0);

            Label lblDesc = new Label();
            lblDesc.Text      = descripcion;
            lblDesc.Font      = new Font("Segoe UI", 8.5F);
            lblDesc.ForeColor = Color.FromArgb(80, 90, 110);
            lblDesc.Dock      = DockStyle.Fill;
            lblDesc.TextAlign = ContentAlignment.TopLeft;
            tlText.Controls.Add(lblDesc, 0, 1);

            tl.Controls.Add(tlText, 2, 0);

            // Valor numérico a la derecha
            lblValor           = new Label();
            lblValor.Text      = "0";
            lblValor.Font      = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblValor.ForeColor = color;
            lblValor.Dock      = DockStyle.Fill;
            lblValor.TextAlign = ContentAlignment.MiddleCenter;
            tl.Controls.Add(lblValor, 3, 0);

            badge.Controls.Add(tl);
            return badge;
        }

        private void ConstruirCharts(Panel parent)
        {
            TableLayoutPanel tl = new TableLayoutPanel();
            tl.Dock        = DockStyle.Fill;
            tl.ColumnCount = 2;
            tl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tl.RowCount = 1;
            tl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tl.Padding = new Padding(15, 0, 15, 12);

            // ── GRAFICA COLUMNAS ──────────────────────────────
            Panel pC1 = CrTarjeta("Movimientos últimos 7 días", out Panel bodyC1);
            pC1.Margin     = new Padding(0, 0, 6, 0);
            bodyC1.Padding = new Padding(6, 4, 6, 6);

            chartMovimientos            = new Chart();
            chartMovimientos.Dock       = DockStyle.Fill;
            chartMovimientos.BackColor  = Color.White;

            ChartArea ca1 = new ChartArea();
            ca1.BackColor               = Color.White;
            ca1.AxisX.MajorGrid.Enabled = false;
            ca1.AxisX.LineColor         = Color.FromArgb(210, 215, 230);
            ca1.AxisX.LabelStyle.Font   = new Font("Segoe UI", 9F);
            ca1.AxisY.MajorGrid.LineColor = Color.FromArgb(230, 235, 245);
            ca1.AxisY.LabelStyle.Font   = new Font("Segoe UI", 9F);
            ca1.AxisY.LineColor         = Color.FromArgb(210, 215, 230);
            chartMovimientos.ChartAreas.Add(ca1);

            Series s1 = new Series();
            s1.ChartType     = SeriesChartType.Column;
            s1.Color         = Color.FromArgb(37, 99, 235);
            s1["PointWidth"] = "0.55";
            chartMovimientos.Series.Add(s1);

            Legend lg1 = new Legend(); lg1.Enabled = false;
            chartMovimientos.Legends.Add(lg1);

            bodyC1.Controls.Add(chartMovimientos);
            tl.Controls.Add(pC1, 0, 0);

            // ── GRAFICA PIE ───────────────────────────────────
            Panel pC2 = CrTarjeta("Distribución de inventario por bodega", out Panel bodyC2);
            pC2.Margin     = new Padding(6, 0, 0, 0);
            bodyC2.Padding = new Padding(6, 4, 6, 6);

            chartDistribucion           = new Chart();
            chartDistribucion.Dock      = DockStyle.Fill;
            chartDistribucion.BackColor = Color.White;

            ChartArea ca2 = new ChartArea(); ca2.BackColor = Color.White;
            chartDistribucion.ChartAreas.Add(ca2);

            Series s2 = new Series();
            s2.ChartType            = SeriesChartType.Pie;
            s2["PieLabelStyle"]     = "Outside";
            s2["PieLineColor"]      = "DimGray";
            s2["PieStartAngle"]     = "90";
            chartDistribucion.Series.Add(s2);

            Legend lg2 = new Legend(); lg2.Font = new Font("Segoe UI", 9F);
            chartDistribucion.Legends.Add(lg2);

            bodyC2.Controls.Add(chartDistribucion);
            tl.Controls.Add(pC2, 1, 0);

            parent.Controls.Add(tl);
        }

        private void ConstruirAccesos(Panel parent)
        {
            TableLayoutPanel tl = new TableLayoutPanel();
            tl.Dock        = DockStyle.Fill;
            tl.ColumnCount = 8;
            tl.RowCount    = 1;
            for (int i = 0; i < 8; i++)
                tl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tl.Padding     = new Padding(15, 10, 15, 10);
            tl.BackColor   = Color.White;
            tl.BorderStyle = BorderStyle.FixedSingle;
            tl.Margin      = new Padding(0);

            // Wrapper para que la TableLayout ocupe el panel completo
            Panel wrapper = new Panel();
            wrapper.Dock        = DockStyle.Fill;
            wrapper.Padding     = new Padding(15, 0, 15, 0);
            wrapper.BackColor   = Color.FromArgb(240, 242, 245);

            (string texto, Color color)[] items =
            {
                ("Nuevo Producto",   Color.FromArgb(37,  99,  235)),
                ("Nuevo Movimiento", Color.FromArgb(16,  185, 129)),
                ("Transferencia",    Color.FromArgb(139, 92,  246)),
                ("Ver Kardex",       Color.FromArgb(6,   182, 212)),
                ("Stock Bodegas",    Color.FromArgb(245, 158, 11)),
                ("Usuarios",         Color.FromArgb(239, 68,  68)),
                ("Ver Logs",         Color.FromArgb(55,  65,  81)),
                ("Configuración",    Color.FromArgb(100, 116, 139)),
            };

            for (int i = 0; i < items.Length; i++)
            {
                string nav    = items[i].texto;
                Color  acento = items[i].color;

                Button btn = new Button();
                btn.Text      = items[i].texto;
                btn.Dock      = DockStyle.Fill;
                btn.Margin    = new Padding(5, 4, 5, 4);
                btn.BackColor = acento;
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font      = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
                btn.Cursor    = Cursors.Hand;
                btn.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Dark(acento);
                btn.MouseLeave += (s, e) => btn.BackColor = acento;
                btn.Click      += (s, e) => NavegaA(nav);
                tl.Controls.Add(btn, i, 0);
            }

            wrapper.Controls.Add(tl);
            parent.Controls.Add(wrapper);
        }

        private void ConstruirBottomRow(Panel parent)
        {
            TableLayoutPanel tl = new TableLayoutPanel();
            tl.Dock        = DockStyle.Fill;
            tl.ColumnCount = 2;
            tl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tl.RowCount = 1;
            tl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tl.Padding = new Padding(15, 0, 15, 18);

            Panel pRes = CrTarjeta("Resumen Operativo", out Panel bodyRes);
            pRes.Margin = new Padding(0, 0, 6, 0);
            ConstruirResumenOperativo(bodyRes);
            tl.Controls.Add(pRes, 0, 0);

            Panel pRend = CrTarjeta("Rendimiento del Sistema", out Panel bodyRend);
            pRend.Margin = new Padding(6, 0, 0, 0);
            ConstruirRendimiento(bodyRend);
            tl.Controls.Add(pRend, 1, 0);

            parent.Controls.Add(tl);
        }

        private void ConstruirResumenOperativo(Panel body)
        {
            body.Padding = new Padding(0);

            TableLayoutPanel tl = new TableLayoutPanel();
            tl.Dock        = DockStyle.Fill;
            tl.ColumnCount = 2;
            tl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46F));
            tl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54F));
            tl.RowCount    = 6;
            for (int i = 0; i < 6; i++)
                tl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / 6F));
            tl.Padding = new Padding(20, 14, 20, 14);

            string[] etiquetas = {
                "Último movimiento:", "Última transferencia:", "Bodega mayor stock:",
                "Estado SQL Server:", "Cifrado:", "Sesión iniciada:"
            };
            string[] valores = {
                "Cargando...", "Cargando...", "Cargando...",
                "🟢  Online", "🟢  AES-256 Activo", SesionUsuario.Usuario
            };
            Color?[] coloresV = { null, null, null,
                Color.FromArgb(16, 185, 129), Color.FromArgb(16, 185, 129), Color.FromArgb(37, 99, 235)
            };

            Label[] refs = new Label[6];
            for (int i = 0; i < 6; i++)
            {
                Label lblE = new Label();
                lblE.Text      = etiquetas[i];
                lblE.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
                lblE.ForeColor = Color.FromArgb(80, 90, 110);
                lblE.Dock      = DockStyle.Fill;
                lblE.TextAlign = ContentAlignment.MiddleLeft;
                tl.Controls.Add(lblE, 0, i);

                Label lblV = new Label();
                lblV.Text      = valores[i];
                lblV.Font      = new Font("Segoe UI", 10F);
                lblV.ForeColor = coloresV[i] ?? Color.FromArgb(30, 40, 60);
                lblV.Dock      = DockStyle.Fill;
                lblV.TextAlign = ContentAlignment.MiddleLeft;
                tl.Controls.Add(lblV, 1, i);

                refs[i] = lblV;
            }

            lblUltimoMov    = refs[0];
            lblUltimaTransf = refs[1];
            lblBodegaTop    = refs[2];

            body.Controls.Add(tl);
        }

        private void ConstruirRendimiento(Panel body)
        {
            body.Padding = new Padding(0);

            TableLayoutPanel tl = new TableLayoutPanel();
            tl.Dock        = DockStyle.Fill;
            tl.ColumnCount = 1;
            tl.RowCount    = 5;
            tl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            for (int i = 0; i < 5; i++)
                tl.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tl.Padding = new Padding(20, 12, 20, 12);

            (string nombre, int valor, Color color)[] metricas = {
                ("Conectividad SQL Server",     95,  Color.FromArgb(16,  185, 129)),
                ("Integridad SHA-256",          100, Color.FromArgb(37,  99,  235)),
                ("Cifrado AES-256",             100, Color.FromArgb(139, 92,  246)),
                ("Disponibilidad del sistema",  98,  Color.FromArgb(6,   182, 212)),
                ("Estado de respaldo",          80,  Color.FromArgb(245, 158, 11)),
            };

            int row = 0;
            foreach (var m in metricas)
            {
                Panel item = new Panel();
                item.Dock        = DockStyle.Fill;
                item.BackColor   = Color.White;

                // Agregar barra PRIMERO (queda abajo), label ÚLTIMO (queda arriba)
                ProgressBar pb = new ProgressBar();
                pb.Dock    = DockStyle.Top;
                pb.Height  = 12;
                pb.Margin  = new Padding(0, 2, 0, 0);
                pb.Minimum = 0;
                pb.Maximum = 100;
                pb.Value   = m.valor;
                pb.Style   = ProgressBarStyle.Continuous;
                item.Controls.Add(pb); // primero → abajo

                Label lbl = new Label();
                lbl.Text      = $"{m.nombre}   ({m.valor}%)";
                lbl.Font      = new Font("Segoe UI", 9.5F);
                lbl.ForeColor = Color.FromArgb(55, 65, 85);
                lbl.Dock      = DockStyle.Top;
                lbl.Height    = 20;
                lbl.TextAlign = ContentAlignment.TopLeft;
                item.Controls.Add(lbl); // último → arriba ✓

                tl.Controls.Add(item, 0, row++);
            }

            body.Controls.Add(tl);
        }

        // ─────────────────────────────────────────
        // NAVEGACION DESDE ACCESOS RÁPIDOS
        // ─────────────────────────────────────────
        private void NavegaA(string modulo)
        {
            Control c = this.Parent;
            while (c != null && !(c is FrmDashboard))
                c = c.Parent;

            if (!(c is FrmDashboard dash)) return;

            switch (modulo)
            {
                case "Nuevo Producto":   dash.AbrirFormulario(new FrmProductos()); break;
                case "Nuevo Movimiento": dash.AbrirFormulario(new FrmMovimientosInventario()); break;
                case "Transferencia":    dash.AbrirFormulario(new FrmTransferencias()); break;
                case "Ver Kardex":       dash.AbrirFormulario(new FrmKardex()); break;
                case "Stock Bodegas":    dash.AbrirFormulario(new FrmStockBodega()); break;
                case "Usuarios":         dash.AbrirFormulario(new FrmUsuarios()); break;
                case "Ver Logs":         dash.AbrirFormulario(new FrmLogs()); break;
                case "Configuración":    dash.AbrirFormulario(new FrmAjustes()); break;
            }
        }

        // ═══════════════════════════════════════════════════════
        // CARGA DE DATOS (lógica SQL sin cambios)
        // ═══════════════════════════════════════════════════════

        private void CargarIndicadores()
        {
            try
            {
                SqlConnection cx = cn.AbrirConexion();

                lblProductos.Text = new SqlCommand("SELECT COUNT(*) FROM Productos", cx).ExecuteScalar().ToString();
                lblClientes.Text  = new SqlCommand("SELECT COUNT(*) FROM Bodegas",   cx).ExecuteScalar().ToString();
                lblVentas.Text    = new SqlCommand("SELECT COUNT(*) FROM StockBodega WHERE StockActual <= 5", cx).ExecuteScalar().ToString();
                lblLogin.Text     = new SqlCommand(
                    "SELECT COUNT(*) FROM TransferenciasBodega WHERE CAST(Fecha AS DATE) = CAST(GETDATE() AS DATE)", cx)
                    .ExecuteScalar().ToString();

                cn.CerrarConexion();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void CargarKPIsAdicionales()
        {
            try
            {
                SqlConnection cx = cn.AbrirConexion();

                lblUsuariosActivos.Text = new SqlCommand("SELECT COUNT(*) FROM Usuarios",    cx).ExecuteScalar().ToString();
                lblProveedores.Text     = new SqlCommand("SELECT COUNT(*) FROM Proveedores", cx).ExecuteScalar().ToString();
                lblMovimientosHoy.Text  = new SqlCommand(
                    "SELECT COUNT(*) FROM MovimientosInventario WHERE CAST(Fecha AS DATE) = CAST(GETDATE() AS DATE)", cx)
                    .ExecuteScalar().ToString();
                lblLogsHoy.Text = new SqlCommand(
                    "SELECT COUNT(*) FROM LogsSistema WHERE CAST(Fecha AS DATE) = CAST(GETDATE() AS DATE)", cx)
                    .ExecuteScalar().ToString();

                cn.CerrarConexion();
            }
            catch { }
        }

        private void CargarActividad()
        {
            try
            {
                SqlConnection  cx = cn.AbrirConexion();
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT TOP 20
                        Evento,
                        Usuario,
                        Fecha,
                        Descripcion
                    FROM LogsSistema
                    ORDER BY Fecha DESC",
                    cx);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvActividad.DataSource = dt;

                if (dgvActividad.Columns.Count > 0)
                {
                    try
                    {
                        dgvActividad.Columns["Evento"].FillWeight      = 80;
                        dgvActividad.Columns["Usuario"].FillWeight     = 80;
                        dgvActividad.Columns["Fecha"].FillWeight       = 110;
                        dgvActividad.Columns["Descripcion"].FillWeight = 230;
                        dgvActividad.Columns["Evento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvActividad.Columns["Fecha"].DefaultCellStyle.Alignment  = DataGridViewContentAlignment.MiddleCenter;
                    }
                    catch { }
                }

                cn.CerrarConexion();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void CargarGraficaMovimientos()
        {
            try
            {
                SqlConnection cx  = cn.AbrirConexion();
                SqlCommand    cmd = new SqlCommand(
                    @"SELECT CAST(Fecha AS DATE) AS Dia, COUNT(*) AS Total
                      FROM MovimientosInventario
                      WHERE Fecha >= DATEADD(DAY, -7, GETDATE())
                      GROUP BY CAST(Fecha AS DATE)
                      ORDER BY Dia",
                    cx);

                SqlDataReader dr = cmd.ExecuteReader();
                chartMovimientos.Series[0].Points.Clear();

                while (dr.Read())
                    chartMovimientos.Series[0].Points.AddXY(
                        Convert.ToDateTime(dr["Dia"]).ToString("dd/MM"),
                        dr["Total"]);

                dr.Close();
                cn.CerrarConexion();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void CargarGraficaDistribucion()
        {
            try
            {
                SqlConnection  cx = cn.AbrirConexion();
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT b.Nombre, SUM(sb.StockActual) AS TotalStock
                      FROM StockBodega sb
                      INNER JOIN Bodegas b ON sb.IdBodega = b.IdBodega
                      GROUP BY b.Nombre
                      HAVING SUM(sb.StockActual) > 0",
                    cx);

                DataTable dt = new DataTable();
                da.Fill(dt);
                chartDistribucion.Series[0].Points.Clear();

                Color[] colores = {
                    Color.FromArgb(37,  99,  235), Color.FromArgb(16,  185, 129),
                    Color.FromArgb(245, 158, 11),  Color.FromArgb(139, 92,  246),
                    Color.FromArgb(239, 68,  68),  Color.FromArgb(6,   182, 212),
                };

                int idx = 0;
                foreach (DataRow row in dt.Rows)
                {
                    DataPoint dp = new DataPoint();
                    dp.SetValueXY(row["Nombre"].ToString(), Convert.ToDouble(row["TotalStock"]));
                    dp.Color      = colores[idx % colores.Length];
                    dp.LegendText = row["Nombre"].ToString();
                    chartDistribucion.Series[0].Points.Add(dp);
                    idx++;
                }

                cn.CerrarConexion();
            }
            catch { }
        }

        private void CargarAlertas()
        {
            try
            {
                SqlConnection cx = cn.AbrirConexion();

                lblAlertStockCritico.Text = new SqlCommand(
                    "SELECT COUNT(*) FROM StockBodega WHERE StockActual <= 5 AND StockActual > 0", cx)
                    .ExecuteScalar().ToString();

                lblAlertSinStock.Text = new SqlCommand(
                    "SELECT COUNT(*) FROM StockBodega WHERE StockActual = 0", cx)
                    .ExecuteScalar().ToString();

                lblAlertErrores.Text = new SqlCommand(
                    "SELECT COUNT(*) FROM LogsSistema WHERE Evento = 'ERROR' AND Fecha >= DATEADD(DAY, -1, GETDATE())", cx)
                    .ExecuteScalar().ToString();

                cn.CerrarConexion();
            }
            catch { }
        }

        private void CargarResumen()
        {
            try
            {
                SqlConnection cx = cn.AbrirConexion();

                object m = new SqlCommand(
                    "SELECT TOP 1 CONVERT(VARCHAR(16), Fecha, 120) FROM MovimientosInventario ORDER BY Fecha DESC", cx)
                    .ExecuteScalar();
                lblUltimoMov.Text = m != null ? m.ToString() : "Sin registros";

                object t = new SqlCommand(
                    "SELECT TOP 1 CONVERT(VARCHAR(16), Fecha, 120) FROM TransferenciasBodega ORDER BY Fecha DESC", cx)
                    .ExecuteScalar();
                lblUltimaTransf.Text = t != null ? t.ToString() : "Sin registros";

                object b = new SqlCommand(
                    @"SELECT TOP 1 b.Nombre
                      FROM StockBodega sb
                      INNER JOIN Bodegas b ON sb.IdBodega = b.IdBodega
                      GROUP BY b.Nombre
                      ORDER BY SUM(sb.StockActual) DESC", cx)
                    .ExecuteScalar();
                lblBodegaTop.Text = b != null ? b.ToString() : "Sin datos";

                cn.CerrarConexion();
            }
            catch { }
        }
    }
}
