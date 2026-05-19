using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

using Sistema_Inventario.Datos;

namespace Sistema_Inventario.Presentacion
{
    public partial class FrmInicio : Form
    {
        Conexion cn = new Conexion();

        private DataGridView dgvActividad;

        public FrmInicio()
        {
            InitializeComponent();

            ConstruirDashboard();
        }

        private void FrmInicio_Load(
            object sender,
            EventArgs e)
        {
            CargarIndicadores();

            CargarActividad();
        }

        private void ConstruirDashboard()
        {
            this.BackColor =
                Color.FromArgb(243, 244, 246);

            this.AutoScroll = true;

            Panel contenedor =
                new Panel();

            contenedor.Dock =
                DockStyle.Fill;

            contenedor.Padding =
                new Padding(25);

            contenedor.BackColor =
                Color.FromArgb(243, 244, 246);

            this.Controls.Add(contenedor);

            Label titulo =
                new Label();

            titulo.Text =
                "Dashboard";

            titulo.Font =
                new Font(
                    "Segoe UI",
                    24,
                    FontStyle.Bold);

            titulo.ForeColor =
                Color.FromArgb(17, 24, 39);

            titulo.AutoSize = true;

            titulo.Location =
                new Point(15, 15);

            contenedor.Controls.Add(titulo);

            FlowLayoutPanel cards =
                new FlowLayoutPanel();

            cards.Location =
                new Point(10, 80);

            cards.Width =
                this.Width - 60;

            cards.Height = 180;

            cards.BackColor =
                Color.Transparent;

            cards.WrapContents = false;

            cards.AutoScroll = false;

            contenedor.Controls.Add(cards);

            panelClientes =
                CrearCard(
                    "Bodegas",
                    out lblClientes);

            panelProductos =
                CrearCard(
                    "Productos",
                    out lblProductos);

            panelVentas =
                CrearCard(
                    "Movimientos",
                    out lblVentas);

            panelLogin =
                CrearCard(
                    "Último Login",
                    out lblLogin);

            cards.Controls.Add(panelClientes);
            cards.Controls.Add(panelProductos);
            cards.Controls.Add(panelVentas);
            cards.Controls.Add(panelLogin);

            Panel panelTabla =
                new Panel();

            panelTabla.Location =
                new Point(10, 280);

            panelTabla.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            panelTabla.Width =
                this.Width - 60;

            panelTabla.Height = 430;

            panelTabla.BackColor =
                Color.White;

            contenedor.Controls.Add(panelTabla);

            Label lblActividad =
                new Label();

            lblActividad.Text =
                "Actividad reciente del sistema";

            lblActividad.Font =
                new Font(
                    "Segoe UI",
                    16,
                    FontStyle.Bold);

            lblActividad.ForeColor =
                Color.FromArgb(17, 24, 39);

            lblActividad.AutoSize = true;

            lblActividad.Location =
                new Point(20, 20);

            panelTabla.Controls.Add(lblActividad);

            dgvActividad =
                new DataGridView();

            dgvActividad.Location =
                new Point(20, 70);

            dgvActividad.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right |
                AnchorStyles.Bottom;

            dgvActividad.Width =
                panelTabla.Width - 40;

            dgvActividad.Height = 330;

            dgvActividad.BackgroundColor =
                Color.White;

            dgvActividad.BorderStyle =
                BorderStyle.None;

            dgvActividad.AllowUserToAddRows =
                false;

            dgvActividad.AllowUserToDeleteRows =
                false;

            dgvActividad.ReadOnly = true;

            dgvActividad.RowHeadersVisible =
                false;

            dgvActividad.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvActividad.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvActividad.ColumnHeadersHeight = 40;

            dgvActividad.EnableHeadersVisualStyles =
                false;

            dgvActividad.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(37, 99, 235);

            dgvActividad.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvActividad.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold);

            dgvActividad.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10);

            dgvActividad.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(219, 234, 254);

            dgvActividad.DefaultCellStyle.SelectionForeColor =
                Color.Black;

            panelTabla.Controls.Add(dgvActividad);
        }

        private Panel CrearCard(
            string titulo,
            out Label lblValor)
        {
            Panel panel =
                new Panel();

            panel.Size =
                new Size(240, 140);

            panel.Margin =
                new Padding(15);

            panel.BackColor =
                Color.White;

            Label lblTitulo =
                new Label();

            lblTitulo.Text =
                titulo;

            lblTitulo.Font =
                new Font(
                    "Segoe UI",
                    16,
                    FontStyle.Bold);

            lblTitulo.ForeColor =
                Color.FromArgb(100, 116, 139);

            lblTitulo.AutoSize = true;

            lblTitulo.Location =
                new Point(25, 20);

            panel.Controls.Add(lblTitulo);

            lblValor =
                new Label();

            lblValor.Text = "0";

            lblValor.Font =
                new Font(
                    "Segoe UI",
                    30,
                    FontStyle.Bold);

            lblValor.ForeColor =
                Color.FromArgb(37, 99, 235);

            lblValor.AutoSize = true;

            lblValor.Location =
                new Point(35, 60);

            panel.Controls.Add(lblValor);

            return panel;
        }

        private void CargarIndicadores()
        {
            try
            {
                SqlConnection conexion =
                    cn.AbrirConexion();

                // =====================================
                // PRODUCTOS
                // =====================================

                SqlCommand cmdProductos =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM Productos",
                        conexion);

                lblProductos.Text =
                    cmdProductos.ExecuteScalar().ToString();

                // =====================================
                // BODEGAS
                // =====================================

                SqlCommand cmdBodegas =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM Bodegas",
                        conexion);

                lblClientes.Text =
                    cmdBodegas.ExecuteScalar().ToString();

                // =====================================
                // MOVIMIENTOS
                // =====================================

                SqlCommand cmdMovimientos =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM MovimientosInventario",
                        conexion);

                lblVentas.Text =
                    cmdMovimientos.ExecuteScalar().ToString();

                // =====================================
                // ULTIMO LOGIN
                // =====================================

                SqlCommand cmdLogin =
                    new SqlCommand(
                        "SELECT TOP 1 Usuario FROM LogsSistema ORDER BY Fecha DESC",
                        conexion);

                object login =
                    cmdLogin.ExecuteScalar();

                if (login != null)
                {
                    lblLogin.Text =
                        login.ToString();
                }

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarActividad()
        {
            try
            {
                SqlConnection conexion =
                    cn.AbrirConexion();

                SqlDataAdapter da =
                    new SqlDataAdapter(
                        @"SELECT TOP 10
                        Usuario,
                        Fecha,
                        Descripcion
                        FROM LogsSistema
                        ORDER BY Fecha DESC",
                        conexion);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                dgvActividad.DataSource = dt;

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}