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
    public partial class FrmVentas : Form
    {
        Conexion cn = new Conexion();

        Logger log = new Logger();

        public FrmVentas()
        {
            InitializeComponent();
        }

        private void CargarClientes()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM Clientes",
                cn.AbrirConexion());

            DataTable dt = new DataTable();

            da.Fill(dt);

            cbClientes.DataSource = dt;

            cbClientes.DisplayMember = "Nombre";

            cbClientes.ValueMember = "IdCliente";

            cn.CerrarConexion();
        }

        private void CargarProductos()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM Productos",
                cn.AbrirConexion());

            DataTable dt = new DataTable();

            da.Fill(dt);

            cbProductos.DataSource = dt;

            cbProductos.DisplayMember = "Nombre";

            cbProductos.ValueMember = "IdProducto";

            cn.CerrarConexion();
        }

        private void MostrarVentas()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "sp_MostrarVentas",
                cn.AbrirConexion());

            da.SelectCommand.CommandType =
                CommandType.StoredProcedure;

            DataTable dt = new DataTable();

            da.Fill(dt);

            dgvVentas.DataSource = dt;

            cn.CerrarConexion();
        }

        private void FrmVentas_Load(
            object sender,
            EventArgs e)
        {
            CargarClientes();

            CargarProductos();

            MostrarVentas();
        }

        private void cbProductos_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT Precio FROM Productos WHERE IdProducto=@Id",
                    cn.AbrirConexion());

                cmd.Parameters.AddWithValue(
                    "@Id",
                    cbProductos.SelectedValue);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtPrecio.Text =
                        dr["Precio"].ToString();
                }

                dr.Close();

                cn.CerrarConexion();
            }
            catch
            {

            }
        }

        private void txtCantidad_TextChanged(
            object sender,
            EventArgs e)
        {
            try
            {
                decimal precio =
                    Convert.ToDecimal(txtPrecio.Text);

                int cantidad =
                    Convert.ToInt32(txtCantidad.Text);

                decimal total = precio * cantidad;

                txtTotal.Text = total.ToString();
            }
            catch
            {
                txtTotal.Text = "";
            }
        }

        private void btnRegistrarVenta_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "sp_InsertarVenta",
                    cn.AbrirConexion());

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@IdCliente",
                    cbClientes.SelectedValue);

                cmd.Parameters.AddWithValue(
                    "@IdProducto",
                    cbProductos.SelectedValue);

                cmd.Parameters.AddWithValue(
                    "@Cantidad",
                    txtCantidad.Text);

                cmd.Parameters.AddWithValue(
                    "@Precio",
                    txtPrecio.Text);

                cmd.Parameters.AddWithValue(
                    "@Total",
                    txtTotal.Text);

                cmd.ExecuteNonQuery();

                log.RegistrarLog(
                    "VENTA",
                    "admin",
                    "Venta registrada correctamente");

                MessageBox.Show(
                    "Venta registrada correctamente");

                MostrarVentas();

                LimpiarCampos();

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                log.RegistrarLog(
                    "ERROR VENTA",
                    "admin",
                    ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtTotal.Clear();
        }

        private void btnNuevo_Click(
            object sender,
            EventArgs e)
        {
            LimpiarCampos();
        }
    }
}