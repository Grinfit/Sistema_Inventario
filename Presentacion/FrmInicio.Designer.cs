// CLASE PARCIAL DEL FORMULARIO INICIO
namespace Sistema_Inventario.Presentacion
{
    partial class FrmInicio
    {
        // CONTENEDOR DE COMPONENTES
        private System.ComponentModel.IContainer components = null;

        // METODO PARA LIBERAR RECURSOS
        protected override void Dispose(bool disposing)
        {
            // VERIFICA SI LOS COMPONENTES DEBEN LIBERARSE
            if (disposing &&
                (components != null))
            {
                // LIBERA LOS COMPONENTES
                components.Dispose();
            }

            // LLAMA AL METODO BASE
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        // METODO PARA INICIALIZAR COMPONENTES
        private void InitializeComponent()
        {
            // PANEL PRINCIPAL DEL DASHBOARD
            this.panelDashboard = new System.Windows.Forms.Panel();

            // PANELES KPI
            this.panelClientes = new System.Windows.Forms.Panel();
            this.panelProductos = new System.Windows.Forms.Panel();
            this.panelVentas = new System.Windows.Forms.Panel();
            this.panelLogin = new System.Windows.Forms.Panel();

            // PANEL ACTIVIDAD
            this.panelActividad = new System.Windows.Forms.Panel();

            // LABEL TITULO PRINCIPAL
            this.lblTitulo = new System.Windows.Forms.Label();

            // LABELS TITULOS KPI
            this.lblClientesTitulo = new System.Windows.Forms.Label();
            this.lblProductosTitulo = new System.Windows.Forms.Label();
            this.lblVentasTitulo = new System.Windows.Forms.Label();
            this.lblLoginTitulo = new System.Windows.Forms.Label();

            // LABELS VALORES KPI
            this.lblClientes = new System.Windows.Forms.Label();
            this.lblProductos = new System.Windows.Forms.Label();
            this.lblVentas = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();

            // SUSPENDE EL DISEÑO DEL FORMULARIO
            this.SuspendLayout();

            // FrmInicio

            // CONFIGURA EL ESCALADO
            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.None;

            // COLOR DE FONDO DEL FORMULARIO
            this.BackColor =
                System.Drawing.Color.White;

            // TAMAÑO DEL FORMULARIO
            this.ClientSize =
                new System.Drawing.Size(1400, 850);

            // ELIMINA LOS BORDES
            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.None;

            // NOMBRE DEL FORMULARIO
            this.Name = "FrmInicio";

            // TITULO DEL FORMULARIO
            this.Text = "FrmInicio";

            // EVENTO LOAD DEL FORMULARIO
            this.Load +=
                new System.EventHandler(this.FrmInicio_Load);

            // REANUDA EL DISEÑO
            this.ResumeLayout(false);
        }

        #endregion

        // PANEL PRINCIPAL
        private System.Windows.Forms.Panel panelDashboard;

        // PANELES KPI
        private System.Windows.Forms.Panel panelClientes;
        private System.Windows.Forms.Panel panelProductos;
        private System.Windows.Forms.Panel panelVentas;
        private System.Windows.Forms.Panel panelLogin;

        // PANEL ACTIVIDAD
        private System.Windows.Forms.Panel panelActividad;

        // LABEL TITULO
        private System.Windows.Forms.Label lblTitulo;

        // LABELS TITULOS KPI
        private System.Windows.Forms.Label lblClientesTitulo;
        private System.Windows.Forms.Label lblProductosTitulo;
        private System.Windows.Forms.Label lblVentasTitulo;
        private System.Windows.Forms.Label lblLoginTitulo;

        // LABELS VALORES KPI
        private System.Windows.Forms.Label lblClientes;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.Label lblVentas;
        private System.Windows.Forms.Label lblLogin;
    }
}