using Sistema_Inventario.Datos;
using System.Data;

namespace Sistema_Inventario.Logica
{
    public class LMovimientosInventario
    {
        DMovimientosInventario dMovimientos =
            new DMovimientosInventario();

        public DataTable MostrarProductos()
        {
            return dMovimientos.MostrarProductos();
        }

        public DataTable MostrarBodegas()
        {
            return dMovimientos.MostrarBodegas();
        }

        public DataTable MostrarTiposMovimiento()
        {
            return dMovimientos.MostrarTiposMovimiento();
        }

        public DataTable MostrarMovimientos()
        {
            return dMovimientos.MostrarMovimientos();
        }

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
    }
}