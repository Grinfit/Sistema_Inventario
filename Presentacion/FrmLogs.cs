using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

using Sistema_Inventario.Datos;

namespace Sistema_Inventario.Presentacion
{
    public partial class FrmLogs : Form
    {
        Conexion cn = new Conexion();

        public FrmLogs()
        {
            InitializeComponent();
        }

        private void FrmLogs_Load(
            object sender,
            EventArgs e)
        {
            MostrarLogs();
        }

        private void MostrarLogs()
        {
            try
            {
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        "SELECT * FROM LogsSistema ORDER BY Fecha DESC",
                        cn.AbrirConexion());

                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvLogs.DataSource = dt;

                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}