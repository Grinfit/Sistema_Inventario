using FontAwesome.Sharp;
using Sistema_Inventario.Datos;
using Sistema_Inventario.Utilidades;

using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Sistema_Inventario.Presentacion
{
    public partial class FrmBackup : Form
    {
        Conexion cn = new Conexion();

        Logger log = new Logger();

        string servidor =
            @"HENRYOCHOA\SQLEXPRESS";

        string baseDatos =
            "Inventario";

        string usuarioSistema =
            "Administrador";

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

            // ============================================
            // EFECTOS HOVER
            // ============================================

            btnRuta.FlatAppearance.MouseOverBackColor =
                ControlPaint.Light(btnRuta.BackColor);

            btnBackup.FlatAppearance.MouseOverBackColor =
                ControlPaint.Light(btnBackup.BackColor);

            btnRestore.FlatAppearance.MouseOverBackColor =
                ControlPaint.Light(btnRestore.BackColor);

            btnVerificar.FlatAppearance.MouseOverBackColor =
                ControlPaint.Light(btnVerificar.BackColor);

            btnExportar.FlatAppearance.MouseOverBackColor =
                ControlPaint.Light(btnExportar.BackColor);
        }

        // =====================================================
        // MOSTRAR HISTORIAL
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

                dgvBackupHistorial.ColumnHeadersDefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvBackupHistorial.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;

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
        // SELECCIONAR RUTA
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
                if (txtRuta.Text.Trim() == "")
                {
                    MessageBox.Show(
                        "Seleccione una ruta",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

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
                // FULL BACKUP
                // ============================================

                if (tipoBackup ==
                    "FULL BACKUP")
                {
                    query =
                        $@"BACKUP DATABASE [{baseDatos}]
                           TO DISK='{archivoBackup}'
                           WITH INIT";
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
                           WITH DIFFERENTIAL, INIT";
                }

                // ============================================
                // LOG
                // ============================================

                else
                {
                    query =
                        $@"BACKUP LOG [{baseDatos}]
                           TO DISK='{archivoBackup}'
                           WITH INIT";
                }

                SqlCommand cmd =
                    new SqlCommand(
                        query,
                        cn.AbrirConexion());

                cmd.CommandTimeout = 0;

                cmd.ExecuteNonQuery();

                cn.CerrarConexion();

                // ============================================
                // HASH SHA256
                // ============================================

                string hash =
                    GenerarSHA256(archivoBackup);

                // ============================================
                // TAMAÑO
                // ============================================

                FileInfo fi =
                    new FileInfo(
                        archivoBackup);

                decimal tamanoMB =
                    Convert.ToDecimal(
                        fi.Length / 1024.0 / 1024.0);

                // ============================================
                // GUARDAR HISTORIAL
                // ============================================

                GuardarHistorial(
                    tipoBackup,
                    archivoBackup,
                    "EXITOSO",
                    tamanoMB,
                    hash);

                // ============================================
                // VERIFICAR
                // ============================================

                if (chkVerificar.Checked)
                {
                    VerificarBackup(
                        archivoBackup);
                }

                // ============================================
                // EMAIL
                // ============================================

                if (chkCorreo.Checked)
                {
                    EnviarCorreoBackup(
                        tipoBackup,
                        archivoBackup);
                }

                log.RegistrarLog(
                    "BACKUP",
                    usuarioSistema,
                    "Backup realizado correctamente");

                MessageBox.Show(
                    "Backup realizado correctamente",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                MostrarHistorial();

                CargarUltimoBackup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error Backup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                log.RegistrarLog(
                    "ERROR BACKUP",
                    usuarioSistema,
                    ex.Message);
            }
        }

        // =====================================================
        // VERIFICAR BACKUP
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
        // SHA256
        // =====================================================

        private string GenerarSHA256(
            string archivo)
        {
            using (FileStream stream =
                File.OpenRead(archivo))
            {
                SHA256 sha =
                    SHA256.Create();

                byte[] hash =
                    sha.ComputeHash(stream);

                StringBuilder sb =
                    new StringBuilder();

                foreach (byte b in hash)
                {
                    sb.Append(
                        b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        // =====================================================
        // GUARDAR HISTORIAL
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
        // RESTAURAR
        // =====================================================

        private void btnRestore_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                string password =
                    Prompt.ShowDialog(
                        "wybgaejfjovdiuuf",
                        "Seguridad");

                if (password != "Admin123")
                {
                    MessageBox.Show(
                        "Contraseña incorrecta",
                        "Seguridad",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                OpenFileDialog open =
                    new OpenFileDialog();

                open.Filter =
                    "Backup Files|*.bak";

                if (open.ShowDialog() ==
                    DialogResult.OK)
                {
                    string ruta =
                        open.FileName;

                    SqlConnection conexion =
                        new SqlConnection(
                            $@"Server={servidor};
                               Database=master;
                               User Id=sa;
                               Password=Aswedfr36;
                               TrustServerCertificate=True;");

                    conexion.Open();

                    string query =
                        $@"
                        ALTER DATABASE [{baseDatos}]
                        SET SINGLE_USER
                        WITH ROLLBACK IMMEDIATE;

                        RESTORE DATABASE [{baseDatos}]
                        FROM DISK='{ruta}'
                        WITH REPLACE;

                        ALTER DATABASE [{baseDatos}]
                        SET MULTI_USER;";

                    SqlCommand cmd =
                        new SqlCommand(
                            query,
                            conexion);

                    cmd.CommandTimeout = 0;

                    cmd.ExecuteNonQuery();

                    conexion.Close();

                    MessageBox.Show(
                        "Base restaurada correctamente",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    log.RegistrarLog(
                        "RESTORE",
                        usuarioSistema,
                        "Base restaurada");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error Restore",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // CORREO
        // =====================================================

        private void EnviarCorreoBackup(
            string tipoBackup,
            string rutaArchivo)
        {
            try
            {
                string correo =
                    "henry0020503@gmail.com";

                string asunto =
                    "[BACKUP EXITOSO] Sistema Inventario";

                string mensaje =
                    "Se realizó correctamente un backup.\n\n" +
                    "Servidor: " + servidor + "\n" +
                    "Base de Datos: " + baseDatos + "\n" +
                    "Tipo Backup: " + tipoBackup + "\n" +
                    "Fecha: " + DateTime.Now + "\n" +
                    "Usuario: " + usuarioSistema + "\n" +
                    "Ruta: " + rutaArchivo + "\n\n" +
                    "Estado: EXITOSO";

                MailMessage mail =
                    new MailMessage();

                mail.From =
                    new MailAddress(
                        "henry0020503@gmail.com");

                mail.To.Add(correo);

                mail.Subject =
                    asunto;

                mail.Body =
                    mensaje;

                SmtpClient smtp =
                    new SmtpClient(
                        "smtp.gmail.com");

                smtp.Port = 587;

                smtp.Credentials =
                    new NetworkCredential(
                        "henry0020503@gmail.com",
                        "wybgaejfjovdiuuf");

                smtp.EnableSsl = true;

                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error Correo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
public static class Prompt
{
    public static string ShowDialog(
        string text,
        string caption)
    {
        Form prompt =
            new Form();

        prompt.Width = 400;
        prompt.Height = 200;

        prompt.Text = caption;

        prompt.StartPosition =
            FormStartPosition.CenterScreen;

        Label lblText =
            new Label()
            {
                Left = 30,
                Top = 20,
                Text = text,
                Width = 320
            };

        TextBox txtPassword =
            new TextBox()
            {
                Left = 30,
                Top = 60,
                Width = 320,
                PasswordChar = '*'
            };

        Button btnOk =
            new Button()
            {
                Text = "Aceptar",
                Left = 130,
                Width = 120,
                Top = 100,
                DialogResult = DialogResult.OK
            };

        prompt.Controls.Add(lblText);

        prompt.Controls.Add(txtPassword);

        prompt.Controls.Add(btnOk);

        prompt.AcceptButton = btnOk;

        return prompt.ShowDialog() ==
            DialogResult.OK
            ? txtPassword.Text
            : "";
    }
}