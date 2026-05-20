// IMPORTACION DE LIBRERIA PARA ICONOS
using FontAwesome.Sharp;

namespace Sistema_Inventario.Presentacion
{
    // CLASE PARCIAL DEL FORMULARIO DASHBOARD
    partial class FrmDashboard
    {
        // CONTENEDOR DE COMPONENTES DEL FORMULARIO
        private System.ComponentModel.IContainer components = null;

        // METODO PARA LIBERAR RECURSOS
        protected override void Dispose(
            bool disposing)
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

        #region Windows Form Designer generated code

        // METODO PARA INICIALIZAR LOS COMPONENTES
        private void InitializeComponent()
        {
            // SUSPENDE EL DISEÑO DEL FORMULARIO
            this.SuspendLayout();

            // CONFIGURACION DEL FORMULARIO
            // FrmDashboard

            // CONFIGURA EL ESCALADO AUTOMATICO
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);

            // CONFIGURA EL MODO DE ESCALADO
            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            // CONFIGURA EL COLOR DE FONDO
            this.BackColor =
                System.Drawing.Color.White;

            // CONFIGURA EL TAMAÑO DEL FORMULARIO
            this.ClientSize =
                new System.Drawing.Size(1360, 768);

            // CONFIGURA EL TIPO DE BORDE
            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.None;

            // CONFIGURA EL NOMBRE DEL FORMULARIO
            this.Name =
                "FrmDashboard";

            // CONFIGURA LA POSICION INICIAL
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            // CONFIGURA EL TITULO DEL FORMULARIO
            this.Text =
                "Sistema Inventario";

            // CONFIGURA EL ESTADO DE LA VENTANA
            this.WindowState =
                System.Windows.Forms.FormWindowState.Maximized;

            // REANUDA EL DISEÑO DEL FORMULARIO
            this.ResumeLayout(false);
        }

        #endregion
    }
}