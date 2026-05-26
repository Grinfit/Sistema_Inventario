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
    public partial class FrmBackup : Form
    {
        // Instancia para manejo de conexión SQL
        Conexion cn = new Conexion();

        // Servicio de logs del sistema
        Logger log = new Logger();

        // Servicio para generación de hash SHA256
        HashService hashService =
            new HashService();

        // Servicio para compresión ZIP
        CompressionService compressionService =
            new CompressionService();

        // Servicio de cifrado AES256
        EncryptionService encryptionService =
            new EncryptionService();

        // Servicio de respaldo espejo
        DisasterRecoveryService disasterService =
            new DisasterRecoveryService();

        // Servicio de validaciones
        ValidationService validationService =
            new ValidationService();

        // Servicio de restauración
        RestoreService restoreService =
            new RestoreService();

        // Servicio de envío de correos
        EmailService emailService =
            new EmailService();

        // Nombre de la base de datos
        string baseDatos =
            "Inventario";

        // Usuario actual del sistema
        string usuarioSistema =>
            SesionUsuario.Usuario;

        // Ruta del backup espejo
        string rutaEspejo =
            @"C:\Backups_Espejo";

        // Constructor del formulario
        public FrmBackup()
        {
            InitializeComponent();
        }

        // Evento de carga inicial del formulario
        private void FrmBackup_Load(
     object sender,
     EventArgs e)
        {
            // Seleccionar el primer tipo de backup
            cbTipoBackup.SelectedIndex = 0;

            // Mostrar historial de backups
            MostrarHistorial();

            // Configurar estilos del DataGridView
            ConfigurarDataGrid();

            // Cargar último backup realizado
            CargarUltimoBackup();
        }

        // Configuración visual del DataGridView
        private void ConfigurarDataGrid()
        {
            try
            {
                // Eliminar bordes
                dgvBackupHistorial.BorderStyle =
                    BorderStyle.None;

                // Fondo blanco
                dgvBackupHistorial.BackgroundColor =
                    Color.White;

                // Ajustar columnas automáticamente
                dgvBackupHistorial.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                // Ocultar encabezados de filas
                dgvBackupHistorial.RowHeadersVisible =
                    false;

                // No permitir agregar filas
                dgvBackupHistorial.AllowUserToAddRows =
                    false;

                // No permitir redimensionar filas
                dgvBackupHistorial.AllowUserToResizeRows =
                    false;

                // Selección completa de fila
                dgvBackupHistorial.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                // No permitir múltiples selecciones
                dgvBackupHistorial.MultiSelect =
                    false;

                // Solo lectura
                dgvBackupHistorial.ReadOnly =
                    true;

                // Personalizar encabezados
                dgvBackupHistorial.EnableHeadersVisualStyles =
                    false;

                // Color de encabezados
                dgvBackupHistorial.ColumnHeadersDefaultCellStyle.BackColor =
                    Color.FromArgb(15, 35, 65);

                // Color de texto encabezados
                dgvBackupHistorial.ColumnHeadersDefaultCellStyle.ForeColor =
                    Color.White;

                // Fuente encabezados
                dgvBackupHistorial.ColumnHeadersDefaultCellStyle.Font =
                    new Font(
                        "Segoe UI",
                        10,
                        FontStyle.Bold);

                // Altura encabezados
                dgvBackupHistorial.ColumnHeadersHeight =
                    40;

                // Fuente general
                dgvBackupHistorial.DefaultCellStyle.Font =
                    new Font(
                        "Segoe UI",
                        9);

                // Altura de filas
                dgvBackupHistorial.RowTemplate.Height =
                    35;

                // Color alternado de filas
                dgvBackupHistorial.AlternatingRowsDefaultCellStyle.BackColor =
                    Color.FromArgb(240, 240, 240);

                // Validar columnas existentes
                if (dgvBackupHistorial.Columns.Count > 0)
                {
                    // Ocultar ID
                    if (dgvBackupHistorial.Columns.Contains("IdBackup"))
                    {
                        dgvBackupHistorial.Columns["IdBackup"].Visible =
                            false;
                    }

                    // Ocultar ruta archivo
                    if (dgvBackupHistorial.Columns.Contains("RutaArchivo"))
                    {
                        dgvBackupHistorial.Columns["RutaArchivo"].Visible =
                            false;
                    }

                    // Cambiar encabezado FechaBackup
                    if (dgvBackupHistorial.Columns.Contains("FechaBackup"))
                    {
                        dgvBackupHistorial.Columns["FechaBackup"].HeaderText =
                            "Fecha Backup";
                    }

                    // Cambiar encabezado TipoBackup
                    if (dgvBackupHistorial.Columns.Contains("TipoBackup"))
                    {
                        dgvBackupHistorial.Columns["TipoBackup"].HeaderText =
                            "Tipo Backup";
                    }

                    // Cambiar encabezado UsuarioSistema
                    if (dgvBackupHistorial.Columns.Contains("UsuarioSistema"))
                    {
                        dgvBackupHistorial.Columns["UsuarioSistema"].HeaderText =
                            "Usuario";
                    }

                    // Cambiar encabezado EstadoBackup
                    if (dgvBackupHistorial.Columns.Contains("EstadoBackup"))
                    {
                        dgvBackupHistorial.Columns["EstadoBackup"].HeaderText =
                            "Estado";
                    }

                    // Cambiar encabezado TamanoMB
                    if (dgvBackupHistorial.Columns.Contains("TamanoMB"))
                    {
                        dgvBackupHistorial.Columns["TamanoMB"].HeaderText =
                            "Tamaño MB";
                    }

                    // Cambiar encabezado Encriptado
                    if (dgvBackupHistorial.Columns.Contains("Encriptado"))
                    {
                        dgvBackupHistorial.Columns["Encriptado"].HeaderText =
                            "AES256";
                    }

                    // Cambiar encabezado Verificado
                    if (dgvBackupHistorial.Columns.Contains("Verificado"))
                    {
                        dgvBackupHistorial.Columns["Verificado"].HeaderText =
                            "Verificado";
                    }

                    // Cambiar encabezado Observaciones
                    if (dgvBackupHistorial.Columns.Contains("Observaciones"))
                    {
                        dgvBackupHistorial.Columns["Observaciones"].HeaderText =
                            "Observaciones";
                    }
                }
            }
            catch (Exception ex)
            {
                // Mostrar error visual
                MessageBox.Show(
                    ex.Message,
                    "Error Grid",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Mostrar historial de backups
        private void MostrarHistorial()
        {
            try
            {
                // Adaptador SQL
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        "sp_MostrarBackupHistorial",
                        cn.AbrirConexion());

                // Tipo stored procedure
                da.SelectCommand.CommandType =
                    CommandType.StoredProcedure;

                // Tabla temporal
                DataTable dt =
                    new DataTable();

                // Llenar tabla
                da.Fill(dt);

                // Limpiar datasource
                dgvBackupHistorial.DataSource = null;

                // Asignar datasource
                dgvBackupHistorial.DataSource = dt;

                // Cerrar conexión
                cn.CerrarConexion();

                // Configuración posterior al databind
                if (dgvBackupHistorial.Columns.Count > 0)
                {
                    dgvBackupHistorial.Columns["IdBackup"].Visible =
                        false;

                    dgvBackupHistorial.Columns["RutaArchivo"].Visible =
                        false;

                    dgvBackupHistorial.Columns["FechaBackup"].HeaderText =
                        "Fecha Backup";

                    dgvBackupHistorial.Columns["TipoBackup"].HeaderText =
                        "Tipo Backup";

                    dgvBackupHistorial.Columns["UsuarioSistema"].HeaderText =
                        "Usuario";

                    dgvBackupHistorial.Columns["EstadoBackup"].HeaderText =
                        "Estado";

                    dgvBackupHistorial.Columns["TamanoMB"].HeaderText =
                        "Tamaño MB";

                    dgvBackupHistorial.Columns["Encriptado"].HeaderText =
                        "AES256";

                    dgvBackupHistorial.Columns["Verificado"].HeaderText =
                        "Verificado";

                    dgvBackupHistorial.Columns["Observaciones"].HeaderText =
                        "Observaciones";
                }

                // Refrescar grid
                dgvBackupHistorial.Refresh();
            }
            catch (Exception ex)
            {
                // Mostrar error
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Cargar fecha del último backup
        private void CargarUltimoBackup()
        {
            try
            {
                // Consulta SQL
                SqlCommand cmd =
                    new SqlCommand(
                        @"SELECT TOP 1 FechaBackup
                          FROM BackupHistorial
                          ORDER BY IdBackup DESC",
                        cn.AbrirConexion());

                // Obtener resultado
                object resultado =
                    cmd.ExecuteScalar();

                // Validar resultado
                if (resultado != null)
                {
                    // Mostrar fecha formateada
                    txtUltimoBackup.Text =
                        Convert.ToDateTime(resultado)
                        .ToString("dd/MM/yyyy HH:mm:ss");
                }

                // Cerrar conexión
                cn.CerrarConexion();
            }
            catch
            {

            }
        }

        // Seleccionar ruta del backup
        private void btnRuta_Click(
            object sender,
            EventArgs e)
        {
            // Explorador de carpetas
            FolderBrowserDialog folder =
                new FolderBrowserDialog();

            // Validar selección
            if (folder.ShowDialog() ==
                DialogResult.OK)
            {
                // Asignar ruta seleccionada
                txtRuta.Text =
                    folder.SelectedPath;
            }
        }

        // Generar backup
        private void btnBackup_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                // Mostrar estado inicial
                lblEstado.Text =
                    "Estado: Generando Backup...";

                // Color naranja
                lblEstado.ForeColor =
                    Color.Orange;

                // Validar ruta vacía
                if (txtRuta.Text.Trim() == "")
                {
                    MessageBox.Show(
                        "Seleccione una ruta",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // Validar existencia de ruta
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

                // Validar permisos
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

                // Obtener contraseña AES
                string aesPassword =
                    ConfigurationManager
                    .AppSettings["AESPassword"];

                // Obtener tipo backup
                string tipoBackup =
                    cbTipoBackup.Text;

                // Generar fecha
                string fecha =
                    DateTime.Now.ToString(
                        "yyyyMMdd_HHmmss");

                // Crear nombre archivo
                string archivoBackup =
                    txtRuta.Text +
                    @"\" +
                    baseDatos +
                    "_" +
                    fecha +
                    ".bak";

                // Variable consulta SQL
                string query = "";

                // Backup FULL
                if (tipoBackup ==
                    "FULL BACKUP")
                {
                    query =
                        $@"BACKUP DATABASE [{baseDatos}]
                           TO DISK='{archivoBackup}'
                           WITH CHECKSUM, INIT";
                }

                // Backup diferencial
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

                // Backup log
                else
                {
                    query =
                        $@"BACKUP LOG [{baseDatos}]
                           TO DISK='{archivoBackup}'
                           WITH CHECKSUM,
                           INIT";
                }

                // Ejecutar backup SQL
                SqlCommand cmd =
                    new SqlCommand(
                        query,
                        cn.AbrirConexion());

                // Tiempo ilimitado
                cmd.CommandTimeout = 0;

                // Ejecutar comando
                cmd.ExecuteNonQuery();

                // Cerrar conexión
                cn.CerrarConexion();

                // Comprimir backup
                string zipFile =
                    compressionService
                    .ComprimirBackup(
                        archivoBackup);

                // Archivo final
                string archivoFinal =
                    zipFile;

                // Encriptar si está marcado
                if (chkEncriptar.Checked)
                {
                    archivoFinal =
                        encryptionService
                        .EncryptFile(
                            zipFile,
                            aesPassword);

                    // Eliminar ZIP original
                    if (File.Exists(zipFile))
                    {
                        File.Delete(zipFile);
                    }
                }

                // Eliminar archivo BAK
                if (File.Exists(archivoBackup))
                {
                    File.Delete(archivoBackup);
                }

                // Generar hash SHA256
                string hash =
                    hashService
                    .GenerarSHA256(
                        archivoFinal);

                // Crear backup espejo
                if (chkEspejo.Checked)
                {
                    disasterService
                        .CopiarBackupEspejo(
                            archivoFinal,
                            rutaEspejo);
                }

                // Obtener tamaño archivo
                FileInfo fi =
                    new FileInfo(
                        archivoFinal);

                // Convertir tamaño MB
                decimal tamanoMB =
                    Convert.ToDecimal(
                        fi.Length / 1024.0 / 1024.0);

                // Verificar backup
                if (chkVerificar.Checked)
                {
                    VerificarBackup(
                        archivoBackup);
                }

                // Guardar historial
                GuardarHistorial(
                    tipoBackup,
                    archivoFinal,
                    "EXITOSO",
                    tamanoMB,
                    hash);

                // Registrar log
                log.RegistrarLog(
                    "BACKUP",
                    usuarioSistema,
                    "Backup generado correctamente");

                // Actualizar estado
                lblEstado.Text =
                    "Estado: Backup Exitoso";

                // Color verde
                lblEstado.ForeColor =
                    Color.Green;

                // Enviar correo éxito
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

                // Mensaje éxito
                MessageBox.Show(
                    "Backup generado correctamente",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Actualizar historial
                MostrarHistorial();

                // Actualizar último backup
                CargarUltimoBackup();
            }
            catch (Exception ex)
            {
                // Mostrar estado error
                lblEstado.Text =
                    "Estado: Error Backup";

                // Color rojo
                lblEstado.ForeColor =
                    Color.Red;

                // Mostrar mensaje error
                MessageBox.Show(
                    ex.Message,
                    "Error Backup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                // Registrar log error
                log.RegistrarLog(
                    "ERROR BACKUP",
                    usuarioSistema,
                    ex.ToString());

                // Enviar correo error
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

        // Verificar integridad del backup
        private void VerificarBackup(
            string ruta)
        {
            try
            {
                // Comando RESTORE VERIFYONLY
                SqlCommand cmd =
                    new SqlCommand(
                        $@"RESTORE VERIFYONLY
                           FROM DISK='{ruta}'",
                        cn.AbrirConexion());

                // Ejecutar verificación
                cmd.ExecuteNonQuery();

                // Cerrar conexión
                cn.CerrarConexion();
            }
            catch
            {

            }
        }

        // Guardar historial en SQL
        private void GuardarHistorial(
            string tipo,
            string ruta,
            string estado,
            decimal tamano,
            string hash)
        {
            try
            {
                // Crear comando SQL
                SqlCommand cmd =
                    new SqlCommand(
                        "sp_InsertarBackupHistorial",
                        cn.AbrirConexion());

                // Tipo stored procedure
                cmd.CommandType =
                    CommandType.StoredProcedure;

                // Parámetro tipo backup
                cmd.Parameters.AddWithValue(
                    "@TipoBackup",
                    tipo);

                // Parámetro usuario
                cmd.Parameters.AddWithValue(
                    "@UsuarioSistema",
                    usuarioSistema);

                // Parámetro ruta
                cmd.Parameters.AddWithValue(
                    "@RutaArchivo",
                    ruta);

                // Parámetro estado
                cmd.Parameters.AddWithValue(
                    "@EstadoBackup",
                    estado);

                // Parámetro tamaño
                cmd.Parameters.AddWithValue(
                    "@TamanoMB",
                    tamano);

                // Parámetro hash
                cmd.Parameters.AddWithValue(
                    "@HashBackup",
                    hash);

                // Parámetro encriptado
                cmd.Parameters.AddWithValue(
                    "@Encriptado",
                    chkEncriptar.Checked);

                // Parámetro verificado
                cmd.Parameters.AddWithValue(
                    "@Verificado",
                    chkVerificar.Checked);

                // Parámetro observaciones
                cmd.Parameters.AddWithValue(
                    "@Observaciones",
                    "Backup generado correctamente");

                // Ejecutar inserción
                cmd.ExecuteNonQuery();

                // Cerrar conexión
                cn.CerrarConexion();
            }
            catch
            {

            }
        }

        // Restaurar backup
        private void btnRestore_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                // Abrir explorador archivos
                OpenFileDialog open =
                    new OpenFileDialog();

                // Filtrar archivos encriptados
                open.Filter =
                    "Encrypted Backup|*.enc";

                // Validar selección
                if (open.ShowDialog() ==
                    DialogResult.OK)
                {
                    // Estado restaurando
                    lblEstado.Text =
                        "Estado: Restaurando...";

                    // Color naranja
                    lblEstado.ForeColor =
                        Color.Orange;

                    // Obtener contraseña AES
                    string aesPassword =
                        ConfigurationManager
                        .AppSettings["AESPassword"];

                    // Restaurar backup
                    restoreService.RestaurarBackup(
                        @".\SQLEXPRESS",
                        "Inventario",
                        open.FileName,
                        aesPassword);

                    // Estado restaurado
                    lblEstado.Text =
                        "Estado: Restaurado";

                    // Color verde
                    lblEstado.ForeColor =
                        Color.Green;

                    // Registrar log restore
                    log.RegistrarLog(
                        "RESTORE",
                        usuarioSistema,
                        "Restore realizado correctamente");

                    // Enviar correo restore exitoso
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

                    // Mostrar mensaje éxito
                    MessageBox.Show(
                        "Backup restaurado correctamente",
                        "Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Estado error restore
                lblEstado.Text =
                    "Estado: Error Restore";

                // Color rojo
                lblEstado.ForeColor =
                    Color.Red;

                // Mostrar error
                MessageBox.Show(
                    ex.Message,
                    "Error Restore",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                // Registrar log error
                log.RegistrarLog(
                    "ERROR RESTORE",
                    usuarioSistema,
                    ex.ToString());

                // Enviar correo error
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

        // Dibujar información del panel
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Limpiar controles del panel
            panel1.Controls.Clear();

            // Label espacio disponible
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

            // Label espacio usado
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

            // Label backups
            Label lblBackups =
                new Label();

            try
            {
                // Nueva conexión
                Conexion cn =
                    new Conexion();

                // Consulta cantidad backups
                SqlCommand cmd =
                    new SqlCommand(
                        "SELECT COUNT(*) FROM BackupHistorial",
                        cn.AbrirConexion());

                // Obtener total
                int total =
                    Convert.ToInt32(
                        cmd.ExecuteScalar());

                // Mostrar total backups
                lblBackups.Text =
                    $"Backups: {total}";

                // Cerrar conexión
                cn.CerrarConexion();
            }
            catch
            {
                // Valor por defecto
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

            // Label estado
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

            // Barra progreso disco
            ProgressBar progressDisco =
                new ProgressBar();

            progressDisco.Size =
                new Size(110, 12);

            progressDisco.Location =
                new Point(300, 45);

            progressDisco.Maximum = 100;

            panel1.Controls.Add(
                progressDisco);

            // Obtener disco C
            DriveInfo drive =
                DriveInfo.GetDrives()
                .FirstOrDefault(
                    d => d.IsReady &&
                    d.Name == @"C:\");

            // Validar disco
            if (drive != null)
            {
                // Total GB
                double totalGB =
                    drive.TotalSize /
                    1024.0 / 1024.0 / 1024.0;

                // Espacio libre GB
                double libreGB =
                    drive.AvailableFreeSpace /
                    1024.0 / 1024.0 / 1024.0;

                // Espacio usado GB
                double usadoGB =
                    totalGB - libreGB;

                // Porcentaje uso
                int porcentaje =
                    Convert.ToInt32(
                        (usadoGB / totalGB) * 100);

                // Mostrar espacio disponible
                lblEspacioDisponible.Text =
                    $"Disponible: {libreGB:N2} GB";

                // Mostrar espacio usado
                lblEspacioUsado.Text =
                    $"Usado: {usadoGB:N2} GB";

                // Actualizar barra progreso
                progressDisco.Value =
                    porcentaje;
            }
        }
    }
}