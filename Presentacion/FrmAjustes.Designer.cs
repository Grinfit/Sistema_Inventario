// CLASE PARCIAL DEL FORMULARIO DE AJUSTES
namespace Sistema_Inventario.Presentacion
{
    // CLASE PARCIAL GENERADA POR EL DISEÑADOR
    partial class FrmAjustes
    {
        // CONTENEDOR DE COMPONENTES DEL FORMULARIO
        private System.ComponentModel.IContainer components = null;

        // METODO PARA LIBERAR RECURSOS
        protected override void Dispose(
            bool disposing)
        {
            // VERIFICA SI SE DEBEN LIBERAR LOS COMPONENTES
            if (disposing &&
                (components != null))
            {
                // LIBERA LOS COMPONENTES
                components.Dispose();
            }

            // LLAMA AL METODO BASE
            base.Dispose(disposing);
        }

        // REGION GENERADA POR EL DISEÑADOR
        #region Código generado por el Diseñador

        // METODO PARA INICIALIZAR LOS COMPONENTES
        private void InitializeComponent()
        {
            // SUSPENDE EL DISEÑO DEL FORMULARIO
            this.SuspendLayout();

            // CONFIGURACION DEL FORMULARIO
            // FrmAjustes

            // CONFIGURA EL ESCALADO AUTOMATICO
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(
                    8F,
                    16F);

            // DEFINE EL MODO DE ESCALADO
            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            // DEFINE EL COLOR DE FONDO
            this.BackColor =
                System.Drawing.Color.FromArgb(
                    245,
                    246,
                    250);

            // DEFINE EL TAMAÑO DEL FORMULARIO
            this.ClientSize =
                new System.Drawing.Size(
                    1600,
                    900);

            // DEFINE EL NOMBRE DEL FORMULARIO
            this.Name =
                "FrmAjustes";

            // DEFINE EL TEXTO DEL FORMULARIO
            this.Text =
                "FrmAjustes";

            // EVENTO LOAD DEL FORMULARIO
            this.Load +=
                new System.EventHandler(
                    this.FrmAjustes_Load);

            // REANUDA EL DISEÑO DEL FORMULARIO
            this.ResumeLayout(false);
        }

        #endregion

        // LABEL DEL USUARIO
        private System.Windows.Forms.Label lblUsuario;

        // LABEL DEL ROL
        private System.Windows.Forms.Label lblRol;

        // LABEL DE LA FECHA
        private System.Windows.Forms.Label lblFecha;

        // LABEL DEL SERVIDOR
        private System.Windows.Forms.Label lblServidor;

        // LABEL DE LA BASE DE DATOS
        private System.Windows.Forms.Label lblBaseDatos;

        // LABEL DEL ESTADO DE CONEXION
        private System.Windows.Forms.Label lblEstadoConexion;

        // LABEL TOTAL DE USUARIOS
        private System.Windows.Forms.Label lblTotalUsuarios;

        // LABEL TOTAL DE PRODUCTOS
        private System.Windows.Forms.Label lblTotalProductos;

        // LABEL TOTAL DE ROLES
        private System.Windows.Forms.Label lblTotalRoles;

        // LABEL TOTAL DE LOGS
        private System.Windows.Forms.Label lblTotalLogs;

        // TEXTBOX PARA NUEVA CLAVE
        private System.Windows.Forms.TextBox txtNuevaClave;
    }
}