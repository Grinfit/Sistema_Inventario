namespace Sistema_Inventario.Presentacion
{
    partial class FrmAjustes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(
            bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // 
            // FrmAjustes
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(
                    8F,
                    16F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.FromArgb(
                    245,
                    246,
                    250);

            this.ClientSize =
                new System.Drawing.Size(
                    1600,
                    900);

            this.Name =
                "FrmAjustes";

            this.Text =
                "FrmAjustes";

            this.Load +=
                new System.EventHandler(
                    this.FrmAjustes_Load);

            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblServidor;
        private System.Windows.Forms.Label lblBaseDatos;
        private System.Windows.Forms.Label lblEstadoConexion;

        private System.Windows.Forms.Label lblTotalUsuarios;
        private System.Windows.Forms.Label lblTotalProductos;
        private System.Windows.Forms.Label lblTotalRoles;
        private System.Windows.Forms.Label lblTotalLogs;

        private System.Windows.Forms.TextBox txtNuevaClave;
    }
}