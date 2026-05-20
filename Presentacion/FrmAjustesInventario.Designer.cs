// CLASE PARCIAL DEL FORMULARIO AJUSTES INVENTARIO
namespace Sistema_Inventario.Presentacion
{
    // CLASE PARCIAL GENERADA POR EL DISEÑADOR
    partial class FrmAjustesInventario
    {
        // VARIABLE NECESARIA PARA LOS COMPONENTES DEL FORMULARIO
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // METODO PARA LIBERAR LOS RECURSOS UTILIZADOS
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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

        // REGION GENERADA POR EL DISEÑADOR
        #region Windows Form Designer generated code

        // METODO PARA INICIALIZAR LOS COMPONENTES
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // INICIALIZA EL CONTENEDOR DE COMPONENTES
            this.components = new System.ComponentModel.Container();

            // CONFIGURA EL MODO DE ESCALADO
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            // CONFIGURA EL TAMAÑO DEL FORMULARIO
            this.ClientSize = new System.Drawing.Size(800, 450);

            // CONFIGURA EL TITULO DEL FORMULARIO
            this.Text = "FrmAjustesInventario";
        }

        #endregion
    }
}