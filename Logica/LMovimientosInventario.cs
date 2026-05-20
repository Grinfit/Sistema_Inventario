using Sistema_Inventario.Datos;
using System.Data;

namespace Sistema_Inventario.Logica
{
    public class LMovimientosInventario
    {
        DMovimientosInventario dMovimientos =
            new DMovimientosInventario();

        // =====================================
        // PRODUCTOS
        // =====================================

        public DataTable MostrarProductos()
        {
            return dMovimientos.MostrarProductos();
        }

        // =====================================
        // BODEGAS
        // =====================================

        public DataTable MostrarBodegas()
        {
            return dMovimientos.MostrarBodegas();
        }

        // =====================================
        // TIPOS MOVIMIENTO
        // =====================================

        public DataTable MostrarTiposMovimiento()
        {
            return dMovimientos.MostrarTiposMovimiento();
        }

        // =====================================
        // MOSTRAR MOVIMIENTOS
        // =====================================

        public DataTable MostrarMovimientos()
        {
            return dMovimientos.MostrarMovimientos();
        }

        // =====================================
        // REGISTRAR MOVIMIENTO
        // =====================================

        public void RegistrarMovimiento(
            int idTipoMovimiento,
            int idProducto,
            int idBodega,
            decimal cantidad,
            string observacion,
            string usuario)
        {
            dMovimientos.RegistrarMovimiento(
                idTipoMovimiento,
                idProducto,
                idBodega,
                cantidad,
                observacion,
                usuario);
        }

        // =====================================
        // OBTENER STOCK ACTUAL
        // =====================================

        public decimal ObtenerStockActual(
            int idProducto,
            int idBodega)
        {
            return dMovimientos.ObtenerStockActual(
                idProducto,
                idBodega);
        }
    }
}