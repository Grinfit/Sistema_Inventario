using Sistema_Inventario.Datos;
using System.Data;

namespace Sistema_Inventario.Logica
{
    public class LTransferencias
    {
        DTransferencias dTransferencias =
            new DTransferencias();

        public DataTable MostrarProductos()
        {
            return dTransferencias.MostrarProductos();
        }

        public DataTable MostrarBodegas()
        {
            return dTransferencias.MostrarBodegas();
        }

        public DataTable MostrarTransferencias()
        {
            return dTransferencias.MostrarTransferencias();
        }

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