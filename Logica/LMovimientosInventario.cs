// IMPORTACION DE LIBRERIAS NECESARIAS
using Sistema_Inventario.Datos;
using System.Data;

namespace Sistema_Inventario.Logica
{
    // CLASE ENCARGADA DE LA LOGICA DE MOVIMIENTOS DE INVENTARIO
    public class LMovimientosInventario
    {
        // OBJETO DE LA CLASE DMOVIMIENTOSINVENTARIO
        DMovimientosInventario dMovimientos =
            new DMovimientosInventario();

        // METODO PARA MOSTRAR LOS PRODUCTOS
        public DataTable MostrarProductos()
        {
            return dMovimientos.MostrarProductos();
        }

        // METODO PARA MOSTRAR LAS BODEGAS
        public DataTable MostrarBodegas()
        {
            return dMovimientos.MostrarBodegas();
        }

        // METODO PARA MOSTRAR LOS TIPOS DE MOVIMIENTO
        public DataTable MostrarTiposMovimiento()
        {
            return dMovimientos.MostrarTiposMovimiento();
        }

        // METODO PARA MOSTRAR LOS MOVIMIENTOS
        public DataTable MostrarMovimientos()
        {
            return dMovimientos.MostrarMovimientos();
        }

        // METODO PARA REGISTRAR UN MOVIMIENTO
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

        // METODO PARA OBTENER EL STOCK ACTUAL
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