// IMPORTACION DE LA CAPA LOGICA DEL SISTEMA
using Sistema_Inventario.Logica;

// IMPORTACION DE LIBRERIAS NECESARIAS
using System;
using System.Drawing;
using System.Windows.Forms;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Presentacion
{
    // FORMULARIO ENCARGADO DE MOSTRAR EL STOCK POR BODEGA
    public partial class FrmStockBodega : Form
    {
        // OBJETO DE LA CAPA LOGICA PARA EL MANEJO DEL STOCK
        LStockBodega lStock =
            new LStockBodega();

        // CONSTRUCTOR DEL FORMULARIO
        public FrmStockBodega()
        {
            // INICIALIZA LOS COMPONENTES DEL FORMULARIO
            InitializeComponent();
        }

        // =====================================
        // LOAD
        // =====================================

        // EVENTO QUE SE EJECUTA AL CARGAR EL FORMULARIO
        private void FrmStockBodega_Load(
            object sender,
            EventArgs e)
        {
            // MUESTRA EL STOCK EN EL DATAGRIDVIEW
            MostrarStock();

            // PINTA LOS PRODUCTOS CON STOCK BAJO
            PintarStockBajo();
        }

        // =====================================
        // MOSTRAR
        // =====================================

        // METODO PARA MOSTRAR EL STOCK
        private void MostrarStock()
        {
            // ASIGNA LOS DATOS AL DATAGRIDVIEW
            dgvStock.DataSource =
                lStock.MostrarStock();
        }

        // =====================================
        // STOCK BAJO
        // =====================================

        // METODO PARA RESALTAR LOS PRODUCTOS CON STOCK BAJO
        private void PintarStockBajo()
        {
            // RECORRE TODAS LAS FILAS DEL DATAGRIDVIEW
            foreach (DataGridViewRow fila
                in dgvStock.Rows)
            {
                // OBTIENE EL STOCK ACTUAL
                decimal stock =
                    Convert.ToDecimal(
                        fila.Cells["StockActual"].Value);

                // VERIFICA SI EL STOCK ES MENOR O IGUAL A 5
                if (stock <= 5)
                {
                    // CAMBIA EL COLOR DE FONDO DE LA FILA
                    fila.DefaultCellStyle.BackColor =
                        Color.FromArgb(255, 235, 238);

                    // CAMBIA EL COLOR DEL TEXTO
                    fila.DefaultCellStyle.ForeColor =
                        Color.DarkRed;
                }
            }
        }

        // =====================================
        // RECARGAR
        // =====================================

        // EVENTO DEL BOTON RECARGAR
        private void btnRecargar_Click(
            object sender,
            EventArgs e)
        {
            // MUESTRA NUEVAMENTE EL STOCK
            MostrarStock();

            // PINTA LOS PRODUCTOS CON STOCK BAJO
            PintarStockBajo();
        }

        // =====================================
        // SOLO STOCK BAJO
        // =====================================

        // EVENTO DEL BOTON STOCK BAJO
        private void btnStockBajo_Click(
            object sender,
            EventArgs e)
        {
            // MUESTRA SOLO LOS PRODUCTOS CON STOCK BAJO
            dgvStock.DataSource =
                lStock.MostrarStockBajo();

            // PINTA LOS PRODUCTOS CON STOCK BAJO
            PintarStockBajo();
        }

        // EVENTO DEL BOTON EXPORTAR
        private void btnExportar_Click(
    object sender,
    EventArgs e)
        {
            // EXPORTA LOS DATOS DEL DATAGRIDVIEW A EXCEL
            ExportarExcel.Exportar(
                dgvStock,
                "Reporte_Stock");
        }
    }
}