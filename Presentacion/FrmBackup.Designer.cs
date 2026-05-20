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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblRuta = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblUltimo = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.txtUltimoBackup = new System.Windows.Forms.TextBox();
            this.cbTipoBackup = new System.Windows.Forms.ComboBox();
            this.chkEncriptar = new System.Windows.Forms.CheckBox();
            this.chkVerificar = new System.Windows.Forms.CheckBox();
            this.chkComprimir = new System.Windows.Forms.CheckBox();
            this.chkCorreo = new System.Windows.Forms.CheckBox();
            this.chkEspejo = new System.Windows.Forms.CheckBox();
            this.btnRuta = new FontAwesome.Sharp.IconButton();
            this.btnBackup = new FontAwesome.Sharp.IconButton();
            this.btnRestore = new FontAwesome.Sharp.IconButton();
            this.btnVerificar = new FontAwesome.Sharp.IconButton();
            this.btnExportar = new FontAwesome.Sharp.IconButton();
            this.dgvBackupHistorial = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackupHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(35)))), ((int)(((byte)(66)))));
            this.lblTitulo.Location = new System.Drawing.Point(50, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(488, 67);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión de Backups";
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblRuta.Location = new System.Drawing.Point(60, 120);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(137, 30);
            this.lblRuta.TabIndex = 1;
            this.lblRuta.Text = "Ruta Backup";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblTipo.Location = new System.Drawing.Point(60, 200);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(135, 30);
            this.lblTipo.TabIndex = 2;
            this.lblTipo.Text = "Tipo Backup";
            // 
            // lblUltimo
            // 
            this.lblUltimo.AutoSize = true;
            this.lblUltimo.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblUltimo.Location = new System.Drawing.Point(60, 360);
            this.lblUltimo.Name = "lblUltimo";
            this.lblUltimo.Size = new System.Drawing.Size(158, 30);
            this.lblUltimo.TabIndex = 3;
            this.lblUltimo.Text = "Último Backup";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.Green;
            this.lblEstado.Location = new System.Drawing.Point(850, 355);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(139, 28);
            this.lblEstado.TabIndex = 4;
            this.lblEstado.Text = "Estado: LISTO";
            // 
            // txtRuta
            // 
            this.txtRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRuta.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtRuta.Location = new System.Drawing.Point(260, 115);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(650, 34);
            this.txtRuta.TabIndex = 5;
            // 
            // txtUltimoBackup
            // 
            this.txtUltimoBackup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUltimoBackup.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtUltimoBackup.Location = new System.Drawing.Point(260, 355);
            this.txtUltimoBackup.Name = "txtUltimoBackup";
            this.txtUltimoBackup.ReadOnly = true;
            this.txtUltimoBackup.Size = new System.Drawing.Size(500, 34);
            this.txtUltimoBackup.TabIndex = 6;
            // 
            // cbTipoBackup
            // 
            this.cbTipoBackup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoBackup.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbTipoBackup.Items.AddRange(new object[] {
            "FULL BACKUP",
            "DIFFERENTIAL BACKUP",
            "LOG BACKUP"});
            this.cbTipoBackup.Location = new System.Drawing.Point(260, 195);
            this.cbTipoBackup.Name = "cbTipoBackup";
            this.cbTipoBackup.Size = new System.Drawing.Size(320, 36);
            this.cbTipoBackup.TabIndex = 7;
            // 
            // chkEncriptar
            // 
            this.chkEncriptar.AutoSize = true;
            this.chkEncriptar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.chkEncriptar.Location = new System.Drawing.Point(70, 280);
            this.chkEncriptar.Name = "chkEncriptar";
            this.chkEncriptar.Size = new System.Drawing.Size(176, 29);
            this.chkEncriptar.TabIndex = 8;
            this.chkEncriptar.Text = "Encriptar backup";
            this.toolTip1.SetToolTip(this.chkEncriptar, "AES-256");
            // 
            // chkVerificar
            // 
            this.chkVerificar.AutoSize = true;
            this.chkVerificar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.chkVerificar.Location = new System.Drawing.Point(350, 280);
            this.chkVerificar.Name = "chkVerificar";
            this.chkVerificar.Size = new System.Drawing.Size(196, 29);
            this.chkVerificar.TabIndex = 9;
            this.chkVerificar.Text = "Verificar integridad";
            // 
            // chkComprimir
            // 
            this.chkComprimir.AutoSize = true;
            this.chkComprimir.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.chkComprimir.Location = new System.Drawing.Point(650, 280);
            this.chkComprimir.Name = "chkComprimir";
            this.chkComprimir.Size = new System.Drawing.Size(190, 29);
            this.chkComprimir.TabIndex = 10;
            this.chkComprimir.Text = "Comprimir backup";
            this.toolTip1.SetToolTip(this.chkComprimir, "Comprimir ZIP");
            // 
            // chkCorreo
            // 
            this.chkCorreo.AutoSize = true;
            this.chkCorreo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.chkCorreo.Location = new System.Drawing.Point(930, 280);
            this.chkCorreo.Name = "chkCorreo";
            this.chkCorreo.Size = new System.Drawing.Size(199, 29);
            this.chkCorreo.TabIndex = 11;
            this.chkCorreo.Text = "Enviar alerta correo";
            // 
            // chkEspejo
            // 
            this.chkEspejo.AutoSize = true;
            this.chkEspejo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.chkEspejo.Location = new System.Drawing.Point(1220, 280);
            this.chkEspejo.Name = "chkEspejo";
            this.chkEspejo.Size = new System.Drawing.Size(155, 29);
            this.chkEspejo.TabIndex = 12;
            this.chkEspejo.Text = "Backup espejo";
            this.toolTip1.SetToolTip(this.chkEspejo, "Crear copia espejo");
            // 
            // btnRuta
            // 
            this.btnRuta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRuta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRuta.FlatAppearance.BorderSize = 0;
            this.btnRuta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRuta.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnRuta.ForeColor = System.Drawing.Color.White;
            this.btnRuta.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            this.btnRuta.IconColor = System.Drawing.Color.White;
            this.btnRuta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRuta.IconSize = 28;
            this.btnRuta.Location = new System.Drawing.Point(950, 105);
            this.btnRuta.Name = "btnRuta";
            this.btnRuta.Size = new System.Drawing.Size(200, 50);
            this.btnRuta.TabIndex = 13;
            this.btnRuta.Text = " Seleccionar";
            this.btnRuta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRuta.UseVisualStyleBackColor = false;
            this.btnRuta.Click += new System.EventHandler(this.btnRuta_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackup.FlatAppearance.BorderSize = 0;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.IconChar = FontAwesome.Sharp.IconChar.Database;
            this.btnBackup.IconColor = System.Drawing.Color.White;
            this.btnBackup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBackup.IconSize = 28;
            this.btnBackup.Location = new System.Drawing.Point(70, 450);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(230, 58);
            this.btnBackup.TabIndex = 14;
            this.btnBackup.Text = " Generar Backup";
            this.btnBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnBackup, "Generar backup seguro");
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestore.FlatAppearance.BorderSize = 0;
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnRestore.ForeColor = System.Drawing.Color.White;
            this.btnRestore.IconChar = FontAwesome.Sharp.IconChar.RotateBackward;
            this.btnRestore.IconColor = System.Drawing.Color.White;
            this.btnRestore.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRestore.IconSize = 28;
            this.btnRestore.Location = new System.Drawing.Point(350, 450);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(210, 58);
            this.btnRestore.TabIndex = 15;
            this.btnRestore.Text = " Restaurar";
            this.btnRestore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnRestore, "Restaurar backup");
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnVerificar
            // 
            this.btnVerificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnVerificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerificar.FlatAppearance.BorderSize = 0;
            this.btnVerificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerificar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnVerificar.ForeColor = System.Drawing.Color.White;
            this.btnVerificar.IconChar = FontAwesome.Sharp.IconChar.ShieldAlt;
            this.btnVerificar.IconColor = System.Drawing.Color.White;
            this.btnVerificar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVerificar.IconSize = 28;
            this.btnVerificar.Location = new System.Drawing.Point(620, 450);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(210, 58);
            this.btnVerificar.TabIndex = 16;
            this.btnVerificar.Text = " Verificar";
            this.btnVerificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVerificar.UseVisualStyleBackColor = false;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.IconChar = FontAwesome.Sharp.IconChar.FileExport;
            this.btnExportar.IconColor = System.Drawing.Color.White;
            this.btnExportar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExportar.IconSize = 28;
            this.btnExportar.Location = new System.Drawing.Point(890, 450);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(210, 58);
            this.btnExportar.TabIndex = 17;
            this.btnExportar.Text = " Exportar";
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportar.UseVisualStyleBackColor = false;
            // 
            // dgvBackupHistorial
            // 
            this.dgvBackupHistorial.AllowUserToAddRows = false;
            this.dgvBackupHistorial.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.dgvBackupHistorial.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBackupHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBackupHistorial.BackgroundColor = System.Drawing.Color.White;
            this.dgvBackupHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBackupHistorial.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(35)))), ((int)(((byte)(66)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            this.dgvBackupHistorial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBackupHistorial.ColumnHeadersHeight = 45;
            this.dgvBackupHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBackupHistorial.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvBackupHistorial.EnableHeadersVisualStyles = false;
            this.dgvBackupHistorial.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.dgvBackupHistorial.Location = new System.Drawing.Point(40, 560);
            this.dgvBackupHistorial.MultiSelect = false;
            this.dgvBackupHistorial.Name = "dgvBackupHistorial";
            this.dgvBackupHistorial.ReadOnly = true;
            this.dgvBackupHistorial.RowHeadersVisible = false;
            this.dgvBackupHistorial.RowHeadersWidth = 51;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.dgvBackupHistorial.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvBackupHistorial.RowTemplate.Height = 42;
            this.dgvBackupHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBackupHistorial.Size = new System.Drawing.Size(1580, 500);
            this.dgvBackupHistorial.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(650, 174);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 85);
            this.panel1.TabIndex = 19;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // FrmBackup
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1600, 900);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBackup";
            this.Text = "FrmBackup";
            this.Load += new System.EventHandler(this.FrmBackup_Load);
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
        private Panel panel1;
    }
}