using Sistema_Inventario.Datos;
using System.Data;

namespace Sistema_Inventario.Logica
{
    public class LBodegas
    {
        DBodegas dBodegas =
            new DBodegas();

        // =========================================
        // MOSTRAR
        // =========================================

        public DataTable MostrarBodegas()
        {
            return dBodegas.MostrarBodegas();
        }

        // =========================================
        // INSERTAR
        // =========================================

        public void InsertarBodega(
            string nombre,
            string direccion)
        {
            dBodegas.InsertarBodega(
                nombre,
                direccion);
        }

        // =========================================
        // EDITAR
        // =========================================

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

        // =========================================
        // ELIMINAR
        // =========================================

        public void EliminarBodega(
            int idBodega)
        {
            dBodegas.EliminarBodega(
                idBodega);
        }

        // =========================================
        // BUSCAR
        // =========================================

        public DataTable BuscarBodega(
            string buscar)
        {
            return dBodegas.BuscarBodega(
                buscar);
        }
    }
}