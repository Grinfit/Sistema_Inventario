using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Sistema_Inventario.Presentacion
{
    partial class FrmBackup
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle headerStyle =
                new DataGridViewCellStyle();

            DataGridViewCellStyle rowsStyle =
                new DataGridViewCellStyle();

            this.lblTitulo = new Label();

            this.lblRuta = new Label();
            this.lblTipo = new Label();
            this.lblUltimo = new Label();
            this.lblEstado = new Label();

            this.txtRuta = new TextBox();
            this.txtUltimoBackup = new TextBox();

            this.cbTipoBackup = new ComboBox();

            this.chkEncriptar = new CheckBox();
            this.chkVerificar = new CheckBox();
            this.chkComprimir = new CheckBox();
            this.chkCorreo = new CheckBox();
            this.chkEspejo = new CheckBox();

            this.btnRuta = new IconButton();
            this.btnBackup = new IconButton();
            this.btnRestore = new IconButton();
            this.btnVerificar = new IconButton();
            this.btnExportar = new IconButton();

            this.dgvBackupHistorial = new DataGridView();

            this.toolTip1 = new ToolTip();

            ((System.ComponentModel.ISupportInitialize)(this.dgvBackupHistorial)).BeginInit();

            this.SuspendLayout();

            // =====================================================
            // FORMULARIO
            // =====================================================

            this.ClientSize =
                new Size(1600, 900);

            this.BackColor =
                Color.FromArgb(236, 240, 245);

            this.FormBorderStyle =
                FormBorderStyle.None;

            this.Name =
                "FrmBackup";

            this.Text =
                "FrmBackup";

            this.Load +=
                new System.EventHandler(this.FrmBackup_Load);

            // =====================================================
            // TITULO
            // =====================================================

            this.lblTitulo.AutoSize = true;

            this.lblTitulo.Font =
                new Font(
                    "Segoe UI",
                    30F,
                    FontStyle.Bold);

            this.lblTitulo.ForeColor =
                Color.FromArgb(10, 35, 66);

            this.lblTitulo.Location =
                new Point(50, 25);

            this.lblTitulo.Text =
                "Gestión de Backups";

            // =====================================================
            // LABEL RUTA
            // =====================================================

            this.lblRuta.AutoSize = true;

            this.lblRuta.Font =
                new Font(
                    "Segoe UI Semibold",
                    13F,
                    FontStyle.Bold);

            this.lblRuta.Location =
                new Point(60, 120);

            this.lblRuta.Text =
                "Ruta Backup";

            // =====================================================
            // TXT RUTA
            // =====================================================

            this.txtRuta.Font =
                new Font(
                    "Segoe UI",
                    12F);

            this.txtRuta.Location =
                new Point(260, 115);

            this.txtRuta.Size =
                new Size(650, 34);

            this.txtRuta.BorderStyle =
                BorderStyle.FixedSingle;

            // =====================================================
            // BTN RUTA
            // =====================================================

            this.btnRuta.BackColor =
                Color.FromArgb(52, 152, 219);

            this.btnRuta.FlatStyle =
                FlatStyle.Flat;

            this.btnRuta.FlatAppearance.BorderSize = 0;

            this.btnRuta.ForeColor =
                Color.White;

            this.btnRuta.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            this.btnRuta.IconChar =
                IconChar.FolderOpen;

            this.btnRuta.IconColor =
                Color.White;

            this.btnRuta.IconFont =
                IconFont.Auto;

            this.btnRuta.IconSize = 28;

            this.btnRuta.Text =
                " Seleccionar";

            this.btnRuta.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            this.btnRuta.Size =
                new Size(200, 50);

            this.btnRuta.Location =
                new Point(950, 105);

            this.btnRuta.Cursor =
                Cursors.Hand;

            this.btnRuta.Click +=
                new System.EventHandler(this.btnRuta_Click);

            // =====================================================
            // LABEL TIPO
            // =====================================================

            this.lblTipo.AutoSize = true;

            this.lblTipo.Font =
                new Font(
                    "Segoe UI Semibold",
                    13F,
                    FontStyle.Bold);

            this.lblTipo.Location =
                new Point(60, 200);

            this.lblTipo.Text =
                "Tipo Backup";

            // =====================================================
            // COMBO TIPO BACKUP
            // =====================================================

            this.cbTipoBackup.Font =
                new Font(
                    "Segoe UI",
                    12F);

            this.cbTipoBackup.Location =
                new Point(260, 195);

            this.cbTipoBackup.Size =
                new Size(320, 36);

            this.cbTipoBackup.DropDownStyle =
                ComboBoxStyle.DropDownList;

            this.cbTipoBackup.Items.AddRange(
                new object[]
                {
                    "FULL BACKUP",
                    "DIFFERENTIAL BACKUP",
                    "LOG BACKUP"
                });

            // =====================================================
            // CHECKBOX ENCRIPTAR
            // =====================================================

            this.chkEncriptar.AutoSize = true;

            this.chkEncriptar.Font =
                new Font(
                    "Segoe UI",
                    11F);

            this.chkEncriptar.Location =
                new Point(70, 280);

            this.chkEncriptar.Text =
                "Encriptar backup";

            // =====================================================
            // CHECKBOX VERIFICAR
            // =====================================================

            this.chkVerificar.AutoSize = true;

            this.chkVerificar.Font =
                new Font(
                    "Segoe UI",
                    11F);

            this.chkVerificar.Location =
                new Point(350, 280);

            this.chkVerificar.Text =
                "Verificar integridad";

            // =====================================================
            // CHECKBOX COMPRIMIR
            // =====================================================

            this.chkComprimir.AutoSize = true;

            this.chkComprimir.Font =
                new Font(
                    "Segoe UI",
                    11F);

            this.chkComprimir.Location =
                new Point(650, 280);

            this.chkComprimir.Text =
                "Comprimir backup";

            // =====================================================
            // CHECKBOX CORREO
            // =====================================================

            this.chkCorreo.AutoSize = true;

            this.chkCorreo.Font =
                new Font(
                    "Segoe UI",
                    11F);

            this.chkCorreo.Location =
                new Point(930, 280);

            this.chkCorreo.Text =
                "Enviar alerta correo";

            // =====================================================
            // CHECKBOX ESPEJO
            // =====================================================

            this.chkEspejo.AutoSize = true;

            this.chkEspejo.Font =
                new Font(
                    "Segoe UI",
                    11F);

            this.chkEspejo.Location =
                new Point(1220, 280);

            this.chkEspejo.Text =
                "Backup espejo";

            // =====================================================
            // LABEL ULTIMO BACKUP
            // =====================================================

            this.lblUltimo.AutoSize = true;

            this.lblUltimo.Font =
                new Font(
                    "Segoe UI Semibold",
                    13F,
                    FontStyle.Bold);

            this.lblUltimo.Location =
                new Point(60, 360);

            this.lblUltimo.Text =
                "Último Backup";

            // =====================================================
            // TXT ULTIMO BACKUP
            // =====================================================

            this.txtUltimoBackup.Font =
                new Font(
                    "Segoe UI",
                    12F);

            this.txtUltimoBackup.Location =
                new Point(260, 355);

            this.txtUltimoBackup.Size =
                new Size(500, 34);

            this.txtUltimoBackup.ReadOnly =
                true;

            this.txtUltimoBackup.BorderStyle =
                BorderStyle.FixedSingle;

            // =====================================================
            // LABEL ESTADO
            // =====================================================

            this.lblEstado.AutoSize = true;

            this.lblEstado.Font =
                new Font(
                    "Segoe UI",
                    12F,
                    FontStyle.Bold);

            this.lblEstado.ForeColor =
                Color.Green;

            this.lblEstado.Location =
                new Point(850, 355);

            this.lblEstado.Text =
                "Estado: LISTO";

            // =====================================================
            // BTN BACKUP
            // =====================================================

            this.btnBackup.BackColor =
                Color.FromArgb(46, 204, 113);

            this.btnBackup.FlatStyle =
                FlatStyle.Flat;

            this.btnBackup.FlatAppearance.BorderSize = 0;

            this.btnBackup.ForeColor =
                Color.White;

            this.btnBackup.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            this.btnBackup.IconChar =
                IconChar.Database;

            this.btnBackup.IconColor =
                Color.White;

            this.btnBackup.IconFont =
                IconFont.Auto;

            this.btnBackup.IconSize = 28;

            this.btnBackup.Text =
                " Generar Backup";

            this.btnBackup.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            this.btnBackup.Size =
                new Size(230, 58);

            this.btnBackup.Location =
                new Point(70, 450);

            this.btnBackup.Cursor =
                Cursors.Hand;

            this.btnBackup.Click +=
                new System.EventHandler(this.btnBackup_Click);

            // =====================================================
            // BTN RESTORE
            // =====================================================

            this.btnRestore.BackColor =
                Color.FromArgb(241, 196, 15);

            this.btnRestore.FlatStyle =
                FlatStyle.Flat;

            this.btnRestore.FlatAppearance.BorderSize = 0;

            this.btnRestore.ForeColor =
                Color.White;

            this.btnRestore.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            this.btnRestore.IconChar =
                IconChar.RotateLeft;

            this.btnRestore.IconColor =
                Color.White;

            this.btnRestore.IconFont =
                IconFont.Auto;

            this.btnRestore.IconSize = 28;

            this.btnRestore.Text =
                " Restaurar";

            this.btnRestore.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            this.btnRestore.Size =
                new Size(210, 58);

            this.btnRestore.Location =
                new Point(350, 450);

            this.btnRestore.Cursor =
                Cursors.Hand;

            this.btnRestore.Click +=
                new System.EventHandler(this.btnRestore_Click);

            // =====================================================
            // BTN VERIFICAR
            // =====================================================

            this.btnVerificar.BackColor =
                Color.FromArgb(52, 152, 219);

            this.btnVerificar.FlatStyle =
                FlatStyle.Flat;

            this.btnVerificar.FlatAppearance.BorderSize = 0;

            this.btnVerificar.ForeColor =
                Color.White;

            this.btnVerificar.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            this.btnVerificar.IconChar =
                IconChar.ShieldHalved;

            this.btnVerificar.IconColor =
                Color.White;

            this.btnVerificar.IconFont =
                IconFont.Auto;

            this.btnVerificar.IconSize = 28;

            this.btnVerificar.Text =
                " Verificar";

            this.btnVerificar.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            this.btnVerificar.Size =
                new Size(210, 58);

            this.btnVerificar.Location =
                new Point(620, 450);

            this.btnVerificar.Cursor =
                Cursors.Hand;

            // =====================================================
            // BTN EXPORTAR
            // =====================================================

            this.btnExportar.BackColor =
                Color.FromArgb(155, 89, 182);

            this.btnExportar.FlatStyle =
                FlatStyle.Flat;

            this.btnExportar.FlatAppearance.BorderSize = 0;

            this.btnExportar.ForeColor =
                Color.White;

            this.btnExportar.Font =
                new Font(
                    "Segoe UI Semibold",
                    10F,
                    FontStyle.Bold);

            this.btnExportar.IconChar =
                IconChar.FileExport;

            this.btnExportar.IconColor =
                Color.White;

            this.btnExportar.IconFont =
                IconFont.Auto;

            this.btnExportar.IconSize = 28;

            this.btnExportar.Text =
                " Exportar";

            this.btnExportar.TextImageRelation =
                TextImageRelation.ImageBeforeText;

            this.btnExportar.Size =
                new Size(210, 58);

            this.btnExportar.Location =
                new Point(890, 450);

            this.btnExportar.Cursor =
                Cursors.Hand;

            // =====================================================
            // DATAGRIDVIEW
            // =====================================================

            this.dgvBackupHistorial.AllowUserToAddRows = false;

            this.dgvBackupHistorial.AllowUserToDeleteRows = false;

            this.dgvBackupHistorial.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvBackupHistorial.BackgroundColor =
                Color.White;

            this.dgvBackupHistorial.BorderStyle =
                BorderStyle.None;

            this.dgvBackupHistorial.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            this.dgvBackupHistorial.Location =
                new Point(40, 560);

            this.dgvBackupHistorial.Size =
                new Size(1580, 500);

            this.dgvBackupHistorial.ReadOnly = true;

            this.dgvBackupHistorial.RowHeadersVisible = false;

            this.dgvBackupHistorial.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            this.dgvBackupHistorial.MultiSelect = false;

            this.dgvBackupHistorial.EnableHeadersVisualStyles = false;

            this.dgvBackupHistorial.ColumnHeadersHeight = 45;

            this.dgvBackupHistorial.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            this.dgvBackupHistorial.RowTemplate.Height = 42;

            // =====================================================
            // HEADER STYLE
            // =====================================================

            headerStyle.BackColor =
                Color.FromArgb(10, 35, 66);

            headerStyle.ForeColor =
                Color.White;

            headerStyle.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold);

            this.dgvBackupHistorial.ColumnHeadersDefaultCellStyle =
                headerStyle;

            // =====================================================
            // ROW STYLE
            // =====================================================

            rowsStyle.Font =
                new Font(
                    "Segoe UI",
                    10F);

            rowsStyle.SelectionBackColor =
                Color.FromArgb(52, 152, 219);

            rowsStyle.SelectionForeColor =
                Color.White;

            this.dgvBackupHistorial.RowsDefaultCellStyle =
                rowsStyle;

            this.dgvBackupHistorial.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 247, 250);

            this.dgvBackupHistorial.DefaultCellStyle.Padding =
                new Padding(5);

            this.dgvBackupHistorial.GridColor =
                Color.FromArgb(225, 225, 225);

            // =====================================================
            // TOOLTIPS
            // =====================================================

            this.toolTip1.SetToolTip(
                this.btnBackup,
                "Generar backup seguro");

            this.toolTip1.SetToolTip(
                this.btnRestore,
                "Restaurar backup");

            this.toolTip1.SetToolTip(
                this.chkEncriptar,
                "AES-256");

            this.toolTip1.SetToolTip(
                this.chkComprimir,
                "Comprimir ZIP");

            this.toolTip1.SetToolTip(
                this.chkEspejo,
                "Crear copia espejo");

            // =====================================================
            // CONTROLES
            // =====================================================

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

            ((System.ComponentModel.ISupportInitialize)(this.dgvBackupHistorial)).EndInit();

            this.ResumeLayout(false);

            this.PerformLayout();
        }

        #endregion

        private Label lblTitulo;

        private Label lblRuta;
        private Label lblTipo;
        private Label lblUltimo;
        private Label lblEstado;

        private TextBox txtRuta;
        private TextBox txtUltimoBackup;

        private ComboBox cbTipoBackup;

        private CheckBox chkEncriptar;
        private CheckBox chkVerificar;
        private CheckBox chkComprimir;
        private CheckBox chkCorreo;
        private CheckBox chkEspejo;

        private IconButton btnRuta;
        private IconButton btnBackup;
        private IconButton btnRestore;
        private IconButton btnVerificar;
        private IconButton btnExportar;

        private DataGridView dgvBackupHistorial;

        private ToolTip toolTip1;
    }
}