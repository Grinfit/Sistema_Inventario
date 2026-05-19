using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Inventario.Presentacion
{
    public partial class FrmDashboard : Form
    {
        private Panel sidebar;

        private Panel topbar;

        private Panel panelContenedor;

        private Panel panelMenuScroll;

        private Label lblTitulo;

        private Label lblFecha;

        private bool menuExpandido = true;

        public FrmDashboard()
        {
            InitializeComponent();

            CrearSidebar();

            CrearTopbar();

            CrearPanelContenedor();

            AbrirFormulario(
                new FrmInicio());
        }

        // =========================================
        // SIDEBAR
        // =========================================

        private void CrearSidebar()
        {
            sidebar = new Panel();
            new Padding(0, 5, 0, 0);

            sidebar.Dock =
                DockStyle.Left;

            sidebar.Width = 260;

            sidebar.BackColor =
                Color.FromArgb(
                    11,
                    31,
                    58);

            this.Controls.Add(sidebar);

            // =====================================
            // PANEL SCROLL MENU
            // =====================================

            panelMenuScroll =
                new Panel();

            panelMenuScroll.Dock =
                DockStyle.Fill;

            panelMenuScroll.AutoScroll =
                true;
            panelMenuScroll.HorizontalScroll.Enabled =
                false;

            panelMenuScroll.HorizontalScroll.Visible =
                false;

            panelMenuScroll.HorizontalScroll.Maximum =
                0;

            panelMenuScroll.AutoScrollMinSize =
                new Size(0, 0);

            panelMenuScroll.BackColor =
                Color.FromArgb(
                    11,
                    31,
                    58);

            sidebar.Controls.Add(
                panelMenuScroll);

            // =====================================
            // BTN MENU
            // =====================================

            Button btnMenu =
                new Button();

            btnMenu.Text = "☰";

            btnMenu.Font =
                new Font(
                    "Segoe UI",
                    20F,
                    FontStyle.Bold);

            btnMenu.ForeColor =
                Color.White;

            btnMenu.BackColor =
                Color.FromArgb(
                    18,
                    45,
                    78);

            btnMenu.FlatStyle =
                FlatStyle.Flat;

            btnMenu.FlatAppearance.BorderSize = 0;

            btnMenu.Size =
                new Size(46, 46);

            btnMenu.Location =
                btnMenu.Location =
                new Point(12, 15);

            btnMenu.Cursor =
                Cursors.Hand;

            btnMenu.Click += BtnMenu_Click;

            sidebar.Controls.Add(btnMenu);

            sidebar.Controls.SetChildIndex(
                btnMenu,
                0);

            int top = 110;

            // =====================================
            // DASHBOARD
            // =====================================

            AgregarBoton(
                "Dashboard",
                IconChar.ChartPie,
                btnDashboard_Click,
                top);

            top += 80;

            // =====================================
            // CATALOGOS
            // =====================================

            AgregarTituloMenu(
                "CATÁLOGOS",
                top);

            top += 35;

            AgregarBoton(
                "Productos",
                IconChar.BoxOpen,
                btnProductos_Click,
                top);

            top += 60;

            AgregarBoton(
                "Bodegas",
                IconChar.Warehouse,
                btnBodegas_Click,
                top);

            top += 60;

            AgregarBoton(
                "Proveedores",
                IconChar.TruckField,
                btnProveedores_Click,
                top);

            top += 80;

            // =====================================
            // INVENTARIO
            // =====================================

            AgregarTituloMenu(
                "INVENTARIO",
                top);

            top += 35;

            AgregarBoton(
                "Movimientos",
                IconChar.RightLeft,
                btnMovimientos_Click,
                top);

            top += 60;

            AgregarBoton(
                "Kardex",
                IconChar.ClipboardList,
                btnKardex_Click,
                top);

            top += 60;

            AgregarBoton(
                "Stock",
                IconChar.BoxesStacked,
                btnStock_Click,
                top);

            top += 60;

            AgregarBoton(
                "Transferencias",
                IconChar.ArrowsLeftRight,
                btnTransferencias_Click,
                top);

            top += 60;

            AgregarBoton(
                "Ajustes",
                IconChar.ScrewdriverWrench,
                btnAjustes_Click,
                top);

            top += 80;

            // =====================================
            // SEGURIDAD
            // =====================================

            AgregarTituloMenu(
                "SEGURIDAD",
                top);

            top += 35;

            AgregarBoton(
                "Usuarios",
                IconChar.UserGear,
                btnUsuarios_Click,
                top);

            top += 60;

            AgregarBoton(
                "Roles",
                IconChar.UserShield,
                btnRoles_Click,
                top);

            top += 60;

            AgregarBoton(
                "Logs",
                IconChar.FileLines,
                btnLogs_Click,
                top);

            top += 80;

            // =====================================
            // SISTEMA
            // =====================================

            AgregarTituloMenu(
                "SISTEMA",
                top);

            top += 35;

            AgregarBoton(
                "Backup",
                IconChar.Database,
                btnBackup_Click,
                top);

            top += 60;

            AgregarBoton(
                "Salir",
                IconChar.RightFromBracket,
                btnSalir_Click,
                top);
        }

        // =========================================
        // TITULOS MENU
        // =========================================

        private void AgregarTituloMenu(
            string texto,
            int top)
        {
            Label lbl =
                new Label();

            lbl.Text = texto;

            lbl.ForeColor =
                Color.FromArgb(
                    148,
                    163,
                    184);

            lbl.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            lbl.AutoSize = true;

            lbl.Location =
                new Point(15, top);

            panelMenuScroll.Controls.Add(lbl);
        }

        // =========================================
        // BOTONES MENU
        // =========================================

        private void AgregarBoton(
            string texto,
            IconChar icono,
            EventHandler evento,
            int top)
        {
            IconButton boton =
                new IconButton();

            boton.Text = texto;

            boton.IconChar = icono;

            boton.IconColor =
                Color.White;

            boton.IconFont =
                IconFont.Auto;

            boton.IconSize = 28;

            boton.ForeColor =
                Color.White;

            boton.TextAlign =
                ContentAlignment.MiddleLeft;

            boton.ImageAlign =
                ContentAlignment.MiddleLeft;

            boton.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            boton.Padding =
                new Padding(20, 0, 0, 0);

            boton.FlatStyle =
                FlatStyle.Flat;

            boton.FlatAppearance.BorderSize = 0;

            boton.BackColor =
                Color.FromArgb(
                    11,
                    31,
                    58);

            boton.Font =
                new Font(
                    "Segoe UI",
                    11F);

            boton.Cursor =
                Cursors.Hand;

            boton.Width = 245;

            boton.Height = 55;

            boton.Top = top;

            boton.Left = 0;

            boton.MouseEnter +=
                (s, e) =>
                {
                    boton.BackColor =
                        Color.FromArgb(
                            25,
                            55,
                            95);
                };

            boton.MouseLeave +=
                (s, e) =>
                {
                    boton.BackColor =
                        Color.FromArgb(
                            11,
                            31,
                            58);
                };

            boton.Click += evento;

            panelMenuScroll.Controls.Add(
                boton);
        }

        // =========================================
        // TOPBAR
        // =========================================

        private void CrearTopbar()
        {
            topbar = new Panel();

            topbar.Dock =
                DockStyle.Top;

            topbar.Height = 90;

            topbar.BackColor =
                Color.White;

            this.Controls.Add(topbar);

            topbar.BringToFront();

            lblTitulo =
                new Label();

            lblTitulo.Text =
                "Sistema Inventario";

            lblTitulo.Font =
                new Font(
                    "Segoe UI",
                    24F,
                    FontStyle.Bold);

            lblTitulo.ForeColor =
                Color.FromArgb(
                    11,
                    31,
                    58);

            lblTitulo.AutoSize =
                true;

            lblTitulo.Location =
                new Point(35, 20);

            topbar.Controls.Add(
                lblTitulo);

            // =====================================
            // FECHA
            // =====================================

            lblFecha =
                new Label();

            lblFecha.Text =
                DateTime.Now.ToString(
                    "dd/MM/yyyy HH:mm:ss");

            lblFecha.Font =
                new Font(
                    "Segoe UI",
                    10F);

            lblFecha.ForeColor =
                Color.Gray;

            lblFecha.AutoSize =
                true;

            lblFecha.Location =
                new Point(1050, 35);

            topbar.Controls.Add(
                lblFecha);
        }

        // =========================================
        // PANEL CONTENEDOR
        // =========================================

        private void CrearPanelContenedor()
        {
            panelContenedor =
                new Panel();

            panelContenedor.Dock =
                DockStyle.Fill;

            panelContenedor.Padding =
                new Padding(20);

            panelContenedor.BackColor =
                Color.FromArgb(
                    245,
                    247,
                    250);

            this.Controls.Add(
                panelContenedor);

            panelContenedor.BringToFront();
        }

        // =========================================
        // MENU HAMBURGUESA
        // =========================================

        private void BtnMenu_Click(
            object sender,
            EventArgs e)
        {
            if (menuExpandido)
            {
                sidebar.Width = 80;

                foreach (
                    Control control
                    in panelMenuScroll.Controls)
                {
                    if (control is IconButton)
                    {
                        IconButton btn =
                            (IconButton)control;

                        btn.Text = "";

                        btn.Padding =
                            new Padding(0);

                        btn.Width = 80;
                    }

                    if (control is Label)
                    {
                        control.Visible = false;
                    }
                }

                menuExpandido = false;
            }
            else
            {
                sidebar.Width = 260;

                foreach (
                    Control control
                    in panelMenuScroll.Controls)
                {
                    if (control is IconButton)
                    {
                        IconButton btn =
                            (IconButton)control;

                        btn.Width = 260;

                        btn.Padding =
                            new Padding(20, 0, 0, 0);
                    }

                    if (control is Label)
                    {
                        control.Visible = true;
                    }
                }

                RestaurarTextosBotones();

                menuExpandido = true;
            }
        }

        // =========================================
        // RESTAURAR TEXTOS
        // =========================================

        private void RestaurarTextosBotones()
        {
            int index = 0;

            string[] textos =
            {
                "Dashboard",
                "Productos",
                "Bodegas",
                "Proveedores",
                "Movimientos",
                "Kardex",
                "Stock",
                "Transferencias",
                "Ajustes",
                "Usuarios",
                "Roles",
                "Logs",
                "Backup",
                "Salir"
            };

            foreach (
                Control control
                in panelMenuScroll.Controls)
            {
                if (control is IconButton)
                {
                    if (index < textos.Length)
                    {
                        ((IconButton)control).Text =
                            textos[index];

                        index++;
                    }
                }
            }
        }

        // =========================================
        // ABRIR FORMULARIOS
        // =========================================

        private void AbrirFormulario(
            Form formulario)
        {
            panelContenedor.Controls.Clear();

            formulario.TopLevel = false;

            formulario.FormBorderStyle =
                FormBorderStyle.None;

            formulario.Dock =
                DockStyle.Fill;

            panelContenedor.Controls.Add(
                formulario);

            formulario.Show();
        }

        // =========================================
        // EVENTOS MENU
        // =========================================

        private void btnDashboard_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmInicio());
        }

        private void btnProductos_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmProductos());
        }

        private void btnBodegas_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmBodegas());
        }

        private void btnProveedores_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmProveedores());
        }

        private void btnMovimientos_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmMovimientosInventario());
        }

        private void btnKardex_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmKardex());
        }

        private void btnStock_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmStockBodega());
        }

        private void btnTransferencias_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmTransferencias());
        }

        private void btnAjustes_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmAjustesInventario());
        }

        private void btnUsuarios_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmUsuarios());
        }

        private void btnRoles_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmRoles());
        }

        private void btnBackup_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmBackup());
        }

        private void btnLogs_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmLogs());
        }

        private void btnSalir_Click(
            object sender,
            EventArgs e)
        {
            DialogResult resultado;

            resultado =
                MessageBox.Show(
                    "¿Desea salir del sistema?",
                    "Salir",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (resultado ==
                DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void FrmDashboard_Load(
            object sender,
            EventArgs e)
        {

        }
    }
}