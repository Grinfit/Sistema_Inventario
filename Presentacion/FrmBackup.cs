using FontAwesome.Sharp;
using Sistema_Inventario.Datos;
using Sistema_Inventario.Logica;
using Sistema_Inventario.Utilidades;

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sistema_Inventario.Presentacion
{
    public partial class FrmBackup : Form
    {
        Conexion cn = new Conexion();

        Logger log = new Logger();

        HashService hashService =
            new HashService();

        CompressionService compressionService =
            new CompressionService();

        EncryptionService encryptionService =
            new EncryptionService();

        DisasterRecoveryService disasterService =
            new DisasterRecoveryService();

        ValidationService validationService =
            new ValidationService();

        RestoreService restoreService =
            new RestoreService();

        EmailService emailService =
            new EmailService();

        string baseDatos =
            "Inventario";

        string usuarioSistema =
            "Administrador";

        string rutaEspejo =
            @"C:\Backups_Espejo";

        public FrmBackup()
        {
            InitializeComponent();
        }

        // =====================================================
        // LOAD
        // =====================================================

        private void FrmBackup_Load(
            object sender,
            EventArgs e)
        {
            cbTipoBackup.SelectedIndex = 0;

            MostrarHistorial();

            CargarUltimoBackup();

            ConfigurarDataGrid();
        }

        // =====================================================
        // DATAGRID
        // =====================================================

        private void ConfigurarDataGrid()
        {
            dgvBackupHistorial.BorderStyle =
                BorderStyle.None;

            dgvBackupHistorial.BackgroundColor =
                Color.White;

            dgvBackupHistorial.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvBackupHistorial.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.AllCells;

            dgvBackupHistorial.RowHeadersVisible =
                false;

            dgvBackupHistorial.AllowUserToAddRows =
                false;

            dgvBackupHistorial.AllowUserToResizeRows =
                false;

            dgvBackupHistorial.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvBackupHistorial.MultiSelect =
                false;

            dgvBackupHistorial.ReadOnly =
                true;

            dgvBackupHistorial.EnableHeadersVisualStyles =
                false;

            dgvBackupHistorial.ScrollBars =
                ScrollBars.Vertical;

            // ============================================
            // HEADER
            // ============================================

            dgvBackupHistorial.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(15, 35, 65);

            dgvBackupHistorial.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvBackupHistorial.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold);

            dgvBackupHistorial.ColumnHeadersHeight =
                40;

            // ============================================
            // FILAS
            // ============================================

            dgvBackupHistorial.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9);

            dgvBackupHistorial.RowTemplate.Height =
                35;

            dgvBackupHistorial.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(240, 240, 240);

            // ============================================
            // AJUSTE COLUMNAS
            // ============================================

            dgvBackupHistorial.Columns["FechaBackup"].FillWeight =
                18;

            dgvBackupHistorial.Columns["TipoBackup"].FillWeight =
                14;

            dgvBackupHistorial.Columns["UsuarioSistema"].FillWeight =
                16;

            dgvBackupHistorial.Columns["RutaArchivo"].Visible =
                false;
                //28;

            dgvBackupHistorial.Columns["EstadoBackup"].FillWeight =
                14;

            dgvBackupHistorial.Columns["TamanoMB"].FillWeight =
                10;

            dgvBackupHistorial.Columns["Encriptado"].FillWeight =
                8;

            dgvBackupHistorial.Columns["Verificado"].FillWeight =
                8;

            dgvBackupHistorial.Columns["Observaciones"].FillWeight =
                20;
        }


        // =====================================================
        // HISTORIAL
        // =====================================================

        private void MostrarHistorial()
        {
            try
            {
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        "sp_MostrarBackupHistorial",
                        cn.AbrirConexion());

                da.SelectCommand.CommandType =
                    CommandType.StoredProcedure;

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                dgvBackupHistorial.DataSource = dt;

                if (dgvBackupHistorial.Columns.Count > 0)
                {
                    dgvBackupHistorial.Columns["IdBackup"].Visible = false;
                }

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
        // ULTIMO BACKUP
        // =====================================================

        private void CargarUltimoBackup()
        {
            try
            {
                SqlCommand cmd =
                    new SqlCommand(
                        @"SELECT TOP 1 FechaBackup
                          FROM BackupHistorial
                          ORDER BY IdBackup DESC",
                        cn.AbrirConexion());

                object resultado =
                    cmd.ExecuteScalar();

                if (resultado != null)
                {
                    txtUltimoBackup.Text =
                        Convert.ToDateTime(resultado)
                        .ToString("dd/MM/yyyy HH:mm:ss");
                }

                cn.CerrarConexion();
            }
            catch
            {

            }
        }

        // =====================================================
        // RUTA
        // =====================================================

        private void btnRuta_Click(
            object sender,
            EventArgs e)
        {
            FolderBrowserDialog folder =
                new FolderBrowserDialog();

            if (folder.ShowDialog() ==
                DialogResult.OK)
            {
                txtRuta.Text =
                    folder.SelectedPath;
            }
        }

        // =====================================================
        // GENERAR BACKUP
        // =====================================================

        private void btnBackup_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                lblEstado.Text =
                    "Estado: Generando Backup...";

                lblEstado.ForeColor =
                    Color.Orange;

                if (txtRuta.Text.Trim() == "")
                {
                    MessageBox.Show(
                        "Seleccione una ruta",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (!validationService.ExisteRuta(
                    txtRuta.Text))
                {
                    MessageBox.Show(
                        "La ruta no existe",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (!validationService
                    .TienePermisosEscritura(
                    txtRuta.Text))
                {
                    MessageBox.Show(
                        "La ruta no tiene permisos",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string aesPassword =
                    ConfigurationManager
                    .AppSettings["AESPassword"];

                string tipoBackup =
                    cbTipoBackup.Text;

                string fecha =
                    DateTime.Now.ToString(
                        "yyyyMMdd_HHmmss");

                string archivoBackup =
                    txtRuta.Text +
                    @"\" +
                    baseDatos +
                    "_" +
                    fecha +
                    ".bak";

                string query = "";

                // ============================================
                // FULL
                // ============================================

                if (tipoBackup ==
                    "FULL BACKUP")
                {
                    query =
                        $@"BACKUP DATABASE [{baseDatos}]
                           TO DISK='{archivoBackup}'
                           WITH CHECKSUM, INIT";
                }

                // ============================================
                // DIFFERENTIAL
                // ============================================

                else if (tipoBackup ==
                    "DIFFERENTIAL BACKUP")
                {
                    query =
                        $@"BACKUP DATABASE [{baseDatos}]
                           TO DISK='{archivoBackup}'
                           WITH DIFFERENTIAL,
                           CHECKSUM,
                           INIT";
                }

                // ============================================
                // LOG
                // ============================================

                else
                {
                    query =
                        $@"BACKUP LOG [{baseDatos}]
                           TO DISK='{archivoBackup}'
                           WITH CHECKSUM,
                           INIT";
                }

                SqlCommand cmd =
                    new SqlCommand(
                        query,
                        cn.AbrirConexion());

                cmd.CommandTimeout = 0;

                cmd.ExecuteNonQuery();

                cn.CerrarConexion();

                // ============================================
                // ZIP
                // ============================================

                string zipFile =
                    compressionService
                    .ComprimirBackup(
                        archivoBackup);

                // ============================================
                // AES256
                // ============================================

                string archivoFinal =
                    zipFile;

                if (chkEncriptar.Checked)
                {
                    archivoFinal =
                        encryptionService
                        .EncryptFile(
                            zipFile,
                            aesPassword);

                    if (File.Exists(zipFile))
                    {
                        File.Delete(zipFile);
                    }
                }

                // ============================================
                // ELIMINAR BAK
                // ============================================

                if (File.Exists(archivoBackup))
                {
                    File.Delete(archivoBackup);
                }

                // ============================================
                // HASH
                // ============================================

                string hash =
                    hashService
                    .GenerarSHA256(
                        archivoFinal);

                // ============================================
                // BACKUP ESPEJO
                // ============================================

                if (chkEspejo.Checked)
                {
                    disasterService
                        .CopiarBackupEspejo(
                            archivoFinal,
                            rutaEspejo);
                }

                // ============================================
                // TAMAÑO
                // ============================================

                FileInfo fi =
                    new FileInfo(
                        archivoFinal);

                decimal tamanoMB =
                    Convert.ToDecimal(
                        fi.Length / 1024.0 / 1024.0);

                // ============================================
                // VERIFY
                // ============================================

                if (chkVerificar.Checked)
                {
                    VerificarBackup(
                        archivoBackup);
                }

                // ============================================
                // HISTORIAL
                // ============================================

                GuardarHistorial(
                    tipoBackup,
                    archivoFinal,
                    "EXITOSO",
                    tamanoMB,
                    hash);

                log.RegistrarLog(
                    "BACKUP",
                    usuarioSistema,
                    "Backup generado correctamente");

                lblEstado.Text =
                    "Estado: Backup Exitoso";

                lblEstado.ForeColor =
                    Color.Green;

                // ============================================
                // EMAIL EXITO
                // ============================================

                if (chkCorreo.Checked)
                {
                    emailService.EnviarAlerta(
                        "[BACKUP EXITOSO] Sistema Inventario",
                        $@"
Se realizó correctamente un backup.

Servidor: HENRYOCHOA\SQLEXPRESS

Base de Datos: Inventario

Tipo Backup:
{tipoBackup}

Fecha:
{DateTime.Now}

Usuario:
{usuarioSistema}

Ruta:
{archivoFinal}

Hash SHA256:
{hash}

Estado:
EXITOSO");
                }

                MessageBox.Show(
                    "Backup generado correctamente",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                MostrarHistorial();

                CargarUltimoBackup();
            }
            catch (Exception ex)
            {
                lblEstado.Text =
                    "Estado: Error Backup";

                lblEstado.ForeColor =
                    Color.Red;

                MessageBox.Show(
                    ex.Message,
                    "Error Backup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                log.RegistrarLog(
                    "ERROR BACKUP",
                    usuarioSistema,
                    ex.ToString());

                // ============================================
                // EMAIL ERROR
                // ============================================

                if (chkCorreo.Checked)
                {
                    try
                    {
                        emailService.EnviarAlerta(
                            "[ERROR BACKUP] Sistema Inventario",
                            ex.ToString());
                    }
                    catch
                    {

                    }
                }
            }
        }

        // =====================================================
        // VERIFY
        // =====================================================

        private void VerificarBackup(
            string ruta)
        {
            try
            {
                SqlCommand cmd =
                    new SqlCommand(
                        $@"RESTORE VERIFYONLY
                           FROM DISK='{ruta}'",
                        cn.AbrirConexion());

                cmd.ExecuteNonQuery();

                cn.CerrarConexion();
            }
            catch
            {

            }
        }

        // =====================================================
        // HISTORIAL
        // =====================================================

        private void GuardarHistorial(
            string tipo,
            string ruta,
            string estado,
            decimal tamano,
            string hash)
        {
            try
            {
                SqlCommand cmd =
                    new SqlCommand(
                        "sp_InsertarBackupHistorial",
                        cn.AbrirConexion());

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@TipoBackup",
                    tipo);

                cmd.Parameters.AddWithValue(
                    "@UsuarioSistema",
                    usuarioSistema);

                cmd.Parameters.AddWithValue(
                    "@RutaArchivo",
                    ruta);

                cmd.Parameters.AddWithValue(
                    "@EstadoBackup",
                    estado);

                cmd.Parameters.AddWithValue(
                    "@TamanoMB",
                    tamano);

                cmd.Parameters.AddWithValue(
                    "@HashBackup",
                    hash);

                cmd.Parameters.AddWithValue(
                    "@Encriptado",
                    chkEncriptar.Checked);

                cmd.Parameters.AddWithValue(
                    "@Verificado",
                    chkVerificar.Checked);

                cmd.Parameters.AddWithValue(
                    "@Observaciones",
                    "Backup generado correctamente");

                cmd.ExecuteNonQuery();

                cn.CerrarConexion();
            }
            catch
            {

            }
        }

        // =====================================================
        // RESTORE
        // =====================================================

        private void btnRestore_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                OpenFileDialog open =
                    new OpenFileDialog();

                open.Filter =
                    "Encrypted Backup|*.enc";

                if (open.ShowDialog() ==
                    DialogResult.OK)
                {
                    lblEstado.Text =
                        "Estado: Restaurando...";

                    lblEstado.ForeColor =
                        Color.Orange;

                    string aesPassword =
                        ConfigurationManager
                        .AppSettings["AESPassword"];

                    restoreService.RestaurarBackup(
                        @".\SQLEXPRESS",
                        "Inventario",
                        open.FileName,
                        aesPassword);

                    lblEstado.Text =
                        "Estado: Restaurado";

                    lblEstado.ForeColor =
                        Color.Green;

                    // ============================================
                    // EMAIL RESTORE EXITOSO
                    // ============================================

                    if (chkCorreo.Checked)
                    {
                        emailService.EnviarAlerta(
                            "[RESTORE EXITOSO] Sistema Inventario",
                            $@"
Restore realizado correctamente.

Base Datos:
Inventario

Archivo:
{open.FileName}

Fecha:
{DateTime.Now}

Estado:
EXITOSO");
                    }

                    MessageBox.Show(
                        "Backup restaurado correctamente",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                lblEstado.Text =
                    "Estado: Error Restore";

                lblEstado.ForeColor =
                    Color.Red;

                MessageBox.Show(
                    ex.Message,
                    "Error Restore",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                log.RegistrarLog(
                    "ERROR RESTORE",
                    usuarioSistema,
                    ex.ToString());

                // ============================================
                // EMAIL ERROR RESTORE
                // ============================================

                if (chkCorreo.Checked)
                {
                    try
                    {
                        emailService.EnviarAlerta(
                            "[ERROR RESTORE] Sistema Inventario",
                            ex.ToString());
                    }
                    catch
                    {

                    }
                }
            }
        }
    }
}