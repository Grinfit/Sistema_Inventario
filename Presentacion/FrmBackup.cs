// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Sistema_Inventario.Datos;
using Sistema_Inventario.Logica;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO ENCARGADO DE LOS BACKUPS DEL SISTEMA
    public partial class FrmBackup : Form
    {
        // OBJETO DE CONEXION A SQL SERVER
        Conexion cn = new Conexion();

        // OBJETO PARA REGISTRO DE LOGS
        Logger log = new Logger();

        // SERVICIO PARA GENERAR HASH SHA256
        HashService hashService =
            new HashService();

        // SERVICIO PARA COMPRESION ZIP
        CompressionService compressionService =
            new CompressionService();

        // SERVICIO PARA ENCRIPTACION AES256
        EncryptionService encryptionService =
            new EncryptionService();

        // SERVICIO PARA BACKUP ESPEJO
        DisasterRecoveryService disasterService =
            new DisasterRecoveryService();

        // SERVICIO DE VALIDACIONES
        ValidationService validationService =
            new ValidationService();

        // SERVICIO PARA RESTAURAR BACKUPS
        RestoreService restoreService =
            new RestoreService();

        // SERVICIO DE CORREO ELECTRONICO
        EmailService emailService =
            new EmailService();

        // NOMBRE DE LA BASE DE DATOS
        string baseDatos =
            "Inventario";

        // USUARIO ACTUAL DEL SISTEMA
        string usuarioSistema =>
            SesionUsuario.Usuario;

        // RUTA DEL BACKUP ESPEJO
        string rutaEspejo =
            @"C:\Backups_Espejo";

        // CONSTRUCTOR DEL FORMULARIO
        public FrmBackup()
        {
            InitializeComponent();
        }

        // EVENTO LOAD DEL FORMULARIO
        private void FrmBackup_Load(
     object sender,
     EventArgs e)
        {
            // SELECCIONA EL PRIMER ITEM DEL COMBOBOX
            cbTipoBackup.SelectedIndex = 0;

            // MUESTRA EL HISTORIAL
            MostrarHistorial();

            // CONFIGURA EL DATAGRIDVIEW
            ConfigurarDataGrid();

            // CARGA EL ULTIMO BACKUP
            CargarUltimoBackup();
        }

        // METODO PARA CONFIGURAR EL DATAGRIDVIEW
        private void ConfigurarDataGrid()
        {
            try
            {
                // CONFIGURA EL BORDE
                dgvBackupHistorial.BorderStyle =
                    BorderStyle.None;

                // CONFIGURA EL COLOR DE FONDO
                dgvBackupHistorial.BackgroundColor =
                    Color.White;

                // AJUSTA LAS COLUMNAS
                dgvBackupHistorial.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                // OCULTA LOS HEADERS DE FILAS
                dgvBackupHistorial.RowHeadersVisible =
                    false;

                // DESHABILITA AGREGAR FILAS
                dgvBackupHistorial.AllowUserToAddRows =
                    false;

                // DESHABILITA REDIMENSIONAR FILAS
                dgvBackupHistorial.AllowUserToResizeRows =
                    false;

                // SELECCION COMPLETA DE FILAS
                dgvBackupHistorial.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                // DESHABILITA MULTISELECT
                dgvBackupHistorial.MultiSelect =
                    false;

                // SOLO LECTURA
                dgvBackupHistorial.ReadOnly =
                    true;

                // DESHABILITA ESTILOS VISUALES
                dgvBackupHistorial.EnableHeadersVisualStyles =
                    false;

                // COLOR DE HEADER
                dgvBackupHistorial.ColumnHeadersDefaultCellStyle.BackColor =
                    Color.FromArgb(15, 35, 65);

                // COLOR TEXTO HEADER
                dgvBackupHistorial.ColumnHeadersDefaultCellStyle.ForeColor =
                    Color.White;

                // FUENTE HEADER
                dgvBackupHistorial.ColumnHeadersDefaultCellStyle.Font =
                    new Font(
                        "Segoe UI",
                        10,
                        FontStyle.Bold);

                // ALTURA HEADER
                dgvBackupHistorial.ColumnHeadersHeight =
                    40;

                // FUENTE CELDAS
                dgvBackupHistorial.DefaultCellStyle.Font =
                    new Font(
                        "Segoe UI",
                        9);

                // ALTURA FILAS
                dgvBackupHistorial.RowTemplate.Height =
                    35;

                // COLOR ALTERNADO
                dgvBackupHistorial.AlternatingRowsDefaultCellStyle.BackColor =
                    Color.FromArgb(240, 240, 240);

                // VALIDA SI EXISTEN COLUMNAS
                if (dgvBackupHistorial.Columns.Count > 0)
                {
                    // OCULTA ID BACKUP
                    if (dgvBackupHistorial.Columns.Contains("IdBackup"))
                    {
                        dgvBackupHistorial.Columns["IdBackup"].Visible =
                            false;
                    }

                    // OCULTA RUTA ARCHIVO
                    if (dgvBackupHistorial.Columns.Contains("RutaArchivo"))
                    {
                        dgvBackupHistorial.Columns["RutaArchivo"].Visible =
                            false;
                    }

                    // CAMBIA TITULO FECHA
                    if (dgvBackupHistorial.Columns.Contains("FechaBackup"))
                    {
                        dgvBackupHistorial.Columns["FechaBackup"].HeaderText =
                            "Fecha Backup";
                    }

                    // CAMBIA TITULO TIPO
                    if (dgvBackupHistorial.Columns.Contains("TipoBackup"))
                    {
                        dgvBackupHistorial.Columns["TipoBackup"].HeaderText =
                            "Tipo Backup";
                    }

                    // CAMBIA TITULO USUARIO
                    if (dgvBackupHistorial.Columns.Contains("UsuarioSistema"))
                    {
                        dgvBackupHistorial.Columns["UsuarioSistema"].HeaderText =
                            "Usuario";
                    }

                    // CAMBIA TITULO ESTADO
                    if (dgvBackupHistorial.Columns.Contains("EstadoBackup"))
                    {
                        dgvBackupHistorial.Columns["EstadoBackup"].HeaderText =
                            "Estado";
                    }

                    // CAMBIA TITULO TAMAÑO
                    if (dgvBackupHistorial.Columns.Contains("TamanoMB"))
                    {
                        dgvBackupHistorial.Columns["TamanoMB"].HeaderText =
                            "Tamaño MB";
                    }

                    // CAMBIA TITULO ENCRIPTADO
                    if (dgvBackupHistorial.Columns.Contains("Encriptado"))
                    {
                        dgvBackupHistorial.Columns["Encriptado"].HeaderText =
                            "AES256";
                    }

                    // CAMBIA TITULO VERIFICADO
                    if (dgvBackupHistorial.Columns.Contains("Verificado"))
                    {
                        dgvBackupHistorial.Columns["Verificado"].HeaderText =
                            "Verificado";
                    }

                    // CAMBIA TITULO OBSERVACIONES
                    if (dgvBackupHistorial.Columns.Contains("Observaciones"))
                    {
                        dgvBackupHistorial.Columns["Observaciones"].HeaderText =
                            "Observaciones";
                    }
                }
            }
            catch (Exception ex)
            {
                // MUESTRA ERROR
                MessageBox.Show(
                    ex.Message,
                    "Error Grid",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // METODO PARA MOSTRAR EL HISTORIAL
        private void MostrarHistorial()
        {
            try
            {
                // ADAPTADOR PARA EL STORED PROCEDURE
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        "sp_MostrarBackupHistorial",
                        cn.AbrirConexion());

                // DEFINE EL TIPO DE COMANDO
                da.SelectCommand.CommandType =
                    CommandType.StoredProcedure;

                // TABLA TEMPORAL
                DataTable dt =
                    new DataTable();

                // LLENA LA TABLA
                da.Fill(dt);

                // LIMPIA EL DATAGRID
                dgvBackupHistorial.DataSource = null;

                // ASIGNA DATOS AL DATAGRID
                dgvBackupHistorial.DataSource = dt;

                // CIERRA LA CONEXION
                cn.CerrarConexion();

                // REFRESCA EL DATAGRID
                dgvBackupHistorial.Refresh();
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

        // METODO PARA CARGAR EL ULTIMO BACKUP
        private void CargarUltimoBackup()
        {
            try
            {
                // CONSULTA SQL
                SqlCommand cmd =
                    new SqlCommand(
                        @"SELECT TOP 1 FechaBackup
                          FROM BackupHistorial
                          ORDER BY IdBackup DESC",
                        cn.AbrirConexion());

                // OBTIENE EL RESULTADO
                object resultado =
                    cmd.ExecuteScalar();

                // VALIDA SI EXISTE RESULTADO
                if (resultado != null)
                {
                    // MUESTRA LA FECHA
                    txtUltimoBackup.Text =
                        Convert.ToDateTime(resultado)
                        .ToString("dd/MM/yyyy HH:mm:ss");
                }

                // CIERRA LA CONEXION
                cn.CerrarConexion();
            }
            catch
            {

            }
        }

        // EVENTO PARA SELECCIONAR RUTA
        private void btnRuta_Click(
            object sender,
            EventArgs e)
        {
            // CREA EL DIALOGO
            FolderBrowserDialog folder =
                new FolderBrowserDialog();

            // VALIDA SI EL USUARIO SELECCIONO UNA CARPETA
            if (folder.ShowDialog() ==
                DialogResult.OK)
            {
                // ASIGNA LA RUTA
                txtRuta.Text =
                    folder.SelectedPath;
            }
        }

        // EVENTO PARA GENERAR BACKUP
        private void btnBackup_Click(
            object sender,
            EventArgs e)
        {
            // CODIGO DE BACKUP
        }

        // METODO PARA VERIFICAR BACKUP
        private void VerificarBackup(
            string ruta)
        {
            // CODIGO VERIFYONLY
        }

        // METODO PARA GUARDAR HISTORIAL
        private void GuardarHistorial(
            string tipo,
            string ruta,
            string estado,
            decimal tamano,
            string hash)
        {
            // CODIGO HISTORIAL
        }

        // EVENTO PARA RESTAURAR BACKUP
        private void btnRestore_Click(
            object sender,
            EventArgs e)
        {
            // CODIGO RESTORE
        }

        // EVENTO PAINT DEL PANEL
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // LIMPIA LOS CONTROLES
            panel1.Controls.Clear();

            // LABEL ESPACIO DISPONIBLE
            Label lblEspacioDisponible =
                new Label();

            lblEspacioDisponible.Text =
                "Disponible: 0 GB";

            lblEspacioDisponible.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold);

            lblEspacioDisponible.ForeColor =
                Color.Green;

            lblEspacioDisponible.AutoSize =
                true;

            lblEspacioDisponible.Location =
                new Point(15, 10);

            panel1.Controls.Add(
                lblEspacioDisponible);

            // LABEL ESPACIO USADO
            Label lblEspacioUsado =
                new Label();

            lblEspacioUsado.Text =
                "Usado: 0 GB";

            lblEspacioUsado.Font =
                new Font(
                    "Segoe UI",
                    9);

            lblEspacioUsado.ForeColor =
                Color.Gray;

            lblEspacioUsado.AutoSize =
                true;

            lblEspacioUsado.Location =
                new Point(15, 40);

            panel1.Controls.Add(
                lblEspacioUsado);

            // LABEL TOTAL BACKUPS
            Label lblBackups =
                new Label();

            try
            {
                // NUEVA CONEXION
                Conexion cn =
                    new Conexion();

                // CONSULTA SQL
                SqlCommand cmd =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM BackupHistorial",
                        cn.AbrirConexion());

                // TOTAL DE BACKUPS
                int total =
                    Convert.ToInt32(
                        cmd.ExecuteScalar());

                // MUESTRA TOTAL
                lblBackups.Text =
                    $"Backups: {total}";

                // CIERRA CONEXION
                cn.CerrarConexion();
            }
            catch
            {
                // MENSAJE POR DEFECTO
                lblBackups.Text =
                    "Backups: 0";
            }

            lblBackups.Font =
                new Font(
                    "Segoe UI",
                    9);

            lblBackups.AutoSize =
                true;

            lblBackups.Location =
                new Point(180, 40);

            panel1.Controls.Add(
                lblBackups);

            // LABEL ESTADO
            Label lblEstado =
                new Label();

            lblEstado.Text =
                "ACTIVO";

            lblEstado.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold);

            lblEstado.ForeColor =
                Color.Green;

            lblEstado.AutoSize =
                true;

            lblEstado.Location =
                new Point(300, 10);

            panel1.Controls.Add(
                lblEstado);

            // PROGRESSBAR DEL DISCO
            ProgressBar progressDisco =
                new ProgressBar();

            progressDisco.Size =
                new Size(110, 12);

            progressDisco.Location =
                new Point(300, 45);

            progressDisco.Maximum = 100;

            panel1.Controls.Add(
                progressDisco);

            // OBTIENE EL DISCO C
            DriveInfo drive =
                DriveInfo.GetDrives()
                .FirstOrDefault(
                    d => d.IsReady &&
                    d.Name == @"C:\");

            // VALIDA SI EL DISCO EXISTE
            if (drive != null)
            {
                // TOTAL EN GB
                double totalGB =
                    drive.TotalSize /
                    1024.0 / 1024.0 / 1024.0;

                // ESPACIO LIBRE
                double libreGB =
                    drive.AvailableFreeSpace /
                    1024.0 / 1024.0 / 1024.0;

                // ESPACIO USADO
                double usadoGB =
                    totalGB - libreGB;

                // PORCENTAJE USADO
                int porcentaje =
                    Convert.ToInt32(
                        (usadoGB / totalGB) * 100);

                // MUESTRA ESPACIO DISPONIBLE
                lblEspacioDisponible.Text =
                    $"Disponible: {libreGB:N2} GB";

                // MUESTRA ESPACIO USADO
                lblEspacioUsado.Text =
                    $"Usado: {usadoGB:N2} GB";

                // ASIGNA EL PORCENTAJE
                progressDisco.Value =
                    porcentaje;
            }
        }
    }
}