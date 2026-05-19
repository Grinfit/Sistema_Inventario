using System;
using System.Windows.Forms;
using Sistema_Inventario.Utilidades;
using Sistema_Inventario.Datos;
using Sistema_Inventario.Logica;

namespace Sistema_Inventario.Presentacion
{
    public partial class FrmKardex : Form
    {
        LKardex lKardex =
            new LKardex();

        public FrmKardex()
        {
            InitializeComponent();
        }

        // =====================================
        // LOAD
        // =====================================

        private void FrmKardex_Load(
            object sender,
            EventArgs e)
        {
            CargarProductos();

            MostrarKardex();
        }

        // =====================================
        // PRODUCTOS
        // =====================================

        private void CargarProductos()
        {
            cboProducto.DataSource =
                lKardex.MostrarProductos();

            cboProducto.DisplayMember =
                "Nombre";

            cboProducto.ValueMember =
                "IdProducto";
        }

        // =====================================
        // MOSTRAR
        // =====================================

        private void MostrarKardex()
        {
            dgvKardex.DataSource =
                lKardex.MostrarKardex();
        }

        // =====================================
        // FILTRAR
        // =====================================

        private void btnBuscar_Click(
            object sender,
            EventArgs e)
        {
            dgvKardex.DataSource =
                lKardex.FiltrarProducto(
                    Convert.ToInt32(
                        cboProducto.SelectedValue));
        }

        // =====================================
        // RECARGAR
        // =====================================

        private void btnRecargar_Click(
            object sender,
            EventArgs e)
        {
            MostrarKardex();
        }
        private void btnExportar_Click(
    object sender,
    EventArgs e)
        {
            ExportarExcel.Exportar(
                dgvKardex,
                "Reporte_Kardex");
        }
    }
}