// IMPORTACION DE LIBRERIAS NECESARIAS
using Sistema_Inventario.Datos;
using System.Data;

namespace Sistema_Inventario.Logica
{
    // CLASE ENCARGADA DE LA LOGICA DEL STOCK DE BODEGAS
    public class LStockBodega
    {
        // OBJETO DE LA CLASE DSTOCKBODEGA
        DStockBodega dStock =
            new DStockBodega();

        // METODO PARA MOSTRAR TODO EL STOCK
        public DataTable MostrarStock()
        {
            return dStock.MostrarStock();
        }

        // METODO PARA MOSTRAR EL STOCK BAJO
        public DataTable MostrarStockBajo()
        {
            return dStock.MostrarStockBajo();
        }

        // METODO PARA OBTENER LA LISTA DE PRODUCTOS
        public DataTable MostrarProductos()
        {
            return dStock.MostrarProductos();
        }

        // METODO PARA FILTRAR EL STOCK POR PRODUCTO
        public DataTable FiltrarPorProducto(int idProducto)
        {
            return dStock.FiltrarPorProducto(idProducto);
        }
    }
}