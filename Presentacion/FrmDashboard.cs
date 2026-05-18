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

        // PANEL CONTENEDOR
        private Panel panelContenedor;

        // CONTROL MENU
        bool menuExpandido = true;

        public FrmDashboard()
        {
            InitializeComponent();

            CrearSidebar();
            CrearTopbar();
            CrearContenedor();

            AbrirFormulario(new FrmInicio());
        }

        // =====================================================
        // SIDEBAR
        // =====================================================
        private void CrearSidebar()
        {
            sidebar = new Panel();

            sidebar.Dock = DockStyle.Left;
            sidebar.Width = 220;

            sidebar.BackColor =
                Color.FromArgb(15, 23, 42);

            this.Controls.Add(sidebar);

            sidebar.BringToFront();

            // =========================================
            // BOTON MENU
            // =========================================
            Button btnMenu = new Button();

            btnMenu.Text = "☰";

            btnMenu.Font =
                new Font(
                    "Segoe UI",
                    18,
                    FontStyle.Bold);

            btnMenu.ForeColor =
                Color.White;

            btnMenu.BackColor =
                Color.FromArgb(30, 41, 59);

            btnMenu.FlatStyle =
                FlatStyle.Flat;

            btnMenu.FlatAppearance.BorderSize = 0;

            btnMenu.Size =
                new Size(50, 50);

            btnMenu.Location =
                new Point(10, 10);

            // EVENTO CLICK
            btnMenu.Click += BtnMenu_Click;

            sidebar.Controls.Add(btnMenu);

            int top = 80;

            AgregarBoton(
                "Dashboard",
                IconChar.ChartBar,
                btnDashboard_Click,
                top);

            top += 50;

            AgregarBoton(
                "Productos",
                IconChar.BoxOpen,
                btnProductos_Click,
                top);

            top += 50;

            AgregarBoton(
                "Clientes",
                IconChar.Users,
                btnClientes_Click,
                top);

            top += 50;

            AgregarBoton(
                "Ventas",
                IconChar.CashRegister,
                btnVentas_Click,
                top);

            top += 50;

            AgregarBoton(
                "Backup",
                IconChar.Database,
                btnBackup_Click,
                top);

            top += 50;

            AgregarBoton(
                "Logs",
                IconChar.ClipboardList,
                btnLogs_Click,
                top);

            top += 50;

            AgregarBoton(
                "Salir",
                IconChar.SignOutAlt,
                btnSalir_Click,
                top);
        }

        // =====================================================
        // TOPBAR
        // =====================================================
        private void CrearTopbar()
        {
            topbar = new Panel();

            topbar.Dock = DockStyle.Top;

            topbar.Height = 70;

            topbar.BackColor = Color.White;

            this.Controls.Add(topbar);

            topbar.BringToFront();

            Label titulo = new Label();

            titulo.Text =
                "Sistema Inventario";

            titulo.Font =
                new Font(
                    "Segoe UI",
                    18,
                    FontStyle.Bold);

            titulo.ForeColor =
                Color.FromArgb(17, 24, 39);

            titulo.AutoSize = true;

            titulo.Location =
                new Point(30, 18);

            topbar.Controls.Add(titulo);

            Label fecha = new Label();

            fecha.Text =
                DateTime.Now.ToString(
                    "dd/MM/yyyy HH:mm:ss");

            fecha.Font =
                new Font(
                    "Segoe UI",
                    10);

            fecha.ForeColor =
                Color.Gray;

            fecha.AutoSize = true;

            fecha.Location =
                new Point(900, 25);

            topbar.Controls.Add(fecha);
        }

        // =====================================================
        // PANEL CONTENEDOR
        // =====================================================
        private void CrearContenedor()
        {
            panelContenedor = new Panel();

            panelContenedor.Dock =
                DockStyle.Fill;

            panelContenedor.BackColor =
                Color.WhiteSmoke;

            this.Controls.Add(panelContenedor);

            panelContenedor.BringToFront();
        }

        // =====================================================
        // AGREGAR BOTONES
        // =====================================================
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

            boton.IconSize = 22;

            boton.Width = 220;

            boton.Height = 45;

            boton.Top = top;

            boton.Left = 0;

            boton.FlatStyle =
                FlatStyle.Flat;

            boton.FlatAppearance.BorderSize = 0;

            boton.ForeColor =
                Color.White;

            boton.Font =
                new Font(
                    "Segoe UI",
                    11F);

            boton.TextAlign =
                ContentAlignment.MiddleLeft;

            boton.ImageAlign =
                ContentAlignment.MiddleLeft;

            boton.Padding =
                new Padding(20, 0, 0, 0);

            boton.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            boton.BackColor =
                Color.FromArgb(15, 23, 42);

            boton.Cursor =
                Cursors.Hand;

            boton.MouseEnter += (s, e) =>
            {
                boton.BackColor =
                    Color.FromArgb(37, 99, 235);
            };

            boton.MouseLeave += (s, e) =>
            {
                boton.BackColor =
                    Color.FromArgb(15, 23, 42);
            };

            boton.Click += evento;

            sidebar.Controls.Add(boton);
        }

        // =====================================================
        // BOTON HAMBURGUESA
        // =====================================================
        private void BtnMenu_Click(
            object sender,
            EventArgs e)
        {
            if (menuExpandido)
            {
                sidebar.Width = 70;

                menuExpandido = false;
            }
            else
            {
                sidebar.Width = 220;

                menuExpandido = true;
            }
        }

        // =====================================================
        // ABRIR FORMULARIOS
        // =====================================================
        private void AbrirFormulario(Form formulario)
        {
            panelContenedor.Controls.Clear();

            formulario.TopLevel = false;

            formulario.FormBorderStyle =
                FormBorderStyle.None;

            formulario.Dock =
                DockStyle.Fill;

            panelContenedor.Controls.Add(formulario);

            formulario.Show();
        }

        // =====================================================
        // BOTONES MENU
        // =====================================================
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

        private void btnClientes_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmClientes());
        }

        private void btnVentas_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmVentas());
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
    }
}