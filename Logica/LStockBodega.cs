using Sistema_Inventario.Datos;
using System.Data;

namespace Sistema_Inventario.Logica
{
    public class LStockBodega
    {
        DStockBodega dStock =
            new DStockBodega();

        public DataTable MostrarStock()
        {
            return dStock.MostrarStock();
        }

        public DataTable MostrarStockBajo()
        {
            return dStock.MostrarStockBajo();
        }
    }
}