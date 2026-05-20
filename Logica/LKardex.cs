// IMPORTACION DE LIBRERIAS NECESARIAS
using Sistema_Inventario.Datos;
using System.Data;

namespace Sistema_Inventario.Logica
{
    // CLASE ENCARGADA DE LA LOGICA DEL KARDEX
    public class LKardex
    {
        // OBJETO DE LA CLASE DKARDEX
        DKardex dKardex =
            new DKardex();

        // METODO PARA MOSTRAR LOS PRODUCTOS
        public DataTable MostrarProductos()
        {
            return dKardex.MostrarProductos();
        }

        // METODO PARA MOSTRAR EL KARDEX
        public DataTable MostrarKardex()
        {
            return dKardex.MostrarKardex();
        }

        // METODO PARA FILTRAR PRODUCTOS EN EL KARDEX
        public DataTable FiltrarProducto(
            int idProducto)
        {
            return dKardex.FiltrarProducto(
                idProducto);
        }
    }
}