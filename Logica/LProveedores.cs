using Sistema_Inventario.Datos;
using System.Data;

namespace Sistema_Inventario.Logica
{
    public class LProveedores
    {
        DProveedores dProveedores =
            new DProveedores();

        // =====================================
        // MOSTRAR
        // =====================================

        public DataTable MostrarProveedores()
        {
            return dProveedores.MostrarProveedores();
        }

        // =====================================
        // INSERTAR
        // =====================================

        public void InsertarProveedor(
            string nombre,
            string empresa,
            string telefono,
            string correo,
            string direccion)
        {
            dProveedores.InsertarProveedor(
                nombre,
                empresa,
                telefono,
                correo,
                direccion);
        }

        // =====================================
        // EDITAR
        // =====================================

        public void EditarProveedor(
            int idProveedor,
            string nombre,
            string empresa,
            string telefono,
            string correo,
            string direccion)
        {
            dProveedores.EditarProveedor(
                idProveedor,
                nombre,
                empresa,
                telefono,
                correo,
                direccion);
        }

        // =====================================
        // ELIMINAR
        // =====================================

        public void EliminarProveedor(
            int idProveedor)
        {
            dProveedores.EliminarProveedor(
                idProveedor);
        }

        // =====================================
        // BUSCAR
        // =====================================

        public DataTable BuscarProveedor(
            string buscar)
        {
            return dProveedores.BuscarProveedor(
                buscar);
        }
    }
}