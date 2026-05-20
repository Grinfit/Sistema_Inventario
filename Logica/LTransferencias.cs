// IMPORTACION DE LIBRERIAS NECESARIAS
using Sistema_Inventario.Datos;
using System.Data;

namespace Sistema_Inventario.Logica
{
    // CLASE ENCARGADA DE LA LOGICA DE TRANSFERENCIAS
    public class LTransferencias
    {
        // OBJETO DE LA CLASE DTRANSFERENCIAS
        DTransferencias dTransferencias =
            new DTransferencias();

        // METODO PARA MOSTRAR LOS PRODUCTOS
        public DataTable MostrarProductos()
        {
            return dTransferencias.MostrarProductos();
        }

        // METODO PARA MOSTRAR LAS BODEGAS
        public DataTable MostrarBodegas()
        {
            return dTransferencias.MostrarBodegas();
        }

        // METODO PARA MOSTRAR LAS TRANSFERENCIAS
        public DataTable MostrarTransferencias()
        {
            return dTransferencias.MostrarTransferencias();
        }

        // METODO PARA TRANSFERIR PRODUCTOS ENTRE BODEGAS
        public void TransferirProducto(
            int idProducto,
            int idBodegaOrigen,
            int idBodegaDestino,
            decimal cantidad,
            string observacion,
            string usuario)
        {
            dTransferencias.TransferirProducto(
                idProducto,
                idBodegaOrigen,
                idBodegaDestino,
                cantidad,
                observacion,
                usuario);
        }
    }
}