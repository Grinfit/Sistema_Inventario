using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

using Sistema_Inventario.Datos;

namespace Sistema_Inventario.Presentacion
{
    public partial class FrmLogs : Form
    {
        Conexion cn = new Conexion();

        public FrmLogs()
        {
            InitializeComponent();

            ConfigurarEventos();
        }

        // =====================================================
        // LOAD
        // =====================================================

        private void FrmLogs_Load(
            object sender,
            EventArgs e)
        {
            CargarEventos();

            MostrarLogs();
        }

        // =====================================================
        // CARGAR EVENTOS COMBOBOX
        // =====================================================

        private void CargarEventos()
        {
            cboEvento.Items.Clear();

            cboEvento.Items.Add("TODOS");
            cboEvento.Items.Add("LOGIN");
            cboEvento.Items.Add("BACKUP");
            cboEvento.Items.Add("RESTORE");
            cboEvento.Items.Add("ERROR");
            cboEvento.Items.Add("VENTA");
            cboEvento.Items.Add("CLIENTE");
            cboEvento.Items.Add("PRODUCTO");

            cboEvento.SelectedIndex = 0;
        }

        // =====================================================
        // CONFIGURAR EVENTOS
        // =====================================================

        private void ConfigurarEventos()
        {
            btnBuscar.Click += BtnBuscar_Click;

            btnRefrescar.Click += BtnRefrescar_Click;

            btnLimpiar.Click += BtnLimpiar_Click;
        }

        // =====================================================
        // MOSTRAR LOGS
        // =====================================================

        private void MostrarLogs()
        {
            try
            {
                string query =
                    "SELECT * FROM LogsSistema ORDER BY Fecha DESC";

                SqlDataAdapter da =
                    new SqlDataAdapter(
                        query,
                        cn.AbrirConexion());

                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvLogs.DataSource = dt;

                lblTotalLogs.Text =
                    "Total Logs: " + dt.Rows.Count;

                ColorearEventos();

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // BUSCAR
        // =====================================================

        private void BtnBuscar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                string texto =
                    txtBuscar.Text.Trim();

                string evento =
                    cboEvento.Text;

                string query =
                    @"SELECT * FROM LogsSistema
                      WHERE
                      (Usuario LIKE @texto
                      OR Descripcion LIKE @texto)";

                if (evento != "TODOS")
                {
                    query +=
                        " AND Evento = @evento";
                }

                query +=
                    " ORDER BY Fecha DESC";

                SqlCommand cmd =
                    new SqlCommand(
                        query,
                        cn.AbrirConexion());

                cmd.Parameters.AddWithValue(
                    "@texto",
                    "%" + texto + "%");

                if (evento != "TODOS")
                {
                    cmd.Parameters.AddWithValue(
                        "@evento",
                        evento);
                }

                SqlDataAdapter da =
                    new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvLogs.DataSource = dt;

                lblTotalLogs.Text =
                    "Total Logs: " + dt.Rows.Count;

                ColorearEventos();

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =====================================================
        // REFRESCAR
        // =====================================================

        private void BtnRefrescar_Click(
            object sender,
            EventArgs e)
        {
            txtBuscar.Clear();

            cboEvento.SelectedIndex = 0;

            MostrarLogs();
        }

        // =====================================================
        // LIMPIAR LOGS
        // =====================================================

        private void BtnLimpiar_Click(
            object sender,
            EventArgs e)
        {
            DialogResult resultado =
                MessageBox.Show(
                    "¿Desea eliminar todos los logs?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    SqlCommand cmd =
                        new SqlCommand(
                            "DELETE FROM LogsSistema",
                            cn.AbrirConexion());

                    cmd.ExecuteNonQuery();

                    cn.CerrarConexion();

                    MostrarLogs();

                    MessageBox.Show(
                        "Logs eliminados correctamente",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // =====================================================
        // COLORES EVENTOS
        // =====================================================

        private void ColorearEventos()
        {
            foreach (DataGridViewRow fila in dgvLogs.Rows)
            {
                if (fila.Cells["Evento"].Value == null)
                    continue;

                string evento =
                    fila.Cells["Evento"].Value.ToString();

                switch (evento)
                {
                    case "LOGIN":

                        fila.DefaultCellStyle.BackColor =
                            Color.FromArgb(232, 244, 252);

                        break;

                    case "BACKUP":

                        fila.DefaultCellStyle.BackColor =
                            Color.FromArgb(232, 250, 232);

                        break;

                    case "ERROR":

                        fila.DefaultCellStyle.BackColor =
                            Color.FromArgb(255, 228, 225);

                        break;

                    case "RESTORE":

                        fila.DefaultCellStyle.BackColor =
                            Color.FromArgb(255, 248, 220);

                        break;
                }
            }
        }
    }
}