// IMPORTACION DE LIBRERIAS NECESARIAS
using Sistema_Inventario.Datos;
using System.Data;

namespace Sistema_Inventario.Logica
{
    // CLASE ENCARGADA DE LA LOGICA DE PROVEEDORES
    public class LProveedores
    {
        // OBJETO DE LA CLASE DPROVEEDORES
        DProveedores dProveedores =
            new DProveedores();

        // METODO PARA MOSTRAR LOS PROVEEDORES
        public DataTable MostrarProveedores()
        {
            return dProveedores.MostrarProveedores();
        }

        // METODO PARA INSERTAR UN PROVEEDOR
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

        // METODO PARA EDITAR UN PROVEEDOR
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

        // METODO PARA ELIMINAR UN PROVEEDOR
        public void EliminarProveedor(
            int idProveedor)
        {
            dProveedores.EliminarProveedor(
                idProveedor);
        }

        // METODO PARA BUSCAR UN PROVEEDOR
        public DataTable BuscarProveedor(
            string buscar)
        {
            return dProveedores.BuscarProveedor(
                buscar);
        }
    }
}