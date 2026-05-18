using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

using Sistema_Inventario.Datos;
using Sistema_Inventario.Utilidades;

namespace Sistema_Inventario.Presentacion
{
    public partial class FrmClientes : Form
    {
        Conexion cn = new Conexion();

        Logger log = new Logger();

        int IdCliente = 0;

        public FrmClientes()
        {
            InitializeComponent();
        }

        private void MostrarClientes()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "sp_MostrarClientes",
                    cn.AbrirConexion());

                da.SelectCommand.CommandType =
                    CommandType.StoredProcedure;

                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvClientes.DataSource = dt;

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                log.RegistrarLog(
                    "ERROR CLIENTES",
                    "admin",
                    ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();

            txtNombre.Focus();
        }

        private void FrmClientes_Load(
            object sender,
            EventArgs e)
        {
            MostrarClientes();
        }

        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "sp_InsertarCliente",
                    cn.AbrirConexion());

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@Nombre",
                    txtNombre.Text);

                cmd.Parameters.AddWithValue(
                    "@Telefono",
                    txtTelefono.Text);

                cmd.Parameters.AddWithValue(
                    "@Correo",
                    txtCorreo.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "Cliente guardado correctamente");

                MostrarClientes();

                LimpiarCampos();

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                log.RegistrarLog(
                    "ERROR CLIENTE",
                    "admin",
                    ex.Message);
            }
        }

        private void dgvClientes_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            try
            {
                IdCliente = Convert.ToInt32(
                    dgvClientes.CurrentRow.Cells[0].Value);

                txtNombre.Text =
                    dgvClientes.CurrentRow.Cells[1].Value.ToString();

                txtTelefono.Text =
                    dgvClientes.CurrentRow.Cells[2].Value.ToString();

                txtCorreo.Text =
                    dgvClientes.CurrentRow.Cells[3].Value.ToString();
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
                SqlCommand cmd = new SqlCommand(
                    "sp_EditarCliente",
                    cn.AbrirConexion());

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@IdCliente",
                    IdCliente);

                cmd.Parameters.AddWithValue(
                    "@Nombre",
                    txtNombre.Text);

                cmd.Parameters.AddWithValue(
                    "@Telefono",
                    txtTelefono.Text);

                cmd.Parameters.AddWithValue(
                    "@Correo",
                    txtCorreo.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "Cliente actualizado");

                MostrarClientes();

                LimpiarCampos();

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                log.RegistrarLog(
                    "ERROR EDITAR CLIENTE",
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
                    "¿Desea eliminar este cliente?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand(
                        "sp_EliminarCliente",
                        cn.AbrirConexion());

                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "@IdCliente",
                        IdCliente);

                    cmd.ExecuteNonQuery();

                    log.RegistrarLog(
                        "ELIMINAR CLIENTE",
                        "admin",
                        "Cliente eliminado correctamente");

                    MessageBox.Show(
                        "Cliente eliminado");

                    MostrarClientes();

                    LimpiarCampos();

                    cn.CerrarConexion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                log.RegistrarLog(
                    "ERROR ELIMINAR CLIENTE",
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
                SqlDataAdapter da = new SqlDataAdapter(
                    "sp_BuscarCliente",
                    cn.AbrirConexion());

                da.SelectCommand.CommandType =
                    CommandType.StoredProcedure;

                da.SelectCommand.Parameters.AddWithValue(
                    "@Texto",
                    txtBuscar.Text);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvClientes.DataSource = dt;

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                log.RegistrarLog(
                    "ERROR BUSCAR CLIENTE",
                    "admin",
                    ex.Message);
            }
        }

        private void btnNuevo_Click(
            object sender,
            EventArgs e)
        {
            LimpiarCampos();

            MostrarClientes();

            IdCliente = 0;
        }
    }
}