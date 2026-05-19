using FontAwesome.Sharp;

namespace Sistema_Inventario.Presentacion
{
    partial class FrmDashboard
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // 
            // FrmDashboard
            // 

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.White;

            this.ClientSize =
                new System.Drawing.Size(1360, 768);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.None;

            this.Name =
                "FrmDashboard";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Sistema Inventario";

            this.WindowState =
                System.Windows.Forms.FormWindowState.Maximized;

            this.ResumeLayout(false);
        }

        #endregion
    }
}