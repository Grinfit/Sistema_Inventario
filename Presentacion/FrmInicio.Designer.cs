namespace Sistema_Inventario.Presentacion
{
    partial class FrmInicio
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
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
            this.panelDashboard = new System.Windows.Forms.Panel();

            this.panelClientes = new System.Windows.Forms.Panel();
            this.panelProductos = new System.Windows.Forms.Panel();
            this.panelVentas = new System.Windows.Forms.Panel();
            this.panelLogin = new System.Windows.Forms.Panel();

            this.panelActividad = new System.Windows.Forms.Panel();

            this.lblTitulo = new System.Windows.Forms.Label();

            this.lblClientesTitulo = new System.Windows.Forms.Label();
            this.lblProductosTitulo = new System.Windows.Forms.Label();
            this.lblVentasTitulo = new System.Windows.Forms.Label();
            this.lblLoginTitulo = new System.Windows.Forms.Label();

            this.lblClientes = new System.Windows.Forms.Label();
            this.lblProductos = new System.Windows.Forms.Label();
            this.lblVentas = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // FrmInicio

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.None;

            this.BackColor =
                System.Drawing.Color.White;

            this.ClientSize =
                new System.Drawing.Size(1400, 850);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.None;

            this.Name = "FrmInicio";

            this.Text = "FrmInicio";

            this.Load +=
                new System.EventHandler(this.FrmInicio_Load);

            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelDashboard;

        private System.Windows.Forms.Panel panelClientes;
        private System.Windows.Forms.Panel panelProductos;
        private System.Windows.Forms.Panel panelVentas;
        private System.Windows.Forms.Panel panelLogin;

        private System.Windows.Forms.Panel panelActividad;

        private System.Windows.Forms.Label lblTitulo;

        private System.Windows.Forms.Label lblClientesTitulo;
        private System.Windows.Forms.Label lblProductosTitulo;
        private System.Windows.Forms.Label lblVentasTitulo;
        private System.Windows.Forms.Label lblLoginTitulo;

        private System.Windows.Forms.Label lblClientes;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.Label lblVentas;
        private System.Windows.Forms.Label lblLogin;
    }
}