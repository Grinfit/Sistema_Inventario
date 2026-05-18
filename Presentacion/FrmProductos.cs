using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

using Sistema_Inventario.Datos;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Presentacion
{
    public partial class FrmProductos : Form
    {
        Conexion cn = new Conexion();

        Logger log = new Logger();

        int IdProducto = 0;

        public FrmProductos()
        {
            InitializeComponent();
        }

        private void FrmProductos_Load(
            object sender,
            EventArgs e)
        {
            MostrarProductos();
        }

        private void MostrarProductos()
        {
            try
            {
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        "sp_MostrarProductos",
                        cn.AbrirConexion());

                da.SelectCommand.CommandType =
                    CommandType.StoredProcedure;

                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvProductos.DataSource = dt;

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                log.RegistrarLog(
                    "ERROR PRODUCTOS",
                    "admin",
                    ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCategoria.Clear();
            txtPrecio.Clear();
            txtStock.Clear();

            txtNombre.Focus();
        }

        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                SqlCommand cmd =
                    new SqlCommand(
                        "sp_InsertarProducto",
                        cn.AbrirConexion());

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@Nombre",
                    txtNombre.Text);

                cmd.Parameters.AddWithValue(
                    "@Categoria",
                    txtCategoria.Text);

                cmd.Parameters.AddWithValue(
                    "@Precio",
                    txtPrecio.Text);

                cmd.Parameters.AddWithValue(
                    "@Stock",
                    txtStock.Text);

                cmd.ExecuteNonQuery();

                log.RegistrarLog(
                    "GUARDAR PRODUCTO",
                    "admin",
                    "Producto guardado correctamente");

                MessageBox.Show(
                    "Producto guardado correctamente");

                MostrarProductos();

                LimpiarCampos();

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                log.RegistrarLog(
                    "ERROR PRODUCTO",
                    "admin",
                    ex.Message);
            }
        }

        private void dgvProductos_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    IdProducto = Convert.ToInt32(
                        dgvProductos.Rows[e.RowIndex]
                        .Cells[0].Value);

                    txtNombre.Text =
                        dgvProductos.Rows[e.RowIndex]
                        .Cells[1].Value.ToString();

                    txtCategoria.Text =
                        dgvProductos.Rows[e.RowIndex]
                        .Cells[2].Value.ToString();

                    txtPrecio.Text =
                        dgvProductos.Rows[e.RowIndex]
                        .Cells[3].Value.ToString();

                    txtStock.Text =
                        dgvProductos.Rows[e.RowIndex]
                        .Cells[4].Value.ToString();
                }
            }
            catch
            {

            }
        }

        private void btnEditar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                SqlCommand cmd =
                    new SqlCommand(
                        "sp_EditarProducto",
                        cn.AbrirConexion());

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@IdProducto",
                    IdProducto);

                cmd.Parameters.AddWithValue(
                    "@Nombre",
                    txtNombre.Text);

                cmd.Parameters.AddWithValue(
                    "@Categoria",
                    txtCategoria.Text);

                cmd.Parameters.AddWithValue(
                    "@Precio",
                    txtPrecio.Text);

                cmd.Parameters.AddWithValue(
                    "@Stock",
                    txtStock.Text);

                cmd.ExecuteNonQuery();

                log.RegistrarLog(
                    "EDITAR PRODUCTO",
                    "admin",
                    "Producto actualizado correctamente");

                MessageBox.Show(
                    "Producto actualizado");

                MostrarProductos();

                LimpiarCampos();

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                log.RegistrarLog(
                    "ERROR EDITAR PRODUCTO",
                    "admin",
                    ex.Message);
            }
        }

        private void btnEliminar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                DialogResult resultado;

                resultado = MessageBox.Show(
                    "¿Desea eliminar este producto?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    SqlCommand cmd =
                        new SqlCommand(
                            "sp_EliminarProducto",
                            cn.AbrirConexion());

                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "@IdProducto",
                        IdProducto);

                    cmd.ExecuteNonQuery();

                    log.RegistrarLog(
                        "ELIMINAR PRODUCTO",
                        "admin",
                        "Producto eliminado correctamente");

                    MessageBox.Show(
                        "Producto eliminado");

                    MostrarProductos();

                    LimpiarCampos();

                    cn.CerrarConexion();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("REFERENCE"))
                {
                    MessageBox.Show(
                        "No se puede eliminar el producto porque ya tiene ventas registradas.",
                        "Producto relacionado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }

                log.RegistrarLog(
                    "ERROR ELIMINAR PRODUCTO",
                    "admin",
                    ex.Message);
            }
        }

        private void btnBuscar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        "sp_BuscarProducto",
                        cn.AbrirConexion());

                da.SelectCommand.CommandType =
                    CommandType.StoredProcedure;

                da.SelectCommand.Parameters.AddWithValue(
                    "@Texto",
                    txtBuscar.Text);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvProductos.DataSource = dt;

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                log.RegistrarLog(
                    "ERROR BUSCAR PRODUCTO",
                    "admin",
                    ex.Message);
            }
        }

        private void btnNuevo_Click(
            object sender,
            EventArgs e)
        {
            LimpiarCampos();

            MostrarProductos();

            IdProducto = 0;
        }
    }
}