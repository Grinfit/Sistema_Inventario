// IMPORTACION DE LIBRERIAS NECESARIAS
using Sistema_Inventario.Datos;
using System.Data;

namespace Sistema_Inventario.Logica
{
    // CLASE ENCARGADA DE LA LOGICA DE BODEGAS
    public class LBodegas
    {
        // OBJETO DE LA CLASE DBODEGAS
        DBodegas dBodegas =
            new DBodegas();

        // METODO PARA MOSTRAR LAS BODEGAS
        public DataTable MostrarBodegas()
        {
            return dBodegas.MostrarBodegas();
        }

        // METODO PARA INSERTAR UNA BODEGA
        public void InsertarBodega(
            string nombre,
            string direccion)
        {
            dBodegas.InsertarBodega(
                nombre,
                direccion);
        }

        // METODO PARA EDITAR UNA BODEGA
        public void EditarBodega(
            int idBodega,
            string nombre,
            string direccion)
        {
            dBodegas.EditarBodega(
                idBodega,
                nombre,
                direccion);
        }

        // METODO PARA ELIMINAR UNA BODEGA
        public void EliminarBodega(
            int idBodega)
        {
            dBodegas.EliminarBodega(
                idBodega);
        }

        // METODO PARA BUSCAR UNA BODEGA
        public DataTable BuscarBodega(
            string buscar)
        {
            return dBodegas.BuscarBodega(
                buscar);
        }
    }
}