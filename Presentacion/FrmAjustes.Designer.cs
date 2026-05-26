// CLASE PARCIAL DEL FORMULARIO DE AJUSTES
namespace Sistema_Inventario.Presentacion
{
    partial class FrmAjustes
    {
        // CONTENEDOR DE COMPONENTES
        private System.ComponentModel.IContainer components = null;

        // METODO PARA LIBERAR RECURSOS
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();

            // TIMER — reloj del header
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);

            // FORMULARIO
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Name = "FrmAjustes";
            this.Text = "FrmAjustes";
            this.Load += new System.EventHandler(this.FrmAjustes_Load);

            this.ResumeLayout(false);
        }

        #endregion

        // TIMER
        private System.Windows.Forms.Timer timer1;

        // LABELS DE INFORMACION DEL SISTEMA (existentes)
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblServidor;
        private System.Windows.Forms.Label lblBaseDatos;
        private System.Windows.Forms.Label lblEstadoConexion;

        // LABELS KPI (existentes)
        private System.Windows.Forms.Label lblTotalUsuarios;
        private System.Windows.Forms.Label lblTotalProductos;
        private System.Windows.Forms.Label lblTotalRoles;
        private System.Windows.Forms.Label lblTotalLogs;

        // TEXTBOX SEGURIDAD (existente)
        private System.Windows.Forms.TextBox txtNuevaClave;
    }
}
