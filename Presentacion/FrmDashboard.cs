using FontAwesome.Sharp;
using Sistema_Inventario.Utilidades;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Sistema_Inventario.Presentacion
{
    public partial class FrmDashboard : Form
    {
        private Panel panelMenu;
        private Panel panelContenedor;
        private Panel panelTop;

        private IconButton btnMenu;

        private bool menuExpandido = true;

        public FrmDashboard()
        {
            InitializeComponent();

            ConfigurarFormulario();

            CrearMenu();

            CrearTop();

            CrearContenedor();

            AplicarPermisos();

            ReorganizarMenu();

            AbrirFormulario(new FrmInicio());
        }
        private void ReorganizarMenu()
        {
            int top = 90;

            foreach (Control control in panelMenu.Controls)
            {
                // NO mover botón hamburguesa
                if (control == btnMenu)
                    continue;

                // =====================================
                // LABELS
                // =====================================

                if (control is Label lbl)
                {
                    bool mostrarTitulo = false;

                    string texto = lbl.Text;

                    // ==========================
                    // VALIDAR SECCIONES
                    // ==========================

                    if (texto == "CATÁLOGOS")
                    {
                        mostrarTitulo =
                            panelMenu.Controls["btnDashboard"].Visible ||
                            panelMenu.Controls["btnProductos"].Visible ||
                            panelMenu.Controls["btnBodegas"].Visible ||
                            panelMenu.Controls["btnProveedores"].Visible;
                    }

                    else if (texto == "INVENTARIO")
                    {
                        mostrarTitulo =
                            panelMenu.Controls["btnMovimientos"].Visible ||
                            panelMenu.Controls["btnKardex"].Visible ||
                            panelMenu.Controls["btnStock"].Visible ||
                            panelMenu.Controls["btnTransferencias"].Visible;
                    }

                    else if (texto == "SEGURIDAD")
                    {
                        mostrarTitulo =
                            panelMenu.Controls["btnUsuarios"].Visible ||
                            panelMenu.Controls["btnRoles"].Visible ||
                            panelMenu.Controls["btnLogs"].Visible;
                    }

                    else if (texto == "SISTEMA")
                    {
                        mostrarTitulo =
                            panelMenu.Controls["btnBackup"].Visible ||
                            panelMenu.Controls["btnAjustes"].Visible;
                    }

                    lbl.Visible = mostrarTitulo;

                    if (mostrarTitulo)
                    {
                        lbl.Top = top;
                        top += 40;
                    }
                }

                // =====================================
                // BOTONES
                // =====================================

                if (control is IconButton btn &&
                    btn.Visible &&
                    btn != btnMenu)
                {
                    btn.Top = top;

                    top += 55;
                }
            }
        }
        // =========================================
        // CONFIGURAR FORM
        // =========================================

        private void ConfigurarFormulario()
        {
            this.Text = "Sistema Inventario";

            this.WindowState =
                FormWindowState.Maximized;

            this.FormBorderStyle =
                FormBorderStyle.None;

            this.BackColor =
                Color.FromArgb(245, 247, 250);
        }

        // =========================================
        // CREAR MENU
        // =========================================

        private void CrearMenu()
        {
            panelMenu = new Panel();

            panelMenu.Dock = DockStyle.Left;

            panelMenu.Width = 250;

            panelMenu.BackColor =
                Color.FromArgb(7, 31, 61);

            panelMenu.AutoScroll = true;

            panelMenu.HorizontalScroll.Enabled = false;
            panelMenu.HorizontalScroll.Visible = false;

            this.Controls.Add(panelMenu);

            // =========================================
            // BOTON MENU
            // =========================================

            btnMenu = new IconButton();

            btnMenu.IconChar = IconChar.Bars;

            btnMenu.IconColor = Color.White;

            btnMenu.IconSize = 30;

            btnMenu.FlatStyle = FlatStyle.Flat;

            btnMenu.FlatAppearance.BorderSize = 0;

            btnMenu.BackColor =
                Color.FromArgb(14, 45, 84);

            btnMenu.Size =
                new Size(55, 55);

            btnMenu.Location =
                new Point(10, 10);

            btnMenu.Cursor =
                Cursors.Hand;

            btnMenu.Click += BtnMenu_Click;

            panelMenu.Controls.Add(btnMenu);

            int top = 90;

            // =========================================
            // TITULOS Y BOTONES
            // =========================================

            AgregarTitulo("CATÁLOGOS", top);
            top += 45;

            AgregarBoton(
                "Dashboard",
                IconChar.ChartPie,
                BtnDashboard_Click,
                top);

            top += 60;

            AgregarBoton(
                "Productos",
                IconChar.BoxOpen,
                BtnProductos_Click,
                top);

            top += 60;

            AgregarBoton(
                "Bodegas",
                IconChar.Warehouse,
                BtnBodegas_Click,
                top);

            top += 60;

            AgregarBoton(
                "Proveedores",
                IconChar.Truck,
                BtnProveedores_Click,
                top);

            top += 80;

            AgregarTitulo("INVENTARIO", top);
            top += 45;

            AgregarBoton(
                "Movimientos",
                IconChar.RightLeft,
                BtnMovimientos_Click,
                top);

            top += 60;

            AgregarBoton(
                "Kardex",
                IconChar.ClipboardList,
                BtnKardex_Click,
                top);

            top += 60;

            AgregarBoton(
                "Stock",
                IconChar.BoxesStacked,
                BtnStock_Click,
                top);

            top += 60;

            AgregarBoton(
                "Transferencias",
                IconChar.ArrowsLeftRight,
                BtnTransferencias_Click,
                top);

            top += 80;

            AgregarTitulo("SEGURIDAD", top);
            top += 45;

            AgregarBoton(
                "Usuarios",
                IconChar.Users,
                BtnUsuarios_Click,
                top);

            top += 60;

            AgregarBoton(
                "Roles",
                IconChar.UserShield,
                BtnRoles_Click,
                top);

            top += 60;

            AgregarBoton(
                "Logs",
                IconChar.FileLines,
                BtnLogs_Click,
                top);

            top += 80;

            AgregarTitulo("SISTEMA", top);
            top += 45;

            AgregarBoton(
                "Backup",
                IconChar.Database,
                BtnBackup_Click,
                top);

            top += 60;

            AgregarBoton(
                "Ajustes",
                IconChar.ScrewdriverWrench,
                BtnAjustes_Click,
                top);

            top += 60;

            IconButton btnSalir =
                AgregarBoton(
                    "Cerrar Sesión",
                    IconChar.RightFromBracket,
                    BtnSalir_Click,
                    top);

            btnSalir.BackColor =
                Color.FromArgb(180, 45, 45);
        }

        // =========================================
        // AGREGAR TITULO
        // =========================================

        private void AgregarTitulo(
            string texto,
            int top)
        {
            Label lbl = new Label();

            lbl.Text = texto;

            lbl.ForeColor =
                Color.FromArgb(180, 190, 205);

            lbl.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold);

            lbl.AutoSize = true;

            lbl.Left = 15;

            lbl.Top = top;

            panelMenu.Controls.Add(lbl);
        }

        // =========================================
        // AGREGAR BOTON
        // =========================================

        private IconButton AgregarBoton(
     string texto,
     IconChar icono,
     EventHandler evento,
     int top)
        {
            IconButton btn =
                new IconButton();

            // =====================================
            // NAME FIJO
            // =====================================

            btn.Name =
                "btn" + texto.Replace(" ", "");

            btn.Tag = texto;

            btn.Text = texto;

            btn.IconChar = icono;

            btn.IconColor = Color.White;

            btn.IconSize = 24;

            btn.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            btn.ImageAlign =
                ContentAlignment.MiddleLeft;

            btn.TextAlign =
                ContentAlignment.MiddleLeft;

            btn.Padding =
                new Padding(15, 0, 0, 0);

            btn.ForeColor = Color.White;

            btn.Font =
                new Font(
                    "Segoe UI",
                    11);

            btn.FlatStyle =
                FlatStyle.Flat;

            btn.FlatAppearance.BorderSize = 0;

            btn.BackColor =
                Color.FromArgb(7, 31, 61);

            btn.Width = 240;

            btn.Height = 50;

            btn.Left = 0;

            btn.Top = top;

            btn.Cursor =
                Cursors.Hand;

            btn.Click += evento;

            panelMenu.Controls.Add(btn);

            return btn;
        }

        // =========================================
        // TOP
        // =========================================

        private void CrearTop()
        {
            panelTop = new Panel();

            panelTop.Dock = DockStyle.Top;

            panelTop.Height = 70;

            panelTop.BackColor = Color.White;

            this.Controls.Add(panelTop);

            panelTop.BringToFront();

            Label lblSistema =
                new Label();

            lblSistema.Text =
                "Sistema Inventario";

            lblSistema.Font =
                new Font(
                    "Segoe UI",
                    22,
                    FontStyle.Bold);

            lblSistema.ForeColor =
                Color.FromArgb(11, 31, 58);

            lblSistema.AutoSize = true;

            lblSistema.Location =
                new Point(35, 15);

            panelTop.Controls.Add(lblSistema);

            Label lblFecha =
                new Label();

            lblFecha.Text =
                DateTime.Now.ToString(
                    "dd/MM/yyyy HH:mm:ss");

            lblFecha.Font =
                new Font(
                    "Segoe UI",
                    11);

            lblFecha.ForeColor =
                Color.Gray;

            lblFecha.AutoSize = true;

            lblFecha.Location =
                new Point(900, 25);

            panelTop.Controls.Add(lblFecha);
        }

        // =========================================
        // PANEL CONTENEDOR
        // =========================================

        private void CrearContenedor()
        {
            panelContenedor = new Panel();

            panelContenedor.Dock =
                DockStyle.Fill;

            panelContenedor.BackColor =
                Color.FromArgb(245, 247, 250);

            panelContenedor.AutoScroll = false;

            this.Controls.Add(panelContenedor);

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
                panelMenu.Width = 70;

                foreach (Control control
                    in panelMenu.Controls)
                {
                    if (control is Label lbl)
                    {
                        lbl.Visible = false;
                    }

                    if (control is IconButton btn &&
                        btn != btnMenu)
                    {
                        btn.Text = "";

                        btn.Padding =
                            new Padding(0);

                        btn.IconSize = 28;

                        btn.Width = 70;

                        btn.TextAlign =
                            ContentAlignment.MiddleCenter;

                        btn.ImageAlign =
                            ContentAlignment.MiddleCenter;
                    }
                }
            }
            else
            {
                panelMenu.Width = 250;

                RestaurarTexto();

                foreach (Control control
                    in panelMenu.Controls)
                {
                    if (control is IconButton btn &&
                        btn != btnMenu)
                    {
                        btn.Width = 240;

                        btn.Padding =
                            new Padding(15, 0, 0, 0);

                        btn.IconSize = 24;

                        btn.TextAlign =
                            ContentAlignment.MiddleLeft;

                        btn.ImageAlign =
                            ContentAlignment.MiddleLeft;
                    }
                }

                ReorganizarMenu();
            }

            menuExpandido =
                !menuExpandido;
        }

        // =========================================
        // RESTAURAR TEXTO
        // =========================================

        private void RestaurarTexto()
        {
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
                "Usuarios",
                "Roles",
                "Logs",
                "Backup",
                "Ajustes",
                "Cerrar Sesión"
            };

            int index = 0;

            foreach (Control control
                in panelMenu.Controls)
            {
                if (control is IconButton btn &&
                    btn != btnMenu)
                {
                    btn.Text = textos[index];
                    index++;
                }
            }
        }

        // =========================================
        // ABRIR FORMULARIOS
        // =========================================

        private void AbrirFormulario(
            Form frm)
        {
            panelContenedor.Controls.Clear();

            frm.TopLevel = false;

            frm.FormBorderStyle =
                FormBorderStyle.None;

            frm.Dock = DockStyle.Fill;

            frm.AutoScroll = true;

            panelContenedor.Controls.Add(frm);

            frm.Show();
        }

        // =========================================
        // PERMISOS
        // =========================================

        private void AplicarPermisos()
        {
            foreach (Control control in panelMenu.Controls)
            {
                if (control is IconButton btn)
                {
                    switch (btn.Name)
                    {
                        case "btnDashboard":
                            btn.Visible =
                                SesionUsuario.Permisos
                                .Contains("VER_DASHBOARD");
                            break;

                        case "btnProductos":
                            btn.Visible =
                                SesionUsuario.Permisos
                                .Contains("VER_PRODUCTOS");
                            break;

                        case "btnBodegas":
                            btn.Visible =
                                SesionUsuario.Permisos
                                .Contains("VER_BODEGAS");
                            break;

                        case "btnProveedores":
                            btn.Visible =
                                SesionUsuario.Permisos
                                .Contains("VER_PROVEEDORES");
                            break;

                        case "btnMovimientos":
                            btn.Visible =
                                SesionUsuario.Permisos
                                .Contains("VER_MOVIMIENTOS");
                            break;

                        case "btnKardex":
                            btn.Visible =
                                SesionUsuario.Permisos
                                .Contains("VER_KARDEX");
                            break;

                        case "btnStock":
                            btn.Visible =
                                SesionUsuario.Permisos
                                .Contains("VER_STOCK");
                            break;

                        case "btnTransferencias":
                            btn.Visible =
                                SesionUsuario.Permisos
                                .Contains("VER_TRANSFERENCIAS");
                            break;

                        case "btnUsuarios":
                            btn.Visible =
                                SesionUsuario.Permisos
                                .Contains("VER_USUARIOS");
                            break;

                        case "btnRoles":
                            btn.Visible =
                                SesionUsuario.Permisos
                                .Contains("VER_ROLES");
                            break;

                        case "btnLogs":
                            btn.Visible =
                                SesionUsuario.Permisos
                                .Contains("VER_LOGS");
                            break;

                        case "btnBackup":
                            btn.Visible =
                                SesionUsuario.Permisos
                                .Contains("VER_BACKUP");
                            break;
                    }
                }
            }
        }

        // =========================================
        // EVENTOS
        // =========================================

        private void BtnDashboard_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(new FrmInicio());
        }

        private void BtnProductos_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(new FrmProductos());
        }

        private void BtnBodegas_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(new FrmBodegas());
        }

        private void BtnProveedores_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(new FrmProveedores());
        }

        private void BtnMovimientos_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmMovimientosInventario());
        }

        private void BtnKardex_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(new FrmKardex());
        }

        private void BtnStock_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(new FrmStockBodega());
        }

        private void BtnTransferencias_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmTransferencias());
        }

        private void BtnUsuarios_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(new FrmUsuarios());
        }

        private void BtnRoles_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(new FrmRoles());
        }

        private void BtnLogs_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(new FrmLogs());
        }

        private void BtnBackup_Click(
    object sender,
    EventArgs e)
        {
            AbrirFormulario(
                new FrmBackup());
        }

        private void BtnAjustes_Click(
    object sender,
    EventArgs e)
        {
            AbrirFormulario(
                new FrmAjustes());
        }

        private void BtnSalir_Click(
            object sender,
            EventArgs e)
        {
            DialogResult resultado =
                MessageBox.Show(
                    "¿Desea cerrar sesión?",
                    "Cerrar sesión",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                FrmLogin login =
                    new FrmLogin();

                login.Show();

                this.Close();
            }
        }
    }
}