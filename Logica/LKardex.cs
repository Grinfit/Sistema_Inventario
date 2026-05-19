using Sistema_Inventario.Datos;
using System.Data;

namespace Sistema_Inventario.Logica
{
    public class LKardex
    {
        DKardex dKardex =
            new DKardex();

        public DataTable MostrarProductos()
        {
            return dKardex.MostrarProductos();
        }

        public DataTable MostrarKardex()
        {
            return dKardex.MostrarKardex();
        }

        public DataTable FiltrarProducto(
            int idProducto)
        {
            return dKardex.FiltrarProducto(
                idProducto);
        }
    }
}