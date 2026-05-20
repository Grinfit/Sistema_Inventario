// IMPORTACION DE LIBRERIAS NECESARIAS
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Sistema_Inventario.Presentacion
{
    // CLASE PARCIAL DEL FORMULARIO BACKUP
    partial class FrmBackup
    {
        // CONTENEDOR DE COMPONENTES DEL FORMULARIO
        private System.ComponentModel.IContainer components = null;

        // METODO PARA LIBERAR RECURSOS
        protected override void Dispose(bool disposing)
        {
            // VERIFICA SI LOS COMPONENTES DEBEN SER LIBERADOS
            if (disposing && (components != null))
            {
                // LIBERA LOS COMPONENTES
                components.Dispose();
            }

            // LLAMA AL METODO BASE
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        // METODO PARA INICIALIZAR LOS COMPONENTES
        private void InitializeComponent()
        {
            // INICIALIZA LOS COMPONENTES
            this.components = new System.ComponentModel.Container();

            // ESTILOS DEL DATAGRIDVIEW
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 =
                new System.Windows.Forms.DataGridViewCellStyle();

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 =
                new System.Windows.Forms.DataGridViewCellStyle();

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 =
                new System.Windows.Forms.DataGridViewCellStyle();

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 =
                new System.Windows.Forms.DataGridViewCellStyle();

            // LABEL TITULO
            this.lblTitulo =
                new System.Windows.Forms.Label();

            // LABEL RUTA
            this.lblRuta =
                new System.Windows.Forms.Label();

            // LABEL TIPO
            this.lblTipo =
                new System.Windows.Forms.Label();

            // LABEL ULTIMO BACKUP
            this.lblUltimo =
                new System.Windows.Forms.Label();

            // LABEL ESTADO
            this.lblEstado =
                new System.Windows.Forms.Label();

            // TEXTBOX RUTA
            this.txtRuta =
                new System.Windows.Forms.TextBox();

            // TEXTBOX ULTIMO BACKUP
            this.txtUltimoBackup =
                new System.Windows.Forms.TextBox();

            // COMBOBOX TIPO BACKUP
            this.cbTipoBackup =
                new System.Windows.Forms.ComboBox();

            // CHECKBOX ENCRIPTAR
            this.chkEncriptar =
                new System.Windows.Forms.CheckBox();

            // CHECKBOX VERIFICAR
            this.chkVerificar =
                new System.Windows.Forms.CheckBox();

            // CHECKBOX COMPRIMIR
            this.chkComprimir =
                new System.Windows.Forms.CheckBox();

            // CHECKBOX CORREO
            this.chkCorreo =
                new System.Windows.Forms.CheckBox();

            // CHECKBOX ESPEJO
            this.chkEspejo =
                new System.Windows.Forms.CheckBox();

            // BOTON RUTA
            this.btnRuta =
                new FontAwesome.Sharp.IconButton();

            // BOTON BACKUP
            this.btnBackup =
                new FontAwesome.Sharp.IconButton();

            // BOTON RESTORE
            this.btnRestore =
                new FontAwesome.Sharp.IconButton();

            // BOTON VERIFICAR
            this.btnVerificar =
                new FontAwesome.Sharp.IconButton();

            // BOTON EXPORTAR
            this.btnExportar =
                new FontAwesome.Sharp.IconButton();

            // DATAGRID HISTORIAL
            this.dgvBackupHistorial =
                new System.Windows.Forms.DataGridView();

            // TOOLTIP
            this.toolTip1 =
                new System.Windows.Forms.ToolTip(this.components);

            // PANEL ESTADISTICAS
            this.panel1 =
                new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.dgvBackupHistorial)).BeginInit();

            this.SuspendLayout();

            // CONFIGURACION LABEL TITULO
            this.lblTitulo.AutoSize = true;

            this.lblTitulo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    30F,
                    System.Drawing.FontStyle.Bold);

            this.lblTitulo.ForeColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(10)))),
                    ((int)(((byte)(35)))),
                    ((int)(((byte)(66)))));

            this.lblTitulo.Location =
                new System.Drawing.Point(50, 25);

            this.lblTitulo.Name =
                "lblTitulo";

            this.lblTitulo.Size =
                new System.Drawing.Size(488, 67);

            this.lblTitulo.TabIndex = 0;

            this.lblTitulo.Text =
                "Gestión de Backups";

            // CONFIGURACION LABEL RUTA
            this.lblRuta.AutoSize = true;

            this.lblRuta.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    13F,
                    System.Drawing.FontStyle.Bold);

            this.lblRuta.Location =
                new System.Drawing.Point(60, 120);

            this.lblRuta.Name =
                "lblRuta";

            this.lblRuta.Size =
                new System.Drawing.Size(137, 30);

            this.lblRuta.TabIndex = 1;

            this.lblRuta.Text =
                "Ruta Backup";

            // CONFIGURACION LABEL TIPO
            this.lblTipo.AutoSize = true;

            this.lblTipo.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    13F,
                    System.Drawing.FontStyle.Bold);

            this.lblTipo.Location =
                new System.Drawing.Point(60, 200);

            this.lblTipo.Name =
                "lblTipo";

            this.lblTipo.Size =
                new System.Drawing.Size(135, 30);

            this.lblTipo.TabIndex = 2;

            this.lblTipo.Text =
                "Tipo Backup";

            // CONFIGURACION LABEL ULTIMO
            this.lblUltimo.AutoSize = true;

            this.lblUltimo.Font =
                new System.Drawing.Font(
                    "Segoe UI Semibold",
                    13F,
                    System.Drawing.FontStyle.Bold);

            this.lblUltimo.Location =
                new System.Drawing.Point(60, 360);

            this.lblUltimo.Name =
                "lblUltimo";

            this.lblUltimo.Size =
                new System.Drawing.Size(158, 30);

            this.lblUltimo.TabIndex = 3;

            this.lblUltimo.Text =
                "Último Backup";

            // CONFIGURACION LABEL ESTADO
            this.lblEstado.AutoSize = true;

            this.lblEstado.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold);

            this.lblEstado.ForeColor =
                System.Drawing.Color.Green;

            this.lblEstado.Location =
                new System.Drawing.Point(850, 355);

            this.lblEstado.Name =
                "lblEstado";

            this.lblEstado.Size =
                new System.Drawing.Size(139, 28);

            this.lblEstado.TabIndex = 4;

            this.lblEstado.Text =
                "Estado: LISTO";

            // CONFIGURACION TEXTBOX RUTA
            this.txtRuta.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtRuta.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F);

            this.txtRuta.Location =
                new System.Drawing.Point(260, 115);

            this.txtRuta.Name =
                "txtRuta";

            this.txtRuta.Size =
                new System.Drawing.Size(650, 34);

            this.txtRuta.TabIndex = 5;

            // CONFIGURACION TEXTBOX ULTIMO BACKUP
            this.txtUltimoBackup.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.txtUltimoBackup.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F);

            this.txtUltimoBackup.Location =
                new System.Drawing.Point(260, 355);

            this.txtUltimoBackup.Name =
                "txtUltimoBackup";

            this.txtUltimoBackup.ReadOnly =
                true;

            this.txtUltimoBackup.Size =
                new System.Drawing.Size(500, 34);

            this.txtUltimoBackup.TabIndex = 6;

            // CONFIGURACION COMBOBOX
            this.cbTipoBackup.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cbTipoBackup.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F);

            this.cbTipoBackup.Items.AddRange(
                new object[] {
            "FULL BACKUP",
            "DIFFERENTIAL BACKUP",
            "LOG BACKUP"});

            this.cbTipoBackup.Location =
                new System.Drawing.Point(260, 195);

            this.cbTipoBackup.Name =
                "cbTipoBackup";

            this.cbTipoBackup.Size =
                new System.Drawing.Size(320, 36);

            this.cbTipoBackup.TabIndex = 7;

            // CONFIGURACION CHECKBOX ENCRIPTAR
            this.chkEncriptar.AutoSize = true;

            this.chkEncriptar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F);

            this.chkEncriptar.Location =
                new System.Drawing.Point(70, 280);

            this.chkEncriptar.Name =
                "chkEncriptar";

            this.chkEncriptar.Size =
                new System.Drawing.Size(176, 29);

            this.chkEncriptar.TabIndex = 8;

            this.chkEncriptar.Text =
                "Encriptar backup";

            this.toolTip1.SetToolTip(
                this.chkEncriptar,
                "AES-256");

            // CONFIGURACION CHECKBOX VERIFICAR
            this.chkVerificar.AutoSize = true;

            this.chkVerificar.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F);

            this.chkVerificar.Location =
                new System.Drawing.Point(350, 280);

            this.chkVerificar.Name =
                "chkVerificar";

            this.chkVerificar.Size =
                new System.Drawing.Size(196, 29);

            this.chkVerificar.TabIndex = 9;

            this.chkVerificar.Text =
                "Verificar integridad";

            // CONFIGURACION CHECKBOX COMPRIMIR
            this.chkComprimir.AutoSize = true;

            this.chkComprimir.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F);

            this.chkComprimir.Location =
                new System.Drawing.Point(650, 280);

            this.chkComprimir.Name =
                "chkComprimir";

            this.chkComprimir.Size =
                new System.Drawing.Size(190, 29);

            this.chkComprimir.TabIndex = 10;

            this.chkComprimir.Text =
                "Comprimir backup";

            // CONFIGURACION CHECKBOX CORREO
            this.chkCorreo.AutoSize = true;

            this.chkCorreo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F);

            this.chkCorreo.Location =
                new System.Drawing.Point(930, 280);

            this.chkCorreo.Name =
                "chkCorreo";

            this.chkCorreo.Size =
                new System.Drawing.Size(199, 29);

            this.chkCorreo.TabIndex = 11;

            this.chkCorreo.Text =
                "Enviar alerta correo";

            // CONFIGURACION CHECKBOX ESPEJO
            this.chkEspejo.AutoSize = true;

            this.chkEspejo.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F);

            this.chkEspejo.Location =
                new System.Drawing.Point(1220, 280);

            this.chkEspejo.Name =
                "chkEspejo";

            this.chkEspejo.Size =
                new System.Drawing.Size(155, 29);

            this.chkEspejo.TabIndex = 12;

            this.chkEspejo.Text =
                "Backup espejo";

            // CONFIGURACION PANEL
            this.panel1.Location =
                new System.Drawing.Point(650, 174);

            this.panel1.Name =
                "panel1";

            this.panel1.Size =
                new System.Drawing.Size(458, 85);

            this.panel1.TabIndex = 19;

            this.panel1.Paint +=
                new System.Windows.Forms.PaintEventHandler(
                    this.panel1_Paint);

            // CONFIGURACION FORMULARIO
            this.BackColor =
                System.Drawing.Color.FromArgb(
                    ((int)(((byte)(236)))),
                    ((int)(((byte)(240)))),
                    ((int)(((byte)(245)))));

            this.ClientSize =
                new System.Drawing.Size(1600, 900);

            // AGREGA CONTROLES
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblRuta);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblUltimo);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.txtUltimoBackup);
            this.Controls.Add(this.cbTipoBackup);
            this.Controls.Add(this.chkEncriptar);
            this.Controls.Add(this.chkVerificar);
            this.Controls.Add(this.chkComprimir);
            this.Controls.Add(this.chkCorreo);
            this.Controls.Add(this.chkEspejo);
            this.Controls.Add(this.btnRuta);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnVerificar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dgvBackupHistorial);

            // CONFIGURA EL FORMULARIO
            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.None;

            this.Name =
                "FrmBackup";

            this.Text =
                "FrmBackup";

            // EVENTO LOAD
            this.Load +=
                new System.EventHandler(
                    this.FrmBackup_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvBackupHistorial)).EndInit();

            this.ResumeLayout(false);

            this.PerformLayout();
        }

        #endregion

        // LABEL TITULO
        private Label lblTitulo;

        // LABELS
        private Label lblRuta;
        private Label lblTipo;
        private Label lblUltimo;
        private Label lblEstado;

        // TEXTBOX
        private TextBox txtRuta;
        private TextBox txtUltimoBackup;

        // COMBOBOX
        private ComboBox cbTipoBackup;

        // CHECKBOX
        private CheckBox chkEncriptar;
        private CheckBox chkVerificar;
        private CheckBox chkComprimir;
        private CheckBox chkCorreo;
        private CheckBox chkEspejo;

        // BOTONES
        private IconButton btnRuta;
        private IconButton btnBackup;
        private IconButton btnRestore;
        private IconButton btnVerificar;
        private IconButton btnExportar;

        // DATAGRIDVIEW
        private DataGridView dgvBackupHistorial;

        // TOOLTIP
        private ToolTip toolTip1;

        // PANEL
        private Panel panel1;
    }
}