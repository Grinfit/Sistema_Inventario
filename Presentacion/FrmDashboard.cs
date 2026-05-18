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

        private Label lblTitulo;

        private Label lblSubtitulo;

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

        private void CrearSidebar()
        {
            sidebar = new Panel();

            sidebar.Dock =
                DockStyle.Left;

            sidebar.Width = 240;

            sidebar.BackColor =
                Color.FromArgb(
                    11,
                    31,
                    58);

            this.Controls.Add(sidebar);

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
                new Size(55, 55);

            btnMenu.Location =
                new Point(15, 15);

            btnMenu.Cursor =
                Cursors.Hand;

            btnMenu.Click += BtnMenu_Click;

            sidebar.Controls.Add(btnMenu);

            int top = 100;

            AgregarBoton(
                "Dashboard",
                IconChar.ChartPie,
                btnDashboard_Click,
                top);

            top += 60;

            AgregarBoton(
                "Productos",
                IconChar.BoxOpen,
                btnProductos_Click,
                top);

            top += 60;

            AgregarBoton(
                "Clientes",
                IconChar.Users,
                btnClientes_Click,
                top);

            top += 60;

            AgregarBoton(
                "Ventas",
                IconChar.CashRegister,
                btnVentas_Click,
                top);

            top += 60;

            AgregarBoton(
                "Backup",
                IconChar.Database,
                btnBackup_Click,
                top);

            top += 60;

            AgregarBoton(
                "Logs",
                IconChar.FileLines,
                btnLogs_Click,
                top);

            top += 60;

            AgregarBoton(
                "Salir",
                IconChar.RightFromBracket,
                btnSalir_Click,
                top);
        }

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

            boton.Width = 240;

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

            sidebar.Controls.Add(boton);
        }

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
                    22F,
                    FontStyle.Bold);

            lblTitulo.ForeColor =
                Color.FromArgb(
                    11,
                    31,
                    58);

            lblTitulo.AutoSize =
                true;

            lblTitulo.Location =
                new Point(35, 15);

            topbar.Controls.Add(
                lblTitulo);

            lblSubtitulo =
                new Label();

            lblSubtitulo.Text =
                "Panel Administrativo";

            lblSubtitulo.Font =
                new Font(
                    "Segoe UI",
                    10F);

            lblSubtitulo.ForeColor =
                Color.Gray;

            lblSubtitulo.AutoSize =
                true;

            lblSubtitulo.Location =
                new Point(38, 55);

            topbar.Controls.Add(
                lblSubtitulo);

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

        private void BtnMenu_Click(
            object sender,
            EventArgs e)
        {
            if (menuExpandido)
            {
                sidebar.Width = 70;

                foreach (
                    Control control
                    in sidebar.Controls)
                {
                    if (
                        control
                        is IconButton)
                    {
                        IconButton btn =
                            (IconButton)control;

                        btn.Text = "";

                        btn.Padding =
                            new Padding(0);

                        btn.IconSize = 30;
                    }
                }

                menuExpandido = false;
            }
            else
            {
                sidebar.Controls.Clear();

                sidebar.Width = 240;

                CrearSidebar();

                menuExpandido = true;
            }
        }

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
