using Sistema_Inventario.Logica;
using System;
using System.Drawing;
using System.Windows.Forms;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Presentacion
{
    public partial class FrmStockBodega : Form
    {
        LStockBodega lStock =
            new LStockBodega();

        public FrmStockBodega()
        {
            InitializeComponent();
        }

        // =====================================
        // LOAD
        // =====================================

        private void FrmStockBodega_Load(
            object sender,
            EventArgs e)
        {
            MostrarStock();

            PintarStockBajo();
        }

        // =====================================
        // MOSTRAR
        // =====================================

        private void MostrarStock()
        {
            dgvStock.DataSource =
                lStock.MostrarStock();
        }

        // =====================================
        // STOCK BAJO
        // =====================================

        private void PintarStockBajo()
        {
            foreach (DataGridViewRow fila
                in dgvStock.Rows)
            {
                decimal stock =
                    Convert.ToDecimal(
                        fila.Cells["StockActual"].Value);

                if (stock <= 5)
                {
                    fila.DefaultCellStyle.BackColor =
                        Color.FromArgb(255, 235, 238);

                    fila.DefaultCellStyle.ForeColor =
                        Color.DarkRed;
                }
            }
        }

        // =====================================
        // RECARGAR
        // =====================================

        private void btnRecargar_Click(
            object sender,
            EventArgs e)
        {
            MostrarStock();

            PintarStockBajo();
        }

        // =====================================
        // SOLO STOCK BAJO
        // =====================================

        private void btnStockBajo_Click(
            object sender,
            EventArgs e)
        {
            dgvStock.DataSource =
                lStock.MostrarStockBajo();

            PintarStockBajo();
        }
        private void btnExportar_Click(
    object sender,
    EventArgs e)
        {
            ExportarExcel.Exportar(
                dgvStock,
                "Reporte_Stock");
        }
    }
}