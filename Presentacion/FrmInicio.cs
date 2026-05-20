// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

// IMPORTACION DE LA CAPA DE DATOS
using Sistema_Inventario.Datos;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO PRINCIPAL DE INICIO
    public partial class FrmInicio : Form
    {
        // OBJETO DE CONEXION A BASE DE DATOS
        Conexion cn =
            new Conexion();

        // DATAGRIDVIEW PARA ACTIVIDAD RECIENTE
        private DataGridView dgvActividad;

        // GRAFICA DE MOVIMIENTOS
        private Chart chartMovimientos;

        // CONSTRUCTOR DEL FORMULARIO
        public FrmInicio()
        {
            InitializeComponent();

            // CONSTRUYE EL DASHBOARD
            ConstruirDashboard();
        }

        // EVENTO LOAD DEL FORMULARIO
        private void FrmInicio_Load(
            object sender,
            EventArgs e)
        {
            // CARGA LOS INDICADORES
            CargarIndicadores();

            // CARGA LA ACTIVIDAD RECIENTE
            CargarActividad();

            // CARGA LA GRAFICA
            CargarGraficaMovimientos();
        }

        // DASHBOARD

        private void ConstruirDashboard()
        {
            // COLOR DE FONDO DEL FORMULARIO
            this.BackColor =
                Color.FromArgb(243, 244, 246);

            // ACTIVA EL SCROLL
            this.AutoScroll = true;

            // PANEL CONTENEDOR

            Panel contenedor =
                new Panel();

            contenedor.Location =
                new Point(0, 0);

            contenedor.Size =
                new Size(1500, 1400);

            contenedor.BackColor =
                Color.FromArgb(243, 244, 246);

            this.Controls.Add(contenedor);

            // TITULO

            Label titulo =
                new Label();

            titulo.Text =
                "Dashboard";

            titulo.Font =
                new Font(
                    "Segoe UI",
                    30,
                    FontStyle.Bold);

            titulo.ForeColor =
                Color.FromArgb(17, 24, 39);

            titulo.AutoSize = true;

            titulo.Location =
                new Point(20, 20);

            contenedor.Controls.Add(titulo);

            // CARDS KPI

            FlowLayoutPanel cards =
                new FlowLayoutPanel();

            cards.Location =
                new Point(10, 110);

            cards.Size =
                new Size(1320, 180);

            cards.BackColor =
                Color.Transparent;

            cards.WrapContents =
                false;

            contenedor.Controls.Add(cards);

            // CARD BODEGAS
            panelClientes =
                CrearCard(
                    "Bodegas",
                    out lblClientes,
                    Color.FromArgb(52, 152, 219));

            // CARD PRODUCTOS
            panelProductos =
                CrearCard(
                    "Productos",
                    out lblProductos,
                    Color.FromArgb(46, 204, 113));

            // CARD STOCK BAJO
            panelVentas =
                CrearCard(
                    "Stock Bajo",
                    out lblVentas,
                    Color.FromArgb(231, 76, 60));

            // CARD TRANSFERENCIAS
            panelLogin =
                CrearCard(
                    "Transferencias Hoy",
                    out lblLogin,
                    Color.FromArgb(155, 89, 182));

            // AGREGA LAS CARDS
            cards.Controls.Add(panelClientes);

            cards.Controls.Add(panelProductos);

            cards.Controls.Add(panelVentas);

            cards.Controls.Add(panelLogin);

            // PANEL ACTIVIDAD

            Panel panelTabla =
                new Panel();

            panelTabla.Location =
                new Point(10, 330);

            panelTabla.Size =
                new Size(1320, 420);

            panelTabla.BackColor =
                Color.White;

            panelTabla.BorderStyle =
                BorderStyle.FixedSingle;

            contenedor.Controls.Add(panelTabla);

            // TITULO ACTIVIDAD

            Label lblActividad =
                new Label();

            lblActividad.Text =
                "Actividad reciente del sistema";

            lblActividad.Font =
                new Font(
                    "Segoe UI",
                    18,
                    FontStyle.Bold);

            lblActividad.ForeColor =
                Color.FromArgb(17, 24, 39);

            lblActividad.AutoSize = true;

            lblActividad.Location =
                new Point(20, 20);

            panelTabla.Controls.Add(lblActividad);

            // GRID

            dgvActividad =
                new DataGridView();

            dgvActividad.Location =
                new Point(20, 80);

            dgvActividad.Size =
                new Size(1270, 300);

            dgvActividad.BackgroundColor =
                Color.White;

            dgvActividad.BorderStyle =
                BorderStyle.None;

            dgvActividad.AllowUserToAddRows =
                false;

            dgvActividad.AllowUserToDeleteRows =
                false;

            dgvActividad.ReadOnly =
                true;

            dgvActividad.RowHeadersVisible =
                false;

            dgvActividad.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvActividad.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvActividad.ColumnHeadersHeight =
                45;

            dgvActividad.EnableHeadersVisualStyles =
                false;

            dgvActividad.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(10, 35, 66);

            dgvActividad.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvActividad.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold);

            dgvActividad.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10);

            dgvActividad.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(219, 234, 254);

            dgvActividad.DefaultCellStyle.SelectionForeColor =
                Color.Black;

            dgvActividad.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 247, 250);

            panelTabla.Controls.Add(dgvActividad);

            // PANEL GRAFICA

            Panel panelGrafica =
                new Panel();

            panelGrafica.Location =
                new Point(10, 790);

            panelGrafica.Size =
                new Size(1320, 420);

            panelGrafica.BackColor =
                Color.White;

            panelGrafica.BorderStyle =
                BorderStyle.FixedSingle;

            contenedor.Controls.Add(panelGrafica);

            // TITULO GRAFICA

            Label lblGrafica =
                new Label();

            lblGrafica.Text =
                "Movimientos últimos 7 días";

            lblGrafica.Font =
                new Font(
                    "Segoe UI",
                    18,
                    FontStyle.Bold);

            lblGrafica.ForeColor =
                Color.FromArgb(17, 24, 39);

            lblGrafica.AutoSize =
                true;

            lblGrafica.Location =
                new Point(20, 20);

            panelGrafica.Controls.Add(lblGrafica);

            // CHART

            chartMovimientos =
                new Chart();

            chartMovimientos.Location =
                new Point(20, 70);

            chartMovimientos.Size =
                new Size(1250, 300);

            ChartArea area =
                new ChartArea();

            area.BackColor =
                Color.White;

            area.AxisX.MajorGrid.Enabled =
                false;

            area.AxisY.MajorGrid.LineColor =
                Color.Gainsboro;

            chartMovimientos.ChartAreas.Add(area);

            Series serie =
                new Series();

            serie.ChartType =
                SeriesChartType.Column;

            serie.Color =
                Color.FromArgb(52, 152, 219);

            serie.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold);

            chartMovimientos.Series.Add(serie);

            panelGrafica.Controls.Add(
                chartMovimientos);
        }

        // CREAR CARD

        private Panel CrearCard(
            string titulo,
            out Label lblValor,
            Color color)
        {
            // CREA EL PANEL
            Panel panel =
                new Panel();

            panel.Size =
                new Size(280, 150);

            panel.Margin =
                new Padding(15);

            panel.BackColor =
                Color.White;

            panel.BorderStyle =
                BorderStyle.FixedSingle;

            // CREA BARRA SUPERIOR
            Panel barra =
                new Panel();

            barra.Dock =
                DockStyle.Top;

            barra.Height =
                8;

            barra.BackColor =
                color;

            panel.Controls.Add(barra);

            // CREA LABEL TITULO
            Label lblTitulo =
                new Label();

            lblTitulo.Text =
                titulo;

            lblTitulo.Font =
                new Font(
                    "Segoe UI",
                    15,
                    FontStyle.Bold);

            lblTitulo.ForeColor =
                Color.FromArgb(100, 116, 139);

            lblTitulo.AutoSize =
                true;

            lblTitulo.Location =
                new Point(25, 30);

            panel.Controls.Add(lblTitulo);

            // CREA LABEL VALOR
            lblValor =
                new Label();

            lblValor.Text =
                "0";

            lblValor.Font =
                new Font(
                    "Segoe UI",
                    36,
                    FontStyle.Bold);

            lblValor.ForeColor =
                color;

            lblValor.AutoSize =
                true;

            lblValor.Location =
                new Point(30, 65);

            panel.Controls.Add(lblValor);

            return panel;
        }

        // KPI

        private void CargarIndicadores()
        {
            try
            {
                // ABRE LA CONEXION
                SqlConnection conexion =
                    cn.AbrirConexion();

                // CONSULTA PRODUCTOS
                SqlCommand cmdProductos =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM Productos",
                        conexion);

                lblProductos.Text =
                    cmdProductos.ExecuteScalar().ToString();

                // CONSULTA BODEGAS
                SqlCommand cmdBodegas =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM Bodegas",
                        conexion);

                lblClientes.Text =
                    cmdBodegas.ExecuteScalar().ToString();

                // CONSULTA STOCK BAJO
                SqlCommand cmdStockBajo =
                    new SqlCommand(
                        @"SELECT COUNT(*)
                        FROM StockBodega
                        WHERE StockActual <= 5",
                        conexion);

                lblVentas.Text =
                    cmdStockBajo.ExecuteScalar().ToString();

                // CONSULTA TRANSFERENCIAS
                SqlCommand cmdTransferencias =
                    new SqlCommand(
                        @"SELECT COUNT(*)
                        FROM TransferenciasBodega
                        WHERE CAST(Fecha AS DATE)
                        = CAST(GETDATE() AS DATE)",
                        conexion);

                lblLogin.Text =
                    cmdTransferencias.ExecuteScalar().ToString();

                // CIERRA LA CONEXION
                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                // MUESTRA EL ERROR
                MessageBox.Show(
                    ex.Message);
            }
        }

        // ACTIVIDAD

        private void CargarActividad()
        {
            try
            {
                // ABRE LA CONEXION
                SqlConnection conexion =
                    cn.AbrirConexion();

                // CONSULTA LOGS
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        @"SELECT TOP 15
    Evento,
    Usuario,
    Fecha,
    Descripcion
FROM LogsSistema
ORDER BY Fecha DESC",
                        conexion);

                // TABLA TEMPORAL
                DataTable dt =
                    new DataTable();

                // LLENA LA TABLA
                da.Fill(dt);

                // MUESTRA LOS DATOS
                dgvActividad.DataSource =
                    dt;

                // CIERRA LA CONEXION
                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                // MUESTRA EL ERROR
                MessageBox.Show(
                    ex.Message);
            }
        }

        // GRAFICA

        private void CargarGraficaMovimientos()
        {
            try
            {
                // ABRE LA CONEXION
                SqlConnection conexion =
                    cn.AbrirConexion();

                // CONSULTA MOVIMIENTOS
                SqlCommand cmd =
                    new SqlCommand(
                        @"SELECT
                            CAST(Fecha AS DATE) AS Dia,
                            COUNT(*) AS Total
                        FROM MovimientosInventario
                        WHERE Fecha >= DATEADD(DAY, -7, GETDATE())
                        GROUP BY CAST(Fecha AS DATE)
                        ORDER BY Dia",
                        conexion);

                // EJECUTA EL READER
                SqlDataReader dr =
                    cmd.ExecuteReader();

                // LIMPIA LA GRAFICA
                chartMovimientos.Series[0]
                    .Points.Clear();

                // RECORRE LOS DATOS
                while (dr.Read())
                {
                    chartMovimientos.Series[0]
                        .Points.AddXY(
                        Convert.ToDateTime(
                            dr["Dia"])
                            .ToString("dd/MM"),
                        dr["Total"]);
                }

                // CIERRA EL READER
                dr.Close();

                // CIERRA LA CONEXION
                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                // MUESTRA EL ERROR
                MessageBox.Show(
                    ex.Message);
            }
        }
    }
}