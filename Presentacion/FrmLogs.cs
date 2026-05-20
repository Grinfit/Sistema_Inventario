// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

// IMPORTACION DE LA CAPA DE DATOS
using Sistema_Inventario.Datos;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO DE LOGS DEL SISTEMA
    public partial class FrmLogs : Form
    {
        // OBJETO DE CONEXION
        Conexion cn = new Conexion();

        // CONSTRUCTOR DEL FORMULARIO
        public FrmLogs()
        {
            InitializeComponent();

            // CONFIGURA LOS EVENTOS
            ConfigurarEventos();
        }

        // LOAD

        private void FrmLogs_Load(
            object sender,
            EventArgs e)
        {
            // CARGA LOS EVENTOS EN EL COMBOBOX
            CargarEventos();

            // MUESTRA LOS LOGS
            MostrarLogs();
        }

        // CARGAR EVENTOS COMBOBOX

        private void CargarEventos()
        {
            // LIMPIA EL COMBOBOX
            cboEvento.Items.Clear();

            // AGREGA EVENTO TODOS
            cboEvento.Items.Add("TODOS");

            // EVENTOS LOGIN
            cboEvento.Items.Add("LOGIN");
            cboEvento.Items.Add("LOGOUT");

            // EVENTOS BACKUP
            cboEvento.Items.Add("BACKUP");
            cboEvento.Items.Add("RESTORE");

            // EVENTOS PRODUCTOS
            cboEvento.Items.Add("PRODUCTO_CREATE");
            cboEvento.Items.Add("PRODUCTO_UPDATE");
            cboEvento.Items.Add("PRODUCTO_DELETE");

            // EVENTOS CLIENTES
            cboEvento.Items.Add("CLIENTE_CREATE");
            cboEvento.Items.Add("CLIENTE_UPDATE");
            cboEvento.Items.Add("CLIENTE_DELETE");

            // EVENTOS VENTAS
            cboEvento.Items.Add("VENTA_CREATE");

            // EVENTOS INVENTARIO
            cboEvento.Items.Add("INVENTARIO_ENTRADA");
            cboEvento.Items.Add("INVENTARIO_SALIDA");

            // EVENTOS ERRORES
            cboEvento.Items.Add("ERROR_LOGIN");
            cboEvento.Items.Add("ERROR_INVENTARIO");

            // SELECCIONA EL PRIMER ITEM
            cboEvento.SelectedIndex = 0;
        }

        // CONFIGURAR EVENTOS

        private void ConfigurarEventos()
        {
            // EVENTO BOTON BUSCAR
            btnBuscar.Click += BtnBuscar_Click;

            // EVENTO BOTON REFRESCAR
            btnRefrescar.Click += BtnRefrescar_Click;

            // EVENTO BOTON LIMPIAR
            btnLimpiar.Click += BtnLimpiar_Click;

            // EVENTO BOTON EXPORTAR
            btnExportar.Click += BtnExportar_Click;
        }

        // MOSTRAR LOGS

        private void MostrarLogs()
        {
            try
            {
                // QUERY DE CONSULTA
                string query =
    @"SELECT 
        IdLog AS ID,
        Evento AS TipoEvento,
        Fecha AS Fecha,
        Usuario AS Usuario,
        Descripcion AS Descripcion
    FROM LogsSistema
    ORDER BY Fecha DESC";

                // ADAPTADOR DE DATOS
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        query,
                        cn.AbrirConexion());

                // TABLA TEMPORAL
                DataTable dt = new DataTable();

                // LLENA LA TABLA
                da.Fill(dt);

                // MUESTRA LOS DATOS EN EL GRID
                dgvLogs.DataSource = dt;

                // CAMBIA TITULOS DE COLUMNAS
                dgvLogs.Columns["TipoEvento"].HeaderText = "Tipo Evento";

                dgvLogs.Columns["Descripcion"].HeaderText = "Descripción";

                // MUESTRA TOTAL DE LOGS
                lblTotalLogs.Text =
                    "Total Logs: " + dt.Rows.Count;

                // APLICA COLORES A EVENTOS
                ColorearEventos();

                // CIERRA LA CONEXION
                cn.CerrarConexion();
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

        // BUSCAR

        private void BtnBuscar_Click(
    object sender,
    EventArgs e)
        {
            try
            {
                // OBTIENE EL TEXTO DE BUSQUEDA
                string texto =
                    txtBuscar.Text.Trim();

                // OBTIENE EL EVENTO SELECCIONADO
                string evento =
                    cboEvento.Text;

                // QUERY BASE
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

                // FILTRA POR EVENTO
                if (evento != "TODOS")
                {
                    query +=
                        " AND Evento = @evento";
                }

                // ORDENA LOS DATOS
                query +=
                    " ORDER BY Fecha DESC";

                // CREA EL COMANDO
                SqlCommand cmd =
                    new SqlCommand(
                        query,
                        cn.AbrirConexion());

                // PARAMETRO DE TEXTO
                cmd.Parameters.AddWithValue(
                    "@texto",
                    "%" + texto + "%");

                // PARAMETRO EVENTO
                if (evento != "TODOS")
                {
                    cmd.Parameters.AddWithValue(
                        "@evento",
                        evento);
                }

                // ADAPTADOR DE DATOS
                SqlDataAdapter da =
                    new SqlDataAdapter(cmd);

                // TABLA TEMPORAL
                DataTable dt = new DataTable();

                // LLENA LA TABLA
                da.Fill(dt);

                // MUESTRA LOS DATOS
                dgvLogs.DataSource = dt;

                // CAMBIA TITULOS VISUALES
                dgvLogs.Columns["TipoEvento"].HeaderText =
                    "Tipo Evento";

                dgvLogs.Columns["Descripcion"].HeaderText =
                    "Descripción";

                // MUESTRA TOTAL DE LOGS
                lblTotalLogs.Text =
                    "Total Logs: " + dt.Rows.Count;

                // APLICA COLORES
                ColorearEventos();

                // CIERRA LA CONEXION
                cn.CerrarConexion();
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

        // REFRESCAR

        private void BtnRefrescar_Click(
            object sender,
            EventArgs e)
        {
            // LIMPIA EL TEXTO DE BUSQUEDA
            txtBuscar.Clear();

            // RESETEA EL COMBOBOX
            cboEvento.SelectedIndex = 0;

            // MUESTRA TODOS LOS LOGS
            MostrarLogs();
        }

        // LIMPIAR LOGS

        private void BtnLimpiar_Click(
            object sender,
            EventArgs e)
        {
            // MENSAJE DE CONFIRMACION
            DialogResult resultado =
                MessageBox.Show(
                    "¿Desea eliminar todos los logs?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            // VALIDA SI EL USUARIO CONFIRMO
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    // COMANDO DELETE
                    SqlCommand cmd =
                        new SqlCommand(
                            "DELETE FROM LogsSistema",
                            cn.AbrirConexion());

                    // EJECUTA EL COMANDO
                    cmd.ExecuteNonQuery();

                    // CIERRA LA CONEXION
                    cn.CerrarConexion();

                    // ACTUALIZA EL GRID
                    MostrarLogs();

                    // MENSAJE DE CONFIRMACION
                    MessageBox.Show(
                        "Logs eliminados correctamente",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // MUESTRA ERROR
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // EXPORTAR LOGS

        private void BtnExportar_Click(
    object sender,
    EventArgs e)
        {
            try
            {
                // VALIDA SI EXISTEN DATOS
                if (dgvLogs.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No hay logs para exportar",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // VENTANA PARA GUARDAR
                SaveFileDialog save =
                    new SaveFileDialog();

                // FILTRO DEL ARCHIVO
                save.Filter =
                    "Archivo CSV (*.csv)|*.csv";

                // TITULO DE LA VENTANA
                save.Title =
                    "Exportar Logs";

                // NOMBRE DEL ARCHIVO
                save.FileName =
                    "LogsSistema_" +
                    DateTime.Now.ToString("yyyyMMdd_HHmmss") +
                    ".csv";

                // VALIDA SI EL USUARIO GUARDO
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

                    // MENSAJE DE CONFIRMACION
                    MessageBox.Show(
                        "Logs exportados correctamente",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
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

        // COLORES EVENTOS

        private void ColorearEventos()
        {
            // RECORRE LAS FILAS DEL GRID
            foreach (DataGridViewRow fila in dgvLogs.Rows)
            {
                // VALIDA CELDA VACIA
                if (fila.Cells["TipoEvento"].Value == null)
                    continue;

                // OBTIENE EL EVENTO
                string evento =
                    fila.Cells["TipoEvento"]
                    .Value
                    .ToString();

                // LOGIN

                if (evento.Contains("LOGIN"))
                {
                    fila.DefaultCellStyle.BackColor =
                        Color.FromArgb(232, 244, 252);
                }

                // LOGOUT

                else if (evento.Contains("LOGOUT"))
                {
                    fila.DefaultCellStyle.BackColor =
                        Color.FromArgb(240, 240, 240);
                }

                // BACKUP

                else if (evento.Contains("BACKUP"))
                {
                    fila.DefaultCellStyle.BackColor =
                        Color.FromArgb(232, 250, 232);
                }

                // RESTORE

                else if (evento.Contains("RESTORE"))
                {
                    fila.DefaultCellStyle.BackColor =
                        Color.FromArgb(255, 248, 220);
                }

                // PRODUCTOS

                else if (evento.Contains("PRODUCTO"))
                {
                    fila.DefaultCellStyle.BackColor =
                        Color.FromArgb(230, 255, 230);
                }

                // CLIENTES

                else if (evento.Contains("CLIENTE"))
                {
                    fila.DefaultCellStyle.BackColor =
                        Color.FromArgb(255, 250, 230);
                }

                // INVENTARIO

                else if (evento.Contains("INVENTARIO"))
                {
                    fila.DefaultCellStyle.BackColor =
                        Color.FromArgb(230, 240, 255);
                }

                // VENTAS

                else if (evento.Contains("VENTA"))
                {
                    fila.DefaultCellStyle.BackColor =
                        Color.FromArgb(245, 230, 255);
                }

                // ERRORES

                else if (evento.Contains("ERROR"))
                {
                    fila.DefaultCellStyle.BackColor =
                        Color.FromArgb(255, 228, 225);

                    fila.DefaultCellStyle.ForeColor =
                        Color.DarkRed;
                }
            }
        }
    }
}