// IMPORTACION DE LIBRERIAS NECESARIAS
using Sistema_Inventario.Logica;
using Sistema_Inventario.Utilidades;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Sistema_Inventario.Presentacion
{
    public partial class FrmMovimientosInventario : Form
    {
        // CAPA LOGICA
        LMovimientosInventario lMovimientos = new LMovimientosInventario();

        // TABLA PARA FILTRADO LOCAL
        DataTable tablaMovimientos;

        // PLACEHOLDER DE BÚSQUEDA
        const string PLACEHOLDER = "  Buscar por tipo, producto, bodega...";

        // ARREGLO DE BOTONES DE FILTRO PARA MANEJO DE ESTADO ACTIVO
        Button[] _botonesFiltrRapido;

        // COLORES BASE DE LOS FILTROS INACTIVOS (para restaurar al deseleccionar)
        readonly Color[] _coloresBgInactivo = {
            Color.FromArgb(241, 243, 246),   // Todos
            Color.FromArgb(241, 243, 246),   // Hoy
            Color.FromArgb(240, 253, 244),   // Entradas
            Color.FromArgb(254, 242, 242),   // Salidas
            Color.FromArgb(239, 246, 255),   // Transferencias
            Color.FromArgb(255, 251, 235),   // Ajustes
        };

        readonly Color[] _coloresFgInactivo = {
            Color.FromArgb(55, 65, 81),
            Color.FromArgb(55, 65, 81),
            Color.FromArgb(22, 101, 52),
            Color.FromArgb(153, 27, 27),
            Color.FromArgb(29, 78, 216),
            Color.FromArgb(146, 64, 14),
        };

        readonly Color[] _coloresBorderInactivo = {
            Color.FromArgb(210, 215, 225),
            Color.FromArgb(210, 215, 225),
            Color.FromArgb(167, 243, 208),
            Color.FromArgb(254, 202, 202),
            Color.FromArgb(191, 219, 254),
            Color.FromArgb(253, 230, 138),
        };

        // CONSTRUCTOR
        public FrmMovimientosInventario()
        {
            InitializeComponent();
            ConstruirMenuNuevoMovimiento();
        }

        // ─────────────────────────────────────────
        // LOAD
        // ─────────────────────────────────────────
        private void FrmMovimientosInventario_Load(object sender, EventArgs e)
        {
            _botonesFiltrRapido = new[] {
                btnFiltroTodos, btnFiltroHoy, btnFiltroEntradas,
                btnFiltroSalidas, btnFiltroTransferencias, btnFiltroAjustes
            };

            // Defer to ensure the Dock=Fill resize from FrmDashboard has settled
            BeginInvoke(new Action(GarantizarBotonesToolbar));

            ActualizarInfoHeader();
            MostrarMovimientos();
            IniciarPlaceholder();
            timer1.Start();
        }

        // ─────────────────────────────────────────
        // INYECTAR BOTONES EN BARRA DE ACCIONES
        // Llamado vía BeginInvoke para garantizar que
        // pnlAcciones ya tiene su ancho final (post Dock=Fill).
        // ─────────────────────────────────────────
        private void GarantizarBotonesToolbar()
        {
            const int y = 13, h = 42, margenDerecho = 10, gapBotones = 8;

            int panelW = pnlAcciones.Width;
            if (panelW < 100) panelW = this.Width; // fallback si el panel aún no se expandió

            // Posicionar btnNuevoMovimiento anclado a la derecha
            btnNuevoMovimiento.Size     = new Size(222, h);
            btnNuevoMovimiento.Location = new Point(panelW - 222 - margenDerecho, y);
            btnNuevoMovimiento.Visible  = true;
            btnNuevoMovimiento.Enabled  = true;

            // Posicionar btnExportar justo a la izquierda del anterior
            btnExportar.Size     = new Size(180, h);
            btnExportar.Location = new Point(btnNuevoMovimiento.Left - 180 - gapBotones, y);
            btnExportar.Visible  = true;
            btnExportar.Enabled  = true;

            // Agregar al panel si aún no están (Guard para reentradas desde SizeChanged)
            if (!pnlAcciones.Controls.Contains(btnExportar))
                pnlAcciones.Controls.Add(btnExportar);
            if (!pnlAcciones.Controls.Contains(btnNuevoMovimiento))
                pnlAcciones.Controls.Add(btnNuevoMovimiento);

            // Fijar Anchor DESPUÉS de tener posición y padre: WinForms almacena
            // la distancia desde el borde derecho en este momento, que será positiva.
            btnNuevoMovimiento.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportar.Anchor        = AnchorStyles.Top | AnchorStyles.Right;

            pnlAcciones.PerformLayout();
            pnlAcciones.Refresh();

            System.Diagnostics.Debug.WriteLine(
                $"[Toolbar] pnlAcciones.W={panelW} | " +
                $"btnNuevo={btnNuevoMovimiento.Location} Vis={btnNuevoMovimiento.Visible} " +
                $"Parent={btnNuevoMovimiento.Parent?.Name}");
        }

        // ─────────────────────────────────────────
        // HEADER — fecha/hora y usuario
        // ─────────────────────────────────────────
        private void ActualizarInfoHeader()
        {
            CultureInfo cultura = new CultureInfo("es-PE");
            lblFechaHora.Text = DateTime.Now.ToString(
                "dddd, dd 'de' MMMM 'de' yyyy  •  HH:mm:ss", cultura);
            lblUsuarioInfo.Text = $"◉  {SesionUsuario.Usuario}     |     {SesionUsuario.Rol}";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CultureInfo cultura = new CultureInfo("es-PE");
            lblFechaHora.Text = DateTime.Now.ToString(
                "dddd, dd 'de' MMMM 'de' yyyy  •  HH:mm:ss", cultura);
        }

        // ─────────────────────────────────────────
        // GRID — carga y formato
        // ─────────────────────────────────────────
        private void MostrarMovimientos()
        {
            tablaMovimientos = lMovimientos.MostrarMovimientos();
            dgvMovimientos.DataSource = tablaMovimientos;
            FormatearColumnas();
        }

        private void FormatearColumnas()
        {
            if (dgvMovimientos.Columns.Count == 0) return;
            try
            {
                dgvMovimientos.Columns["IdMovimiento"].HeaderText    = "ID";
                dgvMovimientos.Columns["TipoMovimiento"].HeaderText  = "Tipo";
                dgvMovimientos.Columns["UsuarioRegistro"].HeaderText = "Registrado por";

                dgvMovimientos.Columns["IdMovimiento"].FillWeight    = 45;
                dgvMovimientos.Columns["TipoMovimiento"].FillWeight  = 120;
                dgvMovimientos.Columns["Producto"].FillWeight        = 200;
                dgvMovimientos.Columns["Bodega"].FillWeight          = 130;
                dgvMovimientos.Columns["Cantidad"].FillWeight        = 70;
                dgvMovimientos.Columns["Fecha"].FillWeight           = 145;
                dgvMovimientos.Columns["Observacion"].FillWeight     = 185;
                dgvMovimientos.Columns["UsuarioRegistro"].FillWeight = 105;

                dgvMovimientos.Columns["IdMovimiento"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
                dgvMovimientos.Columns["Cantidad"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
                dgvMovimientos.Columns["Fecha"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
                dgvMovimientos.Columns["TipoMovimiento"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }
            catch { }
        }

        // ─────────────────────────────────────────
        // COLOREADO POR TIPO — CellFormatting
        // ─────────────────────────────────────────
        private void dgvMovimientos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid == null || e.RowIndex < 0) return;

            try
            {
                if (!grid.Columns.Contains("TipoMovimiento")) return;

                string tipo = grid.Rows[e.RowIndex].Cells["TipoMovimiento"]
                    ?.Value?.ToString()?.ToUpper()?.Trim() ?? "";

                GetTipoColors(tipo,
                    out Color rowBg, out Color badgeBg, out Color textColor);

                e.CellStyle.BackColor = rowBg;
                e.CellStyle.ForeColor = Color.FromArgb(35, 40, 50);
                e.CellStyle.SelectionBackColor = ControlPaint.Dark(rowBg, 0.1f);
                e.CellStyle.SelectionForeColor = Color.FromArgb(20, 25, 35);

                if (e.ColumnIndex == grid.Columns["TipoMovimiento"].Index)
                {
                    e.CellStyle.BackColor = badgeBg;
                    e.CellStyle.ForeColor = textColor;
                    e.CellStyle.SelectionBackColor = ControlPaint.Dark(badgeBg, 0.1f);
                    e.CellStyle.SelectionForeColor = textColor;
                    e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }
            }
            catch { }
        }

        private static void GetTipoColors(string tipo,
            out Color rowBg, out Color badgeBg, out Color textColor)
        {
            switch (tipo)
            {
                case "ENTRADA":
                    rowBg     = Color.FromArgb(240, 253, 244);
                    badgeBg   = Color.FromArgb(187, 247, 208);
                    textColor = Color.FromArgb(22, 101, 52);
                    break;
                case "SALIDA":
                    rowBg     = Color.FromArgb(254, 242, 242);
                    badgeBg   = Color.FromArgb(254, 202, 202);
                    textColor = Color.FromArgb(153, 27, 27);
                    break;
                case "TRANSFERENCIA":
                    rowBg     = Color.FromArgb(239, 246, 255);
                    badgeBg   = Color.FromArgb(191, 219, 254);
                    textColor = Color.FromArgb(29, 78, 216);
                    break;
                case "AJUSTE":
                    rowBg     = Color.FromArgb(255, 251, 235);
                    badgeBg   = Color.FromArgb(253, 230, 138);
                    textColor = Color.FromArgb(146, 64, 14);
                    break;
                case "DEVOLUCIÓN":
                case "DEVOLUCION":
                    rowBg     = Color.FromArgb(250, 245, 255);
                    badgeBg   = Color.FromArgb(233, 213, 255);
                    textColor = Color.FromArgb(109, 40, 217);
                    break;
                default:
                    rowBg     = Color.White;
                    badgeBg   = Color.FromArgb(229, 231, 235);
                    textColor = Color.FromArgb(55, 65, 81);
                    break;
            }
        }

        // ─────────────────────────────────────────
        // BÚSQUEDA
        // ─────────────────────────────────────────
        private void IniciarPlaceholder()
        {
            txtBuscar.Text      = PLACEHOLDER;
            txtBuscar.ForeColor = Color.FromArgb(150, 150, 160);
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == PLACEHOLDER)
            {
                txtBuscar.Text      = "";
                txtBuscar.ForeColor = Color.FromArgb(30, 30, 40);
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                FiltrarMovimientos("");
                IniciarPlaceholder();
                btnLimpiarBusqueda.Visible = false;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text == PLACEHOLDER) return;

            bool tieneTexto = !string.IsNullOrWhiteSpace(txtBuscar.Text);
            btnLimpiarBusqueda.Visible = tieneTexto;
            FiltrarMovimientos(txtBuscar.Text.Trim());
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            FiltrarMovimientos("");
            IniciarPlaceholder();
            btnLimpiarBusqueda.Visible = false;
            txtBuscar.Focus();
        }

        private void FiltrarMovimientos(string texto)
        {
            if (tablaMovimientos == null) return;

            if (string.IsNullOrWhiteSpace(texto))
            {
                tablaMovimientos.DefaultView.RowFilter = "";
                return;
            }

            string filtro = texto.Replace("'", "''");
            tablaMovimientos.DefaultView.RowFilter =
                $"TipoMovimiento LIKE '%{filtro}%' OR " +
                $"Producto LIKE '%{filtro}%' OR " +
                $"Bodega LIKE '%{filtro}%' OR " +
                $"Observacion LIKE '%{filtro}%' OR " +
                $"UsuarioRegistro LIKE '%{filtro}%'";
        }

        // ─────────────────────────────────────────
        // FILTROS RÁPIDOS
        // ─────────────────────────────────────────
        private void AplicarFiltroRapido(Button btnActivo, string rowFilter)
        {
            for (int i = 0; i < _botonesFiltrRapido.Length; i++)
            {
                var b = _botonesFiltrRapido[i];
                b.BackColor = _coloresBgInactivo[i];
                b.ForeColor = _coloresFgInactivo[i];
                b.FlatAppearance.BorderColor = _coloresBorderInactivo[i];
            }

            btnActivo.BackColor = Color.FromArgb(37, 99, 235);
            btnActivo.ForeColor = Color.White;
            btnActivo.FlatAppearance.BorderColor = Color.FromArgb(37, 99, 235);

            if (tablaMovimientos != null)
                tablaMovimientos.DefaultView.RowFilter = rowFilter;

            // Limpia el buscador al cambiar filtro
            IniciarPlaceholder();
            btnLimpiarBusqueda.Visible = false;
        }

        private void btnFiltroTodos_Click(object sender, EventArgs e)
            => AplicarFiltroRapido(btnFiltroTodos, "");

        private void btnFiltroHoy_Click(object sender, EventArgs e)
        {
            string filtroFecha = "";
            try
            {
                filtroFecha =
                    $"Fecha >= #{DateTime.Today:MM/dd/yyyy}# " +
                    $"AND Fecha < #{DateTime.Today.AddDays(1):MM/dd/yyyy}#";

                // Prueba si funciona el filtro de fecha
                if (tablaMovimientos != null)
                    tablaMovimientos.DefaultView.RowFilter = filtroFecha;
            }
            catch
            {
                // Fallback para columna de tipo string
                filtroFecha =
                    $"CONVERT(Fecha, 'System.String') LIKE " +
                    $"'{DateTime.Today:yyyy-MM-dd}%'";
            }

            AplicarFiltroRapido(btnFiltroHoy, filtroFecha);
        }

        private void btnFiltroEntradas_Click(object sender, EventArgs e)
            => AplicarFiltroRapido(btnFiltroEntradas, "TipoMovimiento LIKE '%ENTRADA%'");

        private void btnFiltroSalidas_Click(object sender, EventArgs e)
            => AplicarFiltroRapido(btnFiltroSalidas, "TipoMovimiento LIKE '%SALIDA%'");

        private void btnFiltroTransferencias_Click(object sender, EventArgs e)
            => AplicarFiltroRapido(btnFiltroTransferencias, "TipoMovimiento LIKE '%TRANSFERENCIA%'");

        private void btnFiltroAjustes_Click(object sender, EventArgs e)
            => AplicarFiltroRapido(btnFiltroAjustes, "TipoMovimiento LIKE '%AJUSTE%'");

        // ─────────────────────────────────────────
        // MENÚ DESPLEGABLE — Nuevo Movimiento
        // ─────────────────────────────────────────
        private void ConstruirMenuNuevoMovimiento()
        {
            cmsNuevoMovimiento.Font             = new Font("Segoe UI", 10.5F);
            cmsNuevoMovimiento.BackColor        = Color.White;
            cmsNuevoMovimiento.ShowImageMargin  = false;
            cmsNuevoMovimiento.Padding          = new Padding(0, 4, 0, 4);
            cmsNuevoMovimiento.Renderer         =
                new ToolStripProfessionalRenderer(new ElegantMenuColorTable());

            AgregarItemMenu("  ▲   Entrada de Inventario",
                Color.FromArgb(22, 101, 52), "ENTRADA");

            AgregarItemMenu("  ▼   Salida de Inventario",
                Color.FromArgb(153, 27, 27), "SALIDA");

            AgregarItemMenu("  ⇄   Transferencia",
                Color.FromArgb(29, 78, 216), "TRANSFERENCIA");

            cmsNuevoMovimiento.Items.Add(new ToolStripSeparator());

            AgregarItemMenu("  ✏   Ajuste de Inventario",
                Color.FromArgb(146, 64, 14), "AJUSTE");

            AgregarItemMenu("  ↩   Devolución",
                Color.FromArgb(109, 40, 217), "DEVOLUCIÓN");

            AgregarItemMenu("  ★   Movimiento Especial",
                Color.FromArgb(55, 65, 81), "ESPECIAL");

            cmsNuevoMovimiento.Items.Add(new ToolStripSeparator());

            var itemHistorial = new ToolStripMenuItem("  📋   Ver Historial Completo");
            itemHistorial.ForeColor = Color.FromArgb(75, 85, 99);
            itemHistorial.Font      = new Font("Segoe UI", 10.5F);
            itemHistorial.Click    += (s, ev) => VerHistorial();
            cmsNuevoMovimiento.Items.Add(itemHistorial);
        }

        private void AgregarItemMenu(string texto, Color color, string tipo)
        {
            var item = new ToolStripMenuItem(texto);
            item.ForeColor = color;
            item.Font      = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);

            // Captura explícita de la variable para el closure
            string tipoCapturado = tipo;
            item.Click += (s, ev) => AbrirModal(tipoCapturado);

            cmsNuevoMovimiento.Items.Add(item);
        }

        private void btnNuevoMovimiento_Click(object sender, EventArgs e)
        {
            var btn = sender as Control;
            cmsNuevoMovimiento.Show(btn, new Point(0, btn.Height));
        }

        // ─────────────────────────────────────────
        // ABRIR MODAL CON TIPO PRESELECCIONADO
        // ─────────────────────────────────────────
        private void AbrirModal(string tipo)
        {
            using (var modal = new FrmMovimientoModal(tipo))
            {
                if (modal.ShowDialog(this) == DialogResult.OK)
                    MostrarMovimientos();
            }
        }

        // ─────────────────────────────────────────
        // VER HISTORIAL COMPLETO (modal inline)
        // ─────────────────────────────────────────
        private void VerHistorial()
        {
            using (Form f = new Form())
            {
                f.Text            = "Historial de Movimientos";
                f.Size            = new Size(1150, 680);
                f.StartPosition   = FormStartPosition.CenterParent;
                f.BackColor       = Color.FromArgb(240, 242, 245);
                f.FormBorderStyle = FormBorderStyle.FixedDialog;
                f.MaximizeBox     = false;
                f.MinimizeBox     = false;
                f.ShowInTaskbar   = false;

                // HEADER
                var pnlH = new Panel
                {
                    Dock      = DockStyle.Top,
                    Height    = 64,
                    BackColor = Color.FromArgb(10, 35, 66)
                };
                var lblH = new Label
                {
                    Text      = "📋  Historial Completo de Movimientos",
                    Font      = new Font("Segoe UI", 15F, FontStyle.Bold),
                    ForeColor = Color.White,
                    AutoSize  = true,
                    Location  = new Point(24, 18)
                };
                var lblCount = new Label
                {
                    Font      = new Font("Segoe UI", 10F),
                    ForeColor = Color.FromArgb(160, 200, 240),
                    AutoSize  = true,
                    Location  = new Point(24, 44)
                };
                pnlH.Controls.Add(lblH);
                pnlH.Controls.Add(lblCount);

                // GRID
                var dgv = new DataGridView
                {
                    Dock                        = DockStyle.Fill,
                    DataSource                  = tablaMovimientos?.Copy(),
                    AllowUserToAddRows          = false,
                    AllowUserToDeleteRows       = false,
                    ReadOnly                    = true,
                    AutoSizeColumnsMode         = DataGridViewAutoSizeColumnsMode.Fill,
                    BackgroundColor             = Color.White,
                    BorderStyle                 = BorderStyle.None,
                    CellBorderStyle             = DataGridViewCellBorderStyle.SingleHorizontal,
                    ColumnHeadersHeight         = 46,
                    ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                    EnableHeadersVisualStyles   = false,
                    RowHeadersVisible           = false,
                    SelectionMode               = DataGridViewSelectionMode.FullRowSelect,
                    MultiSelect                 = false
                };
                dgv.RowTemplate.Height = 38;

                var hStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(10, 35, 66),
                    ForeColor = Color.White,
                    Font      = new Font("Segoe UI", 10.5F, FontStyle.Bold)
                };
                dgv.ColumnHeadersDefaultCellStyle = hStyle;
                dgv.DefaultCellStyle.Font         = new Font("Segoe UI", 10F);
                dgv.DefaultCellStyle.Padding      = new Padding(5, 0, 5, 0);
                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
                dgv.CellFormatting += dgvMovimientos_CellFormatting;

                int total = tablaMovimientos?.Rows.Count ?? 0;
                lblCount.Text = $"{total} registros en total";

                f.Controls.Add(dgv);    // Fill primero
                f.Controls.Add(pnlH);   // Top último
                f.ShowDialog(this);
            }
        }

        // ─────────────────────────────────────────
        // EXPORTAR EXCEL
        // ─────────────────────────────────────────
        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMovimientos.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No hay datos para exportar.",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                ExportarExcel.Exportar(dgvMovimientos, "Reporte_Movimientos");

                MessageBox.Show(
                    "Reporte exportado correctamente.",
                    "Exportación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────
        // COLOR TABLE PARA CONTEXTMENUSTRIP MODERNO
        // ─────────────────────────────────────────
        private class ElegantMenuColorTable : ProfessionalColorTable
        {
            public override Color MenuItemSelected
                => Color.FromArgb(235, 242, 255);
            public override Color MenuItemBorder
                => Color.FromArgb(191, 210, 250);
            public override Color MenuBorder
                => Color.FromArgb(210, 218, 230);
            public override Color ToolStripDropDownBackground
                => Color.White;
            public override Color ImageMarginGradientBegin
                => Color.FromArgb(248, 249, 251);
            public override Color ImageMarginGradientMiddle
                => Color.FromArgb(248, 249, 251);
            public override Color ImageMarginGradientEnd
                => Color.FromArgb(248, 249, 251);
            public override Color SeparatorLight
                => Color.FromArgb(238, 241, 246);
            public override Color SeparatorDark
                => Color.FromArgb(220, 224, 230);
        }
    }
}
