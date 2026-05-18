namespace Sistema_Inventario
{
    partial class FrmLogin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador.
        /// </summary>
        private void InitializeComponent()
        {
            this.Label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.btnIngresar = new FontAwesome.Sharp.IconButton();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();

            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();

            // 
            // FrmLogin
            // 
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 45);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FrmLogin_Load);

            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Tahoma", 13.8F);
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(270, 140);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(87, 28);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Usuario";

            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 13.8F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(230, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña";

            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Tahoma", 13.8F);
            this.txtUsuario.Location = new System.Drawing.Point(390, 136);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(220, 35);
            this.txtUsuario.TabIndex = 2;

            // 
            // txtClave
            // 
            this.txtClave.Font = new System.Drawing.Font("Tahoma", 13.8F);
            this.txtClave.Location = new System.Drawing.Point(390, 216);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(220, 35);
            this.txtClave.TabIndex = 3;
            this.txtClave.UseSystemPasswordChar = true;

            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Tahoma", 13.8F);
            this.btnIngresar.ForeColor = System.Drawing.Color.White;

            this.btnIngresar.IconChar = FontAwesome.Sharp.IconChar.SignInAlt;
            this.btnIngresar.IconColor = System.Drawing.Color.White;
            this.btnIngresar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnIngresar.IconSize = 28;

            this.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngresar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;

            this.btnIngresar.Location = new System.Drawing.Point(340, 320);
            this.btnIngresar.Name = "btnIngresar";

            this.btnIngresar.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);

            this.btnIngresar.Size = new System.Drawing.Size(190, 50);
            this.btnIngresar.TabIndex = 4;
            this.btnIngresar.Text = "Ingresar";

            this.btnIngresar.UseVisualStyleBackColor = false;

            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);

            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(30, 30, 45);

            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.UserLock;
            this.iconPictureBox1.IconColor = System.Drawing.Color.White;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;

            this.iconPictureBox1.IconSize = 120;

            this.iconPictureBox1.Location = new System.Drawing.Point(70, 120);

            this.iconPictureBox1.Name = "iconPictureBox1";

            this.iconPictureBox1.Size = new System.Drawing.Size(120, 120);

            this.iconPictureBox1.TabIndex = 5;
            this.iconPictureBox1.TabStop = false;

            // 
            // Controls
            // 
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Label1);

            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtClave;

        private FontAwesome.Sharp.IconButton btnIngresar;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
    }
}