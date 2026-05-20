// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using FontAwesome.Sharp;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO PRINCIPAL DEL SISTEMA
    public partial class FrmDashboard : Form
    {
        // PANEL MENU LATERAL
        private Panel panelMenu;

        // PANEL CONTENEDOR DE FORMULARIOS
        private Panel panelContenedor;

        // PANEL SUPERIOR
        private Panel panelTop;

        // BOTON MENU HAMBURGUESA
        private IconButton btnMenu;

        // VARIABLE PARA CONTROLAR EL MENU
        private bool menuExpandido = true;

        // TIMER PARA EL RELOJ
        private Timer reloj;

        // OBJETO LOGGER PARA REGISTRO DE LOGS
        Logger log = new Logger();

        // CONSTRUCTOR DEL FORMULARIO
        public FrmDashboard()
        {
            InitializeComponent();

            // CONFIGURA EL FORMULARIO
            ConfigurarFormulario();

            // CREA EL MENU
            CrearMenu();

            // CREA EL PANEL SUPERIOR
            CrearTop();

            // CREA EL PANEL CONTENEDOR
            CrearContenedor();

            // APLICA LOS PERMISOS DEL USUARIO
            AplicarPermisos();

            // REORGANIZA EL MENU
            ReorganizarMenu();

            // ABRE EL FORMULARIO INICIAL
            AbrirFormulario(new FrmInicio());
        }

        // METODO PARA REORGANIZAR EL MENU
        private void ReorganizarMenu()
        {
            int top = 90;

            foreach (Control control in panelMenu.Controls)
            {
                // NO MOVER EL BOTON MENU
                if (control == btnMenu)
                    continue;

                // VALIDACION DE LABELS
                if (control is Label lbl)
                {
                    bool mostrarTitulo = false;

                    string texto = lbl.Text;

                    // VALIDAR SECCION CATALOGOS
                    if (texto == "CATÁLOGOS")
                    {
                        mostrarTitulo =
                            panelMenu.Controls["btnDashboard"].Visible ||
                            panelMenu.Controls["btnProductos"].Visible ||
                            panelMenu.Controls["btnBodegas"].Visible ||
                            panelMenu.Controls["btnProveedores"].Visible;
                    }

                    // VALIDAR SECCION INVENTARIO
                    else if (texto == "INVENTARIO")
                    {
                        mostrarTitulo =
                            panelMenu.Controls["btnMovimientos"].Visible ||
                            panelMenu.Controls["btnKardex"].Visible ||
                            panelMenu.Controls["btnStock"].Visible ||
                            panelMenu.Controls["btnTransferencias"].Visible;
                    }

                    // VALIDAR SECCION SEGURIDAD
                    else if (texto == "SEGURIDAD")
                    {
                        mostrarTitulo =
                            panelMenu.Controls["btnUsuarios"].Visible ||
                            panelMenu.Controls["btnRoles"].Visible ||
                            panelMenu.Controls["btnLogs"].Visible;
                    }

                    // VALIDAR SECCION SISTEMA
                    else if (texto == "SISTEMA")
                    {
                        mostrarTitulo =
                            panelMenu.Controls["btnBackup"].Visible ||
                            panelMenu.Controls["btnAjustes"].Visible;
                    }

                    // DEFINE VISIBILIDAD DEL LABEL
                    lbl.Visible = mostrarTitulo;

                    // POSICION DEL LABEL
                    if (mostrarTitulo)
                    {
                        lbl.Top = top;
                        top += 40;
                    }
                }

                // VALIDACION DE BOTONES
                if (control is IconButton btn &&
                    btn.Visible &&
                    btn != btnMenu)
                {
                    // POSICION DEL BOTON
                    btn.Top = top;

                    top += 55;
                }
            }
        }

        // METODO PARA CONFIGURAR EL FORMULARIO
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

        // METODO PARA CREAR EL MENU
        private void CrearMenu()
        {
            // CREA EL PANEL MENU
            panelMenu = new Panel();

            panelMenu.Dock = DockStyle.Left;

            panelMenu.Width = 250;

            panelMenu.BackColor =
                Color.FromArgb(7, 31, 61);

            panelMenu.AutoScroll = true;

            panelMenu.HorizontalScroll.Enabled = false;

            panelMenu.HorizontalScroll.Visible = false;

            this.Controls.Add(panelMenu);

            // BOTON MENU
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

            // TITULO CATALOGOS
            AgregarTitulo("CATÁLOGOS", top);
            top += 45;

            // BOTON DASHBOARD
            AgregarBoton(
                "Dashboard",
                IconChar.ChartPie,
                BtnDashboard_Click,
                top);

            top += 60;

            // BOTON PRODUCTOS
            AgregarBoton(
                "Productos",
                IconChar.BoxOpen,
                BtnProductos_Click,
                top);

            top += 60;

            // BOTON BODEGAS
            AgregarBoton(
                "Bodegas",
                IconChar.Warehouse,
                BtnBodegas_Click,
                top);

            top += 60;

            // BOTON PROVEEDORES
            AgregarBoton(
                "Proveedores",
                IconChar.Truck,
                BtnProveedores_Click,
                top);

            top += 80;

            // TITULO INVENTARIO
            AgregarTitulo("INVENTARIO", top);
            top += 45;

            // BOTON MOVIMIENTOS
            AgregarBoton(
                "Movimientos",
                IconChar.RightLeft,
                BtnMovimientos_Click,
                top);

            top += 60;

            // BOTON KARDEX
            AgregarBoton(
                "Kardex",
                IconChar.ClipboardList,
                BtnKardex_Click,
                top);

            top += 60;

            // BOTON STOCK
            AgregarBoton(
                "Stock",
                IconChar.BoxesStacked,
                BtnStock_Click,
                top);

            top += 60;

            // BOTON TRANSFERENCIAS
            AgregarBoton(
                "Transferencias",
                IconChar.ArrowsLeftRight,
                BtnTransferencias_Click,
                top);

            top += 80;

            // TITULO SEGURIDAD
            AgregarTitulo("SEGURIDAD", top);
            top += 45;

            // BOTON USUARIOS
            AgregarBoton(
                "Usuarios",
                IconChar.Users,
                BtnUsuarios_Click,
                top);

            top += 60;

            // BOTON ROLES
            AgregarBoton(
                "Roles",
                IconChar.UserShield,
                BtnRoles_Click,
                top);

            top += 60;

            // BOTON LOGS
            AgregarBoton(
                "Logs",
                IconChar.FileLines,
                BtnLogs_Click,
                top);

            top += 80;

            // TITULO SISTEMA
            AgregarTitulo("SISTEMA", top);
            top += 45;

            // BOTON BACKUP
            AgregarBoton(
                "Backup",
                IconChar.Database,
                BtnBackup_Click,
                top);

            top += 60;

            // BOTON AJUSTES
            AgregarBoton(
                "Ajustes",
                IconChar.ScrewdriverWrench,
                BtnAjustes_Click,
                top);

            top += 60;

            // BOTON SALIR
            IconButton btnSalir =
                AgregarBoton(
                    "Cerrar Sesión",
                    IconChar.RightFromBracket,
                    BtnSalir_Click,
                    top);

            // COLOR BOTON SALIR
            btnSalir.BackColor =
                Color.FromArgb(180, 45, 45);
        }

        // METODO PARA AGREGAR TITULOS
        private void AgregarTitulo(
            string texto,
            int top)
        {
            // CREA LABEL
            Label lbl = new Label();

            // TEXTO DEL LABEL
            lbl.Text = texto;

            // COLOR DEL LABEL
            lbl.ForeColor =
                Color.FromArgb(180, 190, 205);

            // FUENTE DEL LABEL
            lbl.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold);

            // AJUSTE AUTOMATICO
            lbl.AutoSize = true;

            // POSICION IZQUIERDA
            lbl.Left = 15;

            // POSICION SUPERIOR
            lbl.Top = top;

            // AGREGA EL LABEL
            panelMenu.Controls.Add(lbl);
        }

        // METODO PARA AGREGAR BOTONES
        private IconButton AgregarBoton(
     string texto,
     IconChar icono,
     EventHandler evento,
     int top)
        {
            // CREA EL BOTON
            IconButton btn =
                new IconButton();

            // NOMBRE DEL BOTON
            btn.Name =
                "btn" + texto.Replace(" ", "");

            // TAG DEL BOTON
            btn.Tag = texto;

            // TEXTO DEL BOTON
            btn.Text = texto;

            // ICONO DEL BOTON
            btn.IconChar = icono;

            // COLOR DEL ICONO
            btn.IconColor = Color.White;

            // TAMAÑO DEL ICONO
            btn.IconSize = 24;

            // RELACION TEXTO E IMAGEN
            btn.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            // ALINEACION DE IMAGEN
            btn.ImageAlign =
                ContentAlignment.MiddleLeft;

            // ALINEACION DEL TEXTO
            btn.TextAlign =
                ContentAlignment.MiddleLeft;

            // PADDING DEL BOTON
            btn.Padding =
                new Padding(15, 0, 0, 0);

            // COLOR DEL TEXTO
            btn.ForeColor = Color.White;

            // FUENTE DEL BOTON
            btn.Font =
                new Font(
                    "Segoe UI",
                    11);

            // ESTILO DEL BOTON
            btn.FlatStyle =
                FlatStyle.Flat;

            // BORDE DEL BOTON
            btn.FlatAppearance.BorderSize = 0;

            // COLOR DEL BOTON
            btn.BackColor =
                Color.FromArgb(7, 31, 61);

            // TAMAÑO DEL BOTON
            btn.Width = 240;

            btn.Height = 50;

            // POSICION IZQUIERDA
            btn.Left = 0;

            // POSICION SUPERIOR
            btn.Top = top;

            // CURSOR DEL BOTON
            btn.Cursor =
                Cursors.Hand;

            // EVENTO CLICK
            btn.Click += evento;

            // AGREGA EL BOTON
            panelMenu.Controls.Add(btn);

            return btn;
        }

        // METODO PARA CREAR EL PANEL SUPERIOR
        private void CrearTop()
        {
            // CREA PANEL SUPERIOR
            panelTop = new Panel();

            panelTop.Dock = DockStyle.Top;

            panelTop.Height = 70;

            panelTop.BackColor = Color.White;

            this.Controls.Add(panelTop);

            panelTop.BringToFront();

            // LABEL DEL SISTEMA
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

            // LABEL FECHA
            Label lblFecha =
                new Label();

            lblFecha.Name =
                "lblFecha";

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

            // TIMER DEL RELOJ
            reloj = new Timer();

            reloj.Interval = 1000;

            reloj.Tick += (s, e) =>
            {
                lblFecha.Text =
                    DateTime.Now.ToString(
                        "dd/MM/yyyy HH:mm:ss");
            };

            reloj.Start();

            // LABEL USUARIO
            Label lblUsuario =
                new Label();

            lblUsuario.Text =
                "Usuario: " +
                SesionUsuario.Usuario +
                " | Rol: " +
                SesionUsuario.Rol;

            lblUsuario.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold);

            lblUsuario.ForeColor =
                Color.FromArgb(52, 73, 94);

            lblUsuario.AutoSize = true;

            lblUsuario.Location =
                new Point(900, 45);

            panelTop.Controls.Add(lblUsuario);
        }

        // METODO PARA CREAR EL PANEL CONTENEDOR
        private void CrearContenedor()
        {
            // CREA PANEL CONTENEDOR
            panelContenedor = new Panel();

            panelContenedor.Dock =
                DockStyle.Fill;

            panelContenedor.BackColor =
                Color.FromArgb(245, 247, 250);

            panelContenedor.AutoScroll = false;

            this.Controls.Add(panelContenedor);

            panelContenedor.BringToFront();
        }

        // EVENTO MENU HAMBURGUESA
        private void BtnMenu_Click(
    object sender,
    EventArgs e)
        {
            // VALIDACION MENU EXPANDIDO
            if (menuExpandido)
            {
                panelMenu.Width = 70;

                foreach (Control control
                    in panelMenu.Controls)
                {
                    // OCULTA LABELS
                    if (control is Label lbl)
                    {
                        lbl.Visible = false;
                    }

                    // CONFIGURA BOTONES
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
                    // RESTAURA BOTONES
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

            // CAMBIA EL ESTADO DEL MENU
            menuExpandido =
                !menuExpandido;
        }

        // METODO PARA RESTAURAR TEXTO DE BOTONES
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
                // RESTAURA TEXTO DE BOTONES
                if (control is IconButton btn &&
                    btn != btnMenu)
                {
                    btn.Text = textos[index];

                    index++;
                }
            }
        }

        // METODO PARA ABRIR FORMULARIOS
        private void AbrirFormulario(
            Form frm)
        {
            // LIMPIA EL PANEL CONTENEDOR
            panelContenedor.Controls.Clear();

            // CONFIGURA EL FORMULARIO
            frm.TopLevel = false;

            frm.FormBorderStyle =
                FormBorderStyle.None;

            frm.Dock = DockStyle.Fill;

            frm.AutoScroll = true;

            // AGREGA EL FORMULARIO
            panelContenedor.Controls.Add(frm);

            frm.Show();
        }

        // METODO PARA APLICAR PERMISOS
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

        // EVENTO DASHBOARD
        private void BtnDashboard_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(new FrmInicio());
        }

        // EVENTO PRODUCTOS
        private void BtnProductos_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(new FrmProductos());
        }

        // EVENTO BODEGAS
        private void BtnBodegas_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(new FrmBodegas());
        }

        // EVENTO PROVEEDORES
        private void BtnProveedores_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(new FrmProveedores());
        }

        // EVENTO MOVIMIENTOS
        private void BtnMovimientos_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmMovimientosInventario());
        }

        // EVENTO KARDEX
        private void BtnKardex_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(new FrmKardex());
        }

        // EVENTO STOCK
        private void BtnStock_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(new FrmStockBodega());
        }

        // EVENTO TRANSFERENCIAS
        private void BtnTransferencias_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(
                new FrmTransferencias());
        }

        // EVENTO USUARIOS
        private void BtnUsuarios_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(new FrmUsuarios());
        }

        // EVENTO ROLES
        private void BtnRoles_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(new FrmRoles());
        }

        // EVENTO LOGS
        private void BtnLogs_Click(
            object sender,
            EventArgs e)
        {
            AbrirFormulario(new FrmLogs());
        }

        // EVENTO BACKUP
        private void BtnBackup_Click(
    object sender,
    EventArgs e)
        {
            AbrirFormulario(
                new FrmBackup());
        }

        // EVENTO AJUSTES
        private void BtnAjustes_Click(
    object sender,
    EventArgs e)
        {
            AbrirFormulario(
                new FrmAjustes());
        }

        // EVENTO CERRAR SESION
        private void BtnSalir_Click(
    object sender,
    EventArgs e)
        {
            // MENSAJE DE CONFIRMACION
            DialogResult resultado =
                MessageBox.Show(
                    "¿Desea cerrar sesión?",
                    "Cerrar sesión",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            // VALIDACION RESPUESTA
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    // REGISTRA EL LOGOUT
                    log.RegistrarLog(
                        "LOGOUT",
                        SesionUsuario.Usuario,
                        "Cierre de sesión correcto");

                    // CREA EL LOGIN
                    FrmLogin login =
                        new FrmLogin();

                    // MUESTRA EL LOGIN
                    login.Show();

                    // CIERRA EL DASHBOARD
                    this.Close();
                }
                catch (Exception ex)
                {
                    // MUESTRA ERROR
                    MessageBox.Show(
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}