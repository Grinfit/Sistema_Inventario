using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.IO;


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

            btnExportar.Click += BtnExportar_Click;
        }

        // =====================================================
        // MOSTRAR LOGS
        // =====================================================

        private void MostrarLogs()
        {
            try
            {
                string query =
    @"SELECT 
        IdLog AS ID,
        Evento AS TipoEvento,
        Fecha AS Fecha,
        Usuario AS Usuario,
        Descripcion AS Descripcion
    FROM LogsSistema
    ORDER BY Fecha DESC";

                SqlDataAdapter da =
                    new SqlDataAdapter(
                        query,
                        cn.AbrirConexion());

                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvLogs.DataSource = dt;
                dgvLogs.Columns["TipoEvento"].HeaderText = "Tipo Evento";
                dgvLogs.Columns["Descripcion"].HeaderText = "Descripción";

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
                    @"SELECT 
                IdLog AS ID,
                Evento AS TipoEvento,
                Fecha,
                Usuario,
                Descripcion
              FROM LogsSistema
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

                // TITULOS VISUALES
                dgvLogs.Columns["TipoEvento"].HeaderText =
                    "Tipo Evento";

                dgvLogs.Columns["Descripcion"].HeaderText =
                    "Descripción";

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

        private void BtnExportar_Click(
    object sender,
    EventArgs e)
        {
            try
            {
                if (dgvLogs.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No hay logs para exportar",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                SaveFileDialog save =
                    new SaveFileDialog();

                save.Filter =
                    "Archivo CSV (*.csv)|*.csv";

                save.Title =
                    "Exportar Logs";

                save.FileName =
                    "LogsSistema_" +
                    DateTime.Now.ToString("yyyyMMdd_HHmmss") +
                    ".csv";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw =
                        new StreamWriter(save.FileName))
                    {
                        // ENCABEZADOS
                        for (int i = 0;
                            i < dgvLogs.Columns.Count;
                            i++)
                        {
                            sw.Write(
                                dgvLogs.Columns[i].HeaderText);

                            if (i <
                                dgvLogs.Columns.Count - 1)
                            {
                                sw.Write(",");
                            }
                        }

                        sw.WriteLine();

                        // FILAS
                        foreach (DataGridViewRow row
                            in dgvLogs.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                for (int i = 0;
                                    i < dgvLogs.Columns.Count;
                                    i++)
                                {
                                    sw.Write(
                                        row.Cells[i].Value?.ToString());

                                    if (i <
                                        dgvLogs.Columns.Count - 1)
                                    {
                                        sw.Write(",");
                                    }
                                }

                                sw.WriteLine();
                            }
                        }
                    }

                    MessageBox.Show(
                        "Logs exportados correctamente",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
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
        // COLORES EVENTOS
        // =====================================================

        private void ColorearEventos()
        {
            foreach (DataGridViewRow fila in dgvLogs.Rows)
            {
                if (fila.Cells["TipoEvento"].Value == null)
                    continue;

                string evento =
                    fila.Cells["TipoEvento"].Value.ToString();

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